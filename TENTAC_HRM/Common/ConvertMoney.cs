namespace TENTAC_HRM.Common
{
    internal class ConvertMoney
    {
        public string chendau(string so)
        {
            for (int i = so.Length - 3; i >= 0; i -= 3)
            {
                so = so.Insert(i, ",");
            }
            if (so.Substring(0, 1) == ",")
            {
                so = so.Remove(0, 1);
            }
            return so;
        }

        public string loaidau(string chuoi)
        {
            chuoi = chuoi.Replace(",", "");
            return chuoi;
        }

        public string BoKhoangTrang(string Chuoi)
        {
            Chuoi = Chuoi.Replace(" ", "");
            return Chuoi;
        }

        private string doc1so(string so)
        {
            return (new string[10] { "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín " })[int.Parse(so)];
        }

        private string doc3so(string so)
        {
            string luu;
            luu = null;
            if (so.Length == 1)
            {
                luu = this.doc1so(so);
            }
            if (so.Length == 2)
            {
                switch (so.Substring(0, 1))
                {
                    case "0":
                        luu = (!(so.Substring(so.Length - 1, 1) != "0")) ? "" : ("Lẻ " + this.doc1so(so.Substring(so.Length - 1, 1)));
                        break;
                    case "1":
                        luu = (!(so.Substring(so.Length - 1, 1) == "0")) ? ("mười " + this.doc1so(so.Substring(so.Length - 1, 1))) : "mười ";
                        break;
                    default:
                        luu = (!(so.Substring(so.Length - 1, 1) != "0")) ? (this.doc1so(so.Substring(0, 1)) + "mươi ") : (this.doc1so(so.Substring(0, 1)) + "mươi " + this.doc1so(so.Substring(so.Length - 1, 1)));
                        break;
                }
            }
            if (so.Length == 3)
            {
                luu = ((!(so == "000")) ? (this.doc1so(so.Substring(0, 1)) + "trăm " + this.doc3so(so.Substring(so.Length - 2, 2))) : "");
            }
            return luu;
        }

        public string docso(string so)
        {
            int j;
            j = 0;
            int d;
            d = 0;
            string kq;
            kq = null;
            string[] mang;
            mang = new string[4] { "", "ngàn ", "triệu ", "tỷ " };
            for (int i = so.Length - 3; i >= -2; i -= 3)
            {
                if (j == 4)
                {
                    j = 1;
                }
                if (i >= 0)
                {
                    if (this.doc3so(so.Substring(i, 3)) != "")
                    {
                        kq = this.doc3so(so.Substring(i, 3)) + mang[j] + kq;
                    }
                    else if (j == 3)
                    {
                        kq = "tỷ " + kq;
                    }
                }
                else
                {
                    kq = this.doc3so(so.Substring(0, so.Length - 3 * d)) + mang[j] + kq;
                }
                j++;
                d++;
            }
            return kq.Replace("mươi một", "mươi mốt");
        }
    }
}
