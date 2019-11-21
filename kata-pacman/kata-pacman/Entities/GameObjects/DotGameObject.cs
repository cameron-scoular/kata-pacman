using System.Collections.Generic;

namespace kata_pacman
{
    public class DotGameObject : BoardGameObject
    {

        public DotGameObject(Coordinate position) : base(position)
        {
            Passable = true;
            RenderSymbol = '.';

        }
        
    }
}