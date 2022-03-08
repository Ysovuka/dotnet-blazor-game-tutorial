using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine;
public interface IGameSession
{
    Player CurrentPlayer { get; }

    void AddXP();
}
