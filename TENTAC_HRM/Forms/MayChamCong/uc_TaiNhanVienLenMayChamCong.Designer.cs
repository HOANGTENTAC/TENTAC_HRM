using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.MayChamCong
{
    partial class uc_TaiNhanVienLenMayChamCong
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_TaiNhanVienLenMayChamCong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Danh sách nhân viên mới");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Nhân viên nghỉ việc");
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChuyenXuongNhanVien = new DevComponents.DotNetBar.ButtonX();
            this.groupTimNhanVien = new System.Windows.Forms.GroupBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.radioMaChamCong = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioTenNhanVien = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RadioMaNhanVien = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnChonTatCaNhanVien = new DevComponents.DotNetBar.ButtonX();
            this.lbTongSoNhanVienTaiLenMay = new DevComponents.DotNetBar.LabelX();
            this.lbTongSoNhanVien = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btnXoaTrenMayChamCong = new DevComponents.DotNetBar.ButtonX();
            this.radioXoaNhanVien = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxXoaVanTay = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxXoaGuongMat = new DevComponents.DotNetBar.CheckBoxItem();
            this.lbThongTinTaiVanTay = new DevComponents.DotNetBar.LabelX();
            this.lbThongTinTaiNhanVien = new DevComponents.DotNetBar.LabelX();
            this.checkBoxTaiGuongMat = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxTaiVanTay = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnTaiNhanVienLenMayChamCong = new DevComponents.DotNetBar.ButtonX();
            this.btnLoaiBoNhanVien = new DevComponents.DotNetBar.ButtonX();
            this.btnLoaiBoTatCaNhanVien = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVNhanVienTaiLenMCC = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaNhanVien1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenNhanVien2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaChamCong2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenChamCong2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaThe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChoPhep2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPhanQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVNhanVien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColMaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaThe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTinhTrang = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColPhanQuyen1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMatKhau1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEnable1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewSoDoQuanLy = new System.Windows.Forms.TreeView();
            this.panelEx1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupTimNhanVien.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVienTaiLenMCC)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "No.png");
            this.imageList1.Images.SetKeyName(1, "Yes.png");
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.panel3);
            this.panelEx1.Controls.Add(this.lbTongSoNhanVienTaiLenMay);
            this.panelEx1.Controls.Add(this.lbTongSoNhanVien);
            this.panelEx1.Controls.Add(this.panel2);
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1184, 582);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(442, 240);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 17;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnChuyenXuongNhanVien);
            this.panel3.Controls.Add(this.groupTimNhanVien);
            this.panel3.Controls.Add(this.btnChonTatCaNhanVien);
            this.panel3.Location = new System.Drawing.Point(926, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 217);
            this.panel3.TabIndex = 16;
            // 
            // btnChuyenXuongNhanVien
            // 
            this.btnChuyenXuongNhanVien.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChuyenXuongNhanVien.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChuyenXuongNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenXuongNhanVien.Location = new System.Drawing.Point(14, 180);
            this.btnChuyenXuongNhanVien.Name = "btnChuyenXuongNhanVien";
            this.btnChuyenXuongNhanVien.Size = new System.Drawing.Size(223, 23);
            this.btnChuyenXuongNhanVien.TabIndex = 18;
            this.btnChuyenXuongNhanVien.Text = "Chuyển xuống";
            this.btnChuyenXuongNhanVien.Click += new System.EventHandler(this.btnChuyenXuongNhanVien_Click);
            // 
            // groupTimNhanVien
            // 
            this.groupTimNhanVien.Controls.Add(this.btnSearch);
            this.groupTimNhanVien.Controls.Add(this.radioMaChamCong);
            this.groupTimNhanVien.Controls.Add(this.radioTenNhanVien);
            this.groupTimNhanVien.Controls.Add(this.RadioMaNhanVien);
            this.groupTimNhanVien.Controls.Add(this.textBoxX1);
            this.groupTimNhanVien.Location = new System.Drawing.Point(8, 8);
            this.groupTimNhanVien.Name = "groupTimNhanVien";
            this.groupTimNhanVien.Size = new System.Drawing.Size(229, 131);
            this.groupTimNhanVien.TabIndex = 14;
            this.groupTimNhanVien.TabStop = false;
            this.groupTimNhanVien.Text = "Tìm nhân viên";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(188, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.btnSearch.TabIndex = 2;
            // 
            // radioMaChamCong
            // 
            this.radioMaChamCong.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioMaChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMaChamCong.Location = new System.Drawing.Point(8, 62);
            this.radioMaChamCong.Name = "radioMaChamCong";
            this.radioMaChamCong.Size = new System.Drawing.Size(210, 23);
            this.radioMaChamCong.TabIndex = 1;
            this.radioMaChamCong.Text = "Mã chấm công";
            // 
            // radioTenNhanVien
            // 
            this.radioTenNhanVien.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTenNhanVien.Location = new System.Drawing.Point(8, 38);
            this.radioTenNhanVien.Name = "radioTenNhanVien";
            this.radioTenNhanVien.Size = new System.Drawing.Size(210, 23);
            this.radioTenNhanVien.TabIndex = 1;
            this.radioTenNhanVien.Text = "Tên nhân viên";
            // 
            // RadioMaNhanVien
            // 
            this.RadioMaNhanVien.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.RadioMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioMaNhanVien.Location = new System.Drawing.Point(8, 14);
            this.RadioMaNhanVien.Name = "RadioMaNhanVien";
            this.RadioMaNhanVien.Size = new System.Drawing.Size(210, 23);
            this.RadioMaNhanVien.TabIndex = 1;
            this.RadioMaNhanVien.Text = "Mã nhân viên";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.Location = new System.Drawing.Point(11, 94);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(171, 23);
            this.textBoxX1.TabIndex = 0;
            // 
            // btnChonTatCaNhanVien
            // 
            this.btnChonTatCaNhanVien.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChonTatCaNhanVien.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChonTatCaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonTatCaNhanVien.Location = new System.Drawing.Point(14, 155);
            this.btnChonTatCaNhanVien.Name = "btnChonTatCaNhanVien";
            this.btnChonTatCaNhanVien.Size = new System.Drawing.Size(223, 23);
            this.btnChonTatCaNhanVien.TabIndex = 17;
            this.btnChonTatCaNhanVien.Text = "Chọn tất cả";
            this.btnChonTatCaNhanVien.Click += new System.EventHandler(this.btnChonTatCaNhanVien_Click);
            // 
            // lbTongSoNhanVienTaiLenMay
            // 
            this.lbTongSoNhanVienTaiLenMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSoNhanVienTaiLenMay.Location = new System.Drawing.Point(706, 551);
            this.lbTongSoNhanVienTaiLenMay.Name = "lbTongSoNhanVienTaiLenMay";
            this.lbTongSoNhanVienTaiLenMay.Size = new System.Drawing.Size(207, 20);
            this.lbTongSoNhanVienTaiLenMay.TabIndex = 15;
            this.lbTongSoNhanVienTaiLenMay.Text = "Tổng số nhân viên: 0   ";
            // 
            // lbTongSoNhanVien
            // 
            this.lbTongSoNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSoNhanVien.Location = new System.Drawing.Point(706, 239);
            this.lbTongSoNhanVien.Name = "lbTongSoNhanVien";
            this.lbTongSoNhanVien.Size = new System.Drawing.Size(207, 21);
            this.lbTongSoNhanVien.TabIndex = 15;
            this.lbTongSoNhanVien.Text = "labelX1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonX2);
            this.panel2.Controls.Add(this.btnXoaTrenMayChamCong);
            this.panel2.Controls.Add(this.lbThongTinTaiVanTay);
            this.panel2.Controls.Add(this.lbThongTinTaiNhanVien);
            this.panel2.Controls.Add(this.checkBoxTaiGuongMat);
            this.panel2.Controls.Add(this.checkBoxTaiVanTay);
            this.panel2.Controls.Add(this.btnTaiNhanVienLenMayChamCong);
            this.panel2.Controls.Add(this.btnLoaiBoNhanVien);
            this.panel2.Controls.Add(this.btnLoaiBoTatCaNhanVien);
            this.panel2.Location = new System.Drawing.Point(926, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 298);
            this.panel2.TabIndex = 14;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(40, 213);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 18;
            this.buttonX2.Text = "buttonX2";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // btnXoaTrenMayChamCong
            // 
            this.btnXoaTrenMayChamCong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoaTrenMayChamCong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoaTrenMayChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaTrenMayChamCong.Location = new System.Drawing.Point(14, 244);
            this.btnXoaTrenMayChamCong.Name = "btnXoaTrenMayChamCong";
            this.btnXoaTrenMayChamCong.Size = new System.Drawing.Size(223, 23);
            this.btnXoaTrenMayChamCong.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.radioXoaNhanVien,
            this.checkBoxXoaVanTay,
            this.checkBoxXoaGuongMat});
            this.btnXoaTrenMayChamCong.TabIndex = 17;
            this.btnXoaTrenMayChamCong.Text = "Xóa trên máy chấm công";
            // 
            // radioXoaNhanVien
            // 
            this.radioXoaNhanVien.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioXoaNhanVien.GlobalItem = false;
            this.radioXoaNhanVien.Name = "radioXoaNhanVien";
            this.radioXoaNhanVien.Text = "Nhân viên";
            // 
            // checkBoxXoaVanTay
            // 
            this.checkBoxXoaVanTay.GlobalItem = false;
            this.checkBoxXoaVanTay.Name = "checkBoxXoaVanTay";
            this.checkBoxXoaVanTay.Text = "Vân tay";
            // 
            // checkBoxXoaGuongMat
            // 
            this.checkBoxXoaGuongMat.GlobalItem = false;
            this.checkBoxXoaGuongMat.Name = "checkBoxXoaGuongMat";
            this.checkBoxXoaGuongMat.Text = "Gương mặt";
            // 
            // lbThongTinTaiVanTay
            // 
            this.lbThongTinTaiVanTay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongTinTaiVanTay.ForeColor = System.Drawing.Color.Red;
            this.lbThongTinTaiVanTay.Location = new System.Drawing.Point(14, 170);
            this.lbThongTinTaiVanTay.Name = "lbThongTinTaiVanTay";
            this.lbThongTinTaiVanTay.Size = new System.Drawing.Size(223, 23);
            this.lbThongTinTaiVanTay.TabIndex = 16;
            this.lbThongTinTaiVanTay.Text = "labelX1";
            // 
            // lbThongTinTaiNhanVien
            // 
            this.lbThongTinTaiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongTinTaiNhanVien.ForeColor = System.Drawing.Color.Red;
            this.lbThongTinTaiNhanVien.Location = new System.Drawing.Point(14, 143);
            this.lbThongTinTaiNhanVien.Name = "lbThongTinTaiNhanVien";
            this.lbThongTinTaiNhanVien.Size = new System.Drawing.Size(223, 23);
            this.lbThongTinTaiNhanVien.TabIndex = 16;
            this.lbThongTinTaiNhanVien.Text = "labelX1";
            // 
            // checkBoxTaiGuongMat
            // 
            this.checkBoxTaiGuongMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTaiGuongMat.Location = new System.Drawing.Point(14, 113);
            this.checkBoxTaiGuongMat.Name = "checkBoxTaiGuongMat";
            this.checkBoxTaiGuongMat.Size = new System.Drawing.Size(223, 23);
            this.checkBoxTaiGuongMat.TabIndex = 15;
            this.checkBoxTaiGuongMat.Text = "Tải gương mặt";
            // 
            // checkBoxTaiVanTay
            // 
            this.checkBoxTaiVanTay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTaiVanTay.Location = new System.Drawing.Point(14, 87);
            this.checkBoxTaiVanTay.Name = "checkBoxTaiVanTay";
            this.checkBoxTaiVanTay.Size = new System.Drawing.Size(223, 23);
            this.checkBoxTaiVanTay.TabIndex = 15;
            this.checkBoxTaiVanTay.Text = "Tải vân tay";
            // 
            // btnTaiNhanVienLenMayChamCong
            // 
            this.btnTaiNhanVienLenMayChamCong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTaiNhanVienLenMayChamCong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTaiNhanVienLenMayChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiNhanVienLenMayChamCong.Location = new System.Drawing.Point(14, 57);
            this.btnTaiNhanVienLenMayChamCong.Name = "btnTaiNhanVienLenMayChamCong";
            this.btnTaiNhanVienLenMayChamCong.Size = new System.Drawing.Size(223, 23);
            this.btnTaiNhanVienLenMayChamCong.TabIndex = 14;
            this.btnTaiNhanVienLenMayChamCong.Text = "Tải lên máy chấm công";
            this.btnTaiNhanVienLenMayChamCong.Click += new System.EventHandler(this.btnTaiNhanVienLenMayChamCong_Click);
            // 
            // btnLoaiBoNhanVien
            // 
            this.btnLoaiBoNhanVien.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLoaiBoNhanVien.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLoaiBoNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiBoNhanVien.Location = new System.Drawing.Point(14, 7);
            this.btnLoaiBoNhanVien.Name = "btnLoaiBoNhanVien";
            this.btnLoaiBoNhanVien.Size = new System.Drawing.Size(223, 23);
            this.btnLoaiBoNhanVien.TabIndex = 13;
            this.btnLoaiBoNhanVien.Text = "Loại bỏ";
            this.btnLoaiBoNhanVien.Click += new System.EventHandler(this.btnLoaiBoNhanVien_Click);
            // 
            // btnLoaiBoTatCaNhanVien
            // 
            this.btnLoaiBoTatCaNhanVien.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLoaiBoTatCaNhanVien.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLoaiBoTatCaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiBoTatCaNhanVien.Location = new System.Drawing.Point(14, 32);
            this.btnLoaiBoTatCaNhanVien.Name = "btnLoaiBoTatCaNhanVien";
            this.btnLoaiBoTatCaNhanVien.Size = new System.Drawing.Size(223, 23);
            this.btnLoaiBoTatCaNhanVien.TabIndex = 13;
            this.btnLoaiBoTatCaNhanVien.Text = "Loại bỏ tất cả";
            this.btnLoaiBoTatCaNhanVien.Click += new System.EventHandler(this.btnLoaiBoTatCaNhanVien_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVNhanVienTaiLenMCC);
            this.groupBox3.Location = new System.Drawing.Point(264, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(656, 277);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách nhân viên được tải lên máy chấm công";
            // 
            // DGVNhanVienTaiLenMCC
            // 
            this.DGVNhanVienTaiLenMCC.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.DGVNhanVienTaiLenMCC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVNhanVienTaiLenMCC.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DGVNhanVienTaiLenMCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNhanVienTaiLenMCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColMaNhanVien1,
            this.ColTenNhanVien2,
            this.ColMaChamCong2,
            this.ColTenChamCong2,
            this.ColMaThe2,
            this.ColChoPhep2,
            this.ColPhanQuyen,
            this.ColMatKhau,
            this.ColEnable});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVNhanVienTaiLenMCC.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVNhanVienTaiLenMCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVNhanVienTaiLenMCC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVNhanVienTaiLenMCC.Location = new System.Drawing.Point(3, 16);
            this.DGVNhanVienTaiLenMCC.Name = "DGVNhanVienTaiLenMCC";
            this.DGVNhanVienTaiLenMCC.Size = new System.Drawing.Size(650, 258);
            this.DGVNhanVienTaiLenMCC.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // ColMaNhanVien1
            // 
            this.ColMaNhanVien1.HeaderText = "Mã Nhân Viên";
            this.ColMaNhanVien1.Name = "ColMaNhanVien1";
            // 
            // ColTenNhanVien2
            // 
            this.ColTenNhanVien2.HeaderText = "Tên Nhân Viên";
            this.ColTenNhanVien2.Name = "ColTenNhanVien2";
            // 
            // ColMaChamCong2
            // 
            this.ColMaChamCong2.HeaderText = "Mã Chấm Công";
            this.ColMaChamCong2.Name = "ColMaChamCong2";
            // 
            // ColTenChamCong2
            // 
            this.ColTenChamCong2.HeaderText = "Tên Chấm Công";
            this.ColTenChamCong2.Name = "ColTenChamCong2";
            // 
            // ColMaThe2
            // 
            this.ColMaThe2.HeaderText = "Mã Thẻ";
            this.ColMaThe2.Name = "ColMaThe2";
            // 
            // ColChoPhep2
            // 
            this.ColChoPhep2.HeaderText = "Cho Phép";
            this.ColChoPhep2.Name = "ColChoPhep2";
            this.ColChoPhep2.ReadOnly = true;
            // 
            // ColPhanQuyen
            // 
            this.ColPhanQuyen.HeaderText = "Phân Quyền";
            this.ColPhanQuyen.Name = "ColPhanQuyen";
            // 
            // ColMatKhau
            // 
            this.ColMatKhau.HeaderText = "Mật Khẩu";
            this.ColMatKhau.Name = "ColMatKhau";
            // 
            // ColEnable
            // 
            this.ColEnable.HeaderText = "Enable";
            this.ColEnable.Name = "ColEnable";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVNhanVien);
            this.groupBox2.Location = new System.Drawing.Point(264, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 233);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhân viên";
            // 
            // DGVNhanVien
            // 
            this.DGVNhanVien.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite;
            this.DGVNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVNhanVien.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DGVNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaNhanVien,
            this.ColTenNhanVien,
            this.ColMaChamCong,
            this.ColTenChamCong,
            this.ColMaThe,
            this.ColTinhTrang,
            this.ColPhanQuyen1,
            this.ColMatKhau1,
            this.ColEnable1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVNhanVien.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVNhanVien.Location = new System.Drawing.Point(3, 16);
            this.DGVNhanVien.Name = "DGVNhanVien";
            this.DGVNhanVien.Size = new System.Drawing.Size(650, 214);
            this.DGVNhanVien.TabIndex = 0;
            this.DGVNhanVien.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVNhanVien_CellPainting);
            this.DGVNhanVien.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVNhanVien_ColumnHeaderMouseClick);
            // 
            // ColMaNhanVien
            // 
            this.ColMaNhanVien.DataPropertyName = "MaNhanVien";
            this.ColMaNhanVien.HeaderText = "Mã Nhân Viên";
            this.ColMaNhanVien.Name = "ColMaNhanVien";
            // 
            // ColTenNhanVien
            // 
            this.ColTenNhanVien.DataPropertyName = "TenNhanVien";
            this.ColTenNhanVien.HeaderText = "Tên Nhân Viên";
            this.ColTenNhanVien.Name = "ColTenNhanVien";
            // 
            // ColMaChamCong
            // 
            this.ColMaChamCong.DataPropertyName = "MaChamCong";
            this.ColMaChamCong.HeaderText = "Mã Chấm Công";
            this.ColMaChamCong.Name = "ColMaChamCong";
            // 
            // ColTenChamCong
            // 
            this.ColTenChamCong.DataPropertyName = "TenChamCong";
            this.ColTenChamCong.HeaderText = "Tên Chấm Công";
            this.ColTenChamCong.Name = "ColTenChamCong";
            // 
            // ColMaThe
            // 
            this.ColMaThe.DataPropertyName = "MaThe";
            this.ColMaThe.HeaderText = "Mã Thẻ";
            this.ColMaThe.Name = "ColMaThe";
            // 
            // ColTinhTrang
            // 
            this.ColTinhTrang.DataPropertyName = "TinhTrang";
            this.ColTinhTrang.HeaderText = "Cho Phép";
            this.ColTinhTrang.Name = "ColTinhTrang";
            this.ColTinhTrang.ReadOnly = true;
            // 
            // ColPhanQuyen1
            // 
            this.ColPhanQuyen1.DataPropertyName = "PhanQuyen";
            this.ColPhanQuyen1.HeaderText = "Phân Quyền";
            this.ColPhanQuyen1.Name = "ColPhanQuyen1";
            // 
            // ColMatKhau1
            // 
            this.ColMatKhau1.DataPropertyName = "UserPassWord";
            this.ColMatKhau1.HeaderText = "Mật Khẩu";
            this.ColMatKhau1.Name = "ColMatKhau1";
            // 
            // ColEnable1
            // 
            this.ColEnable1.DataPropertyName = "UserEnable";
            this.ColEnable1.HeaderText = "Enable";
            this.ColEnable1.Name = "ColEnable1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(264, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 3);
            this.panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewSoDoQuanLy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 582);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phòng ban";
            // 
            // treeViewSoDoQuanLy
            // 
            this.treeViewSoDoQuanLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSoDoQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewSoDoQuanLy.ImageIndex = 0;
            this.treeViewSoDoQuanLy.ImageList = this.imageList1;
            this.treeViewSoDoQuanLy.Location = new System.Drawing.Point(3, 16);
            this.treeViewSoDoQuanLy.Name = "treeViewSoDoQuanLy";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Danh sách nhân viên mới";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Nhân viên nghỉ việc";
            this.treeViewSoDoQuanLy.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeViewSoDoQuanLy.SelectedImageIndex = 1;
            this.treeViewSoDoQuanLy.Size = new System.Drawing.Size(258, 563);
            this.treeViewSoDoQuanLy.TabIndex = 3;
            // 
            // uc_TaiNhanVienLenMayChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelEx1);
            this.Name = "uc_TaiNhanVienLenMayChamCong";
            this.Size = new System.Drawing.Size(1184, 582);
            this.Load += new System.EventHandler(this.uc_TaiNhanVienLenMayChamCong_Load);
            this.panelEx1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupTimNhanVien.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVienTaiLenMCC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private ImageList imageList1;

        private PanelEx panelEx1;

        private GroupBox groupBox2;

        private DataGridViewX DGVNhanVien;

        private GroupBox groupBox1;

        private TreeView treeViewSoDoQuanLy;

        private Panel panel1;

        private GroupBox groupBox3;

        private DataGridViewX DGVNhanVienTaiLenMCC;

        private DataGridViewTextBoxColumn Column1;

        private DataGridViewTextBoxColumn ColMaNhanVien1;

        private DataGridViewTextBoxColumn ColTenNhanVien2;

        private DataGridViewTextBoxColumn ColMaChamCong2;

        private DataGridViewTextBoxColumn ColTenChamCong2;

        private DataGridViewTextBoxColumn ColMaThe2;

        private DataGridViewCheckBoxColumn ColChoPhep2;

        private Panel panel2;

        private ButtonX btnLoaiBoNhanVien;

        private ButtonX btnLoaiBoTatCaNhanVien;

        private CheckBoxX checkBoxTaiGuongMat;

        private CheckBoxX checkBoxTaiVanTay;

        private ButtonX btnTaiNhanVienLenMayChamCong;

        private LabelX lbThongTinTaiVanTay;

        private LabelX lbThongTinTaiNhanVien;

        private ButtonX btnXoaTrenMayChamCong;

        private CheckBoxItem radioXoaNhanVien;

        private CheckBoxItem checkBoxXoaVanTay;

        private CheckBoxItem checkBoxXoaGuongMat;

        private LabelX lbTongSoNhanVien;

        private LabelX lbTongSoNhanVienTaiLenMay;

        private GroupBox groupTimNhanVien;

        private ButtonX btnSearch;

        private CheckBoxX radioMaChamCong;

        private CheckBoxX radioTenNhanVien;

        private CheckBoxX RadioMaNhanVien;

        private TextBoxX textBoxX1;

        private Panel panel3;

        private ButtonX btnChonTatCaNhanVien;

        private ButtonX btnChuyenXuongNhanVien;

        private ButtonX buttonX1;

        private ButtonX buttonX2;

        private DataGridViewTextBoxColumn ColPhanQuyen;

        private DataGridViewTextBoxColumn ColMatKhau;

        private DataGridViewTextBoxColumn ColEnable;

        private DataGridViewTextBoxColumn ColMaNhanVien;

        private DataGridViewTextBoxColumn ColTenNhanVien;

        private DataGridViewTextBoxColumn ColMaChamCong;

        private DataGridViewTextBoxColumn ColTenChamCong;

        private DataGridViewTextBoxColumn ColMaThe;

        private DataGridViewCheckBoxColumn ColTinhTrang;

        private DataGridViewTextBoxColumn ColPhanQuyen1;

        private DataGridViewTextBoxColumn ColMatKhau1;

        private DataGridViewTextBoxColumn ColEnable1;
        #endregion
    }
}
