using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic.DataAccess
{
    public static class DataAccess
    {
        // Returns the database connection string
        public static string GetConnectionString(string connectionName = "DBEmployeesInfo")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        // Returns information from the database
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }

        // Returns affected rows
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }
    }
}
