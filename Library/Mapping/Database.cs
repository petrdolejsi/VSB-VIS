using System.Data;
using System.Data.SqlClient;

namespace Library.Mapping
{
    public class Database
    {
        private SqlConnection Connection { get; }
        private SqlTransaction SqlTransaction { get; set; }

        public Database()
        {
            Connection = new SqlConnection();
        }

        public bool Connect()
        {
            if (Connection.State == ConnectionState.Open) return true;
            Connection.ConnectionString = "";
            Connection.Open();
            return true;

        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            SqlTransaction.Commit();
            //Close();
        }

        public static int ExecuteNonQuery(SqlCommand command)
        {
            var rowNumber = command.ExecuteNonQuery();
            return rowNumber;
        }

        public SqlCommand CreateCommand(string strCommand)
        {
            var command = new SqlCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public static SqlDataReader Select(SqlCommand command)
        {
            var sqlReader = command.ExecuteReader();
            return sqlReader;
        }
    }
}

