using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PWS40.Backend.Conways.Tests
{
    public class GameFieldParserTest
    {
        [Fact]
        public void ParseGameField_ShouldReturnCorrect()
        {
            //Arrange
            var expected = new GameField(4, 4);
            expected.Cells[0, 3].IsAlive = true;
            expected.Cells[1, 1].IsAlive = true;
            expected.Cells[2, 2].IsAlive = true;
            expected.Cells[3, 0].IsAlive = true;

            //Act
            var parseResult = GameFieldParser.TryParseGameField("0001;0100;0010;1000;", out var actualGameField);

            //Assert
            Assert.True(parseResult);
            Assert.Equal(expected, actualGameField);
        }


        [Fact]
        public void ParseGameField_ShouldFail()
        {
            //Arrange
            var expected = new GameField(4, 4);
            expected.Cells[0, 3].IsAlive = true;
            expected.Cells[1, 1].IsAlive = true;
            expected.Cells[2, 2].IsAlive = true;
            expected.Cells[3, 0].IsAlive = true;

            //Act
            var parseResult = GameFieldParser.TryParseGameField("1001;0101;1010;10100;", out var actualGameField);

            //Assert
            Assert.False(parseResult);
        }

        //[Fact]
        //public void TryParseGameFieldOptimized_ShouldReturnCorrect()
        //{
        //    //Arrange
        //    var currentDir = Directory.GetCurrentDirectory();
        //    var gameFieldAsJson = File.ReadAllText(currentDir + "/Resources/ConwaysObjectFlyer_Gen_1.json");

        //    var expectedGameField = new GameField(10, 10);
        //    expectedGameField.Cells[1, 0].IsAlive = true;
        //    expectedGameField.Cells[1, 2].IsAlive = true;

        //    expectedGameField.Cells[2, 1].IsAlive = true;
        //    expectedGameField.Cells[2, 2].IsAlive = true;

        //    expectedGameField.Cells[3, 1].IsAlive = true;

        //    //Act
        //    var parseResult = GameFieldParser.TryParseGameField(gameFieldAsJson, out var actualGameField, true);

        //    //Assert
        //    Assert.True(parseResult);
        //    Assert.Equal(expectedGameField, actualGameField);
        //}

    }
}
