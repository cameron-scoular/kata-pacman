using System.Collections.Generic;

namespace kata_pacman.Characters
{
    public class GhostCharacter : Character
    {

        public GhostCharacter(Coordinate spawnPosition, Direction spawnDirection, BoardState boardState) : base(spawnPosition, spawnDirection, boardState)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'G';
        }
        
    }
}