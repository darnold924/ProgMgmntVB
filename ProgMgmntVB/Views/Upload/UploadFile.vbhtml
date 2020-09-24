
<h2>UploadFile</h2>

@using (Html.BeginForm("UploadFile", "Upload", FormMethod.Post, new With { .enctype="multipart/form-data"}))


    @<div>
    @Html.TextBox("file", "", new With  {  .type= "file"}) <br />

         <input type = "submit" value="Upload" />

    @ViewBag.Message

    </div>

End Using

