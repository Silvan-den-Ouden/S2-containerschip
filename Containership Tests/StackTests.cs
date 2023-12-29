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

            // Act
            foreach (Container container in containerList)
            {
                stack.AddContainer(container);
            }
           
            // Assert
            Assert.AreEqual(30000, stack.GetLoadOnBottomContainer());
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

            // Act
            foreach (Container container in containerList)
            {
                stack.AddContainer(container);
            }

            // Assert
            Assert.IsTrue(stack.TopIsValuable());
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

            // Act
            foreach (Container container in containerList2)
            {
                stack.AddContainer(container);
            }

            // Assert
            Assert.IsFalse(stack.TopIsValuable());
        }

        [TestMethod]
        public void CanAddContainer_WithSpaceToAdd_ShouldAllReturnTrue()
        {
            // Act
            Stack stack = new();

            // Arrange
            
            stack.AddContainer(NormalContainer);

            // Assert
            Assert.IsTrue(stack.CanAddContainer(NormalContainer));
            Assert.IsTrue(stack.CanAddContainer(HeavyContainer));
            Assert.IsTrue(stack.CanAddContainer(ValuableContainer));
            Assert.IsTrue(stack.CanAddContainer(CooledContainer));
        }

        [TestMethod]
        public void CanAddContainer_WithoutSpaceToAdd_ShouldReturnFalse()
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
            Assert.IsFalse(stack.CanAddContainer(HeavyContainer));
        }

        [TestMethod]
        public void CanAddContainer_WithValuableContainerOnTop_ShouldReturnFalse()
        {
            // Act
            Stack stack = new();

            // Arrange
            stack.AddContainer(ValuableContainer);

            // Assert
            Assert.IsFalse(stack.CanAddContainer(NormalContainer));
            Assert.IsFalse(stack.CanAddContainer(HeavyContainer)); 
            Assert.IsFalse(stack.CanAddContainer(CooledContainer));
            Assert.IsFalse(stack.CanAddContainer(ValuableContainer));
        }
    }
}
