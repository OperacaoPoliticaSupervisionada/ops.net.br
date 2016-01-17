using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace AuditoriaParlamentar
{
    internal class Banco : IDisposable
    {
        private Boolean mBeginTransaction;
        private MySqlConnection mConnection;
        private MySqlTransaction mTransaction;

        private List<MySqlParameter> mParametros;

        internal Banco()
        {
            String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ToString();

            mParametros = new List<MySqlParameter>();
            mConnection = new MySqlConnection(connStr);
            mConnection.Open();

            //ExecuteNonQuery("set @@session.time_zone = '-02:00'"); //Horário de verão
            ExecuteNonQuery("set @@session.time_zone = '-03:00'");

            mBeginTransaction = false;
        }

        internal Int64 Rows { get; set; }
        internal Int64 LastInsertedId { get; set; }

        internal Boolean ExecuteNonQuery(String sql, Int32 timeOut = 60)
        {
            using (MySqlCommand command = mConnection.CreateCommand())
            {
                if (mBeginTransaction)
                    command.Transaction = mTransaction;

                if (mParametros.Count > 0)
                {
                    command.Parameters.AddRange(mParametros.ToArray());
                    mParametros.Clear();
                }

                command.CommandText = sql;
                command.CommandTimeout = timeOut;

                Rows = command.ExecuteNonQuery();

                LastInsertedId = command.LastInsertedId;
            }

            return true;
        }

        internal Object ExecuteScalar(String sql, Int32 timeOut = 60)
        {
            Object retorno = null;

            using (MySqlCommand command = mConnection.CreateCommand())
            {
                if (mBeginTransaction)
                    command.Transaction = mTransaction;

                if (mParametros.Count > 0)
                {
                    command.Parameters.AddRange(mParametros.ToArray());
                    mParametros.Clear();
                }

                command.CommandText = sql;
                command.CommandTimeout = timeOut;

                retorno = command.ExecuteScalar();
            }

            return retorno;
        }

        internal MySqlDataReader ExecuteReader(String sql, Int32 timeOut = 60)
        {
            MySqlDataReader reader;

            using (MySqlCommand command = mConnection.CreateCommand())
            {
                if (mBeginTransaction)
                    command.Transaction = mTransaction;

                if (mParametros.Count > 0)
                {
                    command.Parameters.AddRange(mParametros.ToArray());
                    mParametros.Clear();
                }

                command.CommandText = sql;
                command.CommandTimeout = timeOut;

                reader = command.ExecuteReader();
            }

            return reader;
        }

        internal DataTable GetTable(String sql, Int32 timeOut = 60)
        {
            DataTable table = null;

            using (MySqlCommand command = mConnection.CreateCommand())
            {
                if (mBeginTransaction)
                    command.Transaction = mTransaction;

                if (mParametros.Count > 0)
                {
                    command.Parameters.AddRange(mParametros.ToArray());
                    mParametros.Clear();
                }

                command.CommandText = sql;
                command.CommandTimeout = timeOut;

                using (MySqlDataAdapter adaper = new MySqlDataAdapter(command))
                {
                    using (DataSet data = new DataSet())
                    {
                        data.EnforceConstraints = false;
                        adaper.Fill(data);
                        table = data.Tables[0];
                    }
                }
            }

            return table;
        }

        internal void BeginTransaction()
        {
            mBeginTransaction = true;
            mTransaction = mConnection.BeginTransaction();
        }

        internal void CommitTransaction()
        {
            mBeginTransaction = false;

            try
            {
                mTransaction.Commit();
            }
            catch
            {
                mTransaction.Rollback();
            }
        }

        internal void RollBackTransaction()
        {
            mBeginTransaction = false;
            mTransaction.Rollback();
        }

        internal void AddParameter(String name, Object value)
        {
            mParametros.Add(new MySqlParameter(name, value));
        }

        public void Dispose()
        {
            try
            {
                if (mBeginTransaction)
                {
                    mTransaction.Rollback();
                }
            }
            catch { }

            mConnection.Close();
            mConnection.Dispose();
            mConnection = null;
        }
    }
}