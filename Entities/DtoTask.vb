
Public Class DtoTask

    Public Property TaskId As Int32
    Public Property TaskName As String
    Public Property Note As String
    Public Property StartDate  As DateTime
    Public Property EndDate As Nullable(of DateTime) 
    Public Property ResourceId As String
    Public Property ProjectId As Int32
    Public Property TaskDuration As String
    Public Property TaskSpent As String
    Public Property Status As String

End Class