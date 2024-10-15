using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.Chart_Management
{
    public partial class uc_cong_ty : UserControl
    {
        private int id_congty;
        public static uc_cong_ty _instance;
        public static uc_cong_ty Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_cong_ty();
                return _instance;
            }
        }
        public uc_cong_ty()
        {
            InitializeComponent();
        }
        public byte[] Picbyte { get; set; }
        private void btn_updata_Click(object sender, System.EventArgs e)
        {
            Picbyte = null;
            if (pb_image.Image != null)
            {
                MemoryStream ms;
                ms = new MemoryStream();
                pb_image.Image.Save(ms, ImageFormat.Png);
                Picbyte = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(Picbyte, 0, Picbyte.Length);
            }
            string sql = "update thong_tin_cong_ty set ten_cong_ty = @ten_cong_ty,dia_chi =@dia_chi,dien_thoai = @dien_thoai," +
                "so_fax = @so_fax,ma_so_thue = @ma_so_thue,wesite = @wesite,email = @email,image=@image " +
                "where id_cong_ty = @id_cong_ty";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id_cong_ty", SqlDbType.Int) {Value = id_congty},
                new SqlParameter("@ten_cong_ty", SqlDbType.NVarChar) {Value = txt_ten_cong_ty.Text},
                new SqlParameter("@dia_chi", SqlDbType.NVarChar) {Value = txt_dia_chi.Text},
                new SqlParameter("@dien_thoai", SqlDbType.VarChar) {Value = txt_dien_thoai.Text},
                new SqlParameter("@so_fax", SqlDbType.VarChar) {Value = txt_so_fax.Text},
                new SqlParameter("@ma_so_thue", SqlDbType.VarChar) {Value = txt_ma_so_thue.Text},
                new SqlParameter("@wesite", SqlDbType.NVarChar) {Value = txt_website.Text},
                new SqlParameter("@email", SqlDbType.VarChar) {Value = txt_email.Text},
                new SqlParameter("@image", SqlDbType.Image) {Value = (Picbyte == null ? (object)DBNull.Value : Picbyte)},
            };
            if (SQLHelper.ExecuteSql(sql, param) == 1)
            {
                RJMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uc_cong_ty_Load(object sender, System.EventArgs e)
        {
            string sql = "SELECT * FROM thong_tin_cong_ty";
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                id_congty = int.Parse(dt.Rows[0]["id_cong_ty"].ToString());
                txt_ten_cong_ty.Text = dt.Rows[0]["ten_cong_ty"].ToString();
                txt_dia_chi.Text = dt.Rows[0]["dia_chi"].ToString();
                txt_dien_thoai.Text = dt.Rows[0]["dien_thoai"].ToString();
                txt_so_fax.Text = dt.Rows[0]["so_fax"].ToString();
                txt_ma_so_thue.Text = dt.Rows[0]["ma_so_thue"].ToString();
                txt_website.Text = dt.Rows[0]["website"].ToString();
                txt_email.Text = dt.Rows[0]["email"].ToString();

                if (!string.IsNullOrEmpty(dt.Rows[0]["image"].ToString()))
                {
                    Byte[] byteanh_nv = new Byte[0];
                    byteanh_nv = (Byte[])(dt.Rows[0]["hinh_anh"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteanh_nv);
                    pb_image.Image = Image.FromStream(stmBLOBData);
                }
                else
                {
                    pb_image.Image = null;
                }
            }
        }
    }
}
