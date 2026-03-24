using GameProject.Model;

namespace GameProject.Controller;

class InputController
{
    public GameInput ReadInput(GameState state)
    {
        try
        {
            if (!Console.KeyAvailable)
            {
                return GameInput.None;
            }
        }
        catch (InvalidOperationException)
        {
            return GameInput.None;
        }

        var key = Console.ReadKey(intercept: true).Key;

        return key switch
        {
            ConsoleKey.Q => GameInput.Quit,
            ConsoleKey.Escape => GameInput.Quit,

            // TODO: Weitere Tasten auf GameInput-Werte mappen,
            //       z.B. W/A/S/D oder die Pfeiltasten für Bewegung.

            ConsoleKey.W => GameInput.MoveUp,
            ConsoleKey.S => GameInput.MoveDown,
            ConsoleKey.A => GameInput.MoveLeft,
            ConsoleKey.D => GameInput.MoveRight,
            
            _ => GameInput.None
        };
    }
}


