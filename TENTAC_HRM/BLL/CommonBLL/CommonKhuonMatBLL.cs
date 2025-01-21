using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Common;
using TENTAC_HRM.Models.CommonModel;

namespace TENTAC_HRM.BLL.CommonBLL
{
    internal class CommonKhuonMatBLL : Provider
    {
        public void InsertFaceVirtual(CommonKhuonMatModel _commonkhuonmatDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _commonkhuonmatDTO));
            _sqlParameter.Add(new SqlParameter("@FaceIDVirtual", _commonkhuonmatDTO.FaceIDVirtual));
            _sqlParameter.Add(new SqlParameter("@@FaceTemplateVirtual", _commonkhuonmatDTO.FaceTemplateVirtual));
            Procedure("FaceVirtual_add", _sqlParameter);
        }
        public DataTable SelectTemplateVirtualByMaChamCong(string MaChamCong)
        {
            return SQLHelper.ExecuteDt($"select * from MITACOSQL.dbo.[FaceVirtual] where MaChamCong = '{MaChamCong}'");
        }
    }
}
