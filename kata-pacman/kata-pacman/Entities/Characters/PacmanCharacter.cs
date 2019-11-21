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

        public bool HandleInputTurn(CharacterInput characterInput)
        {

            var newDirection = GetNewDirection(characterInput);

            var adjacentGameObject = BoardState.GetAdjacentObjectFromDirection(Position, newDirection);

            if (adjacentGameObject.Passable) // If the adjacent space is passable, then the new direction is valid
            {
                Direction = newDirection;
                RenderSymbol = GetRenderSymbolFromDirection(Direction);
                return true;
            }

            return false;
            
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