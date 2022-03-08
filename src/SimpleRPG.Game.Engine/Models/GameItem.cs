namespace SimpleRPG.Game.Engine.Models;

public class GameItem
{
    public GameItem(int itemTypeID, string name, int price)
    {
        ItemTypeID = itemTypeID;
        Name = name;
        Price = price;
    }

    public int ItemTypeID { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Price { get; set; }

    public virtual GameItem Clone() =>
        new GameItem(ItemTypeID, Name, Price);
}
