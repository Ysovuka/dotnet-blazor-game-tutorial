namespace SimpleRPG.Game.Engine.Models;

public class Recipe
{
    public Recipe(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }

    public string Name { get; }

    public IList<ItemQuantity> Ingredients { get; } = new List<ItemQuantity>();

    public IList<ItemQuantity> OutputItems { get; } = new List<ItemQuantity>();

    public void AddIngredient(int itemId, int quantity)
    {
        if (!Ingredients.Any(x => x.ItemId == itemId))
        {
            Ingredients.Add(new ItemQuantity { ItemId = itemId, Quantity = quantity });
        }
    }

    public void AddOutputItem(int itemId, int quantity)
    {
        if (!OutputItems.Any(x => x.ItemId == itemId))
        {
            OutputItems.Add(new ItemQuantity { ItemId = itemId, Quantity = quantity });
        }
    }
}
