namespace GameProject.Model;

class Player
{
    public Position Position { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public bool Dead { get; set; } = false;
    public int Score { get; set; } = 0;

    public Player(Position startPosition, string symbol, bool dead, int score)
    {
        Position = startPosition;
        Symbol = symbol;
        Dead = dead;
        Score = score;
    }
}
