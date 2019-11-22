using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameProcessor
    {

        public GameState GameState;
        private ConsoleBoardDisplayer ConsoleBoardDisplayer;
        private GameInputThreadProcessor GameInputThreadProcessor;

        public int TickPeriod { get; set; }

        public GameProcessor(ConsoleBoardDisplayer consoleBoardDisplayer, GameInputThreadProcessor gameInputThreadProcessor, int tickPeriod)
        {
            ConsoleBoardDisplayer = consoleBoardDisplayer;
            GameInputThreadProcessor = gameInputThreadProcessor;
            
            InitializeNewGame(tickPeriod);
            
        }
        
        public void InitializeNewGame(int tickPeriod)
        {
            GameState = new GameState();
            TickPeriod = tickPeriod;
        }

        public void RunGame()
        {

            while (GameState.GameInProgress)
            {
                
                ProcessAllCharacters();
                
                ConsoleBoardDisplayer.DisplayConsoleBoard(GameState);

                Tick();

            }

        }

        private void Tick()
        {
            Thread.Sleep(TickPeriod);
            GameState.TickNumber++;
            GameState.PacmanCharacter.TurnAvailable = true;
        }
        
        public void ProcessAllCharacters()
        {
            foreach (var character in GameState.GameCharacterSet)
            {
                character.ProcessCharacter(GameState, this);
            }

        }

        

        public void ProcessCharacterTurnInput(ConsoleKeyInfo keyInfo)
        {

            GameState.PacmanCharacter.HandleInputTurn(keyInfo, ConsoleBoardDisplayer, GameState);
                
            
        }
        

        public void LoseGame()
        {
            Console.WriteLine("Game Over!");
            GameState.GameInProgress = false;
            GameInputThreadProcessor.GameActive = false;
        }

    }
}