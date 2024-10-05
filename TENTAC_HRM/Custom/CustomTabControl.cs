﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TENTAC_HRM.Custom
{
    internal class CustomTabControl : TabControl
    {
        public CustomTabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 136);
            Alignment = TabAlignment.Top;
            SelectedIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            if (!DesignMode)
                SelectedTab.BackColor = Color.White;
            g.Clear(Color.White);
            if (Alignment == TabAlignment.Left || Alignment == TabAlignment.Right)
            { 
                g.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)),
                new Rectangle(0, 0, ItemSize.Height + 4, Height));
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)),
                new Rectangle(0, 0, Width, ItemSize.Height + 4));
            }


            //g.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(ItemSize.Height + 3, 0),
            //    new Point(ItemSize.Height + 3, 999));
            //g.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(0, Size.Height - 1),
                //new Point(Width + 3, Size.Height - 1));
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle();
                    if (Alignment == TabAlignment.Left || Alignment == TabAlignment.Right)
                    {
                        x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y -2),
                        new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    }
                    else
                    {
                        x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 2),
                        new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    }

                        ColorBlend myBlend = new ColorBlend();
                    myBlend.Colors = new Color[] { Color.FromArgb(232, 232, 240), Color.FromArgb(232, 232, 240), Color.FromArgb(232, 232, 240) };
                    myBlend.Positions = new float[] { 0f, 0.5f, 1f };
                    LinearGradientBrush lgBrush = new LinearGradientBrush(x2, Color.Black, Color.Black, 90f);
                    lgBrush.InterpolationColors = myBlend;
                    g.FillRectangle(lgBrush, x2);
                    g.DrawRectangle(new Pen(Color.FromArgb(170, 187, 204)), x2);

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    if(Alignment == TabAlignment.Left || Alignment == TabAlignment.Right)
                    {
                        Point[] p =
                        {
                            new Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 20),
                            new Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 14),
                            new Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 27)
                        };
                        g.FillPolygon(SystemBrushes.Control, p);
                        g.DrawPolygon(new Pen(Color.FromArgb(170, 187, 204)), p);
                    }
                    else
                    {
                        Point[] p = new Point[]
                        {
                            //new Point( GetTabRect(i).Location.X + 50, GetTabRect(i).Location.Y  + 45),
                            //new Point( GetTabRect(i).Location.X + 56, GetTabRect(i).Location.Y  + 52),
                            //new Point( GetTabRect(i).Location.X + 45, GetTabRect(i).Location.Y  + 52)

                            new Point( GetTabRect(i).Location.X + 0 + (ItemSize.Width/2), GetTabRect(i).Location.Y  - 5 + ItemSize.Height),
                            new Point( GetTabRect(i).Location.X + 6 + (ItemSize.Width/2), GetTabRect(i).Location.Y  + 2 + ItemSize.Height),
                            new Point( GetTabRect(i).Location.X - 5 + (ItemSize.Width/2), GetTabRect(i).Location.Y  + 2 + ItemSize.Height)
                        };
                        g.FillPolygon(SystemBrushes.Control, p);
                        g.DrawPolygon(new Pen(Color.FromArgb(170, 187, 204)), p);
                    }

                    if (ImageList != null)
                    {
                        try
                        {
                            g.DrawImage(ImageList.Images[TabPages[i].ImageIndex],
                                new Point(x2.Location.X + 8, x2.Location.Y + 6));
                            g.DrawString("  " + TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.Black, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                        catch (Exception)
                        {
                            g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                                Brushes.Black, x2, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                        }
                    }
                    else
                    {
                        g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                            Brushes.Black, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                    }

                    g.DrawLine(new Pen(Color.FromArgb(200, 200, 250)), new Point(x2.Location.X - 1, x2.Location.Y - 1),
                        new Point(x2.Location.X, x2.Location.Y));
                    g.DrawLine(new Pen(Color.FromArgb(200, 200, 250)), new Point(x2.Location.X - 1, x2.Bottom - 1),
                        new Point(x2.Location.X, x2.Bottom));
                }
                else
                {
                    Rectangle x2 = new Rectangle();
                    if (Alignment == TabAlignment.Left || Alignment == TabAlignment.Right)
                    {
                        x2 = new Rectangle(new Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y - 2),
                        new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    }
                    else
                    {
                        x2 = new Rectangle(new Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y + 2),
                        new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(246, 248, 252)), x2);
                    //g.DrawLine(new Pen(Color.FromArgb(170, 187, 204)), new Point(x2.Right, x2.Top),
                        //new Point(x2.Right, x2.Bottom));
                    if (ImageList != null)
                    {
                        try
                        {
                            g.DrawImage(ImageList.Images[TabPages[i].ImageIndex],
                                new Point(x2.Location.X + 8, x2.Location.Y + 6));
                            g.DrawString("  " + TabPages[i].Text, Font, Brushes.DimGray, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                        catch (Exception)
                        {
                            g.DrawString(TabPages[i].Text, Font, Brushes.DimGray, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        g.DrawString(TabPages[i].Text, Font, Brushes.DimGray, x2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                }
            }

            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }
}
