using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Services;

public class DisplayMessageBroker
{
    // Use the Singleton design pattern for this class,
    // to ensure everything in the game sends messages through this one object.
    private static readonly DisplayMessageBroker _messageBroker = new DisplayMessageBroker();

    private DisplayMessageBroker()
    {
    }

    public event EventHandler<DisplayMessage>? OnMessageRaised;

    public static DisplayMessageBroker Instance => _messageBroker;

    public void RaiseMessage(DisplayMessage message)
    {
        if (OnMessageRaised != null)
        {
            OnMessageRaised.Invoke(this, message);
        }
    }
}
