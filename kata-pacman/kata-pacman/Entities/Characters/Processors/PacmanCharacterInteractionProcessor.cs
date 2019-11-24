namespace kata_pacman.Characters
{
    public class PacmanCharacterInteractionProcessor : ICharacterInteractionProcessor
    {
        public void InteractWithAdjacentCharacter(ICharacter adjacentCharacter, GameProcessor gameProcessor)
        {
            if (adjacentCharacter is DumbGhostCharacter)
            {
                gameProcessor.LoseGame();
            }        
        }
    }
}