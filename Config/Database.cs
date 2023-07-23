﻿using Microsoft.Data.SqlClient;

namespace MonitoringSystem.Config
{
    public static class Database
    {
        public static string ConnectionString =>
        (
            $"Data Source={RegistryConfig.ServerName};" +
            $"Initial Catalog={RegistryConfig.DatabaseName};" +
            $"Integrated Security={RegistryConfig.IntegratedSecurity};" +
            $"TrustServerCertificate={RegistryConfig.TrustServerCertificate}"
        );

        public static bool ConnectionExist
        {
            get
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static void Create()
        {
            string query = $"CREATE DATABASE [{RegistryConfig.DatabaseName}]";

            ExecuteQuery(query, Server.ConnectionString);
        }

        public static void CreateTables()
        {
            foreach (var table in Tables.Items)
                ExecuteQuery(table.CreationQuery, ConnectionString);
        }

        public static void ExecuteQuery(string query, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
