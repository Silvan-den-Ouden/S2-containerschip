namespace Containership_Tests
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void MakeRowsBasedOnWidth_ValidWidth_ShouldReturnCorrectAmountOfRows()
        {
            // Arrange
            Row rowOdd = new();
            Row rowEven = new();
            rowOdd.MakeStacksBasedOnWidthOfShip(5);
            rowEven.MakeStacksBasedOnWidthOfShip(6);

            // Act
            int lengthOdd = rowOdd.Stacks.Count();
            int lengthEven = rowEven.Stacks.Count();

            // Assert
            Assert.AreEqual(5, lengthOdd);
            Assert.AreEqual(6, lengthEven);
        }

        [TestMethod]
        public void MakeRowsBasedOnWidth_EmptyWidth_ShouldThrowException()
        {
            // Arrange
            Row rowEmpty = new();

            // Act
            try
            {
                rowEmpty.MakeStacksBasedOnWidthOfShip(0);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not return so no exception was thrown.");
        }

        [TestMethod]
        public void MakeRowsBasedOnWidth_NegativeWidth_ShouldThrowException()
        {
            // Arrange
            Row rowNegative = new();

            // Act
            try
            {
                rowNegative.MakeStacksBasedOnWidthOfShip(-1);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not return so no exception was thrown.");
        }


    }
}
