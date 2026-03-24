namespace GameProject.Model;

class World
{
    private readonly HashSet<Position> _pointsOfInterest;
    private readonly HashSet<Position> _water;

    public World(int width, int height)
    {
        if (width < 19 || height < 6)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Welt ist zu klein. Nicht alle vorgesehenen Felder passen in die Welt hinein.");
        }

        Width = width;
        Height = height;

        _pointsOfInterest = new HashSet<Position>
        {
            new Position(2, 2),
            new Position(Width - 3, Height - 3),
            new Position(Width / 2, Height - 2)
        };
        
        _water = new HashSet<Position>
        {
            new Position(5, 4),
            new Position(6, 4),
            new Position(7, 4),
            new Position(8, 4),
            
            new Position(5, 5),
            new Position(6, 5),
            new Position(7, 5),
            new Position(8, 5),
            new Position(9, 5),
            
            
            new Position(6, 6),
            new Position(7, 6),
            new Position(8, 6),
            new Position(9, 6),
            
            
            new Position(15, 2),
            new Position(16, 2),
            new Position(17, 2),
            new Position(18, 2),
            new Position(15, 3),
            new Position(16, 3),
            new Position(17, 3),
            new Position(18, 3),
        };
    }

    public int Width { get; }

    public int Height { get; }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X < Width && position.Y < Height;
    }

    public TileType GetTile(Position position)
    {
        if (!IsInside(position))
        {
            return TileType.Empty;
        }

        if (position.X == 0 || position.Y == 0 || position.X == Width - 1 || position.Y == Height - 1)
        {
            return TileType.Wall;
        }

        if (_pointsOfInterest.Contains(position))
        {
            return TileType.PointOfInterest;
        }

        if (_water.Contains(position))
        {
            return TileType.Water;
        }

        return TileType.Floor;
    }
}


