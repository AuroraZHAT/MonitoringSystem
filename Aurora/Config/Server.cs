using Microsoft.Data.SqlClient;

namespace Aurora.Config
{
    partial class Server
    {
        public Database _Database = new Database();
        public RegistryConfig Config = new RegistryConfig();

        public string ConnectionString =>
        (
            $"Data Source={Config.ServerName};" +
            $"Initial Catalog=master;" +
            $"Integrated Security={Config.IntegratedSecurity};" +
            $"TrustServerCertificate={Config.TrustServerCertificate}"
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
    }
}
