using System.ComponentModel.DataAnnotations;

namespace Luderia.Presentation.Contexts.Catalog.Requests;

public record struct AddGameRequest
{
    private const int maxDurationMin = 525960; // 1 year

    public int BGGId { get; init; }
    [Length(3, 64)]
    public string Name { get; init; }
    public List<string> Types { get; init; }
    [Length(3, 256)]
    public string Description { get; init; }
    [Range(1, 100)]
    public int MinPlayers { get; init; }
    [Range(1, 100)]
    public int MaxPlayers { get; init; }
    [Range(3, 80)]
    public int MinAge { get; init; }
    [Range(1, maxDurationMin)]
    public int DurationMins { get; init; }
}