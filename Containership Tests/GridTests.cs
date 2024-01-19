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

        [DataRow(1, 1)]
        [DataRow(3, 4)]
        [DataRow(4, 3)]
        [TestMethod]
        public void InitiateGrid_ShouldHaveCorrectDimensions(int length, int width)
        {
            // Act
            Grid grid = new(length, width);

            // Assert
            Assert.AreEqual(length, grid.Lines[0].Stacks.Count);
            Assert.AreEqual(width, grid.Lines.Count);
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

        [DataRow(2, 40.0/70)]
        [DataRow(5, 90.0/160)]
        [TestMethod]
        public void GetLeftWeightPercentage_ValidInput_ShouldReturnCorrectPercentage(int AmountOfHeavyContainers, double ExpectedResult)
        {
            // Arrange
            Grid grid = new(3, 2);
            for (int i = 1; i <= AmountOfHeavyContainers; i++)
            {
                grid.AddContainer(HeavyContainer);
            }
            grid.AddContainer(NormalContainer);

            // Act
            double leftPercentage = grid.GetLeftWeightPercentage();

            // Assert
            Assert.AreEqual(ExpectedResult, leftPercentage);
        }

        [TestMethod]
        public void GetLeftIndex_Index1IsFree_ShouldReturn1()
        {
            // Arrange
            Grid grid = new(3, 4);
            for (int i = 1; i <= 30; i++)
            {
                grid.AddContainer(HeavyContainer);
            }

            // Act
            int index = grid.GetLeftIndex(NormalContainer);

            // Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void GetRightIndex_Index2IsFree_ShouldReturn2()
        {
            // Arrange
            Grid grid = new(3, 4);
            for (int i = 1; i <= 30; i++)
            {
                grid.AddContainer(HeavyContainer);
            }

            // Act
            int index = grid.GetRightIndex(NormalContainer);

            // Assert
            Assert.AreEqual(2, index);
        }

        [DataRow(5, 2)]
        [DataRow(9, 4)]
        [TestMethod]
        public void CanPlaceInMiddleLine_WithSpaceInMiddle_ShouldReturnIndex(int shipWidth, int expectedIndex)
        {
            // Arrange
            Grid grid = new(3, shipWidth);

            // Act
            int index = grid.CanPlaceInMiddleLine(NormalContainer);

            // Assert
            Assert.AreEqual(expectedIndex, index);
        }
    }
}
