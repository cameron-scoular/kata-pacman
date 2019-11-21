using System.Collections.Generic;

namespace kata_pacman
{
    public class EmptySpaceGameObject : BoardGameObject
    {
        public EmptySpaceGameObject(Coordinate position) : base(position)
        {
            SetupEmptySpaceFields();
        }

        public EmptySpaceGameObject(DotGameObject dotGameObject) : base(dotGameObject.Position)
        {
            SetupEmptySpaceFields();
            CharacterOnGameObject = dotGameObject.CharacterOnGameObject;
        }

        public void SetupEmptySpaceFields()
        {
            Passable = true;
            RenderSymbol = ' ';
        }
        
    }
}