Imports System.Web.Mvc
Imports Microsoft.Owin.Security.Provider
Imports ProgMgmntVB.Models

Namespace Controllers
    Public Class TaskController
        Inherits BaseController

        private readonly _taskModel As ITaskModel 
        private readonly _projectModel As IProjectModel 
        private readonly _modelHelper As IModelHelper 

        public sub New (taskModel As ITaskModel,  projectModel As IProjectModel, modelHelper As IModelHelper)
            _taskModel = taskModel
            _projectModel = projectModel
            _modelHelper = modelHelper
        End sub

        ' GET: Task
        <Authorize>
        public Function Index(ByVal id As Int32) As ActionResult

            dim project = _projectModel.GetProjectById(id)

            TempData("ProjectId") = id
            TempData("Title") = project.ProjectName

            return View(_taskModel.GetTasksByProjectId(id))
            
        End Function

        <Authorize>
        public Function  Details(Optional id As Int32 = 0) As ActionResult
            return  IIf(id = 0, nothing, View(_taskModel.Edit(id)))
        End Function

        <Authorize>
        public Function Create() As ActionResult
            return View(_taskModel.Create())
        End Function
        
        <Authorize>
        <HttpPost>
        public function Create( task As TaskViewModels.TaskCreate, submit As string ) As ActionResult

            if submit = "Cancel" then
                return RedirectToAction("Index", new With {.id = cint(TempData("ProjectId"))})
            End If

            Call ValidateddlStatuses()
            Call ValidateddlDurations()
            Call ValidateddlResources()

            task.Status = (Request.Form("ddlStatusTypes"))
            task.TaskDuration = (Request.Form("ddlDurations"))
            task.ResourceId = (Request.Form("ddlResources"))

            if Not ModelState.IsValid Then
                return View( CType(_taskModel.PopulateDropDownLists(task, "Create"), TaskViewModels.TaskCreate))
               
            End If

            _taskModel.Create(task, cint(TempData("ProjectId")))

            return RedirectToAction("Index", new With { .id = CInt(TempData("ProjectId")) })

        End function

        <Authorize>
        public Function  Edit( Optional id As Int32 = 0) As ActionResult
            return  IIf(id = 0, nothing, View(_taskModel.Edit(id)))
        End Function

        <Authorize>
        <HttpPost>
        public Function  Edit(task As TaskViewModels.TaskEdit, submit As string ) As ActionResult

            if submit = "Cancel" then
                return RedirectToAction("Index", new With {.id = cint(TempData("ProjectId"))})
            End If

            if ModelState.IsValid And _modelHelper.IsEndDateLessThanStartDate(task, "Task")
                ModelState.AddModelError(String.Empty, "End Date cannot be less than Start Date.")
            End If

            if Not ModelState.IsValid  Then
                return view(CType(_taskModel.PopulateDropDownLists(task, "Edit"), TaskViewModels.TaskEdit))
            end If

            dim thetask = new TaskViewModels.TaskEdit()
            thetask = task
            thetask.ProjectId = cint(TempData("ProjectId"))

            _taskModel.Edit(thetask)
            return RedirectToAction("Index", new With { .id = CInt(TempData("ProjectId"))})

        End Function

        public Function  Delete(Optional id As Int32 = 0) as ActionResult

            If id > 0 Then
                _taskModel.Delete(id)
            End if
            return RedirectToAction("Index", new With { .id = CInt(TempData("ProjectId"))})

        End Function

        public function Cancel() As ActionResult
            dim id = TempData("ProjectId")
            return RedirectToAction("Index", "Home")
        End function

        public function UploadFile(id As int32) As ActionResult
            return RedirectToAction("UploadFile", "Upload", new With { .id = id, .type = "TM" })
        End function
        '
        private sub ValidateddlStatuses()
            
            if Request.Form("ddlStatusTypes") = String.Empty Then
                exit sub
            End If

            for each  key1 in ModelState.Keys.ToList().Where(Function(key) ModelState.ContainsKey(key))

                if key1 <> "Status" Then
                    continue for
                End If

                ModelState(key1).Errors.Clear()
            next
        End sub

        private sub ValidateddlDurations()
            
            if Request.Form("ddlDurations") = String.Empty Then
                exit sub
            End If

            for each  key1 in ModelState.Keys.ToList().Where(Function(key) ModelState.ContainsKey(key))

                if key1 <> "TaskDuration" Then
                    continue for
                End If

                ModelState(key1).Errors.Clear()
            next

        End sub

        private sub ValidateddlResources()
            
            if Request.Form("ddlResources") = String.Empty Then
                exit sub
            End If

            for each  key1 in ModelState.Keys.ToList().Where(Function(key) ModelState.ContainsKey(key))

                if key1 <> "ResourceId" Then
                    continue for
                End If

                ModelState(key1).Errors.Clear()
            next

        End sub

    End Class
End Namespace