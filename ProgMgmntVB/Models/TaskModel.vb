Imports Entities
Imports ProgMgmntVB.WebApi

Namespace Models
    Public Class TaskModel
        Implements ITaskModel

        Private ReadOnly _webapi As IWebApi

        public sub New (webapi As IWebApi)
            _webapi = webapi
        End sub

        public Function GetTasksByProjectId(id As int32) As TaskViewModels Implements ITaskModel.GetTasksByProjectId

            dim vm = new TaskViewModels  With{.Tasks = new List(of TaskViewModels.TaskEdit)}

            dim dtos = _webApi.GetTasksByProjIdApi(id).ToList()

            vm.Tasks.AddRange(dtos.Select(function(dto) New TaskViewModels.TaskEdit With {.TaskId = dto.TaskId,
                                                                                          .TaskName = dto.TaskName,
                                                                                          .Note = dto.Note,
                                                                                          .StartDate = dto.StartDate,
                                                                                          .EndDate = dto.EndDate,
                                                                                          .ResourceId = dto.ResourceId,
                                                                                          .ProjectId = dto.ProjectId,
                                                                                          .TaskDuration = dto.TaskDuration,
                                                                                          .Status = dto.Status}).ToList())

            return vm
        End Function
        
        public Function Create() As TaskViewModels.TaskCreate Implements ITaskModel.Create

            dim task = new TaskViewModels.TaskCreate()
            return  CType(PopulateDropDownLists(task, "Create"), TaskViewModels.TaskCreate )

        End Function

        public sub Create(task As TaskViewModels.TaskCreate, id As int32) Implements ITaskModel.Create
            Dim  dto = New DtoTask With {.TaskId = task.TaskId,
                                         .TaskName = task.TaskName,
                                         .Note = task.Note,
                                         .StartDate = task.StartDate,
                                         .ResourceId = task.ResourceId,
                                         .ProjectId = id,
                                         .TaskDuration = task.TaskDuration,
                                         .TaskSpent = "",
                                         .Status = task.Status}
            _webApi.CreateTaskApi(dto)
        End sub
        
        public Function  Edit(id As Int32) As TaskViewModels.TaskEdit Implements  ITaskModel.Edit

            dim dto = _webApi.GetTaskByIdApi(id)
            dim task = New TaskViewModels.TaskEdit With {.TaskId = dto.TaskId,
                                                         .TaskName = dto.TaskName,
                                                         .Note = dto.Note,
                                                         .StartDate = dto.StartDate,
                                                         .EndDate = dto.EndDate,
                                                         .ResourceId = dto.ResourceId,
                                                         .ProjectId = dto.ProjectId,
                                                         .TaskDuration = dto.TaskDuration,
                                                         .TaskSpent = dto.TaskSpent,
                                                         .Status = dto.Status} 

            Return CType(PopulateDropDownLists(task, "Edit"), TaskViewModels.TaskEdit) 
        End Function
        
        public sub Edit(task As TaskViewModels.TaskEdit) Implements ITaskModel.Edit

            if Not IsNothing(task.StartDate)
                dim dto = New DtoTask With {.TaskId = task.TaskId,
                                            .TaskName = task.TaskName,
                                            .Note = task.Note,
                                            .StartDate = task.StartDate,
                                            .EndDate = task.EndDate,
                                            .ResourceId = task.ResourceId,
                                            .ProjectId = task.ProjectId,
                                            .TaskDuration = task.TaskDuration,
                                            .TaskSpent = task.TaskSpent,
                                            .Status = task.Status}
                _webApi.UpdateTaskApi(dto)
            End If
        End sub

        public sub Delete(id As Int32) Implements ITaskModel.Delete
            _webApi.DeleteTaskApi(new DtoId With {.Id = id})
        End sub
        
        public Function PopulateDropDownLists(task as object,  type As string) As Object Implements ITaskModel.PopulateDropDownLists

            dim taskedit as TaskViewModels.TaskEdit
            dim taskcreate as TaskViewModels.TaskCreate
            dim obj as Object

            dim dtocache as DtoCache = HttpContext.Current.Cache.Get("DtoCache") 

            if IsNothing(dtocache) Then
                dtocache = _webapi.GetCacheApi()
                HttpContext.Current.Cache.Insert("DtoCache", dtocache, nothing, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration)
            End If

            if type = "Create" Then

                taskcreate =  CType(task, TaskViewModels.TaskCreate)

                taskcreate.Statuses = new List(Of SelectListItem)()

                for each st As DtoStatus In dtocache.Statuses
                    dim sli = new SelectListItem With {.Value = st.Value, .Text = st.Text }
                    taskcreate.Statuses.Add(sli)
                Next

                dim selectedtask = (from a in taskcreate.Statuses.Where(Function(a) a.Value = _ 
                                             taskcreate.Status) select a).SingleOrDefault()

                if Not IsNothing(selectedtask) Then
                    selectedtask.Selected = true
                End If

                taskcreate.Durations = new List(of SelectListItem)()

                for each du As DtoDuration In dtocache.Durations
                    dim sli = new SelectListItem With {.Value = du.Value, .Text = du.Text }
                    taskcreate.Durations.Add(sli)
                Next

                if Not IsNothing (taskcreate.TaskDuration) Then

                    dim selectedduration = (from a in taskcreate.Durations.Where(Function(a) a.Value = _ 
                                                taskcreate.TaskDuration) select a).SingleOrDefault()

                    if Not IsNothing(selectedduration) Then
                        selectedduration.Selected = true
                    End If
                End If

                taskcreate.Resources = new List(of SelectListItem)()

                for each rs As DtoResource In dtocache.Resources
                    dim sli = new SelectListItem With {.Value = rs.Value, .Text = rs.Text }
                    taskcreate.Resources.Add(sli)
                Next

                if Not IsNothing (taskcreate.ResourceId) Then

                    dim selectedresource = (from a in taskcreate.Resources.Where(Function(a) a.Value = _
                                                    taskcreate.ResourceId) select a).SingleOrDefault()

                    if Not IsNothing(selectedresource) Then
                        selectedresource.Selected = true
                    End If
                End If

                obj = taskcreate
            Else 
                taskedit =  CType(task, TaskViewModels.TaskEdit)

                taskedit.Statuses = new List(of SelectListItem)()

                for each st As DtoStatus In dtocache.Statuses
                    dim sli = new SelectListItem With {.Value = st.Value, .Text = st.Text }
                    taskedit.Statuses.Add(sli)
                Next

                dim selectedtask = (from a in taskedit.Statuses.Where(Function(a) a.Value = _ 
                                                    taskedit.Status) select a).SingleOrDefault()

                if Not IsNothing(selectedtask) Then
                    selectedtask.Selected = true
                End If

                taskedit.Durations = new List(of SelectListItem)()

                for each du As DtoDuration In dtocache.Durations
                    dim sli = new SelectListItem With {.Value = du.Value, .Text = du.Text }
                    taskedit.Durations.Add(sli)
                Next

                if Not IsNothing (taskedit.TaskDuration) Then

                    dim selectedduration = (from a in taskedit.Durations.Where(Function(a) a.Value = _
                                                     taskedit.TaskDuration) select a).SingleOrDefault()

                    if Not IsNothing(selectedduration) Then
                        selectedduration.Selected = true
                    End If
                End If

                taskedit.Spents = new List(of SelectListItem)()

                for each sp As DtoDuration In dtocache.Durations
                    dim sli = new SelectListItem With {.Value = sp.Value, .Text = sp.Text }
                    taskedit.Spents.Add(sli)
                Next

                if Not IsNothing (taskedit.Spents) Then

                    dim selectedspent = (from a in taskedit.Spents.Where(Function(a) a.Value = taskedit.TaskSpent) select a) _
                            .SingleOrDefault()

                    if Not IsNothing(selectedspent) Then
                        selectedspent.Selected = true
                    End If
                End If

                taskedit.Resources = new List(of SelectListItem)()

                for each rs As DtoResource In dtocache.Resources
                    dim sli = new SelectListItem With {.Value = rs.Value, .Text = rs.Text }
                    taskedit.Resources.Add(sli)
                Next

                if Not IsNothing (taskedit.ResourceId) Then

                    dim selectedresource = (from a in taskedit.Resources.Where(Function(a) a.Value = taskedit.ResourceId) select a) _
                            .SingleOrDefault()

                    if Not IsNothing(selectedresource) Then
                        selectedresource.Selected = true
                    End If
                End If

                obj = taskedit
                
            End If

            Return obj

        End Function
    
    End Class
End NameSpace