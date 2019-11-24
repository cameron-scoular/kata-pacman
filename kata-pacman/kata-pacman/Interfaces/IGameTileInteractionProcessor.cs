namespace kata_pacman.Characters
{
    public interface IGameTileInteractionProcessor
    {
        void InteractWithGameTile(ref IGameTile gameTile, GameState gameState);
    }
}