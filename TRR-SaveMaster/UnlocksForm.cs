using System;
using System.Windows.Forms;
using System.IO;

namespace TRR_SaveMaster
{
    public partial class UnlocksForm : Form
    {
        // Offsets
        private const int TR1_COMPLETED_OFFSET = 0x18C;
        private const int TR2_COMPLETED_OFFSET = 0x190;
        private const int TR3_COMPLETED_OFFSET = 0x194;
        private const int TR4_COMPLETED_OFFSET = 0x1A4;
        private const int TR5_COMPLETED_OFFSET = 0x1A8;
        private const int TR6_COMPLETED_OFFSET = 0x1AC;
        private const int SOCIETY_OF_RAIDERS_OFFSET_TRX = 0x00A;
        private const int SOCIETY_OF_RAIDERS_OFFSET_TRX2 = 0x00B;

        // Flags
        private const byte RAIDERS_MASK_TRX = 0x80;
        private const byte RAIDERS_MASK_TRX2 = 0x20;

        // Misc
        private MainForm mainForm;
        private ToolStripStatusLabel slblStatus;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;

        // Paths
        private string savegamePathTRX;
        private string savegamePathTRX2;

        public UnlocksForm(MainForm mainForm, ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePathTRX, string savegamePathTRX2)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePathTRX = savegamePathTRX;
            this.savegamePathTRX2 = savegamePathTRX2;
            this.mainForm = mainForm;
        }

        private void UnlocksForm_Load(object sender, EventArgs e)
        {
            SetCheckboxes();
            DisplayData();
        }

