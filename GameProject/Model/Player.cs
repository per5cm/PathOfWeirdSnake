namespace GameProject.Model;

class Player
{
    public Player(Position startPosition, string symbol)
    {
        Position = startPosition;
        Symbol = symbol;
        //Dead = dead;
    }

    public Position Position { get; set; }

    public string Symbol { get; set; } = "  ";

    //public bool Dead { get; init; } = false;
}
