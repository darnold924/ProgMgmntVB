
Imports System.Data.Entity
Imports System.Web.Http
Imports Unity
Imports DAL
Imports Unity.Lifetime


Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        dim container = new UnityContainer()
        container.RegisterType(Of IDaoProject, DaoProject) ()
        container.RegisterType(Of IDaoTask, DaoTask) ()
        container.RegisterType(Of IDaoCache, DaoCache) ()
        container.RegisterType(Of DbContext, ProjectManagementEntities)(new HierarchicalLifetimeManager())
        config.DependencyResolver = new UnityResolver(container)

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )
    End Sub

    
End Module
