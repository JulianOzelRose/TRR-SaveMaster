using System;
using System.Drawing;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class ThemedDialog : Form
    {
        public ThemedDialog(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            InitializeComponent();

            lblMessage.Text = message;
            this.Text = title;

            _icon = icon;
            _buttons = buttons;
        }

        private void ThemedDialog_Load(object sender, EventArgs e)
        {
            if (ThemeUtilities.DARK_MODE_ENABLED)
            {
                ThemeUtilities.ApplyDarkMode(this);
                ThemeUtilities.ApplyDarkTitleBar(this);
            }

            picIcon.Image = GetIcon(_icon);
            SetupButtons();
        }

        private MessageBoxIcon _icon;
        private MessageBoxButtons _buttons;

        private Image GetIcon(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Warning:
                    return SystemIcons.Warning.ToBitmap();

                case MessageBoxIcon.Error:
                    return SystemIcons.Error.ToBitmap();

                case MessageBoxIcon.Information:
                    return SystemIcons.Information.ToBitmap();

                case MessageBoxIcon.Question:
                    return SystemIcons.Question.ToBitmap();

                default:
                    return null;
            }
        }

        private void SetupButtons()
        {
            btnPrimary.Visible = false;
            btnSecondary.Visible = false;

            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                    btnPrimary.Text = "&OK";
                    btnPrimary.DialogResult = DialogResult.OK;
                    btnPrimary.Visible = true;

                    this.AcceptButton = btnPrimary;
                    this.CancelButton = btnPrimary;

                    const int RightPadding = 15;
                    btnPrimary.Left = this.ClientSize.Width - btnPrimary.Width - RightPadding;
                    break;

                case MessageBoxButtons.YesNo:
                    btnPrimary.Text = "&Yes";
                    btnPrimary.DialogResult = DialogResult.Yes;

                    btnSecondary.Text = "&No";
                    btnSecondary.DialogResult = DialogResult.No;

                    btnPrimary.Visible = true;
                    btnSecondary.Visible = true;

                    this.AcceptButton = btnPrimary;
                    this.CancelButton = btnSecondary;
                    break;

                case MessageBoxButtons.OKCancel:
                    btnPrimary.Text = "&OK";
                    btnPrimary.DialogResult = DialogResult.OK;

                    btnSecondary.Text = "&Cancel";
                    btnSecondary.DialogResult = DialogResult.Cancel;

                    btnPrimary.Visible = true;
                    btnSecondary.Visible = true;

                    this.AcceptButton = btnPrimary;
                    this.CancelButton = btnSecondary;
                    break;
            }
        }
    }
}
