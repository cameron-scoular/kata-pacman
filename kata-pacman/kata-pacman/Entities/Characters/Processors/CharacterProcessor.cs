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

            // If there is a character on the adjacentGameObject handle it, otherwise can just check moving onto it
            if (adjacentCharacter != null)
            {
                CharacterInteractionProcessor.InteractWithAdjacentCharacter(adjacentCharacter, GameProcessor);
            }
            else
            {
                ProcessCharacterMovement(character, adjacentGameTile);
            }
            
            GameTileInteractionProcessor.InteractWithGameTile(ref GameState.BoardState.GetGameTile(character.Position), GameState);

        }
        
        public void ProcessCharacterMovement(ICharacter character, GameTile adjacentGameTile){
            
 
            if (adjacentGameTile.Passable) // If GameObject is passable, can move character onto it
            {
                var originalPosition = character.Position;

                // Updating character position and board character reference whether object has WrapAround behaviour or not
                if (adjacentGameTile is WrapAroundGameTile)
                {
                    character.Position = ((WrapAroundGameTile) adjacentGameTile).WrapPosition;

                    var wrapGameObject = GameState.BoardState.GetGameTile(
                        ((WrapAroundGameTile) adjacentGameTile)
                        .WrapPosition);

                    wrapGameObject.CharacterOnGameTile = character;

                    // Updating adjacentGameObject immediately for DotGameObject check 
                    adjacentGameTile = wrapGameObject;
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