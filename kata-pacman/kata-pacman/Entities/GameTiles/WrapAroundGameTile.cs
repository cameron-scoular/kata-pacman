using System.ComponentModel.Design;

namespace kata_pacman
{
    public class WrapAroundGameTile : GameTile
    {

        public WrapAroundGameTile(Coordinate position, Coordinate wrapPosition) : base(position)
        {
            WrapPosition = wrapPosition;
            Passable = true;
            RenderSymbol = '~';
        }

        // Position where character is 'teleported' to for movement wrapping across the game board
        public Coordinate WrapPosition { get; }
        
    }
}