using SimpleRPG.Game.Engine.Actions;

namespace SimpleRPG.Game.Engine.Models;

public class GameItem
{
    public enum ItemCategory
    {
        Miscellaneous,
        Weapon,
        Consumable
    }

    public GameItem(int itemTypeID, ItemCategory category, string name, int price, bool isUnique = false, IAction? action = null)
    {
        ItemTypeID = itemTypeID;
        Category = category;
        Name = name;
        Price = price;
        IsUnique = isUnique;
        Action = action;
    }

    public int ItemTypeID { get; }

    public ItemCategory Category { get; }

    public string Name { get; }

    public int Price { get; }

    public bool IsUnique { get; }

    public IAction? Action { get; private set; }

    public virtual GameItem Clone() =>
        new GameItem(ItemTypeID, Category, Name, Price, IsUnique, Action);

    internal void SetAction(IAction? action)
    {
        this.Action = action;
    }

    internal DisplayMessage PerformAction(LivingEntity actor, LivingEntity target)
    {
        if (Action is null)
        {
            throw new InvalidOperationException("CurrentWeapon.Action cannot be null");
        }

        return Action.Execute(actor, target);
    }
}