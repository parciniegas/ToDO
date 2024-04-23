namespace ToDo.Domain.ToDo;

public interface IToDoRepository
{
    public int Create(ToDoItem item);
}