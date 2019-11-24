namespace kata_pacman.Characters
{
    public interface ICharacter : IEntity
    {
        ICharacterProcessor CharacterProcessor
        {
            get;
            set;
        }

        void ProcessCharacter();

        Direction Direction { get; set; }
            
    }
}