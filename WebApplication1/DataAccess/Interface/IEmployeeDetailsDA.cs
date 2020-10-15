using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IEmployeeDetailsDA
    {
        EmployeeDetails GetEmployee(int empId);
        bool AddEmployee(EmployeeDetails employeeDetails);
        bool DeleteEmployee(int empId, int updatedBy);
        bool UpdateEmployee(EmployeeUpdateEntity employeeDetails);
    }
}
