namespace GameProject.Model;

class World
{
    private readonly HashSet<Position> _pointsOfInterest;
    private readonly HashSet<Position> _water;
    private readonly HashSet<Position> _wall;

    public World(int width, int height)
    {
        if (width < 19 || height < 6)
        {
            throw new ArgumentOutOfRangeException(nameof(width), nameof(height), "Welt ist zu klein. Nicht alle vorgesehenen Felder passen in die Welt hinein.");
        }

        Width = width;
        Height = height;

        _pointsOfInterest = new HashSet<Position>
        {
            new (2, 2),
            new (Width - 3, Height - 3),
            new (Width / 2, Height - 2)
        };

        _wall = new HashSet<Position>
        {
            //new (0, -1),
        };

        _water = new HashSet<Position>
        {
            new (5, 4), 
            new (6, 4),
            new (7, 4),
            new (8, 4),
            
            new (5, 5),
            new (6, 5),
            new (7, 5),
            new (8, 5),
            new (9, 5),
            
            
            new (6, 6),
            new (7, 6),
            new (8, 6),
            new (9, 6),
            
            
            new (15, 2),
            new (16, 2),
            new (17, 2),
            new (18, 2),
            new (15, 3),
            new (16, 3),
            new (17, 3),
            new (18, 3),
        };
    }

    public int Width { get; }

    public int Height { get; }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Width && 
               position.Y >= 0 && position.Y < Height;
    }

    public bool IsWalkable(Position position)
    {
        TileType tile = GetTile(position);
        return tile != TileType.Wall && tile != TileType.Empty;
    }

    public TileType GetTile(Position position)
    {
        if (!IsInside(position))
        {
            return TileType.Empty;
        }

        else if (position.X == 0 || position.Y == 0 || position.X == Width - 1 || position.Y == Height - 1)
        {
            return TileType.Wall;
        }

        else if (_pointsOfInterest.Contains(position))
        {
            return TileType.PointOfInterest;
        }

        else if (_water.Contains(position))
        {
            return TileType.Water;
        }

        return TileType.Floor;
    }
}
