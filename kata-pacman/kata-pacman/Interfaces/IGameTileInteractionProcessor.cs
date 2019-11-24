namespace kata_pacman.Characters
{
    public interface IGameTileInteractionProcessor
    {
        void InteractGameTile(ref IGameTile gameTile, GameState gameState);
    }
}