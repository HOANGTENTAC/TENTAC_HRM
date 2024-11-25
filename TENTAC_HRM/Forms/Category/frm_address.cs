using ComponentFactory.Krypton.Toolkit;
using Microsoft.Office.Interop.Excel;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TENTAC_HRM.Custom;
using TENTAC_HRM.Forms.Main;
using TENTAC_HRM.Forms.User_control;
using DataTable = System.Data.DataTable;

namespace TENTAC_HRM.Forms.Category
{
    public partial class frm_address : KryptonForm
    {
        public string _ma_nhanvien { get; set; }
        public int? _loai_diachi { get; set; }
        public string _NameForm { get; set; }
        uc_nhan_su uc_nhan_su;
        frm_personnel _Personnel;
        DataProvider provider = new DataProvider();

        DataTable dtAddress = new DataTable();
        DataTable dtDonViHanhChinh = new DataTable();
        int? _IdQuocGia, _IdTinh, _IdHuyen, _IdXa;
        string _ThonSoNha, _DiaChi, _NguoiTao, _NguoiCapNhat;
        public frm_address(Form frm)
        {
            InitializeComponent();
            _Personnel = (frm_personnel)frm;
        }
        private void frm_address_Load(object sender, EventArgs e)
        {
            labelX1.Text = _NameForm;
            LoadDonViHanhChinh();
            LoadNhanVien();
            LoadLoaiDiaChi();
            LoadQuocGia();
            LoadTinhThanh(null);
            LoadQuanHuyen(null);
            LoadPhuongXa(null);
            LoadData();
        }
        private void LoadData()
        {
            string sql = string.Empty;
            sql = $@"select * from tbl_NhanVienDiaChi where MaNhanVien = {SQLHelper.rpStr(_ma_nhanvien)} and LoaiDiaChi = {SQLHelper.rpI(_loai_diachi)}";
            dtAddress = SQLHelper.ExecuteDt(sql);
            if (dtAddress.Rows.Count > 0)
            {
                cbo_QuocGia.SelectedValue = dtAddress.Rows[0]["Id_QuocGia"].ToString();
                cbo_TinhThanh.SelectedValue = dtAddress.Rows[0]["Id_Tinh"].ToString();
                cbo_QuanHuyen.SelectedValue = dtAddress.Rows[0]["Id_Huyen"].ToString();
                cbo_PhuongXa.SelectedValue = dtAddress.Rows[0]["Id_Xa"].ToString();
                txt_ThonSoNha.Text = dtAddress.Rows[0]["ThonToSoNha"].ToString();
            }
        }
        private void LoadDonViHanhChinh()
        {
            string sql = string.Empty;
            sql = $@"Select * from mst_DonViHanhChinh where DelFlg = 0";
            dtDonViHanhChinh = SQLHelper.ExecuteDt(sql);
        }
        private void LoadLoaiDiaChi()
        {
            cbo_LoaiDiaChi.DataSource = provider.load_all_type(40);
            cbo_LoaiDiaChi.DisplayMember = "name";
            cbo_LoaiDiaChi.ValueMember = "id";
            if (_loai_diachi != null)
            {
                cbo_LoaiDiaChi.SelectedValue = _loai_diachi;
            }
        }
        private void LoadNhanVien()
        {
            cbo_NhanVien.DataSource = provider.load_nhanvien();
            cbo_NhanVien.DisplayMember = "name";
            cbo_NhanVien.ValueMember = "value";
            if (_ma_nhanvien != null)
            {
                cbo_NhanVien.SelectedValue = _ma_nhanvien;
            }
        }
        private void LoadQuocGia()
        {
            cbo_QuocGia.DataSource = provider.LoadDiaChiNew(20);
            cbo_QuocGia.DisplayMember = "name";
            cbo_QuocGia.ValueMember = "id";
        }
        private void LoadTinhThanh(int? IdParent)
        {
            IEnumerable<DataRow> RowsTinhThanh = Enumerable.Empty<DataRow>();
            if (IdParent == null)
            {
                RowsTinhThanh = dtDonViHanhChinh.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 1);
            }
            else
            {
                RowsTinhThanh = dtDonViHanhChinh.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 1 && row.Field<int?>("ParentId") == IdParent);
            }

