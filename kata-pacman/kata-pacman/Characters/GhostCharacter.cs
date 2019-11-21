using System.Collections.Generic;

namespace kata_pacman.Characters
{
    public class GhostCharacter : Character
    {

        public GhostCharacter(Coordinate spawnPosition, Direction spawnDirection) : base(spawnPosition, spawnDirection)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'G';
        }
        
    }
}