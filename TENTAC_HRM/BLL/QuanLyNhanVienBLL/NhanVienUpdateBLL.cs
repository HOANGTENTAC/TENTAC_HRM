using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.QuanLyNhanVienModel;

namespace TENTAC_HRM.BLL.QuanLyNhanVienBLL
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
        public DataTable NhanVienUpdateGetByMaChamCong(NhanVienUpdateDTO _nhanVienUpdateDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _nhanVienUpdateDTO.MaChamCong));
            return executeNonQuerya("NhanVienUpdate_getByMaChamCong", _sqlParameter);
        }
        public void NhanVienUpdateDeleteAll(NhanVienUpdateDTO _nhanVienUpdateDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            Procedure("NhanVienUpdate_deleteAll", _sqlParameter);
        }
    }
}
