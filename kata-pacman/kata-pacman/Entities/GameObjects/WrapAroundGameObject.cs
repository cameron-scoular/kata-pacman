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

        public Coordinate WrapPosition { get; }
        
    }
}