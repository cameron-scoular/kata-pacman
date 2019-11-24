namespace kata_pacman.Characters
{
    public interface ICharacterInteractionProcessor
    {
        void InteractWithAdjacentCharacter(ICharacter character, GameProcessor processor);
    }
}