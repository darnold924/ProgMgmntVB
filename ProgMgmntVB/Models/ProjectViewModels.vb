Imports System.ComponentModel.DataAnnotations

Namespace Models

    Public Class ProjectViewModels

        public Class Project

            public Property  ProjectId As int32

            <Required(ErrorMessage: = "Client Name is required")>
            <StringLength(50)>
            public property ClientName As String 

            <Required(ErrorMessage: = "Project Name is required")>
            <StringLength(50)>
            public property ProjectName  as String

            <Required(ErrorMessage: = "Technology is required")>
            <StringLength(50)>
            public property Technology As String

            <Required(ErrorMessage: = "Project Type is required")>
            public property ProjectType As String

            <Required(ErrorMessage: = "Start Date is required")>
            <DisplayFormat(ApplyFormatInEditMode: = true, DataFormatString: = "{0:MM-dd-yyyy}")>
            public  Property  StartDate As DateTime? 

            <Required(ErrorMessage: = "End Date is required")>
            <DisplayFormat(ApplyFormatInEditMode: = true, DataFormatString: = "{0:MM-dd-yyyy}")>
            public  Property  EndDate As DateTime?

            <Required(ErrorMessage: = "Cost is required")>
            public Property  Cost As decimal?

            public Property ProjectTypes As List(of SelectListItem)
        end Class 
    
        public Property Projects As List(of Project)

    End Class
End NameSpace