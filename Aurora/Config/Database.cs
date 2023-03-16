using Microsoft.Data.SqlClient;

namespace Aurora.Config
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
                SqlConnection conn = new SqlConnection(ConnectionString);
                try
                {
                    conn.Open();
                    conn.Close();
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
            ExecuteQuery(Tables.ObjectsQuery, ConnectionString);
            ExecuteQuery(Tables.InterfacesQuery, ConnectionString);
            ExecuteQuery(Tables.LocationsQuery, ConnectionString);
            ExecuteQuery(Tables.OperatingSystemsQuery, ConnectionString);
            ExecuteQuery(Tables.ObjectTypesQuery, ConnectionString);
        }

        public static void CreateViews()
        {
            ExecuteQuery(Views.ObjectsQuery, ConnectionString);
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
