namespace kata_pacman.Characters
{
    public class GhostGameTileInteractionProcessor : IGameTileInteractionProcessor
    {
        public void InteractWithGameTile(ref IGameTile gameTile, GameState gameState)
        {
            // Do nothing since the ghost does not currently interact with any tile
        }
    }
}