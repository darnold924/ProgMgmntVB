Imports System.Data.Entity
Imports Entities

Public Class DaoTask
    Implements IDaoTask

    Private ReadOnly context As ProjectManagementEntities

    public sub New (dbcontext As ProjectManagementEntities)
        context = dbcontext
    End sub

    public Function GetTaskById(ByVal id As int32) As DtoTask Implements IDaoTask.GetTaskById

        Dim dto = new DtoTask()
       
        Dim task = (context.Tasks.Where(Function(a) a.TaskId = id)).SingleOrDefault()

        If IsNothing(task) Then
            Return dto
        End If

        dto.TaskId = task.TaskId
        dto.TaskName = task.TaskName
        dto.Note = task.Note
        dto.StartDate = task.StartDate
        dto.EndDate = task.EndDate
        dto.ResourceId = task.ResourceId
        dto.ProjectId = task.ProjectId
        dto.TaskDuration = task.TaskDuration
        dto.TaskSpent = task.TaskSpent
        dto.Status = task.Status
    
       
        Return dto

    End Function

    public Function  GetTasksByProjectId(byval id as int32) As List(Of DtoTask) Implements IDaoTask.GetTasksByProjectId

        Dim dtos = new List(Of DtoTask)

        dim tasks = (from a in context.Tasks.Where(Function(a) a.ProjectId = id) select a).ToList()

        for each task As Task In tasks

            Dim dto = New DtoTask() With{.TaskId = task.TaskId,
                                            .TaskName = task.TaskName,
                                            .Note = task.Note,
                                            .StartDate = task.StartDate,
                                            .EndDate = task.EndDate,
                                            .ResourceId = task.ResourceId,
                                            .TaskDuration = task.TaskDuration,
                                            .ProjectId = task.ProjectId,                                        
                                            .TaskSpent = task.TaskSpent,
                                            .Status = task.Status}

            dtos.Add(dto)

        Next

        Return dtos

    End Function

    public sub  CreateTask(ByVal dto As DtoTask) Implements IDaoTask.CreateTask

        Dim task as New Task() With {.TaskId = dto.TaskId,
                                        .TaskName = dto.TaskName,
                                        .Note = dto.Note,
                                        .StartDate = dto.StartDate,
                                        .EndDate = dto.EndDate,
                                        .ResourceId = dto.ResourceId,
                                        .ProjectId = dto.ProjectId,
                                        .TaskDuration = dto.TaskDuration,
                                        .TaskSpent = dto.TaskSpent,
                                        .Status = dto.Status}
        context.Tasks.Add(task)
        context.SaveChanges()
       
    End sub
    
    public sub UpdateTask(byval dto As DtoTask) Implements IDaoTask.UpdateTask

        Dim task = new Task()
        
        task = (context.Tasks.Where(Function(a) a.TaskId = dto.TaskId)).SingleOrDefault()

        If Not IsNothing(task) Then
            task.TaskId = dto.TaskId
            task.TaskName = dto.TaskName
            task.Note = dto.Note
            task.StartDate = dto.StartDate
            task.EndDate = dto.EndDate
            task.ResourceId = dto.ResourceId
            task.ProjectId = dto.ProjectId
            task.TaskDuration = dto.TaskDuration
            task.TaskSpent = dto.TaskSpent
            task.Status = dto.Status
        End If
     
        If IsNothing(task) Then
            Exit Sub
        End If

        context.Entry(task).State = EntityState.Modified
        context.SaveChanges()
        
    End sub
    
    public sub DeleteTask(ByVal id As Int32) Implements IDaoTask.DeleteTask

        Dim task As Task 

        task = (context.Tasks.Where(Function(a)a.TaskId = id)).SingleOrDefault()

        context.Entry(task).State = EntityState.Deleted
        context.SaveChanges()
       
    End Sub
   
End Class
