using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace TENTAC_HRM.Common
{
    internal class Provider
    {
        private SqlConnection con;

        private SqlDataAdapter da;

        private SqlCommand cmd;

        private DataSet ds;

        protected static string strConnect;

        public static string sPass;

        public static string sUser;
        public static string GetSqlConnection()
        {
            return ConfigurationManager.AppSettings["conn_string"].ToString();
        }
        public void thu(string sql, List<SqlParameter> sqlParams)
        {
            connect();
            cmd = new SqlCommand(sql, con);
            if (sqlParams != null)
            {
                foreach (SqlParameter param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }
            }
            cmd.ExecuteNonQuery();
            disconnect();
        }

        public DataTable executeNonQuerya(string spName, List<SqlParameter> sqlParams)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        command.Parameters.Add(param);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return dt;
        }

        public void Procedure(string spName, List<SqlParameter> sqlParams)
        {
            try
            {
                connect();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        command.Parameters.Add(param);
                    }
                }
                command.ExecuteNonQuery();
                disconnect();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static SqlConnection get_Connect()
        {
            strConnect = GetSqlConnection();
            //if (File.Exists("MITA.exe.config"))
            //{
            //    Configuration AppC = ConfigurationManager.OpenExeConfiguration("MITA.exe");
            //    if (AppC.AppSettings.Settings["uid"].Value.ToString().Trim() != "" && AppC.AppSettings.Settings["pwd"].Value.ToString().Trim() != "")
            //    {
            //        strConnect = "server=" + AppC.AppSettings.Settings["server"].Value.ToString() + ";database=" + AppC.AppSettings.Settings["database"].Value.ToString() + ";uid=" + AppC.AppSettings.Settings["uid"].Value.ToString() + ";pwd=" + AppC.AppSettings.Settings["pwd"].Value.ToString();
            //    }
            //    else
            //    {
            //        strConnect = "server=" + AppC.AppSettings.Settings["server"].Value.ToString() + ";database=" + AppC.AppSettings.Settings["database"].Value.ToString() + ";integrated security = true";
            //    }
            //}
            SqlConnection cn = new SqlConnection(strConnect);
            cn.Open();
            return cn;
        }

        public void connect()
        {
            if (con == null)
            {
                con = get_Connect();
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void disconnect()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataSet get(string sql)
        {
            connect();
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            disconnect();
            return ds;
        }

        public void executeNonQuery(string sql)
        {
            connect();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            disconnect();
        }
    }
}
