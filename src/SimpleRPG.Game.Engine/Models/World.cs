namespace SimpleRPG.Game.Engine.Models;

public class World
{
    private readonly IEnumerable<Location> _locations;

    public World(IEnumerable<Location> locations)
    {
        _locations = locations ?? new List<Location>();
    }

    public Location LocationAt(int x, int y)
    {
        return _locations.FirstOrDefault(p => p.XCoordinate == x && p.YCoordinate == y) ??
            throw new ArgumentOutOfRangeException("Coordinates", "Provided coordinates could not be found in game world.");
    }

    public Location GetHomeLocation()
    {
        return LocationAt(0, -1);
    }
}
