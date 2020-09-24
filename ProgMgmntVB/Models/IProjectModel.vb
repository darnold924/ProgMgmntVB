Imports ProgMgmntVB.Models

Public Interface IProjectModel
    Function  GetProjectsByUserId(userid As String) As ProjectViewModels
    Function GetProjectById(id As Int32) As ProjectViewModels.Project
    function Create() As ProjectViewModels.Project
    sub Create(project As ProjectViewModels.Project, userid As string)
    Function  Edit(id As int32)As ProjectViewModels.Project
    Sub Edit(project As ProjectViewModels.Project, userid as string)
    sub Delete(id As int32)
    Function  PopulateSelectedList(project As ProjectViewModels.Project ) As ProjectViewModels.Project

End Interface
