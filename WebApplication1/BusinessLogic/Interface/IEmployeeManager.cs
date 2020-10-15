using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.BusinessLogic.Interface
{
    public interface IEmployeeManager
    {

        EmployeeDetailsModel GetEmployeeDetails(int empId);
        bool AddEmployee(EmployeeDetailsModel employeeDetailsModel);
        bool UpdateEmployee(EmployeeDetailsUpdateModel employeeDetailsModel);
        bool DeleteEmployee(int empId, int updatedBy);
    }
}
