@ModelType Models.ProjectViewModels.Project

<!DOCTYPE html>

<style type="text/css">
    .editor-field > label {
        float: left;
        width: 150px;
    }

    .txtbox {
        font-family: Arial, Helvetica, sans-serif;
        font-size: 12px;
        background: white;
        color: black;
        cursor: text;
        border-bottom: 1px solid #104A7B;
        border-right: 1px solid #104A7B;
        border-left: 1px solid #104A7B;
        border-top: 1px solid #104A7B;
        padding-top: 10px;
    }
</style>
<html>
<head>
    <title>Edit</title>
</head>

<body>
    <h1>Project</h1>

    @using (Html.BeginForm())

        @Html.ValidationSummary(false, "", new With { .class = "text-danger" })

        @<fieldset>

        <legend>Edit</legend>

        @Html.HiddenFor(Function(m) m.ProjectId)

        <div class="editor-field">
            @Html.Label("Project Name:")
            @Html.TextBoxFor(function(m) m.ProjectName, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(function(m) m.ProjectName)
         </div>
         <br />

        <div class="editor-field">
            @Html.Label("Client Name:")
            @Html.TextBoxFor(Function(m) m.ClientName, new with { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.ClientName)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("Technology:")
            @Html.TextBoxFor(Function(m) m.Technology, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.Technology)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("Start Date:")
            @Html.TextBoxFor(Function(m) m.StartDate, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.StartDate)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("End Date:")
            @Html.TextBoxFor(Function(m) m.EndDate, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.EndDate)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("Cost:")
            @Html.TextBoxFor(Function(m) m.Cost, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m)  m.Cost)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("Project Type:")
            @Html.DropDownListFor(Function(m) m.ProjectType, Model.ProjectTypes)
        </div>
        <br />
        <p>
            <input type = "submit" name="submit" value="Save" />
            <input type = "submit" name="submit" value="Cancel" />
        </p>

    </fieldset>

    End using 

</body>
</html>


