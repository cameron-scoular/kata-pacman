using System;
using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class WallGameTile : IGameTile
    {
        
        public Coordinate Position { get; set; }
        public char RenderSymbol { get; set; }
        public bool Passable { get; set; }
        public ICharacter CharacterOnGameTile { get; set; }

        public WallGameTile(Coordinate position)
        {
            Position = position;
            Passable = false;
            RenderSymbol = '@';
        }

        
    }
}