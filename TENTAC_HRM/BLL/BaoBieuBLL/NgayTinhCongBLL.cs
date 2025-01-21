using System.Data;
using TENTAC_HRM.Models;

namespace TENTAC_HRM.BLL.BaoBieuBLL
{
    internal class NgayTinhCongBLL
    {
        public void Insert_NgayTinhCong(NgayTinhCongModel _ngayTinhCongDTO)
        {
            string sql = "insert into MITACOSQL.dbo.[ngaytinhcong](id,ngaybatdau,ngayketthuc) values('" + _ngayTinhCongDTO.ID + "','" + _ngayTinhCongDTO.NgayBatDau + "','" + _ngayTinhCongDTO.NgayKetThuc + "')";
            SQLHelper.ExecuteSql(sql);
        }

        public void Update_NgayTinhCong(NgayTinhCongModel _ngayTinhCongDTO)
        {
            string sql = "update MITACOSQL.dbo.[ngaytinhcong] set id='" + _ngayTinhCongDTO.ID + "',ngaybatdau='" + _ngayTinhCongDTO.NgayBatDau + "',ngayketthuc='" + _ngayTinhCongDTO.NgayKetThuc + "' " +
                "where id = '" + _ngayTinhCongDTO.ID + "'";
            SQLHelper.ExecuteSql(sql);
        }

        public DataTable showThongTinNgayTinhCong()
        {
            return SQLHelper.ExecuteDt("select * from MITACOSQL.dbo.[ngaytinhcong]");
        }

        public DataTable showLoadNgayTinhCong(int id)
        {
            return SQLHelper.ExecuteDt("select * from MITACOSQL.dbo.[ngaytinhcong] where id = '" + id + "'");
        }
    }
}
