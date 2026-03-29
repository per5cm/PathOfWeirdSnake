using GameProject.Model;
using GameProject.View;
using System.Numerics;

namespace GameProject.Controller;

class GameController
{
    private readonly GameState _state;
    private readonly Renderer _renderer;
    private readonly InputController _inputController;

    private readonly Random _random = new();

    public GameController(GameState state, Renderer renderer, InputController inputController)
    {
        _state = state;
        _renderer = renderer;
        _inputController = inputController;
    }

    public void Run()
    {
        //Console.Clear();
        Console.CursorVisible = false;
        //if (_state.PlayerOne.Dead) Console.WriteLine("You Dead!");
        //if (_state.PlayerTwo.Dead) Console.WriteLine("You Dead!");

        bool isRunning = true;
        int tick = 0;

        while (isRunning)
        {
            isRunning = Update(tick);
            Render(tick);

            tick++;
            Thread.Sleep(60); // FPS?
        }

        Console.SetCursorPosition(0, _state.World.Height + 4);
        Console.CursorVisible = true;
        Console.WriteLine("Spiel beendet.");
    }

    private bool Update(int tick)
    {
        var input = _inputController.ReadInput(_state);
        var isRunning = ApplyInput(input);
        ApplyMoveEnemy(tick);

        // TODO: Erweiterungspunkt für Spielsysteme (z.B. Quests, Trigger, Interaktionen).

        // event of players death.
        if (_state.PlayerOne.Dead || _state.PlayerTwo.Dead)
        {
            Console.WriteLine("You Dead!");
            return false;
        }

        return isRunning;
    }

    private void Render(int tick)
    {
        Console.Clear();
        _renderer.Render(_state, tick);
    }

    #region Player
    private void MovePlayer(Player player,int dx, int dy)
    { 
        var newPosition = player.Position.Offset(dx, dy);

        if (_state.World.IsWalkable(newPosition))
        {
            player.Position = newPosition;
        }

        // death conditions/events
        
        if (_state.World.GetTile(newPosition) == TileType.Water)
        {
            player.Dead = true;
        }
    }

    private bool ApplyInput(GameInput input)
    {
        switch (input)
        {
            // TODO: Steuerung (Bewegung) hier umsetzen.
            case GameInput.Quit: return false;
            case GameInput.None: break;

            // movement player one
            case GameInput.MoveUp: MovePlayer(_state.PlayerOne, 0, -1); break;
            case GameInput.MoveDown: MovePlayer(_state.PlayerOne, 0, 1); break;
            case GameInput.MoveLeft: MovePlayer(_state.PlayerOne, -1, 0); break; 
            case GameInput.MoveRight: MovePlayer(_state.PlayerOne, 1, 0); break;

            // movement player 2
            case GameInput.MoveUpArrow: MovePlayer(_state.PlayerTwo, 0, -1); break;
            case GameInput.MoveDownArrow: MovePlayer(_state.PlayerTwo, 0, 1); break;
            case GameInput.MoveLeftArrow: MovePlayer(_state.PlayerTwo, -1, 0); break;
            case GameInput.MoveRightArrow: MovePlayer(_state.PlayerTwo, 1, 0); break;

            default: break;
        }
        return true;
    }
    #endregion

    #region Enemy
    private void MoveEnemy(Enemy enemy, int dx, int dy)
    {
        var newMove = enemy.Position.Offset(dx, dy);

        if (_state.World.IsWalkable(newMove))
        {
            enemy.Position = newMove;
        }

        if (newMove == _state.PlayerOne.Position || newMove == _state.PlayerTwo.Position)
        {
            _state.PlayerOne.Dead = true;
            _state.PlayerTwo.Dead = true;
        }
    }

    private void ApplyMoveEnemy(int tick)
    {
        if (tick % 3 != 0) return;

        int move = _random.Next(1, 5);

        switch (move)
        {
            case 1: MoveEnemy(_state.Enemy, 0, -1); break;
            case 2: MoveEnemy(_state.Enemy, 0, 1); break;
            case 3: MoveEnemy(_state.Enemy, -1, 0); break;
            case 4: MoveEnemy(_state.Enemy, 1, 0); break;
        }  
    }
    #endregion
}
