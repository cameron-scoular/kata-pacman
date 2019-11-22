using System;
using System.Threading;

namespace kata_pacman
{
    public class GameInputThreadProcessor
    {
        public GameProcessor Processor;
        public bool GameActive = true;
        
        private Thread KeyPressHandlerThread;

        public GameInputThreadProcessor()
        {
            KeyPressHandlerThread = new Thread(DetectAndHandleKeyPress);
            KeyPressHandlerThread.Start();
        }

        private void DetectAndHandleKeyPress()
        {
            while (GameActive)
            {
                if (Console.KeyAvailable)
                {
                    
                    var keyInfo = Console.ReadKey(true);

                    Processor.ProcessCharacterTurnInput(keyInfo);
                }

            } 
        }
        
    }
}