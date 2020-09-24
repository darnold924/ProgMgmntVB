@ModelType Models.TaskViewModels.TaskEdit

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
    <h1>Task</h1>

    @using (Html.BeginForm())


@Html.ValidationSummary(false, "", new With { .class = "text-danger" })

        @<fieldset>
        <legend>Edit</legend>

        @Html.HiddenFor(Function(m) m.TaskId)

        <div class="editor-field">
            @Html.Label("Task Name:")
            @Html.TextBoxFor(Function(m) m.TaskName, "", new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.TaskName)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Notes:")
            @Html.TextAreaFor(Function(m) m.Note)
            @Html.ValidationMessageFor(Function(m) m.Note)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Start Date:")
            @Html.TextBoxFor(Function(m) m.StartDate, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m) m.StartDate, "", new With { .class = "text-danger" })
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("End Date:")
            @Html.TextBoxFor(Function(m) m.EndDate, new With { .Cssclass = "txtbox" })
            @Html.ValidationMessageFor(Function(m)m.EndDate, "", new with { .class = "text-danger" })
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Duration:")
            @Html.DropDownListFor(Function(m) m.TaskDuration, Model.Durations)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Spent:")
            @Html.DropDownListFor(function(m) m.TaskSpent, Model.Spents)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Resource:")
            @Html.DropDownListFor(Function(m) m.ResourceId, Model.Resources)
        </div>
        <br/>

        <div class="editor-field">
            @Html.Label("Status:")
            @Html.DropDownListFor(Function(m) m.Status, Model.Statuses)
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







