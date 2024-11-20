using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TENTAC_HRM.Custom;

namespace TENTAC_HRM.Forms.ChamCong
{
    public partial class frm_ChinhVaoSomRaMuon : Form
    {
        CheckBox headerCheckBox = new CheckBox();
        public frm_ChinhVaoSomRaMuon()
        {
            InitializeComponent();
            LoadNam();
            LoadThang();
        }
        private void BindGrid()
        {
            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgv_Data.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 50, headerCellLocation.Y + 2);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dgv_Data.Controls.Add(headerCheckBox);
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dgv_Data.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["chk_col"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var listCheckInOut = (from DataGridViewRow r in dgv_Data.Rows
                                      where Convert.ToBoolean(r.Cells[0].Value) == true
                                      select r).ToList();
                int sophutnew = 0;
                Random TenBienRanDom = new Random();
                foreach (DataGridViewRow r in listCheckInOut)
                {
                    var fsf = r.Cells["MaChamCong"].Value.ToString();
                    try
                    {
                        string sql = "";
                        string ngaycham = "";
                        // Khong tang ca
                        if (string.IsNullOrEmpty(r.Cells["LoaiTangCa"].Value.ToString()))
                        {
                            switch (r.Cells["Ca"].Value.ToString())
                            {
                                case "CA1":
                                case "CA2":
                                case "HC":
                                    //if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("07:35:00"))
                                    if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) <= (TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString()) - TimeSpan.Parse("00:13:00")))
                                    {
                                        var giobatdau = TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString());

                                        int sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes == 0 ? 59 : giobatdau.Minutes);
                                        int sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes == 0 ? 59 : giobatdau.Minutes);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours.ToString().PadLeft(2, '0') + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    //else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("16:45:00"))
                                    else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) >= (TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) + TimeSpan.Parse("00:13:00")))
                                    {
                                        var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString());
                                        //Random TenBienRanDom = new Random();
                                        var sophut = TenBienRanDom.Next(giobatdau.Minutes + 1, (giobatdau + TimeSpan.Parse("00:13:00")).Minutes);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next(giobatdau.Minutes + 1, (giobatdau + TimeSpan.Parse("00:13:00")).Minutes);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours.ToString().PadLeft(2, '0') + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    else if (r.Cells["Ca"].Value.ToString() == "HC"
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString())
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()))
                                    {
                                        if (r.Cells["LoaiDangKy"].Value.ToString() == "1")
                                        {
                                            if (r.Cells["AnTruaCaHC"].Value.ToString() == "0"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("12:43:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(31, 43);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(31, 43);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 12:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            else if (r.Cells["AnTruaCaHC"].Value.ToString() == "1"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("12:03:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(51, 59);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(51, 59);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 11:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        else if (r.Cells["LoaiDangKy"].Value.ToString() == "0")
                                        {
                                            if (r.Cells["AnTruaCaHC"].Value.ToString() == "0"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("12:17:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(17, 29);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(17, 29);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 12:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            else if (r.Cells["AnTruaCaHC"].Value.ToString() == "1"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("11:37:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(37, 49);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(37, 49);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 11:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            // nuoi con nho
                                            else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                            {
                                                var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        // nuoi con nho
                                        else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                        {
                                            var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                            //Random TenBienRanDom = new Random();
                                            var sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                            var sogiay = TenBienRanDom.Next(1, 59);
                                            for (int i = 0; i <= 10; i++)
                                            {
                                                if (sophutnew == sophut)
                                                {
                                                    sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                    sogiay = TenBienRanDom.Next(1, 59);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            sophutnew = sophut;
                                            ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                        }
                                    }
                                    else if (r.Cells["Ca"].Value.ToString() != "HC"
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString())
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()))
                                    {
                                        if (r.Cells["LoaiDangKy"].Value.ToString() == "1")
                                        {
                                            var giobatdau = TimeSpan.Parse(r.Cells["GioNghiTrua"].Value.ToString());
                                            //Random TenBienRanDom = new Random();
                                            var sophut = TenBienRanDom.Next(giobatdau.Minutes, 13);
                                            var sogiay = TenBienRanDom.Next(1, 59);
                                            for (int i = 0; i <= 10; i++)
                                            {
                                                if (sophutnew == sophut)
                                                {
                                                    sophut = TenBienRanDom.Next(giobatdau.Minutes, 13);
                                                    sogiay = TenBienRanDom.Next(1, 59);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            sophutnew = sophut;
                                            ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                        }
                                        else if (r.Cells["LoaiDangKy"].Value.ToString() == "0")
                                        {
                                            if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioNghiTrua"].Value.ToString()) - TimeSpan.Parse("00:13:00"))
                                            {
                                                var giobatdau = TimeSpan.Parse(r.Cells["GioNghiTrua"].Value.ToString());
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            // nuoi con nho
                                            else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                            {
                                                var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(giobatdau.Minutes, (giobatdau + TimeSpan.Parse("00:13:00")).Minutes);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(giobatdau.Minutes, (giobatdau + TimeSpan.Parse("00:13:00")).Minutes);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        // nuoi con nho
                                        else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                        {
                                            var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                            //Random TenBienRanDom = new Random();
                                            var sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                            var sogiay = TenBienRanDom.Next(1, 59);
                                            for (int i = 0; i <= 10; i++)
                                            {
                                                if (sophutnew == sophut)
                                                {
                                                    sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                    sogiay = TenBienRanDom.Next(1, 59);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            sophutnew = sophut;
                                            ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                        }

                                    }
                                    break;
                                case "CA3":
                                    if (
                                        //TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("21:45:00") 
                                        TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) <= (TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString()) - TimeSpan.Parse("00:13:00"))
                                        &&
                                        //TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("17:00:00") 
                                        TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) >= (TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString()) - TimeSpan.Parse("05:00:00")))
                                    {
                                        //Random TenBienRanDom3 = new Random();
                                        var sophut = TenBienRanDom.Next(47, 59);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next(47, 59);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 21:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    else if (
                                        //TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("06:15:00") &&
                                        //TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("08:00:00") 
                                        TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) >= (TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString()) + TimeSpan.Parse("00:13:00")) &&
                                        TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) <= (TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString()) + TimeSpan.Parse("02:00:00")))

                                    {
                                        //Random TenBienRanDom3 = new Random();
                                        var sophut = TenBienRanDom.Next(1, 13);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next(1, 13);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 06:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        // Co tang ca
                        else
                        {
                            switch (r.Cells["Ca"].Value.ToString())
                            {
                                case "CA1":
                                case "CA2":
                                case "HC":
                                    //if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("07:35:00"))
                                    if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) <= (TimeSpan.Parse(r.Cells["GioBatDau"].Value.ToString()) - TimeSpan.Parse("00:13:00"))
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString()))
                                    {
                                        var giobatdau = TimeSpan.Parse(r.Cells["GioBatDau"].Value.ToString());
                                        //Random TenBienRanDom = new Random();
                                        var sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes == 0 ? 59 : giobatdau.Minutes);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes == 0 ? 59 : giobatdau.Minutes);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + (giobatdau - TimeSpan.Parse("00:13:00")).Hours.ToString().PadLeft(2, '0') + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    //else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("16:45:00"))
                                    else if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) >= (TimeSpan.Parse(r.Cells["GioKetThuc"].Value.ToString()) + TimeSpan.Parse("00:13:00"))
                                            && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()))
                                    {
                                        var gioketthuc = TimeSpan.Parse(r.Cells["GioKetThuc"].Value.ToString());
                                        //Random TenBienRanDom = new Random();
                                        var sophut = TenBienRanDom.Next(gioketthuc.Minutes + 1, (gioketthuc + TimeSpan.Parse("00:13:00")).Minutes);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next(gioketthuc.Minutes + 1, (gioketthuc + TimeSpan.Parse("00:13:00")).Minutes);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + gioketthuc.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    else if (r.Cells["Ca"].Value.ToString() == "HC"
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString())
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()))
                                    {
                                        if (r.Cells["LoaiDangKy"].Value.ToString() == "1")
                                        {
                                            if (r.Cells["AnTruaCaHC"].Value.ToString() == "0"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("12:43:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(31, 43);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(31, 43);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 12:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            else if (r.Cells["AnTruaCaHC"].Value.ToString() == "1"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("12:00:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(51, 59);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(51, 59);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 11:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        else if (r.Cells["LoaiDangKy"].Value.ToString() == "0")
                                        {
                                            if (r.Cells["AnTruaCaHC"].Value.ToString() == "0"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("12:17:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(17, 29);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(17, 29);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 12:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            else if (r.Cells["AnTruaCaHC"].Value.ToString() == "1"
                                                && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("11:37:00"))
                                            {
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(37, 49);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(37, 49);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " 11:" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            // nuoi con nho
                                            else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                            {
                                                var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        // nuoi con nho
                                        else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                        {
                                            var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                            //Random TenBienRanDom = new Random();
                                            var sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                            var sogiay = TenBienRanDom.Next(1, 59);
                                            for (int i = 0; i <= 10; i++)
                                            {
                                                if (sophutnew == sophut)
                                                {
                                                    sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                    sogiay = TenBienRanDom.Next(1, 59);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            sophutnew = sophut;
                                            ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                        }
                                    }
                                    else if (r.Cells["Ca"].Value.ToString() != "HC"
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse(r.Cells["GioVaoLam"].Value.ToString())
                                        && TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()))
                                    {
                                        if (r.Cells["LoaiDangKy"].Value.ToString() == "1")
                                        {
                                            var giobatdau = TimeSpan.Parse(r.Cells["GioNghiTrua"].Value.ToString());
                                            //Random TenBienRanDom = new Random();
                                            var sophut = TenBienRanDom.Next(giobatdau.Minutes, 13);
                                            var sogiay = TenBienRanDom.Next(1, 59);
                                            for (int i = 0; i <= 10; i++)
                                            {
                                                if (sophutnew == sophut)
                                                {
                                                    sophut = TenBienRanDom.Next(giobatdau.Minutes, 13);
                                                    sogiay = TenBienRanDom.Next(1, 59);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            sophutnew = sophut;
                                            ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                        }
                                        else if (r.Cells["LoaiDangKy"].Value.ToString() == "0")
                                        {
                                            if (TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse(r.Cells["GioNghiTrua"].Value.ToString()) - TimeSpan.Parse("00:13:00"))
                                            {
                                                var giobatdau = TimeSpan.Parse(r.Cells["GioNghiTrua"].Value.ToString());
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, giobatdau.Minutes);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                            // nuoi con nho
                                            else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                            {
                                                var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                                //Random TenBienRanDom = new Random();
                                                var sophut = TenBienRanDom.Next(giobatdau.Minutes, (giobatdau + TimeSpan.Parse("00:13:00")).Minutes);
                                                var sogiay = TenBienRanDom.Next(1, 59);
                                                for (int i = 0; i <= 10; i++)
                                                {
                                                    if (sophutnew == sophut)
                                                    {
                                                        sophut = TenBienRanDom.Next(giobatdau.Minutes, (giobatdau + TimeSpan.Parse("00:13:00")).Minutes);
                                                        sogiay = TenBienRanDom.Next(1, 59);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                sophutnew = sophut;
                                                ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                            }
                                        }
                                        // nuoi con nho
                                        else if (!string.IsNullOrEmpty(r.Cells["NgayBatDau"].Value.ToString()))
                                        {
                                            var giobatdau = TimeSpan.Parse(r.Cells["GioKetThucLam"].Value.ToString()) - TimeSpan.Parse("01:00:00");
                                            //Random TenBienRanDom = new Random();
                                            var sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                            var sogiay = TenBienRanDom.Next(1, 59);
                                            for (int i = 0; i <= 10; i++)
                                            {
                                                if (sophutnew == sophut)
                                                {
                                                    sophut = TenBienRanDom.Next(giobatdau.Minutes, giobatdau.Minutes + 13);
                                                    sogiay = TenBienRanDom.Next(1, 59);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            sophutnew = sophut;
                                            ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + giobatdau.Hours + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                        }
                                    }
                                    break;
                                case "CA3":
                                    if (
                                        //TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) < TimeSpan.Parse("21:45:00") 
                                        TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) <= (TimeSpan.Parse(r.Cells["GioBatDau"].Value.ToString()) - TimeSpan.Parse("00:13:00"))
                                        &&
                                        //TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) > TimeSpan.Parse("17:00:00") 
                                        TimeSpan.Parse(r.Cells["GioCham"].Value.ToString()) >= (TimeSpan.Parse(r.Cells["GioBatDau"].Value.ToString()) - TimeSpan.Parse("05:00:00")))
                                    {
                                        var giobatdau = TimeSpan.Parse(r.Cells["GioBatDau"].Value.ToString());
                                        //Random TenBienRanDom3 = new Random();
                                        var sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, 59);
                                        var sogiay = TenBienRanDom.Next(1, 59);
                                        for (int i = 0; i <= 10; i++)
                                        {
                                            if (sophutnew == sophut)
                                            {
                                                sophut = TenBienRanDom.Next((giobatdau - TimeSpan.Parse("00:13:00")).Minutes, 59);
                                                sogiay = TenBienRanDom.Next(1, 59);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        sophutnew = sophut;
                                        ngaycham = DateTime.Parse(r.Cells["NgayCham"].Value.ToString()).ToString("yyyy/MM/dd") + " " + (giobatdau - TimeSpan.Parse("00:13:00")).Hours.ToString().PadLeft(2, '0') + ":" + sophut + ":" + sogiay.ToString().PadLeft(2, '0');
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        sql = $"Update CheckInOut set GioCham = '{ngaycham}' " +
                                $"Where ID = '{r.Cells["Id"].Value.ToString()}'";
                        if (!string.IsNullOrEmpty(ngaycham))
                        {
                            bool check = DataProvider.add_CheckInOut_Backup(int.Parse(r.Cells["MaChamCong"].Value.ToString()), r.Cells["NgayCham"].Value.ToString());
                            if (check == true)
                            {
                                SQLHelper.ExecuteSql(sql);
                            }
                            else
                            {
                                RJMessageBox.Show("Sao lưu dữ liệu thất bại " + Environment.NewLine + " vui lòng liên hệ IT", "Thông báo");
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + " - " + r.Cells["MaChamCong"].Value.ToString() + " - " + r.Cells["NgayCham"].Value.ToString());
                    }
                }
                RJMessageBox.Show("Cập nhật thành công");
                LoadData();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.WaitCursor;
        }
        private void LoadData()
        {
            string sql_pro = $"proc_DanhSachDiSomVeMuon {cbo_Nam.SelectedValue}, {cbo_Thang.Text}";
            DataTable data = SQLHelper.ExecuteDt(sql_pro);
            //dgv_Data.DataSource = data;

            DataTable dt_CaLamViec = new DataTable();
            dt_CaLamViec = SQLHelper.ExecuteDt("select MaCaLamViec,GioVaoLamViec,GioKetThucLamViec from CaLamViecNew");

            DataTable dt_BangXepCa = new DataTable();
            dt_BangXepCa = SQLHelper.ExecuteDt($"select * from BangXepCa Where Thang = '{cbo_Thang.Text}' and Nam = '{cbo_Nam.Text}'");

            DataTable dt_DangKyTangCa = new DataTable();
            string sql_DangKyTangCa = "select MaChamCong,NgayTangCa,GioBatDau,GioKetThuc,LoaiTangCa,GioTangCa " +
                $"from DangKyTangCa where YEAR(NgayTangCa) = {cbo_Nam.Text} and MONTH(NgayTangCa) = {cbo_Thang.Text}";
            dt_DangKyTangCa = SQLHelper.ExecuteDt(sql_DangKyTangCa);

            foreach (DataRow item in data.Rows)
            {
                if (item["LoaiTangCa"].ToString() == "1"
                    && TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse(item["GioVaoLam"].ToString())
                    && item["Ca"].ToString() != "CA3")
                {
                    var dangkytangca = dt_DangKyTangCa.Rows.Cast<DataRow>()
                                        .Where(x => x["MaChamCong"].ToString() == item["MaChamCong"].ToString()
                                        && DateTime.Parse(x["NgayTangCa"].ToString()).ToString("yyyy/MM/dd") == DateTime.Parse(item["NgayCham"].ToString()).ToString("yyyy/MM/dd")
                                        && x["LoaiTangCa"].ToString() == "0").FirstOrDefault();
                    if (dangkytangca != null)
                    {
                        item["LoaiTangCa"] = "0";
                        item["GioTangCa"] = dangkytangca["GioTangCa"].ToString();
                        item["GioBatDau"] = dangkytangca["GioBatDau"].ToString();
                        item["GioKetThuc"] = dangkytangca["GioKetThuc"].ToString();
                    }
                    else
                    {
                        item["LoaiTangCa"] = "";
                    }
                }
                else if (item["LoaiTangCa"].ToString() == "0"
                    && TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse(item["GioKetThucLam"].ToString())
                    && item["Ca"].ToString() != "CA3")
                {
                    var dangkytangca = dt_DangKyTangCa.Rows.Cast<DataRow>()
                    .Where(x => x["MaChamCong"].ToString() == item["MaChamCong"].ToString()
                    && x["NgayTangCa"].ToString() == item["NgayCham"].ToString()
                    && x["LoaiTangCa"].ToString() == "1").FirstOrDefault();
                    if (dangkytangca != null)
                    {
                        item["LoaiTangCa"] = "1";
                        item["GioTangCa"] = dangkytangca["GioTangCa"].ToString();
                        item["GioBatDau"] = dangkytangca["GioBatDau"].ToString();
                        item["GioKetThuc"] = dangkytangca["GioKetThuc"].ToString();
                    }
                    else
                    {
                        item["LoaiTangCa"] = "";
                    }
                }
                // gio ra ca 3
                if ((item["Ca"].ToString() == "HC" || item["Ca"].ToString() == "") && TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse("08:00:00"))
                {
                    string ca = "";
                    int ngay = DateTime.Parse(item["NgayCham"].ToString()).Day;
                    DateTime ngaythangnam = DateTime.Parse(cbo_Nam.Text + "/" + cbo_Thang.Text.PadLeft(2, '0') + "/" + ngay.ToString().PadLeft(2, '0')).AddDays(-1);
                    if (ngay == 1)
                    {
                        DataTable dt_BangXepCa1 = new DataTable();
                        dt_BangXepCa1 = SQLHelper.ExecuteDt($"select * from BangXepCa Where Thang = '{ngaythangnam.Month}' and Nam = '{ngaythangnam.Year}'");
                        ca = dt_BangXepCa1.Rows.Cast<DataRow>()
                        .Where(x => x["MaChamCong"].ToString() == item["MaChamCong"].ToString())
                        .Select(x => x["D" + (ngaythangnam.Day)].ToString()).FirstOrDefault();
                    }
                    else
                    {
                        ca = dt_BangXepCa.Rows.Cast<DataRow>()
                        .Where(x => x["MaChamCong"].ToString() == item["MaChamCong"].ToString())
                        .Select(x => x["D" + (ngay - 1)].ToString()).FirstOrDefault();
                    }

                    var calamviec = dt_CaLamViec.Rows.Cast<DataRow>().Where(x => x["MaCaLamViec"].ToString() == (ca == "" ? "HC" : ca)).FirstOrDefault();
                    //if (ca == "CA3" && (TimeSpan.Parse(item["GioCham"].ToString()) < (TimeSpan.Parse(DateTime.Parse(calamviec["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss")) + TimeSpan.Parse("00:14:00"))))
                    //{
                    //    item.Delete();
                    //}
                    if (ca == "CA3")
                    {
                        item["Ca"] = ca;
                        item["GioVaoLam"] = DateTime.Parse(calamviec["GioVaoLamViec"].ToString()).ToString("HH:mm:ss");
                        item["GioKetThucLam"] = DateTime.Parse(calamviec["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss");
                        if (TimeSpan.Parse(item["GioCham"].ToString()) < (TimeSpan.Parse(DateTime.Parse(calamviec["GioKetThucLamViec"].ToString()).ToString("HH:mm:ss")) + TimeSpan.Parse("00:13:00")))
                        {
                            item.Delete();
                            continue;
                        }
                    }
                }

                // khong tang ca
                if (item["LoaiTangCa"].ToString() == "")
                {
                    if ((TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse(item["GioVaoLam"].ToString()) - TimeSpan.Parse("00:13:00")
                    && TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse(item["GioVaoLam"].ToString())))
                    {
                        item.Delete();
                    }
                    else if ((TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse(item["GioKetThucLam"].ToString()) + TimeSpan.Parse("00:13:00")
                    && TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse(item["GioKetThucLam"].ToString())))
                    {
                        item.Delete();
                        //item.Delete();
                    }
                    else if (TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse(item["GioVaoLam"].ToString())
                            && TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse(item["GioKetThucLam"].ToString()))
                    {
                        var calamviec = dt_CaLamViec.Rows.Cast<DataRow>().Where(x => x["MaCaLamViec"].ToString() == (item["Ca"].ToString() == "" ? "HC" : item["Ca"].ToString())).FirstOrDefault();
                        if (item["CA"].ToString() == "HC"
                            && item["LoaiDangKy"].ToString() == "1")
                        {
                            if (
                                //TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse("12:30:00") && 
                                TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse("12:43:00")
                                && item["AnTruaCaHC"].ToString() == "0")
                            {
                                item.Delete();
                            }
                            else if (
                                //TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse("11:50:00") && 
                                TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse("12:03:00")
                                && item["AnTruaCaHC"].ToString() == "1")
                            {
                                item.Delete();
                            }
                        }
                        else if (item["CA"].ToString() == "HC"
                                 && item["LoaiDangKy"].ToString() == "0")
                        {
                            if (TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse("12:17:00")
                                //&& TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse("12:30:00")
                                && item["AnTruaCaHC"].ToString() == "0")
                            {
                                item.Delete();
                            }
                            else if (
                                //TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse("11:50:00") && 
                                TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse("11:37:00")
                                && item["AnTruaCaHC"].ToString() == "1")
                            {
                                item.Delete();
                            }
                        }
                        else if (item["LoaiDangKy"].ToString() == "1"
                            && TimeSpan.Parse(item["GioCham"].ToString()) <= (TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString()) + TimeSpan.Parse("00:13:00"))
                            //&& TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString())
                            )
                        {
                            item.Delete();
                        }
                        else if (item["LoaiDangKy"].ToString() == "0"
                            && TimeSpan.Parse(item["GioCham"].ToString()) >= (TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString()) - TimeSpan.Parse("00:13:00"))
                            //&& TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString())
                            )
                        {
                            item.Delete();
                        }
                        else if (string.IsNullOrEmpty(item["NgayBatDau"].ToString()))
                        {
                            item.Delete();
                        }
                    }
                }
                // co tang ca
                else if (item["LoaiTangCa"].ToString() != "")
                {
                    if (TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse(item["GioBatDau"].ToString()) - TimeSpan.Parse("00:13:00")
                    && TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse(item["GioBatDau"].ToString()))
                    {
                        item.Delete();
                    }
                    else if (TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse(item["GioKetThuc"].ToString()) + TimeSpan.Parse("00:13:00")
                    && TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse(item["GioKetThuc"].ToString()))
                    {
                        item.Delete();
                    }
                    else if ((TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse(item["GioVaoLam"].ToString())
                            && TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse(item["GioKetThucLam"].ToString()))
                            || (TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse(item["GioBatDau"].ToString())
                            && TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse(item["GioKetThuc"].ToString())))
                    {
                        var calamviec = dt_CaLamViec.Rows.Cast<DataRow>().Where(x => x["MaCaLamViec"].ToString() == (item["Ca"].ToString() == "" ? "HC" : item["Ca"].ToString())).FirstOrDefault();
                        if (item["CA"].ToString() == "HC"
                            && item["LoaiDangKy"].ToString() == "1")
                        {
                            if (
                                //TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse("12:30:00") && 
                                TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse("12:43:00")
                                && item["AnTruaCaHC"].ToString() == "0")
                            {
                                item.Delete();
                            }
                            else if (
                                //TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse("11:50:00")&& 
                                TimeSpan.Parse(item["GioCham"].ToString()) <= TimeSpan.Parse("12:03:00")
                                && item["AnTruaCaHC"].ToString() == "1")
                            {
                                item.Delete();
                            }
                        }
                        else if (item["CA"].ToString() == "HC"
                                 && item["LoaiDangKy"].ToString() == "0")
                        {
                            if (TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse("12:17:00")
                                 //&& TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse("12:30:00")
                                 && item["AnTruaCaHC"].ToString() == "0")
                            {
                                item.Delete();
                            }
                            else if (TimeSpan.Parse(item["GioCham"].ToString()) >= TimeSpan.Parse("11:37:00")
                                 //&& TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse("11:50:00")
                                 && item["AnTruaCaHC"].ToString() == "1")
                            {
                                item.Delete();
                            }
                        }
                        else if (item["LoaiDangKy"].ToString() == "1"
                            && TimeSpan.Parse(item["GioCham"].ToString()) <= (TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString()) + TimeSpan.Parse("00:13:00"))
                            //&& TimeSpan.Parse(item["GioCham"].ToString()) > TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString())
                            )
                        {
                            item.Delete();
                        }
                        else if (item["LoaiDangKy"].ToString() == "0"
                            && TimeSpan.Parse(item["GioCham"].ToString()) >= (TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString()) - TimeSpan.Parse("00:13:00"))
                            //&& TimeSpan.Parse(item["GioCham"].ToString()) < TimeSpan.Parse(calamviec["GioBatDauNghiTrua"].ToString())
                            )
                        {
                            item.Delete();
                        }
                        else if (string.IsNullOrEmpty(item["NgayBatDau"].ToString()))
                        {
                            item.Delete();
                        }
                    }
                }
            }
            data.AcceptChanges();
            var dt_new = (from a in data.Rows.Cast<DataRow>()
                          group new { a } by new
                          {
                              Id = int.Parse(a["Id"].ToString()),
                              MaChamCong = int.Parse(a["MaChamCong"].ToString()),
                              TenNhanVien = a["TenNhanVien"].ToString(),
                              MaNhanVien = a["MaNhanVien"].ToString(),
                              TenPhongBan = a["TenPhongBan"].ToString(),
                              NgayCham = a["NgayCham"].ToString(),
                              GioCham = a["GioCham"].ToString(),
                              Ca = a["Ca"].ToString(),
                              TenMay = a["TenMay"].ToString(),
                              update_flg = int.Parse(a["update_flg"].ToString()),
                              LoaiTangCa = a["LoaiTangCa"].ToString(),
                              GioTangCa = a["GioTangCa"].ToString(),
                              GioBatDau = a["GioBatDau"].ToString(),
                              GioKetThuc = a["GioKetThuc"].ToString(),
                              GioVaoLam = a["GioVaoLam"].ToString(),
                              GioKetThucLam = a["GioKetThucLam"].ToString(),
                              LoaiDangKy = a["LoaiDangKy"].ToString(),
                              AnTruaCaHC = a["AnTruaCaHC"].ToString(),
                              GioNghiTrua = a["GioNghiTrua"].ToString(),
                              NgayBatDau = a["NgayBatDau"].ToString(),
                              NgayKetThuc = a["NgayKetThuc"].ToString()
                          } into g
                          select new DataModel
                          {
                              Id = g.Key.Id,
                              MaChamCong = g.Key.MaChamCong,
                              TenNhanVien = g.Key.TenNhanVien,
                              MaNhanVien = g.Key.MaNhanVien,
                              TenPhongBan = g.Key.TenPhongBan,
                              NgayCham = g.Key.NgayCham,
                              GioCham = g.Key.GioCham,
                              Ca = g.Key.Ca,
                              TenMay = g.Key.TenMay,
                              update_flg = g.Key.update_flg,
                              LoaiTangCa = g.Key.LoaiTangCa,
                              GioTangCa = g.Key.GioTangCa,
                              GioBatDau = g.Key.GioBatDau,
                              GioKetThuc = g.Key.GioKetThuc,
                              GioVaoLam = g.Key.GioVaoLam,
                              GioKetThucLam = g.Key.GioKetThucLam,
                              LoaiDangKy = g.Key.LoaiDangKy,
                              AnTruaCaHC = g.Key.AnTruaCaHC,
                              GioNghiTrua = g.Key.GioNghiTrua,
                              NgayBatDau = g.Key.NgayBatDau,
                              NgayKetThuc = g.Key.NgayKetThuc
                          }).Distinct().ToList();
            dgv_Data.DataSource = dt_new;
        }
        private void frm_ChinhVaoSomRaMuon_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void LoadThang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            for (int i = 1; i <= 12; i++)
            {
                dt.Rows.Add(i, i);
            }
            cbo_Thang.DataSource = dt;
            cbo_Thang.DisplayMember = "Name";
            cbo_Thang.ValueMember = "Id";
            cbo_Thang.SelectedValue = DateTime.Now.Month;
        }

        private void LoadNam()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            for (int i = DateTime.Now.Year - 4; i <= DateTime.Now.Year + 4; i++)
            {
                dt.Rows.Add(i, i);
            }
            cbo_Nam.DataSource = dt;
            cbo_Nam.DisplayMember = "Name";
            cbo_Nam.ValueMember = "Id";
            cbo_Nam.SelectedValue = DateTime.Now.Year;
        }

        private void dgv_Data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (grid.RowHeadersWidth < textSize.Width + 10)
            {
                grid.RowHeadersWidth = textSize.Width + 10;
            }
            var headerBounds =
                new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
    public class DataModel
    {
        public int Id { get; set; }
        public int MaChamCong { get; set; }
        public string TenNhanVien { get; set; }
        public string MaNhanVien { get; set; }
        public string TenPhongBan { get; set; }
        public string NgayCham { get; set; }
        public string GioCham { get; set; }
        public string Ca { get; set; }
        public string TenMay { get; set; }
        public int update_flg { get; set; }
        public string LoaiTangCa { get; set; }
        public string GioTangCa { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public string GioVaoLam { get; set; }
        public string GioKetThucLam { get; set; }
        public string LoaiDangKy { get; set; }
        public string AnTruaCaHC { get; set; }
        public string GioNghiTrua { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
    }
}
