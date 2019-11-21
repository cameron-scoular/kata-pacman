using System;
using System.Collections.Generic;

namespace kata_pacman
{
    public class WallGameObject : BoardGameObject
    {

        public WallGameObject(Coordinate position) : base(position)
        {
            Position = position;
            Passable = false;
            RenderSymbol = '@';
        }
        
    }
}