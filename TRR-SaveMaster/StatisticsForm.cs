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
        private int pickupsOffset;
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
        private bool backupBeforeSaving = false;
        private int SELECTED_TAB;

        public StatisticsForm(ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePath, int SELECTED_TAB)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePath = savegamePath;
            this.SELECTED_TAB = SELECTED_TAB;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            DetermineOffsets();
            SetParams();
            DisplayStatistics();
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
                pickupsOffset = 0x62A;
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
                pickupsOffset = 0x626;
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
                pickupsOffset = 0x8C2;
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
                nudPickupsMax.Value = pickupsFoundMaxTR1[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR2[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR3[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = true;
            }
        }

        private void DisplayStatistics()
        {
            isLoading = true;

            try
            {
                nudSecretsFound.Value = GetNumSecretsFound();
                nudPickups.Value = GetNumPickups();
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
                else
                {
                    nudCrystalsFound.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error loading savegame statistics.";
                this.Close();
            }

            isLoading = false;
        }

        private void DisplayDistanceTravelled()
        {
            UInt32 distanceTravelledRaw = GetDistanceTravelled();

            decimal distanceTravelledMeters = distanceTravelledRaw / 445;
            decimal distanceToShow;

            if (distanceTravelledMeters >= 1000)
            {
                decimal distanceInKilometers = (decimal)distanceTravelledMeters / 1000.0m;
                distanceToShow = decimal.Floor(distanceInKilometers * 100) / 100;

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
            Int32 timeTakenRaw = GetTimeTaken();
            Int32 timeTakenSeconds = timeTakenRaw / 30;
            Int32 remainingSeconds = timeTakenSeconds % 60;
            Int32 totalMinutes = timeTakenSeconds / 60;
            Int32 remainingMinutes = totalMinutes % 60;
            Int32 totalHours = totalMinutes / 60;

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

        private sbyte ReadInt8(int offset)
        {
            return (sbyte)ReadByte(offset);
        }

        private void WriteInt8(int offset, sbyte value)
        {
            WriteByte(offset, (byte)value);
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

        private Int32 ReadInt32(int offset)
        {
            byte byte1 = ReadByte(offset);
            byte byte2 = ReadByte(offset + 1);
            byte byte3 = ReadByte(offset + 2);
            byte byte4 = ReadByte(offset + 3);

            return (Int32)(byte1 + (byte2 << 8) + (byte3 << 16) + (byte4 << 24));
        }

        private void WriteUInt32(int offset, UInt32 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
            WriteByte(offset + 2, (byte)(value >> 16));
            WriteByte(offset + 3, (byte)(value >> 24));
        }

        private void WriteInt32(int offset, Int32 value)
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

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + levelIndexOffset);
        }

        private Int32 GetAmmoUsed()
        {
            return ReadInt32(savegameOffset + ammoUsedOffset);
        }

        private Int32 GetNumHits()
        {
            return ReadInt32(savegameOffset + hitsOffset);
        }

        private Int32 GetNumKills()
        {
            return ReadInt32(savegameOffset + killsOffset);
        }

        private UInt32 GetDistanceTravelled()
        {
            return ReadUInt32(savegameOffset + distanceTravelledOffset);
        }

        private Int32 GetTimeTaken()
        {
            return ReadInt32(savegameOffset + timeTakenOffset);
        }

        private UInt16 RawSecretsValueToDisplayValue(UInt16 rawValue)
        {
            if (rawValue == 0)
            {
                return 0;
            }

            UInt16 count = 0;

            while (rawValue != 0)
            {
                count += (UInt16)(rawValue & 1);
                rawValue >>= 1;
            }

            return count;
        }

        private UInt16 GetNumSecretsFound()
        {
            UInt16 rawValue = ReadUInt16(savegameOffset + secretsFoundOffset);
            return RawSecretsValueToDisplayValue(rawValue);
        }

        private sbyte GetNumPickups()
        {
            return ReadInt8(savegameOffset + pickupsOffset);
        }

        private sbyte GetNumMedipacksUsed()
        {
            return ReadInt8(savegameOffset + medipacksUsedOffset);
        }

        private Int32 GetNumCrystalsFound()
        {
            return ReadInt32(savegameOffset + crystalsFoundOffset);
        }

        private void WriteAmmoUsed(Int32 value)
        {
            WriteInt32(savegameOffset + ammoUsedOffset, value);
        }

        private void WriteNumHits(Int32 value)
        {
            WriteInt32(savegameOffset + hitsOffset, value);
        }

        private void WriteNumKills(Int32 value)
        {
            WriteInt32(savegameOffset + killsOffset, value);
        }

        private void WriteNumSecretsFound(UInt16 value)
        {
            UInt16 rawValue = 0;

            for (int i = 0; i < value; i++)
            {
                rawValue |= (UInt16)(1 << i);
            }

            WriteUInt16(savegameOffset + secretsFoundOffset, rawValue);
        }

        private void WriteNumPickups(sbyte value)
        {
            WriteInt8(savegameOffset + pickupsOffset, value);
        }

        private void WriteNumMedipacksUsed(sbyte value)
        {
            WriteInt8(savegameOffset + medipacksUsedOffset, value);
        }

        private void WriteNumCrystalsFound(Int32 value)
        {
            WriteInt32(savegameOffset + crystalsFoundOffset, value);
        }

        private void WriteTimeTaken(Int32 value)
        {
            WriteInt32(savegameOffset + timeTakenOffset, value);
        }

        private void WriteDistanceTravelled(decimal value)
        {
            bool isMeter = lblDistanceTravelledUnit.Text == "m";

            if (!isMeter)
            {
                value = (decimal)(value * 1000);
            }

            value *= 445;

            WriteUInt32(savegameOffset + distanceTravelledOffset, (UInt32)value);
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

                WriteAmmoUsed((Int32)nudAmmoUsed.Value);
                WriteNumHits((Int32)nudHits.Value);
                WriteNumKills((Int32)nudKills.Value);
                WriteNumPickups((sbyte)nudPickups.Value);
                WriteNumMedipacksUsed((sbyte)(nudMedipacksUsed.Value * 2));
                WriteTimeTaken((Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                WriteDistanceTravelled((decimal)nudDistanceTravelled.Value);
                WriteNumSecretsFound((UInt16)nudSecretsFound.Value);

                if (SELECTED_TAB == TAB_TR3)
                {
                    WriteNumCrystalsFound((Int32)nudCrystalsFound.Value);
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

        private void nudPickups_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudPickupsMax_ValueChanged(object sender, EventArgs e)
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

        private void nudPickups_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudPickupsMax_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
