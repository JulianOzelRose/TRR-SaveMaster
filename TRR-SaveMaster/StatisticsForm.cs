﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    public partial class StatisticsForm : Form
    {
        // Offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private int LEVEL_INDEX_OFFSET;
        private int CRYSTALS_FOUND_OFFSET;
        private int CRYSTALS_USED_OFFSET;
        private int AMMO_USED_OFFSET;
        private int HITS_OFFSET;
        private int KILLS_OFFSET;
        private int SECRETS_FOUND_OFFSET;
        private int PICKUPS_OFFSET;
        private int MEDIPACKS_USED_OFFSET;
        private int DISTANCE_TRAVELLED_OFFSET;
        private int TIME_TAKEN_OFFSET;
        private int VESSELS_BROKEN_OFFSET;

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

        // Misc
        private ToolStripStatusLabel slblStatus;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;
        private int SELECTED_TAB;

        // Maxes
        private const int MAX_SECRETS_FOUND_TR4 = 70;
        private const int MAX_SECRETS_FOUND_TR5 = 36;

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
            grpSavegameStatistics.Text = $"{selectedSavegame}";
        }

        private void DetermineOffsets()
        {
            if (SELECTED_TAB == TAB_TR1)
            {
                LEVEL_INDEX_OFFSET = 0x62C;
                CRYSTALS_USED_OFFSET = 0x610;
                AMMO_USED_OFFSET = 0x618;
                HITS_OFFSET = 0x61C;
                KILLS_OFFSET = 0x620;
                SECRETS_FOUND_OFFSET = 0x628;
                PICKUPS_OFFSET = 0x62A;
                MEDIPACKS_USED_OFFSET = 0x62B;
                DISTANCE_TRAVELLED_OFFSET = 0x624;
                TIME_TAKEN_OFFSET = 0x614;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                LEVEL_INDEX_OFFSET = 0x628;
                AMMO_USED_OFFSET = 0x614;
                HITS_OFFSET = 0x618;
                KILLS_OFFSET = 0x61C;
                SECRETS_FOUND_OFFSET = 0x624;
                PICKUPS_OFFSET = 0x626;
                MEDIPACKS_USED_OFFSET = 0x627;
                DISTANCE_TRAVELLED_OFFSET = 0x620;
                TIME_TAKEN_OFFSET = 0x610;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                LEVEL_INDEX_OFFSET = 0x8D6;
                CRYSTALS_FOUND_OFFSET = 0x8A4;
                CRYSTALS_USED_OFFSET = 0x8A8;
                AMMO_USED_OFFSET = 0x8B0;
                HITS_OFFSET = 0x8B4;
                KILLS_OFFSET = 0x8B8;
                SECRETS_FOUND_OFFSET = 0x8C0;
                PICKUPS_OFFSET = 0x8C2;
                MEDIPACKS_USED_OFFSET = 0x8C3;
                DISTANCE_TRAVELLED_OFFSET = 0x8BC;
                TIME_TAKEN_OFFSET = 0x8AC;
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                LEVEL_INDEX_OFFSET = 0x26F;
                TIME_TAKEN_OFFSET = 0x230;
                DISTANCE_TRAVELLED_OFFSET = 0x234;
                AMMO_USED_OFFSET = 0x238;
                PICKUPS_OFFSET = 0x240;
                KILLS_OFFSET = 0x244;
                SECRETS_FOUND_OFFSET = 0x246;
                MEDIPACKS_USED_OFFSET = 0x247;
                VESSELS_BROKEN_OFFSET = 0x280;
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                LEVEL_INDEX_OFFSET = 0x26F;
                TIME_TAKEN_OFFSET = 0x230;
                DISTANCE_TRAVELLED_OFFSET = 0x234;
                AMMO_USED_OFFSET = 0x238;
                PICKUPS_OFFSET = 0x240;
                KILLS_OFFSET = 0x244;
                SECRETS_FOUND_OFFSET = 0x246;
                MEDIPACKS_USED_OFFSET = 0x247;
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
                nudCrystalsUsed.Enabled = selectedSavegame.Mode == GameMode.Plus;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR2[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR3[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = true;
                nudCrystalsUsed.Enabled = selectedSavegame.Mode == GameMode.Plus;
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                nudAmmoUsed.Maximum = Int16.MaxValue;
                nudAmmoUsed.Minimum = Int16.MinValue;

                nudPickups.Maximum = Int32.MaxValue;
                nudPickups.Minimum = Int32.MinValue;

                nudKills.Maximum = UInt16.MaxValue;
                nudKills.Minimum = UInt16.MinValue;

                nudMedipacksUsed.Maximum = Byte.MaxValue;
                nudMedipacksUsed.Minimum = Byte.MinValue;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                nudVesselsBroken.Enabled = true;

                nudSecretsFound.Maximum = MAX_SECRETS_FOUND_TR4;
                nudSecretsFound.Minimum = Byte.MinValue;

                nudSecretsFoundMax.Value = MAX_SECRETS_FOUND_TR4;
                nudPickupsMax.Visible = false;
                nudHits.Visible = false;
                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                lblAmmoUsedHits.Text = "Ammo Used:";
                lblMedipacksUsed.Text = "Health Packs Used:";
                lblOf.Text = "/";

                lblOf2.Visible = false;
                lblSlash.Visible = false;
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                nudAmmoUsed.Maximum = Int16.MaxValue;
                nudAmmoUsed.Minimum = Int16.MinValue;

                nudPickups.Maximum = Int32.MaxValue;
                nudPickups.Minimum = Int32.MinValue;

                nudKills.Maximum = UInt16.MaxValue;
                nudKills.Minimum = UInt16.MinValue;

                nudMedipacksUsed.Maximum = Byte.MaxValue;
                nudMedipacksUsed.Minimum = Byte.MinValue;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                nudSecretsFound.Maximum = MAX_SECRETS_FOUND_TR5;
                nudSecretsFound.Minimum = Byte.MinValue;

                nudSecretsFoundMax.Value = MAX_SECRETS_FOUND_TR5;
                nudPickupsMax.Visible = false;
                nudHits.Visible = false;
                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                lblAmmoUsedHits.Text = "Ammo Used:";
                lblMedipacksUsed.Text = "Health Packs Used:";
                lblOf.Text = "/";

                lblOf2.Visible = false;
                lblSlash.Visible = false;
            }
        }

        private bool IsTRXSavegame()
        {
            return (SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3);
        }

        private void DisplayStatistics()
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

                if (IsTRXSavegame())
                {
                    nudSecretsFound.Value = GetNumSecretsFoundTRX();
                    nudPickups.Value = GetNumPickupsTRX();
                    nudKills.Value = GetNumKillsTRX();
                    nudAmmoUsed.Value = GetAmmoUsedTRX();
                    nudHits.Value = GetNumHits();
                    nudMedipacksUsed.Value = (decimal)GetNumMedipacksUsedTRX() / 2;

                    if (nudCrystalsFound.Enabled)
                    {
                        nudCrystalsFound.Value = GetNumCrystalsFound();
                    }

                    if (nudCrystalsUsed.Enabled)
                    {
                        nudCrystalsUsed.Value = GetNumCrystalsUsed();
                    }

                    DisplayDistanceTravelledTRX();
                    DisplayTimeTaken();
                }
                else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
                {
                    nudSecretsFound.Value = GetNumSecretsFoundTRX2();
                    nudMedipacksUsed.Value = GetNumMedipacksUsedTRX2();
                    nudKills.Value = GetNumKillsTRX2();
                    nudPickups.Value = GetNumPickupsTRX2();
                    nudAmmoUsed.Value = GetAmmoUsedTRX2();
                    DisplayDistanceTravelledTRX2();
                    DisplayTimeTaken();

                    if (nudVesselsBroken.Enabled)
                    {
                        nudVesselsBroken.Value = GetNumVesselsBroken();
                    }
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

        private void DisplayDistanceTravelledTRX()
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

        private void DisplayDistanceTravelledTRX2()
        {
            UInt32 distanceTravelledRaw = GetDistanceTravelled();

            decimal distanceTravelledMeters = distanceTravelledRaw / 419;
            decimal distanceToShow;

            distanceToShow = distanceTravelledMeters;

            nudDistanceTravelled.DecimalPlaces = 0;
            nudDistanceTravelled.Increment = 1;
            lblDistanceTravelledUnit.Text = "m";

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
            {  8, 1 },  // Temple of Puna
            {  9, 5 },  // Thames Wharf
            { 10, 5 },  // Aldwych
            { 11, 6 },  // Lud's Gate
            { 12, 1 },  // City
            { 13, 3 },  // Nevada Desert
            { 14, 2 },  // High Security Compound
            { 15, 3 },  // Area 51
            { 16, 3 },  // Antarctica
            { 17, 3 },  // RX-Tech Mines
            { 18, 3 },  // Lost City of Tinnos
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
            {  8, 11 }, // Temple of Puna
            {  9, 32 }, // Thames Wharf
            { 10, 50 }, // Aldwych
            { 11, 59 }, // Lud's Gate
            { 12, 7  }, // City
            { 13, 28 }, // Nevada Desert
            { 14, 34 }, // High Security Compound
            { 15, 36 }, // Area 51
            { 16, 34 }, // Antarctica
            { 17, 26 }, // RX-Tech Mines
            { 18, 33 }, // Lost City of Tinnos
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

        private Int16 ReadInt16(int offset)
        {
            byte lowerByte = ReadByte(offset);
            byte upperByte = ReadByte(offset + 1);

            return (Int16)(lowerByte + (upperByte << 8));
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

        private void WriteInt16(int offset, Int16 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
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

        private bool IsSavegamePresent()
        {
            return ReadByte(savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + LEVEL_INDEX_OFFSET);
        }

        private Int32 GetAmmoUsedTRX()
        {
            return ReadInt32(savegameOffset + AMMO_USED_OFFSET);
        }

        private Int16 GetAmmoUsedTRX2()
        {
            return ReadInt16(savegameOffset + AMMO_USED_OFFSET);
        }

        private Int32 GetNumHits()
        {
            return ReadInt32(savegameOffset + HITS_OFFSET);
        }

        private Int32 GetNumKillsTRX()
        {
            return ReadInt32(savegameOffset + KILLS_OFFSET);
        }

        private UInt16 GetNumKillsTRX2()
        {
            return ReadUInt16(savegameOffset + KILLS_OFFSET);
        }

        private UInt32 GetDistanceTravelled()
        {
            return ReadUInt32(savegameOffset + DISTANCE_TRAVELLED_OFFSET);
        }

        private Int32 GetTimeTaken()
        {
            return ReadInt32(savegameOffset + TIME_TAKEN_OFFSET);
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

        private UInt16 GetNumSecretsFoundTRX()
        {
            UInt16 rawValue = ReadUInt16(savegameOffset + SECRETS_FOUND_OFFSET);
            return RawSecretsValueToDisplayValue(rawValue);
        }

        private byte GetNumSecretsFoundTRX2()
        {
            return ReadByte(savegameOffset + SECRETS_FOUND_OFFSET);
        }

        private sbyte GetNumPickupsTRX()
        {
            return ReadInt8(savegameOffset + PICKUPS_OFFSET);
        }

        private Int32 GetNumPickupsTRX2()
        {
            return ReadInt32(savegameOffset + PICKUPS_OFFSET);
        }

        private sbyte GetNumMedipacksUsedTRX()
        {
            return ReadInt8(savegameOffset + MEDIPACKS_USED_OFFSET);
        }

        private byte GetNumMedipacksUsedTRX2()
        {
            return ReadByte(savegameOffset + MEDIPACKS_USED_OFFSET);
        }

        private Int32 GetNumCrystalsFound()
        {
            return ReadInt32(savegameOffset + CRYSTALS_FOUND_OFFSET);
        }

        private Int32 GetNumVesselsBroken()
        {
            return ReadInt32(savegameOffset + VESSELS_BROKEN_OFFSET);
        }

        private Int32 GetNumCrystalsUsed()
        {
            return ReadInt32(savegameOffset + CRYSTALS_USED_OFFSET);
        }

        private void WriteAmmoUsedTRX(Int32 value)
        {
            WriteInt32(savegameOffset + AMMO_USED_OFFSET, value);
        }

        private void WriteAmmoUsedTRX2(Int16 value)
        {
            WriteInt16(savegameOffset + AMMO_USED_OFFSET, value);
        }

        private void WriteNumHits(Int32 value)
        {
            WriteInt32(savegameOffset + HITS_OFFSET, value);
        }

        private void WriteNumKillsTRX(Int32 value)
        {
            WriteInt32(savegameOffset + KILLS_OFFSET, value);
        }

        private void WriteNumKillsTRX2(UInt16 value)
        {
            WriteUInt16(savegameOffset + KILLS_OFFSET, value);
        }

        private void WriteNumSecretsFoundTRX(UInt16 value)
        {
            UInt16 rawValue = 0;

            for (int i = 0; i < value; i++)
            {
                rawValue |= (UInt16)(1 << i);
            }

            WriteUInt16(savegameOffset + SECRETS_FOUND_OFFSET, rawValue);
        }

        private void WriteNumSecretsFoundTRX2(byte value)
        {
            WriteByte(savegameOffset + SECRETS_FOUND_OFFSET, value);
        }

        private void WriteNumPickupsTRX(sbyte value)
        {
            WriteInt8(savegameOffset + PICKUPS_OFFSET, value);
        }

        private void WriteNumPickupsTRX2(Int32 value)
        {
            WriteInt32(savegameOffset + PICKUPS_OFFSET, value);
        }

        private void WriteNumMedipacksUsedTRX(sbyte value)
        {
            WriteInt8(savegameOffset + MEDIPACKS_USED_OFFSET, value);
        }

        private void WriteNumMedipacksUsedTRX2(byte value)
        {
            WriteByte(savegameOffset + MEDIPACKS_USED_OFFSET, value);
        }

        private void WriteNumCrystalsFound(Int32 value)
        {
            WriteInt32(savegameOffset + CRYSTALS_FOUND_OFFSET, value);
        }

        private void WriteNumCrystalsUsed(Int32 value)
        {
            WriteInt32(savegameOffset + CRYSTALS_USED_OFFSET, value);
        }

        private void WriteTimeTaken(Int32 value)
        {
            WriteInt32(savegameOffset + TIME_TAKEN_OFFSET, value);
        }

        private void WriteDistanceTravelledTRX(decimal value)
        {
            bool isMeter = lblDistanceTravelledUnit.Text == "m";

            if (!isMeter)
            {
                value = (decimal)(value * 1000);
            }

            value *= 445;

            WriteUInt32(savegameOffset + DISTANCE_TRAVELLED_OFFSET, (UInt32)value);
        }

        private void WriteDistanceTravelledTRX2(decimal value)
        {
            value *= 419;

            WriteUInt32(savegameOffset + DISTANCE_TRAVELLED_OFFSET, (UInt32)value);
        }

        private void WriteVesselsBroken(Int32 value)
        {
            WriteInt32(savegameOffset + VESSELS_BROKEN_OFFSET, value);
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

                if (IsTRXSavegame())
                {
                    WriteAmmoUsedTRX((Int32)nudAmmoUsed.Value);
                    WriteNumHits((Int32)nudHits.Value);
                    WriteNumKillsTRX((Int32)nudKills.Value);
                    WriteNumPickupsTRX((sbyte)nudPickups.Value);
                    WriteNumMedipacksUsedTRX((sbyte)(nudMedipacksUsed.Value * 2));
                    WriteTimeTaken((Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteDistanceTravelledTRX((decimal)nudDistanceTravelled.Value);
                    WriteNumSecretsFoundTRX((UInt16)nudSecretsFound.Value);

                    if (nudCrystalsFound.Enabled)
                    {
                        WriteNumCrystalsFound((Int32)nudCrystalsFound.Value);
                    }

                    if (nudCrystalsUsed.Enabled)
                    {
                        WriteNumCrystalsUsed((Int32)nudCrystalsUsed.Value);
                    }
                }
                else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
                {
                    WriteAmmoUsedTRX2((Int16)nudAmmoUsed.Value);
                    WriteNumKillsTRX2((UInt16)nudKills.Value);
                    WriteNumPickupsTRX2((Int32)nudPickups.Value);
                    WriteNumMedipacksUsedTRX2((byte)nudMedipacksUsed.Value);
                    WriteNumSecretsFoundTRX2((byte)nudSecretsFound.Value);
                    WriteTimeTaken((Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteDistanceTravelledTRX2((decimal)nudDistanceTravelled.Value);

                    if (nudVesselsBroken.Enabled)
                    {
                        WriteVesselsBroken((Int32)nudVesselsBroken.Value);
                    }
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
                DialogResult result = MessageBox.Show($"Would you like to apply changes to the savegame?",
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

        private void nudCrystalsUsed_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudVesselsBroken_ValueChanged(object sender, EventArgs e)
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

        private void nudCrystalsUsed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudVesselsBroken_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }
    }
}
