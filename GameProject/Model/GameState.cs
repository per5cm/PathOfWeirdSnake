namespace GameProject.Model;

class GameState
{
    public GameState(World world, Player player)
    {
        World = world;
        Player = player;
    }

    public World World { get; }

    public Player Player { get; }
}


