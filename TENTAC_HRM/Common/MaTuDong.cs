using System.Data.SqlClient;

namespace TENTAC_HRM.Common
{
    internal class MaTuDong : Provider
    {
        private SqlConnection sqlMaTuDong = Provider.get_Connect();

        private int Maxa = 1;

        public string sTuDongDienMCC(string sMCC)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select mamcc from maychamcong", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sMCC = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sMCC.ToString().Trim().Substring(3, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sMCC = "MCC" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sMCC = "MCC" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sMCC = "MCC" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sMCC = "MCC" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sMCC = string.Concat(Maxa);
            }
            return sMCC;
        }

        public string sTuDongDienNguoiDung(string sND)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaNguoiDung from NGUOIDUNG", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sND = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sND.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sND = "ND" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sND = "ND" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sND = "ND" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sND = "ND" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sND = string.Concat(Maxa);
            }
            return sND;
        }

        public string sTuDongDienCongTy(string sCT)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaCongTy from CONGTY", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sCT = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sCT.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sCT = "CT" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sCT = "CT" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sCT = "CT" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sCT = "CT" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sCT = string.Concat(Maxa);
            }
            return sCT;
        }

        public string sTuDongDienKyHieu(string sKyHieu)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaKyHieu from KYHIEUCHAMCONG", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sKyHieu = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sKyHieu.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sKyHieu = "KH" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sKyHieu = "KH" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sKyHieu = "KH" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sKyHieu = "KH" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sKyHieu = string.Concat(Maxa);
            }
            return sKyHieu;
        }

        public string sTuDongDienNgayLe(string sNgayLe)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaNgayLe from NGAYLE", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sNgayLe = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sNgayLe.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sNgayLe = "NL" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sNgayLe = "NL" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sNgayLe = "NL" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sNgayLe = "NL" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sNgayLe = string.Concat(Maxa);
            }
            return sNgayLe;
        }

        public string sTuDongDienLichTrinhVaoRa(string sLichTrinhVaoRa)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaLichTrinhVaoRa from LICHTRINHVAORA", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sLichTrinhVaoRa = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sLichTrinhVaoRa.ToString().Trim().Substring(4, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sLichTrinhVaoRa = "LTVR" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sLichTrinhVaoRa = "LTVR" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sLichTrinhVaoRa = "LTVR" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sLichTrinhVaoRa = "LTVR" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sLichTrinhVaoRa = string.Concat(Maxa);
            }
            return sLichTrinhVaoRa;
        }

        public string sTuDongDienLichTrinhChoCaLamViec(string sLichTrinhChoCaLamViec)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaLichTrinhCaLamViec from LICHTRINHCHOCALAMVIEC", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sLichTrinhChoCaLamViec = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sLichTrinhChoCaLamViec.ToString().Trim().Substring(5, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sLichTrinhChoCaLamViec = "LTCLV" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sLichTrinhChoCaLamViec = "LTCLV" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sLichTrinhChoCaLamViec = "LTCLV" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sLichTrinhChoCaLamViec = "LTCLV" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sLichTrinhChoCaLamViec = string.Concat(Maxa);
            }
            return sLichTrinhChoCaLamViec;
        }

        public string sTuDongDienTuyChon(string sTuyChon)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaTuyChinh from TUYCHON", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sTuyChon = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sTuyChon.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sTuyChon = "TC" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sTuyChon = "TC" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sTuyChon = "TC" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sTuyChon = "TC" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sTuyChon = string.Concat(Maxa);
            }
            return sTuyChon;
        }

        public string sTuDongDienKhuVuc(string sKhuVuc)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaKhuVuc from KHUVUC", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sKhuVuc = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sKhuVuc.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sKhuVuc = "KV" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sKhuVuc = "KV" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sKhuVuc = "KV" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sKhuVuc = "KV" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sKhuVuc = string.Concat(Maxa);
            }
            return sKhuVuc;
        }

        public string sTuDongDienPhongBan(string sPhongBan)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaPhongBan from PHONGBAN", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sPhongBan = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sPhongBan.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sPhongBan = "PB" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sPhongBan = "PB" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sPhongBan = "PB" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sPhongBan = "PB" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sPhongBan = string.Concat(Maxa);
            }
            return sPhongBan;
        }

        public string sTuDongDienChucVu(string sChucVu)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaChucVu from CHUCVU", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sChucVu = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sChucVu.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sChucVu = "CV" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sChucVu = "CV" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sChucVu = "CV" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sChucVu = "CV" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sChucVu = string.Concat(Maxa);
            }
            return sChucVu;
        }

        public string sTuDongDienCacLoaiVang(string sCacLoaiVang)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaCacLoaiVang from CACLOAIVANG", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sCacLoaiVang = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sCacLoaiVang.ToString().Trim().Substring(1, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sCacLoaiVang = "V" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sCacLoaiVang = "V" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sCacLoaiVang = "V" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sCacLoaiVang = "V" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sCacLoaiVang = string.Concat(Maxa);
            }
            return sCacLoaiVang;
        }

        public string sTuDongDienMucLuongToiThieu(string sMucLuongToiThieu)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaLuongToiThieu from MUCLUONGTOITHIEU", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sMucLuongToiThieu = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sMucLuongToiThieu.ToString().Trim().Substring(3, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sMucLuongToiThieu = "LTT" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sMucLuongToiThieu = "LTT" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sMucLuongToiThieu = "LTT" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sMucLuongToiThieu = "LTT" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sMucLuongToiThieu = string.Concat(Maxa);
            }
            return sMucLuongToiThieu;
        }

        public string sTuDongDienChucVuNhanVien(string sChucVuNhanVien)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaChucVuNhanVien from CHUCVUNHANVIEN", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sChucVuNhanVien = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sChucVuNhanVien.ToString().Trim().Substring(4, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sChucVuNhanVien = "CVNV" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sChucVuNhanVien = "CVNV" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sChucVuNhanVien = "CVNV" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sChucVuNhanVien = "CVNV" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sChucVuNhanVien = string.Concat(Maxa);
            }
            return sChucVuNhanVien;
        }

        public string sTuDongDienTinhThanh(string sTinhThanh)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaTinhThanh from TINHTHANH", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sTinhThanh = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sTinhThanh.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sTinhThanh = "TT" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sTinhThanh = "TT" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sTinhThanh = "TT" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sTinhThanh = "TT" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sTinhThanh = string.Concat(Maxa);
            }
            return sTinhThanh;
        }

        public string sTuDongDienPhuCap(string sPhuCap)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaPhuCap from PHUCAP", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sPhuCap = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sPhuCap.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sPhuCap = "PC" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sPhuCap = "PC" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sPhuCap = "PC" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sPhuCap = "PC" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sPhuCap = string.Concat(Maxa);
            }
            return sPhuCap;
        }

        public string sTuDongDienCaLamViec(string sCaLamViec)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select top 1 MaCaLamViec from MITACOSQL.dbo.CaLamViecNew where MaCaLamViec != 'HC' order by MaCaLamViec desc", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sCaLamViec = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sCaLamViec.ToString().Trim().Substring(2, sCaLamViec.Length - 2));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            sCaLamViec = "CA" + Maxa;
            return sCaLamViec;
        }

        public string sTuDongDienDanToc(string sDanToc)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaDanToc from DanToc", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sDanToc = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sDanToc.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sDanToc = "DT" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sDanToc = "DT" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sDanToc = "DT" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sDanToc = "DT" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sDanToc = string.Concat(Maxa);
            }
            return sDanToc;
        }

        public string sTuDongDienQuocTich(string sQuocTich)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaQuocTich from QuocTich", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sQuocTich = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sQuocTich.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sQuocTich = "QT" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sQuocTich = "QT" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sQuocTich = "QT" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sQuocTich = "QT" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sQuocTich = string.Concat(Maxa);
            }
            return sQuocTich;
        }

        public string sTuDongDienMayChu(string sMayChu)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select ID from Maychu", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sMayChu = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sMayChu.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sMayChu = "MC" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sMayChu = "MC" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sMayChu = "MC" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sMayChu = "MC" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sMayChu = string.Concat(Maxa);
            }
            return sMayChu;
        }

        public string sTuDongDienTrinhDo(string sTrinhDo)
        {
            int iMaxSoSanh = 1;
            SqlCommand sqlcmdLenhThucThi = new SqlCommand("Select MaTrinhDo from TrinhDo", sqlMaTuDong);
            SqlDataReader sqldatareader = sqlcmdLenhThucThi.ExecuteReader();
            while (sqldatareader.Read())
            {
                for (int ii = 0; ii < sqldatareader.GetValue(0).ToString().Length; ii++)
                {
                    sTrinhDo = sqldatareader.GetValue(0).ToString().Trim();
                    int iLaySoDuoi = int.Parse(sTrinhDo.ToString().Trim().Substring(2, 5));
                    if (iMaxSoSanh == iLaySoDuoi)
                    {
                        iMaxSoSanh++;
                    }
                    if (iMaxSoSanh != iLaySoDuoi)
                    {
                        Maxa = iMaxSoSanh;
                    }
                }
            }
            sqldatareader.Close();
            if (Maxa < 10)
            {
                sTrinhDo = "TD" + "0000" + Maxa;
            }
            if (Maxa >= 10)
            {
                sTrinhDo = "TD" + "000" + Maxa;
            }
            if (Maxa >= 100)
            {
                sTrinhDo = "TD" + "00" + Maxa;
            }
            if (Maxa >= 1000)
            {
                sTrinhDo = "TD" + "0" + Maxa;
            }
            if (Maxa >= 10000)
            {
                sTrinhDo = string.Concat(Maxa);
            }
            return sTrinhDo;
        }
    }
}
