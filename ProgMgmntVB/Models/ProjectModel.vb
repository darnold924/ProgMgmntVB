
Imports ProgMgmntVB.WebApi
Imports Entities
Namespace Models
    Public Class ProjectModel
        Implements IProjectModel

        Private ReadOnly _webapi As IWebApi

        public sub New (webapi As IWebApi)
            _webapi = webapi
        End sub

        public Function  GetProjectsByUserId(userid As String) As ProjectViewModels Implements  IProjectModel.GetProjectsByUserId

            dim vm = new ProjectViewModels With {.Projects = new List(of ProjectViewModels.Project)}

            dim dtos = _webApi.GetProjsByUserIdApi(userid).ToList()

            vm.Projects.AddRange(dtos.Select(Function(dto) New ProjectViewModels.Project() With{.ProjectId = dto.ProjectId,
                                                                                                .ClientName = dto.ClientName,
                                                                                                .ProjectName = dto.ProjectName,
                                                                                                .Technology = dto.Technology,
                                                                                                .ProjectType = dto.ProjectType,
                                                                                                .StartDate = dto.StartDate,
                                                                                                .EndDate = dto.EndDate,
                                                                                                .Cost = dto.Cost}).ToList())
            Return vm

        End Function

        public Function GetProjectById(id As Int32) As ProjectViewModels.Project Implements IProjectModel.GetProjectById

        dim responseDto = _webApi.GetProjByIdApi(id)
        dim project = New ProjectViewModels.Project With {.ProjectId = responseDto.ProjectId,
                                                            .ClientName = responseDto.ClientName,
                                                            .ProjectName = responseDto.ProjectName,
                                                            .Technology = responseDto.Technology,
                                                            .ProjectType = responseDto.ProjectType,
                                                            .StartDate = responseDto.StartDate,
                                                            .EndDate = responseDto.EndDate,
                                                            .Cost = responseDto.Cost}
        Return project
        End Function

        public function Create() As ProjectViewModels.Project Implements IProjectModel.Create

            Dim project = new ProjectViewModels.Project 
            return PopulateSelectedList(project)

        End function
       
        public sub Create(project As ProjectViewModels.Project, userid As string) Implements IProjectModel.Create

            dim dto = New DtoProject With{.ProjectId = project.ProjectId,
                                        .ClientName = project.ClientName,
                                        .ProjectName = project.ProjectName,
                                        .ProjectType = project.ProjectType,  
                                        .Technology = project.Technology,
                                        .UserId = userid,
                                        .StartDate = project.StartDate,
                                        .EndDate = project.EndDate,
                                        .Cost = project.Cost}

            _webApi.CreateProjectApi(dto)
        End sub

        public Function  Edit(id As int32)As ProjectViewModels.Project Implements IProjectModel.Edit

            dim responseDto = _webApi.GetProjByIdApi(id)

            dim project = New ProjectViewModels.Project with {.ProjectId = responseDto.ProjectId,
                                                              .ClientName = responseDto.ClientName,
                                                              .ProjectName = responseDto.ProjectName,
                                                              .Technology = responseDto.Technology,
                                                              .ProjectType = responseDto.ProjectType,
                                                              .StartDate = responseDto.StartDate,
                                                              .EndDate = responseDto.EndDate,
                                                              .Cost = responseDto.Cost}
            project = PopulateSelectedList(project)

            Return project
        End Function

        public Sub Edit(project As ProjectViewModels.Project, userid as string) Implements IProjectModel.Edit

            dim dto = New DtoProject With {.ProjectId = project.ProjectId,
                                           .ClientName = project.ClientName,
                                           .ProjectName = project.ProjectName,
                                           .ProjectType = project.ProjectType,
                                           .Technology = project.Technology,
                                           .UserId = userid,
                                           .StartDate = project.StartDate,
                                           .EndDate = project.EndDate,
                                           .Cost = project.Cost}
            _webApi.UpdateProjectApi(dto)
        end Sub
        
        public sub Delete(id As int32) Implements IProjectModel.Delete

            _webApi.DeleteProjectApi(new DtoId With {.Id = id})

        End sub
        
        public Function  PopulateSelectedList(project As ProjectViewModels.Project ) As ProjectViewModels.Project Implements IProjectModel.PopulateSelectedList

              dim dtocache as DtoCache = HttpContext.Current.Cache.Get("DtoCache") 

              if IsNothing(dtocache) Then
                  dtocache = _webapi.GetCacheApi()
                  HttpContext.Current.Cache.Insert("DtoCache", dtocache, nothing,  _ 
                                                   DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration)
              End If

              project.ProjectTypes = new List(Of SelectListItem)

              for each pt as DtoProjectType in dtocache.ProjectTypes
                  Dim sli = new SelectListItem With {.Value = pt.Value, .Text = pt.Text}
                  project.ProjectTypes.Add(sli)
              Next

              dim selected = (from a in project.ProjectTypes.Where(Function (a) a.Value = _ 
                                                   project.ProjectType) select a).SingleOrDefault()

              if Not IsNothing(selected) then
                  selected.Selected = true
              End If

              return project

          End Function

    End Class
End NameSpace