namespace GameProject.Model;

readonly record struct Position(int X, int Y)
{
    public Position Offset(int dx, int dy) => new(X + dx, Y + dy);
    //public Position OffsetTwo(int dx, int dy) => new(X + dx, Y + dy);
}

