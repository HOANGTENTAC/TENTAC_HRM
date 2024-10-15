using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.Common
{
    internal class CommonBLL : Provider
    {

        public void InsertTemplateVirtual(Common_model _commonDTO)
        {
            string sql = "insert into dbo.[template_virtual](ma_cham_cong,fingeridvirtual,flagvirtual,fingertemplatevirtual,fingerversionvirtual) " +
                "values('"+_commonDTO.MaChamCong+"','"+ _commonDTO .FingerIDVirtual+ "','"+_commonDTO.FlagVirtual+"','"+_commonDTO.FingerTemplateVirtual+"','"+_commonDTO.FingerVersionVirtual+"')";
            SQLHelper.ExecuteSql(sql);
        }
        public void InsertNhanVienVirtual(int machamcong)
        {
            string sql = "insert into dbo.[nhanvien_virtual](MaChamCong) values('" + machamcong + "')";
            SQLHelper.ExecuteSql(sql);
        }
        public DataTable SelectTemplateVirtualByMaChamCong(int machamcong)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", machamcong));
            return executeNonQuerya("NhanVienVirtual_selectTemplateByMaChamCong", _sqlParameter);
        }

        public void DeleteALLTemplateVirtual()
        {
            string sql = "delete dbo.[template_virtual]";
            SQLHelper.ExecuteSql(sql);
        }

        public void DeleteAllNhanVienVirtual()
        {
            string sql = "delete dbo.[nhanvien_virtual]";
            SQLHelper.ExecuteSql(sql);
        }

        public DataTable NhanVienVirtualSelectAll()
        {
            return SQLHelper.ExecuteDt("select * from  dbo.[nhanvien_virtual]");
        }

        public DataTable TemplateVirtualSelectAll()
        {
            return SQLHelper.ExecuteDt("select * from  dbo.[TemplateVirtual]");
        }
    }
}
