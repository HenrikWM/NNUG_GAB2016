namespace GAB.Core.Tests.Domain
{
    using System;

    using GAB.Core.Domain;
    using GAB.Core.Domain.ResourcePlanning;

    using NUnit.Framework;

    using Should;

    [TestFixture]
    public class CapacityCalculatorTests
    {
        private const string FakeEmployeeId = "123";
        private const string FakeEmployeeDepartment = "ABC";

        [Test]
        public void CalculateUtilizationForEmployee_GivenFullDayPlanned_ReturnsReportWith100PercentUtilization()
        {
            // Arrange
            ResourcePlan resourcePlanWithFullDay = ResourcePlan.CreateForToday(FakeEmployeeId);
            
            // Act
            double actual = CapacityCalculator.CalculateUtilizationForEmployee(resourcePlanWithFullDay);
            
            // Assert
            actual.ShouldEqual(100);
        }

        [Test]
        public void CalculateUtilizationForEmployee_GivenHalfDayPlanned_ReturnsReportWith50PercentUtilization()
        {
            // Arrange
            DateTime startsAt = new DateTime(2016, 4, 13, 8, 0, 0);
            DateTime endsAt = new DateTime(2016, 4, 13, 12, 0, 0);
            ResourcePlan resourcePlanWithFullDay = ResourcePlan.Create(FakeEmployeeId, FakeEmployeeDepartment, startsAt, endsAt);

            // Act
            double actual = CapacityCalculator.CalculateUtilizationForEmployee(resourcePlanWithFullDay);

            // Assert
            actual.ShouldEqual(50);
        }
    }
}