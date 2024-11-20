using System;
using System.Data;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class frm_SuaGioTangCa : Form
    {
        public string id_giotangca { get; set; }
        private string _machamcong;
        uc_DangKyTangCa _frm;
        public frm_SuaGioTangCa(uc_DangKyTangCa frm)
        {
            InitializeComponent();
            _frm = frm;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_ca = "SELECT D" + dtp_ngaytangca.Value.Day.ToString() + " FROM [MITACOSQL].[dbo].BangXepCa " +
                $"where Nam = '{dtp_ngaytangca.Value.Year}' and Thang = '{dtp_ngaytangca.Value.Month}' and MaChamCong = '{_machamcong}'";
                DataTable dt_ca = new DataTable();
                dt_ca = SQLHelper.ExecuteDt(sql_ca);

                if (dt_ca == null)
                {
                    RJMessageBox.Show("Ngày " + dtp_ngaytangca.Value.ToString() + " chưa đăng ký ca", "Thông báo");
                    return;
                }
                string sql_ngaynghi = $"select D" + dtp_ngaytangca.Value.Day.ToString() + $" from [MITACOSQL].[dbo].NgayNghi where Nam = '{dtp_ngaytangca.Value.Year}' and Thang = '{dtp_ngaytangca.Value.Month}'";
                DataTable dt_lichnghi = SQLHelper.ExecuteDt(sql_ngaynghi);

                string sql_calamviec = "SELECT MaCaLamViec,GioVaoLamViec,GioKetThucLamViec " +
                    "FROM [MITACOSQL].[dbo].CaLamViecNew " +
                    $"WHERE MaCaLamViec = '{(dt_ca.Rows[0][0].ToString() == "" ? "HC" : dt_ca.Rows[0][0].ToString())}'";
                DataTable dt_calamviec = SQLHelper.ExecuteDt(sql_calamviec);

                DateTime giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " 00:00:00");
                string thoigian_batdau = DateTime.Parse(dtp_giobatdau.Text).ToString("HH:mm:00");
                string thoigian_ketthuc = DateTime.Parse(dtp_gioketthuc.Text).ToString("HH:mm:00");

                int loaitangca = 0;
                if (bool.Parse(dt_lichnghi.Rows[0][0].ToString()) == true)
                {
                    loaitangca = 2;
                }
                else
                {
                    if (dt_calamviec.Rows[0][0].ToString() == "CA3" || dt_calamviec.Rows[0][0].ToString() == "CA2")
                    {
                        giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_giobatdau.Value.ToString("HH:mm:00"));
                        loaitangca = 0;
                    }
                    else if (dt_calamviec.Rows[0][0].ToString() == "CA1")
                    {
                        giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_gioketthuc.Value.ToString("HH:mm:00"));
                        loaitangca = 1;
                    }
                    else
                    {
                        if (TimeSpan.Parse(thoigian_batdau) < TimeSpan.Parse(DateTime.Parse(dt_calamviec.Rows[0][1].ToString()).ToString("HH:mm:ss")) &&
                                    TimeSpan.Parse(thoigian_ketthuc) == TimeSpan.Parse(DateTime.Parse(dt_calamviec.Rows[0][1].ToString()).ToString("HH:mm:ss")))
                        {
                            giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_giobatdau.Value.ToString("HH:mm:00"));
                            loaitangca = 0;
                        }
                        else
                        {
                            giotangca = DateTime.Parse(dtp_ngaytangca.Value.ToString("yyyy/MM/dd") + " " + dtp_gioketthuc.Value.ToString("HH:mm:00"));
                            loaitangca = 1;
                        }
                    }
                }
                string sql_check = $"Select * from [MITACOSQL].[dbo].DangKyTangCa " +
                    $"where MaChamCong = '{_machamcong}' " +
                    $"and NgayTangCa = '{giotangca.ToString("yyyy/MM/dd")}' " +
                    $"and LoaiTangCa = '{loaitangca}' " +
                    $"and Id != '{id_giotangca}'";
                DataTable dt_check = SQLHelper.ExecuteDt(sql_check);
                if (dt_check.Rows.Count > 0)
                {
                    RJMessageBox.Show("Đã đăng ký tăng ca trong khoảng thời gian này! " + Environment.NewLine + " Vui lòng kiểm tra và cập nhật lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sql = $"update [MITACOSQL].[dbo].DangKyTangCa set GioTangCa = '{giotangca.ToString("yyyy/MM/dd HH:mm:00")}', " +
                                $"LoaiTangCa = '{loaitangca}', " +
                                $"GioBatDau = '{thoigian_batdau}', " +
                                $"GioKetThuc = '{thoigian_ketthuc}' " +
                                $"where Id = '{id_giotangca}'";
                    SQLHelper.ExecuteSql(sql);

                    //_frm.btn_luyke_Click(sender, e);
                    _frm.btn_search_Click(sender, e);
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_SuaGioTangCa_Load(object sender, EventArgs e)
        {
            load_giotangca();
        }
        private void load_giotangca()
        {
            string sql = string.Format("select a.MaChamCong,a.NgayTangCa,a.GioTangCa,a.LoaiTangCa,b.TenNhanVien,a.GioBatDau,a.GioKetThuc " +
                                        "from [MITACOSQL].[dbo].DangKyTangCa a " +
                                        "join [MITACOSQL].[dbo].NHANVIEN b on a.MaChamCong = b.MaChamCong " +
                                        "where a.Id = '{0}'", id_giotangca);
            DataTable dt = new DataTable();
            dt = SQLHelper.ExecuteDt(sql);
            lb_nhanvien.Text = dt.Rows[0]["TenNhanVien"].ToString();
            dtp_ngaytangca.Text = dt.Rows[0]["NgayTangCa"].ToString();
            dtp_giobatdau.Text = dt.Rows[0]["GioBatDau"].ToString();
            dtp_gioketthuc.Text = dt.Rows[0]["GioKetThuc"].ToString();
            _machamcong = dt.Rows[0]["MaChamCong"].ToString(); ;
        }
    }
}
