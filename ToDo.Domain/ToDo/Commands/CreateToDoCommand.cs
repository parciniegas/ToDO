using Ilse.Cqrs.Commands;

namespace ToDo.Domain.ToDo.Commands;

public record CreateToDoCommand(string Title, string Description) : ICommand
{
    public ToDoItem GetToDoItem() => new(Title, Description);

    public ToDoItem GetToDo()
    {
        var todo = new ToDoItem(Title, Description);
        return todo;
    }
}

public record CreateToDoCommandResponse(int Id)
{
    public static CreateToDoCommandResponse FromId(int id) => new(id);
    
    public static CreateToDoCommandResponse FromItemId(int id)
    {
        return new CreateToDoCommandResponse(id);
    }
}