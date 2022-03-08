using SimpleRPG.Game.Engine.Factories;
using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.ViewModels;

public class GameSession : IGameSession
{
    private readonly World _currentWorld;
    public Player CurrentPlayer { get; private set; }
    public Location CurrentLocation { get; private set; }

    public Monster? CurrentMonster { get; private set; }

    public bool HasMonster => CurrentMonster != null;

    public MovementUnit Movement { get; private set; }

    public GameSession()
    {
        CurrentPlayer = new Player
        {
            Name = "DarthPedro",
            CharacterClass = "Fighter",
            CurrentHitPoints = 10,
            MaximumHitPoints = 10,
            Gold = 1000,
            ExperiencePoints = 0,
            Level = 1
        };

        this._currentWorld = WorldFactory.CreateWorld();
        this.Movement = new MovementUnit(this._currentWorld);
        this.CurrentLocation = this.Movement.CurrentLocation;
        GetMonsterAtCurrentLocation();

        CurrentPlayer.Inventory.AddItem(ItemFactory.CreateGameItem(1001)!);
    }

    public void OnLocationChanged(Location newLocation)
    {
        this.CurrentLocation = newLocation;
        GetMonsterAtCurrentLocation();
    }

    private void GetMonsterAtCurrentLocation() =>
            CurrentMonster = CurrentLocation.HasMonster() ? CurrentLocation.GetMonster() : null;
}
