using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TENTAC_HRM.Custom
{
    internal class CustomMultiSelect : UserControl
    {
        private CustomButton dropdownButton;
        private Panel itemPanel;
        private List<CheckBox> checkboxes;
        private TextBox filterTextBox;
        private CheckBox selectAllCheckbox;
        private bool isFilterActive = false;

        private string selectedButtonText = "Select item";
        public string MSPlaceholder
        {
            get { return selectedButtonText; }
            set
            {
                selectedButtonText = value;
                dropdownButton.Text = value;
            }
        }
        private int rightPadding = 15;
        public int MSIconRightPadding
        {
            get { return rightPadding; }
            set
            {
                rightPadding = value;
                dropdownButton.RightPadding = value;
            }
        }
        private Color textboxFormColor = Color.Black;
        public Color MSTextboxFormColor
        {
            get { return textboxFormColor; }
            set
            {
                textboxFormColor = value;
                filterTextBox.ForeColor = value;
            }
        }
        private Image multiSelectIon;
        public Image MSIcon
        {
            get { return multiSelectIon; }
            set
            {
                multiSelectIon = value;
                dropdownButton.RightIcon = value;
            }
        }
        private int multiSelectIonSize = 20;
        public int MSIconSize
        {
            get { return multiSelectIonSize; }
            set
            {
                multiSelectIonSize = value;
                dropdownButton.IconSize = value;
            }
        }
        private string selectedPlaceholder = "items";
        public string MSSelectedPlaceholder
        {
            get { return selectedPlaceholder; }
            set
            {
                selectedPlaceholder = value;
            }
        }
        private Color multiSelectForeColor = Color.Black;
        public Color MSForeColor
        {
            get { return multiSelectForeColor; }
            set
            {
                multiSelectForeColor = value;
                dropdownButton.ForeColor = value;
            }
        }
        private int multiSelectHeight = 200;
        public int MSHeight
        {
            get { return multiSelectHeight; }
            set
            {
                multiSelectHeight = value;
            }
        }

        private string valueMember = "";
        public string ValueMember
        {
            get { return valueMember; }
            set
            {
                valueMember = value;
            }
        }
        private string displayMember = "";
        public string DisplayMember
        {
            get { return displayMember; }
            set
            {
                displayMember = value;
            }
        }
        public CustomMultiSelect()
        {
            this.Cursor = Cursors.Hand;
            this.BackColor = Color.White;
            this.Padding = new Padding(3);

            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw
                | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            dropdownButton = new CustomButton
            {
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Top,
                ForeColor = multiSelectForeColor,
                IconSize = multiSelectIonSize,
                RightPadding = rightPadding,
                Height = 20,
                Text = selectedButtonText,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            dropdownButton.FlatAppearance.BorderSize = 0;

            dropdownButton.Click += (sender, e) =>
            {
                itemPanel.Visible = !itemPanel.Visible;
                itemPanel.Size = this.Size = itemPanel.Visible ? new
                System.Drawing.Size(this.Width, multiSelectHeight) : new
                System.Drawing.Size(this.Width, dropdownButton.Height);
                filterTextBox.Focus();
            };

            filterTextBox = new TextBox
            {
                Dock = DockStyle.Top,
                Text = "",
                ForeColor = textboxFormColor,
                Padding = new Padding(3)
            };

            filterTextBox.TextChanged += (sender, e) =>
            {
                UpdateitemPanel(filterTextBox.Text);
            };

            itemPanel = new Panel
            {
                AutoScroll = true,
                Visible = false,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(3)
                //Anchor = AnchorStyles.Left | AnchorStyles.Right,
            };
            //itemPanel.VerticalScroll.Enabled = true;
            //itemPanel.VerticalScroll.Visible = true;

            //VScrollBar vScroll = new VScrollBar
            //{
            //    Value = itemPanel.VerticalScroll.Value,
            //    Minimum = itemPanel.VerticalScroll.Minimum,
            //    Maximum = itemPanel.VerticalScroll.Maximum,
            //    Dock = DockStyle.Right,
            //};
            //vScroll.Scroll += (sender, e) =>
            //{
            //    itemPanel.VerticalScroll.Value = vScroll.Value;
            //};
            checkboxes = new List<CheckBox>();

            this.Controls.Add(filterTextBox);
            //this.Controls.Add(vScroll);
            //vScroll.BringToFront();
            this.Controls.Add(itemPanel);
            itemPanel.BringToFront();
            this.Controls.Add(dropdownButton);
            this.Size = new System.Drawing.Size(this.Width,
                dropdownButton.Height);
        }
        private void AddSelectAllCheckBox()
        {
            selectAllCheckbox = new CheckBox
            {
                Text = "Select All",
                Dock = DockStyle.Top,
                Width = this.Width,
                ForeColor = multiSelectForeColor
            };

            selectAllCheckbox.CheckedChanged += (sender, e) =>
            {
                bool checkAll = selectAllCheckbox.Checked;

                foreach (var checkbox in checkboxes)
                {
                    if (!isFilterActive || checkbox.Visible)
                        checkbox.Checked = checkAll;
                }
            };
            itemPanel.Controls.Add(selectAllCheckbox);
        }
        private void UpdateButtonText()
        {
            int selectedCount = checkboxes.Count(cb => cb.Checked);
            if (selectedCount == 0)
            {
                dropdownButton.Text = selectedButtonText;
            }
            else
            {
                string selectedText = string.Join(", ", checkboxes.Where(
                    cb => cb.Checked).Select(cb => cb.Text));
                if (selectedCount == 1)
                {
                    dropdownButton.Text = selectedText;
                }
                else
                {
                    dropdownButton.Text = selectedCount + " " +
                        selectedPlaceholder + " selected";
                }
            }
        }
        private void UpdateitemPanel(string filterText)
        {
            isFilterActive = !string.IsNullOrWhiteSpace(filterText);
            foreach (var checkbox in checkboxes)
            {
                bool isVisible = string.IsNullOrWhiteSpace(filterText) ||
                    checkbox.Text.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0;
                checkbox.Visible = isVisible;
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!this.Visible)
            {
                HideItemsPanel();
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            HideItemsPanel();
        }
        public void HideItemsPanel()
        {
            itemPanel.Visible = false;
            this.Size = new Size(this.Width, dropdownButton.Height);
        }
        public object DataSource
        {
            set
            {
                itemPanel.Controls.Clear();
                checkboxes.Clear();
                if (value != null)
                {
                    AddSelectAllCheckBox();
                    if (value.GetType().IsGenericType && value.GetType().
                        GetGenericTypeDefinition() == typeof(List<>))
                    {
                        Type listItemType = value.GetType().
                            GetGenericArguments()[0];
                        if (listItemType.GetProperty(valueMember) != null
                            && listItemType.GetProperty(displayMember) != null)
                        {
                            foreach (var item in (IEnumerable)value)
                            {
                                string id = (string)item.GetType().GetProperty
                                    (valueMember).GetValue(item, null);
                                string text = (string)item.GetType().GetProperty
                                    (displayMember).GetValue(item, null);
                                AddCheckBox(id, text);
                            }
                        }
                    }
                    else if (value is DataTable dataTable)
                    {
                        if (dataTable.Columns.Contains(valueMember)
                            && dataTable.Columns.Contains(displayMember))
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string id = row[valueMember].ToString();
                                string val = row[displayMember].ToString();
                                AddCheckBox(id, val);
                            }
                        }
                    }
                }
            }
        }

        public string SelectIds
        {
            get
            {
                List<string> selectedIds = checkboxes.Where(
                    cb => cb.Checked).Select(cb => (string)cb.Tag).ToList();
                return string.Join(",", selectedIds);
            }
        }
        public string SelectedValues
        {
            get
            {
                List<string> selectedValues = checkboxes.Where(
                    cb => cb.Checked).Select(cb => cb.Text).ToList();
                return string.Join(", ", selectedValues);
            }
        }
        private void AddCheckBox(string id, string value)
        {
            var checkbox = new CheckBox
            {
                Text = value,
                Dock = DockStyle.Top,
                Tag = id,
                Width = this.Width,
                ForeColor = multiSelectForeColor
            };

            checkbox.MouseEnter += (sender, e) =>
            {
                ((CheckBox)sender).BackColor = Color.FromArgb(128, Color.LightGray);
            };

            checkbox.MouseLeave += (sender, e) =>
            {
                ((CheckBox)sender).BackColor = this.BackColor;
            };

            checkbox.CheckedChanged += (sender, e) =>
            {
                string selectId = (string)((CheckBox)sender).Tag;
                UpdateButtonText();
            };
            checkboxes.Add(checkbox);
            itemPanel.Controls.Add(checkbox);
            checkbox.BringToFront();
        }

        private int radius = 5;
        public int MSRadius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.RecreateRegion();
            }
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,
            int nTopRect, int nRightRext, int nButtomRect, int nWidthEllipse,
            int nHeightEllipse);
        private void RecreateRegion()
        {
            var bounds = ClientRectangle;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(
                bounds.Left, bounds.Top, bounds.Right, bounds.Bottom,
                MSRadius, radius));
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }
    }
    public class CustomButton : Button
    {
        private Image rightIcon;
        private int iconSize;
        private int rightPadding;
        public CustomButton()
        {
            FlatAppearance.BorderColor = Color.Red;
            FlatAppearance.BorderSize = 5;
        }
        public int RightPadding
        {
            get { return rightPadding; }
            set { rightPadding = value; Refresh(); }
        }
        public Image RightIcon
        {
            get { return rightIcon; }
            set { rightIcon = value; Refresh(); }
        }
        public int IconSize
        {
            get { return iconSize; }
            set { iconSize = value; Refresh(); }
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (rightIcon != null)
            {
                int iconX = this.Width - IconSize - RightPadding;
                int iconY = (this.Height - IconSize) / 2;
                pevent.Graphics.DrawImage(rightIcon, new Rectangle(iconX, iconY, IconSize, iconSize));
            }
        }
    }
}
