@ModelType Models.TaskViewModels.TaskEdit

<!DOCTYPE html>

<style type="text/css">
    .editor-field > label {
        float: left;
        width: 150px;
    }
</style>

<html>
<head>
    <title>Edit</title>
</head>

<body>
    <h1>Task</h1>

    @using (Html.BeginForm())


    @<fieldset>

<legend>Detail</legend>

    @Html.HiddenFor(function(m) m.TaskId)

    <div class="form-group">
    <div class="editor-field">
        @Html.Label("Task Name:")
        @Html.DisplayTextFor(Function(m) m.TaskName)
     </div>
     </div>

     <div class="form-group">
     <div class="editor-field">
        @Html.Label("Notes:")
        @Html.TextAreaFor(Function(m) m.Note, new With { .class = "form-control", .readonly = "readonly" })
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
            @Html.DisplayTextFor(Function(m) model.EndDate)
      </div>
      </div>

      <div class="form-group">
      <div class="editor-field">
            @Html.Label("Duration:")
            @Html.DropDownListFor(Function(m) m.TaskDuration, Model.Durations, new With { .class = "form-control", .readonly = "readonly" })
      </div>
      </div>

      <div class="form-group">
      <div class="editor-field">
            @Html.Label("Spent:")
            @Html.DropDownListFor(Function(m) m.TaskSpent, Model.Spents, new With { .class = "form-control", .readonly = "readonly" })
       </div>
       </div>

        <div class="form-group">
        <div class="editor-field">
                @Html.Label("Resource:")
                @Html.DropDownListFor(Function(m) m.ResourceId, Model.Resources, new With {.class = "form-control", .readonly = "readonly" })
        </div>
        </div>

        <div class="form-group">
        <div class="editor-field">
                @Html.Label("Status:")
                @Html.DropDownListFor(Function(m) m.Status, Model.Statuses, new With { .class = "form-control",.readonly = "readonly" })
        </div>
        </div>

    </fieldset>
    end using

</body>
</html>

