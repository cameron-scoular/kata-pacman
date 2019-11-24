namespace kata_pacman.Characters
{
    public interface ICharacter : IEntity
    {
        ICharacterProcessor CharacterProcessor
        {
            get;
        }

        void ProcessCharacter();

        Direction Direction { get; set; }
            
    }
}