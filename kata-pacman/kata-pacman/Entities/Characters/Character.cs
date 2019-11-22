using System;
using System.Drawing;

namespace kata_pacman.Characters
{
    public abstract class Character : IEntity
    {
        
        public Coordinate Position { get; set; }
        public char RenderSymbol { get; set; }
        
        public readonly BoardState BoardState;

        public abstract void ProcessCharacter(GameState gameState, GameProcessor processor);
        public abstract void InteractWithAdjacentCharacter(Character character, GameProcessor processor);
        public abstract void InteractWithGameTile(GameTile gameTile, GameState gameState);
        
        public Character(Coordinate spawnPosition, Direction spawnDirection, BoardState boardState)
        {
            Alive = true;
            Position = spawnPosition;
            Direction = spawnDirection;
            BoardState = boardState;
            BoardState.Board[spawnPosition.XPos, spawnPosition.YPos].CharacterOnGameTile = this;
        }
        
        public bool Alive { get; set; }
        
        public Direction Direction { get; set; }

        public void ProcessCharacterMovement(GameState gameState, GameProcessor gameProcessor)
        {
            var adjacentGameObject =
                gameState.BoardState.GetAdjacentGameTile(Position, Direction);

            var adjacentCharacter = adjacentGameObject.CharacterOnGameTile;

            // If there is a character on the adjacentGameObject handle it, otherwise can just check moving onto it
            if (adjacentCharacter != null)
            {
                InteractWithAdjacentCharacter(adjacentCharacter, gameProcessor);
            }
            else
            {
                if (adjacentGameObject.Passable) // If GameObject is passable, can move character onto it
                {
                    adjacentGameObject = MoveCharacter(adjacentGameObject, gameState.BoardState);
                    InteractWithGameTile(adjacentGameObject, gameState);

                }
            }
        }
        
        public GameTile MoveCharacter(GameTile adjacentGameTile, BoardState boardState)
        {
            
            var originalPosition = Position;

            // Updating character position and board character reference whether object has WrapAround behaviour or not
            if (adjacentGameTile is WrapAroundGameTile)
            {
                Position = ((WrapAroundGameTile) adjacentGameTile).WrapPosition;

                var wrapGameObject = boardState.GetGameTile(
                    ((WrapAroundGameTile) adjacentGameTile)
                    .WrapPosition);

                wrapGameObject.CharacterOnGameTile = this;

                // Updating adjacentGameObject immediately for DotGameObject check 
                adjacentGameTile = wrapGameObject;
            }
            else
            {
                Position = adjacentGameTile.Position;
                adjacentGameTile.CharacterOnGameTile = this;
            }

            // Removing the old board character reference
            boardState.GetGameTile(originalPosition).CharacterOnGameTile = null;
            return adjacentGameTile;
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