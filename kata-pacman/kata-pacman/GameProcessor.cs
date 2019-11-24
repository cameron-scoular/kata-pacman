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
            
            var pacmanCharacterProcessor = new CharacterProcessor(new PacmanCharacterInteractionProcessor(), new PacmanGameTileInteractionProcessor(), this);   
            var pacmanCharacter = new PacmanCharacter(GameState.BoardState.PlayerSpawnPosition, Direction.East, pacmanCharacterProcessor);
            GameState.PacmanCharacter = pacmanCharacter;
            GameState.GameCharacterSet.Add(pacmanCharacter);
            
            var ghostCharacterProcessor = new CharacterProcessor(new GhostCharacterInteractionProcessor(), new GhostGameTileInteractionProcessor(), this);
            GameState.GameCharacterSet.Add(new DumbGhostCharacter(new Coordinate(1, 1), Direction.East, ghostCharacterProcessor));
            GameState.GameCharacterSet.Add(new DumbGhostCharacter(new Coordinate(2, 2), Direction.West, ghostCharacterProcessor));
            
            GameState.GameCharacterSet.Add(new SmartGhostCharacter(new Coordinate(3, 4), Direction.East, ghostCharacterProcessor, GameState));
        } 

        public void RunGame()
        {

            while (GameState.GameInProgress)
            {
                
                foreach (var character in GameState.GameCharacterSet)
                {
                    character.ProcessCharacter();
                }                
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
        
        public void ProcessTurnInput(ConsoleKeyInfo keyInfo)
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