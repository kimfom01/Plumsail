using Microsoft.EntityFrameworkCore;
using Plumsail.Entities;

namespace Plumsail.Database;

public class DataContext : DbContext
{
    public DbSet<Entity> Entities { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}