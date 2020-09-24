Imports System.IO
Imports System.Web.Optimization

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        ModuleUnity.UnityConfig.RegisterComponents()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")))
    End Sub
End Class
