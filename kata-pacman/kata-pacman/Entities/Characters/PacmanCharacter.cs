using System;
using System.Collections.Generic;

namespace kata_pacman.Characters
{
    public class PacmanCharacter : Character
    {
        
        public bool TurnAvailable { get; set; }

        public PacmanCharacter(Coordinate spawnPosition, Direction spawnDirection, BoardState boardState) : base(spawnPosition, spawnDirection, boardState)
        {
            Position = spawnPosition;
            Direction = Direction;
            RenderSymbol = GetRenderSymbolFromDirection(spawnDirection);
            
        }

        public void HandleInputTurn(ConsoleKeyInfo keyInfo, ConsoleBoardDisplayer displayer, GameState gameState)
        {
            if (TurnAvailable)
            {
                CharacterInput input;
            
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    input = CharacterInput.LeftInput;
                }
                else
                {
                    input = CharacterInput.RightInput;
                }
            
                var newDirection = GetNewDirection(input);

                var adjacentGameObject = BoardState.GetAdjacentGameTile(Position, newDirection);

                if (adjacentGameObject.Passable) // If the adjacent space is passable, then the new direction is valid
                {
                    Direction = newDirection;
                    RenderSymbol = GetRenderSymbolFromDirection(Direction);
                    TurnAvailable = false;
                    displayer.DisplayConsoleBoard(gameState);
                }
            }
        }

        public override void ProcessCharacter(GameState gameState, GameProcessor processor)
        {
            ProcessCharacterMovement(gameState, processor);
        }

        public override void InteractWithAdjacentCharacter(Character adjacentCharacter, GameProcessor gameProcessor)
        {
            if (adjacentCharacter is DumbGhostCharacter)
            {
                gameProcessor.LoseGame();
            }        
        }

        public override void InteractWithGameTile(GameTile gameTile, GameState gameState)
        {
            if (gameTile is DotGameTile) 
            {
                gameState.BoardState.GetGameTile(gameTile.Position) = new EmptySpaceGameTile((DotGameTile) gameTile);
                gameState.Score++;
            }
        }
        
        private char GetRenderSymbolFromDirection(Direction direction)
        {
            switch (direction) 
            {
                case Direction.North:
                    return 'v';
                case Direction.East:
                    return '<';
                case Direction.South:
                    return '^';
                case Direction.West:
                    return '>';
            }

            throw new Exception();
        }

        
        
    }
}