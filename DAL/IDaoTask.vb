
Imports Entities

Public Interface IDaoTask

    Function GetTaskById(ByVal id As int32) As DtoTask
    Function GetTasksByProjectId(byval id as int32) As List(Of DtoTask)
    sub  CreateTask(ByVal dto As DtoTask)
    sub UpdateTask(byval dto As DtoTask)
    sub DeleteTask(ByVal id As Int32)

End Interface
