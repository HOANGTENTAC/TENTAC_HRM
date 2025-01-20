using System.Data;
using TENTAC_HRM.Models;

namespace TENTAC_HRM.Common
{
    internal class TemplateCapNhatVanTayBLL
    {
        public void TemplateCapNhatVanTayInsert(TemplateCapNhatVanTay_model data)
        {
            string sql = "insert into dbo.[template_capnhatvantay](ma_cham_cong,fingerid_capnhatvantay,flag_capnhatvantay,fingertemplate_capnhatvantay,fingerversion_capnhatvantay) " +
                "values('" + data.MaChamCong + "','" + data.FingerIDCapNhatVanTay + "','" + data.FlagCapNhatVanTay + "','" + data.FingerTemplateCapNhatVanTay + "','" + data.FingerVersionCapNhatVanTay + "')";
            SQLHelper.ExecuteSql(sql);
        }

        public void TemplateCapNhatVanTayDeleteAll()
        {
            string sql = "delete template_capnhatvantay";
            SQLHelper.ExecuteSql(sql);
        }

        public DataTable TemplateCapNhatVanTayGetByMaChamCong(int machamcong)
        {
            string sql = "select * from template_capnhatvantay where (ma_cham_cong = '" + machamcong + "')";
            return SQLHelper.ExecuteDt(sql);
        }
        public DataTable NhanVienUpdateGetByMaChamCong(int machamcong)
        {
            return SQLHelper.ExecuteDt($"select * from  dbo.[NhanVienUpdate] where ('{machamcong}'=dbo.[NhanVienUpdate].MaChamCong)");
        }
    }
}
