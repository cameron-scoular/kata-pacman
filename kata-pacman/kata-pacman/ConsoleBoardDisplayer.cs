using System;
using System.Text;

namespace kata_pacman
{
    public class ConsoleBoardDisplayer
    {

        public void DisplayConsoleBoard(GameState gameState)
        {
            Console.WriteLine("Score: " + gameState.Score);
            
            var presentationBoard = ConstructPresentationBoard(gameState);

            ConsoleDisplayPresentationBoard(presentationBoard);
        }

        
        // This method constructs an array of entities from the game state for rendering (Needed since not all game entities are displayed)
        private IEntity[,] ConstructPresentationBoard(GameState gameState)
        {
            var presentationBoard = new IEntity[gameState.BoardState.Board.GetLength(0), gameState.BoardState.Board.GetLength(1)];
            
            for(var i = 0; i < gameState.BoardState.Board.GetLength(0); i++)
            {
                for (var j = 0; j < gameState.BoardState.Board.GetLength(1); j++)
                {

                    var boardGameObject = gameState.BoardState.Board[i, j];

                    if (boardGameObject.CharacterOnGameTile != null) 
                    {
                        presentationBoard[i, j] = boardGameObject.CharacterOnGameTile;
                    }
                    else 
                    {
                        presentationBoard[i, j] = boardGameObject;
                    }

                }
            }

            return presentationBoard;

        }

        private void ConsoleDisplayPresentationBoard(IEntity[,] presentationBoard)
        {

            for (var i = 0; i < presentationBoard.GetLength(0); i++)
            {
                
                StringBuilder stringBuilderRow = new StringBuilder();
                
                for (var j = 0; j < presentationBoard.GetLength(1); j++)
                {
                    stringBuilderRow.Append(' ');
                    stringBuilderRow.Append(presentationBoard[i, j].RenderSymbol);

                }
                
                Console.WriteLine(stringBuilderRow);
            }

        }
        
        
    }
}