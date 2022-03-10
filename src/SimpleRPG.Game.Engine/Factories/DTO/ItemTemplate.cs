using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Factories.DTO;

public class ItemTemplate
{
    public int Id { get; set; }

    public GameItem.ItemCategory Category { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Price { get; set; }

    public string Damage { get; set; } = string.Empty;

    public int Heals { get; set; }
}
