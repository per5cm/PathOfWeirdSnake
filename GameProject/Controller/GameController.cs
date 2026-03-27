using GameProject.Model;
using GameProject.View;

namespace GameProject.Controller;

class GameController
{
    private readonly GameState _state;
    private readonly Renderer _renderer;
    private readonly InputController _inputController;
    private readonly Random Rng = new();

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
            isRunning = Update();
            Render(tick);

            tick++;
            Thread.Sleep(60); // FPS?
        }

        Console.SetCursorPosition(0, _state.World.Height + 4);
        Console.CursorVisible = true;
        Console.WriteLine("Spiel beendet.");
    }

    private bool Update()
    {
        var input = _inputController.ReadInput(_state);
        var isRunning = ApplyInput(input);
        ApplyMoveEnemy();

        // TODO: Erweiterungspunkt für Spielsysteme (z.B. Quests, Trigger, Interaktionen).

        // event of players death.
        if (_state.PlayerOne.Dead)
        {
            Console.WriteLine("You Dead!");
            return false;
        }
        else if (_state.PlayerTwo.Dead)
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
    private void MovePlayerOne(int dx, int dy)
    { 
        var newPosition = _state.PlayerOne.Position.Offset(dx, dy);

        if (_state.World.IsInside(newPosition))
        {
            _state.PlayerOne.Position = newPosition;

            if (_state.World.GetTile(newPosition) == TileType.Water)
            {
                _state.PlayerOne.Dead = true;
            }
            else if (newPosition == _state.Enemy.Position)
            {
                _state.PlayerOne.Dead = true;
            }
        }
    }

    private void MovePlayerTwo(int dx, int dy)
    {
        var newPosition = _state.PlayerTwo.Position.Offset(dx, dy);

        if (_state.World.IsInside(newPosition))
        {
            _state.PlayerTwo.Position = newPosition;

            if (_state.World.GetTile(newPosition) == TileType.Water)
            {
                _state.PlayerTwo.Dead = true;
            }
            else if (newPosition == _state.Enemy.Position)
            {
                _state.PlayerTwo.Dead = true;
            }
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
            case GameInput.MoveUp: MovePlayerOne(0, -1); break;
            case GameInput.MoveDown: MovePlayerOne(0, 1); break;
            case GameInput.MoveLeft: MovePlayerOne(-1, 0); break; 
            case GameInput.MoveRight: MovePlayerOne(1, 0); break;

            // movement player 2
            case GameInput.MoveUpArrow: MovePlayerTwo(0, -1); break;
            case GameInput.MoveDownArrow: MovePlayerTwo(0, 1); break;
            case GameInput.MoveLeftArrow: MovePlayerTwo(-1, 0); break;
            case GameInput.MoveRightArrow: MovePlayerTwo(1, 0); break;

            default: break;
        }
        return true;
    }
    #endregion

    #region Enemy
    private void MoveEnemy(int dx, int dy)
    {
        var newMove = _state.Enemy.Position.Offset(dx, dy);

        if (_state.World.IsInside(newMove))
        {
            _state.Enemy.Position = newMove;

            if (newMove == _state.PlayerOne.Position)
            {
                _state.PlayerOne.Dead = true;
            }
            else if (newMove == _state.PlayerTwo.Position)
            {
                _state.PlayerTwo.Dead = true;
            }
        }
    }

    private void ApplyMoveEnemy()
    {
        int move = Rng.Next(1, 5);

        switch (move)
        {
            case 1: MoveEnemy(0, -1); break;
            case 2: MoveEnemy(0, 1); break;
            case 3: MoveEnemy(-1, 0); break;
            case 4: MoveEnemy(1, 0); break;
        }
    }
    #endregion
}
