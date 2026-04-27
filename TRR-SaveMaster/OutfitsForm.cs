using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using static TRR_SaveMaster.MainForm;

namespace TRR_SaveMaster
{
    public partial class OutfitsForm : Form
    {
        // Base start of outfit bitfield
        private const int OUTFITS_BASE_OFFSET = 0x250;

        // Mirror offset
        private const int OUTFITS_MIRROR_DELTA = 0x04;

        // Individual bytes
        private const int OUTFITS_BYTE_0 = OUTFITS_BASE_OFFSET + 0;
        private const int OUTFITS_BYTE_1 = OUTFITS_BASE_OFFSET + 1;
        private const int OUTFITS_BYTE_2 = OUTFITS_BASE_OFFSET + 2;
        private const int OUTFITS_BYTE_3 = OUTFITS_BASE_OFFSET + 3;

        // Byte 0 (0x250)
        private const byte PARAGON_B = 0x01;
        private const byte PARAGON_S = 0x02;
        private const byte PARAGON_G = 0x04;

        private const byte ESTABLISHED_B = 0x08;
        private const byte ESTABLISHED_S = 0x10;
        private const byte ESTABLISHED_G = 0x20;

        private const byte ATLANTEAN_B = 0x40;
        private const byte ATLANTEAN_S = 0x80;

        // Byte 1 (0x251)
        private const byte ATLANTEAN_G = 0x01;

        private const byte MASTER_MOBSTER_B = 0x02;
        private const byte MASTER_MOBSTER_S = 0x04;
        private const byte MASTER_MOBSTER_G = 0x08;

        private const byte AHAB_B = 0x10;
        private const byte AHAB_S = 0x20;
        private const byte AHAB_G = 0x40;

        private const byte DRAGON_B = 0x80;

        // Byte 2 (0x252)
        private const byte DRAGON_S = 0x01;
        private const byte DRAGON_G = 0x02;

        private const byte SPEED_B = 0x04;
        private const byte SPEED_S = 0x08;
        private const byte SPEED_G = 0x10;

        private const byte FLYING_B = 0x20;
        private const byte FLYING_S = 0x40;
        private const byte FLYING_G = 0x80;

        // Misc
        private ToolStripStatusLabel slblStatus;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;

        // Paths
        private string savegamePath;

        public OutfitsForm(ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePath)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePath = savegamePath;
        }

        private void OutfitsForm_Load(object sender, EventArgs e)
        {
            if (ThemeUtilities.DARK_MODE_ENABLED)
            {
                ThemeUtilities.ApplyDarkMode(this);
                ThemeUtilities.ApplyDarkTitleBar(this);
            }

            DisplayData();
        }

