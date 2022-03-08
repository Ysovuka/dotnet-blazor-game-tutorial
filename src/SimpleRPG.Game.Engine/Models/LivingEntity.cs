namespace SimpleRPG.Game.Engine.Models;

public abstract class LivingEntity
{
    public string Name { get; set; } = string.Empty;

    public int CurrentHitPoints { get; set; }

    public int MaximumHitPoints { get; set; }

    public int Gold { get; set; }

    public int Level { get; set; }

    public Inventory Inventory { get; } = new Inventory();
}
