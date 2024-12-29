public record struct UpdateGameMessage
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? MinPlayers { get; set; }
    public int? MaxPlayers { get; set; }
    public int? MinAge { get; set; }
    public int? Duration { get; set; }
}
