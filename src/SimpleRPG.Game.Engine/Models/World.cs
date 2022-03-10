namespace SimpleRPG.Game.Engine.Models;

public class World
{
    private readonly IList<Location> _locations;

    public World(IEnumerable<Location>? locs = null)
    {
        _locations = locs is null ? new List<Location>() : locs.ToList();
    }

    internal void AddLocation(Location location)
    {
        _locations.Add(location);
    }

    public Location LocationAt(int xCoordinate, int yCoordinate)
    {
        var loc = _locations.FirstOrDefault(p => p.XCoordinate == xCoordinate && p.YCoordinate == yCoordinate);
        return loc ?? throw new ArgumentOutOfRangeException("Coordinates", "Provided coordinates could not be found in game world.");
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
