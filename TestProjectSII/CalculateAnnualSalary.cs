using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSII.Models;

namespace TestProjectSII
{
    [TestClass]
    public class CalculateAnnualSalary
    {
        [TestMethod]
        public void TestCalculateAnnualSalary()
        {
            // Arrange
            var logic = new BusinessLogic();
            double monthlySalary = 2.0;

            // Act
            var annualSalary = logic.CalculateAnnualSalary(monthlySalary);

            // Assert
            Assert.AreEqual(24.0, annualSalary);
        }
    }
}
