using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class PositionForm : Form
    {
        // Offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private int LEVEL_INDEX_OFFSET;
        private int X_COORDINATE_OFFSET;
        private int Y_COORDINATE_OFFSET;
        private int Z_COORDINATE_OFFSET;
        private int ORIENTATION_OFFSET;
        private int ROOM_OFFSET;

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;
        private const int TAB_TR4 = 3;
        private const int TAB_TR5 = 4;

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
            EnableStartOfLevelButtonConditionally();
            EnableEndOfLevelButtonConditionally();
            EnableSecretButtonsConditionally();
            SetNUDRanges();
        }

        private void PositionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
        }

        public void SetSavegame(Savegame savegame)
        {
            selectedSavegame = savegame;
            savegameOffset = savegame.Offset;
            grpSavegameCoordinates.Text = $"{selectedSavegame}";
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

        private Int16 ReadInt16(int offset)
        {
            byte lowerByte = ReadByte(offset);
            byte upperByte = ReadByte(offset + 1);

            return (Int16)(lowerByte + (upperByte << 8));
        }

        private UInt16 ReadUInt16(int offset)
        {
            byte lowerByte = ReadByte(offset);
            byte upperByte = ReadByte(offset + 1);

            return (UInt16)(lowerByte + (upperByte << 8));
        }

        private Int32 ReadInt32(int offset)
        {
            byte byte1 = ReadByte(offset);
            byte byte2 = ReadByte(offset + 1);
            byte byte3 = ReadByte(offset + 2);
            byte byte4 = ReadByte(offset + 3);

            return (Int32)(byte1 + (byte2 << 8) + (byte3 << 16) + (byte4 << 24));
        }

        private void WriteInt16(int offset, Int16 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
        }

        private void WriteUInt16(int offset, UInt16 value)
        {
            if (value > 255)
            {
                byte upperByte = (byte)(value / 256);
                byte lowerByte = (byte)(value % 256);

                WriteByte(offset + 1, upperByte);
                WriteByte(offset, lowerByte);
            }
            else
            {
                WriteByte(offset + 1, 0);
                WriteByte(offset, (byte)value);
            }
        }

        private void WriteInt32(int offset, Int32 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
            WriteByte(offset + 2, (byte)(value >> 16));
            WriteByte(offset + 3, (byte)(value >> 24));
        }

        private bool IsSavegamePresent()
        {
            return ReadByte(savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + LEVEL_INDEX_OFFSET);
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

        private void btnStartOfLevel_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] startOfLevelCoordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && startOfLevelCoordinatesTR1.ContainsKey(levelIndex))
            {
                startOfLevelCoordinates = startOfLevelCoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR2 && startOfLevelCoordinatesTR2.ContainsKey(levelIndex))
            {
                startOfLevelCoordinates = startOfLevelCoordinatesTR2[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && startOfLevelCoordinatesTR3.ContainsKey(levelIndex))
            {
                startOfLevelCoordinates = startOfLevelCoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && startOfLevelCoordinatesTR4.ContainsKey(levelIndex))
            {
                startOfLevelCoordinates = startOfLevelCoordinatesTR4[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR5 && startOfLevelCoordinatesTR5.ContainsKey(levelIndex))
            {
                startOfLevelCoordinates = startOfLevelCoordinatesTR5[levelIndex];
            }

            if (startOfLevelCoordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = startOfLevelCoordinates[0];
            nudYCoordinate.Value = startOfLevelCoordinates[1];
            nudZCoordinate.Value = startOfLevelCoordinates[2];
            nudOrientation.Value = (Int16)startOfLevelCoordinates[3];
            nudRoom.Value = (byte)startOfLevelCoordinates[4];
        }

        private void btnEndOfLevel_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] endOfLevelCoordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && endOfLevelCoordinatesTR1.ContainsKey(levelIndex))
            {
                endOfLevelCoordinates = endOfLevelCoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR2 && endOfLevelCoordinatesTR2.ContainsKey(levelIndex))
            {
                endOfLevelCoordinates = endOfLevelCoordinatesTR2[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && endOfLevelCoordinatesTR3.ContainsKey(levelIndex))
            {
                endOfLevelCoordinates = endOfLevelCoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && endOfLevelCoordinatesTR4.ContainsKey(levelIndex))
            {
                endOfLevelCoordinates = endOfLevelCoordinatesTR4[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR5 && endOfLevelCoordinatesTR5.ContainsKey(levelIndex))
            {
                endOfLevelCoordinates = endOfLevelCoordinatesTR5[levelIndex];
            }

            if (endOfLevelCoordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = endOfLevelCoordinates[0];
            nudYCoordinate.Value = endOfLevelCoordinates[1];
            nudZCoordinate.Value = endOfLevelCoordinates[2];
            nudOrientation.Value = (Int16)endOfLevelCoordinates[3];
            nudRoom.Value = (byte)endOfLevelCoordinates[4];
        }

        private void btnSecret1_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret1Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && secret1CoordinatesTR1.ContainsKey(levelIndex))
            {
                secret1Coordinates = secret1CoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR2 && secret1CoordinatesTR2.ContainsKey(levelIndex))
            {
                secret1Coordinates = secret1CoordinatesTR2[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && secret1CoordinatesTR3.ContainsKey(levelIndex))
            {
                secret1Coordinates = secret1CoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && secret1CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret1Coordinates = secret1CoordinatesTR4[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR5 && secret1CoordinatesTR5.ContainsKey(levelIndex))
            {
                secret1Coordinates = secret1CoordinatesTR5[levelIndex];
            }

            if (secret1Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret1Coordinates[0];
            nudYCoordinate.Value = secret1Coordinates[1];
            nudZCoordinate.Value = secret1Coordinates[2];
            nudOrientation.Value = (Int16)secret1Coordinates[3];
            nudRoom.Value = (byte)secret1Coordinates[4];
        }

        private void btnSecret2_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret2Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && secret2CoordinatesTR1.ContainsKey(levelIndex))
            {
                secret2Coordinates = secret2CoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR2 && secret2CoordinatesTR2.ContainsKey(levelIndex))
            {
                secret2Coordinates = secret2CoordinatesTR2[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && secret2CoordinatesTR3.ContainsKey(levelIndex))
            {
                secret2Coordinates = secret2CoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && secret2CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret2Coordinates = secret2CoordinatesTR4[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR5 && secret2CoordinatesTR5.ContainsKey(levelIndex))
            {
                secret2Coordinates = secret2CoordinatesTR5[levelIndex];
            }

            if (secret2Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret2Coordinates[0];
            nudYCoordinate.Value = secret2Coordinates[1];
            nudZCoordinate.Value = secret2Coordinates[2];
            nudOrientation.Value = (Int16)secret2Coordinates[3];
            nudRoom.Value = (byte)secret2Coordinates[4];
        }

        private void btnSecret3_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret3Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && secret3CoordinatesTR1.ContainsKey(levelIndex))
            {
                secret3Coordinates = secret3CoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR2 && secret3CoordinatesTR2.ContainsKey(levelIndex))
            {
                secret3Coordinates = secret3CoordinatesTR2[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && secret3CoordinatesTR3.ContainsKey(levelIndex))
            {
                secret3Coordinates = secret3CoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && secret3CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret3Coordinates = secret3CoordinatesTR4[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR5 && secret3CoordinatesTR5.ContainsKey(levelIndex))
            {
                secret3Coordinates = secret3CoordinatesTR5[levelIndex];
            }

            if (secret3Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret3Coordinates[0];
            nudYCoordinate.Value = secret3Coordinates[1];
            nudZCoordinate.Value = secret3Coordinates[2];
            nudOrientation.Value = (Int16)secret3Coordinates[3];
            nudRoom.Value = (byte)secret3Coordinates[4];
        }

        private void btnSecret4_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret4Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && secret4CoordinatesTR1.ContainsKey(levelIndex))
            {
                secret4Coordinates = secret4CoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && secret4CoordinatesTR3.ContainsKey(levelIndex))
            {
                secret4Coordinates = secret4CoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && secret4CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret4Coordinates = secret4CoordinatesTR4[levelIndex];
            }

            if (secret4Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret4Coordinates[0];
            nudYCoordinate.Value = secret4Coordinates[1];
            nudZCoordinate.Value = secret4Coordinates[2];
            nudOrientation.Value = (Int16)secret4Coordinates[3];
            nudRoom.Value = (byte)secret4Coordinates[4];
        }

        private void btnSecret5_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret5Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR1 && secret5CoordinatesTR1.ContainsKey(levelIndex))
            {
                secret5Coordinates = secret5CoordinatesTR1[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR3 && secret5CoordinatesTR3.ContainsKey(levelIndex))
            {
                secret5Coordinates = secret5CoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && secret5CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret5Coordinates = secret5CoordinatesTR4[levelIndex];
            }

            if (secret5Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret5Coordinates[0];
            nudYCoordinate.Value = secret5Coordinates[1];
            nudZCoordinate.Value = secret5Coordinates[2];
            nudOrientation.Value = (Int16)secret5Coordinates[3];
            nudRoom.Value = (byte)secret5Coordinates[4];
        }

        private void btnSecret6_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret6Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR3 && secret6CoordinatesTR3.ContainsKey(levelIndex))
            {
                secret6Coordinates = secret6CoordinatesTR3[levelIndex];
            }
            else if (SELECTED_TAB == TAB_TR4 && secret6CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret6Coordinates = secret6CoordinatesTR4[levelIndex];
            }

            if (secret6Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret6Coordinates[0];
            nudYCoordinate.Value = secret6Coordinates[1];
            nudZCoordinate.Value = secret6Coordinates[2];
            nudOrientation.Value = (Int16)secret6Coordinates[3];
            nudRoom.Value = (byte)secret6Coordinates[4];
        }

        private void btnSecret7_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret7Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR4 && secret7CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret7Coordinates = secret7CoordinatesTR4[levelIndex];
            }

            if (secret7Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret7Coordinates[0];
            nudYCoordinate.Value = secret7Coordinates[1];
            nudZCoordinate.Value = secret7Coordinates[2];
            nudOrientation.Value = (Int16)secret7Coordinates[3];
            nudRoom.Value = (byte)secret7Coordinates[4];
        }

        private void btnSecret8_Click(object sender, EventArgs e)
        {
            byte levelIndex = GetLevelIndex();
            Int32[] secret8Coordinates = new Int32[4];

            if (SELECTED_TAB == TAB_TR4 && secret8CoordinatesTR4.ContainsKey(levelIndex))
            {
                secret8Coordinates = secret8CoordinatesTR4[levelIndex];
            }

            if (secret8Coordinates.Length < 5)
            {
                return;
            }

            nudXCoordinate.Value = secret8Coordinates[0];
            nudYCoordinate.Value = secret8Coordinates[1];
            nudZCoordinate.Value = secret8Coordinates[2];
            nudOrientation.Value = (Int16)secret8Coordinates[3];
            nudRoom.Value = (byte)secret8Coordinates[4];
        }

        private void EnableEndOfLevelButtonConditionally()
        {
            byte levelIndex = GetLevelIndex();

            if (SELECTED_TAB == TAB_TR1)
            {
                btnEndOfLevel.Enabled = true;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                btnEndOfLevel.Enabled = endOfLevelCoordinatesTR2.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                btnEndOfLevel.Enabled = endOfLevelCoordinatesTR3.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                btnEndOfLevel.Enabled = endOfLevelCoordinatesTR4.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                btnEndOfLevel.Enabled = endOfLevelCoordinatesTR5.ContainsKey(levelIndex);
            }
        }

        private void EnableStartOfLevelButtonConditionally()
        {
            byte levelIndex = GetLevelIndex();

            if (SELECTED_TAB == TAB_TR1)
            {
                btnStartOfLevel.Enabled = startOfLevelCoordinatesTR1.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                btnStartOfLevel.Enabled = startOfLevelCoordinatesTR2.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                btnStartOfLevel.Enabled = startOfLevelCoordinatesTR3.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                btnStartOfLevel.Enabled = startOfLevelCoordinatesTR4.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                btnStartOfLevel.Enabled = startOfLevelCoordinatesTR5.ContainsKey(levelIndex);
            }
        }

        private void EnableSecretButtonsConditionally()
        {
            byte levelIndex = GetLevelIndex();

            if (SELECTED_TAB == TAB_TR1)
            {
                btnSecret1.Enabled = secret1CoordinatesTR1.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR1.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR1.ContainsKey(levelIndex);
                btnSecret4.Enabled = secret4CoordinatesTR1.ContainsKey(levelIndex);
                btnSecret5.Enabled = secret5CoordinatesTR1.ContainsKey(levelIndex);
                btnSecret6.Enabled = false;
                btnSecret7.Enabled = false;
                btnSecret8.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                btnSecret1.Enabled = secret1CoordinatesTR2.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR2.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR2.ContainsKey(levelIndex);
                btnSecret4.Enabled = false;
                btnSecret5.Enabled = false;
                btnSecret6.Enabled = false;
                btnSecret7.Enabled = false;
                btnSecret8.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                btnSecret1.Enabled = secret1CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret4.Enabled = secret4CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret5.Enabled = secret5CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret6.Enabled = secret6CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret7.Enabled = false;
                btnSecret8.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                btnSecret1.Enabled = secret1CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret4.Enabled = secret4CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret5.Enabled = secret5CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret6.Enabled = secret6CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret7.Enabled = secret7CoordinatesTR4.ContainsKey(levelIndex);
                btnSecret8.Enabled = secret8CoordinatesTR4.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                btnSecret1.Enabled = secret1CoordinatesTR5.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR5.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR5.ContainsKey(levelIndex);
                btnSecret4.Enabled = false;
                btnSecret5.Enabled = false;
                btnSecret6.Enabled = false;
                btnSecret7.Enabled = false;
                btnSecret8.Enabled = false;
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

        private readonly Dictionary<byte, Int32[]> startOfLevelCoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 75264, 3072, 3584, 0, 0         } },    // Caves
            { 2,  new Int32[] { 78336, -1024, 12800, 0, 90      } },    // City of Vilcabamba
            { 3,  new Int32[] { 27136, -256, 77312, 180, 0      } },    // Lost Valley
            { 4,  new Int32[] { 46592, 6272, 64000, 90, 19      } },    // Tomb of Qualopec
            { 5,  new Int32[] { 17920, 0, 40448, 90, 55         } },    // St. Francis' Folly
            { 6,  new Int32[] { 79360, 0, 34304, 0, 59          } },    // Colosseum
            { 7,  new Int32[] { 50688, -2304, 42084, 0, 11      } },    // Palace Midas
            { 8,  new Int32[] { 46592, -8448, 76288, 180, 137   } },    // The Cistern
            { 9,  new Int32[] { 57856, -3328, 1536, 0, 19       } },    // Tomb of Tihocan
            { 10, new Int32[] { 27136, 0, 6656, 0, 0            } },    // City of Khamoon
            { 11, new Int32[] { 45568, 0, 37376, 0, 24          } },    // Obelisk of Khamoon
            { 12, new Int32[] { 9728, -512, 49664, 90, 60       } },    // Sanctuary of the Scion
            { 13, new Int32[] { 49664, -4096, 3168, 0, 86       } },    // Natla's Mines
            { 14, new Int32[] { 57856, 10240, 11776, 0, 12      } },    // Atlantis
            { 15, new Int32[] { 58880, -15616, 11776, 90, 36    } },    // The Great Pyramid
            { 16, new Int32[] { 38400, -12460, 9728, 0, 0       } },    // Return to Egypt
            { 17, new Int32[] { 96768, 0, 57856, 90, 26         } },    // Temple of the Cat
            { 18, new Int32[] { 51812, -30773, 64000, 90, 15    } },    // Atlantean Stronghold
            { 19, new Int32[] { 32256, -3584, 44544, 180, 17    } },    // The Hive
        };

        private readonly Dictionary<byte, Int32[]> startOfLevelCoordinatesTR2 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 64176, 5376, 26090, 0, 35       } },    // The Great Wall
            { 2,  new Int32[] { 58880, 0, 23188, 0, 0           } },    // Venice
            { 3,  new Int32[] { 72523, 4608, 41024, 270, 106    } },    // Bartoli's Hideout
            { 4,  new Int32[] { 79360, 2816, 31212, 0, 35       } },    // Opera House
            { 5,  new Int32[] { 46592, -1536, 90624, 90, 4      } },    // Offshore Rig
            { 6,  new Int32[] { 49664, -256, 57856, 180, 37     } },    // Diving Area
            { 7,  new Int32[] { 28160, -4096, 41472, 90, 0      } },    // 40 Fathoms
            { 8,  new Int32[] { 66048, -4352, 29184, 0, 113     } },    // Wreck of the Maria Doria
            { 9,  new Int32[] { 92672, 5376, 79360, 270, 4      } },    // Living Quarters
            { 10, new Int32[] { 48640, -2048, 52736, 90, 40     } },    // The Deck
            { 11, new Int32[] { 95322, -256, 17920, 90, 76      } },    // Tibetan Foothills
            { 12, new Int32[] { 96768, 3455, 16896, 270, 128    } },    // Barkhang Monastery
            { 13, new Int32[] { 3584, -5632, 36352, 90, 0       } },    // Catacombs of the Talion
            { 14, new Int32[] { 61952, 7936, 66048, 0, 42       } },    // Ice Palace
            { 15, new Int32[] { 7680, -22784, 81408, 180, 190   } },    // Temple of Xian
            { 16, new Int32[] { 82432, -9216, 55808, 270, 8     } },    // Floating Islands
            { 17, new Int32[] { 73216, -9472, 78336, 180, 17    } },    // The Dragon's Lair
            { 18, new Int32[] { 34304, 256, 62976, 180, 52      } },    // Home Sweet Home
            { 19, new Int32[] { 88576, -3828, 57856, 270, 32    } },    // The Cold War
            { 20, new Int32[] { 80384, 5888, 54784, 270, 53     } },    // Fool's Gold
            { 21, new Int32[] { 68096, -10166, 24064, 180, 65   } },    // Furnace of the Gods
            { 22, new Int32[] { 38400, 0, 48640, 270, 0         } },    // Kingdom
            { 23, new Int32[] { 66048, -256, 50688, 90, 28      } },    // Nightmare in Vegas
        };

        private readonly Dictionary<byte, Int32[]> startOfLevelCoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 28160, -256, 28160, 0, 4        } },    // Jungle
            { 2,  new Int32[] { 94720, -512, 26112, 270, 18     } },    // Temple Ruins
            { 3,  new Int32[] { 84480, -256, 58880, 0, 1        } },    // The River Ganges
            { 4,  new Int32[] { 3584, -15360, 47616, 90, 20     } },    // Caves of Kaliya
            { 5,  new Int32[] { 18944, 1280, 18603, 0, 7        } },    // Costal Village
            { 6,  new Int32[] { 11776, -5376, 74240, 135, 90    } },    // Crash Site
            { 7,  new Int32[] { 73216, -25984, 55808, 180, 50   } },    // Madubu Gorge
            { 8,  new Int32[] { 46592, -8839, 59928, 180, 0     } },    // Temple of Puna
            { 9,  new Int32[] { 41472, -21504, 41472, 90, 52    } },    // Thames Wharf
            { 10, new Int32[] { 71587, -10309, 98816, 90, 157   } },    // Aldwych
            { 11, new Int32[] { 81408, -17920, 39424, 270, 36   } },    // Lud's Gate
            { 12, new Int32[] { 51712, 0, 50688, 270, 4         } },    // City
            { 13, new Int32[] { 23040, -1183, 5858, 0, 0        } },    // Nevada Desert
            { 14, new Int32[] { 17334, 0, 23294, 270, 2         } },    // High Security Compound
            { 15, new Int32[] { 64000, 3072, 52736, 0, 31       } },    // Area 51
            { 16, new Int32[] { 32256, -3713, 4608, 0, 12       } },    // Antarctica
            { 17, new Int32[] { 59904, 1024, 25088, 90, 40      } },    // RX-Tech Mines
            { 18, new Int32[] { 98816, 0, 69120, 270, 9         } },    // Lost City of Tinnos
            { 19, new Int32[] { 61952, -512, 62976, 270, 5      } },    // Meteorite Cavern
            { 20, new Int32[] { 57306, -17125, 55808, 270, 40   } },    // All Hallows
            { 21, new Int32[] { 92672, -3072, 41472, 290, 107   } },    // Highland Fling
            { 22, new Int32[] { 25088, -5120, 61952, 0, 77      } },    // Willard's Lair
            { 23, new Int32[] { 41472, 6912, 73216, 135, 24     } },    // Shakespeare Cliff
            { 24, new Int32[] { 61952, 128, 25088, 270, 1       } },    // Sleeping with the Fishes
            { 25, new Int32[] { 78261, 6363, 47471, 180, 27     } },    // It's a Madhouse!
            { 26, new Int32[] { 44544, 4864, 51101, 180, 68     } },    // Reunion
        };

        private readonly Dictionary<byte, Int32[]> startOfLevelCoordinatesTR4 = new Dictionary<byte, Int32[]>
        {

        };

        private readonly Dictionary<byte, Int32[]> startOfLevelCoordinatesTR5 = new Dictionary<byte, Int32[]>
        {

        };

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 42911, 7168, 81358, 0, 11       } },    // Caves
            { 2,  new Int32[] { 10380, -1024, 29124, 270, 87    } },    // City of Vilcabamba
            { 3,  new Int32[] { 39962, 5895, 75273, 90, 50      } },    // Lost Valley
            { 4,  new Int32[] { 39061, 0, 60703, 0, 9           } },    // Tomb of Qualopec
            { 5,  new Int32[] { 29142, 23296, 38357, 270, 46    } },    // St. Francis' Folly
            { 6,  new Int32[] { 35304, -2304, 65138, 0, 40      } },    // Colosseum
            { 7,  new Int32[] { 19557, -4608, 19861, 270, 1     } },    // Palace Midas
            { 8,  new Int32[] { 40451, -5888, 35460, 180, 61    } },    // The Cistern
            { 9,  new Int32[] { 32276, 3840, 94965, 0, 112      } },    // Tomb of Tihocan
            { 10, new Int32[] { 44506, -3072, 37787, 180, 33    } },    // City of Khamoon
            { 11, new Int32[] { 26058, -256, 21387, 270, 9      } },    // Obelisk of Khamoon
            { 12, new Int32[] { 24941, 3072, 53569, 0, 61       } },    // Sanctuary of the Scion
            { 13, new Int32[] { 32857, -8704, 93170, 270, 82    } },    // Natla's Mines
            { 14, new Int32[] { 50073, -18688, 45543, 90, 50    } },    // Atlantis
            { 15, new Int32[] { 44711, 0, 72603, 270, 59        } },    // The Great Pyramid
            { 16, new Int32[] { 68525, -1813, 73212, 270, 78    } },    // Return to Egypt
            { 17, new Int32[] { 31973, -15104, 61952, 90, 105   } },    // Temple of the Cat
            { 18, new Int32[] { 45157, -3584, 37302, 270, 65    } },    // Atlantean Stronghold
            { 19, new Int32[] { 41573, 11264, 43109, 180, 9     } },    // The Hive
        };

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR2 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 88689, 20480, 68958, 180, 65    } },    // The Great Wall
            { 2,  new Int32[] { 25184, 251, 78543, 0, 154       } },    // Venice
            { 3,  new Int32[] { 40544, -1024, 37470, 0, 138     } },    // Bartoli's Hideout
            { 4,  new Int32[] { 53514, 6912, 49394, 270, 121    } },    // Opera House
            { 5,  new Int32[] { 38438, -256, 27539, 180, 70     } },    // Offshore Rig
            { 6,  new Int32[] { 54742, 3072, 61941, 90, 5       } },    // Diving Area
            { 7,  new Int32[] { 81295, -3584, 46423, 0, 50      } },    // 40 Fathoms
            { 8,  new Int32[] { 69941, 8571, 15852, 0, 89       } },    // Wreck of the Maria Doria
            { 9,  new Int32[] { 67684, -1818, 35154, 90, 42     } },    // Living Quarters
            { 10, new Int32[] { 35485, 1792, 15873, 130, 105    } },    // The Deck
            { 11, new Int32[] { 11722, 15616, 32039, 0, 146     } },    // Tibetan Foothills
            { 12, new Int32[] { 27388, 768, 22043, 270, 44      } },    // Barkhang Monastery
            { 13, new Int32[] { 51564, 7936, 65955, 270, 52     } },    // Catacombs of the Talion
            { 14, new Int32[] { 57937, 9984, 30156, 0, 127      } },    // Ice Palace
            { 15, new Int32[] { 17027, -24415, 61925, 270, 33   } },    // Temple of Xian
            { 16, new Int32[] { 21984, -7424, 65024, 180, 40    } },    // Floating Islands
            { 17, new Int32[] { 51123, -7187, 28285, 180, 22    } },    // The Dragon's Lair
            //{ 18, new Int32[] { 56931, 2560, 57466, 0, 1        } },  // Home Sweet Home (there is no "end of level" here)
            { 19, new Int32[] { 51066, -10239, 21074, 180, 90   } },    // The Cold War
            { 20, new Int32[] { 1544, 23552, 35616, 180, 58     } },    // Fool's Gold
            { 21, new Int32[] { 81334, 3584, 80114, 180, 90     } },    // Furnace of the Gods
            //{ 22, new Int32[] { 25965, 1792, 55397, 0, 77       } },  // Kingdom (missing level trigger for final boss)
            //{ 23, new Int32[] { 49949, -5888, 55394, 0, 44      } },  // Nightmare in Vegas (missing level trigger for final boss)
        };

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 22951, 23808, 71168, 0, 132     } },    // Jungle
            { 2,  new Int32[] { 10895, 2304, 70849, 0, 214      } },    // Temple Ruins
            { 3,  new Int32[] { 43585, 5888, 68146, 180, 167    } },    // The River Ganges
            { 4,  new Int32[] { 41083, -4864, 52861, 90, 24     } },    // Caves of Kaliya
            { 5,  new Int32[] { 73241, -5120, 79274, 180, 191   } },    // Costal Village
            { 6,  new Int32[] { 77776, -1792, 60997, 0, 41      } },    // Crash Site
            { 7,  new Int32[] { 57195, 13056, 72148, 270, 96    } },    // Madubu Gorge
            { 8,  new Int32[] { 51739, -8811, 57985, 0, 28      } },    // Temple of Puna
            { 9,  new Int32[] { 55907, -21504, 45565, 0, 0      } },    // Thames Wharf
            { 10, new Int32[] { 55028, 2560, 34299, 270, 104    } },    // Aldwych
            { 11, new Int32[] { 34488, -28160, 48438, 90, 207   } },    // Lud's Gate
            { 12, new Int32[] { 37989, -12032, 53019, 270, 14   } },    // City
            { 13, new Int32[] { 47088, -3072, 66099, 90, 113    } },    // Nevada Desert
            { 14, new Int32[] { 55160, 0, 65196, 120, 96        } },    // High Security Compound
            { 15, new Int32[] { 44438, -7424, 35311, 0, 18      } },    // Area 51
            { 16, new Int32[] { 44748, -7168, 60733, 180, 80    } },    // Antarctica
            { 17, new Int32[] { 9606, 0, 16931, 270, 3          } },    // RX-Tech Mines
            { 18, new Int32[] { 28077, 4608, 38480, 90, 211     } },    // Lost City of Tinnos (too many level triggers to jump to end)
            { 19, new Int32[] { 22709, 0, 27287, 270, 29        } },    // Meteorite Cavern
            { 20, new Int32[] { 33698, 1536, 38769, 270, 6      } },    // All Hallows
            { 21, new Int32[] { 47664, -5120, 67966, 0, 100     } },    // Highland Fling
            { 22, new Int32[] { 77238, -3840, 18147, 270, 55    } },    // Willard's Lair
            { 23, new Int32[] { 87565, 15126, 42498, 0, 104     } },    // Shakespeare Cliff
            { 24, new Int32[] { 68708, -13568, 41653, 90, 111   } },    // Sleeping with the Fishes
            { 25, new Int32[] { 94093, 5632, 34368, 90, 133     } },    // It's a Madhouse! (just need Hand of Rathmore from beginning)
            { 26, new Int32[] { 81708, 5376, 36764, 180, 62     } },    // Reunion
        };

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 33824, 616, 16352, 270, 119     } },    // Angkor Wat
            { 2,  new Int32[] { 26312, -1664, 15834, 3, 115     } },    // Race for the Iris
            { 3,  new Int32[] { 3828, 1920, 25657, 0, 57        } },    // The Tomb of Seth
            { 4,  new Int32[] { 4235, -1885, 49922, 260, 125    } },    // Burial Chambers
            //{ 5,  new Int32[] { 19153, 256, 10823, 166, 3       } },    // Valley of the Kings
            //{ 6,  new Int32[] { 29637, -911, 18061, 95, 22      } },    // KV5
            { 7,  new Int32[] { 30968, 627, 25549, 1, 7         } },    // Temple of Karnak
            { 8,  new Int32[] { 37454, -256, 24018, 2, 151      } },    // The Great Hypostyle Hall
            { 9,  new Int32[] { 24774, 3589, 27169, 0, 87       } },    // Sacred Lake
            { 11, new Int32[] { 23345, 8192, 18150, 40, 44      } },    // Tomb of Semerkhet
            { 12, new Int32[] { 14513, -416, 20941, 4, 24       } },    // Guardian of Semerkhet
            //{ 13, new Int32[] { 8795, -384, 25880, 0, 43        } },    // Desert Railroad
            { 14, new Int32[] { 26353, -2944, 16679, 178, 76    } },    // Alexandria
            { 15, new Int32[] { 23811, -3712, 10524, 176, 154   } },    // Coastal Ruins
            { 16, new Int32[] { 18282, -2688, 27283, 270, 39    } },    // Pharos, Temple of Isis
            { 17, new Int32[] { 36308, -4352, 28192, 175, 10    } },    // Cleopatra's Palaces
            { 18, new Int32[] { 11971, 0, 24454, 177, 79        } },    // Catacombs
            { 20, new Int32[] { 33295, -640, 25167, 87, 15      } },    // The Lost Library
            { 21, new Int32[] { 35011, -1280, 31945, 87, 10     } },    // Hall of Demetrius
            { 24, new Int32[] { 17812, -1152, 26793, 270, 138   } },    // Chambers of Tulun
            { 26, new Int32[] { 26843, -1920, 36441, 180, 98    } },    // Citadel Gate
            { 28, new Int32[] { 25554, 1008, 26047, 0, 95       } },    // The Sphinx Complex
            { 30, new Int32[] { 20089, -512, 27821, 270, 132    } },    // Underneath the Sphinx
            { 31, new Int32[] { 25998, -6669, 35357, 1, 110     } },    // Menkaure's Pyramid
            { 32, new Int32[] { 43658, 640, 13339, 178, 13      } },    // Inside Menkaure's Pyramid
            { 33, new Int32[] { 26383, -2296, 21790, 270, 128   } },    // The Mastabas
            { 34, new Int32[] { 18512, -7044, 40835, 270, 89    } },    // The Great Pyramid
            { 35, new Int32[] { 17370, -6969, 45209, 89, 168    } },    // Khufu's Queens Pyramids
            { 36, new Int32[] { 5137, 1024, 21236, 270, 119     } },    // Inside the Great Pyramid
            { 38, new Int32[] { 27513, 4547, 7903, 84, 13       } },    // Temple of Horus (Part 2)
        };

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR5 = new Dictionary<byte, Int32[]>
        {
            { 2,  new Int32[] { 22793, -128, 13556, 270, 70     } },    // Trajan's Markets
            { 3,  new Int32[] { 27715, 3968, 35054, 260, 70     } },    // The Colosseum     
            { 8,  new Int32[] { 24827, 0, 15994, 172, 1         } },    // Gallows Tree
            { 9,  new Int32[] { 21710, 4736, 17666, 90, 169     } },    // Labyrinth
            { 11, new Int32[] { 17121, -384, 18961, 176, 154    } },    // The 13th Floor
            { 14, new Int32[] { 25801, -1111, 19027, 178, 198   } },    // Red Alert!
        };

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 89465, 1016, 37019, 0, 5        } },    // Caves
            { 2,  new Int32[] { 66881, 3072, 44181, 1, 88       } },    // City of Vilcabamba
            { 3,  new Int32[] { 37308, 1536, 3995, 270, 31      } },    // Lost Valley
            { 4,  new Int32[] { 65434, 4608, 73827, 8, 39       } },    // Tomb of Qualopec
            { 5,  new Int32[] { 29795, -8448, 32308, 90, 52     } },    // St. Francis' Folly
            { 6,  new Int32[] { 75101, -2814, 50682, 117, 10    } },    // Colosseum
            { 7,  new Int32[] { 57552, -12032, 67054, 270, 59   } },    // Palace Midas
            { 8,  new Int32[] { 27175, -10240, 61860, 49, 3     } },    // The Cistern
            { 9,  new Int32[] { 43345, 0, 70223, 91, 6          } },    // Tomb of Tihocan
            { 10, new Int32[] { 60516, -1899, 23902, 149, 40    } },    // City of Khamoon
            { 11, new Int32[] { 54587, -5888, 46552, 94, 80     } },    // Obelisk of Khamoon
            { 12, new Int32[] { 45565, -8832, 59275, 175, 11    } },    // Sanctuary of the Scion
            { 13, new Int32[] { 62365, -12800, 37547, 270, 103  } },    // Natla's Mines
            { 14, new Int32[] { 59959, 11520, 41885, 180, 5     } },    // Atlantis
            { 15, new Int32[] { 63344, -13568, 18967, 87, 63    } },    // The Great Pyramid
            { 16, new Int32[] { 38387, -473, 20641, 0, 46       } },    // Return to Egypt
            { 17, new Int32[] { 98744, 3584, 54171, 177, 13     } },    // Temple of the Cat
            { 18, new Int32[] { 68709, -28979, 63847, 146, 15   } },    // Atlantean Stronghold
            { 19, new Int32[] { 33897, 6400, 37136, 102, 2      } },    // The Hive
        };

        private readonly Dictionary<byte, Int32[]> secret2CoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 67735, -2560, 50275, 0, 28      } },    // Caves
            { 2,  new Int32[] { 71580, -1024, 19332, 280, 21    } },    // City of Vilcabamba
            { 3,  new Int32[] { 40838, -512, 2973, 180, 31      } },    // Lost Valley
            { 4,  new Int32[] { 64593, 6400, 78743, 270, 4      } },    // Tomb of Qualopec
            { 5,  new Int32[] { 37989, 8448, 34258, 90, 11      } },    // St. Francis' Folly
            { 6,  new Int32[] { 63509, -3846, 55197, 190, 2     } },    // Colosseum
            { 7,  new Int32[] { 32315, -11008, 56421, 174, 49   } },    // Palace Midas
            { 8,  new Int32[] { 46075, 1456, 54580, 67, 0       } },    // The Cistern
            { 9,  new Int32[] { 23040, 1024, 59293, 180, 12     } },    // Tomb of Tihocan
            { 10, new Int32[] { 53092, -4430, 26176, 270, 41    } },    // City of Khamoon
            { 11, new Int32[] { 49473, -8448, 61349, 179, 42    } },    // Obelisk of Khamoon
            { 13, new Int32[] { 78312, 4352, 53417, 270, 47     } },    // Natla's Mines
            { 14, new Int32[] { 54373, 6341, 50569, 270, 20     } },    // Atlantis
            { 15, new Int32[] { 29320, -9472, 33893, 0, 23      } },    // The Great Pyramid
            { 16, new Int32[] { 91236, 0, 9741, 270, 21         } },    // Return to Egypt
            { 17, new Int32[] { 67782, -6912, 60815, 168, 27    } },    // Temple of the Cat
            { 18, new Int32[] { 13925, -12388, 48591, 84, 64    } },    // Atlantean Stronghold
        };

        private readonly Dictionary<byte, Int32[]> secret3CoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 14851, 6912, 93351, 0, 26       } },    // Caves
            { 2,  new Int32[] { 12001, -3072, 18955, 145, 79    } },    // City of Vilcabamba
            { 3,  new Int32[] { 63589, -1953, 5497, 55, 65      } },    // Lost Valley
            { 4,  new Int32[] { 39571, 7361, 56790, 270, 17     } },    // Tomb of Qualopec
            { 5,  new Int32[] { 41883, 11009, 34304, 90, 12     } },    // St. Francis' Folly
            { 6,  new Int32[] { 58764, -8448, 19345, 178, 51    } },    // Colosseum
            { 7,  new Int32[] { 64984, 0, 59627, 1, 71          } },    // Palace Midas
            { 8,  new Int32[] { 42441, -5632, 47848, 168, 81    } },    // The Cistern
            { 10, new Int32[] { 56764, 4352, 30621, 138, 54     } },    // City of Khamoon
            { 11, new Int32[] { 49985, -7680, 56421, 158, 42    } },    // Obelisk of Khamoon
            { 13, new Int32[] { 62071, 9082, 80579, 270, 102    } },    // Natla's Mines
            { 14, new Int32[] { 51922, -8960, 33654, 168, 100   } },    // Atlantis
            { 15, new Int32[] { 67934, 0, 51728, 88, 64         } },    // The Great Pyramid
            { 16, new Int32[] { 88997, -6460, 15962, 270, 20    } },    // Return to Egypt
            { 17, new Int32[] { 50082, 0, 90793, 5, 72          } },    // Temple of the Cat
        };

        private readonly Dictionary<byte, Int32[]> secret4CoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 3,  new Int32[] { 37393, -389, 97165, 44, 9       } },    // Lost Valley
            { 5,  new Int32[] { 43759, 23552, 46400, 3, 60      } },    // St. Francis' Folly
            { 17, new Int32[] { 38269, -5888, 48350, 88, 93     } },    // Temple of the Cat
        };

        private readonly Dictionary<byte, Int32[]> secret5CoordinatesTR1 = new Dictionary<byte, Int32[]>
        {
            { 3,  new Int32[] { 43411, -2304, 74652, 180, 14    } },    // Lost Valley
        };

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR2 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 62441, 853, 36520, 91, 38       } },    // The Great Wall
            { 2,  new Int32[] { 44124, 0, 29131, 86, 58         } },    // Venice
            { 3,  new Int32[] { 71123, 512, 35977, 18, 107      } },    // Bartoli's Hideout
            { 4,  new Int32[] { 63389, 6400, 36188, 260, 187    } },    // Opera House
            { 5,  new Int32[] { 21892, 1645, 94204, 175, 77     } },    // Offshore Rig
            { 6,  new Int32[] { 28165, 3840, 63589, 8, 48       } },    // Diving Area
            { 7,  new Int32[] { 66812, -5888, 76596, 19, 20     } },    // 40 Fathoms
            { 8,  new Int32[] { 66952, 4352, 39847, 0, 10       } },    // Wreck of the Maria Doria
            { 9,  new Int32[] { 76901, -4096, 88369, 15, 1      } },    // Living Quarters
            { 10, new Int32[] { 62017, 13129, 61211, 0, 24      } },    // The Deck
            { 11, new Int32[] { 78167, 0, 38231, 106, 11        } },    // Tibetan Foothills
            { 12, new Int32[] { 31425, 0, 49835, 179, 159       } },    // Barkhang Monastery
            { 13, new Int32[] { 11877, -3840, 41759, 132, 5     } },    // Catacombs of the Talion
            { 14, new Int32[] { 68019, 5632, 90211, 0, 106      } },    // Ice Palace
            { 15, new Int32[] { 18333, 13312, 55781, 270, 162   } },    // Temple of Xian
            { 16, new Int32[] { 73238, -7157, 69341, 171, 3     } },    // Floating Islands
            { 19, new Int32[] { 87600, 2749, 67225, 270, 31     } },    // The Cold War
            //{ 20, new Int32[] { 65051, 1024, 61781, 175, 48     } },  // Fool's Gold (too many level triggers)
            { 21, new Int32[] { 57801, -4608, 8924, 147, 13     } },    // Furnace of the Gods
            { 22, new Int32[] { 45545, 6912, 63918, 164, 35     } },    // Kingdom
            { 23, new Int32[] { 47626, 15360, 85915, 1, 76      } },    // Nightmare in Vegas
        };

        private readonly Dictionary<byte, Int32[]> secret2CoordinatesTR2 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 41293, 7168, 60959, 84, 54      } },    // The Great Wall
            { 2,  new Int32[] { 37749, 5101, 16083, 270, 126    } },    // Venice
            { 3,  new Int32[] { 41282, 8604, 34215, 16, 51      } },    // Bartoli's Hideout
            { 4,  new Int32[] { 68940, 7681, 49695, 270, 46     } },    // Opera House
            { 5,  new Int32[] { 21119, -8704, 71287, 0, 50      } },    // Offshore Rig
            { 6,  new Int32[] { 58785, 3484, 87611, 178, 11     } },    // Diving Area
            { 7,  new Int32[] { 89974, -4105, 71062, 113, 33    } },    // 40 Fathoms
            { 8,  new Int32[] { 58921, 1792, 101125, 179, 13    } },    // Wreck of the Maria Doria
            { 9,  new Int32[] { 54990, 1024, 73829, 180, 62     } },    // Living Quarters
            { 10, new Int32[] { 34640, -5220, 57976, 270, 93    } },    // The Deck
            { 11, new Int32[] { 31114, -1280, 96376, 2, 14      } },    // Tibetan Foothills
            { 12, new Int32[] { 45446, 924, 35353, 80, 6        } },    // Barkhang Monastery
            { 13, new Int32[] { 6727, -1024, 59718, 169, 94     } },    // Catacombs of the Talion
            { 14, new Int32[] { 73314, -1024, 68778, 7, 4       } },    // Ice Palace
            { 15, new Int32[] { 19558, 24064, 37644, 56, 23     } },    // Temple of Xian
            { 16, new Int32[] { 38242, -7168, 63049, 0, 25      } },    // Floating Islands
            { 19, new Int32[] { 67911, -8960, 47612, 88, 85     } },    // The Cold War
            { 20, new Int32[] { 68520, -1024, 56985, 73, 35     } },    // Fool's Gold
            { 21, new Int32[] { 35213, -11776, 64963, 90, 33    } },    // Furnace of the Gods
            { 22, new Int32[] { 77351, 934, 73365, 27, 46       } },    // Kingdom
            { 23, new Int32[] { 64940, 13312, 51962, 175, 46    } },    // Nightmare in Vegas
        };

        private readonly Dictionary<byte, Int32[]> secret3CoordinatesTR2 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 86384, 26112, 74257, 89, 79     } },    // The Great Wall
            { 2,  new Int32[] { 62357, -1792, 61898, 30, 91     } },    // Venice
            { 3,  new Int32[] { 38114, 256, 34146, 270, 131     } },    // Bartoli's Hideout
            { 4,  new Int32[] { 77923, 1024, 45436, 90, 189     } },    // Opera House
            { 5,  new Int32[] { 38419, 6144, 57147, 153, 109    } },    // Offshore Rig
            { 6,  new Int32[] { 52543, 5632, 57736, 170, 78     } },    // Diving Area
            { 7,  new Int32[] { 74657, -3940, 46640, 270, 68    } },    // 40 Fathoms
            { 8,  new Int32[] { 41079, 0, 48630, 270, 11        } },    // Wreck of the Maria Doria
            { 9,  new Int32[] { 45270, 2769, 72180, 12, 32      } },    // Living Quarters
            { 10, new Int32[] { 27770, -4096, 38488, 270, 82    } },    // The Deck
            { 11, new Int32[] { 76230, 10496, 19632, 78, 144    } },    // Tibetan Foothills
            { 12, new Int32[] { 46738, -2560, 24111, 90, 100    } },    // Barkhang Monastery
            { 13, new Int32[] { 45575, 1792, 67974, 161, 49     } },    // Catacombs of the Talion
            { 14, new Int32[] { 45954, 11008, 29150, 270, 7     } },    // Ice Palace
            { 15, new Int32[] { 46485, 14848, 23391, 166, 121   } },    // Temple of Xian
            { 16, new Int32[] { 35373, -10240, 54882, 177, 41   } },    // Floating Islands
            { 19, new Int32[] { 21998, -4096, 17069, 175, 81    } },    // The Cold War
            { 20, new Int32[] { 15809, 5120, 32258, 163, 94     } },    // Fool's Gold
            { 21, new Int32[] { 66210, -21673, 88461, 180, 58   } },    // Furnace of the Gods
            { 22, new Int32[] { 53847, 3690, 54704, 177, 82     } },    // Kingdom
            { 23, new Int32[] { 34406, -256, 57823, 94, 6       } },    // Nightmare in Vegas
        };

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 27465, 2939, 32501, 270, 21     } },    // Jungle
            { 2,  new Int32[] { 60023, 8192, 62828, 2, 87       } },    // Temple Ruins
            { 3,  new Int32[] { 86619, 768, 34715, 270, 18      } },    // The River Ganges
            { 5,  new Int32[] { 11365, -768, 34715, 270, 2      } },    // Coastal Village
            { 6,  new Int32[] { 32667, -1280, 82377, 90, 93     } },    // Crash Site
            { 7,  new Int32[] { 72603 , -21096, 33487, 35, 18   } },    // Madubu Gorge
            { 8,  new Int32[] { 30315, -18176, 59491, 0, 11     } },    // Temple of Puna
            { 9,  new Int32[] { 48603, -11520, 28522, 179, 148  } },    // Thames Wharf
            { 10, new Int32[] { 56423, 12800, 68509, 180, 5     } },    // Aldwych
            { 11, new Int32[] { 58267, -8704, 28929, 90, 72     } },    // Lud's Gate
            { 12, new Int32[] { 41553, -2048, 52727, 175, 8     } },    // City
            { 13, new Int32[] { 33380, -256, 32125, 4, 18       } },    // Nevada Desert
            { 14, new Int32[] { 1549, -512, 38499, 179, 54      } },    // High Security Compound
            { 15, new Int32[] { 41790, 3584, 62022, 85, 62      } },    // Area 51
            { 16, new Int32[] { 21105, -6045, 28890, 270, 163   } },    // Antarctica
            { 17, new Int32[] { 45957, 3840, 49662, 270, 186    } },    // RX-Tech Mines
            { 18, new Int32[] { 80392, -3966, 58467, 0, 46      } },    // Lost City of Tinnos
            { 21, new Int32[] { 42907, -11570, 52496, 270, 45   } },    // Highland Fling
            { 22, new Int32[] { 53637, 8704, 77308, 85, 102     } },    // Willard's Lair
            { 23, new Int32[] { 35369, -6400, 55195, 2, 36      } },    // Shakespeare Cliff
            { 24, new Int32[] { 68917, 2305, 56601, 176, 59     } },    // Sleeping with the Fishes
            { 25, new Int32[] { 57286, -256, 30032, 89, 89      } },    // It's a Madhouse!
        };

        private readonly Dictionary<byte, Int32[]> secret2CoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 25391, 17313, 57665, 8, 17      } },    // Jungle
            { 2,  new Int32[] { 42667, 3840, 19841, 88, 181     } },    // Temple Ruins
            { 3,  new Int32[] { 91465, 282, 32869, 0, 22        } },    // The River Ganges
            { 5,  new Int32[] { 14231, -7168, 76215, 148, 15    } },    // Coastal Village
            { 6,  new Int32[] { 36965, -1766, 53380, 270, 53    } },    // Crash Site
            { 7,  new Int32[] { 80943, -24293, 20684, 91, 14    } },    // Madubu Gorge
            { 9,  new Int32[] { 39666, -12288, 45979, 0, 96     } },    // Thames Wharf
            { 10, new Int32[] { 67012, -1059, 52362, 179, 57    } },    // Aldwych
            { 11, new Int32[] { 62643, -20736, 31265, 90, 17    } },    // Lud's Gate
            { 13, new Int32[] { 42909, 1280, 50651, 270, 33     } },    // Nevada Desert
            { 14, new Int32[] { 82138, -256, 7431, 82, 177      } },    // High Security Compound
            { 15, new Int32[] { 13285, 2816, 55926, 270, 55     } },    // Area 51
            { 16, new Int32[] { 51567, -6400, 26044, 270, 190   } },    // Antarctica
            //{ 17, new Int32[] { 45157, 3840, 49625, 90, 186     } },  // RX-Tech Mines (too many level triggers)
            { 18, new Int32[] { 33893, -4864, 51729, 270, 59    } },    // Lost City of Tinnos
            { 21, new Int32[] { 54784, -4864, 72134, 0, 112     } },    // Highland Fling
            { 22, new Int32[] { 67056, -512, 72603, 1, 1        } },    // Willard's Lair
            { 23, new Int32[] { 25079, 2204, 52325, 179, 67     } },    // Shakespeare Cliff
            { 24, new Int32[] { 29847, -3395, 34721, 161, 11    } },    // Sleeping with the Fishes
            { 25, new Int32[] { 39282, -2304, 59755, 3, 107     } },    // It's a Madhouse!
        };

        private readonly Dictionary<byte, Int32[]> secret3CoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 19099, 24064, 58269, 180, 135   } },    // Jungle
            { 2,  new Int32[] { 56421, 1280, 93662, 270, 125    } },    // Temple Ruins
            { 3,  new Int32[] { 56788, -3840, 25499, 1, 113     } },    // The River Ganges
            { 5,  new Int32[] { 25035, -6384, 87999, 179, 124   } },    // Coastal Village
            { 6,  new Int32[] { 70551, -6886, 27749, 162, 60    } },    // Crash Site
            { 7,  new Int32[] { 30187, 758, 54883, 126, 83      } },    // Madubu Gorge
            { 9,  new Int32[] { 44229, -19968, 51885, 180, 62   } },    // Thames Wharf
            //{ 10, new Int32[] { 48689, -4608, 39966, 0, 62      } },  // Aldwych (too many level triggers)
            { 11, new Int32[] { 43394, -22016, 28800, 177, 68   } },    // Lud's Gate
            { 13, new Int32[] { 13068, -3328, 47205, 178, 48    } },    // Nevada Desert
            { 15, new Int32[] { 46603, -6656, 41077, 270, 42    } },    // Area 51
            { 16, new Int32[] { 40442, -5120, 19822, 4, 201     } },    // Antarctica
            { 17, new Int32[] { 13597, 3656, 29356, 1, 5        } },    // RX-Tech Mines
            { 18, new Int32[] { 47934, 6144, 47565, 270, 156    } },    // Lost City of Tinnos
            { 21, new Int32[] { 14530, -3999, 65507, 91, 120    } },    // Highland Fling
            { 22, new Int32[] { 66929, -5888, 30246, 84, 81     } },    // Willard's Lair
            { 23, new Int32[] { 74467, 17921, 38413, 10, 110    } },    // Shakespeare Cliff
            { 24, new Int32[] { 54689, -5883, 31115, 89, 88     } },    // Sleeping with the Fishes
            { 25, new Int32[] { 80449, 1792, 30034, 91, 50      } },    // It's a Madhouse!
        };

        private readonly Dictionary<byte, Int32[]> secret4CoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 95333, 18944, 70002, 270, 77    } },    // Jungle
            { 2,  new Int32[] { 40459, 6968, 96815, 270, 142    } },    // Temple Ruins
            { 3,  new Int32[] { 33999, -5562, 64020, 122, 173   } },    // The River Ganges
            { 5,  new Int32[] { 26928, -659, 71547, 0, 156      } },    // Coastal Village
            { 9,  new Int32[] { 55908, -21504, 45568, 90, 0     } },    // Thames Wharf
            //{ 10, new Int32[] { 48696, -2048, 50277, 4, 15      } },  // Aldwych (too many level triggers)
            { 11, new Int32[] { 71581, -18432, 25031, 270, 54   } },    // Lud's Gate
        };

        private readonly Dictionary<byte, Int32[]> secret5CoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 89422, 24064, 57445, 178, 76    } },    // Jungle
            { 3,  new Int32[] { 42075, 4810, 79061, 84, 162     } },    // The River Ganges
            { 9,  new Int32[] { 51301, -14848, 56743, 89, 180   } },    // Thames Wharf
            //{ 10, new Int32[] { 48335, -3328, 66778, 28, 55     } },  // Aldwych (too many level triggers)
            { 11, new Int32[] { 46851, -3002, 37141, 16, 134    } },    // Lud's Gate
        };

        private readonly Dictionary<byte, Int32[]> secret6CoordinatesTR3 = new Dictionary<byte, Int32[]>
        {
            { 1,  new Int32[] { 82252, 26624, 63587, 0, 99      } },    // Jungle
            { 11, new Int32[] { 56161, -2614, 22934, 16, 102    } },    // Lud's Gate
        };

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 4325, 640, 41774, 173, 20       } },    // Angkor Wat
            {  3, new Int32[] { 33123, -2790, 18381, 4, 34      } },    // The Tomb of Seth
            {  5, new Int32[] { 46734, -640, 16946, 173, 2      } },    // Valley of the Kings
            {  6, new Int32[] { 5924, -640, 11314, 179, 63      } },    // KV5
            {  7, new Int32[] { 40397, 0, 18257, 90, 16         } },    // Temple of Karnak
            {  9, new Int32[] { 27900, 3140, 6404, 90, 46       } },    // Sacred Lake
            { 11, new Int32[] { 31282, -1408, 26932, 270, 18    } },    // Tomb of Semerkhet
            { 12, new Int32[] { 33650, -1024, 16846, 180, 63    } },    // Guardian of Semerkhet
            { 13, new Int32[] { 44494, -768, 26384, 270, 146    } },    // Desert Railroad
            { 14, new Int32[] { 22276, -3072, 18641, 176, 20    } },    // Alexandria
            { 17, new Int32[] { 31465, -2560, 38132, 0, 1       } },    // Cleopatra's Palaces
            { 18, new Int32[] { 16665, -2560, 21760, 0, 64      } },    // Catacombs
            { 19, new Int32[] { 42175, 1280, 30770, 162, 80     } },    // Temple of Poseidon
            { 20, new Int32[] { 22738, 4992, 27614, 177, 46     } },    // The Lost Library
            //{ 22, new Int32[] { 23286, 1920, 17042, 179, 137    } },    // City of the Dead
            { 24, new Int32[] { 29489, -1024, 35113, 82, 57     } },    // Chambers of Tulun
            { 25, new Int32[] { 33625, -2432, 26460, 174, 3     } },    // Street Bazaar
            { 26, new Int32[] { 26051, -2176, 26128, 0, 57      } },    // Citadel Gate
            { 27, new Int32[] { 23321, 512, 26011, 180, 19      } },    // Citadel
            //{ 28, new Int32[] { 35285, 384, 34890, 115, 10      } },    // The Sphinx Complex
            { 30, new Int32[] { 36594, -512, 23073, 177, 61     } },    // Underneath the Sphinx
            { 31, new Int32[] { 25367, -8192, 34051, 71, 118    } },    // Menkaure's Pyramid
            { 32, new Int32[] { 43181, -896, 16118, 180, 116    } },    // Inside Menkaure's Pyramid
            { 33, new Int32[] { 11314, -1664, 5888, 90, 29      } },    // The Mastabas
            { 34, new Int32[] { 23152, -1664, 26883, 270, 43    } },    // The Great Pyramid
            { 35, new Int32[] { 12032, -2688, 18784, 180, 129   } },    // Khufu's Queens Pyramids
            { 36, new Int32[] { 7414, -3328, 14093, 175, 4      } },    // Inside the Great Pyramid
        };

        private readonly Dictionary<byte, Int32[]> secret2CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 8473, 2944, 32486, 87, 144      } },    // Angkor Wat
            {  3, new Int32[] { 20639, 3072, 20212, 270, 58     } },    // The Tomb of Seth
            //{  4, new Int32[] { 737, -1280, 21965, 33, 21       } },    // Burial Chambers
            {  6, new Int32[] { 21553, -4224, 14575, 90, 33     } },    // KV5
            {  7, new Int32[] { 29107, 3200, 30158, 180, 91     } },    // Temple of Karnak
            { 11, new Int32[] { 40398, -2560, 36009, 270, 51    } },    // Tomb of Semerkhet
            { 12, new Int32[] { 38321, 512, 23245, 87, 57       } },    // Guardian of Semerkhet
            //{ 13, new Int32[] { 32726, -384, 26685, 157, 94     } },    // Desert Railroad
            { 18, new Int32[] { 23349, -6656, 32446, 81, 86     } },    // Catacombs
            { 20, new Int32[] { 8403, 3200, 18783, 176, 180     } },    // The Lost Library
            { 24, new Int32[] { 27707, -1024, 25709, 110, 88    } },    // Chambers of Tulun
            { 27, new Int32[] { 27598, 2944, 44841, 270, 72     } },    // Citadel
        };

        private readonly Dictionary<byte, Int32[]> secret3CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 19235, 1664, 26829, 3, 73       } },    // Angkor Wat
            {  3, new Int32[] { 15267, -1024, 17503, 175, 1     } },    // The Tomb of Seth
            {  4, new Int32[] { 16053, 128, 37837, 180, 89      } },    // Burial Chambers
            {  5, new Int32[] { 14898, 2432, 17100, 90, 38      } },    // Valley of the Kings
            {  6, new Int32[] { 28360, -256, 2982, 180, 87      } },    // KV5
            {  7, new Int32[] { 29854, 3256, 32659, 270, 75     } },    // Temple of Karnak
            { 11, new Int32[] { 33681, 5504, 25506, 170, 26     } },    // Tomb of Semerkhet
            //{ 12, new Int32[] { 22480, -1920, 13939, 90, 33     } },    // Guardian of Semerkhet (need to fix)
            //{ 13, new Int32[] { 9277, -384, 26736, 86, 1        } },    // Desert Railroad
            { 18, new Int32[] { 22735, -6144, 32972, 81, 56     } },    // Catacombs
            { 20, new Int32[] { 26455, 512, 17719, 0, 37        } },    // The Lost Library
        };

        private readonly Dictionary<byte, Int32[]> secret4CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 28985, 2249, 24731, 29, 68      } },    // Angkor Wat
            {  3, new Int32[] { 15267, -1024, 17503, 175, 1     } },    // The Tomb of Seth
            {  4, new Int32[] { 15821, 512, 40181, 90, 111      } },    // Burial Chambers
            //{  6, new Int32[] { 17439, 21064, 45006, 14, 255    } },    // KV5 (need to re-examine this one)
            {  7, new Int32[] { 33742, -1024, 35099, 0, 71      } },    // Temple of Karnak
            { 11, new Int32[] { 31281, 11776, 28126, 90, 111    } },    // Tomb of Semerkhet
            { 18, new Int32[] { 20132, -2048, 37603, 270, 37    } },    // Catacombs
        };

        private readonly Dictionary<byte, Int32[]> secret5CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 28917, -1920, 29431, 134, 91    } },    // Angkor Wat
            {  3, new Int32[] { 3992, -1314, 26487, 270, 13     } },    // The Tomb of Seth
            {  4, new Int32[] { 7117, -768, 43639, 115, 54      } },    // Burial Chambers
            { 11, new Int32[] { 24332, 11008, 17695, 178, 128   } },    // Tomb of Semerkhet
        };

        private readonly Dictionary<byte, Int32[]> secret6CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 44294, 384, 30474, 101, 158     } },    // Angkor Wat
            { 11, new Int32[] { 27832, 14848, 16719, 270, 194   } },    // Tomb of Semerkhet
        };

        private readonly Dictionary<byte, Int32[]> secret7CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 48359, 384, 31992, 89, 170      } },    // Angkor Wat
            //{ 11, new Int32[] { 26573, 7552, 19127, 87, 133     } },    // Tomb of Semerkhet (need to fix)
        };

        private readonly Dictionary<byte, Int32[]> secret8CoordinatesTR4 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 38029, -256, 19192, 97, 42      } },    // Angkor Wat
        };

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR5 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 19160, 0, 13542, 178, 215       } },    // Streets of Rome
            {  2, new Int32[] { 42415, 1664, 17386, 150, 22     } },    // Trajan's Markets
            {  3, new Int32[] { 40738, 2432, 28419, 14, 112     } },    // The Colosseum
            {  4, new Int32[] { 33817, -1024, 21649, 94, 23     } },    // The Base
            {  5, new Int32[] { 33783, 3840, 26797, 92, 5       } },    // The Submarine
            //{  6, new Int32[] { 8508, 31382, 48141, 4, 62       } },    // Deepsea Dive
            {  7, new Int32[] { 30841, 2048, 23005, 158, 115    } },    // Sinking Submarine
            {  8, new Int32[] { 25284, 3072, 21690, 36, 53      } },    // Gallows Tree
            {  9, new Int32[] { 21068, 3840, 10496, 270, 162    } },    // Labyrinth
            { 10, new Int32[] { 35365, 2176, 14548, 100, 199    } },    // Old Mill
            { 11, new Int32[] { 17672, 896, 16585, 92, 6        } },    // The 13th Floor
            { 12, new Int32[] { 18629, -7680, 36575, 84, 148    } },    // Escape with the Iris
            //{ 14, new Int32[] { 27824, 3584, 37978, 82, 206     } },    // Red Alert!
        };

        private readonly Dictionary<byte, Int32[]> secret2CoordinatesTR5 = new Dictionary<byte, Int32[]>
        {
            {  1, new Int32[] { 23822, 0, 28862, 105, 217       } },    // Streets of Rome
            {  2, new Int32[] { 19233, 128, 21905, 22, 101      } },    // Trajan's Markets
            {  3, new Int32[] { 15629, 768, 17392, 10, 81       } },    // The Colosseum
            {  4, new Int32[] { 11313, -2688, 13654, 90, 146    } },    // The Base
            {  5, new Int32[] { 26969, 512, 20345, 180, 19      } },    // The Submarine
            {  7, new Int32[] { 25853, 512, 33508, 270, 54      } },    // Sinking Submarine
            {  8, new Int32[] { 32955, 3456, 31319, 37, 114     } },    // Gallows Tree
            {  9, new Int32[] { 19319, 9344, 22196, 270, 103    } },    // Labyrinth
            { 10, new Int32[] { 13390, 5248, 22085, 173, 188    } },    // Old Mill
            { 11, new Int32[] { 12231, -2560, 26784, 85, 143    } },    // The 13th Floor
            { 12, new Int32[] { 24075, 0, 34033, 96, 122        } },    // Escape with the Iris
            { 14, new Int32[] { 44033, -128, 29863, 270, 78     } },    // Red Alert!
        };

        private readonly Dictionary<byte, Int32[]> secret3CoordinatesTR5 = new Dictionary<byte, Int32[]>
        {
            //{  1, new Int32[] { 23822, -3072, 36313, 4, 166     } },    // Streets of Rome
            {  2, new Int32[] { 35974, 0, 23808, 270, 219       } },    // Trajan's Markets
            {  3, new Int32[] { 33565, 3968, 35597, 12, 120     } },    // The Colosseum
            {  4, new Int32[] { 9931, 1024, 25864, 90, 76       } },    // The Base
            {  5, new Int32[] { 34369, -256, 30870, 90, 15      } },    // The Submarine
            {  8, new Int32[] { 16166, 5632, 28435, 270, 206    } },    // Gallows Tree
            {  9, new Int32[] { 18674, 6016, 25793, 1, 251      } },    // Labyrinth
            { 10, new Int32[] { 14059, 5248, 14798, 180, 197    } },    // Old Mill
            { 11, new Int32[] { 17217, 128, 29881, 2, 136       } },    // The 13th Floor
            { 12, new Int32[] { 22888, -3072, 35215, 270, 167   } },    // Escape with the Iris
            { 14, new Int32[] { 14106, 256, 20740, 87, 216      } },    // Red Alert!
        };

        private void DetermineOffsets()
        {
            if (SELECTED_TAB == TAB_TR1)
            {
                LEVEL_INDEX_OFFSET = 0x62C;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                LEVEL_INDEX_OFFSET = 0x628;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                LEVEL_INDEX_OFFSET = 0x8D6;
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                LEVEL_INDEX_OFFSET = 0x26F;
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                LEVEL_INDEX_OFFSET = 0x26F;
            }

            if (SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3)
            {
                X_COORDINATE_OFFSET = healthOffset - 0x24;
                Y_COORDINATE_OFFSET = healthOffset - 0x20;
                Z_COORDINATE_OFFSET = healthOffset - 0x1C;
                ORIENTATION_OFFSET = healthOffset - 0x16;
                ROOM_OFFSET = healthOffset - 0x10;
            }
            else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
            {
                X_COORDINATE_OFFSET = healthOffset - 0x10;
                Y_COORDINATE_OFFSET = healthOffset - 0xE;
                Z_COORDINATE_OFFSET = healthOffset - 0xC;
                ORIENTATION_OFFSET = healthOffset - 0x9;
                ROOM_OFFSET = healthOffset - 0xA;
            }
        }

        private void SetNUDRanges()
        {
            if (SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3)
            {
                nudXCoordinate.Maximum = Int32.MaxValue;
                nudXCoordinate.Minimum = Int32.MinValue;

                nudYCoordinate.Maximum = Int32.MaxValue;
                nudYCoordinate.Minimum = Int32.MinValue;

                nudZCoordinate.Maximum = Int32.MaxValue;
                nudZCoordinate.Minimum = Int32.MinValue;
            }
            else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
            {
                nudXCoordinate.Maximum = UInt16.MaxValue;
                nudXCoordinate.Minimum = UInt16.MinValue;

                nudYCoordinate.Maximum = Int16.MaxValue;
                nudYCoordinate.Minimum = Int16.MinValue;

                nudZCoordinate.Maximum = UInt16.MaxValue;
                nudZCoordinate.Minimum = UInt16.MinValue;
            }
        }

        private Int32 GetXCoordinateI32()
        {
            return ReadInt32(savegameOffset + X_COORDINATE_OFFSET);
        }

        private Int32 GetYCoordinateI32()
        {
            return ReadInt32(savegameOffset + Y_COORDINATE_OFFSET);
        }

        private Int32 GetZCoordinateI32()
        {
            return ReadInt32(savegameOffset + Z_COORDINATE_OFFSET);
        }

        private UInt16 GetXCoordinateU16()
        {
            return ReadUInt16(savegameOffset + X_COORDINATE_OFFSET);
        }

        private Int32 GetYCoordinateI16()
        {
            return ReadInt16(savegameOffset + Y_COORDINATE_OFFSET);
        }

        private UInt16 GetZCoordinateU16()
        {
            return ReadUInt16(savegameOffset + Z_COORDINATE_OFFSET);
        }

        private Int16 GetOrientation()
        {
            Int16 rawValue = ReadInt16(savegameOffset + ORIENTATION_OFFSET);
            double degrees = rawValue * 180.0 / Int16.MaxValue;

            return (degrees >= 0) ? (Int16)degrees : (Int16)(-degrees);
        }

        private byte GetRoom()
        {
            return ReadByte(savegameOffset + ROOM_OFFSET);
        }

        private void WriteXCoordinateI32(Int32 value)
        {
            WriteInt32(savegameOffset + X_COORDINATE_OFFSET, value);
        }

        private void WriteYCoordinateI32(Int32 value)
        {
            WriteInt32(savegameOffset + Y_COORDINATE_OFFSET, value);
        }

        private void WriteZCoordinateI32(Int32 value)
        {
            WriteInt32(savegameOffset + Z_COORDINATE_OFFSET, value);
        }

        private void WriteYCoordinateI16(Int16 value)
        {
            WriteInt16(savegameOffset + Y_COORDINATE_OFFSET, value);
        }

        private void WriteXCoordinateU16(UInt16 value)
        {
            WriteUInt16(savegameOffset + X_COORDINATE_OFFSET, value);
        }

        private void WriteZCoordinateU16(UInt16 value)
        {
            WriteUInt16(savegameOffset + Z_COORDINATE_OFFSET, value);
        }

        private void WriteOrientation(Int16 value)
        {
            Int16 rawValue = (Int16)(value * Int16.MaxValue / 180.0);
            WriteInt16(savegameOffset + ORIENTATION_OFFSET, rawValue);
        }

        private void WriteRoom(byte value)
        {
            WriteByte(savegameOffset + ROOM_OFFSET, value);
        }

        private void DisplayCoordinates()
        {
            isLoading = true;

            try
            {
                if (!IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtons();
                    this.Close();
                    return;
                }

                if (SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3)
                {
                    nudXCoordinate.Value = GetXCoordinateI32();
                    nudYCoordinate.Value = GetYCoordinateI32();
                    nudZCoordinate.Value = GetZCoordinateI32();
                    nudOrientation.Value = GetOrientation();
                    nudRoom.Value = GetRoom();
                }
                else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
                {
                    nudXCoordinate.Value = GetXCoordinateU16();
                    nudYCoordinate.Value = GetYCoordinateI16();
                    nudZCoordinate.Value = GetZCoordinateU16();
                    nudOrientation.Value = GetOrientation();
                    nudRoom.Value = GetRoom();
                }

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
                if (!IsSavegamePresent())
                {
                    string errorMessage = $"Savegame no longer present.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtons();
                    this.Close();
                    return;
                }

                if (backupBeforeSaving)
                {
                    CreateBackup();
                }

                File.SetAttributes(savegamePath, File.GetAttributes(savegamePath) & ~FileAttributes.ReadOnly);

                if (SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3)
                {
                    WriteXCoordinateI32((Int32)nudXCoordinate.Value);
                    WriteYCoordinateI32((Int32)nudYCoordinate.Value);
                    WriteZCoordinateI32((Int32)nudZCoordinate.Value);
                    WriteOrientation((Int16)nudOrientation.Value);
                    WriteRoom((byte)nudRoom.Value);
                }
                else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
                {
                    WriteXCoordinateU16((UInt16)nudXCoordinate.Value);
                    WriteYCoordinateI16((Int16)nudYCoordinate.Value);
                    WriteZCoordinateU16((UInt16)nudZCoordinate.Value);
                    WriteOrientation((Int16)nudOrientation.Value);
                    WriteRoom((byte)nudRoom.Value);
                }

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

        private void nudRoom_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudOrientation_ValueChanged(object sender, EventArgs e)
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

        private void nudRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudOrientation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }
    }
}
