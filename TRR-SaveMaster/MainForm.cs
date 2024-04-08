using System;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Savegame
        private Savegame previousSelectedSavegameTR1;
        private Savegame previousSelectedSavegameTR2;
        private Savegame previousSelectedSavegameTR3;
        private string savegamePath;
        private bool isLoading = false;
        private bool userIndexChanged = true;
        private Platform platform;

        // Utils
        readonly TR1Utilities TR1 = new TR1Utilities();
        readonly TR2Utilities TR2 = new TR2Utilities();
        readonly TR3Utilities TR3 = new TR3Utilities();

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetSavegamePath();
            PopulateSavegamesTR1();

            btnRefreshTR1.Enabled = !string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath);
            tsmiCreateBackup.Enabled = !string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath);
            tsmiBackupBeforeSaving.Enabled = !string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath);

            EnableToolStripMenuItemsConditionally();

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                slblStatus.Text = $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I";
            }
            else
            {
                slblStatus.Text = "Ready";
            }

            TR1.SetPlatform(platform);
            TR2.SetPlatform(platform);
            TR3.SetPlatform(platform);

            this.Text = $"Tomb Raider I-III Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(savegamePath))
            {
                PromptBrowseSavegamePath();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
            SaveSavegamePath();
        }

        private void PopulateSavegamesTR1()
        {
            cmbSavegamesTR1.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                TR1.SetSavegamePath(savegamePath);
                TR1.PopulateSavegames(cmbSavegamesTR1);
            }
        }

        private void PopulateSavegamesTR2()
        {
            cmbSavegamesTR2.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                TR2.SetSavegamePath(savegamePath);
                TR2.PopulateSavegames(cmbSavegamesTR2);
            }
        }

        private void PopulateSavegamesTR3()
        {
            cmbSavegamesTR3.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                TR3.SetSavegamePath(savegamePath);
                TR3.PopulateSavegames(cmbSavegamesTR3);
            }
        }

        private void PopulateSavegamesConditionally()
        {
            if (tabGame.SelectedIndex == TAB_TR1)
            {
                DisableButtonsTR1();
                PopulateSavegamesTR1();
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                DisableButtonsTR2();
                PopulateSavegamesTR2();
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                DisableButtonsTR3();
                PopulateSavegamesTR3();
            }
        }

        private void ClearControlsInGroupBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                    numericUpDown.Enabled = true;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                    checkBox.Enabled = true;
                }
                else if (control is TrackBar trackBar)
                {
                    trackBar.Value = trackBar.Minimum;
                    trackBar.Enabled = true;
                }
            }
        }

        private void ClearControlsTR1()
        {
            ClearControlsInGroupBox(grpItemsTR1);
            ClearControlsInGroupBox(grpWeaponsTR1);
            ClearControlsInGroupBox(grpHealthTR1);

            nudSaveNumberTR1.Value = nudSaveNumberTR1.Minimum;
            lblHealthErrorTR1.Visible = false;
            lblHealthTR1.Text = "0.1%";
            lblHealthTR1.Visible = true;

            btnSaveTR1.Enabled = false;
            btnCancelTR1.Enabled = false;
        }

        private void ClearControlsTR2()
        {
            ClearControlsInGroupBox(grpItemsTR2);
            ClearControlsInGroupBox(grpWeaponsTR2);
            ClearControlsInGroupBox(grpHealthTR2);

            nudSaveNumberTR2.Value = nudSaveNumberTR2.Minimum;
            lblHealthErrorTR2.Visible = false;
            lblHealthTR2.Text = "0.1%";
            lblHealthTR2.Visible = true;

            btnSaveTR2.Enabled = false;
            btnCancelTR2.Enabled = false;
        }

        private void ClearControlsTR3()
        {
            ClearControlsInGroupBox(grpItemsTR3);
            ClearControlsInGroupBox(grpWeaponsTR3);
            ClearControlsInGroupBox(grpHealthTR3);

            nudSaveNumberTR3.Value = nudSaveNumberTR3.Minimum;
            lblHealthErrorTR3.Visible = false;
            lblHealthTR3.Text = "0.1%";
            lblHealthTR3.Visible = true;

            btnSaveTR3.Enabled = false;
            btnCancelTR3.Enabled = false;
        }

        private bool IsValidSavegameFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Length >= 0x152004;
        }

        private void PromptBrowseSavegamePath()
        {
            DialogResult result = MessageBox.Show("Savegame path has not been set. Would you like to set it now?",
                "Savegame Path", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                BrowseSavegamePath();
            }
        }

        private void BrowseSavegamePath()
        {
            using (OpenFileDialog fileBrowserDialog = new OpenFileDialog())
            {
                fileBrowserDialog.InitialDirectory = "C:\\";
                fileBrowserDialog.Title = "Select Tomb Raider I-III Remastered savegame file";
                fileBrowserDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";

                if (fileBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!IsValidSavegameFile(fileBrowserDialog.FileName))
                    {
                        MessageBox.Show("Invalid savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    savegamePath = fileBrowserDialog.FileName;

                    ClearControlsTR1();
                    ClearControlsTR2();
                    ClearControlsTR3();

                    cmbSavegamesTR1.Items.Clear();
                    cmbSavegamesTR2.Items.Clear();
                    cmbSavegamesTR3.Items.Clear();

                    PopulateSavegamesConditionally();

                    btnRefreshTR1.Enabled = true;
                    btnRefreshTR2.Enabled = true;
                    btnRefreshTR3.Enabled = true;

                    EnableToolStripMenuItemsConditionally();

                    tsmiCreateBackup.Enabled = true;
                    tsmiBackupBeforeSaving.Enabled = true;

                    this.Text = $"Tomb Raider I-III Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";

                    slblStatus.Text = $"Loaded savegame file: \"{savegamePath}\"";
                }
            }
        }

        private void SetPlatform(Platform platform)
        {
            tsmiPC.CheckedChanged -= tsmiPC_CheckedChanged;
            tsmiPlayStation4.CheckedChanged -= tsmiPlayStation4_CheckedChanged;
            tsmiNintendoSwitch.CheckedChanged -= tsmiNintendoSwitch_CheckedChanged;

            tsmiPC.Checked = (platform == Platform.PC);
            tsmiPlayStation4.Checked = (platform == Platform.PlayStation4);
            tsmiNintendoSwitch.Checked = (platform == Platform.NintendoSwitch);

            tsmiPC.CheckedChanged += tsmiPC_CheckedChanged;
            tsmiPlayStation4.CheckedChanged += tsmiPlayStation4_CheckedChanged;
            tsmiNintendoSwitch.CheckedChanged += tsmiNintendoSwitch_CheckedChanged;

            this.platform = platform;
            this.Text = $"Tomb Raider I-III Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";

            TR1.SetPlatform(platform);
            TR2.SetPlatform(platform);
            TR3.SetPlatform(platform);

            if (tabGame.SelectedIndex == TAB_TR1 && cmbSavegamesTR1.SelectedIndex != -1)
            {
                DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
            }
            else if (tabGame.SelectedIndex == TAB_TR2 && cmbSavegamesTR2.SelectedIndex != -1)
            {
                DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
            }
            else if (tabGame.SelectedIndex == TAB_TR3 && cmbSavegamesTR3.SelectedIndex != -1)
            {
                DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
            }
        }

        private void GetSavegamePath()
        {
            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootFolder, "path.ini");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (line.StartsWith("Path="))
                    {
                        string directoryPath = line.Substring("Path=".Length);
                        savegamePath = directoryPath;
                    }
                    else if (line.StartsWith("AutoBackup="))
                    {
                        bool autoBackup;

                        if (bool.TryParse(line.Substring("AutoBackup=".Length), out autoBackup))
                        {
                            tsmiBackupBeforeSaving.Checked = autoBackup;
                        }
                    }
                    else if (line.StartsWith("Platform="))
                    {
                        string platform = line.Substring("Platform=".Length);

                        if (platform == "PC")
                        {
                            SetPlatform(Platform.PC);
                        }
                        else if (platform == "PS4")
                        {
                            SetPlatform(Platform.PlayStation4);
                        }
                        else if (platform == "NintendoSwitch")
                        {
                            SetPlatform(Platform.NintendoSwitch);
                        }
                        else
                        {
                            SetPlatform(Platform.PC);
                        }
                    }
                }
            }
            else
            {
                SaveSavegamePath();
            }
        }

        private void SaveSavegamePath()
        {
            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootFolder, "path.ini");

            string content = $"Path={savegamePath}\n";
            content += $"AutoBackup={tsmiBackupBeforeSaving.Checked}\n";

            string platform = "";

            if (tsmiPC.Checked)
            {
                platform = "PC";
            }
            else if (tsmiPlayStation4.Checked)
            {
                platform = "PS4";
            }
            else if (tsmiNintendoSwitch.Checked)
            {
                platform = "NintendoSwitch";
            }

            content += $"Platform={platform}";

            File.WriteAllText(filePath, content);
        }

        private void btnExitTR1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExitTR2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExitTR3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfirmChanges()
        {
            if (tabGame.SelectedIndex == TAB_TR1 && cmbSavegamesTR1.SelectedIndex != -1 && btnSaveTR1.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR1(cmbSavegamesTR1.SelectedItem as Savegame);
                }

                DisableButtonsTR1();
            }
            else if (tabGame.SelectedIndex == TAB_TR2 && cmbSavegamesTR2.SelectedIndex != -1 && btnSaveTR2.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR2(cmbSavegamesTR2.SelectedItem as Savegame);
                }

                DisableButtonsTR2();
            }
            else if (tabGame.SelectedIndex == TAB_TR3 && cmbSavegamesTR3.SelectedIndex != -1 && btnSaveTR3.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR3(cmbSavegamesTR3.SelectedItem as Savegame);
                }

                DisableButtonsTR3();
            }
        }

        private void cmbSavegamesTR1_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR1.SelectedIndexChanged -= cmbSavegamesTR1_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                for (int i = 0; i < cmbSavegamesTR1.Items.Count; i++)
                {
                    if (cmbSavegamesTR1.Items[i] is Savegame savegame)
                    {
                        TR1.UpdateDisplayName(savegame);

                        cmbSavegamesTR1.Items[i] = savegame;
                    }
                }

                TR1.PopulateEmptySlots(cmbSavegamesTR1);
            }

            cmbSavegamesTR1.SelectedIndexChanged += cmbSavegamesTR1_SelectedIndexChanged;
        }

        private void cmbSavegamesTR2_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR2.SelectedIndexChanged -= cmbSavegamesTR2_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                for (int i = 0; i < cmbSavegamesTR2.Items.Count; i++)
                {
                    if (cmbSavegamesTR2.Items[i] is Savegame savegame)
                    {
                        TR2.UpdateDisplayName(savegame);

                        cmbSavegamesTR2.Items[i] = savegame;
                    }
                }

                TR2.PopulateEmptySlots(cmbSavegamesTR2);
            }

            cmbSavegamesTR2.SelectedIndexChanged += cmbSavegamesTR2_SelectedIndexChanged;
        }

        private void cmbSavegamesTR3_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR3.SelectedIndexChanged -= cmbSavegamesTR3_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                for (int i = 0; i < cmbSavegamesTR3.Items.Count; i++)
                {
                    if (cmbSavegamesTR3.Items[i] is Savegame savegame)
                    {
                        TR3.UpdateDisplayName(savegame);

                        cmbSavegamesTR3.Items[i] = savegame;
                    }
                }

                TR3.PopulateEmptySlots(cmbSavegamesTR3);
            }

            cmbSavegamesTR3.SelectedIndexChanged += cmbSavegamesTR3_SelectedIndexChanged;
        }

        private void cmbSavegamesTR1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegameTR1 != null && btnSaveTR1.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR1(previousSelectedSavegameTR1);
                }
            }

            previousSelectedSavegameTR1 = cmbSavegamesTR1.SelectedItem as Savegame;

            DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
            DisableButtonsTR1();
            EnableToolStripMenuItemsConditionally();
        }

        private void cmbSavegamesTR2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegameTR2 != null && btnSaveTR2.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR2(previousSelectedSavegameTR2);
                }
            }

            previousSelectedSavegameTR2 = cmbSavegamesTR2.SelectedItem as Savegame;

            DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
            DisableButtonsTR2();
            EnableToolStripMenuItemsConditionally();
        }

        private void cmbSavegamesTR3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegameTR3 != null && btnSaveTR3.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR3(previousSelectedSavegameTR3);
                }
            }

            previousSelectedSavegameTR3 = cmbSavegamesTR3.SelectedItem as Savegame;

            DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
            DisableButtonsTR3();
            EnableToolStripMenuItemsConditionally();
        }

        private void btnCancelTR1_Click(object sender, EventArgs e)
        {
            DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
            DisableButtonsTR1();
        }

        private void btnCancelTR2_Click(object sender, EventArgs e)
        {
            DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
            DisableButtonsTR2();
        }

        private void btnCancelTR3_Click(object sender, EventArgs e)
        {
            DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
            DisableButtonsTR3();
        }

        private void trbHealthTR1_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = ((double)trbHealthTR1.Value / (double)MAX_HEALTH_VALUE) * 100;
            lblHealthTR1.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void trbHealthTR2_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = ((double)trbHealthTR2.Value / (double)MAX_HEALTH_VALUE * 100);
            lblHealthTR2.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void trbHealthTR3_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = ((double)trbHealthTR3.Value / (double)MAX_HEALTH_VALUE * 100);
            lblHealthTR3.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void CreateBackup()
        {
            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                string directory = Path.GetDirectoryName(savegamePath);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(savegamePath);
                string fileExtension = Path.GetExtension(savegamePath);

                string backupFilePath = Path.Combine(directory, $"{fileNameWithoutExtension}{fileExtension}.bak");

                if (File.Exists(backupFilePath))
                {
                    File.SetAttributes(backupFilePath, File.GetAttributes(backupFilePath) & ~FileAttributes.ReadOnly);
                }

                File.Copy(savegamePath, backupFilePath, true);

                slblStatus.Text = $"Created savegame backup: \"{backupFilePath}\"";
            }
        }

        private void WriteChangesTR1(Savegame savegame)
        {
            if (savegame != null)
            {
                try
                {
                    TR1.SetSavegamePath(savegamePath);
                    TR1.SetSavegameOffset(savegame.Offset);

                    if (!TR1.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR1();
                        PopulateSavegamesTR1();
                        return;
                    }

                    if (tsmiBackupBeforeSaving.Checked)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                    TR1.WriteChanges(chkPistolsTR1, chkMagnumsTR1, chkUzisTR1, chkShotgunTR1, nudSaveNumberTR1,
                        nudSmallMedipacksTR1, nudLargeMedipacksTR1, nudUziAmmoTR1, nudMagnumAmmoTR1, nudShotgunAmmoTR1, trbHealthTR1);

                    TR1.UpdateDisplayName(savegame);
                    UpdateSavegameDisplayNameTR1(cmbSavegamesTR1, savegame);

                    DisableButtonsTR1();

                    slblStatus.Text = $"Successfully patched savegame: '{savegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error writing to savegame.";
                }
            }
        }

        private void WriteChangesTR2(Savegame savegame)
        {
            if (savegame != null)
            {
                try
                {
                    TR2.SetSavegamePath(savegamePath);
                    TR2.SetSavegameOffset(savegame.Offset);

                    if (!TR2.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR2();
                        PopulateSavegamesTR2();
                        return;
                    }

                    if (tsmiBackupBeforeSaving.Checked)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                    TR2.WriteChanges(chkPistolsTR2, chkAutomaticPistolsTR2, chkUzisTR2, chkShotgunTR2,
                        chkM16TR2, chkGrenadeLauncherTR2, chkHarpoonGunTR2, nudSaveNumberTR2, nudFlaresTR2,
                        nudSmallMedipacksTR2, nudLargeMedipacksTR2, nudAutomaticPistolsAmmoTR2,
                        nudUziAmmoTR2, nudM16AmmoTR2, nudGrenadeLauncherAmmoTR2, nudHarpoonGunAmmoTR2,
                        nudShotgunAmmoTR2, trbHealthTR2);

                    TR2.UpdateDisplayName(savegame);
                    UpdateSavegameDisplayNameTR2(cmbSavegamesTR2, savegame);

                    DisableButtonsTR2();

                    slblStatus.Text = $"Successfully patched savegame: '{savegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error writing to savegame.";
                }
            }
        }

        private void WriteChangesTR3(Savegame savegame)
        {
            if (savegame != null)
            {
                try
                {
                    TR3.SetSavegamePath(savegamePath);
                    TR3.SetSavegameOffset(savegame.Offset);

                    if (!TR3.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR3();
                        PopulateSavegamesTR3();
                        return;
                    }

                    if (tsmiBackupBeforeSaving.Checked)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                    TR3.WriteChanges(chkPistolsTR3, chkDeagleTR3, chkUziTR3, chkShotgunTR3, chkMP5TR3, chkRocketLauncherTR3,
                        chkGrenadeLauncherTR3, chkHarpoonGunTR3, nudSaveNumberTR3, nudFlaresTR3, nudSmallMedipacksTR3,
                        nudLargeMedipacksTR3, nudShotgunAmmoTR3, nudDeagleAmmoTR3, nudGrenadeLauncherAmmoTR3, nudRocketLauncherAmmoTR3,
                        nudHarpoonGunAmmoTR3, nudMP5AmmoTR3, nudUziAmmoTR3, trbHealthTR3, nudCollectibleCrystalsTR3);

                    TR3.UpdateDisplayName(savegame);
                    UpdateSavegameDisplayNameTR3(cmbSavegamesTR3, savegame);

                    DisableButtonsTR3();

                    slblStatus.Text = $"Successfully patched savegame: '{savegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error writing to savegame.";
                }
            }
        }

        private void btnSaveTR1_Click(object sender, EventArgs e)
        {
            WriteChangesTR1(cmbSavegamesTR1.SelectedItem as Savegame);
        }

        private void btnSaveTR2_Click(object sender, EventArgs e)
        {
            WriteChangesTR2(cmbSavegamesTR2.SelectedItem as Savegame);
        }

        private void btnSaveTR3_Click(object sender, EventArgs e)
        {
            WriteChangesTR3(cmbSavegamesTR3.SelectedItem as Savegame);
        }

        private void btnRefreshTR1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                cmbSavegamesTR1.Items.Clear();
                TR1.PopulateSavegames(cmbSavegamesTR1);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath)) ?
                    $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                cmbSavegamesTR2.Items.Clear();
                TR2.PopulateSavegames(cmbSavegamesTR2);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath)) ?
                    $"{cmbSavegamesTR2.Items.Count} savegames found for Tomb Raider II" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                cmbSavegamesTR3.Items.Clear();
                TR3.PopulateSavegames(cmbSavegamesTR3);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath)) ?
                    $"{cmbSavegamesTR3.Items.Count} savegames found for Tomb Raider III" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSavegameDisplayNameTR1(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR1_SelectedIndexChanged;

            if (cmbSavegames.SelectedItem != null)
            {
                int selectedIndex = cmbSavegames.Items.IndexOf(selectedSavegame);

                if (selectedIndex != -1)
                {
                    cmbSavegames.Items[selectedIndex] = selectedSavegame;
                }
                else
                {
                    cmbSavegames.Items.Add(selectedSavegame);
                }
            }

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR1_SelectedIndexChanged;
        }

        private void UpdateSavegameDisplayNameTR2(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR2_SelectedIndexChanged;

            if (cmbSavegames.SelectedItem != null)
            {
                int selectedIndex = cmbSavegames.Items.IndexOf(selectedSavegame);

                if (selectedIndex != -1)
                {
                    cmbSavegames.Items[selectedIndex] = selectedSavegame;
                }
                else
                {
                    cmbSavegames.Items.Add(selectedSavegame);
                }
            }

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR2_SelectedIndexChanged;
        }

        private void UpdateSavegameDisplayNameTR3(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR3_SelectedIndexChanged;

            if (cmbSavegames.SelectedItem != null)
            {
                int selectedIndex = cmbSavegames.Items.IndexOf(selectedSavegame);

                if (selectedIndex != -1)
                {
                    cmbSavegames.Items[selectedIndex] = selectedSavegame;
                }
                else
                {
                    cmbSavegames.Items.Add(selectedSavegame);
                }
            }

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR3_SelectedIndexChanged;
        }

        private void DisplayGameInfoTR1(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR1.SetSavegamePath(savegamePath);
                    TR1.SetSavegameOffset(selectedSavegame.Offset);

                    if (!TR1.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR1();
                        PopulateSavegamesTR1();
                        return;
                    }

                    TR1.UpdateDisplayName(selectedSavegame);
                    UpdateSavegameDisplayNameTR1(cmbSavegamesTR1, selectedSavegame);

                    TR1.DisplayGameInfo(chkPistolsTR1, chkMagnumsTR1, chkUzisTR1, chkShotgunTR1,
                        nudSmallMedipacksTR1, nudLargeMedipacksTR1, nudUziAmmoTR1, nudShotgunAmmoTR1, nudMagnumAmmoTR1,
                        nudSaveNumberTR1, trbHealthTR1, lblHealthTR1, lblHealthErrorTR1);

                    slblStatus.Text = $"Successfully loaded savegame: '{selectedSavegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error retrieving savegame info.";
                }

                isLoading = false;
            }
        }

        private void DisplayGameInfoTR2(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR2.SetSavegamePath(savegamePath);
                    TR2.SetSavegameOffset(selectedSavegame.Offset);

                    if (!TR2.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR2();
                        PopulateSavegamesTR2();
                        return;
                    }

                    TR2.UpdateDisplayName(selectedSavegame);
                    UpdateSavegameDisplayNameTR2(cmbSavegamesTR2, selectedSavegame);

                    TR2.SetLevelParams(chkPistolsTR2, chkShotgunTR2, chkAutomaticPistolsTR2, chkUzisTR2, chkM16TR2,
                        chkGrenadeLauncherTR2, chkHarpoonGunTR2, nudShotgunAmmoTR2, nudAutomaticPistolsAmmoTR2, nudUziAmmoTR2,
                        nudM16AmmoTR2, nudGrenadeLauncherAmmoTR2, nudHarpoonGunAmmoTR2);

                    TR2.DisplayGameInfo(chkPistolsTR2, chkAutomaticPistolsTR2, chkUzisTR2, chkM16TR2,
                        chkGrenadeLauncherTR2, chkHarpoonGunTR2, nudSaveNumberTR2, nudAutomaticPistolsAmmoTR2, chkShotgunTR2,
                        nudUziAmmoTR2, nudM16AmmoTR2, nudGrenadeLauncherAmmoTR2, nudHarpoonGunAmmoTR2,
                        nudShotgunAmmoTR2, nudFlaresTR2, nudSmallMedipacksTR2, nudLargeMedipacksTR2,
                        trbHealthTR2, lblHealthTR2, lblHealthErrorTR2);

                    slblStatus.Text = $"Successfully loaded savegame: '{selectedSavegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error retrieving savegame info.";
                }

                isLoading = false;
            }
        }

        private void DisplayGameInfoTR3(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR3.SetSavegamePath(savegamePath);
                    TR3.SetSavegameOffset(selectedSavegame.Offset);

                    if (!TR3.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR3();
                        PopulateSavegamesTR3();
                        return;
                    }

                    TR3.UpdateDisplayName(selectedSavegame);
                    UpdateSavegameDisplayNameTR3(cmbSavegamesTR3, selectedSavegame);

                    TR3.DisplayGameInfo(chkPistolsTR3, chkShotgunTR3, chkDeagleTR3, chkUziTR3, chkMP5TR3,
                        chkRocketLauncherTR3, chkGrenadeLauncherTR3, chkHarpoonGunTR3, nudSaveNumberTR3, nudSmallMedipacksTR3,
                        nudLargeMedipacksTR3, nudFlaresTR3, nudShotgunAmmoTR3, nudDeagleAmmoTR3, nudGrenadeLauncherAmmoTR3,
                        nudRocketLauncherAmmoTR3, nudHarpoonGunAmmoTR3, nudMP5AmmoTR3, nudUziAmmoTR3,
                        trbHealthTR3, lblHealthTR3, lblHealthErrorTR3, nudCollectibleCrystalsTR3, lblCollectibleCrystalsTR3);

                    slblStatus.Text = $"Successfully loaded savegame: '{selectedSavegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error retrieving savegame info.";
                }

                isLoading = false;
            }
        }

        private void tabGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabGame.SelectedIndex == TAB_TR1)
            {
                btnRefreshTR1.Enabled = !string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath);

                if (cmbSavegamesTR1.Items.Count == 0)
                {
                    PopulateSavegamesTR1();
                }
                else
                {
                    DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath)) ?
                    $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                btnRefreshTR2.Enabled = !string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath);

                if (cmbSavegamesTR2.Items.Count == 0)
                {
                    PopulateSavegamesTR2();
                }
                else
                {
                    DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath)) ?
                    $"{cmbSavegamesTR2.Items.Count} savegames found for Tomb Raider II" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                btnRefreshTR3.Enabled = !string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath);

                if (cmbSavegamesTR3.Items.Count == 0)
                {
                    PopulateSavegamesTR3();
                }
                else
                {
                    DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath)) ?
                    $"{cmbSavegamesTR3.Items.Count} savegames found for Tomb Raider III" : "Ready";
            }

            EnableToolStripMenuItemsConditionally();
        }

        private void tabGame_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            ConfirmChanges();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiAlwaysOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = tsmiAlwaysOnTop.Checked;
        }

        private void tsmiViewReadme_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JulianOzelRose/TRR-SaveMaster/blob/master/README.md");
        }

        private void tsmiSendFeedback_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JulianOzelRose/TRR-SaveMaster/issues");
        }

        private void tsmiStatusBar_Click(object sender, EventArgs e)
        {
            if (tsmiStatusBar.Checked)
            {
                ssrStatusStrip.Visible = true;
                slblStatus.Visible = true;
                this.Height += ssrStatusStrip.Height;
            }
            else
            {
                ssrStatusStrip.Visible = false;
                slblStatus.Visible = false;
                this.Height -= ssrStatusStrip.Height;
            }
        }

        private void tsmiCreateBackup_Click(object sender, EventArgs e)
        {
            CreateBackup();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.TopMost = TopMost;
            aboutForm.ShowDialog();
        }

        private void tsmiStatistics_Click(object sender, EventArgs e)
        {
            if (!File.Exists(savegamePath))
            {
                string errorMessage = $"Could not find savegame file.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            StatisticsForm statisticsForm = new StatisticsForm(slblStatus, tsmiBackupBeforeSaving.Checked,
                savegamePath, tabGame.SelectedIndex);

            Savegame selectedSavegame = null;

            bool savegamePresent = false;

            if (tabGame.SelectedIndex == TAB_TR1 && cmbSavegamesTR1.SelectedIndex != -1)
            {
                selectedSavegame = cmbSavegamesTR1.Items[cmbSavegamesTR1.SelectedIndex] as Savegame;
                savegamePresent = TR1.IsSavegamePresent();
            }
            else if (tabGame.SelectedIndex == TAB_TR2 && cmbSavegamesTR2.SelectedIndex != -1)
            {
                selectedSavegame = cmbSavegamesTR2.Items[cmbSavegamesTR2.SelectedIndex] as Savegame;
                savegamePresent = TR2.IsSavegamePresent();
            }
            else if (tabGame.SelectedIndex == TAB_TR3 && cmbSavegamesTR3.SelectedIndex != -1)
            {
                selectedSavegame = cmbSavegamesTR3.Items[cmbSavegamesTR3.SelectedIndex] as Savegame;
                savegamePresent = TR3.IsSavegamePresent();
            }

            if (!savegamePresent)
            {
                string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                PopulateSavegamesConditionally();
                return;
            }

            if (selectedSavegame != null)
            {
                statisticsForm.SetSavegame(selectedSavegame);
                statisticsForm.TopMost = TopMost;
                statisticsForm.ShowDialog();
            }
        }

        private void tsmiPosition_Click(object sender, EventArgs e)
        {
            if (!File.Exists(savegamePath))
            {
                string errorMessage = $"Could not find savegame file.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            PositionForm positionForm = new PositionForm(slblStatus, tsmiBackupBeforeSaving.Checked,
                savegamePath, tabGame.SelectedIndex);

            Savegame selectedSavegame = null;

            if (tabGame.SelectedIndex == TAB_TR1 && cmbSavegamesTR1.SelectedIndex != -1)
            {
                if (!TR1.IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtonsTR1();
                    PopulateSavegamesTR1();
                    return;
                }

                int healthOffset = TR1.GetHealthOffset();

                if (healthOffset == -1)
                {
                    string errorMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedSavegame = cmbSavegamesTR1.Items[cmbSavegamesTR1.SelectedIndex] as Savegame;
                positionForm.SetHealthOffset(healthOffset - selectedSavegame.Offset);
            }
            else if (tabGame.SelectedIndex == TAB_TR2 && cmbSavegamesTR2.SelectedIndex != -1)
            {
                if (!TR2.IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtonsTR2();
                    PopulateSavegamesTR2();
                    return;
                }

                int healthOffset = TR2.GetHealthOffset();

                if (healthOffset == -1)
                {
                    string errorMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedSavegame = cmbSavegamesTR2.Items[cmbSavegamesTR2.SelectedIndex] as Savegame;
                positionForm.SetHealthOffset(healthOffset - selectedSavegame.Offset);
            }
            else if (tabGame.SelectedIndex == TAB_TR3 && cmbSavegamesTR3.SelectedIndex != -1)
            {
                if (!TR3.IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtonsTR3();
                    PopulateSavegamesTR3();
                    return;
                }

                int healthOffset = TR3.GetHealthOffset();

                if (healthOffset == -1)
                {
                    string errorMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedSavegame = cmbSavegamesTR3.Items[cmbSavegamesTR3.SelectedIndex] as Savegame;
                positionForm.SetHealthOffset(healthOffset - selectedSavegame.Offset);
            }

            if (selectedSavegame != null)
            {
                positionForm.SetSavegame(selectedSavegame);
                positionForm.TopMost = TopMost;
                positionForm.ShowDialog();
            }
        }

        private void tsmiBrowseSavegamePath_Click(object sender, EventArgs e)
        {
            BrowseSavegamePath();
        }

        private void tsmiPC_CheckedChanged(object sender, EventArgs e)
        {
            SetPlatform(Platform.PC);
        }

        private void tsmiPlayStation4_CheckedChanged(object sender, EventArgs e)
        {
            SetPlatform(Platform.PlayStation4);
        }

        private void tsmiNintendoSwitch_CheckedChanged(object sender, EventArgs e)
        {
            SetPlatform(Platform.NintendoSwitch);
        }

        private void tsmiEnableAllWeapons_Click(object sender, EventArgs e)
        {
            if (tabGame.SelectedIndex == TAB_TR1)
            {
                EnableAllWeapons(grpWeaponsTR1);
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                EnableAllWeapons(grpWeaponsTR2);
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                EnableAllWeapons(grpWeaponsTR3);
            }
        }

        private void tsmiSetMaximumAmmunition_Click(object sender, EventArgs e)
        {
            if (tabGame.SelectedIndex == TAB_TR1)
            {
                SetMaximumAmmunition(grpWeaponsTR1);
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                SetMaximumAmmunition(grpWeaponsTR2);
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                SetMaximumAmmunition(grpWeaponsTR3);
            }
        }

        private void tsmiSetMaximumItems_Click(object sender, EventArgs e)
        {
            if (tabGame.SelectedIndex == TAB_TR1)
            {
                SetMaximumItems(grpItemsTR1);
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                SetMaximumItems(grpItemsTR2);
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                SetMaximumItems(grpItemsTR3);
            }
        }

        private void tsmiMaxEverything_Click(object sender, EventArgs e)
        {
            tsmiEnableAllWeapons.PerformClick();
            tsmiSetMaximumAmmunition.PerformClick();
            tsmiSetMaximumItems.PerformClick();

            if (tabGame.SelectedIndex == TAB_TR1 && trbHealthTR1.Enabled)
            {
                trbHealthTR1.Value = trbHealthTR1.Maximum;
                lblHealthTR1.Text = "100.0%";
            }
            else if (tabGame.SelectedIndex == TAB_TR2 && trbHealthTR2.Enabled)
            {
                trbHealthTR2.Value = trbHealthTR2.Maximum;
                lblHealthTR2.Text = "100.0%";
            }
            else if (tabGame.SelectedIndex == TAB_TR3 && trbHealthTR3.Enabled)
            {
                trbHealthTR3.Value = trbHealthTR3.Maximum;
                lblHealthTR3.Text = "100.0%";
            }
        }

        private void EnableAllWeapons(GroupBox grpWeapons)
        {
            foreach (Control control in grpWeapons.Controls)
            {
                if (control is CheckBox chkWeapon && chkWeapon.Enabled)
                {
                    chkWeapon.Checked = true;
                }
            }
        }

        private void SetMaximumAmmunition(GroupBox grpWeapons)
        {
            foreach (Control control in grpWeapons.Controls)
            {
                if (control is NumericUpDown nudAmmo && nudAmmo.Enabled)
                {
                    nudAmmo.Value = nudAmmo.Maximum;
                }
            }
        }

        private void SetMaximumItems(GroupBox grpItems)
        {
            foreach (Control control in grpItems.Controls)
            {
                if (control is NumericUpDown nudItem && nudItem.Enabled)
                {
                    nudItem.Value = nudItem.Maximum;
                }
            }
        }

        private void EnableToolStripMenuItemsConditionally()
        {
            if (tabGame.SelectedIndex == TAB_TR1)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
            }
        }

        private void EnableButtonsTR1()
        {
            btnCancelTR1.Enabled = true;
            btnSaveTR1.Enabled = true;
        }

        private void EnableButtonsTR2()
        {
            btnCancelTR2.Enabled = true;
            btnSaveTR2.Enabled = true;
        }

        private void EnableButtonsTR3()
        {
            btnCancelTR3.Enabled = true;
            btnSaveTR3.Enabled = true;
        }

        private void DisableButtonsTR1()
        {
            btnCancelTR1.Enabled = false;
            btnSaveTR1.Enabled = false;
        }

        private void DisableButtonsTR2()
        {
            btnCancelTR2.Enabled = false;
            btnSaveTR2.Enabled = false;
        }

        private void DisableButtonsTR3()
        {
            btnCancelTR3.Enabled = false;
            btnSaveTR3.Enabled = false;
        }

        private void nudSaveNumberTR1_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudSmallMedipacksTR1_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudLargeMedipacksTR1_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudShotgunAmmoTR1_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudMagnumAmmoTR1_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudUziAmmoTR1_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudSaveNumberTR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudShotgunAmmoTR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudMagnumAmmoTR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudUziAmmoTR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudSmallMedipacksTR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudLargeMedipacksTR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void chkPistolsTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void chkShotgunTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void chkMagnumsTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void chkUzisTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void nudSaveNumberTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudSmallMedipacksTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudLargeMedipacksTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudFlaresTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudShotgunAmmoTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudAutomaticPistolsAmmoTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudUziAmmoTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudM16AmmoTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudGrenadeLauncherAmmoTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudHarpoonGunAmmoTR2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudSaveNumberTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudSmallMedipacksTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudLargeMedipacksTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudFlaresTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudShotgunAmmoTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudAutomaticPistolsAmmoTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudUziAmmoTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudM16AmmoTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudGrenadeLauncherAmmoTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudHarpoonGunAmmoTR2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkPistolsTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkShotgunTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkAutomaticPistolsTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkUzisTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkM16TR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkGrenadeLauncherTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void chkHarpoonGunTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void nudSaveNumberTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudSmallMedipacksTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudLargeMedipacksTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudFlaresTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudShotgunAmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudDeagleAmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudGrenadeLauncherAmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudRocketLauncherAmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudHarpoonGunAmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudMP5AmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudUziAmmoTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudCollectibleCrystalsTR3_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudSaveNumberTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudSmallMedipacksTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudLargeMedipacksTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudFlaresTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudShotgunAmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudDeagleAmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudGrenadeLauncherAmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudRocketLauncherAmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudHarpoonGunAmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudMP5AmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudUziAmmoTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudCollectibleCrystalsTR3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkPistolsTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkShotgunTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkDeagleTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkGrenadeLauncherTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkRocketLauncherTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkHarpoonGunTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkMP5TR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void chkUziTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }
    }
}