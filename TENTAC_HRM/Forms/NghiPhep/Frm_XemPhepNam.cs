﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.NghiPhep
{
    public partial class Frm_XemPhepNam : Form
    {
        public string _machamcong { get; set; }
        public string _year { get; set; }
        public Frm_XemPhepNam()
        {
            InitializeComponent();
        }

        private void Frm_XemPhepNam_Load(object sender, EventArgs e)
        {
            //string sql_bangxapca = $"Select * from BangXepCa where Nam = '{_year}' and MaChamCong = '{_machamcong}'";
            //DataTable dt_xepca = new DataTable();
            //dt_xepca = SQLHelper.ExecuteDt(sql_bangxapca);

            //string sql_ngaynghi = $"Select * From NgayNghi Where Nam = '{_year}'";
            //DataTable dt_ngaynghi = new DataTable();
            //dt_ngaynghi = SQLHelper.ExecuteDt(sql_ngaynghi);

            DataTable dt = new DataTable();
            string sql_socot = $"SELECT PhepTrongNam,PhepDocHai,TongNgayPhep FROM tbl_NgayPhepNam where MaChamCong = '{_machamcong}' and Nam = '{_year}'";
            dt = SQLHelper.ExecuteDt(sql_socot);

            DataTable data = new DataTable();
            string sql = "select f.id,a.MaNhanVien,a.TenNhanVien,d.TenKhuVuc,c.TenChucVu," +
                         "e.typename as TrangThai,f.NgayNghi,g.TenLoaiPhep,f.GhiChu,g.LoaiPhep," +
                         "f.SoNgay,f.NgayTao,f.NuaNgay " +
                         "from MITACOSQL.dbo.NhanVien a " +
                         "join tbl_NhanVien b on a.MaNhanVien = b.MaNhanVien " +
                         //"join nhanvien_phongban b on a.manhanvien = b.ma_nhan_vien and is_active = 1 " +
                         "join MITACOSQL.dbo.CHUCVU c on c.MachucVu = a.MaChucVu " +
                         "join MITACOSQL.dbo.KHUVUC d on d.MaKhuVuc = a.MaKhuVuc " +
                         "join sys_AllType e on b.id_trangthai = e.typeid " +
                         "join tbl_NghiPhepNam f on f.MaChamCong = a.MaChamCong " +
                         "join mst_LoaiPhep g on g.MaLoaiPhep = f.LoaiPhepNghi " +
                         $"where f.nam = '{_year}' and f.del_flg = 0 and a.MaChamCong = '{_machamcong}' and f.Chk_NhanSu = 1 " +
                         $"order by f.NgayNghi";
            data = SQLHelper.ExecuteDt(sql);

            var phepnam = data.Rows.Cast<DataRow>().Where(x => x["LoaiPhep"].ToString().Equals("PN")).ToList();
            var phepkhac = data.Rows.Cast<DataRow>().Where(x => x["LoaiPhep"].ToString() != "PN").ToList();

            decimal tongphepnam = phepnam.Sum(x => decimal.Parse(x["SoNgay"].ToString()));

            decimal PhepTrongNam = decimal.Parse(dt.Rows[0]["PhepTrongNam"].ToString()) - decimal.Parse(dt.Rows[0]["PhepDocHai"].ToString());
            decimal Phepdochai = decimal.Parse(dt.Rows[0]["PhepDocHai"].ToString());

            //List<NghiPhepModel> ngayphep = new List<NghiPhepModel>();
            //List<NghiPhepModel> ngaypheple = new List<NghiPhepModel>();

            //foreach (DataRow row in phepnam)
            //{
            //    if (row["SoNgay"].ToString() == "0.5")
            //    {
            //        NghiPhepModel nghiphep = new NghiPhepModel();
            //        nghiphep.SoNgay = decimal.Parse(row["SoNgay"].ToString());
            //        nghiphep.NgayVietPhep = row["NgayTao"].ToString();
            //        nghiphep.NgayNghi = DateTime.Parse(row["NgayNghi"].ToString()).ToString("yyyy/MM/dd");
            //        nghiphep.LoaiPhep = row["LoaiPhep"].ToString();
            //        ngaypheple.Add(nghiphep);
            //    }
            //    else
            //    {
            //        NghiPhepModel nghiPhep = new NghiPhepModel();
            //        nghiPhep.SoNgay = decimal.Parse(row["SoNgay"].ToString());
            //        nghiPhep.NgayVietPhep = row["NgayTao"].ToString();
            //        nghiPhep.NgayNghi = DateTime.Parse(row["NgayNghi"].ToString()).ToString("yyyy/MM/dd");
            //        nghiPhep.LoaiPhep = row["LoaiPhep"].ToString();
            //        ngayphep.Add(nghiPhep);
            //    }
            //}

            string html = "";
            for (int i = 1; i <= PhepTrongNam; i++)
            {
                int thang = i;
                if (i > 12)
                {
                    thang = int.Parse(_year) - 1;
                }
                if (phepnam.Count > 0)
                {
                    bool nuangay = false;

                    var listnew = phepnam[0];
                    if (listnew["SoNgay"].ToString() == "0.5")
                    {
                        nuangay = true;
                    }
                    if(nuangay == true)
                    {
                        for (int j = 1; j <= 2; j++)
                        {
                            if (j == 1)
                            {
                                html += "<tr> \r\n" +
                                        $"<td style='text-align:center' rowspan=2>{thang}</td> \r\n" +
                                        $"<td class='borderbottomdotted'>{listnew["SoNgay"].ToString()}</td> \r\n" +
                                        $"<td class='borderbottomdotted'>{DateTime.Parse(listnew["NgayTao"].ToString()).ToString("dd/MM/yyyy")}</td> \r\n" +
                                        $"<td class='borderbottomdotted'>{DateTime.Parse(listnew["NgayNghi"].ToString()).ToString("dd/MM/yyyy")}</td> \r\n" +
                                        $"<td class='borderbottomdotted'>{listnew["LoaiPhep"].ToString()}</td> \r\n" +
                                    "</tr> \r\n";
                                phepnam.Remove(listnew);
                            }
                            else
                            {
                                if (nuangay == true)
                                {
                                    var dr = phepnam.Where(x => x["SoNgay"].ToString() == "0.5").FirstOrDefault();
                                    html += "<tr> \r\n" +
                                            $"<td class='bordertopdotted'>{(dr != null ? dr["SoNgay"].ToString() : "")}</td> \r\n" +
                                            $"<td class='bordertopdotted'>{(dr != null ? DateTime.Parse(dr["NgayTao"].ToString()).ToString("dd/MM/yyyy") : "")}</td> \r\n" +
                                            $"<td class='bordertopdotted'>{(dr != null ? DateTime.Parse(dr["NgayNghi"].ToString()).ToString("dd/MM/yyyy") : "")}</td> \r\n" +
                                            $"<td class='bordertopdotted'>{(dr != null ? dr["LoaiPhep"].ToString() : "")}</td> \r\n" +
                                        "</tr> \r\n";
                                    phepnam.Remove(dr);
                                }
                                else
                                {
                                    html += "<tr> \r\n" +
                                            $"<td class='bordertopdotted'></td> \r\n" +
                                            $"<td class='bordertopdotted'></td> \r\n" +
                                            $"<td class='bordertopdotted'></td> \r\n" +
                                            $"<td class='bordertopdotted'></td> \r\n" +
                                        "</tr> \r\n";
                                }

                            }
                        }
                    }
                    else
                    {
                        html += "<tr> \r\n" +
                                $"<td style='text-align:center'>{thang}</td> \r\n" +
                                $"<td>{listnew["SoNgay"].ToString()}</td> \r\n" +
                                $"<td>{DateTime.Parse(listnew["NgayTao"].ToString()).ToString("dd/MM/yyyy")}</td> \r\n" +
                                $"<td>{DateTime.Parse(listnew["NgayNghi"].ToString()).ToString("dd/MM/yyyy")}</td> \r\n" +
                                $"<td>{listnew["LoaiPhep"].ToString()}</td> \r\n" +
                            "</tr> \r\n";
                        phepnam.Remove(listnew);
                    }
                }
                else
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        if (j == 1)
                        {
                            html += "<tr> \r\n" +
                                    $"<td style='text-align:center' rowspan=2>{thang}</td> \r\n" +
                                    $"<td class='borderbottomdotted'></td> \r\n" +
                                    $"<td class='borderbottomdotted'></td> \r\n" +
                                    $"<td class='borderbottomdotted'></td> \r\n" +
                                    $"<td class='borderbottomdotted'></td> \r\n" +
                                "</tr> \r\n";
                        }
                        else
                        {
                            html += "<tr> \r\n" +
                                    $"<td class='bordertopdotted'></td> \r\n" +
                                    $"<td class='bordertopdotted'></td> \r\n" +
                                    $"<td class='bordertopdotted'></td> \r\n" +
                                    $"<td class='bordertopdotted'></td> \r\n" +
                                "</tr> \r\n";
                        }

                    }
                }
            }
            if (Phepdochai > 0)
            {
                for (int i = 1; i <= Phepdochai; i++)
                {
                    html += "<tr> \r\n" +
                            $"<td>Độc hại</td> \r\n" +
                            $"<td></td> \r\n" +
                            $"<td></td> \r\n" +
                            $"<td></td> \r\n" +
                            $"<td></td> \r\n" +
                        "</tr> \r\n";
                }
            }

            //string html = "";
            //int index = 1;
            //foreach(var item in phepnam)
            //{
            //    string songay = item["SoNgay"].ToString();
            //    string ngaybatdau = item["NgayNghi"].ToString();
            //    string denngay = item["DenNgay"].ToString();

            //    for (int i = 0; i < int.Parse(songay); i++) {
            //        html += "<tr>" +
            //                $"<td>{index}</td>" +
            //                $"<td>{item}</td>" +
            //            "</tr> \r\n";
            //        index++;
            //    }
            //}
            var asm = Assembly.GetEntryAssembly();
            string filepath = $@"{Path.GetDirectoryName(asm.Location)}\Template\BangPhepNam.html";
            StreamReader read = new StreamReader(filepath, Encoding.Unicode);
            string html_template = read.ReadToEnd();
            html_template = html_template.Replace("[MatTruoc]", html);
            html_template = html_template.Replace("[Tong]", tongphepnam + "/" + dt.Rows[0]["TongNgayPhep"].ToString());
            webBrowser1.DocumentText = html_template;

            //FileStream source = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            //webBrowser1.DocumentStream = source;
        }
    }
    public class NghiPhepModel
    {
        public decimal SoNgay { get; set; }
        public string NgayVietPhep { get; set; }
        public string NgayNghi { get; set; }
        public string LoaiPhep { get; set; }

    }
}