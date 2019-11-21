using System;

namespace kata_pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var displayer = new ConsoleBoardDisplayer();
            
            displayer.DisplayConsoleBoard(new GameState());
            
            
        }
    }
}
