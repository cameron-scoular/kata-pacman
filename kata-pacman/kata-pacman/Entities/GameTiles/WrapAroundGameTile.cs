using System.ComponentModel.Design;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class WrapAroundGameTile : IGameTile
    {
        
        public Coordinate WrapPosition { get; }
        public Coordinate Position { get; set; }
        public char RenderSymbol { get; set; }
        public bool Passable { get; set; }
        public ICharacter CharacterOnGameTile { get; set; }

        public WrapAroundGameTile(Coordinate position, Coordinate wrapPosition)
        {
            WrapPosition = wrapPosition;
            Passable = true;
            RenderSymbol = '~';
            Position = position;
        }

   
    }
}