using Microsoft.AspNetCore.Mvc;

namespace Luderia.Presentation.Contexts.Catalog.Requests;

public class SearchGameRequest
{
    [FromQuery]
    public string? Name { get; set; }
    [FromQuery]
    public List<string>? Types { get; set; }
    [FromQuery]
    public int? MinPlayers { get; set; }
    [FromQuery]
    public int? MaxPlayers { get; set; }
    [FromQuery]
    public int? MinAge { get; set; }
    [FromQuery]
    public int? Duration { get; set; }
}
