Namespace Models
    Public Interface ITaskModel

        Function GetTasksByProjectId(id As int32) As TaskViewModels
        Function Create() As TaskViewModels.TaskCreate
        sub Create(task As TaskViewModels.TaskCreate, id As int32)
        Function  Edit(id As Int32) As TaskViewModels.TaskEdit
        sub Edit(task As TaskViewModels.TaskEdit)
        sub Delete(id As Int32)
        Function PopulateDropDownLists(task as object,  type As string) As Object

    End Interface
End NameSpace