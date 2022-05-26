using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PWS40.Backend.Conways.Model;
using Xunit;

namespace PWS40.Backend.Conways.Tests
{
    public class GameFieldTest
    {
        [Fact]
        public void NextGeneration_ShouldReturnCorrect()
        {
            //Arrange
            var oldGenerationGameField = new GameField(5, 5);
            oldGenerationGameField.Cells[0, 1].IsAlive = true;
            oldGenerationGameField.Cells[1, 2].IsAlive = true;

            oldGenerationGameField.Cells[2, 0].IsAlive = true;
            oldGenerationGameField.Cells[2, 1].IsAlive = true;
            oldGenerationGameField.Cells[2, 2].IsAlive = true;


            var expectedGameField = new GameField(5, 5);
            expectedGameField.Cells[1, 0].IsAlive = true;
            expectedGameField.Cells[1, 2].IsAlive = true;

            expectedGameField.Cells[2, 1].IsAlive = true;
            expectedGameField.Cells[2, 2].IsAlive = true;

            expectedGameField.Cells[3, 1].IsAlive = true;


            //Act
            var nextGenerationGameField = oldGenerationGameField.NextGeneration();

            //Assert
            Assert.Equal(expectedGameField, nextGenerationGameField);
        }

        //[Fact]
        //public void NextGenerationAsModel_ShouldReturnCorrect()
        //{
        //    //Arrange
        //    var oldGenerationGameField = new GameField(10, 10);
        //    oldGenerationGameField.Cells[0, 1].IsAlive = true;
        //    oldGenerationGameField.Cells[1, 2].IsAlive = true;

        //    oldGenerationGameField.Cells[2, 0].IsAlive = true;
        //    oldGenerationGameField.Cells[2, 1].IsAlive = true;
        //    oldGenerationGameField.Cells[2, 2].IsAlive = true;

        //    var currentDir = Directory.GetCurrentDirectory();
        //    var expectedGameFieldAsJson = File.ReadAllText(currentDir + "/Resources/ConwaysObjectFlyer_Gen_1.json");

        //    //Act
        //    var nextGenerationGameFieldModel = oldGenerationGameField.NextGenerationAsModel();
        //    var nextGenerationGameFieldAsJson = JsonSerializer.Serialize(nextGenerationGameFieldModel, new JsonSerializerOptions() { WriteIndented = true});

        //    //Assert
        //    Assert.Equal(expectedGameFieldAsJson, nextGenerationGameFieldAsJson);
        //}
    }
}