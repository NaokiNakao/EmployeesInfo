using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.DataAccess;

namespace BusinessLogic.Repository
{
    public static class EmployeeRepository
    {
        public static int CreateEmployee(int employeeId, string firstName, string lastName,
            string emailAddress, string location)
        {
            EmployeeModel data = (new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Location = location
            });

            string sql = @"INSERT INTO dbo.Employee (EmployeeId, FirstName, LastName, EmailAddress, Location)
                           VALUES (@EmployeeId, @FirstName, @LastName, @EmailAddress, @Location);";

            return SqlDataAccess.InsertData(sql, data);
        }

        public static List<EmployeeModel> GetEmployees()
        {
            string sql = @"SELECT Is, EmployeeId, FirstName, LastName, EmailAddress, Location
                           FROM dbo.Employee;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static int UpdateEmployeeById(int id, int employeeId, string firstName, string lastName,
            string emailAddress, string location)
        {
            string sql = @"UPDATE dbo.Employee
                           SET
                           EmployeeId=@employeeId,
                           FirstName=@firstName,
                           LastName=@lastName,
                           EmailAddress=@emailAddress,
                           Location=@location
                           WHERE Id=@id";

            return SqlDataAccess.SaveData(sql);
        }

        public static int DeleteEmployeeById(int id)
        {
            string sql = @"DELETE FROM dbo.Employee
                           WHERE Id=@id;";

            return SqlDataAccess.SaveData(sql);
        }
    }
}
