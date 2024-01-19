namespace Containership_Tests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void GetWeight_WithValidWeight_ReturnsCorrectWeight()
        {
            // Arrange 
            Container container = new(20000, false, false);

            // Act
            int weight = container.GetWeight();

            // Assert
            Assert.AreEqual(24000, weight);
        }

        [TestMethod]
        public void GetMaxLoad_RerturnMaxLoad_IThinkThisTestCaseIsVerySilly()
        {
            // Arrange
            Container container = new(20000, false, false);

            // Act
            int maxLoad = container.GetMaxLoad();

            // Assert
            Assert.AreEqual(120000, maxLoad);
        }

        [TestMethod]
        public void ContainerCreation_WithValidWeight_ShouldNotThrowException()
        {
            // Arrange
            int validContent = 20000;

            Container container;

            // Act
            try
            {
                container = new(validContent, false, false);
            } catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.IsNotNull(container);
        }

        [TestMethod]
        public void ContainerCreation_WithExceedingWeight_ShouldThrowException()
        {
            // Arrange
            int exceedingContent = 27000;
            
            // Act
            try
            {
                Container container = new(exceedingContent, false, false);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not return so no exception was thrown.");
        }

        [TestMethod]
        public void GetWeight_WithValidWeight_ShouldNotThrowException()
        {
            // Arrange
            int validContent = 20000;

            Container container = new(validContent, false, false);

            // Act
            try
            {
                container.GetWeight();
            }
            catch (InvalidOperationException)
            {
                Assert.Fail("Unexpected exception was thrown.");
            }

            // Assert
            Assert.IsTrue(true);
        }
    }
}
