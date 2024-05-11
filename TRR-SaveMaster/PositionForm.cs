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
        }

        private void PositionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
        }

        public void SetSavegame(Savegame savegame)
        {
            selectedSavegame = savegame;
            savegameOffset = savegame.Offset;
            grpSavegame.Text = $"{selectedSavegame}";
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

            nudXCoordinate.Value = secret5Coordinates[0];
            nudYCoordinate.Value = secret5Coordinates[1];
            nudZCoordinate.Value = secret5Coordinates[2];
            nudOrientation.Value = (Int16)secret5Coordinates[3];
            nudRoom.Value = (byte)secret5Coordinates[4];
        }

        private void btnSecret6_Click(object sender, EventArgs e)
        {

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

            }
            else if (SELECTED_TAB == TAB_TR3)
            {

            }
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
            { 23, new Int32[] { 49949, -5888, 55394, 0, 44      } },    // Nightmare in Vegas
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

        private readonly Dictionary<byte, Int32[]> secret1CoordinatesTR1 = new Dictionary<byte, int[]>
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

        private readonly Dictionary<byte, Int32[]> secret2CoordinatesTR1 = new Dictionary<byte, int[]>
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

        private readonly Dictionary<byte, Int32[]> secret3CoordinatesTR1 = new Dictionary<byte, int[]>
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

        private readonly Dictionary<byte, Int32[]> secret4CoordinatesTR1 = new Dictionary<byte, int[]>
        {
            { 3,  new Int32[] { 37393, -389, 97165, 44, 9       } },    // Lost Valley
            { 5,  new Int32[] { 43759, 23552, 46400, 3, 60      } },    // St. Francis' Folly
            { 17, new Int32[] { 38269, -5888, 48350, 88, 93     } },    // Temple of the Cat
        };

        private readonly Dictionary<byte, Int32[]> secret5CoordinatesTR1 = new Dictionary<byte, int[]>
        {
            { 3,  new Int32[] { 43411, -2304, 74652, 180, 14    } },    // Lost Valley
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

            xCoordinateOffset = healthOffset - 0x24;
            yCoordinateOffset = healthOffset - 0x20;
            zCoordinateOffset = healthOffset - 0x1C;
            orientationOffset = healthOffset - 0x16;
            roomOffset = healthOffset - 0x10;
        }

        private Int32 GetXCoordinate()
        {
            return ReadInt32(savegameOffset + xCoordinateOffset);
        }

        private Int32 GetYCoordinate()
        {
            return ReadInt32(savegameOffset + yCoordinateOffset);
        }

        private Int32 GetZCoordinate()
        {
            return ReadInt32(savegameOffset + zCoordinateOffset);
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

        private void WriteXCoordinate(Int32 value)
        {
            WriteInt32(savegameOffset + xCoordinateOffset, value);
        }

        private void WriteYCoordinate(Int32 value)
        {
            WriteInt32(savegameOffset + yCoordinateOffset, value);
        }

        private void WriteZCoordinate(Int32 value)
        {
            WriteInt32(savegameOffset + zCoordinateOffset, value);
        }

        private void WriteOrientation(Int16 value)
        {
            Int16 rawValue = (Int16)(value * Int16.MaxValue / 180);
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

                nudXCoordinate.Value = GetXCoordinate();
                nudYCoordinate.Value = GetYCoordinate();
                nudZCoordinate.Value = GetZCoordinate();
                nudOrientation.Value = GetOrientation();
                nudRoom.Value = GetRoom();
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

                WriteXCoordinate((Int32)nudXCoordinate.Value);
                WriteYCoordinate((Int32)nudYCoordinate.Value);
                WriteZCoordinate((Int32)nudZCoordinate.Value);
                WriteOrientation((Int16)nudOrientation.Value);
                WriteRoom((byte)nudRoom.Value);

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
