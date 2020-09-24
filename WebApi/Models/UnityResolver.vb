Imports Unity
imports Unity.Exceptions
Imports System.Web.Http.Dependencies

Public Class UnityResolver
    Implements IDependencyResolver
    
    Private ReadOnly _container As IUnityContainer  

    public sub New( container as IUnityContainer)

        _container = container

    End sub

    Public Function GetService(serviceType As Type) As Object Implements IDependencyScope.GetService

        Try
            return _container.Resolve(serviceType)
        Catch ex As ResolutionFailedException
            Return nothing 
        End Try

        End Function

    Public Function GetServices(serviceType As Type) As IEnumerable(Of Object) Implements IDependencyScope.GetServices

        Try
            return _container.ResolveAll(serviceType)
        Catch ex As ResolutionFailedException
            Return new List(Of object)
        End Try
       
    End Function

    Public Function BeginScope() As IDependencyScope Implements IDependencyResolver.BeginScope
        dim child = _container.CreateChildContainer()
        return new UnityResolver(child)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        _container.Dispose()
    End Sub
End Class
