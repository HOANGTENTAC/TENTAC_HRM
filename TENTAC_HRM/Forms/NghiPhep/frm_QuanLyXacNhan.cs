using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Consts;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class frm_QuanLyXacNhan : Form
    {
        public string _id { get; set; }
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
            string sql = $"select nv.TenNhanVien,npn.NgayNghi,npn.GhiChu " +
                         $"from tbl_NghiPhepNam npn " +
                         $"join MITACOSQL.dbo.NhanVien nv on nv.MaChamCong = npn.MaChamCong " +
                         $"where npn.id = {_id}";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            txt_TenNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();
            dtp_NgayNghi.Text = dt.Rows[0]["NgayNghi"].ToString();
            txt_GhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
        }
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (LoginInfo.ChucVu == "CV00005")
            {
                sql = $"update tbl_NghiPhepNam set Chk_ToTruong = 1 where id = '{_id}'";
            }
            else if (LoginInfo.ChucVu == "CV00004")
            {
                sql = $"update tbl_NghiPhepNam set Chk_QuanLy = 1 where id = '{_id}'";
            }
            if (LoginInfo.LoaiUser == "HR")
            {
                sql = $"update tbl_NghiPhepNam set Chk_NhanSu = 1 where id = '{_id}'";
            }
            SQLHelper.ExecuteSql(sql);
        }

        private void btn_KhongXacNhan_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (LoginInfo.ChucVu == "ToTruong")
            {
                sql = $"update tbl_NghiPhepNam set Chk_ToTruong = 0 where id = '{_id}'";
            }
            else if (LoginInfo.ChucVu == "QuanLy")
            {
                sql = $"update tbl_NghiPhepNam set Chk_QuanLy = 0 where id = '{_id}'";
            }
            if (LoginInfo.LoaiUser == "HR")
            {
                sql = $"update tbl_NghiPhepNam set Chk_NhanSu = 0 where id = '{_id}'";
            }
            SQLHelper.ExecuteSql(sql);
        }
    }
}
