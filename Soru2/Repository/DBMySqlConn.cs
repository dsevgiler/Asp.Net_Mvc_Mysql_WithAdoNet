using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Soru2.Repository
{
    public class DBMySqlConn
    {
        private readonly string _connectionString;
        private MySqlConnection _cnn;

        public DBMySqlConn()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["_db"].ConnectionString;
            _cnn = new MySqlConnection(_connectionString);
        }

        private MySqlConnection GetConnection()
        {
            if (_cnn.State == ConnectionState.Open)
            {
                _cnn.Close();
                _cnn.Open();
            }
            else
            {
                _cnn.Open();
            }

            return _cnn;
        }

        public void CloseConnection()
        {
            _cnn.Close();
            _cnn.Dispose();
            _cnn = null;
        }

        public MySqlCommand GetSqlCommand()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = GetConnection();
            return cmd;
        }
    }
}