using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                stack.Containers.Add(container);
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
                stack.Containers.Add(container);
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
                stack.Containers.Add(container);
            }

            // Assert
            Assert.IsFalse(stack.TopIsValuable());
        }

        [TestMethod]
        public void CanAddContainer_WithSpaceToAdd_ShouldAllReturnTrue()
        {
            // Arrange
            Stack stack = new();

            // Act
            stack.Containers.Add(NormalContainer);

            // Assert
            Assert.IsTrue(stack.CanAddContainerToStack(NormalContainer));
            Assert.IsTrue(stack.CanAddContainerToStack(HeavyContainer));
            Assert.IsTrue(stack.CanAddContainerToStack(ValuableContainer));
            Assert.IsTrue(stack.CanAddContainerToStack(CooledContainer));
        }

        // FEEDBACK VRAGEN: is dit beter?
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
            bool actual = stack.CanAddContainerToStack(HeavyContainer);

            // Assert
            Assert.IsFalse(actual);
        }

        // FEEDBACK VRAGEN: of is dit beter?
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