            DataTable dtTinhThanh = RowsTinhThanh.Any() ? RowsTinhThanh.CopyToDataTable() : null;
            dtTinhThanh.Rows.Add("0", "");
            cbo_TinhThanh.DataSource = dtTinhThanh.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
            cbo_TinhThanh.DisplayMember = "TenDiaChi";
            cbo_TinhThanh.ValueMember = "Id";
        }
        private void LoadQuanHuyen(int? IdParent)
        {
            IEnumerable<DataRow> RowsQuanHuyen = Enumerable.Empty<DataRow>();
            if(IdParent == null)
            {
                RowsQuanHuyen = dtDonViHanhChinh.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 2);
            }
            else
            {
                RowsQuanHuyen = dtDonViHanhChinh.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 2 && row.Field<int?>("ParentId") == IdParent);
            }

            DataTable dtQuanHuyen = RowsQuanHuyen.Any() ? RowsQuanHuyen.CopyToDataTable() : null;
            dtQuanHuyen.Rows.Add("0", "");
            cbo_QuanHuyen.DataSource = dtQuanHuyen.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
            cbo_QuanHuyen.DisplayMember = "TenDiaChi";
            cbo_QuanHuyen.ValueMember = "Id";
        }
        private void LoadPhuongXa(int? IdParent)
        {
            IEnumerable<DataRow> RowsPhuongXa = Enumerable.Empty<DataRow>();
            if (IdParent == null)
            {
                RowsPhuongXa = dtDonViHanhChinh.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 3);
            }
            else
            {
                RowsPhuongXa = dtDonViHanhChinh.AsEnumerable().Where(row => row.Field<int?>("CapBac") == 3 && row.Field<int?>("ParentId") == IdParent);
            }

            DataTable dtPhuongXa = RowsPhuongXa.Any()? RowsPhuongXa.CopyToDataTable() : null;
            dtPhuongXa.Rows.Add("0", "");
            cbo_PhuongXa.DataSource = dtPhuongXa.Rows.Cast<DataRow>().OrderBy(x => x.Field<int>("id")).CopyToDataTable();
            cbo_PhuongXa.DisplayMember = "TenDiaChi";
            cbo_PhuongXa.ValueMember = "Id";
        }
        private void cbo_QuocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_QuocGia.SelectedValue != null && cbo_QuocGia.SelectedIndex != 0)
            {
                int IdParent = Convert.ToInt32(cbo_QuocGia.SelectedValue);
                LoadTinhThanh(IdParent);
            }
        }
        private void cbo_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_TinhThanh.SelectedValue != null && cbo_TinhThanh.SelectedIndex != 0)
            {
                int IdParent = Convert.ToInt32(cbo_TinhThanh.SelectedValue);
                LoadQuanHuyen(IdParent);
            }
        }
        private void cbo_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_QuanHuyen.SelectedValue != null && cbo_QuanHuyen.SelectedIndex != 0)
            {
                int IdParent = Convert.ToInt32(cbo_QuanHuyen.SelectedValue);
                LoadPhuongXa(IdParent);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                SetValues();
                string sql = $@"
                        IF EXISTS(SELECT 1 FROM tbl_NhanVienDiaChi 
                                  WHERE MaNhanVien = {SQLHelper.rpStr(_ma_nhanvien)} 
                                  AND LoaiDiaChi = {SQLHelper.rpI(_loai_diachi)} 
                                  AND del_flg = 0)
                        BEGIN
                            UPDATE tbl_NhanVienDiaChi
                            SET Id_QuocGia = {SQLHelper.rpI(_IdQuocGia)},
                                Id_Tinh = {SQLHelper.rpI(_IdTinh)},
                                Id_Huyen = {SQLHelper.rpI(_IdHuyen)},
                                Id_Xa = {SQLHelper.rpI(_IdXa)},
                                ThonToSoNha = {SQLHelper.rpStr(_ThonSoNha)},
                                DiaChi = {SQLHelper.rpStr(_DiaChi)},
                                NgayCapNhat = '{DateTime.Now}',
                                NguoiCapNhat = {SQLHelper.rpStr(_NguoiCapNhat)}
                            WHERE MaNhanVien = {SQLHelper.rpStr(_ma_nhanvien)} 
                              AND LoaiDiaChi = {SQLHelper.rpI(_loai_diachi)} 
                              AND del_flg = 0;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO tbl_NhanVienDiaChi(MaNhanVien, LoaiDiaChi, Id_QuocGia, Id_Tinh, Id_Huyen, Id_Xa, ThonToSoNha, DiaChi, 
                                                           NgayTao, NguoiTao, del_flg)
                            VALUES({SQLHelper.rpStr(_ma_nhanvien)}, {SQLHelper.rpI(_loai_diachi)}, {SQLHelper.rpI(_IdQuocGia)}, 
                                   {SQLHelper.rpI(_IdTinh)}, {SQLHelper.rpI(_IdHuyen)}, {SQLHelper.rpI(_IdXa)}, {SQLHelper.rpStr(_ThonSoNha)},
                                   {SQLHelper.rpStr(_DiaChi)}, '{DateTime.Now}', {SQLHelper.rpStr(_NguoiTao)}, 0);
                        END";

                int res = SQLHelper.ExecuteSql(sql);
                if (res >= 0)
                {
                    RJMessageBox.Show("Lưu địa chỉ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Personnel.load_diachi();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetValues()
        {
            _IdQuocGia = Convert.ToInt32(cbo_QuocGia.SelectedValue);
            _IdTinh = Convert.ToInt32(cbo_TinhThanh.SelectedValue);
            _IdHuyen = Convert.ToInt32(cbo_QuanHuyen.SelectedValue);
            _IdXa = Convert.ToInt32(cbo_PhuongXa.SelectedValue);
            _ThonSoNha = txt_ThonSoNha.Text.Trim();
            _DiaChi = (string.IsNullOrEmpty(_ThonSoNha) ? "" : _ThonSoNha + ", ") + (string.IsNullOrEmpty(cbo_PhuongXa.Text) ? "" : cbo_PhuongXa.Text + ", ") +
                (string.IsNullOrEmpty(cbo_QuanHuyen.Text) ? "" : cbo_QuanHuyen.Text + ", ") + (string.IsNullOrEmpty(cbo_TinhThanh.Text) ? "" : cbo_TinhThanh.Text + ", ") +
                (string.IsNullOrEmpty(cbo_QuocGia.Text) ? "" : cbo_QuocGia.Text);
            _NguoiTao = SQLHelper.sUser;
            _NguoiCapNhat = SQLHelper.sUser;
        }
    }
}
