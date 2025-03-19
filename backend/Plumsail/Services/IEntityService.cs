namespace Plumsail.Services;

public interface IEntityService
{
    Task<object> AddEntity(string owner, Dictionary<string, string> data, CancellationToken cancellationToken = default);
    Task<object?> GetEntityById(long id, CancellationToken cancellationToken = default);
    IEnumerable<object> GetEntities(string owner);
}