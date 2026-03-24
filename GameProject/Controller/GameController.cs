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

    private void MovePlayer(int dx, int dy)
    {
        var NewPosition = _state.Player.Position.Offset(dx, dy);

        _state.Player.Position = NewPosition;
    }

    private bool ApplyInput(GameInput input)
    {
        switch (input)
        {
            // TODO: Steuerung (Bewegung) hier umsetzen.

            case GameInput.Quit: return false;
            case GameInput.None: break;

            // movement
            case GameInput.MoveUp: MovePlayer(0, -1); break;
            case GameInput.MoveDown: MovePlayer(0, 1); break;
            case GameInput.MoveLeft: MovePlayer(-1, 0); break; 
            case GameInput.MoveRight: MovePlayer(1, 0); break; 
            
            default: break;       
        }
        return true;
    }
}
