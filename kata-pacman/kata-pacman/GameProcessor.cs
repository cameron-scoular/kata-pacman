using System.Threading;

namespace kata_pacman
{
    public class GameProcessor
    {

        private GameState GameState;
        private ConsoleBoardDisplayer ConsoleBoardDisplayer;
        private GameInputThreadProcessor GameInputThreadProcessor;

        public int TickPeriod { get; set; }
        
        public int Score { get; set; }

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
            Score = 0;
        }

        public void RunGame()
        {

            while (true)
            {
                var latestInputKey = GameInputThreadProcessor.LatestCharacterInput;

                if (latestInputKey != null)
                {
                    GameState.PlayableCharacter.HandleInputTurn((CharacterInput) latestInputKey);

                }
                    
                ProcessCharacterMovement();
                
            }
            
        }

       
        
        public void ProcessCharacterMovement()
        {
            foreach (var character in GameState.GameCharacterSet)
            {

                var currentPos = character.Position;

                var adjacentGameObject = GameState.BoardState.GetAdjacentObjectFromDirection(currentPos, character.Direction);
                
                if (adjacentGameObject.Passable) // If GameObject is passable, can move character onto it
                {

                    character.Position = adjacentGameObject.Position; // Changing the character's position
                    
                    // Updating board state references 
                    GameState.BoardState.Board[adjacentGameObject.Position.XPos, adjacentGameObject.Position.YPos].CharacterOnGameObject = character; 
                    GameState.BoardState.Board[currentPos.XPos, currentPos.YPos].CharacterOnGameObject = null; 

                }

                ConsoleBoardDisplayer.DisplayConsoleBoard(GameState);
                Thread.Sleep(TickPeriod/GameState.GameCharacterSet.Count); // Wait for tick period, with tick waiting period being allocated equally amongst characters
                
            }
        }

    }
}