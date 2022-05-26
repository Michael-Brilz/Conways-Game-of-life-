using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PWS40.Backend.Conways.Model;

namespace PWS40.Backend.Conways
{
    public static class GameFieldParser
    {
        public static bool TryParseGameField(string gameFieldAsString, out GameField gameField, bool optimized = false)
        {
            if(optimized)
            {
                return TryParseGameFieldOptimized(gameFieldAsString, out gameField);
            }
            else
            {
                return TryParseGameFieldObsolete(gameFieldAsString, out gameField);
            }
        }

        private static bool TryParseGameFieldObsolete(string gameFieldAsString, out GameField gameField)
        {
            gameField = null;

            var tempCellRows = new List<List<Cell>>();

            try
            {
                var cells = new List<Cell>();
                for (int i = 0; i < gameFieldAsString.Length; i++)
                {
                    if (gameFieldAsString[i] == ';')
                    {
                        tempCellRows.Add(cells);
                        cells = new List<Cell>();
                    }
                    else
                    {
                        cells.Add(new Cell() { IsAlive = gameFieldAsString[i] == '1' });
                    }
                }
                gameField = new GameField(tempCellRows);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool TryParseGameFieldOptimized(string gameFieldAsString, out GameField gameField)
        {
            try
            {
                var gameFieldModel = JsonSerializer.Deserialize<GameFieldModel>(gameFieldAsString);
                gameField = new GameField(gameFieldModel);
                return true;
            }
            catch (Exception e)
            {
                gameField = null;
                return false;
            }
        }
    }
}
