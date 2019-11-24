using System;
using System.Collections.Generic;

namespace kata_pacman.Characters
{
    public class PacmanCharacter : ICharacter
    {
        
        public bool TurnAvailable { get; set; }
        
        public ICharacterProcessor CharacterProcessor { get; set; }

        public Coordinate Position { get; set; }
        public Direction Direction { get; set; }
        public char RenderSymbol { get; set; }


        public PacmanCharacter(Coordinate spawnPosition, Direction spawnDirection, ICharacterProcessor characterProcessor)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = GetRenderSymbolFromDirection(spawnDirection);
            CharacterProcessor = characterProcessor;
        }

        public void ProcessCharacter()
        {
            CharacterProcessor.ProcessCharacter(this); 
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

                var adjacentGameObject = gameState.BoardState.GetAdjacentGameTile(Position, newDirection);

                if (adjacentGameObject.Passable) // If the adjacent space is passable, then the new direction is valid
                {
                    Direction = newDirection;
                    RenderSymbol = GetRenderSymbolFromDirection(Direction);
                    TurnAvailable = false;
                    displayer.DisplayConsoleBoard(gameState);
                }
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

        public Direction GetNewDirection(CharacterInput characterInput)
        {
            if (characterInput == CharacterInput.LeftInput)
            {
                switch (Direction)
                {
                    case Direction.North:
                        return Direction.West;
                    case Direction.East:
                        return Direction.North;
                    case Direction.South:
                        return Direction.East;
                    case Direction.West:
                        return Direction.South;
                }
            }
            else if (characterInput == CharacterInput.RightInput)
            {
                switch (Direction)
                {
                    case Direction.North:
                        return Direction.East;
                    case Direction.East:
                        return Direction.South;
                    case Direction.South:
                        return Direction.West;
                    case Direction.West:
                        return Direction.North;
                }
            }
            
            throw new Exception();
        }

    }
}