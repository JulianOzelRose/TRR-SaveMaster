using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using static TRR_SaveMaster.MainForm;

namespace TRR_SaveMaster
{
    public partial class OutfitsTRX2Form : Form
    {
        // Game completion flags
        private const int TR4_COMPLETED_OFFSET = 0x1A4;
        private const int TR5_COMPLETED_OFFSET = 0x1A8;
        private const int TR6_COMPLETED_OFFSET = 0x1AC;

        private const int OUTFITS_BASE_OFFSET = 0x1B0;

        private const int OUTFITS_BYTE_0 = OUTFITS_BASE_OFFSET + 0;
        private const int OUTFITS_BYTE_1 = OUTFITS_BASE_OFFSET + 1;
        private const int OUTFITS_BYTE_2 = OUTFITS_BASE_OFFSET + 2;

        // Byte 0
        private const byte CLASSIC = 0x01;
        private const byte FMV = 0x02;
        private const byte YOUNG_1 = 0x04;
        private const byte YOUNG_2 = 0x08;
        private const byte CAMOUFLAGE = 0x10;
        private const byte CATSUIT_1 = 0x40;
        private const byte CATSUIT_2 = 0x80;

        // Byte 1
        private const byte XRAY = 0x01;
        private const byte CLASSIC_TR1 = 0x04;
        private const byte TRAINING_TR1 = 0x08;
        private const byte BLOODY_TR1 = 0x10;
        private const byte CLASSIC_TR2 = 0x20;
        private const byte TRAINING_TR2 = 0x40;
        private const byte WETSUIT_TR2 = 0x80;

        // Byte 2
        private const byte BOMBER_TR2 = 0x01;
        private const byte BATHROBE_TR2 = 0x02;
        private const byte VEGAS_TR2 = 0x04;
        private const byte TRAINING_TR3 = 0x08;
        private const byte NEVADA_TR3 = 0x10;
        private const byte PACIFIC_TR3 = 0x20;
        private const byte CATSUIT_TR3 = 0x40;
        private const byte ANTARCTICA_TR3 = 0x80;

        // Misc
        private ToolStripStatusLabel slblStatus;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;

        // Paths
        private string savegamePath;

        public OutfitsTRX2Form(ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePath)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePath = savegamePath;
        }

        private void OutfitsTRX2Form_Load(object sender, EventArgs e)
        {
            if (ThemeUtilities.DARK_MODE_ENABLED)
            {
                ThemeUtilities.ApplyDarkMode(this);
                ThemeUtilities.ApplyDarkTitleBar(this);
            }

            DisplayData();
        }

        private void OutfitsTRX2Form_FormClosing(object sender, FormClosingEventArgs e)
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

                // TR6
                chkAllTR6Outfits.Checked = BitConverter.ToInt32(fileData, TR6_COMPLETED_OFFSET) != 0;

                // TR4 / TR5
                chkClassic.Checked = Has(OUTFITS_BYTE_0, CLASSIC);
                chkFMV.Checked = Has(OUTFITS_BYTE_0, FMV);
                chkYoung1.Checked = Has(OUTFITS_BYTE_0, YOUNG_1);
                chkYoung2.Checked = Has(OUTFITS_BYTE_0, YOUNG_2);
                chkCamouflage.Checked = Has(OUTFITS_BYTE_0, CAMOUFLAGE);
                chkCatsuit1.Checked = Has(OUTFITS_BYTE_0, CATSUIT_1);
                chkCatsuit2.Checked = Has(OUTFITS_BYTE_0, CATSUIT_2);

                chkXray.Checked = Has(OUTFITS_BYTE_1, XRAY);
                chkClassicTR1.Checked = Has(OUTFITS_BYTE_1, CLASSIC_TR1);
                chkTrainingTR1.Checked = Has(OUTFITS_BYTE_1, TRAINING_TR1);
                chkBloodyTR1.Checked = Has(OUTFITS_BYTE_1, BLOODY_TR1);
                chkClassicTR2.Checked = Has(OUTFITS_BYTE_1, CLASSIC_TR2);
                chkTrainingTR2.Checked = Has(OUTFITS_BYTE_1, TRAINING_TR2);
                chkWetsuitTR2.Checked = Has(OUTFITS_BYTE_1, WETSUIT_TR2);

