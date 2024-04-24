using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using ToDo.Domain.ToDo.Commands;

namespace ToDo.Application.ToDo.Command;

public class AppCreateToDoCommandHandler(ICommandDispatcher commandDispatcher)
    : ICommandHandler<AppCreateToDoCommand, OperationResult<AppCreateToDoCommandResponse>>
{
    public async Task<OperationResult<AppCreateToDoCommandResponse>> 
        HandleAsync(AppCreateToDoCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var toDoCommand = command.CreateToDoCommand();
        var result = 
            await commandDispatcher.ExecAsync<CreateToDoCommand, OperationResult<CreateToDoCommandResponse>>(toDoCommand, cancellationToken);
        return new AppCreateToDoCommandResponse(result.Value!.Id);
    }
}