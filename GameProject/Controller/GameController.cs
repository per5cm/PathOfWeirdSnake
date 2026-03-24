using GameProject.Model;
using GameProject.View;

namespace GameProject.Controller;

class GameController
{
    private readonly GameState _state;
    private readonly Renderer _renderer;
    private readonly InputController _inputController;

    public GameController(
        GameState state,
        Renderer renderer,
        InputController inputController)
    {
        _state = state;
        _renderer = renderer;
        _inputController = inputController;
    }

    public void Run()
    {
        //Console.Clear();
        Console.CursorVisible = false;

        bool isRunning = true;
        int tick = 0;

        while (isRunning)
        {
            isRunning = Update();
            Render(tick);

            tick++;
            Thread.Sleep(500); // FPS?
        }

        Console.SetCursorPosition(0, _state.World.Height + 4);
        Console.CursorVisible = true;
        Console.WriteLine("Spiel beendet.");
    }

    private bool Update()
    {
        var input = _inputController.ReadInput(_state);
        var isRunning = ApplyInput(input);

        // TODO: Erweiterungspunkt für Spielsysteme (z.B. Quests, Trigger, Interaktionen).

        return isRunning;
    }

    private void Render(int tick)
    {
        Console.Clear();
        _renderer.Render(_state, tick);
    }

    private void MovePlayerOne(int dx, int dy)
    {
        var NewPosition = _state.PlayerOne.Position.Offset(dx, dy);

        _state.PlayerOne.Position = NewPosition;

    }

    private void MovePlayerTwo(int dx, int dy)
    {
        var NewPosition = _state.PlayerTwo.Position.Offset(dx, dy);

        _state.PlayerTwo.Position = NewPosition;
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
}
