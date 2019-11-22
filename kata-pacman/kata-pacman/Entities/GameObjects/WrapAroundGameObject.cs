using System.ComponentModel.Design;

namespace kata_pacman
{
    public class WrapAroundGameObject : BoardGameObject
    {

        public WrapAroundGameObject(Coordinate position, Coordinate wrapPosition) : base(position)
        {
            WrapPosition = wrapPosition;
            Passable = true;
            RenderSymbol = '~';
        }

        // Position where character is 'teleported' to for movement wrapping across the game board
        public Coordinate WrapPosition { get; }
        
    }
}