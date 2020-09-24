
Imports System.Web.Http
Imports DAL
Imports Entities

Namespace Controllers

    <CustomExceptionFilter>
    Public Class TaskController
        Inherits ApiController

        Private ReadOnly _daotask As IDaoTask

        public sub New (daotask As IDaoTask)
            _daotask = daotask
        End sub

        <HttpGet>
        <ActionName("GetTaskById")>
        public Function  GetTaskById(ByVal id As int32) as DtoTask
            return _daotask.GetTaskById(id)
        End Function
        
        <HttpGet>
        <ActionName("GetTasksByProjectId")>
        public  Function GetTasksByProjectId(byval id as int32) as List(Of DtoTask)
            return _daotask.GetTasksByProjectId(id)
        End Function

        <HttpPost>
        <ActionName("CreateTask")>
        public sub  CreateTask(ByVal dto As DtoTask)
            Call _daotask.CreateTask(dto)
        End sub
       
        <HttpPost>
        <ActionName("UpdateTask")>
        public sub  UpdateTask(ByVal dto As DtoTask)
            Call _daotask.UpdateTask(dto)
        End sub
        
        <HttpPost>
        <ActionName("DeleteTask")>
        public sub  DeleteTask(byval dto As DtoId)
            Call _daotask.DeleteTask(dto.Id)
        End sub
        
    End Class
End Namespace