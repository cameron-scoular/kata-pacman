
using System;
using System.Linq;

namespace kata_pacman.Characters
{
    public class SmartGhostCharacter : IAiCharacter
    {
        
        public ICharacterProcessor CharacterProcessor { get;}
        public GameState GameState { get; }
        public Coordinate Position { get; set; }
        public Direction Direction { get; set; }
        public char RenderSymbol { get; set; }
        
        public SmartGhostCharacter(Coordinate spawnPosition, Direction spawnDirection, ICharacterProcessor characterProcessor, GameState gameState)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'S';
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

            var adjacentTileDictionary = CharacterProcessor.GetValidTileMoves(Position);
            
            var playerPosition = GameState.PacmanCharacter.Position;

            var xDiff = playerPosition.XPos - Position.XPos;
            var yDiff = playerPosition.YPos - Position.YPos;

            

            if (xDiff > 0 && adjacentTileDictionary.ContainsKey(Direction.South))
            {
                Direction = Direction.South;
            }else if (xDiff < 0 && adjacentTileDictionary.ContainsKey(Direction.North))
            {
                Direction = Direction.North;
            }else if (yDiff > 0 && adjacentTileDictionary.ContainsKey(Direction.East))
            {
                Direction = Direction.East;
            }
            else if (yDiff < 0 && adjacentTileDictionary.ContainsKey(Direction.West))
            {
                Direction = Direction.West;
            }
            

        }

    }
}