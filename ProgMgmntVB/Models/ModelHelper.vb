Namespace Models
    Public Class ModelHelper
        Implements IModelHelper

        public Function IsEndDateLessThanStartDate(obj As object, type As string) As Boolean Implements  IModelHelper.IsEndDateLessThanStartDate

            dim value = false
            
            if type = "Project" Then
                dim project =  CType (obj, ProjectViewModels.Project)
                if project.EndDate < project.StartDate Then
                    value = True
                End If
            Else 
                dim task =  CType (obj, TaskViewModels.TaskEdit)
                if task.EndDate < task.StartDate Then
                    value = True
                End If
            End If

            Return value

        End Function
    End Class
End NameSpace