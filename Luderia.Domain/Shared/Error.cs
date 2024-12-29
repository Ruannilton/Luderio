public abstract record Error
{
    public string Title { get; private set; } = "An error occurred";
    public void SetTitle(string title)
    {
        Title = title;
    }
}
