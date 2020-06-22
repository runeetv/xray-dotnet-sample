using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Amazon.XRay.Recorder.Handlers.SqlServer;

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
                //var command = new SqlCommand(commandText, conn);
                var command = new TraceableSqlCommand(commandText, conn,true);
                command.CommandType = CommandType.Text;
                var sqlReader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(sqlReader);

                //sqlReader.f
                //var dataset = new DataSet();
                //var dataAdapter = new SqlDataAdapter();
                //dataAdapter.Fill(dataset);
                //conn.Close();
                //return dataset.Tables[0];

                return dataTable;
            }
                
        }
    }
}
