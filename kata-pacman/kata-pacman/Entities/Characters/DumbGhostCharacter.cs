using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_pacman.Characters
{
    public class DumbGhostCharacter : Character, IAiCharacter
    {

        public DumbGhostCharacter(Coordinate spawnPosition, Direction spawnDirection, BoardState boardState) : base(spawnPosition, spawnDirection, boardState)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'G';
        }

      
        public override void ProcessCharacter(GameState gameState, GameProcessor gameProcessor)
        {

            ExecuteAiBehaviour();

            ProcessCharacterMovement(gameState, gameProcessor);
            
        }
        
        public void ExecuteAiBehaviour()
        {
            var random = new Random();

            if (random.NextDouble() < 0.3)
            {
                if (random.NextDouble() < 0.25)
                {
                    Direction = Direction.North;
                }
                else if (random.NextDouble() < 0.5)
                {
                    Direction = Direction.East;
                }
                else if (random.NextDouble() < 0.75)
                {
                    Direction = Direction.South;
                }
                else
                {
                    Direction = Direction.West;
                }

            }

        }


        
        public override void InteractWithAdjacentCharacter(Character adjacentCharacter, GameProcessor gameProcessor)
        {
            if (adjacentCharacter is PacmanCharacter)
            {
                gameProcessor.LoseGame();
            }        
        }

        public override void InteractWithGameTile(GameTile gameTile, GameState gameState)
        {
            // Currently ghost does not interact with their game tile
        }
    }
}