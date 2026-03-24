namespace GameProject.Model;

class Player
{
    public Player(Position startPosition)
    {
        Position = startPosition;
    }

    public Position Position { get; set; }

    public char Symbol { get; set; } = 'X';
}


