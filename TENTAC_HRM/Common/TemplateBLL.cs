using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TENTAC_HRM.Models;

namespace TENTAC_HRM.Common
{
    internal class TemplateBLL : Provider
    {
        public void ThemTemplate(Template_model _templateDTO)
        {
            List<SqlParameter> _sqlParameter = new List<SqlParameter>();
            _sqlParameter.Add(new SqlParameter("@MaChamCong", _templateDTO.MaChamCong));
            _sqlParameter.Add(new SqlParameter("@FingerID", _templateDTO.FingerID));
            _sqlParameter.Add(new SqlParameter("@Flag", _templateDTO.Flag));
            _sqlParameter.Add(new SqlParameter("@FingerTemplate", _templateDTO.FingerTemplate));
            _sqlParameter.Add(new SqlParameter("@FingerVersion", _templateDTO.FingerVersion));
            Procedure("TEMPLATE_add", _sqlParameter);
        }
        public DataTable SelectTemplateByMaChamCongUpToDevice(int ma_cham_cong)
        {
            string sql = "select * from  dbo.template where ma_cham_cong = '"+ ma_cham_cong + "'";
            return SQLHelper.ExecuteDt(sql);
        }
    }
}
