﻿using SimpleRPG.Game.Engine.Models;
using SimpleRPG.Game.Engine.ViewModels;

namespace SimpleRPG.Game.Engine;
public interface IGameSession
{
    Player CurrentPlayer { get; }
    Location CurrentLocation { get; }
    MovementUnit Movement { get; }

    void OnLocationChanged(Location newLocation);

}
