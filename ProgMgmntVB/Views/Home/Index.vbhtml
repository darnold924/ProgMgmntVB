@ModelType Models.ProjectViewModels

<div class="">
    <h2>Projects</h2>
</div>

<div>
    <table border="1" cellpadding="10">
        <tr>
            <th>Project Name</th>
            <th>Client Name</th>
            <th>Technology</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th>Cost</th>
            <!--  <th colspan="3">Actions</th> -->
        </tr>
        @for each item as Models.ProjectViewModels.Project in Model.Projects
        
        @<tr>
            <td>@Html.ActionLink(item.ProjectName, "Task", new With { .id = item.ProjectId })</td>
            <td>@item.ClientName</td>
            <td>@item.Technology</td>
            <td>@item.StartDate.Value.ToString("MM/dd/yyyy")</td>
            <td>@item.EndDate.Value.ToString("MM/dd/yyyy")</td>
            <td>@item.Cost.Value.ToString("C0")</td>
        </tr>
        next

    </table>
</div>
