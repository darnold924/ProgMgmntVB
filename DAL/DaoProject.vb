
Imports System.Data.Entity
Imports Entities

Public Class DaoProject
    Implements IDaoProject

    Private ReadOnly context As ProjectManagementEntities

    public sub New (dbcontext As ProjectManagementEntities)
        context = dbcontext
    End sub

    Public Function GetProjectById(ByVal id As Int32) As DtoProject Implements IDaoProject.GetProjectById

        Dim dto = New DtoProject()
   
        Dim project = (context.Projects.Where(Function(a) a.ProjectId = id)).SingleOrDefault()

        If IsNothing(project) Then
            Return dto
        End If

        dto.ProjectId = project.ProjectId
        dto.ClientName = project.ClientName
        dto.ProjectName = project.ProjectName
        dto.Technology = project.Technology
        dto.ProjectType = project.ProjectType
        dto.UserId = project.UserId
        dto.StartDate = project.StartDate
        dto.EndDate = project.EndDate
        dto.Cost = project.Cost

        Return dto

    End Function

    Public Function GetProjectsByUserId(ByVal userid As String) As List(Of DtoProject) Implements IDaoProject.GetProjectsByUserId

        Dim dtos = New List(Of DtoProject)

        dtos = (From a In context.Projects.Where(Function(a) a.UserId.Contains(userid))
                Select New DtoProject With {.ProjectId = a.ProjectId,
                                            .ClientName = a.ClientName,
                                            .ProjectName = a.ProjectName,
                                            .Technology = a.Technology,
                                            .ProjectType = a.ProjectType,
                                            .UserId = a.UserId,
                                            .StartDate = a.StartDate,
                                            .EndDate = a.EndDate,
                                            .Cost = a.Cost}).ToList()
       

        Return dtos

    End Function

    Public Sub CreateProject(ByVal dto As DtoProject) Implements IDaoProject.CreateProject

        Dim project = New Project() With {.ClientName = dto.ClientName,
                                            .ProjectName = dto.ProjectName,
                                            .Technology = dto.Technology,
                                            .ProjectType = dto.ProjectType,
                                            .UserId = dto.UserId,
                                            .StartDate = dto.StartDate,
                                            .EndDate = dto.EndDate,
                                            .Cost = dto.Cost}
        context.Projects.Add(project)
        context.SaveChanges()

       
    End Sub

    Public Sub UpdateProject(ByVal dto As DtoProject) Implements IDaoProject.UpdateProject

        Dim project = New Project()
       
        project = (context.Projects.Where(Function(a) a.ProjectId = dto.ProjectId)).SingleOrDefault()
       
        If Not IsNothing(project) Then
            project.ClientName = dto.ClientName
            project.ProjectName = dto.ProjectName
            project.Technology = dto.Technology
            project.ProjectType = dto.ProjectType
            project.UserId = dto.UserId
            project.StartDate = dto.StartDate
            project.EndDate = dto.EndDate
            project.Cost = dto.Cost
        End If

      
        If IsNothing(project) Then
            Exit Sub
        End If

        context.Entry(project).State = EntityState.Modified
        context.SaveChanges()
       
    End Sub

    Public Sub DeleteProject(ByVal id As Int32) Implements IDaoProject.DeleteProject

        Dim project As Project
        
        project = (context.Projects.Where(Function(a) a.ProjectId = id)).Include("Tasks").SingleOrDefault()
       
        If IsNothing(project) Then
            Exit Sub
        End If

        For i As Integer = 0 To  project.Tasks.Count - 1
            Dim task = project.Tasks(i)
            context.Entry(task).State = EntityState.Deleted
        Next
        
        context.Entry(project).State = EntityState.Deleted
        context.SaveChanges()
       
    End Sub

    End Class
