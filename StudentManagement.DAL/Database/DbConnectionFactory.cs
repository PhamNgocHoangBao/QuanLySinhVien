using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
namespace StudentManagement.DAL.Database
{
    public static class DbConnectionFactory
    {
        private static readonly string connectionString =
            @"Server=LAPTOP-RPV7OC8J\MSSQLSERVER04;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
