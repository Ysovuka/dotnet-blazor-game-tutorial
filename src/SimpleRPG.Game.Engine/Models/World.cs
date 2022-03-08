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

    public bool HasLocationAt(int xCoordinate, int yCoordinate)
    {
        return _locations.Any(p => p.XCoordinate == xCoordinate && p.YCoordinate == yCoordinate);
    }

    public Location GetHomeLocation()
    {
        return LocationAt(0, -1);
    }
}
