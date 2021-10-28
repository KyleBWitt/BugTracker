using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BugTracker2.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString()
        {
            return "Server=localhost;Database=master;Trusted_Connection=True;";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }
        
    }
}
