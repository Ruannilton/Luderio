namespace Luderia.Domain.Contexts.Catalog.Models;
public class Game
{
    public int BGGId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int MinAge { get; set; }
    public int Duration { get; set; }
    public List<GameType> Types { get; set; }
}

public class GameHeader
{
    public int BGGId { get; set; }
    public string Name { get; set; }
}