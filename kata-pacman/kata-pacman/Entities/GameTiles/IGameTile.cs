using kata_pacman.Characters;

namespace kata_pacman
{
    public interface IGameTile : IEntity
    {
        bool Passable { get; set; }
        ICharacter CharacterOnGameTile { get; set; }

    }
}