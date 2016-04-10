namespace GAB.Core.Tests.Domain.ResourcePlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GAB.Core.Domain;
    using GAB.Core.Domain.ResourcePlanning;

    using NUnit.Framework;

    using Should;

    [TestFixture]
    public class ResourcePlanOverlappingTests
    {
        private const string FakeEmployeeId = "123";

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HasOverlapping_HaveEmptyResourcePlan_ThrowsInvalidOperationException()
        {
            // Arrange
            IEnumerable<ResourcePlan> resourcePlans = Enumerable.Empty<ResourcePlan>();
            ResourcePlan resourcePlan = null;

            // Act
            ResourcePlanOverlapping.HasOverlapping(resourcePlan, resourcePlans);
        }

        [Test]
        public void HasOverlapping_HaveResourcePlanAndNoExistingResourcePlans_ReturnsFalse()
        {
            // Arrange
            IEnumerable<ResourcePlan> resourcePlans = Enumerable.Empty<ResourcePlan>();
            ResourcePlan resourcePlan = ResourcePlan.CreateForToday(FakeEmployeeId);

            // Act
            bool actual = ResourcePlanOverlapping.HasOverlapping(resourcePlan, resourcePlans);

            // Assert
            actual.ShouldEqual(false);
        }
        
        [Test]
        [TestCase(7, 8, FakeEmployeeId, false)]
        [TestCase(7, 9, FakeEmployeeId, true)]
        [TestCase(8, 9, FakeEmployeeId, true)]
        [TestCase(9, 10, FakeEmployeeId, true)]
        [TestCase(11, 12, FakeEmployeeId, true)]
        [TestCase(11, 12, "321", false)]
        [TestCase(12, 13, FakeEmployeeId, false)]
        public void HasOverlapping_GivenResourcePlanAndHaveExistingResourcePlans_ReturnsExpectedResult(
            int resourcePlanStartHour, 
            int resourcePlanEndHour,
            string employeeId,
            bool expectedResult)
        {
            // Arrange
            List<ResourcePlan> resourcePlans = new List<ResourcePlan> {
                new ResourcePlan {
                    EmployeeId = FakeEmployeeId,
                    From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0),
                    To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0)
                }
            };

            ResourcePlan resourcePlan = ResourcePlan.Create(
                employeeId, 
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, resourcePlanStartHour, 0, 0), 
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, resourcePlanEndHour, 0, 0));

            // Act
            bool actual = ResourcePlanOverlapping.HasOverlapping(resourcePlan, resourcePlans);

            // Assert
            actual.ShouldEqual(expectedResult);
        }
    }
}
