using System.Collections.Generic;

namespace kata_pacman.Characters
{
    public class PacmanCharacter : Character
    {

        public PacmanCharacter(Coordinate spawnPosition, Direction spawnDirection) : base(spawnPosition, spawnDirection)
        {
            Position = spawnPosition;
            Direction = Direction;

            switch (spawnDirection)
            {
                case Direction.North:
                    RenderSymbol = '^';
                    break;
                case Direction.East:
                    RenderSymbol = '>';
                    break;
                case Direction.South:
                    RenderSymbol = 'v';
                    break;
                case Direction.West:
                    RenderSymbol = '<';
                    break;
            }
        }
        
    }
}