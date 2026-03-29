namespace GameProject;

using Controller;
using Model;
using View;

static class GameFactory
{
    public static GameController Create()
    {
        var world = new World(width: 54, height: 18);

        var player = new Player(startPosition: new Position(3, 3), "😏", dead: false);
        var player2 = new Player(startPosition: new Position(3, 9), "😈", dead: false);

        var enemy = new Enemy(startPosition: new Position(9, 3), "@");

        var state = new GameState(world, player, player2, enemy);

        var renderer = new Renderer();
        var inputController = new InputController();

        return new GameController(state, renderer, inputController);
    }
}
