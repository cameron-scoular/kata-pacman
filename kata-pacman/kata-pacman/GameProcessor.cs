using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using kata_pacman.Characters;

namespace kata_pacman
{
    public class GameProcessor
    {

        private GameState GameState;
        private ConsoleBoardDisplayer ConsoleBoardDisplayer;
        private GameInputThreadProcessor GameInputThreadProcessor;

        public int TickPeriod { get; set; }
        

        public GameProcessor(ConsoleBoardDisplayer consoleBoardDisplayer, GameInputThreadProcessor gameInputThreadProcessor, int tickPeriod)
        {
            ConsoleBoardDisplayer = consoleBoardDisplayer;
            GameInputThreadProcessor = gameInputThreadProcessor;
            
            InitializeNewGame(tickPeriod);
            
        }
        
        public void InitializeNewGame(int tickPeriod)
        {
            GameState = new GameState();
            TickPeriod = tickPeriod;
        }

        public void RunGame()
        {

            while (GameState.GameInProgress)
            {
                var latestInputKey = GameInputThreadProcessor.LatestCharacterInput;
                if (latestInputKey != null)
                {
                    GameState.PlayableCharacter.HandleInputTurn((CharacterInput) latestInputKey);

                }

                RandomlyTurnGhosts();
                    
                ProcessCharacterMovement();
                
            }
            
        }

       
        
        public void ProcessCharacterMovement()
        {
            foreach (var character in GameState.GameCharacterSet)
            {

                var originalPosition = character.Position;

                var adjacentGameObject = GameState.BoardState.GetAdjacentObjectFromDirection(originalPosition, character.Direction);

                var adjacentCharacter = adjacentGameObject.CharacterOnGameObject;

                // If there is a character on the adjacentGameObject handle it, otherwise can just check moving onto it
                if (adjacentCharacter != null) 
                {
                    // Collision between pacman and ghost
                    if ((character is GhostCharacter && adjacentCharacter is PacmanCharacter) ||
                        (character is PacmanCharacter && adjacentCharacter is GhostCharacter))
                    {
                        LoseGame();
                        break;
                    }
                }
                else
                {
                    if (adjacentGameObject.Passable) // If GameObject is passable, can move character onto it
                    {

                        // Updating character position and board character reference whether object has WrapAround behaviour or not
                        if (adjacentGameObject is WrapAroundGameObject)
                        {
                            character.Position = ((WrapAroundGameObject) adjacentGameObject).WrapPosition;

                            var wrapGameObject = GameState.BoardState.GetBoardGameObjectReference(
                                ((WrapAroundGameObject) adjacentGameObject)
                                .WrapPosition);

                            wrapGameObject.CharacterOnGameObject = character;

                            // Updating adjacentGameObject immediately for DotGameObject check 
                            adjacentGameObject = wrapGameObject;

                        }
                        else
                        {
                            character.Position = adjacentGameObject.Position;
                            adjacentGameObject.CharacterOnGameObject = character;
                        }

                        // Removing the old board character reference
                        GameState.BoardState.GetBoardGameObjectReference(originalPosition).CharacterOnGameObject = null;

                        if (adjacentGameObject is DotGameObject && character is PacmanCharacter
                        ) // If pacman moves onto a dot, eat it
                        {
                            GameState.BoardState.GetBoardGameObjectReference(adjacentGameObject.Position) =
                                new EmptySpaceGameObject((DotGameObject) adjacentGameObject);
                            GameState.Score++;
                        }

                    }
                }

                ConsoleBoardDisplayer.DisplayConsoleBoard(GameState);
                Thread.Sleep(TickPeriod/GameState.GameCharacterSet.Count); // Wait for tick period, with tick waiting period being allocated equally amongst characters
                
            }
        }

        public void RandomlyTurnGhosts()
        {
            
            var random = new Random();
            var ghosts = GameState.GameCharacterSet.Where(x => x is GhostCharacter);
            foreach (var ghost in ghosts)
            {
                if (random.NextDouble() < 0.3)
                {
                    if (random.NextDouble() < 0.25)
                    {
                        ghost.Direction = Direction.North;
                    }else if (random.NextDouble() < 0.5)
                    {
                        ghost.Direction = Direction.East;
                    }else if (random.NextDouble() < 0.75)
                    {
                        ghost.Direction = Direction.South;
                    }
                    else
                    {
                        ghost.Direction = Direction.West;
                    }
                    
                }
                
            }
        }

        public void LoseGame()
        {
            Console.WriteLine("Game Over!");
            GameState.GameInProgress = false;
        }

    }
}