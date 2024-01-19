using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containership_Tests
{
    [TestClass]
    public class ShipTests
    {
        readonly Container NormalContainer = new (6000, false, false);
        readonly Container HeavyContainer = new(26000, false, false);
        readonly Container ValuableContainer = new(6000, false, true);
        readonly Container CooledContainer = new(6000, true, false);

        [TestMethod]
        public void FillShip_ValidInput_ShouldFitAllContainers()
        {
            // Arrange
            Ship ship = new(3, 3, 70000);
            List<Container> containers = new()
            {
                ValuableContainer, CooledContainer, HeavyContainer, NormalContainer
            };

            // Act
            try
            {
                ship.FillShip(containers);
            } 
            catch (InvalidOperationException)
            {
                Assert.Fail("Unexpected exception was thrown.");
            }

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FillShip_ShipMaxLoadSmallForLoad_ShouldThrowException()
        {
            // Arrange
            Ship ship = new(3, 3, 20000);
            List<Container> containers = new()
            {
                HeavyContainer,
            };

            // Act
            try
            {
                ship.FillShip(containers);
            } 
            catch (InvalidOperationException) 
            {
                return;
            }

            Assert.Fail("Did not throw expected exception.");
        }

        [TestMethod]
        public void FillShip_ShipLoadTooLight_ShouldThrowException()
        {
            // Arrange
            Ship ship = new(3, 3, 70000);
            List<Container> containers = new()
            {
                HeavyContainer,
            };

            // Act
            try
            {
                ship.FillShip(containers);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("Did not throw expected exception.");
        }
    }
}
