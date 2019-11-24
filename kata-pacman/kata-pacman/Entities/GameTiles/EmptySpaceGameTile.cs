using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class EmptySpaceGameTile : IGameTile
    {
        
        public Coordinate Position { get; set; }
        public char RenderSymbol { get; set; }
        public bool Passable { get; set; }
        public ICharacter CharacterOnGameTile { get; set; }
        
        public EmptySpaceGameTile(Coordinate position) 
        {
            SetupEmptySpaceFields(position);
        }

        public EmptySpaceGameTile(DotGameTile dotGameTile) 
        {
            SetupEmptySpaceFields(dotGameTile.Position);
            CharacterOnGameTile = dotGameTile.CharacterOnGameTile;
        }

        public void SetupEmptySpaceFields(Coordinate position)
        {
            Passable = true;
            RenderSymbol = ' ';
            Position = position;
            Passable = true;
        }

        
    }
}