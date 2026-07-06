namespace GameProject.Model;


class Enemy
{
    public Position Position {  get; set; }
    public string Symbol {  get; set; } 

    public Enemy(Position startPosition, string symbol)
    {
        Position = startPosition;
        Symbol = symbol;
    }
}
