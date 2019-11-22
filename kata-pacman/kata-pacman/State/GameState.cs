using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameState
    {
        public BoardState BoardState { get; private set; }
        
        public PacmanCharacter PacmanCharacter;
        
        public readonly HashSet<Character> GameCharacterSet = new HashSet<Character>(); // Set used to ensure no character is duplicated in the game state

        public bool GameInProgress = true;

        public int TickNumber { get; set; }
        
        public int Score { get; set; }

        public GameState()
        {

            Score = 0;

            TickNumber = 0;
            
            InitializeDefaultGameState();

            InitializeDefaultPlayableCharacter();

            InitializeDefaultGhostCharacter();
        }

        public void InitializeDefaultGameState()
        {
            BoardState = new BoardState();
        }

        public void InitializeDefaultPlayableCharacter()
        {
            
            PacmanCharacter = new PacmanCharacter(BoardState.PlayerSpawnPosition, Direction.East, BoardState);
            GameCharacterSet.Add(PacmanCharacter);
            
        }

        public void InitializeDefaultGhostCharacter()
        {
            GameCharacterSet.Add(new DumbGhostCharacter(new Coordinate(1, 1), Direction.East, BoardState));
            GameCharacterSet.Add(new DumbGhostCharacter(new Coordinate(2, 2), Direction.West, BoardState));
        }
        
    }
}