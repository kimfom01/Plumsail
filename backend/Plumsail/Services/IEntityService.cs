namespace Plumsail.Services;

public interface IEntityService
{
    Task<object> AddEntity(Dictionary<string, string> data, CancellationToken cancellationToken = default);
    Task<object?> GetEntityById(long id, CancellationToken cancellationToken = default);
    IEnumerable<object> GetEntities();
}