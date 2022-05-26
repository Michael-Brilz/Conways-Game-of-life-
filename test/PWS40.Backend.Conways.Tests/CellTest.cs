using Xunit;

namespace PWS40.Backend.Conways.Tests
{
    public class CellTest
    {
        [Fact]
        public void UseRulesOnCell_ShouldReturnCorrect()
        {
            //Arrange
            var cell_0 = new Cell() { IsAlive = false };
            var cell_1 = new Cell() { IsAlive = true };
            var cell_2 = new Cell() { IsAlive = true };
            var cell_3 = new Cell() { IsAlive = true };

            //Act
            var nextGenCellState_0 = cell_0.UseRules(3);
            var nextGenCellState_1 = cell_1.UseRules(1);
            var nextGenCellState_2 = cell_2.UseRules(2);
            var nextGenCellState_3 = cell_3.UseRules(8);

            //Assert
            Assert.True(nextGenCellState_0);
            Assert.False(nextGenCellState_1);

            Assert.True(nextGenCellState_2);
            Assert.False(nextGenCellState_3);
        }
    }
}