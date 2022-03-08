namespace SimpleRPG.Game.Engine.Models;

public class Player
{
    public string Name { get; set; } = string.Empty;

    public string CharacterClass { get; set; } = string.Empty;

    public int HitPoints { get; set; }

    public int ExperiencePoints { get; set; }

    public int Level { get; set; }

    public int Gold { get; set; }

    public Inventory Inventory { get; } = new Inventory();
}
