using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Actions;

public interface IAction
{
    DisplayMessage Execute(LivingEntity actor, LivingEntity target);
}
