namespace Containership_Tests
{
    [TestClass]
    public class StackTests
    {
        readonly Container NormalContainer = new(10, false, false);
        readonly Container HeavyContainer = new(30, false, false);
        readonly Container ValuableContainer = new(10, false, true);
        readonly Container CooledContainer = new(10, true, false);

        [TestMethod]
        public void GetLoadOnBottomContainer_WorksCorrectly()
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

            // Act
            foreach (Container container in containerList)
            {
                stack.AddContainer(container);
            }

            // Assert
            Assert.AreEqual(30, stack.GetLoadOnBottomContainer());
        }

        [TestMethod]
        public void TopIsValuable_WorksCorrectly()
        {
            // Arrange
            Stack stack1 = new();
            Stack stack2 = new();

            List<Container> containerList1 = new()
            {
                NormalContainer,
                NormalContainer,
                ValuableContainer,
            };

            List<Container> containerList2 = new()
            {
                NormalContainer,
                NormalContainer,
                NormalContainer,
            };

            // Act
            foreach (Container container in containerList1)
            {
                stack1.AddContainer(container);
            }

            foreach (Container container in containerList2)
            {
                stack2.AddContainer(container);
            }

            // Assert
            Assert.IsTrue(stack1.TopIsValuable());
            Assert.IsFalse(stack2.TopIsValuable());
        }


        
        [TestMethod]
        public void CanAddContainerWorkWithNormalContainerOnTop()
        {
            // Act
            Stack stack = new();
            
            // Arrange
            // The load on the first container is 100
            stack.AddContainer(NormalContainer);
            stack.AddContainer(NormalContainer);
            stack.AddContainer(HeavyContainer);
            stack.AddContainer(HeavyContainer);
            stack.AddContainer(HeavyContainer);

            // Assert
            Assert.IsTrue(stack.CanAddContainer(NormalContainer));
            Assert.IsFalse(stack.CanAddContainer(HeavyContainer));
            Assert.IsTrue(stack.CanAddContainer(ValuableContainer));
            Assert.IsTrue(stack.CanAddContainer(CooledContainer));
        }

        [TestMethod]
        public void CannotAddContainerOnTopOfValuableContainer()
        {
            // Act
            Stack stack = new();

            // Arrange
            stack.AddContainer(ValuableContainer);

            // Assert
            Assert.IsFalse(stack.CanAddContainer(NormalContainer));
            Assert.IsFalse(stack.CanAddContainer(ValuableContainer));
        }
    }
}