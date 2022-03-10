namespace SimpleRPG.Game.Engine.Factories.DTO;

public class TraderTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<IdQuantityItem> Inventory { get; set; } = new List<IdQuantityItem>();
}
