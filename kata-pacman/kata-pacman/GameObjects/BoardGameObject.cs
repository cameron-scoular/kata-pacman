using kata_pacman.Characters;

namespace kata_pacman
{
    public abstract class BoardGameObject : Entity
    {
        public BoardGameObject(Coordinate position)
        {
            Position = position;
            CharacterOnGameObject = null;
        }
        
        public bool Passable;
        public Character CharacterOnGameObject { get; set; }

    }
}