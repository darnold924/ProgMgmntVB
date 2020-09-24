Imports System.Web.Mvc
Imports System.IO

Namespace Controllers
    Public Class UploadController
        Inherits BaseController

        ' GET: Upload
        Function Index() As ActionResult
            Return View()
        End Function

        <HttpGet>  
        public Function UploadFile(id As Int32, type As string) As ActionResult

            dim path = Server.MapPath("~/UploadedFiles/" & type & id)

            if Not Directory.Exists(path) Then
                Dim di as DirectoryInfo = Directory.CreateDirectory(path)
            End If

            TempData("Pathdata") = path
            TempData("Type") = type

            Return View()

        End Function
       
        <HttpPost>
        public Function  UploadFile(file As HttpPostedFileBase) as ActionResult

            Try
                if file.ContentLength > 0 Then
                    dim filename = IO.Path.GetFileName(file.FileName)
                    dim path = TempData("Pathdata") & "\\" & filename

                    file.SaveAs(path)
                    TempData("Message") = "File Uploaded Successfully!!"

                     Return IIf(TempData("Type") = "PM", RedirectToAction("Index", "Project"), _
                                RedirectToAction("Index", "Task", new  with { .id = Cint(TempData("ProjectId"))}))
                End If
            Catch 
                ViewBag.Message = "File upload failed!!"
            End Try

            return View()

        End Function
        
    End Class
End Namespace