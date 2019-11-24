using System;

namespace kata_pacman.Characters
{
    public class CharacterProcessor : ICharacterProcessor
    {

        public ICharacterInteractionProcessor CharacterInteractionProcessor;
        public IGameTileInteractionProcessor GameTileInteractionProcessor;
        public GameProcessor GameProcessor;
        public GameState GameState;

        public CharacterProcessor(ICharacterInteractionProcessor interactionProcessor,
            IGameTileInteractionProcessor gameTileInteractionProcessor, GameProcessor gameProcessor)
        {
            CharacterInteractionProcessor = interactionProcessor;
            GameTileInteractionProcessor = gameTileInteractionProcessor;
            GameProcessor = gameProcessor;
            GameState = gameProcessor.GameState;
        }
        
        public void ProcessCharacter(ICharacter character)
        {
            
            var adjacentGameTile =
                GameState.BoardState.GetAdjacentGameTile(character.Position, character.Direction);

            var adjacentCharacter = adjacentGameTile.CharacterOnGameTile;

            if (adjacentCharacter != null)
            {
                CharacterInteractionProcessor.InteractWithAdjacentCharacter(adjacentCharacter, GameProcessor);
            }
            else
            {
                ProcessCharacterMovement(character, adjacentGameTile);
            }

            GameTileInteractionProcessor.InteractGameTile(ref GameState.BoardState.GetGameTile(character.Position), GameState);

        }
        
        public void ProcessCharacterMovement(ICharacter character, IGameTile adjacentGameTile){
            
 
            if (adjacentGameTile.Passable)
            {
                var originalPosition = character.Position;

                if (adjacentGameTile is WrapAroundGameTile wrapAroundGameTile)
                {
                    character.Position = wrapAroundGameTile.WrapPosition;

                    var wrapGameObject = GameState.BoardState.GetGameTile(
                        wrapAroundGameTile
                        .WrapPosition);

                    wrapGameObject.CharacterOnGameTile = character;
                    
                }
                else
                {
                    character.Position = adjacentGameTile.Position;
                    adjacentGameTile.CharacterOnGameTile = character;
                }

                // Removing the old board character reference
                GameState.BoardState.GetGameTile(originalPosition).CharacterOnGameTile = null;
                

            }
            
        }
        
        
        
    }
}