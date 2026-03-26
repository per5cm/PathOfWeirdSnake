namespace GameProject.Model;

class Player
{
    public Position Position { get; set; }

    public string Symbol { get; set; } = "  ";

    public bool Dead { get; set; } = false;

    public Player(Position startPosition, string symbol, bool dead)
    {
        Position = startPosition;
        Symbol = symbol;
        Dead = dead;
    }
}
