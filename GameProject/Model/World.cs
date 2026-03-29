using GameProject.Model;
using GameProject.View;

namespace GameProject.Model;

class World
{
    private readonly HashSet<Position> _pointsOfInterest;
    private readonly HashSet<Position> _water;
    private readonly HashSet<Position> _wall;

    private readonly Random _random = new();

    public int Width { get; }

    public int Height { get; }

    public World(int width, int height)
    {
        Width = width;
        Height = height;

        if (width < 19 || height < 6)
        {
            throw new ArgumentOutOfRangeException(nameof(width), nameof(height), "Welt ist zu klein. Nicht alle vorgesehenen Felder passen in die Welt hinein.");
        }

        _wall = new HashSet<Position>
        {
            //new(width, height),

            new (14, 2),
            new (14, 5),
            new (14, 6),
            new (14, 7),
            new (14, 8),
            new (14, 9),
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


            new (19, 10),
            new (20, 10),
            new (21, 10),
            new (22, 10),
            new (20, 11),
            new (21, 11),
            new (22, 11),
            new (23, 11),
            };

        _pointsOfInterest = new HashSet<Position>();

        for (int i = 0; i < 5; i++)
        {
            int x = _random.Next(1, Width - 1); // <--- from top left 1, width -2 means minus from total width. otherwise point of intrest spawns in the walls.
            int y = _random.Next(1, Height - 1); // <--- to botom right 1,height -2 means minus from total heigh.
            var position = new Position(x, y);

            if (GetTile(position) == TileType.Floor)
            {
                _pointsOfInterest.Add(position);
            }
        }
    }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Width && 
               position.Y >= 0 && position.Y < Height;
    }

    public bool IsWalkable(Position position)
    {
        //if (IsInside(position)) return true;

        //else return false;

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

        else if (_wall.Contains(position))
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

#region Old hard coded world objects

//_pointsOfInterest = new HashSet<Position>
//        {
//            new (2, 2),
//            new (Width - 3, Height - 3),
//            new (Width / 2, Height - 2)
//        };

//_water = new HashSet<Position>
//        {
//            new (5, 4),
//            new (6, 4),
//            new (7, 4),
//            new (8, 4),

//            new (5, 5),
//            new (6, 5),
//            new (7, 5),
//            new (8, 5),
//            new (9, 5),


//            new (6, 6),
//            new (7, 6),
//            new (8, 6),
//            new (9, 6),


//            new (15, 2),
//            new (16, 2),
//            new (17, 2),
//            new (18, 2),
//            new (15, 3),
//            new (16, 3),
//            new (17, 3),
//            new (18, 3),
//        };
//    }

#endregion
