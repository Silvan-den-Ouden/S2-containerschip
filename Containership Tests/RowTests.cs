using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Containership_Tests
{
    [TestClass]
    public class RowTests
    {
        readonly Container NormalContainer = new(6000, false, false);
        readonly Container HeavyContainer = new(26000, false, false);
        readonly Container ValuableContainer = new(6000, false, true);
        readonly Container CooledContainer = new(6000, true, false);

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

        [TestMethod]
        public void CanAddContainer_WithSpaceToAdd_ShouldAllReturnTrue()
        {
            // Arrange
            Row row = new();
            row.MakeStacksBasedOnWidthOfShip(2);

            // Act
            bool canAddNormalContainer = row.CanAddContainerToRow(NormalContainer);
            bool canAddHeavyContainer = row.CanAddContainerToRow(HeavyContainer);
            bool canAddValuableContainer = row.CanAddContainerToRow(ValuableContainer);
            bool canAddCooledContainer = row.CanAddContainerToRow(CooledContainer);

            // Assert
            Assert.IsTrue(canAddNormalContainer);
            Assert.IsTrue(canAddHeavyContainer);
            Assert.IsTrue(canAddValuableContainer);
            Assert.IsTrue(canAddCooledContainer);
        }

        [TestMethod]
        public void CanAddContainer_WithoutSpaceToAdd_ShouldReturnFalse()
        {
            // Arrange
            Row row = new();
            row.MakeStacksBasedOnWidthOfShip(3);

            //fill all available stacks with 5 heavy containers
            for(int i = 1; i <= 15; i++) {
                row.AddContainer(HeavyContainer);
            }

            // Act
            bool canAddNormalContainer = row.CanAddContainerToRow(NormalContainer);
            bool canAddHeavyContainer = row.CanAddContainerToRow(HeavyContainer);
            bool canAddValuableContainer = row.CanAddContainerToRow(ValuableContainer);
            bool canAddCooledContainer = row.CanAddContainerToRow(CooledContainer);

            // Assert
            Assert.IsFalse(canAddNormalContainer);
            Assert.IsFalse(canAddHeavyContainer);
            Assert.IsFalse(canAddValuableContainer);
            Assert.IsFalse(canAddCooledContainer);
        }

        [TestMethod]
        public void GetIndexToAdd_WhenIndexAvailableIsZero_ShouldReturnZero()
        {
            // Arrange
            Row row = new();
            row.MakeStacksBasedOnWidthOfShip(3);

            // Act
            int index = row.GetIndexToAdd(NormalContainer);

            // Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void GetIndexToAdd_WhenIndexAvailableIsOne_ShouldReturnOne()
        {
            // Arrange
            Row row = new();
            row.MakeStacksBasedOnWidthOfShip(3);
            for(int i= 1; i <= 5; i++)
            {
                row.AddContainer(HeavyContainer);
            }

            // Act
            int index = row.GetIndexToAdd(NormalContainer);

            // Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void GetIndexToAdd_WhenNoIndexAvailable_ShouldReturnNegetiveOne()
        {
            // Arrange
            Row row = new();
            row.MakeStacksBasedOnWidthOfShip(3);
            for (int i = 1; i <= 15; i++)
            {
                row.AddContainer(HeavyContainer);
            }

            // Act
            int index = row.GetIndexToAdd(NormalContainer);

            // Assert
            Assert.AreEqual(-1, index);
        }

    }
}