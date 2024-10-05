using System.Collections.Generic;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.DataTransferObject.QuanLyNhanVienDTO;

namespace TENTAC_HRM.BusinessLogicLayer.QuanLyNhanVienBLL
{
    internal class NhanVienUpdateBLL : Provider
    {
        public void NhanVienUpdateInsert(NhanVienUpdateDTO _nhanVienUpdateDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _nhanVienUpdateDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@MaThe", _nhanVienUpdateDTO.MaThe));
            Procedure("NhanVienUpdate_add", _sqlParameter);
        }

    }
}
