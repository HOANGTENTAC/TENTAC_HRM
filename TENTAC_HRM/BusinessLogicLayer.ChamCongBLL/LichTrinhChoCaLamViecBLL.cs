using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TENTAC_HRM.Common;

namespace TENTAC_HRM.BusinessLogicLayer.ChamCongBLL
{
    internal class LichTrinhChoCaLamViecBLL : Provider
    {
        public DataTable GET_DANHSACH_LICHTRINHCHOCALAMVIEC()
        {
            return SQLHelper.ExecuteDt("select * from  dbo.lichtrinh_chocalamviec");
        }
    }
}
