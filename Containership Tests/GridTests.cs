using S2_containerschip;

namespace Containership_Tests
{
    [TestClass]
    public class GridTests
    {
        readonly Container NormalContainer = new(6000, false, false);
        readonly Container HeavyContainer = new(26000, false, false);
        readonly Container ValuableContainer = new(6000, false, true);
        readonly Container CooledContainer = new(6000, true, false);

        [TestMethod]
        public void MakeLinesBasedOnWidthOfShip_ValidWidth_ShouldReturnCorrectAmountOfLines()
        {
            // Arrange
            Grid gridOdd = new(3, 5);
            Grid gridEven = new(3, 6);

            // Act
            int widthOdd = gridOdd.Lines.Count;
            int widthEven = gridEven.Lines.Count;

            // Assert
            Assert.AreEqual(5, widthOdd);
            Assert.AreEqual(6, widthEven);
        }

        [DataRow(0)]
        [DataRow(-1)]
        [TestMethod]
        public void MakeLinesBasedOnWidthOfShip_InvalidWidth_ShouldThrowException(int length)
        {
            // Arrange
           

            // Act
            try
            {
                Grid gridEmpty = new(3, length);
                gridEmpty.MakeGridBasedOnShipDimensions(3, length);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not return so no exception was thrown.");
        }

        [TestMethod]
        public void GetTotalWeight_EmptyShip_ShouldReturnZero()
        {
            // Arrange
            Grid gridEmpty = new(3, 3);

            // Act
            int totalWeight = gridEmpty.GetTotalWeight();

            // Assert
            Assert.AreEqual(0, totalWeight);
        }

        [TestMethod]
        public void GetTotalWeight_ValidInput_ShouldReturnCorrectWeight()
        {
            // Arrange
            Grid grid = new(3, 2);
            grid.AddContainer(HeavyContainer);
            grid.AddContainer(HeavyContainer);
            grid.AddContainer(NormalContainer);

            // Act
            int totalWeight = grid.GetTotalWeight();

            // Assert
            Assert.AreEqual(70000, totalWeight);
        }

        [TestMethod]
        public void GetLeftWeight_EmptyShip_ShouldReturnzero()
        {
            // Arrange
            Grid gridEmpty = new(3, 3);

            // Act
            int leftWeight = gridEmpty.GetLeftWeight();

            // Assert
            Assert.AreEqual(0, leftWeight);
        }

        [TestMethod]
        public void GetLeftWeight_ValidInput_ShouldReturnCorrectWeight()
        {
            // Arrange
            Grid grid = new(3, 2);
            grid.AddContainer(HeavyContainer);
            grid.AddContainer(HeavyContainer);
            grid.AddContainer(NormalContainer);
            grid.AddContainer(HeavyContainer);

            // Act
            int leftWeight = grid.GetLeftWeight();

            // Assert
            Assert.AreEqual(40000, leftWeight);
        }

        [TestMethod]
        public void GetLeftWeightPercentage_ValidInput_ShouldReturnCorrectPercentage()
        {
            // Arrange
            Grid grid = new(3, 2);
            grid.AddContainer(HeavyContainer);
            grid.AddContainer(HeavyContainer);
            grid.AddContainer(NormalContainer);

            // Act
            double leftPercentage = grid.GetLeftWeightPercentage();

            // Assert
            Assert.AreEqual(40/70, leftPercentage);
        }
    }
}
