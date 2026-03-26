namespace GameProject.Model;

class GameState
{
    public World World { get; }

    public Player PlayerOne { get; }
    public Player PlayerTwo { get; } 
    public Enemy Enemy {  get; }

    public GameState(World world, Player playerOne, Player playerTwo, Enemy enemy)
    {
        World = world;
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
        Enemy = enemy;
    }
}
