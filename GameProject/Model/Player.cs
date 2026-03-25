namespace GameProject.Model;

class Player
{
    public Player(Position startPosition, string symbol)
    {
        Position = startPosition;
        Symbol = symbol;
    }

    public Position Position { get; set; }

    public string Symbol { get; set; } 
}
