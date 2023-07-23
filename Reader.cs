using Microsoft.Data.SqlClient;

namespace MonitoringSystem
{
    /// <summary>
    /// Читает базу данных
    /// </summary>
    public class Reader
    {
        private readonly SqlConnection _sqlConnection;

        public Reader(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        /// <summary>
        /// Читает все элементы по запросу и возвращает List из найженных элеиентов
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<string> ToListByQuery(string query)
        {
            SqlCommand sqlCommand = new(query, _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<string> list = new();

            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader[0].ToString());
            }
            sqlDataReader.Close();

            return list;
        }
    }
}
