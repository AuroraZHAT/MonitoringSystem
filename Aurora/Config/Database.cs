using Microsoft.Data.SqlClient;
using static Aurora.Config.Database;

namespace Aurora.Config
{
    partial class Server
    {
        public partial class Database
        {
            private RegistryConfig _config = new RegistryConfig();
            public Table Table;
            public View View;

            public string ConnectionString =>
            (
                $"Data Source={_config.ServerName};" +
                $"Initial Catalog={_config.DatabaseName};" +
                $"Integrated Security={_config.IntegratedSecurity};" +
                $"TrustServerCertificate={_config.TrustServerCertificate}"
            );

            public bool ConnectionExist
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

            public void Create()
            {
                string query = $"CREATE DATABASE [{_config.DatabaseName}]";

                ExecuteQuery(query);
            }

            public void TablesCreate()
            {
                ExecuteQuery(Table.Objects);
                ExecuteQuery(Table.Interfaces);
                ExecuteQuery(Table.MapLocations);
                ExecuteQuery(Table.OperatingSystems);
                ExecuteQuery(Table.ObjectTypes);
            }

            public void ViewsCreate()
            {
                ExecuteQuery(View.Objects);
            }

            public void ExecuteQuery(string query)
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
