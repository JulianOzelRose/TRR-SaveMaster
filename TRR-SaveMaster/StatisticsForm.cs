using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class StatisticsForm : Form
    {
        // Offsets
        private int levelIndexOffset;
        private int crystalsFoundOffset;
        private int ammoUsedOffset;
        private int hitsOffset;
        private int killsOffset;
        private int secretsFoundOffset;
        private int pickupsFoundOffset;
        private int medipacksUsedOffset;
        private int distanceTravelledOffset;
        private int timeTakenOffset;

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;

        // Savegame
        private Savegame selectedSavegame;
        private string savegamePath;
        private int savegameOffset;

        // Misc
        private ToolStripStatusLabel slblStatus;
        private bool isLoading = true;
        private int SELECTED_TAB;

        public StatisticsForm(ToolStripStatusLabel slblStatus, string savegamePath, int SELECTED_TAB)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.savegamePath = savegamePath;
            this.SELECTED_TAB = SELECTED_TAB;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            DetermineOffsets();

            try
            {
                SetParams();
                DisplayStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error loading savegame statistics.";
                this.Close();
            }
        }

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
        }

        public void SetSavegame(Savegame savegame)
        {
            selectedSavegame = savegame;
            savegameOffset = savegame.Offset;
            grpLevel.Text = $"{selectedSavegame}";
        }

        private void DetermineOffsets()
        {
            if (SELECTED_TAB == TAB_TR1)
            {
                levelIndexOffset = 0x62C;
                ammoUsedOffset = 0x618;
                hitsOffset = 0x61C;
                killsOffset = 0x620;
                secretsFoundOffset = 0x628;
                pickupsFoundOffset = 0x62A;
                medipacksUsedOffset = 0x62B;
                distanceTravelledOffset = 0x624;
                timeTakenOffset = 0x614;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                levelIndexOffset = 0x628;
                ammoUsedOffset = 0x614;
                hitsOffset = 0x618;
                killsOffset = 0x61C;
                secretsFoundOffset = 0x624;
                pickupsFoundOffset = 0x626;
                medipacksUsedOffset = 0x627;
                distanceTravelledOffset = 0x620;
                timeTakenOffset = 0x610;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                levelIndexOffset = 0x8D6;
                crystalsFoundOffset = 0x8A4;
                ammoUsedOffset = 0x8B0;
                hitsOffset = 0x8B4;
                killsOffset = 0x8B8;
                secretsFoundOffset = 0x8C0;
                pickupsFoundOffset = 0x8C2;
                medipacksUsedOffset = 0x8C3;
                distanceTravelledOffset = 0x8BC;
                timeTakenOffset = 0x8AC;
            }
        }

        private void SetParams()
        {
            byte levelIndex = GetLevelIndex();

            if (SELECTED_TAB == TAB_TR1)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR1[levelIndex];
                nudPickupsFoundMax.Value = pickupsFoundMaxTR1[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickupsFound.Maximum = nudPickupsFoundMax.Value;

                nudCrystalsFound.Enabled = false;
                nudCrystalsFound.Value = 0;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2[levelIndex];
                nudPickupsFoundMax.Value = pickupsFoundMaxTR2[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickupsFound.Maximum = nudPickupsFoundMax.Value;

                nudCrystalsFound.Enabled = false;
                nudCrystalsFound.Value = 0;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3[levelIndex];
                nudPickupsFoundMax.Value = pickupsFoundMaxTR3[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickupsFound.Maximum = nudPickupsFoundMax.Value;

                nudCrystalsFound.Enabled = true;
                nudCrystalsFound.Value = GetNumCrystalsFound();
            }
        }

        private void DisplayStatistics()
        {
            isLoading = true;

            nudSecretsFound.Value = GetNumSecretsFound();
            nudPickupsFound.Value = GetNumPickupsFound();
            nudKills.Value = GetNumKills();
            nudAmmoUsed.Value = GetAmmoUsed();
            nudHits.Value = GetNumHits();
            nudMedipacksUsed.Value = (decimal)GetNumMedipacksUsed() / 2;

            DisplayDistanceTravelled();
            DisplayTimeTaken();

            if (SELECTED_TAB == TAB_TR3)
            {
                nudCrystalsFound.Value = GetNumCrystalsFound();
            }

            isLoading = false;
        }

        private void DisplayDistanceTravelled()
        {
            UInt32 distanceTravelledMeters = GetDistanceTravelled() / 445;

            decimal distanceToShow;

            if (distanceTravelledMeters >= 1000)
            {
                decimal distanceInKilometers = (decimal)distanceTravelledMeters / 1000.0m;
                distanceToShow = decimal.Round(distanceInKilometers + 0.005m, 2, MidpointRounding.AwayFromZero);

                nudDistanceTravelled.DecimalPlaces = 2;
                nudDistanceTravelled.Increment = 0.01m;
                lblDistanceTravelledUnit.Text = "km";
            }
            else
            {
                distanceToShow = distanceTravelledMeters;

                nudDistanceTravelled.DecimalPlaces = 0;
                nudDistanceTravelled.Increment = 1;
                lblDistanceTravelledUnit.Text = "m";
            }

            nudDistanceTravelled.Value = distanceToShow;
        }

        private void DisplayTimeTaken()
        {
            UInt32 timeTakenRaw = GetTimeTaken();
            UInt32 timeTakenSeconds = timeTakenRaw / 30;
            UInt32 remainingSeconds = timeTakenSeconds % 60;
            UInt32 totalMinutes = timeTakenSeconds / 60;
            UInt32 remainingMinutes = totalMinutes % 60;
            UInt32 totalHours = totalMinutes / 60;

            nudHours.Value = totalHours;
            nudMinutes.Value = remainingMinutes;
            nudSeconds.Value = remainingSeconds;
        }

        private readonly Dictionary<byte, int> secretsFoundMaxTR1 = new Dictionary<byte, int>
        {
            {  1, 3 },  // Caves
            {  2, 3 },  // City of Vilcabamba
            {  3, 5 },  // Lost Valley
            {  4, 3 },  // Tomb of Qualopec
            {  5, 4 },  // St. Francis' Folly
            {  6, 3 },  // Colosseum
            {  7, 3 },  // Palace Midas
            {  8, 3 },  // The Cistern
            {  9, 2 },  // Tomb of Tihocan
            { 10, 3 },  // City of Khamoon
            { 11, 3 },  // Obelisk of Khamoon
            { 12, 1 },  // Sanctuary of the Scion
            { 13, 3 },  // Natla's Mines
            { 14, 3 },  // Atlantis
            { 15, 3 },  // The Great Pyramid
            { 16, 3 },  // Return to Egypt
            { 17, 4 },  // Temple of the Cat
            { 18, 2 },  // Atlantean Stronghold
            { 19, 1 },  // The Hive
        };

        private readonly Dictionary<byte, int> secretsFoundMaxTR2 = new Dictionary<byte, int>
        {
            {  1, 3 },  // The Great Wall
            {  2, 3 },  // Venice
            {  3, 3 },  // Bartoli's Hideout
            {  4, 3 },  // Opera House
            {  5, 3 },  // Offshore Rig
            {  6, 3 },  // Diving Area
            {  7, 3 },  // 40 Fathoms
            {  8, 3 },  // Wreck of the Maria Doria
            {  9, 3 },  // Living Quarters
            { 10, 3 },  // The Deck
            { 11, 3 },  // Tibetan Foothills
            { 12, 3 },  // Barkhang Monastery
            { 13, 3 },  // Catacombs of the Talion
            { 14, 3 },  // Ice Palace
            { 15, 3 },  // Temple of Xian
            { 16, 3 },  // Floating Islands
            { 17, 0 },  // The Dragon's Lair
            { 18, 0 },  // Home Sweet Home
            { 19, 3 },  // The Cold War
            { 20, 3 },  // Fool's Gold
            { 21, 3 },  // Furnace of the Gods
            { 22, 3 },  // Kingdom
            { 23, 3 },  // Nightmare in Vegas
        };

        private readonly Dictionary<byte, int> secretsFoundMaxTR3 = new Dictionary<byte, int>
        {
            {  1, 6 },  // Jungle
            {  2, 4 },  // Temple Ruins
            {  3, 5 },  // The River Ganges
            {  4, 0 },  // Caves of Kaliya
            {  5, 4 },  // Coastal Village
            {  6, 3 },  // Crash Site
            {  7, 3 },  // Madubu Gorge
            {  8, 1 },  // Temple Of Puna
            {  9, 5 },  // Thames Wharf
            { 10, 5 },  // Aldwych
            { 11, 6 },  // Lud's Gate
            { 12, 1 },  // City
            { 13, 3 },  // Nevada Desert
            { 14, 2 },  // High Security Compound
            { 15, 3 },  // Area 51
            { 16, 3 },  // Antarctica
            { 17, 3 },  // RX-Tech Mines
            { 18, 3 },  // Lost City Of Tinnos
            { 19, 0 },  // Meteorite Cavern
            { 20, 0 },  // All Hallows
            { 21, 3 },  // Highland Fling
            { 22, 3 },  // Willard's Lair
            { 23, 3 },  // Shakespeare Cliff
            { 24, 3 },  // Sleeping with the Fishes
            { 25, 3 },  // It's a Madhouse!
            { 26, 0 },  // Reunion
        };

        private readonly Dictionary<byte, int> pickupsFoundMaxTR3 = new Dictionary<byte, int>
        {
            {  1, 33 }, // Jungle
            {  2, 43 }, // Temple Ruins
            {  3, 32 }, // The River Ganges
            {  4, 10 }, // Caves of Kaliya
            {  5, 29 }, // Coastal Village
            {  6, 26 }, // Crash Site
            {  7, 12 }, // Madubu Gorge
            {  8, 11 }, // Temple Of Puna
            {  9, 32 }, // Thames Wharf
            { 10, 50 }, // Aldwych
            { 11, 59 }, // Lud's Gate
            { 12, 7  }, // City
            { 13, 28 }, // Nevada Desert
            { 14, 34 }, // High Security Compound
            { 15, 36 }, // Area 51
            { 16, 34 }, // Antarctica
            { 17, 26 }, // RX-Tech Mines
            { 18, 33 }, // Lost City Of Tinnos
            { 19, 7  }, // Meteorite Cavern
            { 20, 15 }, // All Hallows
            { 21, 47 }, // Highland Fling
            { 22, 41 }, // Willard's Lair
            { 23, 39 }, // Shakespeare Cliff
            { 24, 57 }, // Sleeping with the Fishes
            { 25, 49 }, // It's a Madhouse!
            { 26, 32 }, // Reunion
        };

        private readonly Dictionary<byte, int> pickupsFoundMaxTR2 = new Dictionary<byte, int>
        {
            {  1, 14 },  // The Great Wall
            {  2, 30 },  // Venice
            {  3, 28 },  // Bartoli's Hideout
            {  4, 37 },  // Opera House
            {  5, 31 },  // Offshore Rig
            {  6, 39 },  // Diving Area
            {  7, 14 },  // 40 Fathoms
            {  8, 41 },  // Wreck of the Maria Doria
            {  9, 16 },  // Living Quarters
            { 10, 35 },  // The Deck
            { 11, 31 },  // Tibetan Foothills
            { 12, 49 },  // Barkhang Monastery
            { 13, 39 },  // Catacombs of the Talion
            { 14, 33 },  // Ice Palace
            { 15, 40 },  // Temple of Xian
            { 16, 39 },  // Floating Islands
            { 17, 24 },  // The Dragon's Lair
            { 18, 45 },  // Home Sweet Home
            { 19, 71 },  // The Cold War
            { 20, 69 },  // Fool's Gold
            { 21, 64 },  // Furnace of the Gods
            { 22, 52 },  // Kingdom
            { 23, 75 },  // Nightmare in Vegas
        };

        private readonly Dictionary<byte, int> pickupsFoundMaxTR1 = new Dictionary<byte, int>
        {
            {  1, 7  },  // Caves
            {  2, 13 },  // City of Vilcabamba
            {  3, 16 },  // Lost Valley
            {  4, 8  },  // Tomb of Qualopec
            {  5, 19 },  // St. Francis' Folly
            {  6, 14 },  // Colosseum
            {  7, 23 },  // Palace Midas
            {  8, 28 },  // The Cistern
            {  9, 26 },  // Tomb of Tihocan
            { 10, 24 },  // City of Khamoon
            { 11, 38 },  // Obelisk of Khamoon
            { 12, 29 },  // Sanctuary of the Scion
            { 13, 30 },  // Natla's Mines
            { 14, 51 },  // Atlantis
            { 15, 31 },  // The Great Pyramid
            { 16, 53 },  // Return to Egypt
            { 17, 63 },  // Temple of the Cat
            { 18, 63 },  // Atlantean Stronghold
            { 19, 60 },  // The Hive
        };

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

        private UInt16 ReadUInt16(int offset)
        {
            byte lowerByte = ReadByte(offset);
            byte upperByte = ReadByte(offset + 1);

            return (UInt16)(lowerByte + (upperByte << 8));
        }

        private UInt32 ReadUInt32(int offset)
        {
            byte byte1 = ReadByte(offset);
            byte byte2 = ReadByte(offset + 1);
            byte byte3 = ReadByte(offset + 2);
            byte byte4 = ReadByte(offset + 3);

            return (UInt32)(byte1 + (byte2 << 8) + (byte3 << 16) + (byte4 << 24));
        }

        private void WriteUInt32(int offset, UInt32 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
            WriteByte(offset + 2, (byte)(value >> 16));
            WriteByte(offset + 3, (byte)(value >> 24));
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

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + levelIndexOffset);
        }

        private UInt16 GetAmmoUsed()
        {
            return ReadUInt16(savegameOffset + ammoUsedOffset);
        }

        private UInt16 GetNumHits()
        {
            return ReadUInt16(savegameOffset + hitsOffset);
        }

        private UInt16 GetNumKills()
        {
            return ReadUInt16(savegameOffset + killsOffset);
        }

        private UInt32 GetDistanceTravelled()
        {
            return ReadUInt32(savegameOffset + distanceTravelledOffset);
        }

        private UInt32 GetTimeTaken()
        {
            return ReadUInt32(savegameOffset + timeTakenOffset);
        }

        private byte RawSecretsValueToDisplayValue(byte rawValue)
        {
            byte[] mapping = {
                    0, 1, 1, 2, 1, 2, 2, 3, 1, 2,
                    2, 3, 2, 3, 3, 4, 1, 2, 2, 3,
                    2, 3, 3, 4, 2, 3, 3, 4, 3, 4,
                    4, 5, 1, 2, 2, 3, 2, 3, 3, 4,
                    2, 3, 3, 4, 3, 4, 4, 5, 2, 3,
                    3, 4, 3, 4, 4, 5, 3, 4, 4, 5,
                    4, 5, 5, 6, 1, 2, 2, 3, 2, 3
            };

            if (rawValue >= 0 && rawValue < mapping.Length)
            {
                return mapping[rawValue];
            }
            else
            {
                return 0;
            }
        }

        private byte GetNumSecretsFound()
        {
            byte rawValue = ReadByte(savegameOffset + secretsFoundOffset);
            byte displayValue = RawSecretsValueToDisplayValue(rawValue);

            return displayValue;
        }

        private byte GetNumPickupsFound()
        {
            return ReadByte(savegameOffset + pickupsFoundOffset);
        }

        private byte GetNumMedipacksUsed()
        {
            return ReadByte(savegameOffset + medipacksUsedOffset);
        }

        private byte GetNumCrystalsFound()
        {
            return ReadByte(savegameOffset + crystalsFoundOffset);
        }

        private void WriteAmmoUsed(UInt16 value)
        {
            WriteUInt16(savegameOffset + ammoUsedOffset, value);
        }

        private void WriteNumHits(UInt16 value)
        {
            WriteUInt16(savegameOffset + hitsOffset, value);
        }

        private void WriteNumKills(UInt16 value)
        {
            WriteUInt16(savegameOffset + killsOffset, value);
        }

        private void WriteNumSecretsFoundTR1(byte value)
        {
            byte rawValue = 0;

            if (value == 0)
            {
                rawValue = 0;
            }
            else if (value == 1)
            {
                rawValue = 4;
            }
            else if (value == 2)
            {
                rawValue = 12;
            }
            else if (value == 3)
            {
                rawValue = 28;
            }
            else if (value == 4)
            {
                rawValue = 29;
            }
            else if (value == 5)
            {
                rawValue = 31;
            }

            WriteByte(savegameOffset + secretsFoundOffset, rawValue);
        }

        private void WriteNumSecretsFoundTR2(byte value)
        {
            byte rawValue = 0;

            if (value == 0)
            {
                rawValue = 0;
            }
            else if (value == 1)
            {
                rawValue = 4;
            }
            else if (value == 2)
            {
                rawValue = 5;
            }
            else if (value == 3)
            {
                rawValue = 7;
            }

            WriteByte(savegameOffset + secretsFoundOffset, rawValue);
        }

        private void WriteNumSecretsFoundTR3(byte value)
        {
            byte rawValue = 0;

            if (value == 0)
            {
                rawValue = 0;
            }
            else if (value == 1)
            {
                rawValue = 4;
            }
            else if (value == 2)
            {
                rawValue = 5;
            }
            else if (value == 3)
            {
                rawValue = 7;
            }
            else if (value == 4)
            {
                rawValue = 15;
            }
            else if (value == 5)
            {
                rawValue = 31;
            }
            else if (value == 6)
            {
                rawValue = 63;
            }

            WriteByte(savegameOffset + secretsFoundOffset, rawValue);
        }

        private void WriteNumPickupsFound(byte value)
        {
            WriteByte(savegameOffset + pickupsFoundOffset, value);
        }

        private void WriteNumMedipacksUsed(byte value)
        {
            WriteByte(savegameOffset + medipacksUsedOffset, value);
        }

        private void WriteNumCrystalsFound(byte value)
        {
            WriteByte(savegameOffset + crystalsFoundOffset, value);
        }

        private void WriteTimeTaken(UInt32 value)
        {
            WriteUInt32(savegameOffset + timeTakenOffset, value);
        }

        private void WriteDistanceTravelled(UInt32 value)
        {
            bool isMeter = lblDistanceTravelledUnit.Text == "m";

            if (!isMeter)
            {
                value = (UInt32)(value * 1000);
            }

            value *= 445;

            WriteUInt32(savegameOffset + distanceTravelledOffset, value);
        }

        private void WriteChanges()
        {
            try
            {
                WriteAmmoUsed((UInt16)nudAmmoUsed.Value);
                WriteNumHits((UInt16)nudHits.Value);
                WriteNumKills((UInt16)nudKills.Value);
                WriteNumPickupsFound((byte)nudPickupsFound.Value);
                WriteNumMedipacksUsed((byte)(nudMedipacksUsed.Value * 2));
                WriteTimeTaken((UInt32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                WriteDistanceTravelled((UInt32)nudDistanceTravelled.Value);

                if (SELECTED_TAB == TAB_TR1)
                {
                    WriteNumSecretsFoundTR1((byte)nudSecretsFound.Value);
                }
                else if (SELECTED_TAB == TAB_TR2)
                {
                    WriteNumSecretsFoundTR2((byte)nudSecretsFound.Value);
                }
                else if (SELECTED_TAB == TAB_TR3)
                {
                    WriteNumSecretsFoundTR3((byte)nudSecretsFound.Value);
                    WriteNumCrystalsFound((byte)nudCrystalsFound.Value);
                }

                DisableButtons();

                slblStatus.Text = $"Successfully patched statistics of savegame: '{selectedSavegame}'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error editing savegame statistics.";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteChanges();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayStatistics();
            DisableButtons();
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

        private void nudHours_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudMinutes_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudSeconds_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudSecretsFound_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudSecretsFoundMax_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudCrystalsFound_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudPickupsFound_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudPickupsFoundMax_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudKills_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudAmmoUsed_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudHits_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudMedipacksUsed_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudDistanceTravelled_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudSeconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudSecretsFound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudSecretsFoundMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudCrystalsFound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudPickupsFound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudPickupsFoundMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudKills_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudAmmoUsed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudHits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudMedipacksUsed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudDistanceTravelled_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void ConfirmChanges()
        {
            if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame statistics?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    WriteChanges();
                }
            }
        }
    }
}
