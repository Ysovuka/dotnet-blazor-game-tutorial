using SimpleRPG.Game.Engine.Actions;
using SimpleRPG.Game.Engine.Factories.DTO;
using SimpleRPG.Game.Engine.Helpers;
using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Factories;

internal static class ItemFactory
{
    private const string _resourceNamespace = "SimpleRPG.Game.Engine.Data.items.json";
    private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

    static ItemFactory()
    {
        Load();
    }

    public static GameItem CreateGameItem(int itemTypeID)
    {
        var standardItem = _standardGameItems.First(i => i.ItemTypeID == itemTypeID);

        return standardItem.Clone();
    }

    public static string GetItemName(int itemTypeId)
    {
        return _standardGameItems.FirstOrDefault(i => i.ItemTypeID == itemTypeId)?.Name ?? "";
    }

    private static void Load()
    {
        var templates = JsonSerializationHelper.DeserializeResourceStream<ItemTemplate>(_resourceNamespace);
        foreach (var tmp in templates)
        {
            switch (tmp.Category)
            {
                case GameItem.ItemCategory.Weapon:
                    BuildWeapon(tmp.Id, tmp.Name, tmp.Price, tmp.Damage);
                    break;
                case GameItem.ItemCategory.Consumable:
                    BuildHealingItem(tmp.Id, tmp.Name, tmp.Price, tmp.Heals);
                    break;
                default:
                    BuildMiscellaneousItem(tmp.Id, tmp.Name, tmp.Price);
                    break;
            }
        }
    }

    private static void BuildMiscellaneousItem(int id, string name, int price) =>
        _standardGameItems.Add(new GameItem(id, GameItem.ItemCategory.Miscellaneous, name, price));

    private static void BuildWeapon(int id, string name, int price, string damageDice)
    {
        var weapon = new GameItem(id, GameItem.ItemCategory.Weapon, name, price, true);
        weapon.SetAction(new Attack(weapon, damageDice));
        _standardGameItems.Add(weapon);
    }

    private static void BuildHealingItem(int id, string name, int price, int healPoints)
    {
        GameItem item = new(id, GameItem.ItemCategory.Consumable, name, price);
        item.SetAction(new Heal(item, healPoints));
        _standardGameItems.Add(item);
    }
}