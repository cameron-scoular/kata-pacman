using System;
using System.Threading;

namespace kata_pacman
{
    public class GameInputThreadProcessor
    {
        
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
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            LatestCharacterInput = CharacterInput.LeftInput;
                            break;
                        case ConsoleKey.RightArrow:
                            LatestCharacterInput = CharacterInput.RightInput;
                            break;
                    }
                }
                else
                {
                    LatestCharacterInput = null;
                }
                
                Thread.Sleep(50);
            } 
        }
        
    }
}