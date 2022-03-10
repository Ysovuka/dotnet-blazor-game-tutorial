namespace SimpleRPG.Game.Engine.Models;

public class Trader : LivingEntity
{
    public Trader(int id, string name)
        : base(id, name, 10, 10, 10, 999, 999, 100)
    {
    }
}
