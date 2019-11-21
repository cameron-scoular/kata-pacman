using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameState
    {
        public BoardState BoardState { get; private set; }
        
        public PacmanCharacter PlayableCharacter;
        
        public readonly HashSet<Character> GameCharacterSet = new HashSet<Character>(); // Set used to ensure no character is duplicated in the game state

        public GameState()
        {
            InitializeDefaultGameState();

            InitializeDefaultPlayableCharacter();
        }

        public void InitializeDefaultGameState()
        {
            BoardState = new BoardState();
        }

        public void InitializeDefaultPlayableCharacter()
        {
            
            PlayableCharacter = new PacmanCharacter(BoardState.PlayerSpawnPosition, Direction.East, BoardState);
            GameCharacterSet.Add(PlayableCharacter);
            
        }
        
    }
}