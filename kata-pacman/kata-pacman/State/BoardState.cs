using System;

namespace kata_pacman
{
    public class BoardState
    {
        
        public BoardGameObject[,] Board { get; private set; }
        
        public Coordinate PlayerSpawnPosition { get; private set; }

        public BoardState()
        {
            InitializeDefaultBoard();
        }

        public void InitializeDefaultBoard()
        {
            Board = new BoardGameObject[10, 10];

            for (var i = 0; i < 10; i++)
            {

                Board[i, 0] = new WrapAroundGameObject(new Coordinate(i, 0), new Coordinate(i, 8));
                Board[i, 9] = new WrapAroundGameObject(new Coordinate(i, 9), new Coordinate(i, 1));

                Board[0, i] = new WrapAroundGameObject(new Coordinate(0, i), new Coordinate(8, i));
                Board[9, i] = new WrapAroundGameObject(new Coordinate(9, i), new Coordinate(1, i));

            }

            for (var i = 1; i < 9; i++)
            {
                for (var j = 1; j < 9; j++)
                {
                    Board[i, j] = new DotGameObject(new Coordinate(i, j));
                }
            }
            
            for (var i = 1; i < 9; i++)
            {
                Board[i, 0] = new WallGameObject(new Coordinate(i, 0));
                Board[i, 9] = new WallGameObject(new Coordinate(i, 9));
            }

            for (var i = 2; i < 8; i++)
            {
                Board[0, i] = new WallGameObject(new Coordinate(0, i));
                Board[9, i] = new WallGameObject(new Coordinate(9, i));
            }
            
            Board[0, 0] = new WallGameObject(new Coordinate(0, 0));
            Board[0, 9] = new WallGameObject(new Coordinate(0, 9));
            Board[9, 0] = new WallGameObject(new Coordinate(9, 0));
            Board[9, 9] = new WallGameObject(new Coordinate(9, 9));

            
            
            PlayerSpawnPosition = new Coordinate(5, 5);

            
        }

        public ref BoardGameObject GetBoardGameObjectReference(Coordinate position)
        {
            return ref Board[position.XPos, position.YPos];
        }
        
        public BoardGameObject GetAdjacentObjectFromDirection(Coordinate position, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Board[position.XPos - 1, position.YPos];
                case Direction.East:
                    return Board[position.XPos, position.YPos + 1];
                case Direction.South:
                    return Board[position.XPos + 1, position.YPos];
                case Direction.West:
                    return Board[position.XPos, position.YPos - 1];
            }

            return null;
        }
        
    }
}