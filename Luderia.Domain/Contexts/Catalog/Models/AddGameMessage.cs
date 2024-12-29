public record struct AddGameMessage
{
    public int BGGId { get; init; }
    public string Name { get; init; }
    public List<string> Types { get; init; }
    public string Description { get; init; }
    public int MinPlayers { get; init; }
    public int MaxPlayers { get; init; }
    public int MinAge { get; init; }
    public int Duration { get; init; }
}