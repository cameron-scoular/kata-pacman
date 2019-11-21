namespace kata_pacman
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            XPos = x;
            YPos = y;
        }
        
        public int XPos { get; }

        public int YPos { get; }
    }
}