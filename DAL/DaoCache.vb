
Imports Entities

Public Class DaoCache
    implements IDaoCache

    Private ReadOnly context As ProjectManagementEntities

    public sub New (dbcontext As ProjectManagementEntities)
        context = dbcontext
    End sub
    
    public Function GetCache() As DtoCache Implements IDaoCache.GetCache
        
        Dim dtocache = New DtoCache()

        dim projectypes = (from a in context.ProjectTypes select a).ToList()
        CreateProjectTypes(dtocache, projectypes)

        dim statuses = (from a in context.Statuses select a).ToList()
        CreateStatuses(dtocache, statuses)

        dim resources = (from a in context.Resources select a).ToList()
        CreateResources(dtocache, resources)

        dim durations = (from a in context.Durations select a).ToList()
        CreateDurations(dtocache, durations)


        Return dtocache

    End Function

    Private Shared Sub CreateProjectTypes(byval dtocache As DtoCache, byval projectypes As List(Of ProjectType))

        For Each pt As ProjectType In projectypes

            Dim dto = new DtoProjectType() With{.ProjectTypeId = pt.ProjectTypeId,
                                                .Text = pt.Text, 
                                                .Value = pt.Value}

            dtocache.ProjectTypes.Add(dto)
            
        Next

    End Sub

    Private Shared Sub CreateStatuses(byval dtocache As DtoCache, byval statuses As List(Of Status))

        For Each st As Status In statuses
           
            Dim dto = new DtoStatus() With{.StatusId = st.StatusId,
                    .Text = st.Text, 
                    .Value = st.Value}

            dtocache.Statuses.Add(dto)
            
        Next

     End Sub

    Private Shared Sub CreateResources(byval dtocache As DtoCache, byval resources As List(Of Resource))

        For Each rs As Resource In resources
           
            Dim dto = new DtoResource() With{.ResourceId = rs.ResourceId,
                    .Text = rs.Text, 
                    .Value = rs.Value}

            dtocache.Resources.Add(dto)
            
        Next

    End Sub
   
    Private Shared Sub CreateDurations(byval dtocache As DtoCache, byval durations As List(Of Duration))

        For Each du As Duration In durations
           
            Dim dto = new DtoDuration() With{.DurationId = du.DurationId,
                    .Text = du.Text, 
                    .Value = du.Value}

            dtocache.Durations.Add(dto)
            
        Next

    End Sub

End Class
