using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameState
    {
        public BoardState BoardState { get; private set; }
        
        public PacmanCharacter PacmanCharacter;
        
        public readonly HashSet<ICharacter> GameCharacterSet = new HashSet<ICharacter>(); 

        public bool GameInProgress = true;

        public int TickNumber { get; set; }
        
        public int Score { get; set; }

        public GameState(IGameTile[,] board, Coordinate spawnPosition)
        {

            Score = 0;

            TickNumber = 0;
            
            BoardState = new BoardState(board, spawnPosition);
        }

        
        
    }
}