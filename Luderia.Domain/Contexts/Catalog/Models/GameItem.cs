namespace Luderia.Domain.Contexts.Catalog.Models;

public class GameItem
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public bool Available { get; set; }
    public List<Damage> Damages { get; set; } = new List<Damage>();
}
