using Microsoft.Data.SqlClient;
using System.Data;

namespace MonitoringSystem.Forms.Database
{
    public static class AdapterExtensions
    {
        public static Task FillAsync(this SqlDataAdapter adapter, DataSet dataset, string name)
        {
            return Task.Factory.StartNew(() =>
            {
                adapter.Fill(dataset, name);
            });
        }
    }
}
