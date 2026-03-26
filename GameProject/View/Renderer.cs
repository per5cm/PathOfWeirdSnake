using System.Text;
using GameProject.Model;

namespace GameProject.View;

class Renderer
{
    public void Render(GameState state, int tick)
    {
        //Console.Clear();
        Console.SetCursorPosition(0, 0);

        var buffer = new StringBuilder();

        for (var y = 0; y < state.World.Height; y++)
        {
            for (var x = 0; x < state.World.Width; x++)
            {
                var position = new Position(x, y);

                if (position == state.PlayerOne.Position)
                {
                    buffer.Append(state.PlayerOne.Symbol);
                    continue;
                }
                else if (position == state.PlayerTwo.Position)
                {
                    buffer.Append(state.PlayerTwo.Symbol);
                    continue;
                }
                else if (position == state.Enemy.Position)
                {
                    buffer.Append(state.Enemy.Symbol);
                    continue;
                }

                var tile = state.World.GetTile(position);
                buffer.Append(ToSymbol(tile));
            }

            buffer.AppendLine();
        }

        buffer.AppendLine($"Tick: {tick}");
        buffer.AppendLine("[ESC] oder [Q] Beenden | [W] Up [S] Down [A] Links [D] Rechts ");
        buffer.AppendLine();
        buffer.AppendLine("========================= Legende ==============================");
        buffer.AppendLine("😏 = Spieler 1 | 😈 = Spieler 2 | █ = Mauer | ~ = Wasser | ★ = Punkt der Interaktion");

        Console.Write(buffer.ToString());
    }

    private static char ToSymbol(TileType tile) => tile switch
    {
        TileType.Wall => '█',
        TileType.Floor => ' ',
        TileType.Water => '~',
        TileType.PointOfInterest => '★',
        _ => ' '
    };
}


//private static string FormatCell(string content)
//    {
//        // ANSI-Codes entfernen (falls vorhanden)
//        var visible = System.Text.RegularExpressions.Regex
//            .Replace(content, @"\x1B\[[0-9;]*m", "");

//        // Wenn es ein normales Zeichen ist → KEIN Padding!
//        if (visible.Length == 1)
//            return content;

//        // Wenn es ein Emoji ist → auf 2 auffüllen
//        return content.PadRight(2);
//    }