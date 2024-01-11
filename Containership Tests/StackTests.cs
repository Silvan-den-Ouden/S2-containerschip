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
        public void GetLoadOnBottomContainer_ReturnsCorrectLoad()
        {
            // Arrange
            Stack stack = new();
            List<Container> containerList = new()
            {
                NormalContainer,
                NormalContainer,
                NormalContainer,
                NormalContainer,
            };

            foreach (Container container in containerList)
            {
                stack.Containers.Add(container);
            }

            // Act
            int loadOnBottomContainer = stack.GetLoadOnBottomContainer();

            // Assert
            Assert.AreEqual(30000, loadOnBottomContainer);
        }

        [TestMethod]
        public void TopIsValuable_WithValuableContainerOnTop_ReturnsTrue()
        {
            // Arrange
            Stack stack = new();

            List<Container> containerList = new()
            {
                NormalContainer,
                NormalContainer,
                ValuableContainer,
            };

            foreach (Container container in containerList)
            {
                stack.Containers.Add(container);
            }

            // Act
            bool result = stack.TopIsValuable();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TopIsValuable_WithNonValuableContainerOnTop_ReturnsFalse()
        {
            // Arrange
            Stack stack = new();

            List<Container> containerList2 = new()
            {
                NormalContainer,
                NormalContainer,
                NormalContainer,
            };

            foreach (Container container in containerList2)
            {
                stack.Containers.Add(container);
            }

            // Act
            bool result = stack.TopIsValuable();

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
            stack.Containers.Add(NormalContainer);
            stack.Containers.Add(NormalContainer);
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(HeavyContainer);
            stack.Containers.Add(HeavyContainer);

            // Act
            // The load on the first container is 100 000 kg, so it cannot add another heavy container
            bool result = stack.CanAddContainerToStack(HeavyContainer);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddContainer_WithValuableContainerOnTop_ShouldReturnFalse()
        {
            // Arrange
            Stack stack = new();
            stack.Containers.Add(ValuableContainer);

            // Act
            bool canAddNormalContainer = stack.CanAddContainerToStack(NormalContainer);
            bool canAddHeavyContainer = stack.CanAddContainerToStack(HeavyContainer);
            bool canAddCooledContainer = stack.CanAddContainerToStack(CooledContainer);
            bool canAddValuableContainer = stack.CanAddContainerToStack(ValuableContainer);

            // Assert
            Assert.IsFalse(canAddNormalContainer);
            Assert.IsFalse(canAddHeavyContainer);
            Assert.IsFalse(canAddCooledContainer);
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
                stack.AddContainer(NormalContainer);
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
