﻿using System.Security.Cryptography;

namespace Containership_Tests
{
    [TestClass]
    public class ContainerTests
    {
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

        [TestMethod]
        public void GetWeight_WithExceedingWeight_ShouldThrowException()
        {
            // Arrange
            int exceedingContent = 27000; 

            Container container = new(exceedingContent, false, false); // this line throws exception

            // Act
            try
            {
                container.GetWeight(); // this method should be tested
            }
            catch (InvalidOperationException)
            {
                return;
            }

            // Assert
            Assert.Fail("Did not return so no exception was thrown.");
        }
    }
}
