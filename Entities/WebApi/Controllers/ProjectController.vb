
Imports System.Web.Http
Imports DAL
Imports Entities

Namespace Controllers

    <CustomExceptionFilter>
    Public Class ProjectController
        Inherits ApiController

        Private ReadOnly _daoproject As IDaoProject

        public sub New (daoproject As IDaoProject)
            _daoproject = daoproject
        End sub

        <HttpGet>
        <ActionName("GetProjectById")>
        public Function GetProjectById(ByVal id As Int32) As DtoProject
            return _daoproject.GetProjectById(id)
        End Function


        <HttpGet>
        <ActionName("GetProjectsByUserId")>
        public Function GetProjectsByUserId(ByVal userid As String) As List(Of DtoProject)
            return _daoproject.GetProjectsByUserId(userid)
        End Function

        <HttpPost>
        <ActionName("CreateProject")>
        public sub CreateProject(ByVal dto As DtoProject)
            Call _daoproject.CreateProject(dto)
        End sub
        
        <HttpPost>
        <ActionName("UpdateProject")>
        public sub UpdateProject(ByVal dto As DtoProject)
            Call _daoproject.UpdateProject(dto)
        End sub

        <HttpPost>
        <ActionName("DeleteProject")>
        public sub  DeleteProject(ByVal dto As DtoId)
            Call _daoproject.DeleteProject(dto.Id)
        End sub
        
    End Class
End Namespace