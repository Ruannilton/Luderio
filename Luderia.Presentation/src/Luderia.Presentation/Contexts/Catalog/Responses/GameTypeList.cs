using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Presentation.Contexts.Catalog.Responses;

public record GameTypeRecord(string Name);

public class GameTypeList
{
    public List<GameTypeRecord> Types { get; set; }

    public GameTypeList(List<GameType> types)
    {
        Types = types.Select(x => new GameTypeRecord(x.Value)).ToList();
    }
}
