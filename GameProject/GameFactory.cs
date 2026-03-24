namespace GameProject;

using Controller;
using Model;
using View;

static class GameFactory
{
    public static GameController Create()
    {
        var world = new World(width: 30, height: 12);
        var player = new Player(startPosition: new Position(3, 3), 'X');
        var player2 = new Player(startPosition: new Position(6, 6), 'O');

        var state = new GameState(world, player, player2);

        var renderer = new Renderer();
        var inputController = new InputController();

        return new GameController(state, renderer, inputController);
    }
}
