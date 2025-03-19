namespace Plumsail.Entities;

public class Entity
{
    public long Id { get; set; }
    public required string Owner { get; set; }
    public string Data { get; set; } = string.Empty;
}