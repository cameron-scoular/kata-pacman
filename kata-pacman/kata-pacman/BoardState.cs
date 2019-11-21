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
                
                Board[i, 0] = new WallGameObject(new Coordinate(i, 0));
                Board[i, 9] = new WallGameObject(new Coordinate(i, 9));

                Board[0, i] = new WallGameObject(new Coordinate(0, i));
                Board[9, i] = new WallGameObject(new Coordinate(9, i));

            }

            for (var i = 1; i < 9; i++)
            {
                for (var j = 1; j < 9; j++)
                {
                    Board[i, j] = new DotGameObject(new Coordinate(i, j));
                }
            }
            
            PlayerSpawnPosition = new Coordinate(1, 1);

            
        }
        
    }
}