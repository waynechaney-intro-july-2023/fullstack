namespace TodosApi.Models;
public enum TodoItemStatus { Later, Now, Waiting,Completed}
    public record TodoListItemResponseModel(Guid Id,string Description, TodoItemStatus Status);

public record TodoListCreateModel
{
    public string Description { get; set; } = string.Empty;
}