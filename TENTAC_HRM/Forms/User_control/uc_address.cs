using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TENTAC_HRM.Forms.User_control
{
    public partial class uc_address : UserControl
    {
        public static uc_address _instance;
        private DataTable dtParent;
        private DataTable dtChild;
        public uc_address()
        {
            InitializeComponent();

        }
        public static uc_address Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_address();
                return _instance;
            }
        }
        private void uc_address_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            string sql = string.Empty;
            sql = $@" select QuocGia.TenDiaChi as QuocGia, TinhThanh.TenDiaChi as TinhThanh, QuanHuyen.TenDiaChi as QuanHuyen,
                 PhuongXa.TenDiaChi as PhuongXa from mst_DonViHanhChinh as QuocGia
                 Inner join mst_DonViHanhChinh as TinhThanh on QuocGia.Id = TinhThanh.ParentId and TinhThanh.DelFlg = 0
                 Inner join mst_DonViHanhChinh as QuanHuyen on TinhThanh.Id = QuanHuyen.ParentId and QuanHuyen.DelFlg = 0
                 Inner join mst_DonViHanhChinh as PhuongXa on QuanHuyen.Id = PhuongXa.ParentId and PhuongXa.DelFlg = 0
                 where QuocGia.CapBac = 0 and QuocGia.DelFlg = 0";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            if (dt.Rows.Count > 0)
            {
                dgv_address.DataSource = dt;
            }

            MergeCellsInDataGridView(dgv_address, 0);
            MergeCellsInDataGridView(dgv_address, 1);
            MergeCellsInDataGridView(dgv_address, 2);
        }
        private void MergeCellsInDataGridView(DataGridView dgv, int mergeColumnIndex)
        {
            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == mergeColumnIndex)
                {
                    var currentCell = dgv[mergeColumnIndex, e.RowIndex];
                    var previousCell = e.RowIndex > 0 ? dgv[mergeColumnIndex, e.RowIndex - 1] : null;

                    // Kiểm tra nếu giá trị ô hiện tại trùng với ô phía trên
                    if (previousCell != null && currentCell.Value?.ToString() == previousCell.Value?.ToString())
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        int mergeStartRow = e.RowIndex;
                        int mergeEndRow = e.RowIndex;

                        for (int i = e.RowIndex + 1; i < dgv.Rows.Count; i++)
                        {
                            var nextCell = dgv[mergeColumnIndex, i];
                            if (nextCell.Value?.ToString() == currentCell.Value?.ToString())
                            {
                                mergeEndRow = i;
                            }
                            else break;
                        }

                        Rectangle mergeRect = e.CellBounds;
                        for (int i = mergeStartRow + 1; i <= mergeEndRow; i++)
                        {
                            mergeRect.Height += dgv[mergeColumnIndex, i].Size.Height;
                        }

                        e.Graphics.FillRectangle(Brushes.White, mergeRect);

                        using (var gridLinePen = new Pen(dgv.GridColor))
                        {
                            e.Graphics.DrawRectangle(gridLinePen, mergeRect.X, mergeRect.Y, mergeRect.Width - 1, mergeRect.Height - 1);
                        }

                        TextRenderer.DrawText(
                            e.Graphics,
                            currentCell.Value?.ToString(),
                            e.CellStyle.Font,
                            new Rectangle(mergeRect.X + 3, mergeRect.Y + 3, mergeRect.Width - 6, dgv[mergeColumnIndex, e.RowIndex].Size.Height), // Điều chỉnh khoảng đệm
                            e.CellStyle.ForeColor,
                            TextFormatFlags.Left | TextFormatFlags.Top
                        );

                        e.Handled = true;
                    }
                }
            };
        }
    }
}
