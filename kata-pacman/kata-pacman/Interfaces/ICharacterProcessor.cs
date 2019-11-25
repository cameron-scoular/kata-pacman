using System.Collections.Generic;

namespace kata_pacman.Characters
{
    public interface ICharacterProcessor
    {
        void ProcessCharacter(ICharacter character);

        Dictionary<Direction, IGameTile> GetValidTileMoves(Coordinate position);


    }
}