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
            bool canAddValuableContainer = line.LineCanAddContainer(ValuableContainer, 0);
            bool canAddNormalContainer = line.LineCanAddContainer(NormalContainer, 0);
            bool canAddHeavyContainer = line.LineCanAddContainer(HeavyContainer, 0);
            bool canAddCooledContainer = line.LineCanAddContainer(CooledContainer, 0);

            // Assert
            Assert.IsTrue(canAddNormalContainer);
            Assert.IsTrue(canAddHeavyContainer);
            Assert.IsTrue(canAddValuableContainer);
            Assert.IsTrue(canAddCooledContainer);
        }

        [TestMethod]
        public void CanAddContainer_WithSpaceToAdd_ShouldReturnTrue()
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(2);
            bool couldAddValuableContainer = false;
            bool couldAddCooledContainer = false;
            bool couldAddNormalContainer = false;


            // Act
            for (int i = 0; i < line.Stacks.Count; i++)
            {
                if (line.LineCanAddContainer(ValuableContainer, i)){
                    couldAddValuableContainer = true;
                }
                if (line.LineCanAddContainer(ValuableContainer, i))
                {
                    couldAddCooledContainer = true;
                }
                if (line.LineCanAddContainer(ValuableContainer, i))
                {
                    couldAddNormalContainer = true;
                }
            }

            // Assert
            Assert.IsTrue(couldAddValuableContainer); 
            Assert.IsTrue(couldAddCooledContainer);
            Assert.IsTrue(couldAddNormalContainer);

        }

        [TestMethod]
        public void AddContainer_WithoutSpaceToAdd_ShouldThrowException()
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(3);

            //fill all available stacks with 5 heavy containers
            for (int i = 1; i <= 15; i++) {
                line.AddContainer(HeavyContainer);
            }

            // Act
            try
            {
                line.AddContainer(ValuableContainer);
            }
            catch
            {
                return;
            }
            

            // Assert
            Assert.Fail("Did not throw expected exception.");
        }
    }
}