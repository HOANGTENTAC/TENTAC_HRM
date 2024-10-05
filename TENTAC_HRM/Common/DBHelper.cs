using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TENTAC_HRM.Common
{
    internal class DBHelper
    {
        private bool connectStatus = true;

        private static SqlConnection conn = null;

        private string strServerName = "";

        private string strDatabaseName = "";

        private string strUserName = "";

        private string strPass = "";

        private string strConn;

        public bool ConnectStatus
        {
            get
            {
                return connectStatus;
            }
            set
            {
                connectStatus = value;
            }
        }

        public DBHelper()
        {
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    initConnection();
                }
            }
            catch (SqlException e)
            {
                ConnectStatus = false;
                Console.WriteLine("Can not open Connection" + e.Message);
            }
        }

        private void initConnection()
        {
            ReadXML();
            if (strUserName != "" && strPass != "")
            {
                strConn = "Server ='" + strServerName + "';Initial Catalog ='" + strDatabaseName + "';User Id='" + strUserName + "';pwd='" + strPass + "';";
            }
            else
            {
                strConn = "Server ='" + strServerName + "';Initial Catalog ='" + strDatabaseName + "';Integrated Security=true;";
            }
            conn = new SqlConnection(strConn);
            conn.Open();
            Console.WriteLine("Connection is opening");
        }

        private void ReadXML()
        {
            string xmlPath = "Config.xml";
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(xmlPath);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    strServerName = ds.Tables[0].Rows[0]["ServerName"].ToString().Trim();
                    strDatabaseName = ds.Tables[0].Rows[0]["Database"].ToString().Trim();
                    strUserName = ds.Tables[0].Rows[0]["UserName"].ToString().Trim();
                    strPass = ds.Tables[0].Rows[0]["PassWord"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                ConnectStatus = false;
                Console.WriteLine(ex.Message);
            }
        }

        public DataSet ExecuteDSQuery(string sql, List<SqlParameter> paramlist)
        {
            SqlCommand cmd = new SqlCommand();
            prepareCommand(cmd, sql, paramlist);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            return dataset;
        }

        protected void prepareCommand(SqlCommand cmd, string sql, List<SqlParameter> paramlist)
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                initConnection();
            }
            cmd.CommandTimeout = 1000;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sql;
            if (paramlist == null)
            {
                return;
            }
            foreach (SqlParameter param in paramlist)
            {
                cmd.Parameters.Add(param);
            }
        }

        public SqlDataReader ExecuteQuery(string sql)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                return reader = cmd.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Can not create Command" + e.Message);
            }
            return reader;
        }

        public SqlDataReader ExecuteQuery(string sql, List<SqlParameter> paramlist)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                prepareCommand(cmd, sql, paramlist);
                reader = cmd.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Can not create Command" + e.Message);
            }
            return reader;
        }

        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        public int ExecuteNonQuery(string sql, List<SqlParameter> paramlist)
        {
            SqlCommand cmd = new SqlCommand();
            prepareCommand(cmd, sql, paramlist);
            return cmd.ExecuteNonQuery();
        }

        public int ExecuteScalar(string sql, List<SqlParameter> paramlist)
        {
            int num = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                prepareCommand(cmd, sql, paramlist);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException e2)
            {
                Console.WriteLine("Can not create Command" + e2.Message);
                return 0;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Can not get Data" + e.Message);
                return 0;
            }
        }

        public int ExecuteScalar(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int FillDataTable(DataTable dt, string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da.Fill(dt);
        }

        public void Dispose()
        {
            if (conn != null || conn.State != 0)
            {
                conn.Close();
                ConnectStatus = false;
            }
        }
    }
}
