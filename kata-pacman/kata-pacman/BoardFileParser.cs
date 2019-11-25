using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.FileIO;

namespace kata_pacman
{
    public class BoardFileParser
    {

        private int maxI;
        private int maxJ;

        public IGameTile[,] ParseBoardCsvFile(string filepath)
        {
            
            var parsedValues = new List<List<string>>();

            using (TextFieldParser parser = new TextFieldParser(filepath))
            {

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                
                while (!parser.EndOfData)
                {

                    var rowList = new List<string>();
                    var rowValues = parser.ReadFields();

                    foreach (var value in rowValues)
                    {
                        rowList.Add(value);
                    }
                    
                    parsedValues.Add(rowList);
                }
            }

            var board = new IGameTile[parsedValues.Count, parsedValues[1].Count];
            maxI = parsedValues.Count;
            maxJ = parsedValues[0].Count;

            for (var i = 0; i < parsedValues.Count; i++)
            {
                for(var j = 0; j < parsedValues[0].Count; j++)
                {
                    board[i, j] = ParseGameTileValue(char.Parse(parsedValues[i][j]), i, j);
                }
            }

            return board;
        }

        public IGameTile ParseGameTileValue(char value, int i, int j)
        {
            switch (value)
            {
                case '_':
                    return new EmptySpaceGameTile(new Coordinate(i, j));
                case '@':
                    return new WallGameTile(new Coordinate(i, j));
                case '.':
                    return new DotGameTile(new Coordinate(i, j));
                case '~':
                    var wrapI = 0;
                    var wrapJ = 0;
                    
                    if (i == 0)
                    {
                        wrapI = maxI - 2;
                        wrapJ = j;
                    }else if (i == maxI - 1)
                    {
                        wrapI = 1;
                        wrapJ = j;
                    }

                    if (j == 0)
                    {
                        wrapI = i;
                        wrapJ = maxJ - 2;
                    }else if (j == maxJ - 1)
                    {
                        wrapI = i;
                        wrapJ = 1;
                    }
                    return new WrapAroundGameTile(new Coordinate(i, j), new Coordinate(wrapI, wrapJ));
            }
            throw new Exception();
        }
        
        
    }
}