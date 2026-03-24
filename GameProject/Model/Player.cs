namespace GameProject.Model;

class Player
{
    public Player(Position startPosition, char symbol)
    {
        Position = startPosition;
        Symbol = symbol;
    }

    public Position Position { get; set; }

    public char Symbol { get; set; } 
}