        private void UnlocksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
            mainForm.RefreshGameInfoConditionally();
        }

        private void SetCheckboxes()
        {
            // TRX checkboxes
            chkTR1Completed.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);
            chkTR2Completed.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);
            chkTR3Completed.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);
            chkSocietyOfRaidersJoinedTRX.Enabled = !string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX);

            // TRX2 checkboxes
            chkTR4Completed.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);
            chkTR5Completed.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);
            chkTR6Completed.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);
            chkSocietyOfRaidersJoinedTRX2.Enabled = !string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2);
        }

        private void DisplayData()
        {
            isLoading = true;

            try
            {
                if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
                {
                    byte[] fileDataTRX = File.ReadAllBytes(savegamePathTRX);

                    chkTR1Completed.Checked = BitConverter.ToInt32(fileDataTRX, TR1_COMPLETED_OFFSET) != 0;
                    chkTR2Completed.Checked = BitConverter.ToInt32(fileDataTRX, TR2_COMPLETED_OFFSET) != 0;
                    chkTR3Completed.Checked = BitConverter.ToInt32(fileDataTRX, TR3_COMPLETED_OFFSET) != 0;
                    chkSocietyOfRaidersJoinedTRX.Checked = (fileDataTRX[SOCIETY_OF_RAIDERS_OFFSET_TRX] & RAIDERS_MASK_TRX) != 0;
                }

                if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
                {
                    byte[] fileDataTRX2 = File.ReadAllBytes(savegamePathTRX2);

                    chkTR4Completed.Checked = BitConverter.ToInt32(fileDataTRX2, TR4_COMPLETED_OFFSET) != 0;
                    chkTR5Completed.Checked = BitConverter.ToInt32(fileDataTRX2, TR5_COMPLETED_OFFSET) != 0;
                    chkTR6Completed.Checked = BitConverter.ToInt32(fileDataTRX2, TR6_COMPLETED_OFFSET) != 0;
                    chkSocietyOfRaidersJoinedTRX2.Checked = (fileDataTRX2[SOCIETY_OF_RAIDERS_OFFSET_TRX2] & RAIDERS_MASK_TRX2) != 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error loading savegame globals.";
                this.Close();
            }

            isLoading = false;
        }

        private void WriteChanges()
        {
            try
            {
                bool wroteSomething = false;

                if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
                {
                    if (backupBeforeSaving)
                    {
                        CreateBackupTRX();
                    }

                    File.SetAttributes(savegamePathTRX, File.GetAttributes(savegamePathTRX) & ~FileAttributes.ReadOnly);

                    byte[] fileDataTRX = File.ReadAllBytes(savegamePathTRX);

                    WriteInt32ToBuffer(fileDataTRX, TR1_COMPLETED_OFFSET, chkTR1Completed.Checked ? 1 : 0);
                    WriteInt32ToBuffer(fileDataTRX, TR2_COMPLETED_OFFSET, chkTR2Completed.Checked ? 1 : 0);
                    WriteInt32ToBuffer(fileDataTRX, TR3_COMPLETED_OFFSET, chkTR3Completed.Checked ? 1 : 0);

                    byte societyValue = fileDataTRX[SOCIETY_OF_RAIDERS_OFFSET_TRX];

                    if (chkSocietyOfRaidersJoinedTRX.Checked)
                    {
                        societyValue |= RAIDERS_MASK_TRX;
                    }
                    else
                    {
                        societyValue &= unchecked((byte)~RAIDERS_MASK_TRX);
                    }

                    fileDataTRX[SOCIETY_OF_RAIDERS_OFFSET_TRX] = societyValue;
                    File.WriteAllBytes(savegamePathTRX, fileDataTRX);
                    wroteSomething = true;
                }

                if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
                {
                    if (backupBeforeSaving)
                    {
                        CreateBackupTRX2();
                    }

                    File.SetAttributes(savegamePathTRX2, File.GetAttributes(savegamePathTRX2) & ~FileAttributes.ReadOnly);

                    byte[] fileDataTRX2 = File.ReadAllBytes(savegamePathTRX2);

                    WriteInt32ToBuffer(fileDataTRX2, TR4_COMPLETED_OFFSET, chkTR4Completed.Checked ? 1 : 0);
                    WriteInt32ToBuffer(fileDataTRX2, TR5_COMPLETED_OFFSET, chkTR5Completed.Checked ? 1 : 0);
                    WriteInt32ToBuffer(fileDataTRX2, TR6_COMPLETED_OFFSET, chkTR6Completed.Checked ? 1 : 0);

                    byte societyValue = fileDataTRX2[SOCIETY_OF_RAIDERS_OFFSET_TRX2];

                    if (chkSocietyOfRaidersJoinedTRX2.Checked)
                    {
                        societyValue |= RAIDERS_MASK_TRX2;
                    }
                    else
                    {
                        societyValue &= unchecked((byte)~RAIDERS_MASK_TRX2);
                    }

                    fileDataTRX2[SOCIETY_OF_RAIDERS_OFFSET_TRX2] = societyValue;
                    File.WriteAllBytes(savegamePathTRX2, fileDataTRX2);
                    wroteSomething = true;
                }

                if (wroteSomething)
                {
                    DisableButtons();
                    slblStatus.Text = $"Successfully patched global variables!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error writing savegame globals.";
                this.Close();
            }
        }

        private void ConfirmChanges()
        {
            if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void CreateBackupTRX()
        {
            if (!string.IsNullOrEmpty(savegamePathTRX) && File.Exists(savegamePathTRX))
            {
                string directory = Path.GetDirectoryName(savegamePathTRX);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(savegamePathTRX);
                string fileExtension = Path.GetExtension(savegamePathTRX);

                string backupFilePath = Path.Combine(directory, $"{fileNameWithoutExtension}{fileExtension}.bak");

                if (File.Exists(backupFilePath))
                {
                    File.SetAttributes(backupFilePath, File.GetAttributes(backupFilePath) & ~FileAttributes.ReadOnly);
                }

                File.Copy(savegamePathTRX, backupFilePath, true);
            }
        }

        private void CreateBackupTRX2()
        {
            if (!string.IsNullOrEmpty(savegamePathTRX2) && File.Exists(savegamePathTRX2))
            {
                string directory = Path.GetDirectoryName(savegamePathTRX2);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(savegamePathTRX2);
                string fileExtension = Path.GetExtension(savegamePathTRX2);

                string backupFilePath = Path.Combine(directory, $"{fileNameWithoutExtension}{fileExtension}.bak");

                if (File.Exists(backupFilePath))
                {
                    File.SetAttributes(backupFilePath, File.GetAttributes(backupFilePath) & ~FileAttributes.ReadOnly);
                }

                File.Copy(savegamePathTRX2, backupFilePath, true);
            }
        }

        private void WriteInt32ToBuffer(byte[] buffer, int offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableButtons();

            SetCheckboxes();
            DisplayData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteChanges();
        }

        private void chkTR1Completed_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTR2Completed_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTR3Completed_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkSocietyOfRaidersJoinedTRX_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTR4Completed_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTR5Completed_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkTR6Completed_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void chkSocietyOfRaidersJoinedTRX2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }
    }
}
