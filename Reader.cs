using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Aurora
{
    /// <summary>
    /// Читает базу данных
    /// </summary>
    public class Reader
    {
        private SqlConnection _sqlConnection;

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
            SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            var list = new List<string>();

            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader[0].ToString());
            }
            sqlDataReader.Close();

            return list;
        }
    }
}
