using Ilse.Cqrs.Commands;
using ToDo.Domain.ToDo.Commands;

namespace ToDo.Application.ToDo.Command;

public record AppCreateToDoCommand(string Title, string Description) : ICommand
{
    public CreateToDoCommand CreateToDoCommand() => new(Title, Description);
}

public record AppCreateToDoCommandResponse(int Id);