using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TENTAC_HRM.Common;
using TENTAC_HRM.Model;

namespace TENTAC_HRM.BusinessLogicLayer.CommonBLL
{
    internal class CommonKhuonMatBLL : Provider
    {
        public void InsertFaceVirtual(CommonKhuonMat_model _commonkhuonmatDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@machamcong", _commonkhuonmatDTO));
            _sqlParameter.Add(new SqlParameter("@faceidvirtual", _commonkhuonmatDTO.FaceIDVirtual));
            _sqlParameter.Add(new SqlParameter("@facetemplatevirtual", _commonkhuonmatDTO.FaceTemplateVirtual));
            Procedure("facevirtual", _sqlParameter);
        }
        public DataTable SelectTemplateVirtualByMaChamCong(string MaChamCong)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@machamcong", MaChamCong));
            return executeNonQuerya("NhanVienVirtual_selectFaceByMaChamCong", _sqlParameter);
        }
    }
}
