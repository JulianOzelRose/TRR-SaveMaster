using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class PositionForm : Form
    {
        // Offsets
        private int levelIndexOffset;
        private int xCoordinateOffset;
        private int yCoordinateOffset;
        private int zCoordinateOffset;
        private int directionOffset;

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;

        // Savegame
        private Savegame selectedSavegame;
        private string savegamePath;
        private int savegameOffset;
        private int healthOffset;

        // Misc
        private ToolStripStatusLabel slblStatus;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;
        private int SELECTED_TAB;

        public PositionForm(ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePath, int SELECTED_TAB)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePath = savegamePath;
            this.SELECTED_TAB = SELECTED_TAB;
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            DetermineOffsets();
            DisplayCoordinates();
        }

        private void PositionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
        }

        public void SetSavegame(Savegame savegame)
        {
            selectedSavegame = savegame;
            savegameOffset = savegame.Offset;
            grpLevel.Text = $"{selectedSavegame}";
        }

        public void SetHealthOffset(int offset)
        {
            healthOffset = offset;
        }

        private byte ReadByte(int offset)
        {
            using (FileStream saveFile = new FileStream(savegamePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                saveFile.Seek(offset, SeekOrigin.Begin);
                return (byte)saveFile.ReadByte();
            }
        }

        private void WriteByte(int offset, byte value)
        {
            using (FileStream saveFile = new FileStream(savegamePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                saveFile.Seek(offset, SeekOrigin.Begin);
                byte[] byteData = { value };
                saveFile.Write(byteData, 0, byteData.Length);
            }
        }

        private Int32 ReadInt32(int offset)
        {
            byte byte1 = ReadByte(offset);
            byte byte2 = ReadByte(offset + 1);
            byte byte3 = ReadByte(offset + 2);
            byte byte4 = ReadByte(offset + 3);

            return (Int32)(byte1 + (byte2 << 8) + (byte3 << 16) + (byte4 << 24));
        }

        private void WriteInt32(int offset, Int32 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
            WriteByte(offset + 2, (byte)(value >> 16));
            WriteByte(offset + 3, (byte)(value >> 24));
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + levelIndexOffset);
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

        private void btnEndOfLevel_Click(object sender, EventArgs e)
        {
            Int32[] endOfLevelCoordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1)
            {
                byte levelIndex = GetLevelIndex();
                endOfLevelCoordinates = endOfLevelCoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                //byte levelIndex = GetLevelIndex();
                //endOfLevelCoordinates = endOfLevelCoordinatesTR2[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                //byte levelIndex = GetLevelIndex();
                //endOfLevelCoordinates = endOfLevelCoordinatesTR3[levelIndex];
            }

            nudXCoordinate.Value = endOfLevelCoordinates[0];
            nudYCoordinate.Value = endOfLevelCoordinates[1];
            nudZCoordinate.Value = endOfLevelCoordinates[2];
            nudDirection.Value = (byte)endOfLevelCoordinates[3];
        }

        private void ConfirmChanges()
        {
            if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame coordinates?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChanges();
                }
            }
        }

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 42911, 7168, 81358, 11      } },    // Caves
            { 2,  new Int32[] { 10380, -1024, 29124, 87     } },    // City of Vilcabamba
            { 3,  new Int32[] { 39962, 5895, 75273, 50      } },    // Lost Valley
            { 4,  new Int32[] { 39061, 0, 60703, 9          } },    // Tomb of Qualopec
            { 5,  new Int32[] { 29142, 23296, 38357, 46     } },    // St. Francis' Folly
            { 6,  new Int32[] { 35304, -2304, 65138, 40     } },    // Colosseum
            { 7,  new Int32[] { 19557, -4608, 19861, 1      } },    // Palace Midas
            { 8,  new Int32[] { 40451, -5888, 35460, 61     } },    // The Cistern
            { 9,  new Int32[] { 32276, 3840, 94965, 112     } },    // Tomb of Tihocan
            { 10, new Int32[] { 44506, -3072, 37787, 33     } },    // City of Khamoon
            { 11, new Int32[] { 26058, -256, 21387, 9       } },    // Obelisk of Khamoon
            { 12, new Int32[] { 24941, 3072, 53569, 61      } },    // Sanctuary of the Scion
            { 13, new Int32[] { 32857, -8704, 93170, 82     } },    // Natla's Mines
            { 14, new Int32[] { 50073, -18688, 45543, 50    } },    // Atlantis
            { 15, new Int32[] { 44711, 0, 72603, 59         } },    // The Great Pyramid
            { 16, new Int32[] { 68525, -1813, 73212, 78     } },    // Return to Egypt
            { 17, new Int32[] { 31973, -15104, 61952, 105   } },    // Temple of the Cat
            { 18, new Int32[] { 45157, -3584, 37302, 65     } },    // Atlantean Stronghold
            { 19, new Int32[] { 41573, 11264, 43109, 9      } },    // The Hive
        };

        private void DetermineOffsets()
        {
            btnEndOfLevel.Enabled = (SELECTED_TAB == TAB_TR1);

            if (SELECTED_TAB == TAB_TR1)
            {
                levelIndexOffset = 0x62C;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                levelIndexOffset = 0x628;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                levelIndexOffset = 0x8D6;
            }

            xCoordinateOffset = healthOffset - 0x24;
            yCoordinateOffset = healthOffset - 0x20;
            zCoordinateOffset = healthOffset - 0x1C;
            directionOffset = healthOffset - 0x10;
        }

        private void DisplayCoordinates()
        {
            isLoading = true;

            try
            {
                nudXCoordinate.Value = ReadInt32(savegameOffset + xCoordinateOffset);
                nudYCoordinate.Value = ReadInt32(savegameOffset + yCoordinateOffset);
                nudZCoordinate.Value = ReadInt32(savegameOffset + zCoordinateOffset);
                nudDirection.Value = ReadByte(savegameOffset + directionOffset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error loading savegame coordinates.";
                this.Close();
            }

            isLoading = false;
        }

        private void WriteChanges()
        {
            try
            {
                if (backupBeforeSaving)
                {
                    CreateBackup();
                }

                File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                WriteInt32(savegameOffset + xCoordinateOffset, (Int32)nudXCoordinate.Value);
                WriteInt32(savegameOffset + yCoordinateOffset, (Int32)nudYCoordinate.Value);
                WriteInt32(savegameOffset + zCoordinateOffset, (Int32)nudZCoordinate.Value);
                WriteByte(savegameOffset + directionOffset, (byte)nudDirection.Value);

                DisableButtons();

                slblStatus.Text = $"Successfully patched coordinates of savegame: '{selectedSavegame}'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error writing to savegame coordinates.";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableButtons();
            DisplayCoordinates();
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

        private void nudXCoordinate_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudYCoordinate_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudZCoordinate_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudDirection_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudXCoordinate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudYCoordinate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudZCoordinate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudDirection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }
    }
}
