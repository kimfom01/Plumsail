using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Plumsail.Database;
using Plumsail.Entities;

namespace Plumsail.Services;

public class EntityService : IEntityService
{
    private readonly DataContext _dbContext;

    public EntityService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<object> AddEntity(string owner, Dictionary<string, string> data, CancellationToken cancellationToken = default)
    {
        var serializedData = JsonSerializer.Serialize(data);

        var entry = await _dbContext.Entities.AddAsync(new Entity
        {
            Owner = owner,
            Data = serializedData
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new
        {
            entry.Entity.Id,
            Data = data
        };
    }

    public async Task<object?> GetEntityById(long id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Entities
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null) return null;

        var data = JsonSerializer.Deserialize<Dictionary<string, string>>(entity.Data);

        return new
        {
            entity.Id,
            Owner = entity.Owner,
            Data = data
        };
    }

    public IEnumerable<object> GetEntities(string owner)
    {
        var entities = _dbContext.Entities
            .Where(entity => entity.Owner.Equals(owner, StringComparison.InvariantCultureIgnoreCase))
            .AsNoTracking()
            .Select(entity => new
            {
                entity.Id,
                Owner = entity.Owner,
                Data = JsonSerializer.Deserialize<Dictionary<string, string>>(entity.Data, new JsonSerializerOptions())
            });

        return entities;
    }
}