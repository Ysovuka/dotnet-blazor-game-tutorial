namespace SimpleRPG.Game.Engine.Models;

public class GameItem
{
    public static readonly GameItem Empty = new GameItem();

    public GameItem(int itemTypeID, string name, int price, bool isUnique = false)
    {
        ItemTypeID = itemTypeID;
        Name = name;
        Price = price;
        IsUnique = isUnique;
    }

    private GameItem()
    {
    }

    public int ItemTypeID { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Price { get; set; }

    public bool IsUnique { get; set; }

    public virtual GameItem Clone() =>
        new GameItem(ItemTypeID, Name, Price, IsUnique);
}
