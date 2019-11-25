using System;
using System.Collections.Generic;
using System.Linq;


namespace kata_pacman.Characters
{
    public class DumbGhostCharacter : IAiCharacter
    {

        public ICharacterProcessor CharacterProcessor { get; set; }
        public GameState GameState { get; }
        public Coordinate Position { get; set; }
        public Direction Direction { get; set; }
        public char RenderSymbol { get; set; }
        
        public DumbGhostCharacter(Coordinate spawnPosition, Direction spawnDirection, ICharacterProcessor characterProcessor, GameState gameState)
        {
            Position = spawnPosition;
            Direction = spawnDirection;
            RenderSymbol = 'G';
            CharacterProcessor = characterProcessor;
            GameState = gameState;
        }

        public void ProcessCharacter()
        {
            ExecuteAiBehaviour();
            CharacterProcessor.ProcessCharacter(this);
        }

        public void ExecuteAiBehaviour()
        {
            
            var adjacentTileDictionary = new Dictionary<Direction, IGameTile>();
            adjacentTileDictionary.Add(Direction.North, GameState.BoardState.GetAdjacentGameTile(Position, Direction.North));
            adjacentTileDictionary.Add(Direction.East, GameState.BoardState.GetAdjacentGameTile(Position, Direction.East));
            adjacentTileDictionary.Add(Direction.South, GameState.BoardState.GetAdjacentGameTile(Position, Direction.South));
            adjacentTileDictionary.Add(Direction.West, GameState.BoardState.GetAdjacentGameTile(Position, Direction.West));

            foreach (var (direction, gameTile) in adjacentTileDictionary)
            {
                if (gameTile.Passable == false)
                {
                    adjacentTileDictionary.Remove(direction);
                }
            }
            
            var random = new Random();

            Direction = adjacentTileDictionary.ElementAt(random.Next(0, adjacentTileDictionary.Count)).Key;

        }
        
    }
}