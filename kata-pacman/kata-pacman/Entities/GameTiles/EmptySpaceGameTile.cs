using System.Collections.Generic;

namespace kata_pacman
{
    public class EmptySpaceGameTile : GameTile
    {
        public EmptySpaceGameTile(Coordinate position) : base(position)
        {
            SetupEmptySpaceFields();
        }

        public EmptySpaceGameTile(DotGameTile dotGameTile) : base(dotGameTile.Position)
        {
            SetupEmptySpaceFields();
            CharacterOnGameTile = dotGameTile.CharacterOnGameTile;
        }

        public void SetupEmptySpaceFields()
        {
            Passable = true;
            RenderSymbol = ' ';
        }
        
    }
}