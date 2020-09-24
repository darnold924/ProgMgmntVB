@ModelType Models.TaskViewModels

<h2>Index</h2>

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <h3>List of Tasks</h3>

    <form method="post">

        @Html.ActionLink("Create", "Create")
        @Html.ActionLink("Cancel", "Cancel")

        <br /><br />
        <table border="1" cellpadding="10">
            <tr>
                <th>Task Name</th>
                <th>Start Date</th>
                <th>End Date</th>
                <th>Status</th>
                <th colspan="4">Actions</th>
            </tr>
            @For Each item As Models.TaskViewModels.TaskEdit in Model.Tasks
            
                @<tr>
                    <td>@item.TaskName</td>
                    <td>
                        @if Not IsNothing(item.StartDate) Then
                            @item.StartDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                        End If
                    </td>
                    <td>
                        @if Not IsNothing(item.EndDate) Then
                            @item.EndDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt")
                        End If
                    </td>
                    <td>@item.Status</td>
                    <td>
                         @Html.ActionLink("Edit", "Edit", new With { .id = item.TaskId })
                     </td>
                     <td>
                         @Html.ActionLink("Details", "details", new With { .id = item.TaskId })
                     </td>
                     <td>
                          @Html.ActionLink("Delete", "delete", new With { .id = item.TaskId },
                            new With { .onclick = "return confirm('Are you sure you wish to delete this task?');" })
                      </td>
                      <td>
                           @Html.ActionLink("File Upload", "UploadFile", new With { .id = item.TaskId })
                      </td>
                   </tr>
              next
        </table>
    </form>
</body>
</html>

