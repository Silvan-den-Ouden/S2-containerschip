using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Containership_Tests
{
    [TestClass]
    public class LineTests
    {
        readonly Container NormalContainer = new(6000, false, false);
        readonly Container HeavyContainer = new(26000, false, false);
        readonly Container ValuableContainer = new(6000, false, true);
        readonly Container CooledContainer = new(6000, true, false);

        [TestMethod]
        public void MakeLinesBasedOnWidth_ValidWidth_ShouldReturnCorrectAmountOfLines()
        {
            // Arrange
            Line lineOdd = new();
            Line lineEven = new();
            lineOdd.MakeLinesBasedOnWidthOfShip(5);
            lineEven.MakeLinesBasedOnWidthOfShip(6);

            // Act
            int lengthOdd = lineOdd.Stacks.Count;
            int lengthEven = lineEven.Stacks.Count;

            // Assert
            Assert.AreEqual(5, lengthOdd);
            Assert.AreEqual(6, lengthEven);
        }

        [TestMethod]
        public void MakeLinesBasedOnWidth_EmptyWidth_ShouldThrowException()
        {
            // Arrange
            Line lineEmpty = new();

            // Act
            try
            {
                lineEmpty.MakeLinesBasedOnWidthOfShip(0);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not return so no exception was thrown.");
        }

        [TestMethod]
        public void MakeLinesBasedOnWidth_NegativeWidth_ShouldThrowException()
        {
            // Arrange
            Line lineNegative = new();

            // Act
            try
            {
                lineNegative.MakeLinesBasedOnWidthOfShip(-1);
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
            Line line = new();
            line.MakeLinesBasedOnWidthOfShip(2);

            // Act
            bool canAddNormalContainer = line.CanAddContainerToLine(NormalContainer);
            bool canAddHeavyContainer = line.CanAddContainerToLine(HeavyContainer);
            bool canAddValuableContainer = line.CanAddContainerToLine(ValuableContainer);
            bool canAddCooledContainer = line.CanAddContainerToLine(CooledContainer);

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
            Line line = new();
            line.MakeLinesBasedOnWidthOfShip(3);

            //fill all available stacks with 5 heavy containers
            for(int i = 1; i <= 15; i++) {
                line.AddContainer(HeavyContainer);
            }

            // Act
            bool canAddNormalContainer = line.CanAddContainerToLine(NormalContainer);
            bool canAddHeavyContainer = line.CanAddContainerToLine(HeavyContainer);
            bool canAddValuableContainer = line.CanAddContainerToLine(ValuableContainer);
            bool canAddCooledContainer = line.CanAddContainerToLine(CooledContainer);

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
            Line line = new();
            line.MakeLinesBasedOnWidthOfShip(3);

            // Act
            int index = line.GetIndexToAdd(NormalContainer);

            // Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void GetIndexToAdd_WhenIndexAvailableIsOne_ShouldReturnOne()
        {
            // Arrange
            Line line = new();
            line.MakeLinesBasedOnWidthOfShip(3);
            for(int i= 1; i <= 5; i++)
            {
                line.AddContainer(HeavyContainer);
            }

            // Act
            int index = line.GetIndexToAdd(NormalContainer);

            // Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void GetIndexToAdd_WhenNoIndexAvailable_ShouldReturnNegetiveOne()
        {
            // Arrange
            Line line = new();
            line.MakeLinesBasedOnWidthOfShip(3);
            for (int i = 1; i <= 15; i++)
            {
                line.AddContainer(HeavyContainer);
            }

            // Act
            int index = line.GetIndexToAdd(NormalContainer);

            // Assert
            Assert.AreEqual(-1, index);
        }

    }
}