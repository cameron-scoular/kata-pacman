namespace kata_pacman.Characters
{
    public class PacmanGameTileInteractionProcessor : IGameTileInteractionProcessor
    {
        public void InteractWithGameTile(ref IGameTile gameTile, GameState gameState)
        {
            
            if (gameTile is DotGameTile)
            {
                gameTile = new EmptySpaceGameTile((DotGameTile)gameTile);
                gameState.Score++;
            }

        }
    }
}