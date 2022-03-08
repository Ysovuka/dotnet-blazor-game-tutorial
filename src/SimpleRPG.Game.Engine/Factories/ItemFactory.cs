using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Factories;

internal static class ItemFactory
{
    private static List<GameItem> _standardGameItems = new List<GameItem>
    {
        new Weapon(1001, "Pointy Stick", 1, 1, 2),
        new Weapon(1002, "Rusty Sword", 5, 1, 3)
    };

    public static GameItem? CreateGameItem(int itemTypeID)
    {
        var standardItem = _standardGameItems.FirstOrDefault(i => i.ItemTypeID == itemTypeID);
        return standardItem?.Clone();
    }
}
