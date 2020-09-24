Imports System.Net
Imports System.Net.Http
Imports System.Web.Http.Filters
Imports log4net

Public Class CustomExceptionFilter
    Inherits ExceptionFilterAttribute

    private ReadOnly _logger As ILog

    public sub New()
        _logger = LogManager.GetLogger(GetType(CustomExceptionFilter))
    End sub

    Public Overrides Sub OnException(actionExecutedContext As HttpActionExecutedContext)
        MyBase.OnException(actionExecutedContext)

        Dim exceptionMessage as String = String.Empty

        If IsNothing(actionExecutedContext.Exception.InnerException ) Then
            exceptionMessage = actionExecutedContext.Exception.Message _
                               & " " & actionExecutedContext.Exception.StackTrace
        Else 
            exceptionMessage =  actionExecutedContext.Exception.Message _
                                & " " & actionExecutedContext.Exception.InnerException.Message _
                                & " " & actionExecutedContext.Exception.StackTrace
        End If

        _logger.Error(exceptionMessage)

        dim response =  New HttpResponseMessage(HttpStatusCode.InternalServerError)With {.Content = New StringContent(“An unhandled exception was thrown by service.”),
                .ReasonPhrase = "Internal Server Error.Please Contact your Administrator."}

        actionExecutedContext.Response = response

    End Sub
End Class
