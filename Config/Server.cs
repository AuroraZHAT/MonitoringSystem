using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace MonitoringSystem.Config
{
    public static class Server
    {
        public static string ConnectionString =>
        (
            $"Data Source={RegistryConfig.ServerName};" +
            $"Initial Catalog=master;" +
            $"Integrated Security={RegistryConfig.IntegratedSecurity};" +
            $"TrustServerCertificate={RegistryConfig.TrustServerCertificate}"
        );

        public static bool ConnectionExist
        {
            get
            {
                using SqlConnection conn = new(ConnectionString);

                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка подключения\nКод ошибки: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
