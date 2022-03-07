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
            CharacterClass = "Fighter",
            HitPoints = 10,
            Gold = 1000,
            ExperiencePoints = 0,
            Level = 1
        };
    }
    public void AddXP()
    {
        this.CurrentPlayer.ExperiencePoints += 10;
    }
}
