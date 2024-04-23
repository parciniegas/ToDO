using Ilse.Core.Results;
using Ilse.Cqrs.Commands;

namespace ToDo.Domain.ToDo.Commands;

public class CreateToDoCommandHandler(IToDoRepository repository)
    : ICommandHandler<CreateToDoCommand, OperationResult<CreateToDoCommandResponse>>
{
    public async Task<OperationResult<CreateToDoCommandResponse>> 
        HandleAsync(CreateToDoCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var todo = command.GetToDoItem();
        var id =  repository.Create(todo);

        //var response = new CreateToDoCommandResponse(id);
        //return response;
        return CreateToDoCommandResponse.FromId(id);
    }
}