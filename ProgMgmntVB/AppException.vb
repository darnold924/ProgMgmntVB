Imports log4net

Public Class AppException
    Inherits Exception

    private ReadOnly _logger As ILog

    Public Sub New(ByVal logger As ILog)

        _logger = logger
        LogError("An unexpected error occurred.", _logger)

    End Sub

    public sub New (byval message as String, logger As ILog) 

        _logger = logger

        LogError(message, _logger)

    End sub

    Public Sub New( ByVal message As String, ByVal innerException As Exception, ByVal logger As ILog)

        _logger = logger
        LogError(message, _logger)

        If Not (innerException Is Nothing) Then
            LogError(innerException.Message.ToString, _logger)
        End If

    End Sub
      
    Public Shared Sub LogError(ByVal message As String, ByVal logger As ILog)
        logger.Error(message)
    End Sub

  End Class
