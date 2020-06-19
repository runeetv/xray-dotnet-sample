using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace blog_app.Models
{
    public class SqlHelper
    {        
        private string _connectionString;
        public SqlHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetDataTable(string commandText)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var command = new SqlCommand(commandText, conn);
                command.CommandType = CommandType.Text;
                var dataset = new DataSet();
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataset);
                conn.Close();
                return dataset.Tables[0];
            }
                
        }
    }
}
