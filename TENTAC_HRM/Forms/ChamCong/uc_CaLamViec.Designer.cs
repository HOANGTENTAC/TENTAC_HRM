using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.ChamCong
{
    partial class uc_CaLamViec
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVCaLamViec = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeKetThucRa = new System.Windows.Forms.DateTimePicker();
            this.dateTimeBatDauRa = new System.Windows.Forms.DateTimePicker();
            this.dateTimeKetThucVao = new System.Windows.Forms.DateTimePicker();
            this.dateTimeBatDauVao = new System.Windows.Forms.DateTimePicker();
            this.dateTimeGioKetThucNghiTrua = new System.Windows.Forms.DateTimePicker();
            this.dateTimeGioBatDauNghiTrua = new System.Windows.Forms.DateTimePicker();
            this.dateTimeGioKetThucLamViec = new System.Windows.Forms.DateTimePicker();
            this.dateTimeGioVaoLamViec = new System.Windows.Forms.DateTimePicker();
            this.checkBoxTinhBuTru = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxXemCaDem = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtCongTinh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtKhongCoGioVao = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTongGioTrongCaLamViec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtKhongCoGioRa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTongGioNghiTrua = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCaLamViec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtChoPhepVeSom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtChoPhepDiTre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxBatDauTinhVeSom = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxBatDauTinhDiTre = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxTruGioVeSom = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxTruGioDiTre = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX38 = new DevComponents.DotNetBar.LabelX();
            this.labelX36 = new DevComponents.DotNetBar.LabelX();
            this.labelX34 = new DevComponents.DotNetBar.LabelX();
            this.labelX31 = new DevComponents.DotNetBar.LabelX();
            this.labelX30 = new DevComponents.DotNetBar.LabelX();
            this.labelX25 = new DevComponents.DotNetBar.LabelX();
            this.labelX29 = new DevComponents.DotNetBar.LabelX();
            this.labelX26 = new DevComponents.DotNetBar.LabelX();
            this.labelX37 = new DevComponents.DotNetBar.LabelX();
            this.labelX24 = new DevComponents.DotNetBar.LabelX();
            this.labelX35 = new DevComponents.DotNetBar.LabelX();
            this.labelX28 = new DevComponents.DotNetBar.LabelX();
            this.labelX33 = new DevComponents.DotNetBar.LabelX();
            this.labelX27 = new DevComponents.DotNetBar.LabelX();
            this.labelX32 = new DevComponents.DotNetBar.LabelX();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.txtGioiHanTangCaMuc4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.txtGioiHanTangCaMuc3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPhutTruTangCaSau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGioiHanTangCa2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPhutTruTangCaTruoc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGioiHanTangCa1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTangCaSauGioLamViecDatDen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTangCaTruocGioLamViecDatDen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTongGioLamDatDen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPhutTangCaSauGioLamViec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPhutTangCaTruocGioLamViec = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxHeSoTangCaNgayLe = new System.Windows.Forms.ComboBox();
            this.comboBoxHeSoTangCaCuoiTuan = new System.Windows.Forms.ComboBox();
            this.comboBoxTangCaHeSo = new System.Windows.Forms.ComboBox();
            this.checkBoxTongGioLamDatDen = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxTangCaSauGioLamViec = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxXemNgayLeLaTangCa = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxTangCaTruocGioLamViec = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxXemCuoiTuanLaTangCa = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxXemCaNayLaTangCa = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.btnThemMoi = new DevComponents.DotNetBar.ButtonItem();
            this.btnLuu = new DevComponents.DotNetBar.ButtonItem();
            this.btnXoa = new DevComponents.DotNetBar.ButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_MaCa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX39 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCaLamViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVCaLamViec
            // 
            this.DGVCaLamViec.AllowUserToAddRows = false;
            this.DGVCaLamViec.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.DGVCaLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCaLamViec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCaLamViec.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCaLamViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCaLamViec.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGVCaLamViec.Location = new System.Drawing.Point(3, 18);
            this.DGVCaLamViec.Name = "DGVCaLamViec";
            this.DGVCaLamViec.Size = new System.Drawing.Size(328, 574);
            this.DGVCaLamViec.TabIndex = 2;
            this.DGVCaLamViec.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCaLamViec_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaCaLamViec";
            this.Column1.HeaderText = "MaCaLamViec";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CaLamViec";
            this.Column2.HeaderText = "Ca Làm Việc";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GioVaoLamViec";
            this.Column3.HeaderText = "Giờ Vào";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GioKetThucLamViec";
            this.Column4.HeaderText = "Giờ Ra";
            this.Column4.Name = "Column4";
            // 
            // dateTimeKetThucRa
            // 
            this.dateTimeKetThucRa.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeKetThucRa.CustomFormat = "HH:mm";
            this.dateTimeKetThucRa.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeKetThucRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeKetThucRa.Location = new System.Drawing.Point(255, 359);
            this.dateTimeKetThucRa.Name = "dateTimeKetThucRa";
            this.dateTimeKetThucRa.ShowUpDown = true;
            this.dateTimeKetThucRa.Size = new System.Drawing.Size(80, 24);
            this.dateTimeKetThucRa.TabIndex = 11;
            // 
            // dateTimeBatDauRa
            // 
            this.dateTimeBatDauRa.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBatDauRa.CustomFormat = "HH:mm";
            this.dateTimeBatDauRa.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBatDauRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBatDauRa.Location = new System.Drawing.Point(255, 330);
            this.dateTimeBatDauRa.Name = "dateTimeBatDauRa";
            this.dateTimeBatDauRa.ShowUpDown = true;
            this.dateTimeBatDauRa.Size = new System.Drawing.Size(80, 24);
            this.dateTimeBatDauRa.TabIndex = 10;
            // 
            // dateTimeKetThucVao
            // 
            this.dateTimeKetThucVao.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeKetThucVao.CustomFormat = "HH:mm";
            this.dateTimeKetThucVao.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeKetThucVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeKetThucVao.Location = new System.Drawing.Point(255, 300);
            this.dateTimeKetThucVao.Name = "dateTimeKetThucVao";
            this.dateTimeKetThucVao.ShowUpDown = true;
            this.dateTimeKetThucVao.Size = new System.Drawing.Size(80, 24);
            this.dateTimeKetThucVao.TabIndex = 9;
            // 
            // dateTimeBatDauVao
            // 
            this.dateTimeBatDauVao.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBatDauVao.CustomFormat = "HH:mm";
            this.dateTimeBatDauVao.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBatDauVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBatDauVao.Location = new System.Drawing.Point(255, 271);
            this.dateTimeBatDauVao.Name = "dateTimeBatDauVao";
            this.dateTimeBatDauVao.ShowUpDown = true;
            this.dateTimeBatDauVao.Size = new System.Drawing.Size(80, 24);
            this.dateTimeBatDauVao.TabIndex = 8;
            // 
            // dateTimeGioKetThucNghiTrua
            // 
            this.dateTimeGioKetThucNghiTrua.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioKetThucNghiTrua.CustomFormat = "HH:mm";
            this.dateTimeGioKetThucNghiTrua.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioKetThucNghiTrua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeGioKetThucNghiTrua.Location = new System.Drawing.Point(255, 187);
            this.dateTimeGioKetThucNghiTrua.Name = "dateTimeGioKetThucNghiTrua";
            this.dateTimeGioKetThucNghiTrua.ShowUpDown = true;
            this.dateTimeGioKetThucNghiTrua.Size = new System.Drawing.Size(80, 24);
            this.dateTimeGioKetThucNghiTrua.TabIndex = 5;
            this.dateTimeGioKetThucNghiTrua.ValueChanged += new System.EventHandler(this.dateTimeGioKetThucNghiTrua_ValueChanged);
            // 
            // dateTimeGioBatDauNghiTrua
            // 
            this.dateTimeGioBatDauNghiTrua.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioBatDauNghiTrua.CustomFormat = "HH:mm";
            this.dateTimeGioBatDauNghiTrua.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioBatDauNghiTrua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeGioBatDauNghiTrua.Location = new System.Drawing.Point(255, 158);
            this.dateTimeGioBatDauNghiTrua.Name = "dateTimeGioBatDauNghiTrua";
            this.dateTimeGioBatDauNghiTrua.ShowUpDown = true;
            this.dateTimeGioBatDauNghiTrua.Size = new System.Drawing.Size(80, 24);
            this.dateTimeGioBatDauNghiTrua.TabIndex = 4;
            this.dateTimeGioBatDauNghiTrua.ValueChanged += new System.EventHandler(this.dateTimeGioBatDauNghiTrua_ValueChanged);
            // 
            // dateTimeGioKetThucLamViec
            // 
            this.dateTimeGioKetThucLamViec.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioKetThucLamViec.CustomFormat = "HH:mm";
            this.dateTimeGioKetThucLamViec.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioKetThucLamViec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeGioKetThucLamViec.Location = new System.Drawing.Point(255, 98);
            this.dateTimeGioKetThucLamViec.Name = "dateTimeGioKetThucLamViec";
            this.dateTimeGioKetThucLamViec.ShowUpDown = true;
            this.dateTimeGioKetThucLamViec.Size = new System.Drawing.Size(80, 24);
            this.dateTimeGioKetThucLamViec.TabIndex = 2;
            this.dateTimeGioKetThucLamViec.ValueChanged += new System.EventHandler(this.dateTimeGioKetThucLamViec_ValueChanged);
            // 
            // dateTimeGioVaoLamViec
            // 
            this.dateTimeGioVaoLamViec.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioVaoLamViec.CustomFormat = "HH:mm";
            this.dateTimeGioVaoLamViec.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeGioVaoLamViec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeGioVaoLamViec.Location = new System.Drawing.Point(255, 67);
            this.dateTimeGioVaoLamViec.Name = "dateTimeGioVaoLamViec";
            this.dateTimeGioVaoLamViec.ShowUpDown = true;
            this.dateTimeGioVaoLamViec.Size = new System.Drawing.Size(80, 24);
            this.dateTimeGioVaoLamViec.TabIndex = 1;
            this.dateTimeGioVaoLamViec.ValueChanged += new System.EventHandler(this.dateTimeGioVaoLamViec_ValueChanged);
            // 
            // checkBoxTinhBuTru
            // 
            this.checkBoxTinhBuTru.AutoSize = true;
            this.checkBoxTinhBuTru.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTinhBuTru.Location = new System.Drawing.Point(19, 476);
            this.checkBoxTinhBuTru.Name = "checkBoxTinhBuTru";
            this.checkBoxTinhBuTru.Size = new System.Drawing.Size(564, 18);
            this.checkBoxTinhBuTru.TabIndex = 16;
            this.checkBoxTinhBuTru.Text = "Tính bù trừ cho ca này (nếu đi làm trễ thì có thể đi về trễ để không bị trừ giờ, " +
    "không tính tăng ca)";
            // 
            // checkBoxXemCaDem
            // 
            this.checkBoxXemCaDem.AutoSize = true;
            this.checkBoxXemCaDem.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxXemCaDem.Location = new System.Drawing.Point(19, 447);
            this.checkBoxXemCaDem.Name = "checkBoxXemCaDem";
            this.checkBoxXemCaDem.Size = new System.Drawing.Size(147, 18);
            this.checkBoxXemCaDem.TabIndex = 15;
            this.checkBoxXemCaDem.Text = "Xem ca này là ca đêm";
            // 
            // labelX17
            // 
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            this.labelX17.Location = new System.Drawing.Point(342, 243);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(87, 23);
            this.labelX17.TabIndex = 3;
            this.labelX17.Text = "công";
            // 
            // labelX16
            // 
            this.labelX16.BackColor = System.Drawing.Color.Transparent;
            this.labelX16.Location = new System.Drawing.Point(344, 390);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(87, 23);
            this.labelX16.TabIndex = 3;
            this.labelX16.Text = "phút";
            // 
            // labelX15
            // 
            this.labelX15.BackColor = System.Drawing.Color.Transparent;
            this.labelX15.Location = new System.Drawing.Point(344, 418);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(87, 23);
            this.labelX15.TabIndex = 3;
            this.labelX15.Text = "phút";
            // 
            // txtCongTinh
            // 
            // 
            // 
            // 
            this.txtCongTinh.Border.Class = "TextBoxBorder";
            this.txtCongTinh.Location = new System.Drawing.Point(255, 244);
            this.txtCongTinh.Name = "txtCongTinh";
            this.txtCongTinh.Size = new System.Drawing.Size(80, 22);
            this.txtCongTinh.TabIndex = 7;
            // 
            // txtKhongCoGioVao
            // 
            // 
            // 
            // 
            this.txtKhongCoGioVao.Border.Class = "TextBoxBorder";
            this.txtKhongCoGioVao.Location = new System.Drawing.Point(255, 419);
            this.txtKhongCoGioVao.Name = "txtKhongCoGioVao";
            this.txtKhongCoGioVao.Size = new System.Drawing.Size(80, 22);
            this.txtKhongCoGioVao.TabIndex = 13;
            // 
            // txtTongGioTrongCaLamViec
            // 
            this.txtTongGioTrongCaLamViec.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTongGioTrongCaLamViec.Border.Class = "TextBoxBorder";
            this.txtTongGioTrongCaLamViec.Location = new System.Drawing.Point(255, 127);
            this.txtTongGioTrongCaLamViec.Name = "txtTongGioTrongCaLamViec";
            this.txtTongGioTrongCaLamViec.ReadOnly = true;
            this.txtTongGioTrongCaLamViec.Size = new System.Drawing.Size(80, 22);
            this.txtTongGioTrongCaLamViec.TabIndex = 3;
            // 
            // txtKhongCoGioRa
            // 
            // 
            // 
            // 
            this.txtKhongCoGioRa.Border.Class = "TextBoxBorder";
            this.txtKhongCoGioRa.Location = new System.Drawing.Point(255, 390);
            this.txtKhongCoGioRa.Name = "txtKhongCoGioRa";
            this.txtKhongCoGioRa.Size = new System.Drawing.Size(80, 22);
            this.txtKhongCoGioRa.TabIndex = 12;
            // 
            // txtTongGioNghiTrua
            // 
            this.txtTongGioNghiTrua.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTongGioNghiTrua.Border.Class = "TextBoxBorder";
            this.txtTongGioNghiTrua.Location = new System.Drawing.Point(255, 218);
            this.txtTongGioNghiTrua.Name = "txtTongGioNghiTrua";
            this.txtTongGioNghiTrua.ReadOnly = true;
            this.txtTongGioNghiTrua.Size = new System.Drawing.Size(80, 22);
            this.txtTongGioNghiTrua.TabIndex = 6;
            // 
            // txtCaLamViec
            // 
            // 
            // 
            // 
            this.txtCaLamViec.Border.Class = "TextBoxBorder";
            this.txtCaLamViec.Location = new System.Drawing.Point(255, 39);
            this.txtCaLamViec.Name = "txtCaLamViec";
            this.txtCaLamViec.Size = new System.Drawing.Size(117, 22);
            this.txtCaLamViec.TabIndex = 14;
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            this.labelX12.Location = new System.Drawing.Point(19, 361);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(230, 22);
            this.labelX12.TabIndex = 0;
            this.labelX12.Text = "Kết thúc ra";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(19, 190);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(230, 22);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Giờ kết thúc nghỉ trưa";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            this.labelX8.Location = new System.Drawing.Point(19, 244);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(204, 22);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "Công tính";
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            this.labelX11.Location = new System.Drawing.Point(19, 303);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(230, 22);
            this.labelX11.TabIndex = 0;
            this.labelX11.Text = "Kết thúc vào";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(19, 101);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(230, 20);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Giờ kết thúc làm việc";
            // 
            // labelX14
            // 
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            this.labelX14.Location = new System.Drawing.Point(19, 418);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(230, 22);
            this.labelX14.TabIndex = 0;
            this.labelX14.Text = "Không có giờ vào thì tính tổng";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            this.labelX7.Location = new System.Drawing.Point(19, 127);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(230, 22);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "Tổng giờ trong ca làm việc";
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            this.labelX10.Location = new System.Drawing.Point(19, 332);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(230, 22);
            this.labelX10.TabIndex = 0;
            this.labelX10.Text = "Bắt đầu ra";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(19, 160);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(230, 22);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Giờ bắt đầu nghỉ trưa";
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            this.labelX13.Location = new System.Drawing.Point(19, 389);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(230, 22);
            this.labelX13.TabIndex = 0;
            this.labelX13.Text = "Không có giờ ra thì tính tổng";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Location = new System.Drawing.Point(19, 218);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(230, 22);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Tổng giờ nghỉ trưa";
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            this.labelX9.Location = new System.Drawing.Point(19, 274);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(230, 22);
            this.labelX9.TabIndex = 0;
            this.labelX9.Text = "Bắt đầu vào";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(19, 70);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(230, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Giờ vào làm việc";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(19, 39);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(230, 22);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Ca làm việc";
            // 
            // txtChoPhepVeSom
            // 
            // 
            // 
            // 
            this.txtChoPhepVeSom.Border.Class = "TextBoxBorder";
            this.txtChoPhepVeSom.Location = new System.Drawing.Point(152, 139);
            this.txtChoPhepVeSom.Name = "txtChoPhepVeSom";
            this.txtChoPhepVeSom.Size = new System.Drawing.Size(51, 22);
            this.txtChoPhepVeSom.TabIndex = 7;
            // 
            // txtChoPhepDiTre
            // 
            // 
            // 
            // 
            this.txtChoPhepDiTre.Border.Class = "TextBoxBorder";
            this.txtChoPhepDiTre.Location = new System.Drawing.Point(152, 80);
            this.txtChoPhepDiTre.Name = "txtChoPhepDiTre";
            this.txtChoPhepDiTre.Size = new System.Drawing.Size(51, 22);
            this.txtChoPhepDiTre.TabIndex = 6;
            // 
            // labelX19
            // 
            this.labelX19.BackColor = System.Drawing.Color.Transparent;
            this.labelX19.Location = new System.Drawing.Point(18, 141);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(128, 20);
            this.labelX19.TabIndex = 4;
            this.labelX19.Text = "Cho phép đi về sớm";
            // 
            // checkBoxBatDauTinhVeSom
            // 
            this.checkBoxBatDauTinhVeSom.AutoSize = true;
            this.checkBoxBatDauTinhVeSom.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxBatDauTinhVeSom.Location = new System.Drawing.Point(18, 170);
            this.checkBoxBatDauTinhVeSom.Name = "checkBoxBatDauTinhVeSom";
            this.checkBoxBatDauTinhVeSom.Size = new System.Drawing.Size(227, 18);
            this.checkBoxBatDauTinhVeSom.TabIndex = 5;
            this.checkBoxBatDauTinhVeSom.Text = "Bắt đầu tính về sớm từ thời gian này";
            // 
            // labelX21
            // 
            this.labelX21.AutoSize = true;
            this.labelX21.BackColor = System.Drawing.Color.Transparent;
            this.labelX21.Location = new System.Drawing.Point(209, 141);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(31, 18);
            this.labelX21.TabIndex = 1;
            this.labelX21.Text = "phút";
            // 
            // labelX20
            // 
            this.labelX20.AutoSize = true;
            this.labelX20.BackColor = System.Drawing.Color.Transparent;
            this.labelX20.Location = new System.Drawing.Point(209, 84);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(31, 18);
            this.labelX20.TabIndex = 1;
            this.labelX20.Text = "phút";
            // 
            // labelX18
            // 
            this.labelX18.AutoSize = true;
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            this.labelX18.Location = new System.Drawing.Point(18, 84);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(115, 18);
            this.labelX18.TabIndex = 2;
            this.labelX18.Text = "Cho phép đi làm trễ";
            // 
            // checkBoxBatDauTinhDiTre
            // 
            this.checkBoxBatDauTinhDiTre.AutoSize = true;
            this.checkBoxBatDauTinhDiTre.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxBatDauTinhDiTre.Location = new System.Drawing.Point(18, 113);
            this.checkBoxBatDauTinhDiTre.Name = "checkBoxBatDauTinhDiTre";
            this.checkBoxBatDauTinhDiTre.Size = new System.Drawing.Size(217, 18);
            this.checkBoxBatDauTinhDiTre.TabIndex = 3;
            this.checkBoxBatDauTinhDiTre.Text = "Bắt đầu tính đi trễ từ thời gian này";
            // 
            // checkBoxTruGioVeSom
            // 
            this.checkBoxTruGioVeSom.AutoSize = true;
            this.checkBoxTruGioVeSom.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTruGioVeSom.Location = new System.Drawing.Point(18, 55);
            this.checkBoxTruGioVeSom.Name = "checkBoxTruGioVeSom";
            this.checkBoxTruGioVeSom.Size = new System.Drawing.Size(109, 18);
            this.checkBoxTruGioVeSom.TabIndex = 1;
            this.checkBoxTruGioVeSom.Text = "Trừ giờ về sớm";
            // 
            // checkBoxTruGioDiTre
            // 
            this.checkBoxTruGioDiTre.AutoSize = true;
            this.checkBoxTruGioDiTre.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTruGioDiTre.Location = new System.Drawing.Point(18, 25);
            this.checkBoxTruGioDiTre.Name = "checkBoxTruGioDiTre";
            this.checkBoxTruGioDiTre.Size = new System.Drawing.Size(99, 18);
            this.checkBoxTruGioDiTre.TabIndex = 0;
            this.checkBoxTruGioDiTre.Text = "Trừ giờ đi trễ";
            // 
            // labelX38
            // 
            this.labelX38.BackColor = System.Drawing.Color.Transparent;
            this.labelX38.Location = new System.Drawing.Point(27, 337);
            this.labelX38.Name = "labelX38";
            this.labelX38.Size = new System.Drawing.Size(250, 22);
            this.labelX38.TabIndex = 4;
            this.labelX38.Text = "Giới hạn tăng ca mức 4";
            this.labelX38.Visible = false;
            // 
            // labelX36
            // 
            this.labelX36.BackColor = System.Drawing.Color.Transparent;
            this.labelX36.Location = new System.Drawing.Point(27, 308);
            this.labelX36.Name = "labelX36";
            this.labelX36.Size = new System.Drawing.Size(250, 22);
            this.labelX36.TabIndex = 4;
            this.labelX36.Text = "Giới hạn tăng ca mức 3";
            this.labelX36.Visible = false;
            // 
            // labelX34
            // 
            this.labelX34.BackColor = System.Drawing.Color.Transparent;
            this.labelX34.Location = new System.Drawing.Point(27, 279);
            this.labelX34.Name = "labelX34";
            this.labelX34.Size = new System.Drawing.Size(250, 22);
            this.labelX34.TabIndex = 4;
            this.labelX34.Text = "Giới hạn tăng ca mức 2";
            // 
            // labelX31
            // 
            this.labelX31.BackColor = System.Drawing.Color.Transparent;
            this.labelX31.Location = new System.Drawing.Point(27, 250);
            this.labelX31.Name = "labelX31";
            this.labelX31.Size = new System.Drawing.Size(250, 22);
            this.labelX31.TabIndex = 4;
            this.labelX31.Text = "Giới hạn tăng ca mức 1";
            // 
            // labelX30
            // 
            this.labelX30.BackColor = System.Drawing.Color.Transparent;
            this.labelX30.Location = new System.Drawing.Point(27, 221);
            this.labelX30.Name = "labelX30";
            this.labelX30.Size = new System.Drawing.Size(250, 22);
            this.labelX30.TabIndex = 4;
            this.labelX30.Text = "Tăng ca sau giờ làm việc đạt đến";
            // 
            // labelX25
            // 
            this.labelX25.BackColor = System.Drawing.Color.Transparent;
            this.labelX25.Location = new System.Drawing.Point(27, 192);
            this.labelX25.Name = "labelX25";
            this.labelX25.Size = new System.Drawing.Size(250, 22);
            this.labelX25.TabIndex = 4;
            this.labelX25.Text = "Tăng ca trước giờ làm việc đạt đến";
            // 
            // labelX29
            // 
            this.labelX29.AutoSize = true;
            this.labelX29.BackColor = System.Drawing.Color.Transparent;
            this.labelX29.Location = new System.Drawing.Point(366, 224);
            this.labelX29.Name = "labelX29";
            this.labelX29.Size = new System.Drawing.Size(81, 18);
            this.labelX29.TabIndex = 3;
            this.labelX29.Text = "phút sẽ trừ đi";
            // 
            // labelX26
            // 
            this.labelX26.AutoSize = true;
            this.labelX26.BackColor = System.Drawing.Color.Transparent;
            this.labelX26.Location = new System.Drawing.Point(366, 195);
            this.labelX26.Name = "labelX26";
            this.labelX26.Size = new System.Drawing.Size(81, 18);
            this.labelX26.TabIndex = 3;
            this.labelX26.Text = "phút sẽ trừ đi";
            // 
            // labelX37
            // 
            this.labelX37.AutoSize = true;
            this.labelX37.BackColor = System.Drawing.Color.Transparent;
            this.labelX37.Location = new System.Drawing.Point(366, 340);
            this.labelX37.Name = "labelX37";
            this.labelX37.Size = new System.Drawing.Size(31, 18);
            this.labelX37.TabIndex = 3;
            this.labelX37.Text = "phút";
            this.labelX37.Visible = false;
            // 
            // labelX24
            // 
            this.labelX24.AutoSize = true;
            this.labelX24.BackColor = System.Drawing.Color.Transparent;
            this.labelX24.Location = new System.Drawing.Point(366, 166);
            this.labelX24.Name = "labelX24";
            this.labelX24.Size = new System.Drawing.Size(108, 18);
            this.labelX24.TabIndex = 3;
            this.labelX24.Text = "giờ sẽ tính tăng ca";
            // 
            // labelX35
            // 
            this.labelX35.AutoSize = true;
            this.labelX35.BackColor = System.Drawing.Color.Transparent;
            this.labelX35.Location = new System.Drawing.Point(366, 311);
            this.labelX35.Name = "labelX35";
            this.labelX35.Size = new System.Drawing.Size(31, 18);
            this.labelX35.TabIndex = 3;
            this.labelX35.Text = "phút";
            this.labelX35.Visible = false;
            // 
            // labelX28
            // 
            this.labelX28.AutoSize = true;
            this.labelX28.BackColor = System.Drawing.Color.Transparent;
            this.labelX28.Location = new System.Drawing.Point(576, 221);
            this.labelX28.Name = "labelX28";
            this.labelX28.Size = new System.Drawing.Size(31, 18);
            this.labelX28.TabIndex = 3;
            this.labelX28.Text = "phút";
            // 
            // labelX33
            // 
            this.labelX33.AutoSize = true;
            this.labelX33.BackColor = System.Drawing.Color.Transparent;
            this.labelX33.Location = new System.Drawing.Point(366, 282);
            this.labelX33.Name = "labelX33";
            this.labelX33.Size = new System.Drawing.Size(31, 18);
            this.labelX33.TabIndex = 3;
            this.labelX33.Text = "phút";
            // 
            // labelX27
            // 
            this.labelX27.AutoSize = true;
            this.labelX27.BackColor = System.Drawing.Color.Transparent;
            this.labelX27.Location = new System.Drawing.Point(576, 192);
            this.labelX27.Name = "labelX27";
            this.labelX27.Size = new System.Drawing.Size(31, 18);
            this.labelX27.TabIndex = 3;
            this.labelX27.Text = "phút";
            // 
            // labelX32
            // 
            this.labelX32.AutoSize = true;
            this.labelX32.BackColor = System.Drawing.Color.Transparent;
            this.labelX32.Location = new System.Drawing.Point(366, 253);
            this.labelX32.Name = "labelX32";
            this.labelX32.Size = new System.Drawing.Size(31, 18);
            this.labelX32.TabIndex = 3;
            this.labelX32.Text = "phút";
            // 
            // labelX23
            // 
            this.labelX23.AutoSize = true;
            this.labelX23.BackColor = System.Drawing.Color.Transparent;
            this.labelX23.Location = new System.Drawing.Point(366, 137);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(31, 18);
            this.labelX23.TabIndex = 3;
            this.labelX23.Text = "phút";
            // 
            // txtGioiHanTangCaMuc4
            // 
            // 
            // 
            // 
            this.txtGioiHanTangCaMuc4.Border.Class = "TextBoxBorder";
            this.txtGioiHanTangCaMuc4.Location = new System.Drawing.Point(283, 337);
            this.txtGioiHanTangCaMuc4.Name = "txtGioiHanTangCaMuc4";
            this.txtGioiHanTangCaMuc4.Size = new System.Drawing.Size(75, 22);
            this.txtGioiHanTangCaMuc4.TabIndex = 10;
            this.txtGioiHanTangCaMuc4.Visible = false;
            // 
            // labelX22
            // 
            this.labelX22.AutoSize = true;
            this.labelX22.BackColor = System.Drawing.Color.Transparent;
            this.labelX22.Location = new System.Drawing.Point(366, 109);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(31, 18);
            this.labelX22.TabIndex = 3;
            this.labelX22.Text = "phút";
            // 
            // txtGioiHanTangCaMuc3
            // 
            // 
            // 
            // 
            this.txtGioiHanTangCaMuc3.Border.Class = "TextBoxBorder";
            this.txtGioiHanTangCaMuc3.Location = new System.Drawing.Point(283, 308);
            this.txtGioiHanTangCaMuc3.Name = "txtGioiHanTangCaMuc3";
            this.txtGioiHanTangCaMuc3.Size = new System.Drawing.Size(75, 22);
            this.txtGioiHanTangCaMuc3.TabIndex = 9;
            this.txtGioiHanTangCaMuc3.Visible = false;
            // 
            // txtPhutTruTangCaSau
            // 
            // 
            // 
            // 
            this.txtPhutTruTangCaSau.Border.Class = "TextBoxBorder";
            this.txtPhutTruTangCaSau.Location = new System.Drawing.Point(492, 221);
            this.txtPhutTruTangCaSau.Name = "txtPhutTruTangCaSau";
            this.txtPhutTruTangCaSau.Size = new System.Drawing.Size(75, 22);
            this.txtPhutTruTangCaSau.TabIndex = 12;
            // 
            // txtGioiHanTangCa2
            // 
            // 
            // 
            // 
            this.txtGioiHanTangCa2.Border.Class = "TextBoxBorder";
            this.txtGioiHanTangCa2.Location = new System.Drawing.Point(283, 279);
            this.txtGioiHanTangCa2.Name = "txtGioiHanTangCa2";
            this.txtGioiHanTangCa2.Size = new System.Drawing.Size(75, 22);
            this.txtGioiHanTangCa2.TabIndex = 8;
            // 
            // txtPhutTruTangCaTruoc
            // 
            // 
            // 
            // 
            this.txtPhutTruTangCaTruoc.Border.Class = "TextBoxBorder";
            this.txtPhutTruTangCaTruoc.Location = new System.Drawing.Point(492, 192);
            this.txtPhutTruTangCaTruoc.Name = "txtPhutTruTangCaTruoc";
            this.txtPhutTruTangCaTruoc.Size = new System.Drawing.Size(75, 22);
            this.txtPhutTruTangCaTruoc.TabIndex = 11;
            // 
            // txtGioiHanTangCa1
            // 
            // 
            // 
            // 
            this.txtGioiHanTangCa1.Border.Class = "TextBoxBorder";
            this.txtGioiHanTangCa1.Location = new System.Drawing.Point(283, 250);
            this.txtGioiHanTangCa1.Name = "txtGioiHanTangCa1";
            this.txtGioiHanTangCa1.Size = new System.Drawing.Size(75, 22);
            this.txtGioiHanTangCa1.TabIndex = 7;
            // 
            // txtTangCaSauGioLamViecDatDen
            // 
            // 
            // 
            // 
            this.txtTangCaSauGioLamViecDatDen.Border.Class = "TextBoxBorder";
            this.txtTangCaSauGioLamViecDatDen.Location = new System.Drawing.Point(283, 221);
            this.txtTangCaSauGioLamViecDatDen.Name = "txtTangCaSauGioLamViecDatDen";
            this.txtTangCaSauGioLamViecDatDen.Size = new System.Drawing.Size(75, 22);
            this.txtTangCaSauGioLamViecDatDen.TabIndex = 6;
            // 
            // txtTangCaTruocGioLamViecDatDen
            // 
            // 
            // 
            // 
            this.txtTangCaTruocGioLamViecDatDen.Border.Class = "TextBoxBorder";
            this.txtTangCaTruocGioLamViecDatDen.Location = new System.Drawing.Point(283, 192);
            this.txtTangCaTruocGioLamViecDatDen.Name = "txtTangCaTruocGioLamViecDatDen";
            this.txtTangCaTruocGioLamViecDatDen.Size = new System.Drawing.Size(75, 22);
            this.txtTangCaTruocGioLamViecDatDen.TabIndex = 5;
            // 
            // txtTongGioLamDatDen
            // 
            // 
            // 
            // 
            this.txtTongGioLamDatDen.Border.Class = "TextBoxBorder";
            this.txtTongGioLamDatDen.Location = new System.Drawing.Point(283, 163);
            this.txtTongGioLamDatDen.Name = "txtTongGioLamDatDen";
            this.txtTongGioLamDatDen.Size = new System.Drawing.Size(75, 22);
            this.txtTongGioLamDatDen.TabIndex = 4;
            // 
            // txtPhutTangCaSauGioLamViec
            // 
            // 
            // 
            // 
            this.txtPhutTangCaSauGioLamViec.Border.Class = "TextBoxBorder";
            this.txtPhutTangCaSauGioLamViec.Location = new System.Drawing.Point(283, 135);
            this.txtPhutTangCaSauGioLamViec.Name = "txtPhutTangCaSauGioLamViec";
            this.txtPhutTangCaSauGioLamViec.Size = new System.Drawing.Size(75, 22);
            this.txtPhutTangCaSauGioLamViec.TabIndex = 3;
            // 
            // txtPhutTangCaTruocGioLamViec
            // 
            // 
            // 
            // 
            this.txtPhutTangCaTruocGioLamViec.Border.Class = "TextBoxBorder";
            this.txtPhutTangCaTruocGioLamViec.Location = new System.Drawing.Point(283, 106);
            this.txtPhutTangCaTruocGioLamViec.Name = "txtPhutTangCaTruocGioLamViec";
            this.txtPhutTangCaTruocGioLamViec.Size = new System.Drawing.Size(75, 22);
            this.txtPhutTangCaTruocGioLamViec.TabIndex = 2;
            // 
            // comboBoxHeSoTangCaNgayLe
            // 
            this.comboBoxHeSoTangCaNgayLe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHeSoTangCaNgayLe.FormattingEnabled = true;
            this.comboBoxHeSoTangCaNgayLe.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxHeSoTangCaNgayLe.Location = new System.Drawing.Point(283, 75);
            this.comboBoxHeSoTangCaNgayLe.Name = "comboBoxHeSoTangCaNgayLe";
            this.comboBoxHeSoTangCaNgayLe.Size = new System.Drawing.Size(76, 22);
            this.comboBoxHeSoTangCaNgayLe.TabIndex = 1;
            // 
            // comboBoxHeSoTangCaCuoiTuan
            // 
            this.comboBoxHeSoTangCaCuoiTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHeSoTangCaCuoiTuan.FormattingEnabled = true;
            this.comboBoxHeSoTangCaCuoiTuan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxHeSoTangCaCuoiTuan.Location = new System.Drawing.Point(283, 46);
            this.comboBoxHeSoTangCaCuoiTuan.Name = "comboBoxHeSoTangCaCuoiTuan";
            this.comboBoxHeSoTangCaCuoiTuan.Size = new System.Drawing.Size(76, 22);
            this.comboBoxHeSoTangCaCuoiTuan.TabIndex = 0;
            // 
            // comboBoxTangCaHeSo
            // 
            this.comboBoxTangCaHeSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTangCaHeSo.FormattingEnabled = true;
            this.comboBoxTangCaHeSo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxTangCaHeSo.Location = new System.Drawing.Point(283, 17);
            this.comboBoxTangCaHeSo.Name = "comboBoxTangCaHeSo";
            this.comboBoxTangCaHeSo.Size = new System.Drawing.Size(76, 22);
            this.comboBoxTangCaHeSo.TabIndex = 1;
            // 
            // checkBoxTongGioLamDatDen
            // 
            this.checkBoxTongGioLamDatDen.AutoSize = true;
            this.checkBoxTongGioLamDatDen.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTongGioLamDatDen.Location = new System.Drawing.Point(27, 163);
            this.checkBoxTongGioLamDatDen.Name = "checkBoxTongGioLamDatDen";
            this.checkBoxTongGioLamDatDen.Size = new System.Drawing.Size(144, 18);
            this.checkBoxTongGioLamDatDen.TabIndex = 10;
            this.checkBoxTongGioLamDatDen.Text = "Tổng giờ làm đạt đến";
            // 
            // checkBoxTangCaSauGioLamViec
            // 
            this.checkBoxTangCaSauGioLamViec.AutoSize = true;
            this.checkBoxTangCaSauGioLamViec.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTangCaSauGioLamViec.Location = new System.Drawing.Point(27, 135);
            this.checkBoxTangCaSauGioLamViec.Name = "checkBoxTangCaSauGioLamViec";
            this.checkBoxTangCaSauGioLamViec.Size = new System.Drawing.Size(162, 18);
            this.checkBoxTangCaSauGioLamViec.TabIndex = 8;
            this.checkBoxTangCaSauGioLamViec.Text = "Tăng ca sau giờ làm việc";
            // 
            // checkBoxXemNgayLeLaTangCa
            // 
            this.checkBoxXemNgayLeLaTangCa.AutoSize = true;
            this.checkBoxXemNgayLeLaTangCa.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxXemNgayLeLaTangCa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxXemNgayLeLaTangCa.Location = new System.Drawing.Point(27, 76);
            this.checkBoxXemNgayLeLaTangCa.Name = "checkBoxXemNgayLeLaTangCa";
            this.checkBoxXemNgayLeLaTangCa.Size = new System.Drawing.Size(179, 18);
            this.checkBoxXemNgayLeLaTangCa.TabIndex = 4;
            this.checkBoxXemNgayLeLaTangCa.Text = "Xem ngày lễ là tăng ca mức";
            // 
            // checkBoxTangCaTruocGioLamViec
            // 
            this.checkBoxTangCaTruocGioLamViec.AutoSize = true;
            this.checkBoxTangCaTruocGioLamViec.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTangCaTruocGioLamViec.Location = new System.Drawing.Point(27, 106);
            this.checkBoxTangCaTruocGioLamViec.Name = "checkBoxTangCaTruocGioLamViec";
            this.checkBoxTangCaTruocGioLamViec.Size = new System.Drawing.Size(172, 18);
            this.checkBoxTangCaTruocGioLamViec.TabIndex = 6;
            this.checkBoxTangCaTruocGioLamViec.Text = "Tăng ca trước giờ làm việc";
            // 
            // checkBoxXemCuoiTuanLaTangCa
            // 
            this.checkBoxXemCuoiTuanLaTangCa.AutoSize = true;
            this.checkBoxXemCuoiTuanLaTangCa.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxXemCuoiTuanLaTangCa.Location = new System.Drawing.Point(27, 47);
            this.checkBoxXemCuoiTuanLaTangCa.Name = "checkBoxXemCuoiTuanLaTangCa";
            this.checkBoxXemCuoiTuanLaTangCa.Size = new System.Drawing.Size(190, 18);
            this.checkBoxXemCuoiTuanLaTangCa.TabIndex = 2;
            this.checkBoxXemCuoiTuanLaTangCa.Text = "Xem cuối tuần là tăng ca mức";
            // 
            // checkBoxXemCaNayLaTangCa
            // 
            this.checkBoxXemCaNayLaTangCa.AutoSize = true;
            this.checkBoxXemCaNayLaTangCa.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxXemCaNayLaTangCa.Location = new System.Drawing.Point(27, 18);
            this.checkBoxXemCaNayLaTangCa.Name = "checkBoxXemCaNayLaTangCa";
            this.checkBoxXemCaNayLaTangCa.Size = new System.Drawing.Size(175, 18);
            this.checkBoxXemCaNayLaTangCa.TabIndex = 0;
            this.checkBoxXemCaNayLaTangCa.Text = "Xem ca này là tăng ca mức";
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.White;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Controls.Add(this.tabControlPanel3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(334, 27);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 2;
            this.tabControl2.Size = new System.Drawing.Size(767, 595);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document;
            this.tabControl2.TabIndex = 6;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem1);
            this.tabControl2.Tabs.Add(this.tabItem3);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.labelX38);
            this.tabControlPanel3.Controls.Add(this.checkBoxXemCaNayLaTangCa);
            this.tabControlPanel3.Controls.Add(this.labelX36);
            this.tabControlPanel3.Controls.Add(this.checkBoxXemCuoiTuanLaTangCa);
            this.tabControlPanel3.Controls.Add(this.labelX34);
            this.tabControlPanel3.Controls.Add(this.checkBoxTangCaTruocGioLamViec);
            this.tabControlPanel3.Controls.Add(this.labelX31);
            this.tabControlPanel3.Controls.Add(this.checkBoxXemNgayLeLaTangCa);
            this.tabControlPanel3.Controls.Add(this.labelX30);
            this.tabControlPanel3.Controls.Add(this.checkBoxTangCaSauGioLamViec);
            this.tabControlPanel3.Controls.Add(this.labelX25);
            this.tabControlPanel3.Controls.Add(this.checkBoxTongGioLamDatDen);
            this.tabControlPanel3.Controls.Add(this.labelX29);
            this.tabControlPanel3.Controls.Add(this.comboBoxTangCaHeSo);
            this.tabControlPanel3.Controls.Add(this.labelX26);
            this.tabControlPanel3.Controls.Add(this.comboBoxHeSoTangCaCuoiTuan);
            this.tabControlPanel3.Controls.Add(this.labelX37);
            this.tabControlPanel3.Controls.Add(this.comboBoxHeSoTangCaNgayLe);
            this.tabControlPanel3.Controls.Add(this.labelX24);
            this.tabControlPanel3.Controls.Add(this.txtPhutTangCaTruocGioLamViec);
            this.tabControlPanel3.Controls.Add(this.labelX35);
            this.tabControlPanel3.Controls.Add(this.txtPhutTangCaSauGioLamViec);
            this.tabControlPanel3.Controls.Add(this.labelX28);
            this.tabControlPanel3.Controls.Add(this.txtTongGioLamDatDen);
            this.tabControlPanel3.Controls.Add(this.labelX33);
            this.tabControlPanel3.Controls.Add(this.txtTangCaTruocGioLamViecDatDen);
            this.tabControlPanel3.Controls.Add(this.labelX27);
            this.tabControlPanel3.Controls.Add(this.txtTangCaSauGioLamViecDatDen);
            this.tabControlPanel3.Controls.Add(this.labelX32);
            this.tabControlPanel3.Controls.Add(this.txtGioiHanTangCa1);
            this.tabControlPanel3.Controls.Add(this.labelX23);
            this.tabControlPanel3.Controls.Add(this.txtPhutTruTangCaTruoc);
            this.tabControlPanel3.Controls.Add(this.txtGioiHanTangCaMuc4);
            this.tabControlPanel3.Controls.Add(this.txtGioiHanTangCa2);
            this.tabControlPanel3.Controls.Add(this.labelX22);
            this.tabControlPanel3.Controls.Add(this.txtPhutTruTangCaSau);
            this.tabControlPanel3.Controls.Add(this.txtGioiHanTangCaMuc3);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(767, 569);
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "Tăng ca";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupBox2);
            this.tabControlPanel1.Controls.Add(this.dateTimeKetThucRa);
            this.tabControlPanel1.Controls.Add(this.labelX39);
            this.tabControlPanel1.Controls.Add(this.labelX1);
            this.tabControlPanel1.Controls.Add(this.dateTimeBatDauRa);
            this.tabControlPanel1.Controls.Add(this.labelX2);
            this.tabControlPanel1.Controls.Add(this.dateTimeKetThucVao);
            this.tabControlPanel1.Controls.Add(this.labelX9);
            this.tabControlPanel1.Controls.Add(this.dateTimeBatDauVao);
            this.tabControlPanel1.Controls.Add(this.labelX6);
            this.tabControlPanel1.Controls.Add(this.dateTimeGioKetThucNghiTrua);
            this.tabControlPanel1.Controls.Add(this.labelX13);
            this.tabControlPanel1.Controls.Add(this.dateTimeGioBatDauNghiTrua);
            this.tabControlPanel1.Controls.Add(this.labelX4);
            this.tabControlPanel1.Controls.Add(this.dateTimeGioKetThucLamViec);
            this.tabControlPanel1.Controls.Add(this.labelX10);
            this.tabControlPanel1.Controls.Add(this.dateTimeGioVaoLamViec);
            this.tabControlPanel1.Controls.Add(this.labelX7);
            this.tabControlPanel1.Controls.Add(this.checkBoxTinhBuTru);
            this.tabControlPanel1.Controls.Add(this.labelX14);
            this.tabControlPanel1.Controls.Add(this.checkBoxXemCaDem);
            this.tabControlPanel1.Controls.Add(this.labelX3);
            this.tabControlPanel1.Controls.Add(this.labelX17);
            this.tabControlPanel1.Controls.Add(this.labelX11);
            this.tabControlPanel1.Controls.Add(this.labelX16);
            this.tabControlPanel1.Controls.Add(this.labelX8);
            this.tabControlPanel1.Controls.Add(this.labelX15);
            this.tabControlPanel1.Controls.Add(this.labelX5);
            this.tabControlPanel1.Controls.Add(this.txtCongTinh);
            this.tabControlPanel1.Controls.Add(this.labelX12);
            this.tabControlPanel1.Controls.Add(this.txtKhongCoGioVao);
            this.tabControlPanel1.Controls.Add(this.txt_MaCa);
            this.tabControlPanel1.Controls.Add(this.txtCaLamViec);
            this.tabControlPanel1.Controls.Add(this.txtTongGioTrongCaLamViec);
            this.tabControlPanel1.Controls.Add(this.txtTongGioNghiTrua);
            this.tabControlPanel1.Controls.Add(this.txtKhongCoGioRa);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(767, 569);
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtChoPhepVeSom);
            this.groupBox2.Controls.Add(this.checkBoxTruGioDiTre);
            this.groupBox2.Controls.Add(this.labelX18);
            this.groupBox2.Controls.Add(this.checkBoxBatDauTinhVeSom);
            this.groupBox2.Controls.Add(this.txtChoPhepDiTre);
            this.groupBox2.Controls.Add(this.labelX21);
            this.groupBox2.Controls.Add(this.checkBoxBatDauTinhDiTre);
            this.groupBox2.Controls.Add(this.checkBoxTruGioVeSom);
            this.groupBox2.Controls.Add(this.labelX20);
            this.groupBox2.Controls.Add(this.labelX19);
            this.groupBox2.Location = new System.Drawing.Point(401, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 205);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đi trễ, về sớm";
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Ca làm việc";
            // 
            // bar2
            // 
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnThemMoi,
            this.btnLuu,
            this.btnXoa});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1101, 27);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar2.TabIndex = 7;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThemMoi.Image = global::TENTAC_HRM.Properties.Resources.add_file;
            this.btnThemMoi.ImagePaddingHorizontal = 8;
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnLuu.Image = global::TENTAC_HRM.Properties.Resources.diskette;
            this.btnLuu.ImagePaddingHorizontal = 8;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnXoa.Image = global::TENTAC_HRM.Properties.Resources.delete_file;
            this.btnXoa.ImagePaddingHorizontal = 8;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVCaLamViec);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 595);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách ca làm việc";
            // 
            // txt_MaCa
            // 
            // 
            // 
            // 
            this.txt_MaCa.Border.Class = "TextBoxBorder";
            this.txt_MaCa.Location = new System.Drawing.Point(255, 11);
            this.txt_MaCa.Name = "txt_MaCa";
            this.txt_MaCa.Size = new System.Drawing.Size(117, 22);
            this.txt_MaCa.TabIndex = 14;
            // 
            // labelX39
            // 
            this.labelX39.BackColor = System.Drawing.Color.Transparent;
            this.labelX39.Location = new System.Drawing.Point(19, 11);
            this.labelX39.Name = "labelX39";
            this.labelX39.Size = new System.Drawing.Size(230, 22);
            this.labelX39.TabIndex = 0;
            this.labelX39.Text = "Mã ca làm việc";
            // 
            // uc_CaLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bar2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "uc_CaLamViec";
            this.Size = new System.Drawing.Size(1101, 622);
            this.Load += new System.EventHandler(this.uc_CaLamViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCaLamViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel3.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private DataGridViewX DGVCaLamViec;

        private TextBoxX txtCaLamViec;

        private LabelX labelX1;

        private LabelX labelX3;

        private LabelX labelX2;

        private LabelX labelX5;

        private LabelX labelX4;

        private TextBoxX txtCongTinh;

        private TextBoxX txtTongGioTrongCaLamViec;

        private TextBoxX txtTongGioNghiTrua;

        private LabelX labelX8;

        private LabelX labelX7;

        private LabelX labelX6;

        private LabelX labelX12;

        private LabelX labelX11;

        private LabelX labelX10;

        private LabelX labelX9;

        private LabelX labelX15;

        private TextBoxX txtKhongCoGioVao;

        private TextBoxX txtKhongCoGioRa;

        private LabelX labelX14;

        private LabelX labelX13;

        private LabelX labelX17;

        private LabelX labelX16;

        private CheckBoxX checkBoxTruGioVeSom;

        private CheckBoxX checkBoxTruGioDiTre;

        private TextBoxX txtChoPhepVeSom;

        private TextBoxX txtChoPhepDiTre;

        private LabelX labelX19;

        private CheckBoxX checkBoxBatDauTinhVeSom;

        private LabelX labelX18;

        private CheckBoxX checkBoxBatDauTinhDiTre;

        private LabelX labelX21;

        private LabelX labelX20;

        private CheckBoxX checkBoxXemNgayLeLaTangCa;

        private CheckBoxX checkBoxXemCuoiTuanLaTangCa;

        private CheckBoxX checkBoxXemCaNayLaTangCa;

        private ComboBox comboBoxHeSoTangCaNgayLe;

        private ComboBox comboBoxHeSoTangCaCuoiTuan;

        private ComboBox comboBoxTangCaHeSo;

        private CheckBoxX checkBoxTangCaSauGioLamViec;

        private CheckBoxX checkBoxTangCaTruocGioLamViec;

        private LabelX labelX25;

        private LabelX labelX26;

        private LabelX labelX24;

        private LabelX labelX23;

        private LabelX labelX22;

        private TextBoxX txtTangCaTruocGioLamViecDatDen;

        private TextBoxX txtTongGioLamDatDen;

        private TextBoxX txtPhutTangCaSauGioLamViec;

        private TextBoxX txtPhutTangCaTruocGioLamViec;

        private CheckBoxX checkBoxTongGioLamDatDen;

        private LabelX labelX38;

        private LabelX labelX36;

        private LabelX labelX34;

        private LabelX labelX31;

        private LabelX labelX30;

        private LabelX labelX29;

        private LabelX labelX37;

        private LabelX labelX35;

        private LabelX labelX28;

        private LabelX labelX33;

        private LabelX labelX27;

        private LabelX labelX32;

        private TextBoxX txtGioiHanTangCaMuc4;

        private TextBoxX txtGioiHanTangCaMuc3;

        private TextBoxX txtPhutTruTangCaSau;

        private TextBoxX txtGioiHanTangCa2;

        private TextBoxX txtPhutTruTangCaTruoc;

        private TextBoxX txtGioiHanTangCa1;

        private TextBoxX txtTangCaSauGioLamViecDatDen;

        private CheckBoxX checkBoxTinhBuTru;

        private CheckBoxX checkBoxXemCaDem;

        private DataGridViewTextBoxColumn Column1;

        private DataGridViewTextBoxColumn Column2;

        private DataGridViewTextBoxColumn Column3;

        private DataGridViewTextBoxColumn Column4;

        private DateTimePicker dateTimeKetThucRa;

        private DateTimePicker dateTimeBatDauRa;

        private DateTimePicker dateTimeKetThucVao;

        private DateTimePicker dateTimeBatDauVao;

        private DateTimePicker dateTimeGioKetThucNghiTrua;

        private DateTimePicker dateTimeGioBatDauNghiTrua;

        private DateTimePicker dateTimeGioKetThucLamViec;

        private DateTimePicker dateTimeGioVaoLamViec;

        private global::DevComponents.DotNetBar.TabControl tabControl2;

        private TabControlPanel tabControlPanel1;

        private TabItem tabItem1;

        private TabControlPanel tabControlPanel3;

        private TabItem tabItem3;

        private Bar bar2;

        private ButtonItem btnThemMoi;

        private ButtonItem btnLuu;

        private ButtonItem btnXoa;

        private GroupBox groupBox2;

        private GroupBox groupBox1;

        #endregion

        private LabelX labelX39;
        private TextBoxX txt_MaCa;
    }
}
