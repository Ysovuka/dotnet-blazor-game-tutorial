namespace SimpleRPG.Game.Engine.Models;

public class Inventory
{
    private readonly List<GameItem> _backingInventory = new List<GameItem>();
    private readonly List<GroupedInventoryItem> _backingGroupedInventory = new List<GroupedInventoryItem>();

    public Inventory(IEnumerable<GameItem> items)
    {
        if (items == null)
        {
            return;
        }

        foreach (GameItem item in items)
        {
            AddItem(item);
        }
    }

    public Inventory()
    {
    }

    public IReadOnlyList<GameItem> Items => _backingInventory.AsReadOnly();

    public IReadOnlyList<GroupedInventoryItem> GroupedItems => _backingGroupedInventory.AsReadOnly();

    public IEnumerable<GameItem> Weapons => _backingInventory.Where(i => i is Weapon);

    public void AddItem(GameItem item)
    {
        _ = item ?? throw new ArgumentNullException(nameof(item));

        _backingInventory.Add(item);

        if (item.IsUnique)
        {
            _backingGroupedInventory.Add(new GroupedInventoryItem { Item = item, Quantity = 1 });
        }
        else
        {
            if (_backingGroupedInventory.All(gi => gi.Item.ItemTypeID != item.ItemTypeID))
            {
                _backingGroupedInventory.Add(new GroupedInventoryItem { Item = item, Quantity = 0 });
            }

            _backingGroupedInventory.First(gi => gi.Item.ItemTypeID == item.ItemTypeID).Quantity++;
        }
    }

    public void RemoveItem(GameItem item)
    {
        _ = item ?? throw new ArgumentNullException(nameof(item));

        _backingInventory.Remove(item);

        GroupedInventoryItem groupedInventoryItemToRemove =
            _backingGroupedInventory.FirstOrDefault(gi => gi.Item == item);

        if (groupedInventoryItemToRemove != null)
        {
            if (groupedInventoryItemToRemove.Quantity == 1)
            {
                _backingGroupedInventory.Remove(groupedInventoryItemToRemove);
            }
            else
            {
                groupedInventoryItemToRemove.Quantity--;
            }
        }
    }

    public bool HasAllTheseItems(IEnumerable<ItemQuantity> items)
    {
        return items.All(item => Items.Count(i => i.ItemTypeID == item.ItemId) >= item.Quantity);
    }
}