using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameState
    {
        public BoardState BoardState { get; private set; }
        
        public PacmanCharacter PacmanCharacter;
        
        public readonly HashSet<ICharacter> GameCharacterSet = new HashSet<ICharacter>(); // Set used to ensure no character is duplicated in the game state

        public bool GameInProgress = true;

        public int TickNumber { get; set; }
        
        public int Score { get; set; }

        public GameState()
        {

            Score = 0;

            TickNumber = 0;
            
            BoardState = new BoardState();
        }

        
        
    }
}