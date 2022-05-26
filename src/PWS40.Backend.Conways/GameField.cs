using System.Text;
using System.Text.Json;
using PWS40.Backend.Conways.Model;

namespace PWS40.Backend.Conways
{
    public class GameField
    {
        public Cell[,] Cells;

        public GameField(int rows, int columns)
        {
            InstantiateGameField(rows, columns);
        }

        public GameField(IEnumerable<IEnumerable<Cell>> cellCollection)
        {
            InstantiateGameField(cellCollection);
        }

        public GameField(GameFieldModel gameFieldModel)
        {
            InstantiateGameField(gameFieldModel);
        }

        private void InstantiateGameField(GameFieldModel gameFieldModel)
        {
            Cells = new Cell[gameFieldModel.Row, gameFieldModel.Column];

            for (int row = 0; row < Cells.GetLength(0); row++)
            {
                for (int column = 0; column < Cells.GetLength(1); column++)
                {
                    if (gameFieldModel.AliveCells.Any(cell => cell.Column == column && row == cell.Row))
                    {
                        Cells[row, column] = new Cell() { IsAlive = true };
                    }
                    else
                    {
                        Cells[row, column] = new Cell() { IsAlive = false };
                    }
                }
            }
        }

        private void InstantiateGameField(int rows, int columns)
        {
            Cells = new Cell[rows, columns];

            for (int row = 0; row < Cells.GetLength(0); row++)
            {
                for (int column = 0; column < Cells.GetLength(1); column++)
                {
                    Cells[row, column] = new Cell();
                }
            }
        }

        private void InstantiateGameField(IEnumerable<IEnumerable<Cell>> cellCollection)
        {
            var rowCounter = 0;
            var columnCounter = 0;

            Cells = new Cell[cellCollection.First().Count(), cellCollection.Count()];

            foreach (var cellRow in cellCollection)
            {
                foreach (var cell in cellRow)
                {
                    Cells[rowCounter, columnCounter] = cell;

                    columnCounter++;
                }
                columnCounter = 0;
                rowCounter++;
            }
        }

        public GameFieldModel NextGenerationAsModel()
        {
            var model = new GameFieldModel();

            model.Row = Cells.GetLength(0);
            model.Column = Cells.GetLength(1);
            var cellList = new List<CellModel>();

            for (int row = 0; row < Cells.GetLength(0); row++)
            {
                for (int column = 0; column < Cells.GetLength(1); column++)
                {
                    var nbrOfLivingNeighbours = GetNbrOfLivingNeighbours(row, column);
                    if (Cells[row, column].UseRules(nbrOfLivingNeighbours))
                    {
                        cellList.Add(new CellModel() { Row = row, Column = column });
                    }
                }
            }

            model.AliveCells = cellList.ToArray();
            return model;
        }

        public GameField NextGeneration()
        {
            var newGameField = Copy();

            for (int row = 0; row < newGameField.Cells.GetLength(0); row++)
            {
                for (int column = 0; column < newGameField.Cells.GetLength(1); column++)
                {
                    var nbrOfLivingNeighbours = GetNbrOfLivingNeighbours(row, column);
                    newGameField.Cells[row, column].IsAlive = Cells[row, column].UseRules(nbrOfLivingNeighbours);
                }
            }

            return newGameField;
        }

        private int GetNbrOfLivingNeighbours(int row, int column)
        {
            var neighbourCounter = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || row + i < 0 || column + j < 0 ||
                    row + i >= Cells.GetLength(0) || column + j >= Cells.GetLength(1))
                    {
                        continue;
                    }

                    if (Cells[row + i, column + j].IsAlive)
                    {
                        neighbourCounter++;
                    }
                }
            }
            return neighbourCounter;
        }

        private GameField Copy()
        {
            var newGameField = new GameField(Cells.GetLength(0), Cells.GetLength(1));

            for (int row = 0; row < newGameField.Cells.GetLength(0); row++)
            {
                for (int column = 0; column < newGameField.Cells.GetLength(1); column++)
                {
                    newGameField.Cells[row, column] = Cells[row, column].Copy();
                }
            }

            return newGameField;
        }

        public string ToGameFieldString()
        {
            if (Cells == null)
            {
                return "Empty gamefield";
            }
            else
            {
                var stringBuilder = new StringBuilder();
                for (int row = 0; row < Cells.GetLength(0); row++)
                {
                    for (int column = 0; column < Cells.GetLength(1); column++)
                    {
                        stringBuilder.Append(Cells[row, column].IsAlive ? 'X' : 'O');
                    }
                    stringBuilder.Append(';');
                }
                //var gameFieldString = new GameFieldString() { Value = stringBuilder.ToString() };
                return stringBuilder.ToString();
            }
        }

        public override string ToString()
        {
            if (Cells == null)
            {
                return "Empty gamefield";
            }
            else
            {
                var stringBuilder = new StringBuilder();
                for (int row = 0; row < Cells.GetLength(0); row++)
                {
                    for (int column = 0; column < Cells.GetLength(1); column++)
                    {
                        stringBuilder.Append(Cells[row, column].IsAlive ? 'X' : 'O');
                    }
                    stringBuilder.Append('\n');
                }
                return stringBuilder.ToString();
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is GameField gameField)
            {
                var equals = gameField.Cells.GetLength(0) == Cells.GetLength(0) &&
                gameField.Cells.GetLength(1) == Cells.GetLength(1);

                if (!equals)
                {
                    return false;
                }

                for (int row = 0; row < Cells.GetLength(0); row++)
                {
                    for (int column = 0; column < Cells.GetLength(1); column++)
                    {
                        equals = gameField.Cells[row, column].IsAlive == Cells[row, column].IsAlive;
                        if (!equals)
                        {
                            return false;
                        }
                    }
                }
                return equals;
            }
            else
            {
                return false;
            }
        }
    }
}