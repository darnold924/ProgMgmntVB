Imports System.Net
Imports Entities
Imports Newtonsoft.Json

Namespace WebApi
    Public Class WebApi
        Implements IWebApi

        #Region "Project"
        public Function  GetProjsByUserIdApi(userid As String) as List(of DtoProject) Implements IWebApi.GetProjsByUserIdApi

            dim dtoprojects = new List(Of DtoProject)

            dim url = "http://localhost/WebApiVB/api/project/GetProjectsByUserId?userid=" & userid

            Using webclient As New WebClient
                dim json  = webclient.DownloadString(url)
                Dim projects = JsonConvert.DeserializeObject(of List(Of DtoProject))(json)
                dtoprojects = projects
            End Using

            Return dtoprojects

        End Function
       
        public Function GetProjByIdApi(id As int32) as DtoProject Implements IWebApi.GetProjByIdApi

            dim dto as DtoProject

            dim url = "http://localhost/WebApiVB/api/project/GetProjectById?id=" & id

            Using webclient As New WebClient
                dim json  = webclient.DownloadString(url)
                Dim project = JsonConvert.DeserializeObject(of DtoProject)(json)
                dto = project
            End Using
           
            Return dto

        End Function

        public sub CreateProjectApi(dto As DtoProject) Implements IWebApi.CreateProjectApi

            Dim reqString As byte()

            Using webclient As New WebClient

                dim url as string = "http://localhost/WebApiVB/api/project/CreateProject"
                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dto, Formatting.Indented))
                webClient.UploadData(url, "post", reqString)

            End Using
            
        End sub
        
        public sub UpdateProjectApi(dto As DtoProject) Implements IWebApi.UpdateProjectApi

            Dim reqString As byte()

            Using webclient As New WebClient

                dim url as string = "http://localhost/WebApiVB/api/project/UpdateProject"
                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dto, Formatting.Indented))
                webClient.UploadData(url, "post", reqString)

            End Using

        End sub

        public sub DeleteProjectApi(dto As DtoId) Implements IWebApi.DeleteProjectApi

            Dim reqString As byte()

            Using webclient As New WebClient

                dim url as string = "http://localhost/WebApiVB/api/project/DeleteProject"
                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dto, Formatting.Indented))
                webClient.UploadData(url, "post", reqString)

            End Using

        End sub
        #End Region

        #Region "Task"

        public function GetTasksByProjIdApi(id as int32) as List(Of DtoTask) Implements IWebApi.GetTasksByProjIdApi

            Dim dtotasks = new List(Of DtoTask)

            dim url = "http://localhost/WebApiVB/api/task/GetTasksByProjectId?id=" & id

            Using webclient As New WebClient
                dim json  = webclient.DownloadString(url)
                Dim tasks = JsonConvert.DeserializeObject(of List(Of DtoTask))(json)
                dtotasks = tasks
            End Using

            Return dtotasks

        End function
        
        public Function  GetTaskByIdApi(id As int32) As DtoTask Implements IWebApi.GetTaskByIdApi

            dim dto as DtoTask

            dim url = "http://localhost/WebApiVB/api/task/GetTaskById?id=" & id

            Using webclient As New WebClient
                dim json  = webclient.DownloadString(url)
                Dim task = JsonConvert.DeserializeObject(of DtoTask)(json)
                dto = task
            End Using

            return dto

        End Function

        public sub CreateTaskApi(dto As DtoTask) Implements IWebApi.CreateTaskApi

            Dim reqString As byte()

            Using webclient As New WebClient

                dim url as string = "http://localhost/WebApiVB/api/task/CreateTask"
                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dto, Formatting.Indented))
                webClient.UploadData(url, "post", reqString)

            End Using
          
        End sub
        
        public sub UpdateTaskApi(dto As DtoTask) Implements IWebApi.UpdateTaskApi

            Dim reqString As byte()

            Using webclient As New WebClient

                dim url as string = "http://localhost/WebApiVB/api/task/UpdateTask"
                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dto, Formatting.Indented))
                webClient.UploadData(url, "post", reqString)

            End Using
            
        End sub
        
        public sub DeleteTaskApi(dto As DtoId) Implements IWebApi.DeleteTaskApi

            Dim reqString As byte()

            Using webclient As New WebClient

                dim url as string = "http://localhost/WebApiVB/api/task/DeleteTask"
                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dto, Formatting.Indented))
                webClient.UploadData(url, "post", reqString)

            End Using

        End sub
        #End Region  
        
        #Region "Cache"

        public Function  GetCacheApi() As DtoCache Implements IWebApi.GetCacheApi

            dim dtocache = new DtoCache()

            dim url = "http://localhost/WebApiVB/api/cache/GetCache"

            Using webclient As New WebClient
                dim json  = webclient.DownloadString(url)
                Dim deserialized = JsonConvert.DeserializeObject(of DtoCacheRoot)(json)

                dtocache.ProjectTypes = deserialized.DtoCache.ProjectTypes
                dtocache.Durations = deserialized.DtoCache.Durations
                dtocache.Statuses = deserialized.DtoCache.Statuses
                dtocache.Resources = deserialized.DtoCache.Resources

            End Using

            return dtocache

        End Function
        #End Region

    End Class
End Namespace
