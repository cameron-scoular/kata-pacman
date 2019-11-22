using System;
using System.Collections.Generic;

namespace kata_pacman
{
    public class WallGameTile : GameTile
    {

        public WallGameTile(Coordinate position) : base(position)
        {
            Position = position;
            Passable = false;
            RenderSymbol = '@';
        }
        
    }
}