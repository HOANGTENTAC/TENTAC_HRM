using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TENTAC_HRM.Common
{
    public class MstMaTuDong
    {
        public string GenerateNextMaPhongBan()
        {
            string query = "SELECT COALESCE(MAX(MaPhongBan), 'PB00000') FROM MITACOSQL.dbo.PHONGBAN WHERE MaPhongBan LIKE 'PB%'";
            var result = SQLHelper.ExecuteScalar(query);

            string currentMaxCode = result.ToString();
            int currentMaxNumber = int.Parse(currentMaxCode.Substring(2));

            int nextNumber = currentMaxNumber + 1;
            string newCode = $"PB{nextNumber:D5}";

            return newCode;
        }
        public string GenerateNextMaChucVu()
        {
            string query = "SELECT COALESCE(MAX(MaChucVu), 'CV00000') FROM mst_ChucVu WHERE MaChucVu LIKE 'CV%'";
            var result = SQLHelper.ExecuteScalar(query);

            string currentMaxCode = result.ToString();
            int currentMaxNumber = int.Parse(currentMaxCode.Substring(2));

            int nextNumber = currentMaxNumber + 1;
            string newCode = $"CV{nextNumber:D5}";

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
