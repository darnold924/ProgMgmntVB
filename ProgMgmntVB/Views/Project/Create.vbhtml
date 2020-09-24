@ModelType Models.ProjectViewModels.Project

<!DOCTYPE html>

<html>
<head>
    <title>Create</title>
</head>
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

<body>
    <h1>Project</h1>

    @using (Html.BeginForm())

        @Html.ValidationSummary(false, "", new With { .class = "text-danger" })

        @<fieldset>

        <legend>Create</legend>

        <div class="editor-field">
            @Html.Label("Project Name:")
            @Html.TextBoxFor(Function(m) m.ProjectName, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.ProjectName)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("Client Name:")
            @Html.TextBoxFor(function(m) m.ClientName, new With { .Cssclass = "txtbox" })
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
            @Html.ValidationMessageFor(Function(m) m.Cost)
        </div>
        <br />

        <div class="editor-field">
            @Html.Label("Project Type:")
            @Html.DropDownList("ddlProjectTypes", Model.ProjectTypes, "Select....")
         </div>
         <br />

        <p>
            <input type = "submit" name="submit" value="Save" />
            <input type = "submit" name="submit" value="Cancel" />
        </p>

    </fieldset>
end using 

</body>
</html>


