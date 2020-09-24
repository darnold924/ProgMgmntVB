@ModelType Models.ProjectViewModels.Project


<style type="text/css">
    .editor-field > label {
        float: left;
        width: 150px;
    }
</style>
<html>
<head>
    <title>Project Detail</title>
</head>

<body>
    <h1>Project</h1>

    @using (Html.BeginForm())

    @<fieldset>

    <legend>Detail</legend>

    @Html.HiddenFor(Function(m) m.ProjectId)

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Client Name:")
        @Html.DisplayTextFor(function(m) m.ClientName)
     </div>
     </div>

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Project Name:")
        @Html.DisplayTextFor(Function(m) m.ProjectName)
    </div>
    </div>

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Technology:")
        @Html.DisplayTextFor(Function(m) m.Technology)
    </div>
    </div>

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Start Date:")
        @Html.DisplayTextFor(Function(m) m.StartDate)
    </div>
    </div>

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("End Date:")
        @Html.DisplayTextFor(Function(m) m.EndDate)
    </div>
    </div>

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Cost:")
        @Html.DisplayTextFor(Function(m) m.Cost)
    </div>
    </div>

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Project Type:")
        @Html.DropDownListFor(Function(m) m.ProjectType, Model.ProjectTypes, new With { .class = "form-control", .readonly = "readonly" })
    </div>
    </div>

    </fieldset>
End Using

</body>
</html>

