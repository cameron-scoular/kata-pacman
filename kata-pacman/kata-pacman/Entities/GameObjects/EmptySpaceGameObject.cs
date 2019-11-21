using System.Collections.Generic;

namespace kata_pacman
{
    public class EmptySpaceGameObject : BoardGameObject
    {
        public EmptySpaceGameObject(Coordinate position) : base(position)
        {
            Position = position;
            Passable = true;
            RenderSymbol = ' ';
        }
    }
}