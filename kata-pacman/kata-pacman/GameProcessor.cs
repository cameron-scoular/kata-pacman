using System;
using System.Threading;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameProcessor
    {

        public GameState GameState;
        private readonly ConsoleBoardDisplayer ConsoleBoardDisplayer;
        private readonly GameInputThreadProcessor GameInputThreadProcessor;
        private readonly BoardFileParser BoardFileParser;

        public int TickPeriod { get; set; }

        public GameProcessor(ConsoleBoardDisplayer consoleBoardDisplayer, GameInputThreadProcessor gameInputThreadProcessor, BoardFileParser boardParser, int tickPeriod)
        {
            ConsoleBoardDisplayer = consoleBoardDisplayer;
            GameInputThreadProcessor = gameInputThreadProcessor;
            BoardFileParser = boardParser;
            
            InitializeNewGame(tickPeriod);
            
        }
        
        public void InitializeNewGame(int tickPeriod)
        {

            IGameTile[,] board = BoardFileParser.ParseBoardCsvFile("../../../maze.csv");
            
            GameState = new GameState(board, new Coordinate((int)Math.Round(board.GetLength(0)/2.0), (int)Math.Round(board.GetLength(1)/2.0)));
            TickPeriod = tickPeriod;
            
            var pacmanCharacterProcessor = new CharacterProcessor(new PacmanCharacterInteractionProcessor(), new PacmanGameTileInteractionProcessor(), this);   
            var pacmanCharacter = new PacmanCharacter(GameState.BoardState.PlayerSpawnPosition, Direction.East, pacmanCharacterProcessor);
            GameState.PacmanCharacter = pacmanCharacter;
            GameState.GameCharacterSet.Add(pacmanCharacter);
            
            var ghostCharacterProcessor = new CharacterProcessor(new GhostCharacterInteractionProcessor(), new GhostGameTileInteractionProcessor(), this);
            GameState.GameCharacterSet.Add(new DumbGhostCharacter(new Coordinate(1, 1), Direction.East, ghostCharacterProcessor));
            GameState.GameCharacterSet.Add(new DumbGhostCharacter(new Coordinate(1, 2), Direction.West, ghostCharacterProcessor));
            
            GameState.GameCharacterSet.Add(new SmartGhostCharacter(new Coordinate(2, 1), Direction.East, ghostCharacterProcessor, GameState));
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