using System;
using System.Threading;

namespace kata_pacman
{
    public class GameInputThreadProcessor
    {
        public GameProcessor Processor;
        
        public CharacterInput? LatestCharacterInput { get; private set; }

        private Thread ListeningThread;

        public GameInputThreadProcessor()
        {
            ListeningThread = new Thread(ListenAndUpdateLatestKeyPress);
            ListeningThread.Start();
        }

        private void ListenAndUpdateLatestKeyPress()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    
                    var keyInfo = Console.ReadKey(true);

                    Processor.ProcessCharacterTurnInput(keyInfo);
                }
                else
                {
                    LatestCharacterInput = null;
                }
                //Thread.Sleep(100);
                
            } 
        }
        
    }
}