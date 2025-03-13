using Plumsail.Services;

namespace Plumsail.Endpoints;

public static class EntityEndpoints
{
    public static void MapEntityEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("/entities")
            .WithTags("Entity Endpoints");

        MapPostEntity(group);
        MapGetEntityById(group);
        MapGetEntities(group);
    }

    private static void MapPostEntity(RouteGroupBuilder group)
    {
        group.MapPost("/",
                async (Dictionary<string, string> data, IEntityService entityService,
                    CancellationToken cancellationToken) =>
                {
                    var entity = await entityService.AddEntity(data, cancellationToken);

                    return Results.Created("", entity);
                })
            .WithSummary("Create entity entry");
    }

    private static void MapGetEntityById(RouteGroupBuilder group)
    {
        group.MapGet("/{id:long}", async (long id, IEntityService entityService, CancellationToken cancellationToken) =>
            {
                var entity = await entityService.GetEntityById(id, cancellationToken);

                if (entity is null)
                {
                    return Results.NotFound("Requested entity does not exist");
                }

                return Results.Ok(entity);
            })
            .WithSummary("Get an entity by ID");
    }

    private static void MapGetEntities(RouteGroupBuilder group)
    {
        group.MapGet("/", (IEntityService entityService) =>
            {
                var entities = entityService.GetEntities();

                return Results.Ok(entities);
            })
            .WithSummary("Get all entities");
    }
}