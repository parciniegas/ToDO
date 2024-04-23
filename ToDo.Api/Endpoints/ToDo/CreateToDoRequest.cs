using ToDo.Application.ToDo.Command;

namespace ToDo.Api.Endpoints.ToDo;

public record CreateToDoRequest(string Title, string Description)
{
    public AppCreateToDoCommand CreateToDoCommand()
    {
        return new AppCreateToDoCommand(Title, Description);
    }
}

public record CreateToDoRequestResponse(int Id);