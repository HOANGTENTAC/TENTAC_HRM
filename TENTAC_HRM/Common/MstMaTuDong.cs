using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TENTAC_HRM.Common
{
    public class MstMaTuDong
    {
        public string GenerateNextMaDanToc()
        {
            string query = "SELECT COALESCE(MAX(MaDanToc), 'DT000') FROM mst_DanToc WHERE MaDanToc LIKE 'DT%'";
            var result = SQLHelper.ExecuteScalar(query);

            string currentMaxCode = result.ToString();
            int currentMaxNumber = int.Parse(currentMaxCode.Substring(2));

            int nextNumber = currentMaxNumber + 1;
            string newCode = $"DT{nextNumber:D3}";

            return newCode;
        }
        public string GenerateNextMaTonGiao()
        {
            string query = "SELECT COALESCE(MAX(MaTonGiao), 'TG000') FROM mst_TonGiao WHERE MaTonGiao LIKE 'TG%'";
            var result = SQLHelper.ExecuteScalar(query);

            string currentMaxCode = result.ToString();
            int currentMaxNumber = int.Parse(currentMaxCode.Substring(2));

            int nextNumber = currentMaxNumber + 1;
            string newCode = $"TG{nextNumber:D3}";

            return newCode;
        }
        public string GenerateNextMaNgoaiNgu()
        {
            string query = "SELECT COALESCE(MAX(MaNgoaiNgu), 'NN000') FROM mst_NgoaiNgu WHERE MaNgoaiNgu LIKE 'NN%'";
            var result = SQLHelper.ExecuteScalar(query);

            string currentMaxCode = result.ToString();
            int currentMaxNumber = int.Parse(currentMaxCode.Substring(2));

            int nextNumber = currentMaxNumber + 1;
            string newCode = $"NN{nextNumber:D3}";

            return newCode;
        }

        public string GenerateNextCode(string tableName, string codePrefix, string codeColumn)
        {
            string query = $"SELECT COALESCE(MAX({codeColumn}), '{codePrefix}000') FROM {tableName} WHERE {codeColumn} LIKE '{codePrefix}%'";
            var result = SQLHelper.ExecuteScalar(query);

            string currentMaxCode = result.ToString();
            int currentMaxNumber = int.Parse(currentMaxCode.Substring(codePrefix.Length));

            int nextNumber = currentMaxNumber + 1;
            string newCode = $"{codePrefix}{nextNumber:D3}";

            return newCode;
        }
    }
}
