using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Containership_Tests
{
    [TestClass]
    public class StackTests
    {
        readonly Container NormalContainer = new(6000, false, false);
        readonly Container HeavyContainer = new(26000, false, false);
        readonly Container ValuableContainer = new(6000, false, true);
        readonly Container CooledContainer = new(6000, true, false);

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
            Assert.AreEqual(30000, stack.GetLoadOnBottomContainer());
        }

        [TestMethod]
        public void TopIsValuable_WorksCorrectly()
        {
            // Arrange
            Stack stack1 = new();
            Stack stack2 = new();

            List<Container> containerList1 = new List<Container>
            {
                NormalContainer,
                NormalContainer,
                ValuableContainer,
            };

            List<Container> containerList2 = new List<Container>
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
            // The load on the first container is 100 000 kg, so it cannot add another heavy container
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
