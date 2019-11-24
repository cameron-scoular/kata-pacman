using kata_pacman.Characters;

namespace kata_pacman
{
    public abstract class GameTile : IEntity
    {
        
        public Coordinate Position { get; set; }
        public char RenderSymbol { get; set; }
        public bool Passable;
        public ICharacter CharacterOnGameTile { get; set; }
        
        public GameTile(Coordinate position)
        {
            Position = position;
            CharacterOnGameTile = null;
        }

    }
}