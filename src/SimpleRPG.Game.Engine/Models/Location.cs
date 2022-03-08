namespace SimpleRPG.Game.Engine.Models;

public class Location
{
    public int XCoordinate { get; set; }

    public int YCoordinate { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageName { get; set; } = string.Empty;
}
