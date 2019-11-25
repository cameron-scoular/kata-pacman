using System;
using System.Collections.Generic;
using System.Linq;


namespace kata_pacman.Characters
{
    public class DumbGhostCharacter : IAiCharacter
    {

        public ICharacterProcessor CharacterProcessor { get; set; }
        public GameState GameState { get; }
        public Coordinate Position { get; set; }
        public Direction Direction { get; set; }
        public Direction PreviousDirection { get; set; }
        public char RenderSymbol { get; set; }
        
        public DumbGhostCharacter(Coordinate spawnPosition, Direction spawnDirection, ICharacterProcessor characterProcessor, GameState gameState)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'G';
            CharacterProcessor = characterProcessor;
            GameState = gameState;
        }

        public void ProcessCharacter()
        {
            ExecuteAiBehaviour();
            CharacterProcessor.ProcessCharacter(this);
        }

        public void ExecuteAiBehaviour()
        {

            var validAdjacentTileMoveDictionary = CharacterProcessor.GetValidTileMoves(Position);
            
            var random = new Random();

            if (!validAdjacentTileMoveDictionary.ContainsKey(Direction) || validAdjacentTileMoveDictionary.Count > 2 )
            {
                Direction = validAdjacentTileMoveDictionary.ElementAt(random.Next(0, validAdjacentTileMoveDictionary.Count)).Key;
            }
            
        }
        
    }
}