

using Marten;

namespace TodosApi.Controllers;

[ApiController]
public class TodoListController : ControllerBase
{

    private readonly IDocumentSession _documentSession;

    public TodoListController(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    [HttpPost("/todo-list")]
    public async Task<ActionResult> AddTodoItem([FromBody] TodoListCreateModel request)
    {

        // if we get here, this is valid.
        // add it to the database.
        var response = new TodoListItemResponseModel(Guid.NewGuid(), request.Description, TodoItemStatus.Later);

        _documentSession.Store(response);
        await _documentSession.SaveChangesAsync();
        // send it back to them. 
        return Ok(response);
    }


    // GET /todo-list
    [HttpGet("/todo-list")]
    public async Task<ActionResult> GetTodoList()
    {
        // fake this for a moment
        var list = await _documentSession.Query<TodoListItemResponseModel>().ToListAsync();

        // var response = new CollectionResponse<TodoListItemResponseModel>(list);
        return Ok(list);
    }
}