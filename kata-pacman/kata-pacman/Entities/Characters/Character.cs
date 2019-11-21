using System;
using System.Drawing;

namespace kata_pacman.Characters
{
    public abstract class Character : Entity
    {

        public BoardState BoardState;
        
        public Character(Coordinate spawnPosition, Direction spawnDirection, BoardState boardState)
        {
            Alive = true;
            Position = spawnPosition;
            Direction = spawnDirection;
            BoardState = boardState;
            BoardState.Board[spawnPosition.XPos, spawnPosition.YPos].CharacterOnGameObject = this;
        }
        
        public bool Alive { get; set; }
        
        public Direction Direction { get; set; }
        
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