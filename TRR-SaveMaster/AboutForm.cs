using System;
using System.Windows.Forms;
using TRR_SaveMaster.Properties;

namespace TRR_SaveMaster
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            if (ThemeUtilities.DARK_MODE_ENABLED)
            {
                ThemeUtilities.ApplyDarkTitleBar(this);
                BackgroundImage = Resources.About_Background_DarkMode;
            }

            lblVersion.Text = $"Version {Globals.VERSION}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Globals.GITHUB_LINK);
        }

        private void llbGitHub_MouseHover(object sender, EventArgs e)
        {
            if (sender is LinkLabel linkLabel)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.InitialDelay = 500;
                toolTip.SetToolTip(linkLabel, Globals.GITHUB_LINK);
            }
        }
    }
}
