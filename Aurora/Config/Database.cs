using Microsoft.Data.SqlClient;

namespace Aurora.Config
{
    public static class Database
    {
        public static Table Table;
        public static View View;

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

            ExecuteQuery(query);
        }

        public static void TablesCreate()
        {
            ExecuteQuery(Table.Objects);
            ExecuteQuery(Table.Interfaces);
            ExecuteQuery(Table.MapLocations);
            ExecuteQuery(Table.OperatingSystems);
            ExecuteQuery(Table.ObjectTypes);
        }

        public static void ViewsCreate()
        {
            ExecuteQuery(View.Objects);
        }

        public static void ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
