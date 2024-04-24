using Ilse.MinimalApi.EndPoints;

namespace ToDo.Api.Endpoints.ToDo.Get;

public class GetToDoByIdHandler: IEndpoint
{
    public RouteHandlerBuilder Configure(IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapGet("/todos/{id}", HandleAsync)
            .RequireAuthorization("todo.read")
            .WithTags("ToDo");
    }

    private Task HandleAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }
}