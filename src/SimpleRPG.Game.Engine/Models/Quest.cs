namespace SimpleRPG.Game.Engine.Models;

public class Quest
{
    public Quest(int id, string name, string description, int rewardsGold, int rewardsXP)
    {
        Id = id;
        Name = name;
        Description = description;
        RewardGold = rewardsGold;
        RewardExperiencePoints = rewardsXP;
    }

    public Quest()
    {
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IList<ItemQuantity> ItemsToComplete { get; set; } = new List<ItemQuantity>();

    public int RewardExperiencePoints { get; set; }

    public int RewardGold { get; set; }

    public IList<ItemQuantity> RewardItems { get; set; } = new List<ItemQuantity>();

    public DisplayMessage ToDisplayMessage()
    {
        var messageLines = new List<string>
            {
                Description,
                "Items to complete the quest:"
            };

        foreach (ItemQuantity q in ItemsToComplete)
        {
            messageLines.Add(q.QuantityItemDescription);
        }

        messageLines.Add("Rewards for quest completion:");
        messageLines.Add($"{RewardExperiencePoints} experience points");
        messageLines.Add($"{RewardGold} gold");
        foreach (ItemQuantity itemQuantity in RewardItems)
        {
            messageLines.Add(itemQuantity.QuantityItemDescription);
        }

        return new DisplayMessage($"Quest Added - {Name}", messageLines);
    }
}
