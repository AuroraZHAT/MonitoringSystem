
namespace Aurora
{
    using Microsoft.Data.SqlClient;
    static internal class Class
    {
        public static string TableName;

        public static string DataBasePath
        {
            get { return "Data Source=DESKTOP-C4FVIA1\\SQLEXPRESS;Initial Catalog=Aurora;Integrated Security=True;TrustServerCertificate=true"; }
        }

        public static SqlConnection DataBaseConnection = new SqlConnection(DataBasePath);
    }
}
