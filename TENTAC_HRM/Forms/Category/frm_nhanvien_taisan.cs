using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Model;
using TENTAC_HRM.Properties;
using TENTAC_HRM.Forms.Search;
using TENTAC_HRM.Forms.User_control;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_nhanvien_taisan : Form
    {
        public bool edit { get; set; }
        public string _ma_nhan_vien { get; set; }
        public int _id_nhanvien_taisan { get; set; }
        public string id_thanhphan1 { get; set; }
        public string id_thanhphan2 { get; set; }
        public string id_thanhphan3 { get; set; }
        public string id_thanhphan4 { get; set; }
        public string id_thanhphan5 { get; set; }
        DataProvider provider = new DataProvider();
        Nhanvien_Taisan_model nhanvien_taisan_model = new Nhanvien_Taisan_model();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        protected override void OnLoad(EventArgs e)
        {
            var btn = new Button();
            btn.Size = new Size(25, txt_thanhphan1.ClientSize.Height + 2);
            btn.Location = new Point(txt_thanhphan1.ClientSize.Width - btn.Width, -1);
            btn.Cursor = Cursors.Default;
            btn.Image = Resources.clear_button;
            btn.FlatStyle = FlatStyle.Flat;
            txt_thanhphan1.Controls.Add(btn);
            SendMessage(txt_thanhphan1.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));

            var btn2 = new Button();
            btn2.Size = new Size(25, txt_thanhphan2.ClientSize.Height + 2);
            btn2.Location = new Point(txt_thanhphan2.ClientSize.Width - btn2.Width, -1);
            btn2.Cursor = Cursors.Default;
            btn2.Image = Resources.clear_button;
            btn2.FlatStyle = FlatStyle.Flat;
            txt_thanhphan2.Controls.Add(btn2);
            SendMessage(txt_thanhphan2.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn2.Width << 16));

            var btn3 = new Button();
            btn3.Size = new Size(25, txt_thanhphan3.ClientSize.Height + 2);
            btn3.Location = new Point(txt_thanhphan3.ClientSize.Width - btn3.Width, -1);
            btn3.Cursor = Cursors.Default;
            btn3.Image = Resources.clear_button;
            btn3.FlatStyle = FlatStyle.Flat;
            txt_thanhphan3.Controls.Add(btn3);
            SendMessage(txt_thanhphan3.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn3.Width << 16));

            var btn4 = new Button();
            btn4.Size = new Size(25, txt_thanhphan4.ClientSize.Height + 2);
            btn4.Location = new Point(txt_thanhphan4.ClientSize.Width - btn4.Width, -1);
            btn4.Cursor = Cursors.Default;
            btn4.Image = Resources.clear_button;
            btn4.FlatStyle = FlatStyle.Flat;
            txt_thanhphan4.Controls.Add(btn4);
            SendMessage(txt_thanhphan4.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn4.Width << 16));

            var btn5 = new Button();
            btn5.Size = new Size(25, txt_thanhphan5.ClientSize.Height + 2);
            btn5.Location = new Point(txt_thanhphan5.ClientSize.Width - btn5.Width, -1);
            btn5.Cursor = Cursors.Default;
            btn5.Image = Resources.clear_button;
            btn5.FlatStyle = FlatStyle.Flat;
            txt_thanhphan5.Controls.Add(btn5);
            SendMessage(txt_thanhphan5.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn5.Width << 16));
            base.OnLoad(e);

            btn.Click += btn_Click;
            btn2.Click += btn2_Click;
            btn3.Click += btn3_Click;
            btn4.Click += btn4_Click;
            btn5.Click += btn5_Click;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            txt_thanhphan1.ResetText();
            txt_chucvu1.ResetText();
            id_thanhphan1 = "";
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            txt_thanhphan2.ResetText();
            txt_chucvu2.ResetText();
            id_thanhphan2 = "";
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            txt_thanhphan3.ResetText();
            txt_chucvu3.ResetText();
            id_thanhphan3 = "";
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            txt_thanhphan4.ResetText();
            txt_chucvu4.ResetText();
            id_thanhphan4 = "";
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            txt_thanhphan5.ResetText();
            txt_chucvu5.ResetText();
            id_thanhphan5 = "";
        }
        frm_personnel _Personnel;
        uc_quatrinh_lamviec _quatrinh;
        public frm_nhanvien_taisan(Form form, UserControl user)
        {
            InitializeComponent();
            _quatrinh = (uc_quatrinh_lamviec)user;
            _Personnel = (frm_personnel)form;
        }

        private void frm_nhanvien_taisan_Load(object sender, EventArgs e)
        {
            load_hientrang();
            load_trangthai();
            load_cty();
            load_bophan();
            load_chucvu();
            load_nhanvien();
            if (edit == true)
            {
                btn_save.Text = "Cập nhật";
                btn_xoa_taisan.Enabled = false;
                load_data();
            }
        }
        private void load_chucvu()
        {
            cbo_chucvu.DataSource = provider.load_chuc_vu();
            cbo_chucvu.DisplayMember = "name";
            cbo_chucvu.ValueMember = "id";
        }
        private void load_hientrang()
        {
            hien_trang.DataSource = provider.load_all_type(164);
            hien_trang.DisplayMember = "name";
            hien_trang.ValueMember = "id";
        }
        private void load_trangthai()
        {
            cbo_trangthai.DataSource = provider.load_all_type(170);
            cbo_trangthai.DisplayMember = "name";
            cbo_trangthai.ValueMember = "id";
        }
        private void load_data()
        {
            string sql = string.Format("select * from nhanvien_taisan where id_nhanvien_taisan = '{0}'", _id_nhanvien_taisan);
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dtp_tungay.Text = dt.Rows[0]["tu_ngay"].ToString();
                dtp_denngay.Text = dt.Rows[0]["den_ngay"].ToString();
                txt_sophieu.Text = dt.Rows[0]["so_phieu"].ToString();
                dtp_ngayvaoso.Text = dt.Rows[0]["ngay_vao_so"].ToString();
                cbo_trangthai.SelectedValue = dt.Rows[0]["trang_thai"].ToString();
                cbo_quytrinh.SelectedValue = dt.Rows[0]["quy_trinh"].ToString();
                cbo_kho.SelectedValue = dt.Rows[0]["kho"].ToString();
                cbo_ke.SelectedValue = dt.Rows[0]["ke"].ToString();
                txt_diengiai.Texts = dt.Rows[0]["dien_giai"].ToString();
                txt_ghichu.Text = dt.Rows[0]["ghi_chu"].ToString();
                cbo_donvi.SelectedValue = dt.Rows[0]["ma_don_vi"].ToString();
                cbo_khuvuc.SelectedValue = dt.Rows[0]["ma_khu_vuc"].ToString();
                cbo_phongban.SelectedValue = dt.Rows[0]["ma_phong_ban"].ToString();
                cbo_chucvu.SelectedValue = dt.Rows[0]["ma_chuc_vu"].ToString();
                txt_thanhphan1.Text = dt.Rows[0]["thanh_phan1"].ToString();
                txt_chucvu1.Text = dt.Rows[0]["chuc_vu1"].ToString();
                txt_daidien1.Text = dt.Rows[0]["dai_dien1"].ToString();
                txt_thanhphan2.Text = dt.Rows[0]["thanh_phan2"].ToString();
                txt_chucvu2.Text = dt.Rows[0]["chuc_vu2"].ToString();
                txt_daidien2.Text = dt.Rows[0]["dai_dien2"].ToString();
                txt_thanhphan3.Text = dt.Rows[0]["thanh_phan3"].ToString();
                txt_chucvu3.Text = dt.Rows[0]["chuc_vu3"].ToString();
                txt_daidien3.Text = dt.Rows[0]["dai_dien3"].ToString();
                txt_thanhphan4.Text = dt.Rows[0]["thanh_phan4"].ToString();
                txt_chucvu4.Text = dt.Rows[0]["chuc_vu4"].ToString();
                txt_daidien4.Text = dt.Rows[0]["dai_dien4"].ToString();
                txt_thanhphan5.Text = dt.Rows[0]["thanh_phan5"].ToString();
                txt_chucvu5.Text = dt.Rows[0]["chuc_vu5"].ToString();
                txt_daidien5.Text = dt.Rows[0]["dai_dien5"].ToString();

                string sql_taisan = string.Format("select a.id_tai_san,b.ma_tai_san,ten_tai_san,a.hien_trang,a.so_luong,a.ghi_chu " +
                    "from tai_san a " +
                    "join danhmuc_taisan b on a.id_tai_san = b.id_tai_san " +
                    "where id_nhanvien_taisan = '{0}'", dt.Rows[0]["id_nhanvien_taisan"].ToString());
                DataTable dt_taisan = SQLHelper.ExecuteDt(sql_taisan);
                foreach (DataRow dr in dt_taisan.Rows)
                {
                    dgv_taisan.Rows.Add(dr["id_tai_san"].ToString(), dr["ma_tai_san"].ToString(), dr["ten_tai_san"].ToString(), int.Parse(dr["hien_trang"].ToString()), dr["so_luong"].ToString(), dr["ghi_chu"].ToString());
                }
            }
        }
        private void load_nhanvien()
        {
            cbo_nhanvien.DataSource = provider.load_nhanvien();
            cbo_nhanvien.DisplayMember = "name";
            cbo_nhanvien.ValueMember = "value";
            cbo_nhanvien.SelectedValue = _ma_nhan_vien;
        }
        private void load_cty()
        {
            cbo_donvi.DataSource = provider.load_treeview(1);
            cbo_donvi.DisplayMember = "name";
            cbo_donvi.ValueMember = "id";
        }
        private void load_bophan()
        {
            cbo_chucvu.DataSource = provider.load_treeview(3);
            cbo_chucvu.DisplayMember = "name";
            cbo_chucvu.ValueMember = "id";
        }

        private void btn_them_taisan_Click(object sender, EventArgs e)
        {
            string taisan_tontai = "";
            frm_tai_san frm = new frm_tai_san();
            frm.ShowDialog();
            if (dgv_taisan.Rows.Count > 0)
            {
                foreach (var item in frm.list_taisan)
                {
                    foreach (DataGridViewRow item1 in dgv_taisan.Rows)
                    {
                        if (item.id_tai_san == int.Parse(item1.Cells["id_tai_san"].Value.ToString()))
                        {
                            taisan_tontai += item.ten_tai_san;
                            break;
                        }
                        else
                        {
                            dgv_taisan.Rows.Add(item.id_tai_san, item.ma_tai_san, item.ten_tai_san, 166, 1, "");
                        }
                    }
                }
            }
            else
            {
                foreach (var item in frm.list_taisan)
                {
                    dgv_taisan.Rows.Add(item.id_tai_san, item.ma_tai_san, item.ten_tai_san, 166, 1, "");
                }
            }

            if (!string.IsNullOrEmpty(taisan_tontai))
            {
                RJMessageBox.Show("Tài sản " + taisan_tontai + " đã có trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_xoa_taisan_Click(object sender, EventArgs e)
        {
            if (dgv_taisan.CurrentRow != null)
            {
                dgv_taisan.Rows.Remove(dgv_taisan.CurrentRow);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            set_value_text();
            if (edit == true)
            {
                update_data();
            }
            else
            {
                save_data();
            }

            _Personnel.LoadNhanVienThaiSan();
        }
        public void set_value_text()
        {
            nhanvien_taisan_model.so_phieu = txt_sophieu.Text;
            nhanvien_taisan_model.ngay_vao_so = dtp_ngayvaoso.Text == " " ? "" : DateTime.Parse(dtp_ngayvaoso.Text).ToString("yyyy/MM/dd");
            nhanvien_taisan_model.tu_ngay = dtp_tungay.Text == " " ? "" : DateTime.Parse(dtp_tungay.Text).ToString("yyyy/MM/dd");
            nhanvien_taisan_model.den_ngay = dtp_denngay.Text == " " ? "" : DateTime.Parse(dtp_denngay.Text).ToString("yyyy/MM/dd");
            nhanvien_taisan_model.trang_thai = int.Parse(cbo_trangthai.SelectedValue.ToString());
            nhanvien_taisan_model.quy_trinh = int.Parse(cbo_quytrinh.SelectedValue == null ? "0" : cbo_quytrinh.SelectedValue.ToString());
            nhanvien_taisan_model.kho = int.Parse(cbo_kho.SelectedValue == null ? "0" : cbo_kho.SelectedValue.ToString());
            nhanvien_taisan_model.ke = int.Parse(cbo_ke.SelectedValue == null ? "0" : cbo_ke.SelectedValue.ToString());
            nhanvien_taisan_model.dien_giai = txt_diengiai.Text;
            nhanvien_taisan_model.ghi_chu = txt_ghichu.Text;
            nhanvien_taisan_model.ma_donvi = cbo_donvi.SelectedValue == null ? "" : cbo_donvi.SelectedValue.ToString();
            nhanvien_taisan_model.ma_khuvuc = cbo_khuvuc.SelectedValue == null ? "" : cbo_khuvuc.SelectedValue.ToString();
            nhanvien_taisan_model.ma_phongban = cbo_phongban.SelectedValue == null ? "" : cbo_phongban.SelectedValue.ToString();
            nhanvien_taisan_model.ma_chucvu = cbo_chucvu.SelectedValue == null ? "" : cbo_chucvu.SelectedValue.ToString();
            nhanvien_taisan_model.thanh_phan1 = txt_thanhphan1.Text;
            nhanvien_taisan_model.chuc_vu1 = txt_chucvu1.Text;
            nhanvien_taisan_model.dai_dien1 = txt_daidien1.Text;
            nhanvien_taisan_model.thanh_phan2 = txt_thanhphan2.Text;
            nhanvien_taisan_model.chuc_vu2 = txt_chucvu2.Text;
            nhanvien_taisan_model.dai_dien2 = txt_daidien2.Text;
            nhanvien_taisan_model.thanh_phan3 = txt_thanhphan3.Text;
            nhanvien_taisan_model.chuc_vu3 = txt_chucvu3.Text;
            nhanvien_taisan_model.dai_dien3 = txt_daidien3.Text;
            nhanvien_taisan_model.thanh_phan4 = txt_thanhphan4.Text;
            nhanvien_taisan_model.chuc_vu4 = txt_chucvu4.Text;
            nhanvien_taisan_model.dai_dien4 = txt_daidien4.Text;
            nhanvien_taisan_model.thanh_phan5 = txt_thanhphan5.Text;
            nhanvien_taisan_model.chuc_vu5 = txt_chucvu5.Text;
            nhanvien_taisan_model.dai_dien5 = txt_daidien5.Text;
        }
        public void save_data()
        {
            try
            {
                string sql = string.Format("insert into nhanvien_taisan(ma_nhan_vien,so_phieu,ngay_vao_so,tu_ngay,den_ngay,trang_thai," +
                    "quy_trinh,kho,ke,dien_giai,ghi_chu,ma_don_vi,ma_khu_vuc,ma_phong_ban,ma_chuc_vu," +
                    "thanh_phan1,chuc_vu1,dai_dien1,thanh_phan2,chuc_vu2,dai_dien2,thanh_phan3,chuc_vu3,dai_dien3," +
                    "thanh_phan4,chuc_vu4,dai_dien4,thanh_phan5,chuc_vu5,dai_dien5,ngay_tao,id_nguoi_tao,del_flg) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}'," +
                    "'{6}','{7}','{8}',N'{9}',N'{10}','{11}','{12}','{13}','{14}'," +
                    "'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}'," +
                    "'{24}','{25}','{26}','{27}','{28}','{29}',GETDATE(),'{30}',0)",
                    _ma_nhan_vien, nhanvien_taisan_model.so_phieu, nhanvien_taisan_model.ngay_vao_so, nhanvien_taisan_model.tu_ngay, nhanvien_taisan_model.den_ngay, nhanvien_taisan_model.trang_thai,
                    nhanvien_taisan_model.quy_trinh, nhanvien_taisan_model.kho, nhanvien_taisan_model.ke, nhanvien_taisan_model.dien_giai, nhanvien_taisan_model.ghi_chu, nhanvien_taisan_model.ma_donvi, nhanvien_taisan_model.ma_khuvuc, nhanvien_taisan_model.ma_phongban, nhanvien_taisan_model.ma_chucvu,
                    nhanvien_taisan_model.thanh_phan1, nhanvien_taisan_model.chuc_vu1, nhanvien_taisan_model.dai_dien1, nhanvien_taisan_model.thanh_phan2, nhanvien_taisan_model.chuc_vu2, nhanvien_taisan_model.dai_dien2, nhanvien_taisan_model.thanh_phan3, nhanvien_taisan_model.chuc_vu3, nhanvien_taisan_model.dai_dien3,
                    nhanvien_taisan_model.thanh_phan4, nhanvien_taisan_model.chuc_vu4, nhanvien_taisan_model.dai_dien4, nhanvien_taisan_model.thanh_phan5, nhanvien_taisan_model.chuc_vu5, nhanvien_taisan_model.dai_dien5, SQLHelper.sIdUser);
                int id_nhanvien_taisan_new = SQLHelper.ExecuteScalarSql(sql);
                if (id_nhanvien_taisan_new != 0)
                {

                    foreach (DataGridViewRow item in dgv_taisan.Rows)
                    {
                        string sql_taisan = string.Format("insert into tai_san(id_tai_san,id_nhanvien_taisan,hien_trang," +
                                            "so_luong,ghi_chu,ngay_tao,id_nguoi_tao,del_flg) " +
                                            "values('{0}','{1}','{2}','{3}',N'{4}',GETDATE(),'{5}',0)",
                                            item.Cells["id_tai_san"].Value.ToString(), id_nhanvien_taisan_new, item.Cells["hien_trang"].Value,
                                            item.Cells["so_luong"].Value.ToString(), item.Cells["ghi_chu"].Value.ToString(), SQLHelper.sIdUser);
                        SQLHelper.ExecuteSql(sql_taisan);
                    }
                    RJMessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void update_data()
        {
            try
            {
                string sql = string.Format("update nhanvien_taisan set so_phieu = '{1}',ngay_vao_so = '{2}',tu_ngay='{3}',den_ngay='{4}'," +
                    "trang_thai ='{5}', quy_trinh ='{6}',kho='{7}',ke ='{8}',dien_giai=N'{9}',ghi_chu=N'{10}'," +
                    "ma_don_vi='{11}',ma_khu_vuc='{12}',ma_phong_ban='{13}',ma_chuc_vu='{14}'," +
                    "thanh_phan1='{15}',chuc_vu1='{16}',dai_dien1='{17}',thanh_phan2='{18}',chuc_vu2='{19}',dai_dien2='{20}'," +
                    "thanh_phan3='{21}',chuc_vu3='{22}',dai_dien3='{23}',thanh_phan4='{24}',chuc_vu4='{25}',dai_dien4='{26}'," +
                    "thanh_phan5='{27}',chuc_vu5='{28}',dai_dien5='{29}',ngay_cap_nhat = GETDATE() " +
                    "where id_nhanvien_taisan = '{0}'",
                    _id_nhanvien_taisan, nhanvien_taisan_model.so_phieu, nhanvien_taisan_model.ngay_vao_so, nhanvien_taisan_model.tu_ngay, nhanvien_taisan_model.den_ngay,
                    nhanvien_taisan_model.trang_thai, nhanvien_taisan_model.quy_trinh, nhanvien_taisan_model.kho, nhanvien_taisan_model.ke, nhanvien_taisan_model.dien_giai, nhanvien_taisan_model.ghi_chu,
                    nhanvien_taisan_model.ma_donvi, nhanvien_taisan_model.ma_khuvuc, nhanvien_taisan_model.ma_phongban, nhanvien_taisan_model.ma_chucvu,
                    nhanvien_taisan_model.thanh_phan1, nhanvien_taisan_model.chuc_vu1, nhanvien_taisan_model.dai_dien1, nhanvien_taisan_model.thanh_phan2, nhanvien_taisan_model.chuc_vu2, nhanvien_taisan_model.dai_dien2,
                    nhanvien_taisan_model.thanh_phan3, nhanvien_taisan_model.chuc_vu3, nhanvien_taisan_model.dai_dien3, nhanvien_taisan_model.thanh_phan4, nhanvien_taisan_model.chuc_vu4, nhanvien_taisan_model.dai_dien4,
                    nhanvien_taisan_model.thanh_phan5, nhanvien_taisan_model.chuc_vu5, nhanvien_taisan_model.dai_dien5
                    );
                if (SQLHelper.ExecuteSql(sql) == 1)
                {
                    foreach (DataGridViewRow item in dgv_taisan.Rows)
                    {
                        string sql_taisan = string.Format("Execute update_taisan '{0}','{1}','{2}','{3}',N'{4}','{5}'",
                            item.Cells["id_tai_san"].Value, _id_nhanvien_taisan,
                            item.Cells["hien_trang"].Value, item.Cells["so_luong"].Value,
                            item.Cells["ghi_chu"].Value, SQLHelper.sIdUser);
                        SQLHelper.ExecuteSql(sql_taisan);
                    }
                    RJMessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtp_tungay_ValueChanged(object sender, EventArgs e)
        {
            dtp_tungay.CustomFormat = "yyyy/MM/dd";
        }

        private void dtp_tungay_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || e.KeyCode == Keys.Delete)
            {
                dtp_tungay.CustomFormat = " ";
            }
        }
        private void btn_search_thanhphan1_Click(object sender, EventArgs e)
        {
            frm_serach_nhanvien frm = new frm_serach_nhanvien();
            frm.ShowDialog();
            txt_thanhphan1.Text = frm.ten_nhanvien.ToString();
            txt_chucvu1.Text = frm.chuc_vu.ToString();
            id_thanhphan1 = frm.id_nhanvien.ToString();
        }

        private void btn_search_thanhphan2_Click(object sender, EventArgs e)
        {
            frm_serach_nhanvien frm = new frm_serach_nhanvien();
            frm.ShowDialog();
            txt_thanhphan2.Text = frm.ten_nhanvien.ToString();
            txt_chucvu2.Text = frm.chuc_vu.ToString();
            id_thanhphan2 = frm.id_nhanvien.ToString();
        }

        private void btn_search_thanhphan3_Click(object sender, EventArgs e)
        {
            frm_serach_nhanvien frm = new frm_serach_nhanvien();
            frm.ShowDialog();
            txt_thanhphan3.Text = frm.ten_nhanvien.ToString();
            txt_chucvu3.Text = frm.chuc_vu.ToString();
            id_thanhphan3 = frm.id_nhanvien.ToString();
        }

        private void btn_search_thanhphan4_Click(object sender, EventArgs e)
        {
            frm_serach_nhanvien frm = new frm_serach_nhanvien();
            frm.ShowDialog();
            txt_thanhphan4.Text = frm.ten_nhanvien.ToString();
            txt_chucvu4.Text = frm.chuc_vu.ToString();
            id_thanhphan4 = frm.id_nhanvien.ToString();
        }

        private void btn_search_thanhphan5_Click(object sender, EventArgs e)
        {
            frm_serach_nhanvien frm = new frm_serach_nhanvien();
            frm.ShowDialog();
            txt_thanhphan5.Text = frm.ten_nhanvien.ToString();
            txt_chucvu5.Text = frm.chuc_vu.ToString();
            id_thanhphan5 = frm.id_nhanvien.ToString();
        }

        private void cbo_donvi_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_donvi.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select ma_phong_ban as id,ten_phong_ban as name from phong_ban where ma_phong_ban_root = '{0}'", row);
                cbo_khuvuc.DataSource = SQLHelper.ExecuteDt(sql);
                cbo_khuvuc.DisplayMember = "name";
                cbo_khuvuc.ValueMember = "id";
            }
        }

        private void cbo_khuvuc_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_khuvuc.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "")
            {
                string sql = string.Format("select ma_phong_ban as id,ten_phong_ban as name from phong_ban where ma_phong_ban_root = '{0}'", row);
                cbo_phongban.DataSource = SQLHelper.ExecuteDt(sql);
                cbo_phongban.DisplayMember = "name";
                cbo_phongban.ValueMember = "id";
            }
        }

        private void cbo_nhanvien_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cbo_nhanvien.SelectedItem;
            string row = vrow.Row.ItemArray[0].ToString();
            if (row != "0")
            {
                string sql_nhanvien = string.Format("select ma_cong_ty,ma_khu_vuc,ma_phong_ban,ma_chuc_vu " +
                    "from nhanvien_phongban where ma_nhan_vien = '{0}' and is_active = 1", row);
                DataTable nhanvien_phongban = SQLHelper.ExecuteDt(sql_nhanvien);
                if (nhanvien_phongban.Rows.Count > 0)
                {
                    cbo_donvi.SelectedValue = nhanvien_phongban.Rows[0]["ma_cong_ty"].ToString();
                    cbo_khuvuc.SelectedValue = nhanvien_phongban.Rows[0]["ma_khu_vuc"].ToString();
                    cbo_phongban.SelectedValue = nhanvien_phongban.Rows[0]["ma_phong_ban"].ToString();
                    cbo_chucvu.SelectedValue = nhanvien_phongban.Rows[0]["ma_chuc_vu"].ToString();
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
