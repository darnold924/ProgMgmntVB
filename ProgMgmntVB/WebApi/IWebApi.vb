
Imports Entities

Namespace WebApi
    Public Interface IWebApi

        Function GetProjsByUserIdApi(userid As String) as List(of DtoProject)
        Function GetProjByIdApi(id As int32) as DtoProject
        sub CreateProjectApi(dto As DtoProject)
        sub  UpdateProjectApi(dto As DtoProject)
        sub DeleteProjectApi(dto As DtoId)
        function GetTasksByProjIdApi(id as int32) as List(Of DtoTask)
        Function GetTaskByIdApi(id As int32) As DtoTask
        sub CreateTaskApi(dto As DtoTask)
        sub UpdateTaskApi(dto As DtoTask)
        sub DeleteTaskApi(dto As DtoId)
        Function GetCacheApi() As DtoCache

    End Interface
End Namespace
