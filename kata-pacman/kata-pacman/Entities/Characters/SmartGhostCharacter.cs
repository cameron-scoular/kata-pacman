
using System;

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
            var playerPosition = GameState.PacmanCharacter.Position;

            var xDiff = playerPosition.XPos - Position.XPos;
            var yDiff = playerPosition.YPos - Position.YPos;

            var possibleXDirection = Direction.North;
            var possibleYDirection = Direction.East;

            var random = new Random();

            if (xDiff > 0)
            {
                possibleXDirection = Direction.South;
            }else if (xDiff < 0)
            {
                possibleXDirection = Direction.North;
            }else if (yDiff > 0)
            {
                possibleYDirection = Direction.East;
            }
            else
            {
                possibleYDirection = Direction.West;
            }

            if (yDiff == 0)
            {
                Direction = possibleXDirection;
            }else if (xDiff == 0)
            {
                Direction = possibleYDirection;
            }else if (random.NextDouble() < 0.5)
            {
                Direction = possibleXDirection;
            }
            else
            {
                Direction = possibleYDirection;
            }

        }

    }
}