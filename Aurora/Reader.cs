using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Aurora
{
    public class Reader
    {
        private SqlConnection _sqlConnection;

        public Reader(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

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
