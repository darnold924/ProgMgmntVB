@ModelType Models.TaskViewModels.TaskCreate
<!DOCTYPE html>

<style type="text/css">
    .editor-field > label {
        float: left;
        width: 150px;
    }

    txtbox {
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
    <title>Create</title>
</head>

<body>
    <h1>Task</h1>

    @using (Html.BeginForm())

        @Html.ValidationSummary(false, "", new With { .class = "text-danger" })

        @<fieldset>

        <legend>Create</legend>

        <div class="editor-field">
            @Html.Label("Task Name:")
            @Html.TextBoxFor(Function(m) m.TaskName, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.TaskName)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Note:")
            @Html.TextAreaFor(Function(m) m.Note)
            @Html.ValidationMessageFor(Function(m) m.Note)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Start Date:")
            @Html.TextBoxFor(Function(m) m.StartDate, new With { .Cssclass = "txtbox" } )
            @Html.ValidationMessageFor(Function(m) m.StartDate, "", new With { .class = "text-danger" })
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Duration:")
            @Html.DropDownList("ddlDurations", Model.Durations, "Select...")
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Resource:")
            @Html.DropDownList("ddlResources", Model.Resources, "Select...")
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Status:")
            @Html.DropDownList("ddlStatusTypes", Model.Statuses, "Select...")
        </div>
        <br/>
        <p>
            <input type = "submit" name="submit" value="Save" />
            <input type = "submit" name="submit" value="Cancel" />
        </p>

     </fieldset>
    end using

</body>
</html>



