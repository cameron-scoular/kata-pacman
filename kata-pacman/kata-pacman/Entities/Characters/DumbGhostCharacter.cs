using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_pacman.Characters
{
    public class DumbGhostCharacter : IAiCharacter
    {

        public ICharacterProcessor CharacterProcessor { get; set; }
        public Coordinate Position { get; set; }
        public Direction Direction { get; set; }
        public char RenderSymbol { get; set; }
        
        public DumbGhostCharacter(Coordinate spawnPosition, Direction spawnDirection, ICharacterProcessor characterProcessor)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'G';
            CharacterProcessor = characterProcessor;
        }

        public void ProcessCharacter()
        {
            ExecuteAiBehaviour();
            CharacterProcessor.ProcessCharacter(this);
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
        
    }
}