using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class PositionForm : Form
    {
        // Offsets
        private const int slotStatusOffset = 0x004;
        private int levelIndexOffset;
        private int xCoordinateOffset;
        private int yCoordinateOffset;
        private int zCoordinateOffset;
        private int orientationOffset;
        private int roomOffset;

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
            return ReadByte(savegameOffset + slotStatusOffset) != 0;
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
            else if (SELECTED_TAB == TAB_TR5 && secret1CoordinatesTR5.ContainsKey(levelIndex))
            {
                secret1Coordinates = secret1CoordinatesTR5[levelIndex];
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

            nudXCoordinate.Value = secret6Coordinates[0];
            nudYCoordinate.Value = secret6Coordinates[1];
            nudZCoordinate.Value = secret6Coordinates[2];
            nudOrientation.Value = (Int16)secret6Coordinates[3];
            nudRoom.Value = (byte)secret6Coordinates[4];
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
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                btnSecret1.Enabled = secret1CoordinatesTR2.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR2.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR2.ContainsKey(levelIndex);
                btnSecret4.Enabled = false;
                btnSecret5.Enabled = false;
                btnSecret6.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                btnSecret1.Enabled = secret1CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret2.Enabled = secret2CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret3.Enabled = secret3CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret4.Enabled = secret4CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret5.Enabled = secret5CoordinatesTR3.ContainsKey(levelIndex);
                btnSecret6.Enabled = secret6CoordinatesTR3.ContainsKey(levelIndex);
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                btnSecret1.Enabled = false;
                btnSecret2.Enabled = false;
                btnSecret3.Enabled = false;
                btnSecret4.Enabled = false;
                btnSecret5.Enabled = false;
                btnSecret6.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                btnSecret1.Enabled = secret1CoordinatesTR5.ContainsKey(levelIndex);
                btnSecret2.Enabled = false;
                btnSecret3.Enabled = false;
                btnSecret4.Enabled = false;
                btnSecret5.Enabled = false;
                btnSecret6.Enabled = false;
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
            { 12, new Int32[] { 14513, -416, 20941, 4, 24       } },    // Guardian of Semerkhet
            { 14, new Int32[] { 26353, -2944, 16679, 178, 76    } },    // Alexandria
            { 15, new Int32[] { 23811, -3712, 10524, 176, 154   } },    // Coastal Ruins
            { 18, new Int32[] { 11971, 0, 24454, 177, 79        } },    // Catacombs
        };

        private readonly Dictionary<byte, Int32[]> endOfLevelCoordinatesTR5 = new Dictionary<byte, Int32[]>
        {
            { 2,  new Int32[] { 22793, -128, 13556, 270, 70     } },    // Trajan's Markets
            { 3,  new Int32[] { 27715, 3968, 35054, 260, 70     } },    // The Colosseum     
            //{ 8,  new Int32[] { 16052, 0, 24786, 172, 1         } },    // Gallows Tree (TODO: fix signage)
            //{ 9,  new Int32[] { 17664, 4736, 21664, 90, 169     } },    // Labyrinth (TODO: fix signage)
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

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR5 = new Dictionary<byte, Int32[]>
        {
            { 11, new Int32[] { 17672, 896, 16585, 92, 6        } },    // The 13th Floor
            { 12, new Int32[] { 18629, -7680, 36575, 84, 148    } },    // Escape with the Iris
        };

        private void DetermineOffsets()
        {
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
            else if (SELECTED_TAB == TAB_TR4)
            {
                levelIndexOffset = 0x26F;
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                levelIndexOffset = 0x26F;
            }

            if (SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3)
            {
                xCoordinateOffset = healthOffset - 0x24;
                yCoordinateOffset = healthOffset - 0x20;
                zCoordinateOffset = healthOffset - 0x1C;
                orientationOffset = healthOffset - 0x16;
                roomOffset = healthOffset - 0x10;
            }
            else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
            {
                xCoordinateOffset = healthOffset - 0x10;
                yCoordinateOffset = healthOffset - 0xE;
                zCoordinateOffset = healthOffset - 0xC;
                orientationOffset = healthOffset - 0x9;
                roomOffset = healthOffset - 0xA;
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
            return ReadInt32(savegameOffset + xCoordinateOffset);
        }

        private Int32 GetYCoordinateI32()
        {
            return ReadInt32(savegameOffset + yCoordinateOffset);
        }

        private Int32 GetZCoordinateI32()
        {
            return ReadInt32(savegameOffset + zCoordinateOffset);
        }

        private Int16 GetXCoordinateI16()
        {
            return ReadInt16(savegameOffset + xCoordinateOffset);
        }

        private UInt16 GetXCoordinateU16()
        {
            return ReadUInt16(savegameOffset + xCoordinateOffset);
        }

        private Int32 GetYCoordinateI16()
        {
            return ReadInt16(savegameOffset + yCoordinateOffset);
        }

        private Int32 GetZCoordinateI16()
        {
            return ReadInt16(savegameOffset + zCoordinateOffset);
        }

        private UInt16 GetZCoordinateU16()
        {
            return ReadUInt16(savegameOffset + zCoordinateOffset);
        }

        private Int16 GetOrientation()
        {
            Int16 rawValue = ReadInt16(savegameOffset + orientationOffset);
            double degrees = rawValue * 180.0 / Int16.MaxValue;

            return (degrees >= 0) ? (Int16)degrees : (Int16)(-degrees);
        }

        private byte GetRoom()
        {
            return ReadByte(savegameOffset + roomOffset);
        }

        private void WriteXCoordinateI32(Int32 value)
        {
            WriteInt32(savegameOffset + xCoordinateOffset, value);
        }

        private void WriteYCoordinateI32(Int32 value)
        {
            WriteInt32(savegameOffset + yCoordinateOffset, value);
        }

        private void WriteZCoordinateI32(Int32 value)
        {
            WriteInt32(savegameOffset + zCoordinateOffset, value);
        }

        private void WriteXCoordinateI16(Int16 value)
        {
            WriteInt16(savegameOffset + xCoordinateOffset, value);
        }

        private void WriteYCoordinateI16(Int16 value)
        {
            WriteInt16(savegameOffset + yCoordinateOffset, value);
        }

        private void WriteZCoordinateI16(Int16 value)
        {
            WriteInt16(savegameOffset + zCoordinateOffset, value);
        }

        private void WriteXCoordinateU16(UInt16 value)
        {
            WriteUInt16(savegameOffset + xCoordinateOffset, value);
        }

        private void WriteZCoordinateU16(UInt16 value)
        {
            WriteUInt16(savegameOffset + zCoordinateOffset, value);
        }

        private void WriteOrientation(Int16 value)
        {
            Int16 rawValue = (Int16)(value * Int16.MaxValue / 180.0);
            WriteInt16(savegameOffset + orientationOffset, rawValue);
        }

        private void WriteRoom(byte value)
        {
            WriteByte(savegameOffset + roomOffset, value);
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
