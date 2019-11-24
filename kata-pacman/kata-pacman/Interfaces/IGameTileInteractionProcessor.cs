namespace kata_pacman.Characters
{
    public interface IGameTileInteractionProcessor
    {
        void InteractWithGameTile(ref GameTile gameTile, GameState gameState);
    }
}