@ModelType Models.ProjectViewModels

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <h1>Projects</h1>

    <form method="post">

        @Html.ActionLink("Create", "Create")
        @Html.ActionLink("Cancel", "Cancel")

        <br /><br />
        <table border="1" cellpadding="10">
            <tr>
                <th>ProjectID</th>
                <th>Client Name</th>
                <th>Project Name</th>
                <th>Technology</th>
                <th colspan="4">Actions</th>
            </tr>
            @For Each item As Models.ProjectViewModels.Project In Model.Projects
                @<tr>
                    <td>@item.ProjectId</td>
                    <td>@item.ClientName</td>
                    <td>@item.ProjectName</td>
                    <td>@item.Technology</td>
                    <td>@Html.ActionLink("Edit", "Edit", new With { .id = item.ProjectId })</td>
                    <td>@Html.ActionLink("Details", "details", new With { .id = item.ProjectId })</td>
                    <td>@Html.ActionLink("Delete", "delete", new With { .id = item.ProjectId }, _
                        new With { .onclick = "return confirm('Are you sure you wish to delete this project?');" })</td>
                    <td> @Html.ActionLink("File Upload", "UploadFile", new With { .id = item.ProjectId })</td>
                </tr>
                next
        </table>
    </form>
</body>
</html>