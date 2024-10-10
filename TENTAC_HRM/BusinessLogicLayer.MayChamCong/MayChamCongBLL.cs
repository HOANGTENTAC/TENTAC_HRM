using System.Collections;
using System.Data;
using TENTAC_HRM.DataAccessLayer.MayChamCong;
using TENTAC_HRM.DataTransferObject.MayChamCong;

namespace TENTAC_HRM.BusinessLogicLayer.MayChamCong
{
    internal class MayChamCongBLL
    {
        private MayChamCongDAL _mayChamCongDAL = new MayChamCongDAL();

        public void THEMMAYCHAMCONG(MayChamCongDTO _mayChamCongDTO)
        {
            _mayChamCongDAL.ThemMayChamCong(_mayChamCongDTO);
        }

        public DataTable GETDANHSACHMCC()
        {
            return _mayChamCongDAL.LOADMAYCHAMCONG();
        }

        public ArrayList GetAllMCC()
        {
            ArrayList arrMCC = new ArrayList();
            return _mayChamCongDAL.SelectAllMCC();
        }

        public void SUAMAYCHAMCONG(MayChamCongDTO _mayChamCongDTO)
        {
            _mayChamCongDAL.SuaMayChamCong(_mayChamCongDTO);
        }

        public void SUAACTIVEKEY(MayChamCongDTO _mayChamCongDTO)
        {
            _mayChamCongDAL.CapNhatActiveKey(_mayChamCongDTO);
        }

        public void DELETEMAYCHAMCONG(MayChamCongDTO _mayChamCongDTO)
        {
            _mayChamCongDAL.DELELEMAYCHAMCONG(_mayChamCongDTO);
        }

        public DataTable MayChamCongGetLoad(MayChamCongDTO _mayChamCongDTO)
        {
            return _mayChamCongDAL.MayChamCong_getLoad(_mayChamCongDTO);
        }

        public DataTable MayChamCongGetAllByTenMCC(MayChamCongDTO _mayChamCongDTO)
        {
            return _mayChamCongDAL.MayChamCong_getAllByTenMCC(_mayChamCongDTO);
        }
        public DataTable MayChamCongGetAllByMaMCC(MayChamCongDTO _mayChamCongDTO)
        {
            return _mayChamCongDAL.MayChamCong_getAllByMaMCC(_mayChamCongDTO);
        }
        public DataTable MayChamCongGetBySerial(MayChamCongDTO _mayChamCongDTO)
        {
            return _mayChamCongDAL.MayChamCong_getBySerial(_mayChamCongDTO);
        }
    }
}
