Namespace Controllers
    Public Class HomeController
        Inherits BaseController
      
        private readonly _projectModel As IProjectModel 
       
        public sub New (projectModel As IProjectModel)
            _projectModel = projectModel
        End sub

        <Authorize>
        public Function  Index() As ActionResult
            return View(_projectModel.GetProjectsByUserId(User.Identity.Name))
        End Function

        Function About() As ActionResult
            ViewData("Message") = "Your application description page."

            Return View()
        End Function

        Function Contact() As ActionResult
            ViewData("Message") = "Your contact page."

            Return View()
        End Function

        public Function  Cancel() As ActionResult
            return RedirectToAction("Index", "Home")
        End Function
      
        public Function Task(id As Int32) As ActionResult
            return RedirectToAction("Index", "Task", new With { .id = id })
        End Function
      
        Function TheError() As ActionResult
            return View("~/Views/Shared/Error.vbhtml", nothing)
        end Function

    
    End Class
End NameSpace