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
        private Savegame previousSelectedSavegame;
        private string savegamePath;
        private bool isLoading = false;
        private bool userIndexChanged = true;

        // Utils
        readonly TR1Utilities TR1 = new TR1Utilities();
        readonly TR2Utilities TR2 = new TR2Utilities();
        readonly TR3Utilities TR3 = new TR3Utilities();

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetSavegamePath();
            PopulateSavegamesTR1();

            btnRefreshTR1.Enabled = !string.IsNullOrEmpty(savegamePath);
            tsmiCreateBackup.Enabled = !string.IsNullOrEmpty(savegamePath);

            slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
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
                    savegamePath = fileBrowserDialog.FileName;

                    if (tabGame.SelectedIndex == TAB_TR1)
                    {
                        PopulateSavegamesTR1();
                    }
                    else if (tabGame.SelectedIndex == TAB_TR2)
                    {
                        PopulateSavegamesTR2();
                    }
                    else if (tabGame.SelectedIndex == TAB_TR3)
                    {
                        PopulateSavegamesTR3();
                    }

                    btnRefreshTR1.Enabled = true;
                    btnRefreshTR2.Enabled = true;
                    btnRefreshTR3.Enabled = true;

                    tsmiCreateBackup.Enabled = true;

                    slblStatus.Text = $"Loaded savegame file: \"{savegamePath}\"";
                }
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
                        return;
                    }
                }
            }
            else
            {
                File.WriteAllText(filePath, $"Path={savegamePath}");
            }
        }

        private void SaveSavegamePath()
        {
            string rootFolder = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootFolder, "path.ini");

            File.WriteAllText(filePath, $"Path={savegamePath}");
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

            for (int i = 0; i < cmbSavegamesTR1.Items.Count; i++)
            {
                if (cmbSavegamesTR1.Items[i] is Savegame savegame)
                {
                    TR1.UpdateDisplayName(savegame);

                    cmbSavegamesTR1.Items[i] = savegame;
                }
            }

            TR1.PopulateEmptySlots(cmbSavegamesTR1);

            cmbSavegamesTR1.SelectedIndexChanged += cmbSavegamesTR1_SelectedIndexChanged;
        }

        private void cmbSavegamesTR2_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR2.SelectedIndexChanged -= cmbSavegamesTR2_SelectedIndexChanged;

            for (int i = 0; i < cmbSavegamesTR2.Items.Count; i++)
            {
                if (cmbSavegamesTR2.Items[i] is Savegame savegame)
                {
                    TR2.UpdateDisplayName(savegame);

                    cmbSavegamesTR2.Items[i] = savegame;
                }
            }

            TR2.PopulateEmptySlots(cmbSavegamesTR2);

            cmbSavegamesTR2.SelectedIndexChanged += cmbSavegamesTR2_SelectedIndexChanged;
        }

        private void cmbSavegamesTR3_MouseDown(object sender, MouseEventArgs e)
        {
            cmbSavegamesTR3.SelectedIndexChanged -= cmbSavegamesTR3_SelectedIndexChanged;

            for (int i = 0; i < cmbSavegamesTR3.Items.Count; i++)
            {
                if (cmbSavegamesTR3.Items[i] is Savegame savegame)
                {
                    TR3.UpdateDisplayName(savegame);

                    cmbSavegamesTR3.Items[i] = savegame;
                }
            }

            TR3.PopulateEmptySlots(cmbSavegamesTR3);

            cmbSavegamesTR3.SelectedIndexChanged += cmbSavegamesTR3_SelectedIndexChanged;
        }

        private void cmbSavegamesTR1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegame != null && btnSaveTR1.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR1(previousSelectedSavegame);
                }
            }

            previousSelectedSavegame = cmbSavegamesTR1.SelectedItem as Savegame;

            DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
            DisableButtonsTR1();
        }

        private void cmbSavegamesTR2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegame != null && btnSaveTR2.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR2(previousSelectedSavegame);
                }
            }

            previousSelectedSavegame = cmbSavegamesTR2.SelectedItem as Savegame;

            DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
            DisableButtonsTR2();
        }

        private void cmbSavegamesTR3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!userIndexChanged) return;

            if (previousSelectedSavegame != null && btnSaveTR3.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChangesTR3(previousSelectedSavegame);
                }
            }

            previousSelectedSavegame = cmbSavegamesTR3.SelectedItem as Savegame;

            DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
            DisableButtonsTR3();
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
            double healthPercentage = (double)trbHealthTR1.Value;
            lblHealthTR1.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR1.SelectedIndex != -1)
            {
                EnableButtonsTR1();
            }
        }

        private void trbHealthTR2_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = (double)trbHealthTR2.Value;
            lblHealthTR2.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR2.SelectedIndex != -1)
            {
                EnableButtonsTR2();
            }
        }

        private void trbHealthTR3_Scroll(object sender, EventArgs e)
        {
            double healthPercentage = (double)trbHealthTR3.Value;
            lblHealthTR3.Text = healthPercentage.ToString("0.0") + "%";

            if (!isLoading && cmbSavegamesTR3.SelectedIndex != -1)
            {
                EnableButtonsTR3();
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

                    TR1.WriteChanges(chkPistolsTR1, chkMagnumsTR1, chkUzisTR1, chkShotgunTR1, nudSmallMedipacksTR1,
                        nudLargeMedipacksTR1, nudUziAmmoTR1, nudMagnumAmmoTR1, nudShotgunAmmoTR1, trbHealthTR1);

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

                    TR2.WriteChanges(chkPistolsTR2, chkAutomaticPistolsTR2, chkUzisTR2, chkShotgunTR2,
                        chkM16TR2, chkGrenadeLauncherTR2, chkHarpoonGunTR2, nudFlaresTR2,
                        nudSmallMedipacksTR2, nudLargeMedipacksTR2, nudAutomaticPistolsAmmoTR2,
                        nudUziAmmoTR2, nudM16AmmoTR2, nudGrenadeLauncherAmmoTR2, nudHarpoonGunAmmoTR2,
                        nudShotgunAmmoTR2, trbHealthTR2);

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

                    TR3.WriteChanges(chkPistolsTR3, chkDeagleTR3, chkUziTR3, chkShotgunTR3, chkMP5TR3, chkRocketLauncherTR3,
                        chkGrenadeLauncherTR3, chkHarpoonGunTR3, nudFlaresTR3, nudSmallMedipacksTR3, nudLargeMedipacksTR3,
                        nudShotgunAmmoTR3, nudDeagleAmmoTR3, nudGrenadeLauncherAmmoTR3, nudRocketLauncherAmmoTR3,
                        nudHarpoonGunAmmoTR3, nudMP5AmmoTR3, nudUziAmmoTR3, trbHealthTR3, nudCollectibleCrystalsTR3);

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

                slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                    $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
            }
            else
            {
                MessageBox.Show("Savegame path is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                cmbSavegamesTR2.Items.Clear();
                TR2.PopulateSavegames(cmbSavegamesTR2);

                slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                    $"{cmbSavegamesTR2.Items.Count} savegames found for Tomb Raider II" : "Ready";
            }
            else
            {
                MessageBox.Show("Savegame path is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshTR3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
            {
                cmbSavegamesTR3.Items.Clear();
                TR3.PopulateSavegames(cmbSavegamesTR3);

                slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                    $"{cmbSavegamesTR3.Items.Count} savegames found for Tomb Raider III" : "Ready";
            }
            else
            {
                MessageBox.Show("Savegame path is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSavegameDisplayNameTR1(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR1_SelectedIndexChanged;

            if (cmbSavegames.SelectedItem != null)
            {
                int selectedIndex = cmbSavegames.SelectedIndex;
                cmbSavegames.Items[selectedIndex] = selectedSavegame;
            }

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR1_SelectedIndexChanged;
        }

        private void UpdateSavegameDisplayNameTR2(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR2_SelectedIndexChanged;

            if (cmbSavegames.SelectedItem != null)
            {
                int selectedIndex = cmbSavegames.SelectedIndex;
                cmbSavegames.Items[selectedIndex] = selectedSavegame;
            }

            cmbSavegames.SelectedIndexChanged += cmbSavegamesTR2_SelectedIndexChanged;
        }

        private void UpdateSavegameDisplayNameTR3(ComboBox cmbSavegames, Savegame selectedSavegame)
        {
            cmbSavegames.SelectedIndexChanged -= cmbSavegamesTR3_SelectedIndexChanged;

            if (cmbSavegames.SelectedItem != null)
            {
                int selectedIndex = cmbSavegames.SelectedIndex;
                cmbSavegames.Items[selectedIndex] = selectedSavegame;
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

                    TR1.UpdateDisplayName(selectedSavegame);

                    UpdateSavegameDisplayNameTR1(cmbSavegamesTR1, selectedSavegame);

                    TR1.DisplayGameInfo(chkPistolsTR1, chkMagnumsTR1, chkUzisTR1, chkShotgunTR1,
                        nudSmallMedipacksTR1, nudLargeMedipacksTR1, nudUziAmmoTR1, nudShotgunAmmoTR1, nudMagnumAmmoTR1,
                        trbHealthTR1, lblHealthTR1, lblHealthErrorTR1);

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

                    TR2.UpdateDisplayName(selectedSavegame);

                    UpdateSavegameDisplayNameTR2(cmbSavegamesTR2, selectedSavegame);

                    TR2.SetLevelParams(chkPistolsTR2, chkShotgunTR2, chkAutomaticPistolsTR2, chkUzisTR2, chkM16TR2,
                        chkGrenadeLauncherTR2, chkHarpoonGunTR2, nudShotgunAmmoTR2, nudAutomaticPistolsAmmoTR2, nudUziAmmoTR2,
                        nudM16AmmoTR2, nudGrenadeLauncherAmmoTR2, nudHarpoonGunAmmoTR2);

                    TR2.DisplayGameInfo(chkPistolsTR2, chkAutomaticPistolsTR2, chkUzisTR2, chkM16TR2,
                        chkGrenadeLauncherTR2, chkHarpoonGunTR2, nudAutomaticPistolsAmmoTR2, chkShotgunTR2,
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

                    TR3.UpdateDisplayName(selectedSavegame);

                    UpdateSavegameDisplayNameTR3(cmbSavegamesTR3, selectedSavegame);

                    TR3.DisplayGameInfo(chkPistolsTR3, chkShotgunTR3, chkDeagleTR3, chkUziTR3, chkMP5TR3,
                        chkRocketLauncherTR3, chkGrenadeLauncherTR3, chkHarpoonGunTR3, nudSmallMedipacksTR3,
                        nudLargeMedipacksTR3, nudFlaresTR3, nudShotgunAmmoTR3, nudDeagleAmmoTR3, nudGrenadeLauncherAmmoTR3,
                        nudRocketLauncherAmmoTR3, nudHarpoonGunAmmoTR3, nudMP5AmmoTR3, nudUziAmmoTR3,
                        trbHealthTR3, lblHealthTR3, lblHealthErrorTR3, nudCollectibleCrystalsTR3);

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
                btnRefreshTR1.Enabled = !string.IsNullOrEmpty(savegamePath);

                if (cmbSavegamesTR1.Items.Count == 0)
                {
                    PopulateSavegamesTR1();
                }
                else
                {
                    DisplayGameInfoTR1(cmbSavegamesTR1.SelectedItem as Savegame);
                }

                slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                    $"{cmbSavegamesTR1.Items.Count} savegames found for Tomb Raider I" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR2)
            {
                btnRefreshTR2.Enabled = !string.IsNullOrEmpty(savegamePath);

                if (cmbSavegamesTR2.Items.Count == 0)
                {
                    PopulateSavegamesTR2();
                }
                else
                {
                    DisplayGameInfoTR2(cmbSavegamesTR2.SelectedItem as Savegame);
                }

                slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                    $"{cmbSavegamesTR2.Items.Count} savegames found for Tomb Raider II" : "Ready";
            }
            else if (tabGame.SelectedIndex == TAB_TR3)
            {
                btnRefreshTR3.Enabled = !string.IsNullOrEmpty(savegamePath);

                if (cmbSavegamesTR3.Items.Count == 0)
                {
                    PopulateSavegamesTR3();
                }
                else
                {
                    DisplayGameInfoTR3(cmbSavegamesTR3.SelectedItem as Savegame);
                }

                slblStatus.Text = !string.IsNullOrEmpty(savegamePath) ?
                    $"{cmbSavegamesTR3.Items.Count} savegames found for Tomb Raider III" : "Ready";
            }
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

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.TopMost = TopMost;
            aboutForm.ShowDialog();
        }

        private void tsmiBrowsePath_Click(object sender, EventArgs e)
        {
            BrowseSavegamePath();
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