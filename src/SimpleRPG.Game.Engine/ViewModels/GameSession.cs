using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels;

public class GameSession
{
    public Player CurrentPlayer { get; set; }

    public GameSession()
    {
        this.CurrentPlayer = new Player
        {
            Name = "DarthPedro",
            Gold = 1000
        };
    }
}
