using ToDo.Domain.ToDo;

namespace ToDo.Infrastructure.ToDo;

public class ToDoRepository: IToDoRepository
{
    private readonly List<ToDo> _todos = [];
    
    public int Create(ToDoItem todo)
    {
        var id = _todos.Count + 1;
        var toDo = new ToDo(id, todo.Title, todo.Description, todo.CreatedAt, todo.CompletedAt,
            todo.CompletedNote);
        _todos.Add(toDo);
        return id;
    }
}