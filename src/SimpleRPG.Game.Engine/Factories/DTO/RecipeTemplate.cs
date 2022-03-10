namespace SimpleRPG.Game.Engine.Factories.DTO;

public class RecipeTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<IdQuantityItem> Ingredients { get; set; } = new List<IdQuantityItem>();

    public IEnumerable<IdQuantityItem> OutputItems { get; set; } = new List<IdQuantityItem>();
}
