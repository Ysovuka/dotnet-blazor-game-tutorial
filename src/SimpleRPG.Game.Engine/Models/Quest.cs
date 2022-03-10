namespace SimpleRPG.Game.Engine.Models;

public class Quest
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IList<ItemQuantity> ItemsToComplete { get; set; } = Array.Empty<ItemQuantity>();

    public int RewardExperiencePoints { get; set; }

    public int RewardGold { get; set; }

    public IList<ItemQuantity> RewardItems { get; set; } = Array.Empty<ItemQuantity>();
}
