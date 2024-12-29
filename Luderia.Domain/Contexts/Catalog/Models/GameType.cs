namespace Luderia.Domain.Contexts.Catalog.Models;

public class GameType
{

    public int Id { get; set; }
    public string Value { get; set; }
    public List<Game> Games { get; set; }

};
