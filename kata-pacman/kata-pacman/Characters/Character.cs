using System.Drawing;

namespace kata_pacman.Characters
{
    public abstract class Character : Entity
    {
        public Character(Coordinate spawnPosition, Direction spawnDirection)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
        }
        
        public bool Alive { get; set; }
        
        public Direction Direction { get; set; }

    }
}