namespace GAB.Core.Tests.Domain
{
    using System;

    using GAB.Core.Domain;

    using NUnit.Framework;

    using Should;

    [TestFixture]
    public class ResourcePlanTests
    {
        private const string FakeEmployeeId = "123";
        private const string FakeEmployeeDepartment = "ABC";

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Create_StartAndEndAreOnSameDays_ReturnsExpectedResourcePlan()
        {
            // Arrange
            DateTime startAt = DateTime.UtcNow;
            DateTime endAt = DateTime.UtcNow.AddDays(-1);
            ResourcePlan expected = new ResourcePlan { EmployeeId = FakeEmployeeId, From = startAt, To = endAt };

            // Act
            ResourcePlan actual = ResourcePlan.Create(FakeEmployeeId, FakeEmployeeDepartment, startAt, endAt);

            // Assert
            actual.ShouldEqual(expected);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Create_StartAndEndAreOnDifferentDays_ThrowsInvalidOperationException()
        {
            // Arrange
            DateTime startAt = DateTime.UtcNow;
            DateTime endAt = DateTime.UtcNow.AddDays(-1);

            // Act
            ResourcePlan.Create(FakeEmployeeId, FakeEmployeeDepartment, startAt, endAt);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Create_StartAndEndAreOnDifferentMonths_ThrowsInvalidOperationException()
        {
            // Arrange
            DateTime startAt = DateTime.UtcNow;
            DateTime endAt = DateTime.UtcNow.AddMonths(-1);

            // Act
            ResourcePlan.Create(FakeEmployeeId, FakeEmployeeDepartment, startAt, endAt);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Create_StartAndEndAreOnDifferentYears_ThrowsInvalidOperationException()
        {
            // Arrange
            DateTime startAt = DateTime.UtcNow;
            DateTime endAt = DateTime.UtcNow.AddYears(-1);

            // Act
            ResourcePlan.Create(FakeEmployeeId, FakeEmployeeDepartment, startAt, endAt);
        }
    }
}