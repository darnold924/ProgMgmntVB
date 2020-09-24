
Imports Entities

Public Interface IDaoProject
    Function GetProjectById(ByVal id As Int32) As DtoProject
    Function GetProjectsByUserId(ByVal userid As String) As List(Of DtoProject)
    Sub CreateProject(ByVal dto As DtoProject)
    Sub UpdateProject(ByVal dto As DtoProject)
    Sub DeleteProject(ByVal id As Int32)
End Interface
