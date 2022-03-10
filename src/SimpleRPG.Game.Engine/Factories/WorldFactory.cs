using SimpleRPG.Game.Engine.Factories.DTO;
using SimpleRPG.Game.Engine.Helpers;
using SimpleRPG.Game.Engine.Models;

namespace SimpleRPG.Game.Engine.Factories;


internal static class WorldFactory
{
    private const string _resourceNamespace = "SimpleRPG.Game.Engine.Data.locations.json";

    internal static World CreateWorld()
    {
        var locationTemplates = JsonSerializationHelper.DeserializeResourceStream<LocationTemplate>(_resourceNamespace);
        var newWorld = new World();

        foreach (var template in locationTemplates)
        {
            var trader = (template.TraderId is null) ? null : TraderFactory.GetTraderById(template.TraderId.Value);
            var loc = new Location(template.X, template.Y, template.Name, template.Description,
                                   template.ImageName, trader);

            foreach (var questId in template.Quests)
            {
                loc.QuestsAvailableHere.Add(QuestFactory.GetQuestById(questId));
            }

            foreach (var enc in template.Monsters)
            {
                loc.AddMonsterEncounter(enc.Id, enc.Perc);
            }

            newWorld.AddLocation(loc);
        }

        return newWorld;
    }
}