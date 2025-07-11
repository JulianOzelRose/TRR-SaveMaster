﻿using System;
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
        private Savegame previousSelectedSavegameTR4;
        private Savegame previousSelectedSavegameTR5;
        private Savegame previousSelectedSavegameTR6;
        private string savegamePathTRX;
        private string savegamePathTRX2;
        private bool isLoading = false;
        private bool isInventoryLoading = false;
        private bool userIndexChanged = true;
        private bool hasShownTRX2PathPrompt = false;
        private Platform platform;
        private const string CONFIG_FILE_NAME = "TRR-SaveMaster.ini";
        private const int SAVEGAME_SIZE_TRX = 0x3800;
        private const int SAVEGAME_SIZE_TRX2 = 0xA470;
        private const int SAVEGAME_FILE_SIZE_TRX = 0x152004;
        //private const int SAVEGAME_FILE_SIZE_TRX2 = 0x3DCA04;

        // Utils
        readonly TR1Utilities TR1 = new TR1Utilities();
        readonly TR2Utilities TR2 = new TR2Utilities();
        readonly TR3Utilities TR3 = new TR3Utilities();
        readonly TR4Utilities TR4 = new TR4Utilities();
        readonly TR5Utilities TR5 = new TR5Utilities();
        readonly TR6Utilities TR6 = new TR6Utilities();

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;
        private const int TAB_TR4 = 3;
        private const int TAB_TR5 = 4;
        private const int TAB_TR6 = 5;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadConfigFile();
            PopulateSavegamesTR1();

            btnRefreshTR1.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);
            tsmiCreateBackup.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);
            tsmiBackupBeforeSaving.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);

            EnableToolStripMenuItemsConditionally();

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
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

            this.Text = $"Tomb Raider I-VI Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(savegamePathTRX))
            {
                PromptBrowseSavegamePathTRX();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
            UpdateConfigFile();
        }

        private void PopulateSavegamesTR1()
        {
            cmbSavegamesTR1.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                TR1.SetSavegamePath(savegamePathTRX);
                TR1.PopulateSavegames(cmbSavegamesTR1);
            }
        }

        private void PopulateSavegamesTR2()
        {
            cmbSavegamesTR2.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                TR2.SetSavegamePath(savegamePathTRX);
                TR2.PopulateSavegames(cmbSavegamesTR2);
            }
        }

        private void PopulateSavegamesTR3()
        {
            cmbSavegamesTR3.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                TR3.SetSavegamePath(savegamePathTRX);
                TR3.PopulateSavegames(cmbSavegamesTR3);
            }
        }

        private void PopulateSavegamesTR4()
        {
            cmbSavegamesTR4.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                TR4.SetSavegamePath(savegamePathTRX2);
                TR4.PopulateSavegames(cmbSavegamesTR4);
            }
        }

        private void PopulateSavegamesTR5()
        {
            cmbSavegamesTR5.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                TR5.SetSavegamePath(savegamePathTRX2);
                TR5.PopulateSavegames(cmbSavegamesTR5);
            }
        }

        private void PopulateSavegamesTR6()
        {
            cmbSavegamesTR6.Items.Clear();

            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                TR6.SetSavegamePath(savegamePathTRX2);
                TR6.PopulateSavegames(cmbSavegamesTR6);
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
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                DisableButtonsTR4();
                PopulateSavegamesTR4();
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                DisableButtonsTR5();
                PopulateSavegamesTR5();
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                DisableButtonsTR6();
                PopulateSavegamesTR6();
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

            lblPistolAmmoTR2.Enabled = true;

            btnSaveTR3.Enabled = false;
            btnCancelTR3.Enabled = false;
        }

        private void ClearControlsTR4()
        {
            ClearControlsInGroupBox(grpItemsTR4);
            ClearControlsInGroupBox(grpWeaponsTR4);
            ClearControlsInGroupBox(grpHealthTR4);

            nudSaveNumberTR4.Value = nudSaveNumberTR4.Minimum;
            lblHealthErrorTR4.Visible = false;
            lblHealthTR4.Text = "0.1%";
            lblHealthTR4.Visible = true;

            btnSaveTR4.Enabled = false;
            btnCancelTR4.Enabled = false;
        }

        private void ClearControlsTR5()
        {
            ClearControlsInGroupBox(grpItemsTR5);
            ClearControlsInGroupBox(grpWeaponsTR5);
            ClearControlsInGroupBox(grpHealthTR5);

            nudSaveNumberTR5.Value = nudSaveNumberTR5.Minimum;
            lblHealthErrorTR5.Visible = false;
            lblHealthTR5.Text = "0.1%";
            lblHealthTR5.Visible = true;

            lblPistolAmmoTR5.Enabled = true;

            btnSaveTR5.Enabled = false;
            btnCancelTR5.Enabled = false;
        }

        private void ClearControlsTR6()
        {
            ClearControlsInGroupBox(grpItemsTR6);
            ClearControlsInGroupBox(grpWeaponsTR6);
            ClearControlsInGroupBox(grpHealthTR6);

            lblHealthErrorTR6.Visible = false;
            lblHealthTR6.Text = "0.1%";
            lblHealthTR6.Visible = true;

            lblChirugaiBladeAmmoTR6.Enabled = true;
            lblScorpionXPairAmmoTR6.Enabled = true;
            lblVectorR35PairAmmoTR6.Enabled = true;

            btnSaveTR6.Enabled = false;
            btnCancelTR6.Enabled = false;
        }

        private bool IsValidSavegameFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Extension.ToLower() != ".dat")
            {
                return false;
            }

            return fileInfo.Length >= SAVEGAME_FILE_SIZE_TRX;
        }

        private void PromptBrowseSavegamePathTRX()
        {
            DialogResult result = MessageBox.Show("Tomb Raider I-III savegame path has not been set. Would you like to set it now?",
                "Savegame Path", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                BrowseSavegamePathTRX();
            }
        }

        private void PromptBrowseSavegamePathTRX2()
        {
            DialogResult result = MessageBox.Show("Tomb Raider IV-VI savegame path has not been set. Would you like to set it now?",
                "Savegame Path", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                BrowseSavegamePathTRX2();
            }

            hasShownTRX2PathPrompt = true;
        }

        private void BrowseSavegamePathTRX()
        {
            using (OpenFileDialog fileBrowserDialog = new OpenFileDialog())
            {
                fileBrowserDialog.InitialDirectory = "C:\\";
                fileBrowserDialog.Title = "Select Tomb Raider I-III savegame file";
                fileBrowserDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";

                if (fileBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!IsValidSavegameFile(fileBrowserDialog.FileName))
                    {
                        MessageBox.Show("Invalid savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    savegamePathTRX = fileBrowserDialog.FileName;

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

                    this.Text = $"Tomb Raider I-VI Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";

                    slblStatus.Text = $"Loaded savegame file: \"{savegamePathTRX}\"";
                }
            }
        }

        private void BrowseSavegamePathTRX2()
        {
            using (OpenFileDialog fileBrowserDialog = new OpenFileDialog())
            {
                fileBrowserDialog.InitialDirectory = "C:\\";
                fileBrowserDialog.Title = "Select Tomb Raider IV-VI savegame file";
                fileBrowserDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";

                if (fileBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!IsValidSavegameFile(fileBrowserDialog.FileName))
                    {
                        MessageBox.Show("Invalid savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    savegamePathTRX2 = fileBrowserDialog.FileName;

                    ClearControlsTR4();
                    ClearControlsTR5();
                    ClearControlsTR6();

                    cmbSavegamesTR4.Items.Clear();
                    cmbSavegamesTR5.Items.Clear();
                    cmbSavegamesTR6.Items.Clear();

                    PopulateSavegamesConditionally();

                    btnRefreshTR4.Enabled = true;
                    btnRefreshTR5.Enabled = true;
                    btnRefreshTR6.Enabled = true;

                    EnableToolStripMenuItemsConditionally();

                    tsmiCreateBackup.Enabled = true;
                    tsmiBackupBeforeSaving.Enabled = true;

                    this.Text = $"Tomb Raider I-VI Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";

                    slblStatus.Text = $"Loaded savegame file: \"{savegamePathTRX2}\"";
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
            this.Text = $"Tomb Raider I-VI Remastered Savegame Editor ({PlatformExtensions.ToFriendlyString(platform)})";

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

        private void ReadConfigFile()
        {
            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootFolder, CONFIG_FILE_NAME);

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (line.StartsWith("TRXPath="))
                    {
                        string directoryPath = line.Substring("TRXPath=".Length);
                        savegamePathTRX = directoryPath;
                    }
                    else if (line.StartsWith("TRX2Path="))
                    {
                        string directoryPath = line.Substring("TRX2Path=".Length);
                        savegamePathTRX2 = directoryPath;
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
                    else if (line.StartsWith("StatusBar"))
                    {
                        if (bool.TryParse(line.Substring("StatusBar=".Length), out bool statusBar))
                        {
                            tsmiStatusBar.Checked = statusBar;
                            ssrStatusStrip.Visible = statusBar;
                            slblStatus.Visible = statusBar;

                            if (!statusBar)
                            {
                                this.Height -= ssrStatusStrip.Height;
                            }
                        }
                    }
                    else if (line.StartsWith("ShowInventoryToggleTR6="))
                    {
                        if (bool.TryParse(line.Substring("ShowInventoryToggleTR6=".Length), out bool showToggle))
                        {
                            tsmiShowInventoryToggleTR6.Checked = showToggle;
                            tsmiShowInventoryToggleTR6_Click(null, EventArgs.Empty);
                        }
                    }
                }
            }
            else
            {
                UpdateConfigFile();
            }
        }

        private void UpdateConfigFile()
        {
            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootFolder, CONFIG_FILE_NAME);

            string content = $"TRXPath={savegamePathTRX}\n";
            content += $"TRX2Path={savegamePathTRX2}\n";
            content += $"AutoBackup={tsmiBackupBeforeSaving.Checked}\n";
            content += $"StatusBar={tsmiStatusBar.Checked}\n";
            content += $"ShowInventoryToggleTR6={tsmiShowInventoryToggleTR6.Checked}\n";

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

        public bool IsTRXTabSelected()
        {
            return (tabGame.SelectedIndex == TAB_TR1 || tabGame.SelectedIndex == TAB_TR2 || tabGame.SelectedIndex == TAB_TR3);
        }

        public bool IsTRX2TabSelected()
        {
            return (tabGame.SelectedIndex == TAB_TR4 || tabGame.SelectedIndex == TAB_TR5 || tabGame.SelectedIndex == TAB_TR6);
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

        private void btnExitTR4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExitTR5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExitTR6_Click(object sender, EventArgs e)
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
            else if (tabGame.SelectedIndex == TAB_TR4 && cmbSavegamesTR4.SelectedIndex != -1 && btnSaveTR4.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR4(cmbSavegamesTR4.SelectedItem as Savegame);
                }

                DisableButtonsTR4();
            }
            else if (tabGame.SelectedIndex == TAB_TR5 && cmbSavegamesTR5.SelectedIndex != -1 && btnSaveTR5.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR5(cmbSavegamesTR5.SelectedItem as Savegame);
                }

                DisableButtonsTR5();
            }
            else if (tabGame.SelectedIndex == TAB_TR6 && cmbSavegamesTR6.SelectedIndex != -1 && btnSaveTR6.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR6(cmbSavegamesTR6.SelectedItem as Savegame);
                }

                DisableButtonsTR6();
            }
        }

        private void cmbSavegamesTR1_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR1.SelectedIndexChanged -= cmbSavegamesTR1_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
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

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
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

            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
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

        private void cmbSavegamesTR4_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR4.SelectedIndexChanged -= cmbSavegamesTR4_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                for (int i = 0; i < cmbSavegamesTR4.Items.Count; i++)
                {
                    if (cmbSavegamesTR4.Items[i] is Savegame savegame)
                    {
                        TR4.UpdateDisplayName(savegame);

                        cmbSavegamesTR4.Items[i] = savegame;
                    }
                }

                TR4.PopulateEmptySlots(cmbSavegamesTR4);
            }

            cmbSavegamesTR4.SelectedIndexChanged += cmbSavegamesTR4_SelectedIndexChanged;
        }

        private void cmbSavegamesTR5_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR5.SelectedIndexChanged -= cmbSavegamesTR5_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                for (int i = 0; i < cmbSavegamesTR5.Items.Count; i++)
                {
                    if (cmbSavegamesTR5.Items[i] is Savegame savegame)
                    {
                        TR5.UpdateDisplayName(savegame);

                        cmbSavegamesTR5.Items[i] = savegame;
                    }
                }

                TR5.PopulateEmptySlots(cmbSavegamesTR5);
            }

            cmbSavegamesTR5.SelectedIndexChanged += cmbSavegamesTR5_SelectedIndexChanged;
        }

        private void cmbSavegamesTR6_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR6.SelectedIndexChanged -= cmbSavegamesTR6_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                for (int i = 0; i < cmbSavegamesTR6.Items.Count; i++)
                {
                    if (cmbSavegamesTR6.Items[i] is Savegame savegame)
                    {
                        TR6.UpdateDisplayName(savegame);

                        cmbSavegamesTR6.Items[i] = savegame;
                    }
                }

                TR6.PopulateEmptySlots(cmbSavegamesTR6);
            }

            cmbSavegamesTR6.SelectedIndexChanged += cmbSavegamesTR6_SelectedIndexChanged;
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

        private void cmbSavegamesTR4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegameTR4 != null && btnSaveTR4.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR4(previousSelectedSavegameTR4);
                }
            }

            previousSelectedSavegameTR4 = cmbSavegamesTR4.SelectedItem as Savegame;

            DisplayGameInfoTR4(cmbSavegamesTR4.SelectedItem as Savegame);
            DisableButtonsTR4();
            EnableToolStripMenuItemsConditionally();
        }

        private void cmbSavegamesTR5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegameTR5 != null && btnSaveTR5.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR5(previousSelectedSavegameTR5);
                }
            }

            previousSelectedSavegameTR5 = cmbSavegamesTR5.SelectedItem as Savegame;

            DisplayGameInfoTR5(cmbSavegamesTR5.SelectedItem as Savegame);
            DisableButtonsTR5();
            EnableToolStripMenuItemsConditionally();
        }

        private void cmbSavegamesTR6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegameTR6 != null && btnSaveTR6.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR6(previousSelectedSavegameTR6);
                }
            }

            previousSelectedSavegameTR6 = cmbSavegamesTR6.SelectedItem as Savegame;

            DisplayGameInfoTR6(cmbSavegamesTR6.SelectedItem as Savegame);
            DisableButtonsTR6();
            EnableToolStripMenuItemsConditionally();
        }

        private void cmbInventoryTR6_SelectedIndexChanged(object sender, EventArgs e)
        {
            isInventoryLoading = true;

            if (cmbSavegamesTR6.SelectedIndex != -1 && !isLoading)
            {
                try
                {
                    TR6.UpdateInventoryUI(cmbInventoryTR6, nudChocolateBarTR6, nudHealthPillsTR6, chkMV9TR6, chkVPackerTR6, nudMV9AmmoTR6,
                        nudVPackerAmmoTR6, chkBoranXTR6, nudBoranXAmmoTR6, nudSmallMedipackTR6, nudHealthBandagesTR6, chkK2ImpactorTR6,
                        nudK2ImpactorAmmoTR6, nudLargeHealthPackTR6, chkScorpionXTR6, nudScorpionXAmmoTR6, chkVectorR35TR6, nudVectorR35AmmoTR6,
                        chkDesertRangerTR6, nudDesertRangerAmmoTR6, chkDartSSTR6, nudDartSSAmmoTR6, chkRigg09TR6, nudRigg09AmmoTR6,
                        chkViperSMGTR6, nudViperSMGAmmoTR6, chkMagVegaTR6, nudMagVegaAmmoTR6, chkVectorR35PairTR6, lblVectorR35PairAmmoTR6, chkScorpionXPairTR6, lblScorpionXPairAmmoTR6,
                        nudPoisonAntidoteTR6, chkChirugaiBladeTR6, lblChirugaiBladeAmmoTR6, nudGPSSaveGame, lblGPSSaveGame);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            isInventoryLoading = false;
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

        private void btnCancelTR4_Click(object sender, EventArgs e)
        {
            DisplayGameInfoTR4(cmbSavegamesTR4.SelectedItem as Savegame);
            DisableButtonsTR4();
        }

        private void btnCancelTR5_Click(object sender, EventArgs e)
        {
            DisplayGameInfoTR5(cmbSavegamesTR5.SelectedItem as Savegame);
            DisableButtonsTR5();
        }

        private void btnCancelTR6_Click(object sender, EventArgs e)
        {
            DisplayGameInfoTR6(cmbSavegamesTR6.SelectedItem as Savegame);
            DisableButtonsTR6();
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

        private void trbHealthTR4_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = ((double)trbHealthTR4.Value / (double)MAX_HEALTH_VALUE) * 100;
            lblHealthTR4.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void trbHealthTR5_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = ((double)trbHealthTR5.Value / (double)MAX_HEALTH_VALUE) * 100;
            lblHealthTR5.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void trbHealthTR6_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = (double)trbHealthTR6.Value;
            lblHealthTR6.Text = $"{healthPercentage}%";

            if (!isLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
            }
        }

        private void CreateBackup()
        {
            string savegamePath = "";

            if (IsTRXTabSelected())
            {
                savegamePath = savegamePathTRX;
            }
            else if (IsTRX2TabSelected())
            {
                savegamePath = savegamePathTRX2;
            }

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
                    TR1.SetSavegamePath(savegamePathTRX);
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

                    File.SetAttributes(savegamePathTRX, File.GetAttributes(savegamePathTRX) & ~FileAttributes.ReadOnly);

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
                    TR2.SetSavegamePath(savegamePathTRX);
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

                    File.SetAttributes(savegamePathTRX, File.GetAttributes(savegamePathTRX) & ~FileAttributes.ReadOnly);

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
                    TR3.SetSavegamePath(savegamePathTRX);
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

                    File.SetAttributes(savegamePathTRX, File.GetAttributes(savegamePathTRX) & ~FileAttributes.ReadOnly);

                    TR3.WriteChanges(chkPistolsTR3, chkDeagleTR3, chkUzisTR3, chkShotgunTR3, chkMP5TR3, chkRocketLauncherTR3,
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

        private void WriteChangesTR4(Savegame savegame)
        {
            if (savegame != null)
            {
                try
                {
                    TR4.SetSavegamePath(savegamePathTRX2);
                    TR4.SetSavegameOffset(savegame.Offset);

                    if (!TR4.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR4();
                        PopulateSavegamesTR4();
                        return;
                    }

                    if (tsmiBackupBeforeSaving.Checked)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePathTRX2, File.GetAttributes(savegamePathTRX2) & ~FileAttributes.ReadOnly);

                    TR4.WriteChanges(nudSaveNumberTR4, nudGoldenSkullsTR4, nudSmallMedipacksTR4, nudLargeMedipacksTR4,
                        nudFlaresTR4, chkPistolsTR4, chkUziTR4, chkRevolverTR4, chkShotgunTR4, chkGrenadeGunTR4,
                        chkCrossbowTR4, nudUziAmmoTR4, nudRevolverAmmoTR4, nudShotgunNormalAmmoTR4, nudShotgunWideshotAmmoTR4,
                        nudGrenadeGunNormalAmmoTR4, nudGrenadeGunSuperAmmoTR4, nudGrenadeGunFlashAmmoTR4, nudCrossbowNormalAmmoTR4,
                        nudCrossbowPoisonAmmoTR4, nudCrossbowExplosiveAmmoTR4, trbHealthTR4);

                    TR4.UpdateDisplayName(savegame);
                    UpdateSavegameDisplayNameTR4(cmbSavegamesTR4, savegame);

                    DisableButtonsTR4();

                    slblStatus.Text = $"Successfully patched savegame: '{savegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error writing to savegame.";
                }
            }
        }

        private void WriteChangesTR5(Savegame savegame)
        {
            if (savegame != null)
            {
                try
                {
                    TR5.SetSavegamePath(savegamePathTRX2);
                    TR5.SetSavegameOffset(savegame.Offset);

                    if (!TR5.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR5();
                        PopulateSavegamesTR5();
                        return;
                    }

                    if (tsmiBackupBeforeSaving.Checked)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePathTRX2, File.GetAttributes(savegamePathTRX2) & ~FileAttributes.ReadOnly);

                    TR5.WriteChanges(nudSaveNumberTR5, nudSmallMedipacksTR5, nudLargeMedipacksTR5, nudFlaresTR5, nudSecretsTR5,
                        chkPistolsTR5, chkRevolverTR5, chkDeagleTR5, chkUziTR5, chkHKGunTR5, chkGrapplingGunTR5, chkShotgunTR5,
                        nudRevolverAmmoTR5, nudDeagleAmmoTR5, nudUziAmmoTR5, nudHKGunAmmoTR5, nudGrapplingGunAmmoTR5,
                        nudShotgunNormalAmmoTR5, nudShotgunWideshotAmmoTR5, trbHealthTR5);

                    TR5.UpdateDisplayName(savegame);
                    UpdateSavegameDisplayNameTR5(cmbSavegamesTR5, savegame);

                    DisableButtonsTR5();

                    slblStatus.Text = $"Successfully patched savegame: '{savegame}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    slblStatus.Text = $"Error writing to savegame.";
                }
            }
        }

        private void WriteChangesTR6(Savegame savegame)
        {
            if (savegame != null)
            {
                try
                {
                    TR6.SetSavegamePath(savegamePathTRX2);
                    TR6.SetSavegameOffset(savegame.Offset);

                    if (!TR6.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR6();
                        PopulateSavegamesTR6();
                        return;
                    }

                    if (tsmiBackupBeforeSaving.Checked)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePathTRX2, File.GetAttributes(savegamePathTRX2) & ~FileAttributes.ReadOnly);

                    TR6.WriteChanges(nudCashTR6, trbHealthTR6, nudSaveNumberTR6);

                    TR6.UpdateDisplayName(savegame);
                    UpdateSavegameDisplayNameTR6(cmbSavegamesTR6, savegame);

                    DisableButtonsTR6();

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

        private void btnSaveTR4_Click(object sender, EventArgs e)
        {
            WriteChangesTR4(cmbSavegamesTR4.SelectedItem as Savegame);
        }

        private void btnSaveTR5_Click(object sender, EventArgs e)
        {
            WriteChangesTR5(cmbSavegamesTR5.SelectedItem as Savegame);
        }

        private void btnSaveTR6_Click(object sender, EventArgs e)
        {
            WriteChangesTR6(cmbSavegamesTR6.SelectedItem as Savegame);
        }

        private void btnRefreshTR1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                cmbSavegamesTR1.Items.Clear();
                TR1.PopulateSavegames(cmbSavegamesTR1);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX)) ?
                    $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                cmbSavegamesTR2.Items.Clear();
                TR2.PopulateSavegames(cmbSavegamesTR2);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX)) ?
                    $"{cmbSavegamesTR2.Items.Count} savegames found for Tomb Raider II" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                cmbSavegamesTR3.Items.Clear();
                TR3.PopulateSavegames(cmbSavegamesTR3);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX)) ?
                    $"{cmbSavegamesTR3.Items.Count} savegames found for Tomb Raider III" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                cmbSavegamesTR4.Items.Clear();
                TR4.PopulateSavegames(cmbSavegamesTR4);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2)) ?
                    $"{cmbSavegamesTR4.Items.Count} savegames found for Tomb Raider IV" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                cmbSavegamesTR5.Items.Clear();
                TR5.PopulateSavegames(cmbSavegamesTR5);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2)) ?
                    $"{cmbSavegamesTR5.Items.Count} savegames found for Tomb Raider V" : "Ready";
            }
            else
            {
                MessageBox.Show("Could not find savegame file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                cmbSavegamesTR6.Items.Clear();
                TR6.PopulateSavegames(cmbSavegamesTR6);

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2)) ?
                    $"{cmbSavegamesTR6.Items.Count} savegames found for Tomb Raider VI" : "Ready";
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

        private void UpdateSavegameDisplayNameTR4(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR4_SelectedIndexChanged;

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

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR4_SelectedIndexChanged;
        }

        private void UpdateSavegameDisplayNameTR5(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR5_SelectedIndexChanged;

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

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR5_SelectedIndexChanged;
        }

        private void UpdateSavegameDisplayNameTR6(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR6_SelectedIndexChanged;

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

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR6_SelectedIndexChanged;
        }

        private void UpdateInventoryFromUI()
        {
            if (!isInventoryLoading)
            {
                try
                {
                    TR6.UpdateInventoryFromUI(cmbInventoryTR6, nudChocolateBarTR6, nudHealthPillsTR6, chkMV9TR6, chkVPackerTR6, nudMV9AmmoTR6,
                        nudVPackerAmmoTR6, chkBoranXTR6, nudBoranXAmmoTR6, nudSmallMedipackTR6, nudHealthBandagesTR6, chkK2ImpactorTR6,
                        nudK2ImpactorAmmoTR6, nudLargeHealthPackTR6, chkScorpionXTR6, nudScorpionXAmmoTR6, chkVectorR35TR6, nudVectorR35AmmoTR6,
                        chkDesertRangerTR6, nudDesertRangerAmmoTR6, chkDartSSTR6, nudDartSSAmmoTR6, chkRigg09TR6, nudRigg09AmmoTR6,
                        chkViperSMGTR6, nudViperSMGAmmoTR6, chkMagVegaTR6, nudMagVegaAmmoTR6, chkVectorR35PairTR6, chkScorpionXPairTR6,
                        nudPoisonAntidoteTR6, chkChirugaiBladeTR6, nudGPSSaveGame);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayGameInfoTR1(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR1.SetSavegamePath(savegamePathTRX);
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
                    TR2.SetSavegamePath(savegamePathTRX);
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
                        nudM16AmmoTR2, nudGrenadeLauncherAmmoTR2, nudHarpoonGunAmmoTR2, lblPistolAmmoTR2);

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
                    TR3.SetSavegamePath(savegamePathTRX);
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

                    TR3.DisplayGameInfo(chkPistolsTR3, chkShotgunTR3, chkDeagleTR3, chkUzisTR3, chkMP5TR3,
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

        private void DisplayGameInfoTR4(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR4.SetSavegamePath(savegamePathTRX2);
                    TR4.SetSavegameOffset(selectedSavegame.Offset);

                    if (!TR4.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR4();
                        PopulateSavegamesTR4();
                        return;
                    }

                    TR4.UpdateDisplayName(selectedSavegame);
                    UpdateSavegameDisplayNameTR4(cmbSavegamesTR4, selectedSavegame);

                    TR4.DetermineOffsets();
                    TR4.DisplayGameInfo(nudSaveNumberTR4, nudSmallMedipacksTR4, nudLargeMedipacksTR4,
                        nudFlaresTR4, nudGoldenSkullsTR4, lblGoldenSkullsTR4, chkPistolsTR4, chkShotgunTR4, chkUziTR4, chkRevolverTR4,
                        chkGrenadeGunTR4, chkCrossbowTR4, trbHealthTR4, lblHealthTR4, lblHealthErrorTR4,
                        nudShotgunNormalAmmoTR4, nudShotgunWideshotAmmoTR4, nudUziAmmoTR4, nudRevolverAmmoTR4,
                        nudCrossbowNormalAmmoTR4, nudGrenadeGunFlashAmmoTR4, nudGrenadeGunNormalAmmoTR4,
                        nudGrenadeGunSuperAmmoTR4, nudCrossbowPoisonAmmoTR4, nudCrossbowExplosiveAmmoTR4);

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

        private void DisplayGameInfoTR5(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR5.SetSavegamePath(savegamePathTRX2);
                    TR5.SetSavegameOffset(selectedSavegame.Offset);

                    if (!TR5.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR5();
                        PopulateSavegamesTR5();
                        return;
                    }

                    TR5.UpdateDisplayName(selectedSavegame);
                    UpdateSavegameDisplayNameTR5(cmbSavegamesTR5, selectedSavegame);

                    TR5.DetermineOffsets();
                    TR5.SetLevelParams(chkRevolverTR5, chkDeagleTR5, nudRevolverAmmoTR5, nudDeagleAmmoTR5, chkUziTR5, nudUziAmmoTR5, chkShotgunTR5,
                        nudShotgunNormalAmmoTR5, nudShotgunWideshotAmmoTR5, chkGrapplingGunTR5, nudGrapplingGunAmmoTR5, chkHKGunTR5, nudHKGunAmmoTR5,
                        chkPistolsTR5, nudFlaresTR5, lblPistolAmmoTR5);

                    TR5.DisplayGameInfo(nudSaveNumberTR5, nudSmallMedipacksTR5, nudLargeMedipacksTR5, nudFlaresTR5, nudSecretsTR5,
                        chkPistolsTR5, chkRevolverTR5, chkDeagleTR5, chkUziTR5, chkHKGunTR5, chkGrapplingGunTR5, chkShotgunTR5,
                        nudRevolverAmmoTR5, nudDeagleAmmoTR5, nudUziAmmoTR5, nudHKGunAmmoTR5, nudGrapplingGunAmmoTR5,
                        nudShotgunNormalAmmoTR5, nudShotgunWideshotAmmoTR5, trbHealthTR5, lblHealthTR5, lblHealthErrorTR5);

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

        private void DisplayGameInfoTR6(Savegame selectedSavegame)
        {
            if (selectedSavegame != null)
            {
                isLoading = true;

                try
                {
                    TR6.SetSavegamePath(savegamePathTRX2);
                    TR6.SetSavegameOffset(selectedSavegame.Offset);

                    if (!TR6.IsSavegamePresent())
                    {
                        string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        DisableButtonsTR6();
                        PopulateSavegamesTR6();
                        return;
                    }

                    TR6.UpdateDisplayName(selectedSavegame);
                    UpdateSavegameDisplayNameTR6(cmbSavegamesTR6, selectedSavegame);

                    TR6.DetermineOffsets(selectedSavegame);
                    TR6.DisplayGameInfo(trbHealthTR6, lblHealthTR6, lblHealthErrorTR6, nudCashTR6, nudSaveNumberTR6);

                    // Default to inventory of active player
                    cmbInventoryTR6.SelectedIndex = TR6.IsPlayerKurtis() ? 1 : 0;

                    TR6.UpdateInventoryUI(cmbInventoryTR6, nudChocolateBarTR6, nudHealthPillsTR6, chkMV9TR6, chkVPackerTR6, nudMV9AmmoTR6,
                        nudVPackerAmmoTR6, chkBoranXTR6, nudBoranXAmmoTR6, nudSmallMedipackTR6, nudHealthBandagesTR6, chkK2ImpactorTR6,
                        nudK2ImpactorAmmoTR6, nudLargeHealthPackTR6, chkScorpionXTR6, nudScorpionXAmmoTR6, chkVectorR35TR6, nudVectorR35AmmoTR6,
                        chkDesertRangerTR6, nudDesertRangerAmmoTR6, chkDartSSTR6, nudDartSSAmmoTR6, chkRigg09TR6, nudRigg09AmmoTR6,
                        chkViperSMGTR6, nudViperSMGAmmoTR6, chkMagVegaTR6, nudMagVegaAmmoTR6, chkVectorR35PairTR6, lblVectorR35PairAmmoTR6, chkScorpionXPairTR6, lblScorpionXPairAmmoTR6,
                        nudPoisonAntidoteTR6, chkChirugaiBladeTR6, lblChirugaiBladeAmmoTR6, nudGPSSaveGame, lblGPSSaveGame);

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
                btnRefreshTR1.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);

                if (cmbSavegamesTR1.Items.Count == 0)
                {
                    PopulateSavegamesTR1();
                }
                else
                {
                    DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX)) ?
                    $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                btnRefreshTR2.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);

                if (cmbSavegamesTR2.Items.Count == 0)
                {
                    PopulateSavegamesTR2();
                }
                else
                {
                    DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX)) ?
                    $"{cmbSavegamesTR2.Items.Count} savegames found for Tomb Raider II" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                btnRefreshTR3.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);

                if (cmbSavegamesTR3.Items.Count == 0)
                {
                    PopulateSavegamesTR3();
                }
                else
                {
                    DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX)) ?
                    $"{cmbSavegamesTR3.Items.Count} savegames found for Tomb Raider III" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                if (string.IsNullOrEmpty(savegamePathTRX2) && !hasShownTRX2PathPrompt)
                {
                    PromptBrowseSavegamePathTRX2();
                    return;
                }

                btnRefreshTR4.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);

                if (cmbSavegamesTR4.Items.Count == 0)
                {
                    PopulateSavegamesTR4();
                }
                else
                {
                    DisplayGameInfoTR4(cmbSavegamesTR4.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2)) ?
                    $"{cmbSavegamesTR4.Items.Count} savegames found for Tomb Raider IV" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                if (string.IsNullOrEmpty(savegamePathTRX2) && !hasShownTRX2PathPrompt)
                {
                    PromptBrowseSavegamePathTRX2();
                    return;
                }

                btnRefreshTR5.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);

                if (cmbSavegamesTR5.Items.Count == 0)
                {
                    PopulateSavegamesTR5();
                }
                else
                {
                    DisplayGameInfoTR5(cmbSavegamesTR5.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2)) ?
                    $"{cmbSavegamesTR5.Items.Count} savegames found for Tomb Raider V" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                if (string.IsNullOrEmpty(savegamePathTRX2) && !hasShownTRX2PathPrompt)
                {
                    PromptBrowseSavegamePathTRX2();
                    return;
                }

                btnRefreshTR6.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);

                if (cmbSavegamesTR6.Items.Count == 0)
                {
                    PopulateSavegamesTR6();
                }
                else
                {
                    DisplayGameInfoTR6(cmbSavegamesTR6.SelectedItem as Savegame);
                }

                slblStatus.Text = (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2)) ?
                    $"{cmbSavegamesTR6.Items.Count} savegames found for Tomb Raider VI" : "Ready";
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

        private void tsmiReportBug_Click(object sender, EventArgs e)
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
            string savegamePath = "";

            if (IsTRXTabSelected())
            {
                savegamePath = savegamePathTRX;
            }
            else if (IsTRX2TabSelected())
            {
                savegamePath = savegamePathTRX2;
            }

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
            else if (tabGame.SelectedIndex == TAB_TR4 && cmbSavegamesTR4.SelectedIndex != -1)
            {
                selectedSavegame = cmbSavegamesTR4.Items[cmbSavegamesTR4.SelectedIndex] as Savegame;
                savegamePresent = TR4.IsSavegamePresent();
            }
            else if (tabGame.SelectedIndex == TAB_TR5 && cmbSavegamesTR5.SelectedIndex != -1)
            {
                selectedSavegame = cmbSavegamesTR5.Items[cmbSavegamesTR5.SelectedIndex] as Savegame;
                savegamePresent = TR5.IsSavegamePresent();
            }
            else if (tabGame.SelectedIndex == TAB_TR6 && cmbSavegamesTR6.SelectedIndex != -1)
            {
                selectedSavegame = cmbSavegamesTR6.Items[cmbSavegamesTR6.SelectedIndex] as Savegame;
                savegamePresent = TR6.IsSavegamePresent();
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
            if (!File.Exists(savegamePathTRX) && IsTRXTabSelected())
            {
                string errorMessage = $"Could not find savegame file.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else if (!File.Exists(savegamePathTRX2) && IsTRX2TabSelected())
            {
                string errorMessage = $"Could not find savegame file.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string savegamePath = "";

            if (IsTRXTabSelected())
            {
                savegamePath = savegamePathTRX;
            }
            else if (IsTRX2TabSelected())
            {
                savegamePath = savegamePathTRX2;
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
                    string warningMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(warningMessage, "Position Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string warningMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(warningMessage, "Position Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TR2.IsLaraInVehicle(healthOffset))
                {
                    string warningMessage = $"Cannot edit position while Lara is in a vehicle.";
                    MessageBox.Show(warningMessage, "Cannot Edit Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string warningMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(warningMessage, "Position Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TR3.IsLaraInVehicle(healthOffset))
                {
                    string warningMessage = $"Cannot edit position while Lara is in a vehicle.";
                    MessageBox.Show(warningMessage, "Cannot Edit Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedSavegame = cmbSavegamesTR3.Items[cmbSavegamesTR3.SelectedIndex] as Savegame;
                positionForm.SetHealthOffset(healthOffset - selectedSavegame.Offset);
            }
            else if (tabGame.SelectedIndex == TAB_TR4 && cmbSavegamesTR4.SelectedIndex != -1)
            {
                if (!TR4.IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtonsTR4();
                    PopulateSavegamesTR4();
                    return;
                }

                int healthOffset = TR4.GetHealthOffset();

                if (healthOffset == -1)
                {
                    string warningMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(warningMessage, "Position Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TR4.IsLaraInVehicle(healthOffset))
                {
                    string warningMessage = $"Cannot edit position while Lara is in a vehicle.";
                    MessageBox.Show(warningMessage, "Cannot Edit Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedSavegame = cmbSavegamesTR4.Items[cmbSavegamesTR4.SelectedIndex] as Savegame;
                positionForm.SetHealthOffset(healthOffset - selectedSavegame.Offset);
            }
            else if (tabGame.SelectedIndex == TAB_TR5 && cmbSavegamesTR5.SelectedIndex != -1)
            {
                if (!TR5.IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtonsTR5();
                    PopulateSavegamesTR5();
                    return;
                }

                int healthOffset = TR5.GetHealthOffset();

                if (healthOffset == -1)
                {
                    string warningMessage = $"Unable to find coordinates. Try saving the game while Lara is standing.";
                    MessageBox.Show(warningMessage, "Position Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedSavegame = cmbSavegamesTR5.Items[cmbSavegamesTR5.SelectedIndex] as Savegame;
                positionForm.SetHealthOffset(healthOffset - selectedSavegame.Offset);
            }
            else if (tabGame.SelectedIndex == TAB_TR6 && cmbSavegamesTR6.SelectedIndex != -1)
            {
                if (!TR6.IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present. Press OK to refresh savegames.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtonsTR6();
                    PopulateSavegamesTR6();
                    return;
                }

                selectedSavegame = cmbSavegamesTR6.Items[cmbSavegamesTR6.SelectedIndex] as Savegame;
                int PLAYER_BASE_OFFSET = TR6.GetPlayerBaseOffset();
                positionForm.SetPlayerBaseOffset(PLAYER_BASE_OFFSET);
            }

            if (selectedSavegame != null)
            {
                positionForm.SetSavegame(selectedSavegame);
                positionForm.TopMost = TopMost;
                positionForm.ShowDialog();
            }
        }

        private void tsmiBrowseTRXSavegamePath_Click(object sender, EventArgs e)
        {
            BrowseSavegamePathTRX();
        }

        private void tsmiBrowseTRX2SavegamePath_Click(object sender, EventArgs e)
        {
            BrowseSavegamePathTRX2();
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
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                EnableAllWeapons(grpWeaponsTR4);
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                EnableAllWeapons(grpWeaponsTR5);
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                EnableAllWeapons(grpWeaponsTR6);
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
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                SetMaximumAmmunition(grpWeaponsTR4);
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                SetMaximumAmmunition(grpWeaponsTR5);
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                SetMaximumAmmunition(grpWeaponsTR6);
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
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                SetMaximumItems(grpItemsTR4);
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                SetMaximumItems(grpItemsTR5);
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                SetMaximumItems(grpItemsTR6);
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
            else if (tabGame.SelectedIndex == TAB_TR4 && trbHealthTR4.Enabled)
            {
                trbHealthTR4.Value = trbHealthTR4.Maximum;
                lblHealthTR4.Text = "100.0%";
            }
            else if (tabGame.SelectedIndex == TAB_TR5 && trbHealthTR5.Enabled)
            {
                trbHealthTR5.Value = trbHealthTR5.Maximum;
                lblHealthTR5.Text = "100.0%";
            }
            else if (tabGame.SelectedIndex == TAB_TR6 && trbHealthTR6.Enabled)
            {
                trbHealthTR6.Value = trbHealthTR6.Maximum;
                lblHealthTR6.Text = "100%";
            }
        }

        private void tsmiAllowUnsafeMaxValuesTR6_Click(object sender, EventArgs e)
        {
            int maxValue = tsmiAllowUnsafeMaxValuesTR6.Checked ? Int32.MaxValue : 99999;

            foreach (Control control in grpItemsTR6.Controls)
            {
                if (control is NumericUpDown nud)
                {
                    nud.Maximum = maxValue;
                }
            }

            foreach (Control control in grpWeaponsTR6.Controls)
            {
                if (control is NumericUpDown nud)
                {
                    nud.Maximum = maxValue;
                }
            }
        }

        private void tsmiShowInventoryToggleTR6_Click(object sender, EventArgs e)
        {
            lblInventoryTR6.Visible = tsmiShowInventoryToggleTR6.Checked;
            cmbInventoryTR6.Visible = tsmiShowInventoryToggleTR6.Checked;
        }

        private void tsmiDeleteSavegame_Click(object sender, EventArgs e)
        {
            Savegame savegameToDelete = null;

            if (tabGame.SelectedIndex == TAB_TR1)
            {
                savegameToDelete = cmbSavegamesTR1.SelectedItem as Savegame;
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                savegameToDelete = cmbSavegamesTR2.SelectedItem as Savegame;
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                savegameToDelete = cmbSavegamesTR3.SelectedItem as Savegame;
            }
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                savegameToDelete = cmbSavegamesTR4.SelectedItem as Savegame;
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                savegameToDelete = cmbSavegamesTR5.SelectedItem as Savegame;
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                savegameToDelete = cmbSavegamesTR6.SelectedItem as Savegame;
            }

            if (savegameToDelete != null)
            {
                System.Media.SystemSounds.Asterisk.Play();

                DialogResult result = MessageBox.Show($"Are you sure you wish to delete '{savegameToDelete}'?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteSavegame(savegameToDelete);
                    PopulateSavegamesConditionally();
                }
            }
        }

        private void DeleteSavegame(Savegame savegame)
        {
            string deletedSavegameString = savegame.ToString();

            int SAVEGAME_SIZE = 0;
            string savegamePath;

            if (IsTRXTabSelected())
            {
                SAVEGAME_SIZE = SAVEGAME_SIZE_TRX;
                savegamePath = savegamePathTRX;

            }
            else
            {
                SAVEGAME_SIZE = SAVEGAME_SIZE_TRX2;
                savegamePath = savegamePathTRX2;
            }

            try
            {
                if (tsmiBackupBeforeSaving.Checked)
                {
                    CreateBackup();
                }

                File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                using (FileStream saveFile = new FileStream(savegamePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    for (int offset = savegame.Offset; offset < (savegame.Offset + SAVEGAME_SIZE); offset++)
                    {
                        saveFile.Seek(offset, SeekOrigin.Begin);
                        saveFile.WriteByte(0);
                    }
                }

                slblStatus.Text = $"Successfully deleted savegame: '{deletedSavegameString}'";
            }
            catch (Exception ex)
            {
                slblStatus.Text = $"Error deleting savegame.";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                tsmiDeleteSavegame.Enabled = cmbSavegamesTR1.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
                tsmiDeleteSavegame.Enabled = cmbSavegamesTR2.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
                tsmiDeleteSavegame.Enabled = cmbSavegamesTR3.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR4)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
                tsmiDeleteSavegame.Enabled = cmbSavegamesTR4.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR5)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
                tsmiDeleteSavegame.Enabled = cmbSavegamesTR5.SelectedIndex != -1;
            }
            else if (tabGame.SelectedIndex == TAB_TR6)
            {
                tsmiEnableAllWeapons.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
                tsmiSetMaximumAmmunition.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
                tsmiSetMaximumItems.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
                tsmiStatistics.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
                tsmiPosition.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
                tsmiMaxEverything.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
                tsmiDeleteSavegame.Enabled = cmbSavegamesTR6.SelectedIndex != -1;
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

        private void EnableButtonsTR4()
        {
            btnCancelTR4.Enabled = true;
            btnSaveTR4.Enabled = true;
        }

        private void EnableButtonsTR5()
        {
            btnCancelTR5.Enabled = true;
            btnSaveTR5.Enabled = true;
        }

        private void EnableButtonsTR6()
        {
            btnCancelTR6.Enabled = true;
            btnSaveTR6.Enabled = true;
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

        private void DisableButtonsTR4()
        {
            btnCancelTR4.Enabled = false;
            btnSaveTR4.Enabled = false;
        }

        private void DisableButtonsTR5()
        {
            btnCancelTR5.Enabled = false;
            btnSaveTR5.Enabled = false;
        }

        private void DisableButtonsTR6()
        {
            btnCancelTR6.Enabled = false;
            btnSaveTR6.Enabled = false;
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

        private void chkUzisTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
            }
        }

        private void nudSaveNumberTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudSmallMedipacksTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudLargeMedipacksTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudFlaresTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGoldenSkullsTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudUziAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudRevolverAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudShotgunNormalAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudShotgunWideshotAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGrenadeGunNormalAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGrenadeGunSuperAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGrenadeGunFlashAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudCrossbowNormalAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudCrossbowPoisonAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudCrossbowExplosiveAmmoTR4_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudSaveNumberTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudSmallMedipacksTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudLargeMedipacksTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudFlaresTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGoldenSkullsTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudUziAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudRevolverAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudShotgunNormalAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudShotgunWideshotAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGrenadeGunNormalAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGrenadeGunSuperAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudGrenadeGunFlashAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudCrossbowNormalAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudCrossbowPoisonAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudCrossbowExplosiveAmmoTR4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void chkPistolsTR4_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void chkUziTR4_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void chkRevolverTR4_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void chkShotgunTR4_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void chkGrenadeGunTR4_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void chkCrossbowTR4_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR4.SelectedIndex != -1)
            {
                EnableButtonsTR4();
            }
        }

        private void nudSaveNumberTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudSmallMedipacksTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudLargeMedipacksTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudFlaresTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudSecretsTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudRevolverAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudDeagleAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudUziAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudHKGunAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudGrapplingGunAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudShotgunNormalAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudShotgunWideshotAmmoTR5_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudSaveNumberTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudSmallMedipacksTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudLargeMedipacksTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudFlaresTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudSecretsTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudRevolverAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudDeagleAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudUziAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudHKGunAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudGrapplingGunAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudShotgunNormalAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void nudShotgunWideshotAmmoTR5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkPistolsTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkRevolverTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkDeagleTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkUziTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkHKGunTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkGrapplingGunTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkShotgunTR5_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR5.SelectedIndex != -1)
            {
                EnableButtonsTR5();
            }
        }

        private void chkMV9TR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkVPackerTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkScorpionXTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkScorpionXPairTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkK2ImpactorTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkVectorR35TR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkVectorR35PairTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkDesertRangerTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkMagVegaTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkDartSSTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkRigg09TR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkViperSMGTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkChirugaiBladeTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void chkBoranXTR6_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudCashTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
            }
        }

        private void nudSaveNumberTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
            }
        }

        private void nudLargeHealthPackTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudSmallMedipackTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudHealthBandagesTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudHealthPillsTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudChocolateBarTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudPoisonAntidoteTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudMV9AmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudVPackerAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudScorpionXAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudK2ImpactorAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudVectorR35AmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudDesertRangerAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudMagVegaAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudDartSSAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudRigg09AmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudViperSMGAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudBoranXAmmoTR6_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudGPSSaveGame_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudCashTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
            }
        }

        private void nudSaveNumberTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
            }
        }

        private void nudLargeHealthPackTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudSmallMedipackTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudHealthBandagesTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudHealthPillsTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudChocolateBarTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudPoisonAntidoteTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudMV9AmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudVPackerAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudScorpionXAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudK2ImpactorAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudVectorR35AmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudDesertRangerAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudMagVegaAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudDartSSAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudRigg09AmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudViperSMGAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudBoranXAmmoTR6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }

        private void nudGPSSaveGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !isInventoryLoading && cmbSavegamesTR6.SelectedIndex != -1)
            {
                EnableButtonsTR6();
                UpdateInventoryFromUI();
            }
        }
    }
}