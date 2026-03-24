namespace GameProject.Model;

class GameState
{
    public World World { get; }

    public Player PlayerOne { get; }
    public Player PlayerTwo { get; }

    public GameState(World world, Player playerOne, Player playerTwo)
    {
        World = world;
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
    }
}
