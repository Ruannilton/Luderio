namespace Luderia.Domain.Contexts.Catalog.Models;

public record struct SearchGameMessage
{
    public string? Name { get; set; }
    public List<string>? Types { get; set; }
    public int? MinPlayers { get; set; }
    public int? MaxPlayers { get; set; }
    public int? MinAge { get; set; }
    public int? Duration { get; set; }
}
