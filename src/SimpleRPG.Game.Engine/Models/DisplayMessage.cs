namespace SimpleRPG.Game.Engine.Models;

public class DisplayMessage
{
    public DisplayMessage(string title, IList<string> messages)
    {
        Title = title;
        Messages = messages;
    }

    public string Title { get; } = string.Empty;

    public IList<string> Messages { get; }
}
