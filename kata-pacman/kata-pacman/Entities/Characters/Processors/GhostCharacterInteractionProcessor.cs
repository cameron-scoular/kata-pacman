namespace kata_pacman.Characters
{
    public class GhostCharacterInteractionProcessor : ICharacterInteractionProcessor
    {
        public void InteractWithAdjacentCharacter(ICharacter adjacentCharacter, GameProcessor gameProcessor)
        {
            if (adjacentCharacter is PacmanCharacter)
            {
                gameProcessor.LoseGame();
            }        
        }

    }
}