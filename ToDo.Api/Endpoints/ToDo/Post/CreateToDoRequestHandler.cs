using Ilse.Core.Context;
using Ilse.Core.Results;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi.EndPoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.ToDo.Command;
using ToDo.Domain.ToDo.Commands;

namespace ToDo.Api.Endpoints.ToDo.Post;

public class CreateToDoRequestHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/todos", HandleAsync)
            .RequireAuthorization("todo.create")
            .WithTags("ToDo");
    }

    private static async Task<Results<
        Created<CreateToDoCommandResponse>,
        BadRequest<ProblemDetails>,
        Conflict<ProblemDetails>>>
        HandleAsync(ILogger<CreateToDoRequestHandler> logger,
            IContextAccessor<CorrelationContext> correlationAccessor,
            ICommandDispatcher commandDispatcher,
            CreateToDoRequest request)
    {
        var result =
            await commandDispatcher.ExecAsync<AppCreateToDoCommand, OperationResult<CreateToDoCommandResponse>>(request.CreateToDoCommand());
        if (result.IsSuccess)
            return TypedResults.Created($"/todos/{result.Value!.Id}", new CreateToDoCommandResponse(result.Value!.Id));

        var problemDetails = result.ProblemDetails(correlationAccessor.Context!.CorrelationId);
        logger.LogError(problemDetails.ToJson());
        return result.ErrorType switch
        {
            ErrorType.BadRequest => TypedResults.BadRequest(problemDetails),
            ErrorType.Conflict => TypedResults.Conflict(problemDetails),
            _ => TypedResults.BadRequest(problemDetails)
        };
    }
}