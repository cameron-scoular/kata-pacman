using System;
using System.Threading;

namespace kata_pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameInputThreadProcessor = new GameInputThreadProcessor();
            
            var displayer = new ConsoleBoardDisplayer();

            var parser = new BoardFileParser();

            var gameProcessor = new GameProcessor(displayer, gameInputThreadProcessor, parser,500);
            gameInputThreadProcessor.Processor = gameProcessor;
            
            gameProcessor.RunGame();

        }
    }
}
