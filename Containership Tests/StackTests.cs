namespace Containership_Tests
{
    [TestClass]
    public class StackTests
    {
        // FEEDBACK VRAGEN: mag dit?
        readonly Container NormalContainer = new(6000, false, false);
        readonly Container HeavyContainer = new(26000, false, false);
        readonly Container ValuableContainer = new(6000, false, true);
        readonly Container CooledContainer = new(6000, true, false);

        // FEEDBACK VRAGEN:
        //  Functies callen die al eerder getest zijn (.AddContainer();)
        //  of built in functies gebruiken (containers.Add();)
        
        [TestMethod]
        public void GetStackWeight_ReturnsCorrectLoad()
        {
            // Arrange
            Stack stack = new();
            List<Container> containerList = new()
            {
                NormalContainer,
                NormalContainer,
                NormalContainer,
            };

            foreach (Container container in containerList)
            {
                stack.Containers.Add(container);
            }

            // Act
            int loadOnBottomContainer = stack.GetStackWeight();

            // Assert
            Assert.AreEqual(30000, loadOnBottomContainer);
        }

        [TestMethod] 
        public void HasValuable_DoesHaveValuable_ShouldReturnTrue()
        {
            // Arrange
            Stack stack = new();
            stack.Containers.Add(ValuableContainer);

            // Act
            bool result = stack.HasValuable();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasValuable_DoesNotHaveValuable_ShouldReturnFalse()
        {
            // Arrange
            Stack stack = new();
            stack.Containers.Add(NormalContainer);
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(CooledContainer);

            // Act
            bool result = stack.HasValuable();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddContainer_WithSpaceToAdd_ShouldAllReturnTrue()
        {
            // Arrange
            Stack stack = new();
            stack.Containers.Add(NormalContainer);

            // Act
            bool canAddNormalContainer = stack.CanAddContainerToStack(NormalContainer);
            bool canAddHeavyContainer = stack.CanAddContainerToStack(HeavyContainer);
            bool canAddValuableContainer = stack.CanAddContainerToStack(ValuableContainer);
            bool canAddCooledContainer = stack.CanAddContainerToStack(CooledContainer);

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
            Stack stack = new();
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(NormalContainer);

            // Act
            // The stack has a weight of 130 000 kg, which is greater than a container can carry.
            bool result = stack.CanAddContainerToStack(HeavyContainer);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddContainer_WithoutSpaceToAdd_ShouldReturnFalse2()
        {
            // Arrange
            Stack stack = new();
            stack.AddContainer(HeavyContainer);
            stack.AddContainer(HeavyContainer);
            stack.AddContainer(HeavyContainer);
            stack.AddContainer(HeavyContainer);
            stack.AddContainer(HeavyContainer);

            // Act
            bool result = stack.CanAddContainerToStack(NormalContainer);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddValuableContainer_WithValuableContainerInStack_ShouldReturnFalse()
        {
            // Arrange
            Stack stack = new();
            stack.Containers.Add(ValuableContainer);
            stack.Containers.Add(NormalContainer);

            // Act
            bool canAddValuableContainer = stack.CanAddContainerToStack(ValuableContainer);

            // Assert
            Assert.IsFalse(canAddValuableContainer);
        }

        [TestMethod]
        public void AddContainer_WithValidContainer_ShouldNotThrowException()
        {
            // Arrange
            Stack stack = new();

            // Act
            try
            {
                stack.AddContainer(NormalContainer);
            }
            catch (InvalidOperationException)
            {
                Assert.Fail("Unexpected exception was thrown.");
            }

            // Assert
            Assert.AreEqual(1, stack.Containers.Count);
            Assert.AreEqual(NormalContainer, stack.Containers[0]);
        }

        [TestMethod]
        public void AddContainer_WithInvalidContainer_ShouldThrowException()
        {
            // Arrange
            Stack stack = new();
            stack.Containers.Add(ValuableContainer);

            // Act
            try
            {
                stack.AddContainer(ValuableContainer);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not throw expected exception.");
        }

    }
}
