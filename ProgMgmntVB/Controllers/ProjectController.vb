Imports System.Web.Mvc
Imports ProgMgmntVB.Models

Namespace Controllers
    Public Class ProjectController
        Inherits BaseController

        private readonly _projectModel As IProjectModel 
        private readonly _modelHelper As IModelHelper 

        public sub New (projectModel As IProjectModel, modelHelper As IModelHelper)
            _projectModel = projectModel
            _modelHelper = modelHelper
        End sub

        ' GET: Project
        <Authorize>
        public Function Index() As ActionResult
            Return View(_projectModel.GetProjectsByUserId(User.Identity.Name))
        End Function

        <Authorize>
        public Function  Details(Optional id As Int32 = 0) As ActionResult
            return  IIf(id = 0, nothing, View(_projectModel.Edit(id)))
        End Function
       
        <Authorize>
        public Function  Edit(Optional id As Int32 = 0) As ActionResult 
            return  IIf(id = 0, nothing, View(_projectModel.Edit(id)))
        End Function

        <Authorize>
        public Function  Create() as ActionResult
            return View(_projectModel.Create())
        End Function
        
        <Authorize>
        <HttpPost>
        public  Function Create(project as ProjectViewModels.Project, submit As string ) As ActionResult

            if submit = "Cancel" Then
                return RedirectToAction("Index")
            End If

            Call ValidateddlProjectTypes()

            project.ProjectType = Request.Form("ddlProjectTypes")

            If ModelState.IsValid And _modelHelper.IsEndDateLessThanStartDate(project, "Project") Then
                ModelState.AddModelError(String.Empty, "End Date cannot be less than Start Date.")
            End If

            if Not ModelState.IsValid Then
                return View(_projectModel.PopulateSelectedList(project))
            End If

            _projectModel.Create(project, User.Identity.Name)
            return RedirectToAction("Index")

        End Function
     
        <Authorize>
        <HttpPost>
        public Function  Edit(project as ProjectViewModels.Project, submit As string ) As ActionResult

            if submit = "Cancel" Then
                return RedirectToAction("Index")
            End If

            If ModelState.IsValid And _modelHelper.IsEndDateLessThanStartDate(project, "Project") Then
                ModelState.AddModelError(String.Empty, "End Date cannot be less than Start Date.")
            End If

            if Not ModelState.IsValid Then
                return View(_projectModel.PopulateSelectedList(project))
            End If

            dim theproject = project

            theproject.ProjectType = Request.Form("ProjectType")

            _projectModel.Edit(theproject, User.Identity.Name)

            return RedirectToAction("Index")

        End Function

        public  Function Delete(Optional id As Int32 = 0) as ActionResult

            if id > 0 Then
               _projectModel.Delete(id)
            end If

            return RedirectToAction("Index")

        End Function
        
        public Function  Cancel() As ActionResult
            return RedirectToAction("Index", "Home")
        End Function
        
        public function UploadFile(id As Int32) As ActionResult
            return RedirectToAction("UploadFile", "Upload", new With { .id = id, .type = "PM" })
        End function
       
        private sub ValidateddlProjectTypes()

            if Request.Form("ddlProjectTypes") = String.Empty Then
                exit sub
            End If

            for each  key1 in ModelState.Keys.ToList().Where(Function(key) ModelState.ContainsKey(key))

                if key1 <> "ProjectType" Then
                    continue for
                End If

                ModelState(key1).Errors.Clear()
            next

        End sub
    End Class
End Namespace