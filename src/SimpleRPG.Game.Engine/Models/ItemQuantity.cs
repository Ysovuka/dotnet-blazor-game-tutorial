using SimpleRPG.Game.Engine.Factories;

namespace SimpleRPG.Game.Engine.Models;

public class ItemQuantity
{
    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public string QuantityItemDescription =>
            $"{ItemFactory.GetItemName(ItemId)} (x{Quantity})";
}
