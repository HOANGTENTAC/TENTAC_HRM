using ComponentFactory.Krypton.Toolkit;
using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Consts;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class frm_QuanLyXacNhan : KryptonForm
    {
        public int _id { get; set; }
        public int _idTrangThai {  get; set; }
        public string _year {  get; set; }
        public frm_QuanLyXacNhan()
        {
            InitializeComponent();
        }
        private void frm_QuanLyXacNhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            //string sql = $"select nv.TenNhanVien,npn.NgayNghi,npn.GhiChu " +
            //             $"from tbl_NghiPhepNam npn " +
            //             $"join MITACOSQL.dbo.NhanVien nv on nv.MaChamCong = npn.MaChamCong " +
            //             $"where npn.id = {_id}";
            string sql = $@"WITH NghiPhep AS (
            SELECT np.MaNhanVien,np.Id_TrangThai, SUM(np.SoNgay) AS TongNgayNghi FROM tbl_NghiPhepNam np
            WHERE np.del_flg = 0 AND np.LoaiPhepNghi = 'LP001' AND YEAR(np.NgayNghi) = {_year}
            GROUP BY np.MaNhanVien, np.Id_TrangThai
            )
            SELECT a.MaNhanVien, npn.NgayNghi, nv.TenNhanVien, npn.GhiChu,
                (a.TongNgayPhep - COALESCE(np.TongNgayNghi, 0)) AS SoPhepTon
            FROM tbl_NgayPhepNam a
            INNER JOIN tbl_NghiPhepNam npn on a.MaNhanVien = npn.MaNhanVien
            INNER JOIN NghiPhep np ON a.MaNhanVien = np.MaNhanVien
            INNER JOIN MITACOSQL.dbo.NhanVien nv ON nv.MaNhanVien = a.MaNhanVien
            WHERE npn.Id = {_id} AND a.del_flg = 0 AND a.Nam = {_year}";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            txt_TenNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();
            dtp_NgayNghi.Text = dt.Rows[0]["NgayNghi"].ToString();
            txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            txt_SoPhepTon.Text = dt.Rows[0]["SoPhepTon"].ToString();
        }
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            string sql = "";
            //if (LoginInfo.ChucVu == "CV00005")
            //{
            //    sql = $"update tbl_NghiPhepNam set Chk_ToTruong = 1 where id = '{_id}'";
            //}
            //else if (LoginInfo.ChucVu == "CV00004")
            //{
            //    sql = $"update tbl_NghiPhepNam set Chk_QuanLy = 1 where id = '{_id}'";
            //}
            //if (LoginInfo.LoaiUser == "HR")
            //{
            //    sql = $"update tbl_NghiPhepNam set Chk_NhanSu = 1 where id = '{_id}'";
            //}
            sql = $@"Update tbl_NghiPhepNam Set 
                NguoiXacNhan = '{(LoginInfo.Group == "HR" ? "" : LoginInfo.ReportTo)}', Id_TrangThai = {(LoginInfo.ReportTo == "" ? "199" : "198")} 
                where Id = {SQLHelper.rpI(_id)}"; 
            int res = SQLHelper.ExecuteSql(sql);
            if (res > 0)
            {
                RJMessageBox.Show("Đã xác nhận thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RJMessageBox.Show("Đã xác nhận thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btn_KhongXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LyDoTuChoi.Text))
            {
                RJMessageBox.Show("Vui lòng nhập lý do.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "";
            //if (LoginInfo.ChucVu == "ToTruong")
            //{
            //    sql = $"update tbl_NghiPhepNam set Chk_ToTruong = 0 where id = '{_id}'";
            //}
            //else if (LoginInfo.ChucVu == "QuanLy")
            //{
            //    sql = $"update tbl_NghiPhepNam set Chk_QuanLy = 0 where id = '{_id}'";
            //}
            //if (LoginInfo.LoaiUser == "HR")
            //{
            //    sql = $"update tbl_NghiPhepNam set Chk_NhanSu = 0 where id = '{_id}'";
            //}
            string reportTo = _idTrangThai == 199 ? SQLHelper.sUser : LoginInfo.ReportTo;
            sql = $@"Update tbl_NghiPhepNam Set 
                NguoiXacNhan = {SQLHelper.rpStr(reportTo)}, Id_TrangThai = 198,
                LyDoNguoiXacNhan = {SQLHelper.rpStr(txt_LyDoTuChoi.Text.TrimEnd())}
                where Id = {SQLHelper.rpI(_id)}";
            int res = SQLHelper.ExecuteSql(sql);
            if (res > 0)
            {
                RJMessageBox.Show("Đã từ chối thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RJMessageBox.Show("Đã từ chối thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
