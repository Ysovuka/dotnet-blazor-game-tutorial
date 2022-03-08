using SimpleRPG.Game.Engine.Factories;
using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels;

public class GameSession : IGameSession
{
    public World CurrentWorld { get; private set; }
    public Player CurrentPlayer { get; private set; }
    public Location CurrentLocation { get; private set; }

    public GameSession()
    {
        this.CurrentPlayer = new Player
        {
            Name = "DarthPedro",
            CharacterClass = "Fighter",
            HitPoints = 10,
            Gold = 1000,
            ExperiencePoints = 0,
            Level = 1
        };

        this.CurrentWorld = WorldFactory.CreateWorld();
        this.CurrentLocation = this.CurrentWorld.GetHomeLocation();
    }
    public void AddXP()
    {
        this.CurrentPlayer.ExperiencePoints += 10;
    }
}
