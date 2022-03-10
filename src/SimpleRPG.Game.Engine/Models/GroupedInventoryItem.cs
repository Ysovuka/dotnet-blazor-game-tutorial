namespace SimpleRPG.Game.Engine.Models;

public class GroupedInventoryItem
{
    public GroupedInventoryItem(GameItem item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }
    public GameItem Item { get; }

    public int Quantity { get; set; }
}
