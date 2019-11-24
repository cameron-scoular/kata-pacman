using System.Collections.Generic;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class DotGameTile : IGameTile
    {

        public DotGameTile(Coordinate position)
        {
            Passable = true;
            RenderSymbol = '.';
            Position = position;
        }

        public Coordinate Position { get; set; }
        public char RenderSymbol { get; set; }
        public bool Passable { get; set; }
        public ICharacter CharacterOnGameTile { get; set; }
    }
}