        private void OutfitsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
        }

        private void DisplayData()
        {
            isLoading = true;

            try
            {
                byte[] fileData = File.ReadAllBytes(savegamePath);

                bool Has(int offset, byte mask) => (fileData[offset] & mask) != 0;

                // Byte 0
                chkParagonOfPeaceBronze.Checked = Has(OUTFITS_BYTE_0, PARAGON_B);
                chkParagonOfPeaceSilver.Checked = Has(OUTFITS_BYTE_0, PARAGON_S);
                chkParagonOfPeaceGold.Checked = Has(OUTFITS_BYTE_0, PARAGON_G);

                chkEstablishedExplorerBronze.Checked = Has(OUTFITS_BYTE_0, ESTABLISHED_B);
                chkEstablishedExplorerSilver.Checked = Has(OUTFITS_BYTE_0, ESTABLISHED_S);
                chkEstablishedExplorerGold.Checked = Has(OUTFITS_BYTE_0, ESTABLISHED_G);

                chkAtlanteanBioArmourBronze.Checked = Has(OUTFITS_BYTE_0, ATLANTEAN_B);
                chkAtlanteanBioArmourSilver.Checked = Has(OUTFITS_BYTE_0, ATLANTEAN_S);
                chkAtlanteanBioArmourGold.Checked = Has(OUTFITS_BYTE_1, ATLANTEAN_G); // cross-byte

                // Byte 1
                chkMasterMobsterBronze.Checked = Has(OUTFITS_BYTE_1, MASTER_MOBSTER_B);
                chkMasterMobsterSilver.Checked = Has(OUTFITS_BYTE_1, MASTER_MOBSTER_S);
                chkMasterMobsterGold.Checked = Has(OUTFITS_BYTE_1, MASTER_MOBSTER_G);

                chkAhabApprovedBronze.Checked = Has(OUTFITS_BYTE_1, AHAB_B);
                chkAhabApprovedSilver.Checked = Has(OUTFITS_BYTE_1, AHAB_S);
                chkAhabApprovedGold.Checked = Has(OUTFITS_BYTE_1, AHAB_G);

                // Byte 2
                chkDragonWarriorBronze.Checked = Has(OUTFITS_BYTE_1, DRAGON_B);
                chkDragonWarriorSilver.Checked = Has(OUTFITS_BYTE_2, DRAGON_S);
                chkDragonWarriorGold.Checked = Has(OUTFITS_BYTE_2, DRAGON_G);

                chkSpeedDemonBronze.Checked = Has(OUTFITS_BYTE_2, SPEED_B);
                chkSpeedDemonSilver.Checked = Has(OUTFITS_BYTE_2, SPEED_S);
                chkSpeedDemonGold.Checked = Has(OUTFITS_BYTE_2, SPEED_G);

                chkFlyingHighBronze.Checked = Has(OUTFITS_BYTE_2, FLYING_B);
                chkFlyingHighSilver.Checked = Has(OUTFITS_BYTE_2, FLYING_S);
                chkFlyingHighGold.Checked = Has(OUTFITS_BYTE_2, FLYING_G);

                // Byte 3
                chkHonoraryDamnedBronze.Checked = Has(OUTFITS_BYTE_3, 0x01);
                chkHonoraryDamnedSilver.Checked = Has(OUTFITS_BYTE_3, 0x02);
                chkHonoraryDamnedGold.Checked = Has(OUTFITS_BYTE_3, 0x04);

                chkCoolerThanCoolBronze.Checked = Has(OUTFITS_BYTE_3, 0x08);
                chkCoolerThanCoolSilver.Checked = Has(OUTFITS_BYTE_3, 0x10);
                chkCoolerThanCoolGold.Checked = Has(OUTFITS_BYTE_3, 0x20);
            }
            catch (Exception ex)
            {
                slblStatus.Text = $"Error loading outfits data";

                SystemSounds.Hand.Play();

                ThemedMessageBox.Show(
                    this,
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }

            isLoading = false;
        }

        private void WriteChanges()
        {
            try
            {
                if (!string.IsNullOrEmpty(savegamePath) && File.Exists(savegamePath))
                {
                    if (backupBeforeSaving)
                    {
                        CreateBackup();
                    }

                    File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                    byte[] fileData = File.ReadAllBytes(savegamePath);

                    // Byte 0
                    SetBit(fileData, OUTFITS_BYTE_0, PARAGON_B, chkParagonOfPeaceBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_0, PARAGON_S, chkParagonOfPeaceSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_0, PARAGON_G, chkParagonOfPeaceGold.Checked);

                    SetBit(fileData, OUTFITS_BYTE_0, ESTABLISHED_B, chkEstablishedExplorerBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_0, ESTABLISHED_S, chkEstablishedExplorerSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_0, ESTABLISHED_G, chkEstablishedExplorerGold.Checked);

                    SetBit(fileData, OUTFITS_BYTE_0, ATLANTEAN_B, chkAtlanteanBioArmourBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_0, ATLANTEAN_S, chkAtlanteanBioArmourSilver.Checked);

                    // Atlantean G is in Byte 1
                    SetBit(fileData, OUTFITS_BYTE_1, ATLANTEAN_G, chkAtlanteanBioArmourGold.Checked);


                    // Byte 1
                    SetBit(fileData, OUTFITS_BYTE_1, MASTER_MOBSTER_B, chkMasterMobsterBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_1, MASTER_MOBSTER_S, chkMasterMobsterSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_1, MASTER_MOBSTER_G, chkMasterMobsterGold.Checked);

                    SetBit(fileData, OUTFITS_BYTE_1, AHAB_B, chkAhabApprovedBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_1, AHAB_S, chkAhabApprovedSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_1, AHAB_G, chkAhabApprovedGold.Checked);

                    // Dragon B (cross-byte)
                    SetBit(fileData, OUTFITS_BYTE_1, DRAGON_B, chkDragonWarriorBronze.Checked);


                    // Byte 2
                    SetBit(fileData, OUTFITS_BYTE_2, DRAGON_S, chkDragonWarriorSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_2, DRAGON_G, chkDragonWarriorGold.Checked);

                    SetBit(fileData, OUTFITS_BYTE_2, SPEED_B, chkSpeedDemonBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_2, SPEED_S, chkSpeedDemonSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_2, SPEED_G, chkSpeedDemonGold.Checked);

                    SetBit(fileData, OUTFITS_BYTE_2, FLYING_B, chkFlyingHighBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_2, FLYING_S, chkFlyingHighSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_2, FLYING_G, chkFlyingHighGold.Checked);


                    // Byte 3
                    SetBit(fileData, OUTFITS_BYTE_3, 0x01, chkHonoraryDamnedBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_3, 0x02, chkHonoraryDamnedSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_3, 0x04, chkHonoraryDamnedGold.Checked);

                    SetBit(fileData, OUTFITS_BYTE_3, 0x08, chkCoolerThanCoolBronze.Checked);
                    SetBit(fileData, OUTFITS_BYTE_3, 0x10, chkCoolerThanCoolSilver.Checked);
                    SetBit(fileData, OUTFITS_BYTE_3, 0x20, chkCoolerThanCoolGold.Checked);


                    File.WriteAllBytes(savegamePath, fileData);

                    DisableButtons();
                    slblStatus.Text = $"Successfully patched outfits data";
                }
            }
            catch (Exception ex)
            {
                slblStatus.Text = $"Error writing to outfits data";

                SystemSounds.Hand.Play();

                ThemedMessageBox.Show(
                    this,
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void SetBit(byte[] data, int offset, byte mask, bool enabled)
        {
            if (enabled)
            {
                data[offset] |= mask;
            }
            else
            {
                data[offset] &= (byte)~mask;
            }

            // Mirror must always match
            if (enabled)
            {
                data[offset + OUTFITS_MIRROR_DELTA] |= mask;
            }
            else
            {
                data[offset + OUTFITS_MIRROR_DELTA] &= (byte)~mask;
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
            }
        }

        private void ConfirmChanges()
        {
            if (btnSave.Enabled)
            {
                DialogResult result = ThemedMessageBox.Show(
                    this,
                    $"Would you like to apply changes to the savegame?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChanges();
                }
            }
        }

        private void EnableButtons()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void DisableButtons()
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnUnlockAll_Click(object sender, EventArgs e)
        {
            chkParagonOfPeaceBronze.Checked = true;
            chkParagonOfPeaceSilver.Checked = true;
            chkParagonOfPeaceGold.Checked = true;

            chkEstablishedExplorerBronze.Checked = true;
            chkEstablishedExplorerSilver.Checked = true;
            chkEstablishedExplorerGold.Checked = true;

            chkAtlanteanBioArmourBronze.Checked = true;
            chkAtlanteanBioArmourSilver.Checked = true;
            chkAtlanteanBioArmourGold.Checked = true;

            chkMasterMobsterBronze.Checked = true;
            chkMasterMobsterSilver.Checked = true;
            chkMasterMobsterGold.Checked = true;

            chkAhabApprovedBronze.Checked = true;
            chkAhabApprovedSilver.Checked = true;
            chkAhabApprovedGold.Checked = true;

            chkDragonWarriorBronze.Checked = true;
            chkDragonWarriorSilver.Checked = true;
            chkDragonWarriorGold.Checked = true;

            chkSpeedDemonBronze.Checked = true;
            chkSpeedDemonSilver.Checked = true;
            chkSpeedDemonGold.Checked = true;

            chkFlyingHighBronze.Checked = true;
            chkFlyingHighSilver.Checked = true;
            chkFlyingHighGold.Checked = true;

            chkHonoraryDamnedBronze.Checked = true;
            chkHonoraryDamnedSilver.Checked = true;
            chkHonoraryDamnedGold.Checked = true;

            chkCoolerThanCoolBronze.Checked = true;
            chkCoolerThanCoolSilver.Checked = true;
            chkCoolerThanCoolGold.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableButtons();
            DisplayData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteChanges();
        }

        private void chkParagonOfPeaceBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkParagonOfPeaceSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkParagonOfPeaceGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkEstablishedExplorerBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkEstablishedExplorerSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkEstablishedExplorerGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAtlanteanBioArmourBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAtlanteanBioArmourSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAtlanteanBioArmourGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkMasterMobsterBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkMasterMobsterSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkMasterMobsterGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAhabApprovedBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAhabApprovedSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAhabApprovedGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkDragonWarriorBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkDragonWarriorSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkDragonWarriorGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkSpeedDemonBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkSpeedDemonSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkSpeedDemonGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkFlyingHighBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkFlyingHighSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkFlyingHighGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkHonoraryDamnedBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkHonoraryDamnedSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkHonoraryDamnedGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCoolerThanCoolBronze_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCoolerThanCoolSilver_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCoolerThanCoolGold_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }
    }
}
