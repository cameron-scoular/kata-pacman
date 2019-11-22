using System;
using System.Threading;

namespace kata_pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameInputMediator = new GameInputThreadProcessor();
            
            var displayer = new ConsoleBoardDisplayer();

            var gameProcessor = new GameProcessor(displayer, gameInputMediator, 500);
            gameInputMediator.Processor = gameProcessor;
            
            gameProcessor.RunGame();

        }
    }
}