                chkBomberTR2.Checked = Has(OUTFITS_BYTE_2, BOMBER_TR2);
                chkBathrobeTR2.Checked = Has(OUTFITS_BYTE_2, BATHROBE_TR2);
                chkVegasTR2.Checked = Has(OUTFITS_BYTE_2, VEGAS_TR2);
                chkTrainingTR3.Checked = Has(OUTFITS_BYTE_2, TRAINING_TR3);
                chkNevadaTR3.Checked = Has(OUTFITS_BYTE_2, NEVADA_TR3);
                chkPacificTR3.Checked = Has(OUTFITS_BYTE_2, PACIFIC_TR3);
                chkCatsuitTR3.Checked = Has(OUTFITS_BYTE_2, CATSUIT_TR3);
                chkAntarcticaTR3.Checked = Has(OUTFITS_BYTE_2, ANTARCTICA_TR3);
            }
            catch (Exception ex)
            {
                slblStatus.Text = Globals.STATUS_MSG_OUTFITS_READ_ERROR;

                SystemSounds.Hand.Play();

                ThemedMessageBox.Show(
                    this,
                    ex.Message,
                    Globals.DIALOG_TITLE_ERROR,
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
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, CLASSIC, chkClassic.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, FMV, chkFMV.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, YOUNG_1, chkYoung1.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, YOUNG_2, chkYoung2.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, CAMOUFLAGE, chkCamouflage.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, CATSUIT_1, chkCatsuit1.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_0, CATSUIT_2, chkCatsuit2.Checked);

                    // Byte 1
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, XRAY, chkXray.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, CLASSIC_TR1, chkClassicTR1.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, TRAINING_TR1, chkTrainingTR1.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, BLOODY_TR1, chkBloodyTR1.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, CLASSIC_TR2, chkClassicTR2.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, TRAINING_TR2, chkTrainingTR2.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_1, WETSUIT_TR2, chkWetsuitTR2.Checked);

                    // Byte 2
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, BOMBER_TR2, chkBomberTR2.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, BATHROBE_TR2, chkBathrobeTR2.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, VEGAS_TR2, chkVegasTR2.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, TRAINING_TR3, chkTrainingTR3.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, NEVADA_TR3, chkNevadaTR3.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, PACIFIC_TR3, chkPacificTR3.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, CATSUIT_TR3, chkCatsuitTR3.Checked);
                    SetOutfitBit(fileData, OUTFITS_BYTE_2, ANTARCTICA_TR3, chkAntarcticaTR3.Checked);

                    bool requiresTR4Completion =
                        chkClassic.Checked ||
                        chkFMV.Checked ||
                        chkYoung1.Checked ||
                        chkYoung2.Checked ||
                        chkClassicTR1.Checked ||
                        chkBloodyTR1.Checked ||
                        chkClassicTR2.Checked;

                    bool requiresTR5Completion =
                        chkCamouflage.Checked ||
                        chkCatsuit1.Checked ||
                        chkCatsuit2.Checked ||
                        chkXray.Checked ||
                        chkTrainingTR1.Checked ||
                        chkTrainingTR2.Checked ||
                        chkWetsuitTR2.Checked ||
                        chkBomberTR2.Checked ||
                        chkBathrobeTR2.Checked ||
                        chkVegasTR2.Checked ||
                        chkTrainingTR3.Checked ||
                        chkNevadaTR3.Checked ||
                        chkPacificTR3.Checked ||
                        chkCatsuitTR3.Checked ||
                        chkAntarcticaTR3.Checked;

                    if (requiresTR4Completion)
                    {
                        WriteInt32ToBuffer(fileData, TR4_COMPLETED_OFFSET, 1);
                    }

                    if (requiresTR5Completion)
                    {
                        WriteInt32ToBuffer(fileData, TR5_COMPLETED_OFFSET, 1);
                    }

                    WriteInt32ToBuffer(fileData, TR6_COMPLETED_OFFSET, chkAllTR6Outfits.Checked ? 1 : 0);

                    File.WriteAllBytes(savegamePath, fileData);

                    DisableButtons();
                    slblStatus.Text = Globals.STATUS_MSG_OUTFITS_WRITE_SUCCESS;
                }
            }
            catch (Exception ex)
            {
                slblStatus.Text = Globals.STATUS_MSG_OUTFITS_WRITE_ERROR;

                SystemSounds.Hand.Play();

                ThemedMessageBox.Show(
                    this,
                    ex.Message,
                    Globals.DIALOG_TITLE_ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void WriteInt32ToBuffer(byte[] buffer, int offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void SetOutfitBit(byte[] data, int offset, byte mask, bool enabled)
        {
            if (enabled)
            {
                data[offset] |= mask;
            }
            else
            {
                data[offset] &= (byte)~mask;
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
                SystemSounds.Asterisk.Play();

                DialogResult result = ThemedMessageBox.Show(
                    this,
                    Globals.DIALOG_MSG_CONFIRM_SAVEGAME_CHANGES,
                    Globals.DIALOG_TITLE_CONFIRMATION,
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

        private void btnUnlockAllTR45_Click(object sender, EventArgs e)
        {
            chkClassic.Checked = true;
            chkFMV.Checked = true;
            chkYoung1.Checked = true;
            chkYoung2.Checked = true;
            chkCamouflage.Checked = true;
            chkCatsuit1.Checked = true;
            chkCatsuit2.Checked = true;
            chkXray.Checked = true;
            chkClassicTR1.Checked = true;
            chkTrainingTR1.Checked = true;
            chkBloodyTR1.Checked = true;
            chkClassicTR2.Checked = true;
            chkTrainingTR2.Checked = true;
            chkWetsuitTR2.Checked = true;
            chkBomberTR2.Checked = true;
            chkBathrobeTR2.Checked = true;
            chkVegasTR2.Checked = true;
            chkTrainingTR3.Checked = true;
            chkNevadaTR3.Checked = true;
            chkPacificTR3.Checked = true;
            chkCatsuitTR3.Checked = true;
            chkAntarcticaTR3.Checked = true;
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

        private void chkClassic_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkClassicTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkFMV_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTrainingTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkYoung1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkWetsuitTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkYoung2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkBomberTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCamouflage_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkBathrobeTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCatsuit1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkVegasTR2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCatsuit2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTrainingTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkXray_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkNevadaTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkClassicTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkPacificTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTrainingTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkCatsuitTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkBloodyTR1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAntarcticaTR3_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkAllTR6Outfits_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }
    }
}
