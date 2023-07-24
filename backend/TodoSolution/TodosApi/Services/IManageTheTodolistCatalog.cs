namespace TodosApi
{
    public class IManageTheTodoListCatalog
    {
        internal Task<TodoListCreateModel> AddTodoItemAsync(TodoListCreateModel request)
        {
            throw new NotImplementedException();
        }

        internal Task<CollectionResponse<TodoListItemResponseModel>> GetFullListAsync()
        {
            throw new NotImplementedException();
        }
    }
}