using System.Drawing;
using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace TENTAC_HRM.Custom
{
    public class CustomLabel : Label
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
    }
}
