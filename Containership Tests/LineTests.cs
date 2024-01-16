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
        public void MakeLineBasedOnLength_ValidWidth_ShouldReturnCorrectAmountOfLines()
        {
            // Arrange
            Line lineOdd = new();
            Line lineEven = new();
            lineOdd.MakeLineBasedOnLengthOfShip(5);
            lineEven.MakeLineBasedOnLengthOfShip(6);

            // Act
            int lengthOdd = lineOdd.Stacks.Count;
            int lengthEven = lineEven.Stacks.Count;

            // Assert
            Assert.AreEqual(5, lengthOdd);
            Assert.AreEqual(6, lengthEven);
        }

        [TestMethod]
        public void MakeLineBasedOnLength_EmptyWidth_ShouldThrowException()
        {
            // Arrange
            Line lineEmpty = new();

            // Act
            try
            {
                lineEmpty.MakeLineBasedOnLengthOfShip(0);
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
                lineNegative.MakeLineBasedOnLengthOfShip(-1);
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
            line.MakeLineBasedOnLengthOfShip(2);

            // Act
            bool canAddValuableContainer = line.CanAddContainerToLine(ValuableContainer, 0);
            bool canAddNormalContainer = line.CanAddContainerToLine(NormalContainer, 0);
            bool canAddHeavyContainer = line.CanAddContainerToLine(HeavyContainer, 0);
            bool canAddCooledContainer = line.CanAddContainerToLine(CooledContainer, 0);

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
            line.MakeLineBasedOnLengthOfShip(3);

            //fill all available stacks with 5 heavy containers
            for(int i = 1; i <= 15; i++) {
                line.AddContainer(HeavyContainer);
            }

            // Act
            bool canAddNormalContainer = line.CanAddContainerToLine(NormalContainer, 1);
            bool canAddHeavyContainer = line.CanAddContainerToLine(HeavyContainer, 1);
            bool canAddValuableContainer = line.CanAddContainerToLine(ValuableContainer, 1);
            bool canAddCooledContainer = line.CanAddContainerToLine(CooledContainer, 1);

            // Assert
            Assert.IsFalse(canAddNormalContainer);
            Assert.IsFalse(canAddHeavyContainer);
            Assert.IsFalse(canAddValuableContainer);
            Assert.IsFalse(canAddCooledContainer);
        }
    }
}