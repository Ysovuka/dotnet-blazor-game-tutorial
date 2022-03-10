using SimpleRPG.Game.Engine.Factories.DTO;
using SimpleRPG.Game.Engine.Helpers;
using SimpleRPG.Game.Engine.Models;
using SimpleRPG.Game.Engine.Services;

namespace SimpleRPG.Game.Engine.Factories;

internal static class MonsterFactory
{
    private const string _resourceNamespace = "SimpleRPG.Game.Engine.Data.monsters.json";
    private static readonly IList<MonsterTemplate> _monsterTemplates = JsonSerializationHelper.DeserializeResourceStream<MonsterTemplate>(_resourceNamespace);

    public static Monster GetMonster(int monsterId, IDiceService? dice = null)
    {
        dice ??= DiceService.Instance;

        // first find the monster template by its id.
        var template = _monsterTemplates.First(p => p.Id == monsterId);

        // then create an instance of monster from that template.
        var weapon = ItemFactory.CreateGameItem(template.WeaponId);
        var monster = new Monster(template.Id, template.Name, template.Image, template.Dex, template.Str,
                                  template.AC, template.MaxHP, weapon, template.RewardXP, template.Gold);

        // finally add random loot for this monster instance.
        foreach (var loot in template.LootItems)
        {
            AddLootItem(monster, loot.Id, loot.Perc, dice);
        }

        return monster;
    }

    private static void AddLootItem(Monster monster, int itemID, int percentage, IDiceService dice)
    {
        if (dice.Roll("1d100").Value <= percentage)
        {
            monster.Inventory.AddItem(ItemFactory.CreateGameItem(itemID));
        }
    }
}