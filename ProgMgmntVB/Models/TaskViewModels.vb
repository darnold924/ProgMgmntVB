Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class TaskViewModels

        public class TaskCreate

            public Property TaskId As int32

            <Required(ErrorMessage: = "Task Name is required")>
            <StringLength(50)>
            public property TaskName As String

            <Required(ErrorMessage: = "Note is required")>
            <StringLength(2000)>
            public property Note as String

            <Required(ErrorMessage: = "Start Date is required")>
            <DisplayFormat(ApplyFormatInEditMode: = true, DataFormatString: = "{0:MM-dd-yyyy hh:mm:ss tt}")>
            public property StartDate As DateTime?

            <Required(ErrorMessage: = "Resource is required")>
            public property ResourceId As String

            public property ProjectId As Int32

            <Required(ErrorMessage: = "Duration is required")>
            public property TaskDuration As String

            <Required(ErrorMessage: = "Status is required")>
            public property Status As String

            public property Statuses as List(of SelectListItem)
            public Property Durations as List(of SelectListItem)
            public property Resources as List(of SelectListItem)
        End Class

        public class TaskEdit
        
            public Property  TaskId As int32

            <Required(ErrorMessage:= "Task Name is required")>
            <StringLength(50)>
            public property TaskName As string

            <Required(ErrorMessage: = "Note is required")>
            <StringLength(2000)>
            public Property Note As String

            <Required(ErrorMessage: = "Start Date is required")>
            <DisplayFormat(ApplyFormatInEditMode: = true, DataFormatString: = "{0:MM-dd-yyyy hh:mm:ss tt}")>
            public Property StartDate As DateTime? 
           
            <DisplayFormat(ApplyFormatInEditMode: = true, DataFormatString: = "{0:MM-dd-yyyy hh:mm:ss tt}")>
            public Property  EndDate As DateTime?

            public Property ResourceId As String
            public Property ProjectId As Int32 
            public property TaskDuration As String
            public Property TaskSpent As String
            public Property Status As String

            public Property Statuses As List(of SelectListItem)
            public property Durations As List(of SelectListItem)
            public Property Resources As List(of SelectListItem)
            public Property Spents As List(of SelectListItem)
        End Class

        public Property Tasks As List(of TaskEdit)

    End Class
End NameSpace