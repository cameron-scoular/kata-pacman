using System.Collections.Generic;

namespace kata_pacman
{
    public abstract class Entity
    {
        public Coordinate Position { get; set; }

        public char RenderSymbol { get; set; }
    }
}