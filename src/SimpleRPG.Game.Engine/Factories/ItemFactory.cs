using SimpleRPG.Game.Engine.Actions;
using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Factories;

internal static class ItemFactory
{
    private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

    static ItemFactory()
    {
        BuildWeapon(1001, "Pointy Stick", 1, "1d2");
        BuildWeapon(1002, "Rusty Sword", 5, "1d3");

        BuildWeapon(1501, "Snake fangs", 0, "1d2");
        BuildWeapon(1502, "Rat claws", 0, "1d2");
        BuildWeapon(1503, "Spider fangs", 0, "1d4");

        BuildMiscellaneousItem(9001, "Snake fang", 1);
        BuildMiscellaneousItem(9002, "Snakeskin", 2);
        BuildMiscellaneousItem(9003, "Rat tail", 1);
        BuildMiscellaneousItem(9004, "Rat fur", 2);
        BuildMiscellaneousItem(9005, "Spider fang", 1);
        BuildMiscellaneousItem(9006, "Spider silk", 2);
    }

    public static GameItem CreateGameItem(int itemTypeID)
    {
        var standardItem = _standardGameItems.First(i => i.ItemTypeID == itemTypeID);

        return standardItem.Clone();
    }

    private static void BuildMiscellaneousItem(int id, string name, int price)
    {
        _standardGameItems.Add(new GameItem(id, GameItem.ItemCategory.Miscellaneous, name, price));
    }

    private static void BuildWeapon(int id, string name, int price, string damageDice)
    {
        var weapon = new GameItem(id, GameItem.ItemCategory.Weapon, name, price, true);
        weapon.Action = new Attack(weapon, damageDice);

        _standardGameItems.Add(weapon);
    }
}
