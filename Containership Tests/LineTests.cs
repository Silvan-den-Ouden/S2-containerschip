using System.Security.Cryptography.X509Certificates;
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
        public void MakeLineBasedOnLengthOfShip_ValidWidth_ShouldReturnCorrectAmountOfLines()
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
        public void MakeLineBasedOnLengthOfShip_EmptyWidth_ShouldThrowException()
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
        public void MakeLineBasedOnLengthOfShip_NegativeWidth_ShouldThrowException()
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
            bool canAddValuableContainer = line.LineCanAddContainer(ValuableContainer) != -1;
            bool canAddNormalContainer = line.LineCanAddContainer(NormalContainer) != -1;
            bool canAddHeavyContainer = line.LineCanAddContainer(HeavyContainer) != -1;
            bool canAddCooledContainer = line.LineCanAddContainer(CooledContainer) != -1;

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
                if (line.LineCanAddContainer(ValuableContainer) != -1){
                    couldAddValuableContainer = true;
                }
                if (line.LineCanAddContainer(ValuableContainer) != -1)
                {
                    couldAddCooledContainer = true;
                }
                if (line.LineCanAddContainer(ValuableContainer) != -1)
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


        [TestMethod]
        [DataRow(0, true)]  // Valid Index
        [DataRow(1, false)] // Invalid Index
        public void CanAddCoolableContainer_ShouldReturnExpectedResult(int stackIndex, bool expectedResult)
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(3);

            // Act
            bool canAddCooledContainer = line.CanAddCooledContainer(stackIndex);

            // Assert
            Assert.AreEqual(expectedResult, canAddCooledContainer);
        }

        [TestMethod]
        [DataRow(0, true)] // Valid index
        [DataRow(2, false)] // Invalid index
        public void CanAddValuableContainer_ShouldReturnExpectedResult(int stackIndex, bool expectedResult)
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(5);

            // Act
            bool canAddValuableContainer = line.CanAddValuableContainer(stackIndex);

            // Assert
            Assert.AreEqual(expectedResult, canAddValuableContainer);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void ShouldAddContainer_EmptyLineValidInput_ShouldReturnTrue(int stackIndex)
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(4);

            // Act
            bool result = line.ShouldAddContainer(stackIndex);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(4)]
        public void ShouldAddContainer_EmptyLineInValidInput_ShouldReturnFalse(int stackIndex)
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(4);

            // Act
            bool result = line.ShouldAddContainer(stackIndex);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldAddContainer_CannotMakeThirdStackHigherThanStackBehind_ShouldReturnFalse()
        {
            // Arrange
            Line line = new();
            line.MakeLineBasedOnLengthOfShip(4);
            List<Container> containers = new()
            {
                ValuableContainer, ValuableContainer,
            };

            for(int i = 0; i < containers.Count; i++)
            {
                line.AddContainer(containers[i]);
            }

            // Act
            bool result = line.ShouldAddContainer(2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}