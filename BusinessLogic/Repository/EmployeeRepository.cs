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
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Location = location
            };

            string sql = @"INSERT INTO dbo.Employee (EmployeeId, FirstName, LastName, EmailAddress, Location)
                           VALUES (@EmployeeId, @FirstName, @LastName, @EmailAddress, @Location);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> GetEmployees()
        {
            string sql = @"SELECT Id, EmployeeId, FirstName, LastName, EmailAddress, Location
                           FROM dbo.Employee;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static int UpdateEmployeeById(int employeeId, string firstName, string lastName,
            string emailAddress, string location)
        {
            var data = new
            {
                employeeId,
                firstName,
                lastName,
                emailAddress,
                location
            };

            string sql = @"UPDATE dbo.Employee
                           SET
                           FirstName = @FirstName,
                           LastName = @LastName,
                           EmailAddress = @EmailAddress,
                           Location = @Location
                           WHERE EmployeeId = @EmployeeId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        /*public static int DeleteEmployeeById(int employeeId)
        {
            string sql = $"DELETE FROM dbo.Employee WHERE EmployeeId = { employeeId };";

            return SqlDataAccess.SaveData(sql);
        }*/
    }
}
