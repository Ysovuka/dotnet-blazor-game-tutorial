namespace SimpleRPG.Game.Engine.Models;

public class GroupedInventoryItem
{
    public GameItem Item { get; set; } = GameItem.Empty;

    public int Quantity { get; set; }
}
