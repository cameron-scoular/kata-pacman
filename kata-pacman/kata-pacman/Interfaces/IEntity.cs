namespace kata_pacman
{
    public interface IEntity
    { 
        Coordinate Position { get; set; }

        char RenderSymbol { get; set; }
    }
}