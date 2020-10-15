using AutoMapper;
using DataAccess.Interface;
using Entities;
using Models;
using System;
using WebApplication1.BusinessLogic.Interface;

namespace WebApplication1.BusinessLogic
{
    public class EmployeeManager :IEmployeeManager
    {
        private readonly IEmployeeDetailsDA employeeDetailsDA;
        private readonly IMapper mapper;
        public EmployeeManager(IEmployeeDetailsDA employeeDetailsDA)
        {
            this.employeeDetailsDA = employeeDetailsDA;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDetailsModel, EmployeeDetails>();
                cfg.CreateMap<EmployeeDetailsUpdateModel, EmployeeUpdateEntity>();
                cfg.CreateMap<EmployeeDetails, EmployeeDetailsModel>();
            });
            mapper = config.CreateMapper();
        }

        public EmployeeDetailsModel GetEmployeeDetails(int empId)
        {
            var result = mapper.Map<EmployeeDetails,EmployeeDetailsModel>(employeeDetailsDA.GetEmployee(empId));
            return result;
        }

        public bool AddEmployee (EmployeeDetailsModel employeeDetailsModel)
        {
            var entity = mapper.Map<EmployeeDetailsModel,EmployeeDetails>(employeeDetailsModel);
            return employeeDetailsDA.AddEmployee(entity);
        }


        public bool UpdateEmployee(EmployeeDetailsUpdateModel employeeDetailsModel)
        {
            var entity = mapper.Map<EmployeeDetailsUpdateModel, EmployeeUpdateEntity>(employeeDetailsModel);
            entity.UpdatedOn = DateTime.UtcNow;
            return employeeDetailsDA.UpdateEmployee(entity);
        }

        public bool DeleteEmployee(int empId, int updatedBy)
        {
            return employeeDetailsDA.DeleteEmployee(empId,updatedBy);
        }

    }
}
