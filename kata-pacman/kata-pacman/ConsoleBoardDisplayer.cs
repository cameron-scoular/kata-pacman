using System;
using System.Text;

namespace kata_pacman
{
    public class ConsoleBoardDisplayer
    {

        public void DisplayConsoleBoard(GameState gameState)
        {
            var presentationBoard = ConstructPresentationBoard(gameState);

            ConsoleRenderPresentationBoard(presentationBoard);
        }

        
        // This method constructs an array of entities from the game state for rendering
        private Entity[,] ConstructPresentationBoard(GameState gameState)
        {
            var presentationBoard = new Entity[gameState.BoardState.Board.GetLength(0), gameState.BoardState.Board.GetLength(1)];
            
            for(var i = 0; i < gameState.BoardState.Board.GetLength(0); i++)
            {
                for (var j = 0; j < gameState.BoardState.Board.GetLength(1); j++)
                {

                    var boardGameObject = gameState.BoardState.Board[i, j];

                    if (boardGameObject.CharacterOnGameObject != null) // If there is a character on this coordinate, place the character in the presentation board for rendering
                    {
                        presentationBoard[i, j] = boardGameObject.CharacterOnGameObject;
                    }
                    else // Otherwise only need to render the BoardGameObject underneath
                    {
                        presentationBoard[i, j] = boardGameObject;
                    }

                }
            }

            return presentationBoard;

        }

        private void ConsoleRenderPresentationBoard(Entity[,] presentationBoard)
        {

            for (var i = 0; i < presentationBoard.GetLength(0); i++)
            {
                
                StringBuilder stringBuilderRow = new StringBuilder();
                
                for (var j = 0; j < presentationBoard.GetLength(1); j++)
                {
                    stringBuilderRow.Append('\t');
                    stringBuilderRow.Append(presentationBoard[i, j].RenderSymbol);

                }
                
                Console.WriteLine(stringBuilderRow);
            }

        }
        
        
    }
}