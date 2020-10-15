using DataAccess.Interface;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Implementation
{
    public class EmployeeDetailsDA : IEmployeeDetailsDA
    {
        private readonly string connectionStr ;
        public EmployeeDetailsDA(IConfiguration configuration)
        {
            connectionStr = configuration.GetSection("SQLConnection").GetSection("SqlConnectionString")?.Value;
        }
        public EmployeeDetails GetEmployee(int empId)
        {
            var result = new EmployeeDetails();
            var connectionString = connectionStr;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EmployeeDetails where EmployeeId= @empId", con);
            cmd.Parameters.Add("@empId", SqlDbType.BigInt).Value = empId;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                result.EmployeeId = Convert.ToInt64(reader["EmployeeId"]);
                result.FirstName = reader["FirstName"].ToString();
                result.LastName = reader["LastName"].ToString();
                result.MiddleName = reader["MiddleName"].ToString();
                result.IsDisabled = Convert.ToBoolean(reader["IsDisabled"]);
                result.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                result.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                result.UpdatedBy = (reader["UpdatedBy"])as int?;
                result.UpdatedOn = (reader["UpdatedOn"]) as DateTime?;
                result.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
            }
            reader.Close();
            con.Close();
            return result;
        }

        public bool AddEmployee(EmployeeDetails employeeDetails)
        {
            //var result = new EmployeeDetails();
            var connectionString = connectionStr;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Insert Into EmployeeDetails(FirstName,LastName,MiddleName,CreatedBy,CreatedOn)Values(@FirstName,@LastName,@MiddleName,@CreatedBy,@CreatedOn)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@FistName", SqlDbType.NVarChar).Value = employeeDetails.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employeeDetails.LastName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = employeeDetails.MiddleName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = employeeDetails.CreatedBy;
            cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = DateTime.UtcNow;
            con.Open();
            var result =cmd.ExecuteNonQuery();
            con.Close();
            if(result > 0)
            {
                return true;
            }
            else
            return false;
        }

        public bool UpdateEmployee(EmployeeUpdateEntity employeeDetails)
        {
            //var result = new EmployeeDetails();
            var connectionString = connectionStr;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Update EmployeeDetails SET FirstNAME = @FirstName, LastName = @LastName, MiddleName =@MiddleName, UpdatedBy =@UpdateBy, UpdatedOn = @UpdatedOn where EmployeeId = @EmployeeId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("EmployeeId", SqlDbType.BigInt).Value = employeeDetails.EmployeeId;
            cmd.Parameters.Add("@FistName", SqlDbType.NVarChar).Value = employeeDetails.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employeeDetails.LastName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = employeeDetails.MiddleName;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = employeeDetails.UpdatedBy;
            cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = employeeDetails.UpdatedOn;
            con.Open();
            var result = cmd.ExecuteNonQuery();
            con.Close();
            if (result < 0)
            {
                return false;
            }
            else
                return true;
        }

        public bool DeleteEmployee(int empId,int updatedBy)
        {
            //var result = new EmployeeDetails();
            var connectionString = connectionStr;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Update EmployeeDetails SET IsDisabled = 1,UpdatedBy =@UpdateBy, UpdatedOn = @UpdatedOn where EmployeeId = @EmployeeId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@EmployeeId", SqlDbType.BigInt).Value = empId;
            cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
            cmd.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = DateTime.UtcNow;
            con.Open();
            var result = cmd.ExecuteNonQuery();
            con.Close();
            if (result < 0)
            {
                return false;
            }
            else
                return true;
        }
    }


}
