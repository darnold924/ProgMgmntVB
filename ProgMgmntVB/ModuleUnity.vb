Imports System.Data.Entity
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports ProgMgmntVB.Controllers
Imports ProgMgmntVB.Models
Imports ProgMgmntVB.WebApi
Imports Unity
Imports Unity.Injection
Imports Unity.Lifetime
Imports Unity.Mvc5

Module ModuleUnity

    public class UnityConfig

        public shared sub RegisterComponents()

            dim container = new UnityContainer()

            container.RegisterType(Of IProjectModel, ProjectModel)() 
            container.RegisterType(Of ITaskModel, TaskModel)()
            container.RegisterType(Of IWebApi, WebApi.WebApi)()
            container.RegisterType(Of IModelHelper, ModelHelper)()

            'Idenity 

            container.RegisterType(Of DbContext, ApplicationDbContext)(new HierarchicalLifetimeManager())
            container.RegisterType(of UserManager(of ApplicationUser))(new HierarchicalLifetimeManager())
            container.RegisterType(of IUserStore(of ApplicationUser), UserStore(of ApplicationUser))(New HierarchicalLifetimeManager())
            container.RegisterType(of AccountController)(new InjectionConstructor())

            DependencyResolver.SetResolver(new UnityDependencyResolver(container))

        End sub
    
    End Class
End Module
