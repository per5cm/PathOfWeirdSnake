using System;

namespace GameProject;

static class Program
{
    private static void Main(string[] args)
    {
        var game = GameFactory.Create();
        game.Run();
    }
}