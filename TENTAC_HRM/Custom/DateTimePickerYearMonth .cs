using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TENTAC_HRM.Custom
{
    [DesignerCategory("Code")]
    class DateTimePickerYearMonth : DateTimePicker
    {
        private string m_CustomFormat = "MM/yyyy";
        private DateTimePickerFormat m_Format = DateTimePickerFormat.Custom;
        private SelectionViewMode m_SelectionMode = SelectionViewMode.Month;
        private bool m_ShowToday = false;
        private IntPtr hWndCal = IntPtr.Zero;
        public DateTimePickerYearMonth()
        {
            base.CustomFormat = m_CustomFormat;
            base.Format = m_Format;
        }

        [DefaultValue(SelectionViewMode.Month)]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance"), Description("Set the current selection mode to either Month or Year")]
        public SelectionViewMode SelectionMode
        {
            get => m_SelectionMode;
            set
            {
                if (value != m_SelectionMode)
                {
                    m_SelectionMode = value;
                    m_CustomFormat = m_SelectionMode == SelectionViewMode.Year ? "yyyy" : "MMMM";
                    base.CustomFormat = m_CustomFormat;
                }
            }
        }

        [DefaultValue(false)]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Appearance"), Description("Shows or hides \"Today\" date at the bottom of the Calendar Control")]
        public bool ShowToday
        {
            get => m_ShowToday;
            set
            {
                if (value != m_ShowToday)
                {
                    m_ShowToday = value;
                    ShowMonCalToday(m_ShowToday);
                }
            }
        }

        [DefaultValue("yyyy")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string CustomFormat
        {
            get => base.CustomFormat;
            set => base.CustomFormat = m_CustomFormat;
        }

        [DefaultValue(DateTimePickerFormat.Custom)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new DateTimePickerFormat Format
        {
            get => base.Format;
            set => base.Format = m_Format;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ShowMonCalToday(m_ShowToday);
        }

        protected override void OnDropDown(EventArgs e)
        {
            hWndCal = SendMessage(this.Handle, DTM_GETMONTHCAL, 0, 0);
            if (hWndCal != IntPtr.Zero)
            {
                SendMessage(hWndCal, MCM_SETCURRENTVIEW, 0, (int)(MonCalStyles)m_SelectionMode);
            }
            base.OnDropDown(e);
        }

        private void ShowMonCalToday(bool show)
        {
            int styles = SendMessage(this.Handle, DTM_GETMCSTYLE, 0, 0).ToInt32();
            styles = show ? styles & ~(int)MonCalStyles.MCS_NOTODAY : styles | (int)MonCalStyles.MCS_NOTODAY;
            SendMessage(this.Handle, DTM_SETMCSTYLE, 0, styles);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NOTIFY:
                    var nmh = (NMHDR)m.GetLParam(typeof(NMHDR));
                    switch (nmh.code)
                    {
                        case MCN_VIEWCHANGE:
                            var nmView = (NMVIEWCHANGE)m.GetLParam(typeof(NMVIEWCHANGE));
                            if (nmView.dwNewView < (MonCalView)m_SelectionMode)
                            {
                                SendMessage(this.Handle, DTM_CLOSEMONTHCAL, 0, 0);
                            }
                            break;
                        default:
                            // NOP: Add more notifications handlers...
                            break;
                    }
                    break;
                default:
                    // NOP: Add more message handlers...
                    break;
            }
            base.WndProc(ref m);
        }

        public enum SelectionViewMode : int
        {
            Month = MonCalView.MCMV_YEAR,
            Year = MonCalView.MCMV_DECADE,
        }

        // Move to a NativeMethods class, eventually
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        internal const int WM_NOTIFY = 0x004E;
        internal const int MCN_VIEWCHANGE = -750;

        internal const int DTM_FIRST = 0x1000;
        internal const int DTM_GETMONTHCAL = DTM_FIRST + 8;
        internal const int DTM_SETMCSTYLE = DTM_FIRST + 11;
        internal const int DTM_GETMCSTYLE = DTM_FIRST + 12;
        internal const int DTM_CLOSEMONTHCAL = DTM_FIRST + 13;

        internal const int MCM_FIRST = 0x1000;
        internal const int MCM_GETCURRENTVIEW = MCM_FIRST + 22;
        internal const int MCM_SETCURRENTVIEW = MCM_FIRST + 32;

        [StructLayout(LayoutKind.Sequential)]
        internal struct NMHDR
        {
            public IntPtr hwndFrom;
            public UIntPtr idFrom;
            public int code;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct NMVIEWCHANGE
        {
            public NMHDR nmhdr;
            public MonCalView dwOldView;
            public MonCalView dwNewView;
        }

        internal enum MonCalView : int
        {
            MCMV_MONTH = 0,
            MCMV_YEAR = 1,
            MCMV_DECADE = 2,
            MCMV_CENTURY = 3
        }

        internal enum MonCalStyles : int
        {
            MCS_DAYSTATE = 0x0001,
            MCS_MULTISELECT = 0x0002,
            MCS_WEEKNUMBERS = 0x0004,
            MCS_NOTODAYCIRCLE = 0x0008,
            MCS_NOTODAY = 0x0010,
            MCS_NOTRAILINGDATES = 0x0040,
            MCS_SHORTDAYSOFWEEK = 0x0080,
            MCS_NOSELCHANGEONNAV = 0x0100
        }
    }
}
