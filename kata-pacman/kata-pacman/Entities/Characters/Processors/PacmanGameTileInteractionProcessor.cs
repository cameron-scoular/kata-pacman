namespace kata_pacman.Characters
{
    public class PacmanGameTileInteractionProcessor : IGameTileInteractionProcessor
    {
        public void InteractWithGameTile(ref GameTile gameTile, GameState gameState)
        {
            
            if (gameTile is DotGameTile) // If pacman moves onto a dot, eat it
            {
                gameTile = new EmptySpaceGameTile((DotGameTile)gameTile);
                gameState.Score++;
            }

        }
    }
}