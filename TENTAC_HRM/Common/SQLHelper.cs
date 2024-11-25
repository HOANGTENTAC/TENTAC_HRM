using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM
{
    public class SQLHelper
    {
        private SqlConnection con;
        public static string sUser;
        public static string sIdUser;
        public static string GetSqlConnection()
        {
            return ConfigurationManager.AppSettings["conn_string"].ToString();
        }
        public static DataTable ExecuteDt_tr(string Sqlstr, SqlTransaction tr, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(Sqlstr, con, tr);
            DataTable dataTable = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            return dataTable;
        }
        public static int ExecuteSql(string Sqlstr)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection2;
            sqlCommand.CommandText = Sqlstr;
            sqlConnection2.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection2.Close();
            return result;
        }
        public static int ExecuteScalarSql(string Sqlstr)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection2;
            sqlCommand.CommandText = Sqlstr + ";SELECT SCOPE_IDENTITY();";
            sqlConnection2.Open();
            int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection2.Close();
            return result;
        }
        public static int ExecuteSql(string Sqlstr, SqlParameter[] param)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection2;
            sqlCommand.CommandText = Sqlstr;
            if (param != null)
            {
                foreach (SqlParameter value in param)
                {
                    sqlCommand.Parameters.Add(value);
                }
            }
            sqlConnection2.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection2.Close();
            return result;
        }
        public static int ExecuteScalarSql(string Sqlstr, SqlParameter[] param)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection2;
            sqlCommand.CommandText = Sqlstr + ";SELECT SCOPE_IDENTITY();";
            if (param != null)
            {
                foreach (SqlParameter value in param)
                {
                    sqlCommand.Parameters.Add(value);
                }
            }
            sqlConnection2.Open();
            int result = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection2.Close();
            return result;
        }
        public static string ExecuteScalar(string Sqlstr)
        {
            string result = "";
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection2;
            sqlCommand.CommandText = Sqlstr;
            sqlConnection2.Open();
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = obj.ToString();
            }
            sqlConnection2.Close();
            return result;
        }

        public static SqlDataReader ExecuteReader(string Sqlstr)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection2;
                sqlCommand.CommandText = Sqlstr;
                sqlConnection2.Open();
                return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ExecuteDt(string Sqlstr)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Sqlstr, sqlConnection2);
            DataTable dataTable = new DataTable();
            sqlConnection2.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection2.Close();
            return dataTable;
        }

        public static DataSet ExecuteDs(string Sqlstr)
        {
            string sqlConnection = GetSqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Sqlstr, sqlConnection2);
            DataSet dataSet = new DataSet();
            sqlConnection2.Open();
            sqlDataAdapter.Fill(dataSet);
            sqlConnection2.Close();
            return dataSet;
        }

        public int RunProc(string procName)
        {
            SqlCommand sqlCommand = CreateCommand(procName, null);
            sqlCommand.ExecuteNonQuery();
            Close();
            return (int)sqlCommand.Parameters["ReturnValue"].Value;
        }

        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand sqlCommand = CreateCommand(procName, prams);
            sqlCommand.ExecuteNonQuery();
            Close();
            return (int)sqlCommand.Parameters[0].Value;
        }

        public void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlCommand sqlCommand = CreateCommand(procName, null);
            dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand sqlCommand = CreateCommand(procName, prams);
            dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            Open();
            SqlCommand sqlCommand = new SqlCommand(procName, con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (SqlParameter value in prams)
                {
                    sqlCommand.Parameters.Add(value);
                }
            }
            return sqlCommand;
        }

        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            SqlParameter sqlParameter = ((Size <= 0) ? new SqlParameter(ParamName, DbType) : new SqlParameter(ParamName, DbType, Size));
            sqlParameter.Direction = Direction;
            if (Direction != ParameterDirection.Output || Value != null)
            {
                sqlParameter.Value = Value;
            }
            return sqlParameter;
        }
        public static void Procedure(string spName, List<SqlParameter> sqlParams)
        {
            try
            {
                string sqlConnection = GetSqlConnection();
                SqlConnection sqlConnection2 = new SqlConnection(sqlConnection);
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection2;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                sqlConnection2.Open();
                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        command.Parameters.Add(param);
                    }
                }
                command.ExecuteNonQuery();
                sqlConnection2.Close();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void Open()
        {
            if (con == null)
            {
                con = new SqlConnection(GetSqlConnection());
                con.Open();
            }
        }

        public void Close()
        {
            if (con != null)
            {
                con.Close();
            }
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }

        public static string rpStr(string hiki)
        {
            if (hiki == null)
            {
                return "Null";
            }
            else if (hiki == "")
            {
                return "''";
            }
            else
            {
                return "N'" + hiki.Replace("'", "''") + "'";
            }
        }

        public static string rpI(int? hiki)
        {
            string result = "";

            if (hiki == null)
            {
                result = "Null";
            }
            else
            {
                result = hiki.ToString();
            }
            return result;
        }

        public static string rpD(decimal? hiki)
        {
            string result = "";

            if (hiki == null)
            {
                result = "Null";
            }
            else
            {
                result = hiki.ToString();
            }
            return result;
        }
        public static string rpDT(DateTime? dateTimeValue)
        {
            string result = "";
            if (dateTimeValue == null)
            {
                result = "Null";
            }
            else
            {
                result = $"'{dateTimeValue:yyyy/MM/dd}'";
            }
            return result;
        }
        public static string rpDouble(double? hiki)
        {
            string result = "";

            if (hiki == null)
            {
                result = "Null";
            }
            else
            {
                result = hiki.ToString();
            }
            return result;
        }
        public static byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
