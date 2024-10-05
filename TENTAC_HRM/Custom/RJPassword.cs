using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TENTAC_HRM.Custom
{
    [DefaultEvent("_TextChanged")]
    public partial class RJPassword : UserControl
    {
        #region -> Fields
        //Fields
        private Color borderColor = Color.Gray;
        private Color borderFocusColor = Color.HotPink;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

        //Events
        public event EventHandler _TextChanged;

        #endregion

        //-> Constructor
        public RJPassword()
        {
            //Created by designer
            InitializeComponent();
            btn_show_pass.MouseDown += new MouseEventHandler(
                                    button_MouseDown);
            btn_show_pass.MouseUp += new MouseEventHandler(
                                                button_MouseUp);
            textBox1.FontChanged += new EventHandler(
                                                textbox_FontChanged);
            textBox1.TextChanged += new EventHandler(
                                                textbox_TextChanged);
        }

        #region -> Properties
        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                if (!isPlaceholder)
                    textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("RJ Code Advance")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("RJ Code Advance")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();//Redraw control
                }
            }
        }

        [Category("RJ Code Advance")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }



        #endregion

        #region -> Overridden methods
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled == false)
            {
                this.BackColor = Color.WhiteSmoke;
                this.BorderColor = Color.LightGray;
            }
            else
            {
                this.BackColor = Color.White;
                this.BorderColor = Color.Gray;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
            set_control_properties();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)//Rounded TextBox
            {
                //-Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle) //Line Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else //Normal Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else //Square/Normal TextBox
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle) //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }
        #endregion

        #region -> Private methods
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
        #endregion

        #region -> TextBox events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
        #endregion


        //#####################################################

        // ######################################################
        public delegate void PasswordEyePropertiesChangedHandler(
                       Object sender,
                       PasswordEyePropertiesChangedEventArgs e);

        public event PasswordEyePropertiesChangedHandler
                            PasswordEyePropertiesChanged;

        // ************************************************* Constants

        static Color BACKCOLOR = Color.White;
        static Color FORECOLOR = Color.Black;
        // used to specify whether or 
        // not TextBox Text is masked
        const char PASSWORD_HIDDEN = '*';
        const char PASSWORD_VISIBLE = '\0';
        // initial TextBox properties
        const int TEXTBOX_HEIGHT = 23;
        const int TEXTBOX_LOCATION_X = 1;
        const int TEXTBOX_LOCATION_Y = 1;
        static int TEXTBOX_MAXIMUM_WIDTH = 20;
        const int TEXTBOX_MAXLENGTH = 50;
        // initial Button properties
        const int BUTTON_HEIGHT = TEXTBOX_HEIGHT;
        const int BUTTON_WIDTH = BUTTON_HEIGHT;
        // initial panel properties
        const int PANEL_LOCATION_X = 1;
        const int PANEL_LOCATION_Y = 1;
        const string WIDEST_CHARACTER = "W";

        // ************************************************* variables

        Color backcolor = BACKCOLOR;
        Color forecolor = FORECOLOR;
        int textbox_maximum_width = TEXTBOX_MAXIMUM_WIDTH;

        // ************** trigger_passwordeye_properties_changed_event

        void trigger_passwordeye_properties_changed_event()
        {

            if (PasswordEyePropertiesChanged != null)
            {
                PasswordEyePropertiesChanged(
                    this,
                    new PasswordEyePropertiesChangedEventArgs(
                                                backcolor,
                                                btn_show_pass,
                                                this,
                                                forecolor,
                                                textbox_maximum_width,
                                                panel,
                                                textBox1));
            }
        }

        // **************************************** textbox_text_width

        int textbox_text_width()
        {
            string textbox_text = String.Empty;
            int width = 0;
            // build a test string so we 
            // can find the width needed 
            // for the textbox
            while (textbox_text.Length < textbox_maximum_width)
            {
                textbox_text += WIDEST_CHARACTER;
            }

            using (Graphics graphics = textBox1.CreateGraphics())
            {
                Size size = TextRenderer.MeasureText(
                graphics,
                                    textbox_text,
                                    textBox1.Font,
                                    new Size(1, 1),
                                    TextFormatFlags.NoPadding);
                // MeasureText does not appear 
                // to return a correct length; 
                // 2/3 seems to help
                width =
                    round((2.0 * (double)size.Width) / 3.0);
            }

            return (width);
        }

        // ***************************************************** round

        // http://en.wikipedia.org/wiki/Rounding

        int round(double double_value)
        {

            return ((int)(double_value + 0.5));
        }

        // ************************************ set_control_properties

        void set_control_properties()
        {
            int button_location_y = 0;
            this.Controls.Clear();
            panel.Controls.Clear();
            textBox1.BackColor = backcolor;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = forecolor;
            textBox1.Location = new Point(TEXTBOX_LOCATION_X,
                                           TEXTBOX_LOCATION_Y);
            textBox1.Size = new Size(textbox_text_width(),
                                      textBox1.Height);
            btn_show_pass.BackColor = backcolor;
            btn_show_pass.BackgroundImage = Properties.
                                     Resources.
                                     eye;
            btn_show_pass.BackgroundImageLayout = ImageLayout.Zoom;
            btn_show_pass.FlatStyle = FlatStyle.Flat;
            if (textBox1.Height > TEXTBOX_HEIGHT)
            {
                btn_show_pass.Size = new Size(BUTTON_HEIGHT,
                                         BUTTON_WIDTH);
                button_location_y =
                    round((double)(textBox1.Height -
                                         btn_show_pass.Height) / 2.0);
            }
            else
            {
                btn_show_pass.Size = new Size(textBox1.Height,
                                         textBox1.Height);
                button_location_y = textBox1.Location.Y;
            }
            btn_show_pass.Location = new Point(textBox1.Location.X +
                                              textBox1.Width + 1,
                                          button_location_y);
            panel.BackColor = backcolor;
            panel.Location = new Point(PANEL_LOCATION_X,
                                         PANEL_LOCATION_Y);
            panel.Size = new Size(
                                    (textBox1.Location.X + 1) +
                                        (textBox1.Width + 1) +
                                        (btn_show_pass.Width + 1),
                                    (textBox1.Height + 2));
            panel.Controls.Add(textBox1);
            panel.Controls.Add(btn_show_pass);
            this.Controls.Add(panel);
            this.Width = panel.Width + 2;
            this.Height = panel.Height + 2;
            trigger_passwordeye_properties_changed_event();
        }

        // ****************************************** button_MouseDown

        void button_MouseDown(object sender,
                                MouseEventArgs e)
        {

            base.OnMouseDown(e);

            textBox1.PasswordChar = PASSWORD_VISIBLE;
        }

        // ******************************************** button_MouseUp

        void button_MouseUp(object sender,
                              MouseEventArgs e)
        {

            base.OnMouseUp(e);

            textBox1.PasswordChar = PASSWORD_HIDDEN;
        }

        // *************************************** textbox_FontChanged

        void textbox_FontChanged(object sender,
                                   EventArgs e)
        {

            base.OnFontChanged(e);

            set_control_properties();
        }

        // *************************************** textbox_TextChanged

        void textbox_TextChanged(object sender,
                                   EventArgs e)
        {

            base.OnTextChanged(e);

            trigger_passwordeye_properties_changed_event();
        }

        // ********************************************* Maximum_Width

        [Category("Appearance"),
         Description("Gets/Sets the width of the password textbox"),
         DefaultValue(20),
         Bindable(true)]
        public int Maximum_Width
        {

            get
            {
                return (textbox_maximum_width);
            }
            set
            {
                if (value != textbox_maximum_width)
                {
                    textbox_maximum_width = value;
                    set_control_properties();
                }
            }
        }

        // ************************************************* MaxLength

        [Category("Appearance"),
         Description("Gets/Sets password textbox MaxLength"),
         DefaultValue(50),
         Bindable(true)]
        public int MaxLength
        {

            get
            {
                return (textBox1.MaxLength);
            }
            set
            {
                if (value != textBox1.MaxLength)
                {
                    textBox1.MaxLength = value;
                    trigger_passwordeye_properties_changed_event();
                }
            }
        }

        // http://stackoverflow.com/questions/2881409/
        //     text-property-in-a-usercontrol-in-c-sharp

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [Category("Appearance")]
        [Description("Gets/Sets password textbox Text")]
        [DefaultValue("")]
        public override string Text
        {

            get
            {
                return (textBox1.Text);
            }
            set
            {
                if (value != textBox1.Text)
                {
                    textBox1.Text = value;
                    set_control_properties();
                }
            }
        }
    }
    public class PasswordEyePropertiesChangedEventArgs
    {
        public Color backcolor;
        public Button button;
        public Control control;
        public Color forecolor;
        public int maximum_width;
        public Panel panel;
        public TextBox textbox;
        public PasswordEyePropertiesChangedEventArgs(
                                                Color backcolor,
                                                Button button,
                                                Control control,
                                                Color forecolor,
                                                int maximum_width,
                                                Panel panel,
                                                TextBox textbox)
        {

            this.backcolor = backcolor;
            this.button = button;
            this.control = control;
            this.forecolor = forecolor;
            this.maximum_width = maximum_width;
            this.panel = panel;
            this.textbox = textbox;
        }

    }
}
