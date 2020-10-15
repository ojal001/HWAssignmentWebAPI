using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.BusinessLogic.Interface;
using Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Test
{
    [TestClass]
    public class EmployeeDetailsControllerTests
    {

        EmployeeController employeeController;
        Mock<IEmployeeManager> employeeManager;

        [TestInitialize]
        public void Init()
        {
            employeeManager = new Mock<IEmployeeManager>();
            employeeController = new EmployeeController(employeeManager.Object);
        }

        [TestMethod]
        public void GetEmployeeSuccessTest()
        {
            int employeeId = 1;
            var emp = new EmployeeDetailsModel()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                MiddleName = "TestMiddleName",
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                DepartmentId = 1,
                EmployeeId = 20,
                IsDisabled = false
            };
            employeeManager.Setup(m => m.GetEmployeeDetails(employeeId)).Returns(emp);
            var result = employeeController.Get(employeeId);
            var assertvalues = result as OkObjectResult;
            Assert.IsNotNull(assertvalues.StatusCode == 200);
            var data = assertvalues.Value as EmployeeDetailsModel;
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void AddEmployeeSuccessTest()
        {
            var emp = new EmployeeDetailsModel()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                MiddleName = "TestMiddleName",
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                DepartmentId = 1,
                IsDisabled = false
            };
            employeeManager.Setup(m => m.AddEmployee(emp)).Returns(true);
            var result = employeeController.CreateEmployee(emp);
            var assertvalues = result as CreatedAtActionResult;
            Assert.IsNotNull(assertvalues.StatusCode == 201);
        }

        [TestMethod]
        public void UpdateEmployeeSuccessTest()
        {
            var emp = new EmployeeDetailsUpdateModel()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                MiddleName = "TestMiddleName",
                UpdatedBy = 1,
            };
            employeeManager.Setup(m => m.UpdateEmployee(emp)).Returns(true);
            var result = employeeController.UpdateEmployeeDetails(emp);
            var assertvalues = result as NoContentResult;
            Assert.IsNotNull(assertvalues.StatusCode == 204);
        }

        [TestMethod]
        public void DeleteEmployeeSuccessTest()
        {
            employeeManager.Setup(m => m.DeleteEmployee(2,123)).Returns(true);
            var result = employeeController.DeleteEmployee(2,123);
            var assertvalues = result as NoContentResult;
            Assert.IsNotNull(assertvalues.StatusCode == 204);
        }

    }
}
