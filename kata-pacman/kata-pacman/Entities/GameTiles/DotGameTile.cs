using System.Collections.Generic;

namespace kata_pacman
{
    public class DotGameTile : GameTile
    {

        public DotGameTile(Coordinate position) : base(position)
        {
            Passable = true;
            RenderSymbol = '.';

        }
        
    }
}