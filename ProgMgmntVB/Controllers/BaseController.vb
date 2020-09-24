Imports System.Web.Mvc
Imports log4net

Namespace Controllers
    Public MustInherit Class BaseController
        Inherits Controller

        private ReadOnly _logger As ILog

        public sub New()
            _logger = LogManager.GetLogger(GetType(BaseController))
        End sub

        Protected Overrides Sub OnException(filterContext As ExceptionContext)
            MyBase.OnException(filterContext)

            dim appexception as AppException = New AppException(CStr(filterContext.Exception.ToString()), _logger) 

            Server.ClearError()

            RedirectToControllers("Home", "TheError")

        End Sub

        private sub RedirectToControllers(control As string, action As string)

            dim routeData = new RouteData()

            routeData.Values("controller") = control
            routeData.Values("action") = action

            Dim controller As IController = new HomeController(nothing) 
            controller.Execute(New RequestContext(new HttpContextWrapper(system.Web.HttpContext.Current), routeData))

        End sub
        
    End Class
End Namespace