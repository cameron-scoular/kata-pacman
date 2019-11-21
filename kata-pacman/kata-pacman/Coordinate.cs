namespace kata_pacman
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            XPos = x;
            YPos = y;
        }
        
        int XPos { get; set; }
        
        int YPos { get; set; }
    }
}