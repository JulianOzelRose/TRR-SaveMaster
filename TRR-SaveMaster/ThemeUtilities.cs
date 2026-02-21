using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TRR_SaveMaster
{
    public static class ThemeUtilities
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);

        public const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        public const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public static Color Background = Color.FromArgb(18, 18, 18);
        public static Color Surface = Color.FromArgb(28, 28, 28);
        public static Color Hover = Color.FromArgb(55, 55, 55);
        public static Color Text = Color.FromArgb(230, 230, 230);
        public static Color DisabledText = Color.FromArgb(140, 140, 140);
        public static Color Border = Color.FromArgb(80, 80, 80);
        public static Color MenuBorderColor = Color.FromArgb(60, 60, 60);
        public static Color SeparatorColor = Color.FromArgb(70, 70, 70);

        public static bool DARK_MODE_ENABLED = false;

        private class DarkToolStripColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground => Background;
            public override Color ImageMarginGradientBegin => Background;
            public override Color ImageMarginGradientMiddle => Background;
            public override Color ImageMarginGradientEnd => Background;
            public override Color MenuBorder => MenuBorderColor;
            public override Color MenuItemSelected => Hover;
            public override Color MenuItemSelectedGradientBegin => Hover;
            public override Color MenuItemSelectedGradientEnd => Hover;
            public override Color MenuItemPressedGradientBegin => Surface;
            public override Color MenuItemPressedGradientEnd => Surface;
            public override Color SeparatorDark => SeparatorColor;
            public override Color SeparatorLight => SeparatorColor;
            public override Color ToolStripBorder => Background;
        }

        private class DarkToolStripRenderer : ToolStripProfessionalRenderer
        {
            private readonly Color enabledText = Color.White;
            private readonly Color disabledText = DisabledText;

            public DarkToolStripRenderer()
                : base(new DarkToolStripColorTable())
            {
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = e.Item.Enabled ? enabledText : disabledText;
                base.OnRenderItemText(e);
            }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = e.Item.Enabled ? enabledText : disabledText;
                base.OnRenderArrow(e);
            }
        }

        public static void ApplyDarkMode(Control parent)
        {
            parent.BackColor = Background;

            foreach (Control control in parent.Controls)
            {
                control.BackColor = Background;
                control.ForeColor = Text;

                if (control is ComboBox cb)
                {
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Paint -= DarkDisabledButton_Paint;
                    btn.Paint += DarkDisabledButton_Paint;
                    btn.FlatAppearance.BorderColor = Border;
                    btn.FlatAppearance.MouseOverBackColor = Surface;
                    btn.FlatAppearance.MouseDownBackColor = Surface;
                }
                else if (control is CheckBox checkbox)
                {
                    checkbox.FlatStyle = FlatStyle.Flat;
                    checkbox.Paint -= DarkDisabledCheckBox_Paint;
                    checkbox.Paint += DarkDisabledCheckBox_Paint;
                }
                else if (control is MenuStrip menu)
                {
                    menu.Renderer = new DarkToolStripRenderer();
                    menu.BackColor = Background;
                    menu.ForeColor = Text;
                }
                else if (control is ToolStrip toolStrip)
                {
                    toolStrip.Renderer = new DarkToolStripRenderer();
                    toolStrip.BackColor = Background;
                    toolStrip.ForeColor = Text;
                }
                else if (control is Label label)
                {
                    label.Paint -= DarkDisabledLabel_Paint;
                    label.Paint += DarkDisabledLabel_Paint;
                }

                if (control.HasChildren)
                {
                    ApplyDarkMode(control);
                }
            }
        }

        public static void ApplyLightMode(Control parent)
        {
            parent.BackColor = SystemColors.Window;

            foreach (Control control in parent.Controls)
            {
                if (control is ToolStrip ts)
                {
                    ts.Renderer = null;
                    ts.BackColor = SystemColors.Control;
                    ts.ForeColor = SystemColors.ControlText;
                }
                else if (control is ComboBox cb)
                {
                    cb.FlatStyle = FlatStyle.Standard;
                    cb.BackColor = SystemColors.Window;
                }
                else if (control is Button btn)
                {
                    btn.Paint -= DarkDisabledButton_Paint;
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.UseVisualStyleBackColor = true;
                    btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
                    btn.FlatAppearance.MouseOverBackColor = Color.Empty;
                    btn.FlatAppearance.MouseDownBackColor = Color.Empty;
                }
                else if (control is TrackBar trb)
                {
                    trb.BackColor = Color.White;
                }
                else if (control is CheckBox chk)
                {
                    chk.FlatStyle = FlatStyle.Standard;
                    chk.Paint -= DarkDisabledCheckBox_Paint;
                    chk.BackColor = Color.White;
                }
                else if (control is Label lbl)
                {
                    lbl.Paint -= DarkDisabledLabel_Paint;
                    lbl.BackColor = Color.White;
                }
                else if (control is MenuStrip menu)
                {
                    menu.Renderer = null;
                }

                if (control.HasChildren)
                {
                    ApplyLightMode(control);
                }

                control.ForeColor = SystemColors.ControlText;
            }
        }

        public static void ApplyDarkTitleBar(Form form)
        {
            if (form == null || form.IsDisposed)
            {
                return;
            }

            int useDark = 1;

            if (DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int)) != 0)
            {
                DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref useDark, sizeof(int));
            }
        }

        public static void ApplyLightTitleBar(Form form)
        {
            if (form == null || form.IsDisposed)
            {
                return;
            }

            int useDark = 0;

            DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));

            DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref useDark, sizeof(int));
        }

        private static void DarkDisabledButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;

            if (!btn.Enabled)
            {
                e.Graphics.Clear(Surface);

                using (Pen border = new Pen(DisabledText))
                {
                    e.Graphics.DrawRectangle(border, 0, 0, btn.Width - 1, btn.Height - 1);
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    btn.Text,
                    btn.Font,
                    btn.ClientRectangle,
                    DisabledText,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }

        private static void DarkDisabledCheckBox_Paint(object sender, PaintEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.Enabled)
            {
                return;
            }

            e.Graphics.Clear(Background);

            // Scale relative to font (DPI-safe)
            int size = (int)(cb.Font.Height * 0.75f);
            int leftPadding = 0;
            int textSpacing = (int)(cb.Font.Height * 0.4f);
            int thickness = Math.Max(1, size / 6);

            Rectangle boxRect = new Rectangle(
                leftPadding,
                (cb.Height - size) / 2,
                size,
                size
            );

            using (Pen border = new Pen(DisabledText))
                e.Graphics.DrawRectangle(border, boxRect);

            if (cb.Checked)
            {
                int pad = size / 4;

                using (Pen checkPen = new Pen(DisabledText, thickness))
                {
                    e.Graphics.DrawLine(checkPen,
                        boxRect.Left + pad,
                        boxRect.Top + size / 2,
                        boxRect.Left + size / 2,
                        boxRect.Bottom - pad);

                    e.Graphics.DrawLine(checkPen,
                        boxRect.Left + size / 2,
                        boxRect.Bottom - pad,
                        boxRect.Right - pad,
                        boxRect.Top + pad);
                }
            }

            TextRenderer.DrawText(
                e.Graphics,
                cb.Text,
                cb.Font,
                new Point(boxRect.Right + textSpacing,
                          (cb.Height - cb.Font.Height) / 2),
                DisabledText,
                TextFormatFlags.NoPadding
            );
        }

        private static void DarkDisabledLabel_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            if (lbl.Enabled)
            {
                return;
            }

            // Fully override disabled rendering
            e.Graphics.Clear(lbl.Parent?.BackColor ?? Background);

            TextRenderer.DrawText(
                e.Graphics,
                lbl.Text,
                lbl.Font,
                lbl.ClientRectangle,
                DisabledText,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
        }
    }
}