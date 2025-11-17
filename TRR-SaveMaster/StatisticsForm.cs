using System;
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
        private int HEALTH_ITEMS_FOUND_OFFSET;
        private int CHOCOBARS_FOUND_OFFSET;
        private int TIMESTAMP_DAYS_OFFSET;
        private int TIMESTAMP_HOURS_OFFSET;
        private int TIMESTAMP_MINUTES_OFFSET;
        private int TIMESTAMP_SECONDS_OFFSET;

        // Maxes
        private const int MAX_PICKUPS_TR4 = 589;
        private const int MAX_VESSELS_BROKEN_TR4 = 169;
        private const int MAX_SECRETS_FOUND_TR4 = 70;
        private const int MAX_SECRETS_FOUND_TR5 = 36;
        private const int MAX_PICKUPS_TR5 = 239;

        // Utils
        private readonly TR1Utilities TR1 = new TR1Utilities();
        private readonly TR2Utilities TR2 = new TR2Utilities();
        private readonly TR3Utilities TR3 = new TR3Utilities();
        private readonly TR4Utilities TR4 = new TR4Utilities();
        private readonly TR5Utilities TR5 = new TR5Utilities();
        private readonly TR6Utilities TR6 = new TR6Utilities();

        // Tabs
        private const int TAB_TR1 = 0;
        private const int TAB_TR2 = 1;
        private const int TAB_TR3 = 2;
        private const int TAB_TR4 = 3;
        private const int TAB_TR5 = 4;
        private const int TAB_TR6 = 5;

        // Misc
        private Savegame selectedSavegame;
        private string savegamePath;
        private int savegameOffset;
        private ToolStripStatusLabel slblStatus;
        private MainForm mainForm;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;
        private int SELECTED_TAB;

        public StatisticsForm(MainForm mainForm, ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePath, int SELECTED_TAB)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePath = savegamePath;
            this.SELECTED_TAB = SELECTED_TAB;
            this.mainForm = mainForm;
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
            mainForm.UpdateDisplayNamesConditionally();
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
                TIMESTAMP_DAYS_OFFSET = 0x00C;
                TIMESTAMP_HOURS_OFFSET = 0x010;
                TIMESTAMP_MINUTES_OFFSET = 0x014;
                TIMESTAMP_SECONDS_OFFSET = 0x018;
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
                TIMESTAMP_DAYS_OFFSET = 0x00C;
                TIMESTAMP_HOURS_OFFSET = 0x010;
                TIMESTAMP_MINUTES_OFFSET = 0x014;
                TIMESTAMP_SECONDS_OFFSET = 0x018;
            }
            else if (SELECTED_TAB == TAB_TR6)
            {
                LEVEL_INDEX_OFFSET = 0x14;
                DISTANCE_TRAVELLED_OFFSET = 0x244;
                TIME_TAKEN_OFFSET = 0x240;
                AMMO_USED_OFFSET = 0x248;
                HITS_OFFSET = 0x24C;
                PICKUPS_OFFSET = 0x250;
                HEALTH_ITEMS_FOUND_OFFSET = 0x252;
                CHOCOBARS_FOUND_OFFSET = 0x254;
                KILLS_OFFSET = 0x256;
                MEDIPACKS_USED_OFFSET = 0x258;
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

                nudPickups.Maximum = MAX_PICKUPS_TR4;
                nudPickups.Minimum = 0;

                nudKills.Maximum = UInt16.MaxValue;
                nudKills.Minimum = UInt16.MinValue;

                nudMedipacksUsed.Maximum = Byte.MaxValue;
                nudMedipacksUsed.Minimum = Byte.MinValue;

                nudSecretsFound.Maximum = MAX_SECRETS_FOUND_TR4;
                nudSecretsFound.Minimum = Byte.MinValue;

                nudVesselsBroken.Enabled = true;
                nudVesselsBroken.Maximum = MAX_VESSELS_BROKEN_TR4;

                nudPickupsMax.Maximum = MAX_PICKUPS_TR4;
                nudSecretsFoundMax.Value = MAX_SECRETS_FOUND_TR4;
                nudVesselsBrokenMax.Value = MAX_VESSELS_BROKEN_TR4;
                nudPickupsMax.Value = MAX_PICKUPS_TR4;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                nudHits.Visible = false;
                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                lblAmmoUsedHits.Text = "Ammo Used:";
                lblMedipacksUsed.Text = "Health Packs Used:";
                lblOf.Text = "/";
                lblOf2.Text = "/";

                lblSlash.Visible = false;
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                nudAmmoUsed.Maximum = Int16.MaxValue;
                nudAmmoUsed.Minimum = Int16.MinValue;

                nudKills.Maximum = UInt16.MaxValue;
                nudKills.Minimum = UInt16.MinValue;

                nudMedipacksUsed.Maximum = Byte.MaxValue;
                nudMedipacksUsed.Minimum = Byte.MinValue;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                nudSecretsFound.Maximum = MAX_SECRETS_FOUND_TR5;
                nudSecretsFound.Minimum = Byte.MinValue;
                nudSecretsFoundMax.Value = MAX_SECRETS_FOUND_TR5;

                nudPickupsMax.Value = MAX_PICKUPS_TR5;
                nudPickups.Maximum = MAX_PICKUPS_TR5;
                nudPickups.Minimum = 0;

                nudHits.Visible = false;

                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                lblAmmoUsedHits.Text = "Ammo Used:";
                lblMedipacksUsed.Text = "Health Packs Used:";
                lblOf.Text = "/";
                lblOf2.Text = "/";

                lblSlash.Visible = false;
            }
            else if (SELECTED_TAB == TAB_TR6)
            {
                nudAmmoUsed.Maximum = Int32.MaxValue;
                nudAmmoUsed.Minimum = 0;

                nudHits.Maximum = Int32.MaxValue;
                nudHits.Minimum = 0;

                nudMedipacksUsed.Maximum = Byte.MaxValue;
                nudMedipacksUsed.Minimum = 0;

                nudKills.Maximum = UInt16.MaxValue;
                nudKills.Minimum = 0;

                nudSecretsFound.Enabled = false;
                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                lblMedipacksUsed.Text = "Health Restored:";
                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                nudChocobarsFound.Enabled = true;
                nudHealthItemsFound.Enabled = true;

                nudVesselsBroken.Enabled = false;

                nudPickupsMax.Value = pickupsFoundMaxTR6[levelIndex];
                nudPickups.Maximum = nudPickupsMax.Value;

                nudHealthItemsFoundMax.Value = healthItemsFoundMaxTR6[levelIndex];
                nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                nudChocobarsFoundMax.Value = chocobarsFoundMaxTR6[levelIndex];
                nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;

                lblOf2.Text = "/";
            }
        }

        private void UpdateDynamicParams(byte[] fileData)
        {
            byte levelIndex = GetLevelIndex(fileData);

            if (SELECTED_TAB == TAB_TR1)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR1[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR1[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsUsed.Enabled = selectedSavegame.Mode == GameMode.Plus;
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR2[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3[levelIndex];
                nudPickupsMax.Value = pickupsFoundMaxTR3[levelIndex];

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsUsed.Enabled = selectedSavegame.Mode == GameMode.Plus;
            }
            else if (SELECTED_TAB == TAB_TR6)
            {
                nudPickupsMax.Value = pickupsFoundMaxTR6[levelIndex];
                nudPickups.Maximum = nudPickupsMax.Value;

                nudHealthItemsFoundMax.Value = healthItemsFoundMaxTR6[levelIndex];
                nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                nudChocobarsFoundMax.Value = chocobarsFoundMaxTR6[levelIndex];
                nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;
            }
        }

        private void UpdateSavegameDisplayName(byte[] fileData)
        {
            if (SELECTED_TAB == TAB_TR1)
            {
                TR1.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == TAB_TR2)
            {
                TR2.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == TAB_TR3)
            {
                TR3.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == TAB_TR4)
            {
                TR4.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == TAB_TR5)
            {
                TR5.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == TAB_TR6)
            {
                TR6.UpdateDisplayName(selectedSavegame, fileData);
            }

            grpSavegameStatistics.Text = $"{selectedSavegame}";
        }

        private bool IsTRXSavegame()
        {
            return SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3;
        }

        private bool HasDynamicParams()
        {
            return SELECTED_TAB == TAB_TR1 || SELECTED_TAB == TAB_TR2 || SELECTED_TAB == TAB_TR3 || SELECTED_TAB == TAB_TR6;
        }

        private void WriteInt32ToBuffer(byte[] buffer, int offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void WriteUInt32ToBuffer(byte[] buffer, int offset, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void WriteInt16ToBuffer(byte[] buffer, int offset, short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 2);
        }

        private void WriteUInt16ToBuffer(byte[] buffer, int offset, UInt16 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 2);
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

        private bool IsSavegamePresent(byte[] fileData = null)
        {
            if (fileData == null)
            {
                fileData = File.ReadAllBytes(savegamePath);
            }

            return fileData[savegameOffset + SLOT_STATUS_OFFSET] != 0;
        }

        private byte GetLevelIndex(byte[] fileData = null)
        {
            if (fileData == null)
            {
                fileData = File.ReadAllBytes(savegamePath);
            }

            return fileData[savegameOffset + LEVEL_INDEX_OFFSET];
        }

        private void DisplayStatistics()
        {
            isLoading = true;

            try
            {
                byte[] fileData = File.ReadAllBytes(savegamePath);

                if (!IsSavegamePresent(fileData))
                {
                    string errorMessage = $"Savegame no longer present.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DisableButtons();
                    this.Close();
                    return;
                }

                UpdateSavegameDisplayName(fileData);

                if (HasDynamicParams())
                {
                    UpdateDynamicParams(fileData);
                }

                if (IsTRXSavegame())
                {
                    nudSecretsFound.Value = GetNumSecretsFoundTRX(fileData);
                    nudPickups.Value = GetNumPickupsTRX(fileData);
                    nudKills.Value = GetNumKillsTRX(fileData);
                    nudAmmoUsed.Value = GetAmmoUsedTRX(fileData);
                    nudHits.Value = GetNumHits(fileData);
                    nudMedipacksUsed.Value = (decimal)GetNumMedipacksUsedTRX(fileData) / 2;

                    if (nudCrystalsFound.Enabled)
                    {
                        nudCrystalsFound.Value = GetNumCrystalsFound(fileData);
                    }

                    if (nudCrystalsUsed.Enabled)
                    {
                        nudCrystalsUsed.Value = GetNumCrystalsUsed(fileData);
                    }

                    DisplayDistanceTravelledTRX(fileData);
                    DisplayTimeTaken(fileData);
                }
                else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
                {
                    nudSecretsFound.Value = GetNumSecretsFoundTRX2(fileData);
                    nudMedipacksUsed.Value = GetNumMedipacksUsedTRX2(fileData);
                    nudKills.Value = GetNumKillsTRX2(fileData);
                    nudPickups.Value = GetNumPickupsTRX2(fileData);
                    nudAmmoUsed.Value = GetAmmoUsedTRX2(fileData);
                    DisplayDistanceTravelledTRX2(fileData);
                    DisplayTimeTaken(fileData);

                    if (nudVesselsBroken.Enabled)
                    {
                        nudVesselsBroken.Value = GetNumVesselsBroken(fileData);
                    }
                }
                else if (SELECTED_TAB == TAB_TR6)
                {
                    nudAmmoUsed.Value = GetAmmoUsedTR6(fileData);
                    nudMedipacksUsed.Value = GetHealthRestored(fileData);
                    nudHits.Value = GetNumHits(fileData);
                    nudKills.Value = GetNumKillsTR6(fileData);
                    nudPickups.Value = GetNumPickupsTR6(fileData);
                    nudHealthItemsFound.Value = GetNumHealthItemsFound(fileData);
                    nudChocobarsFound.Value = GetNumChocobarsFound(fileData);

                    DisplayDistanceTravelledTRX2(fileData);
                    DisplayTimeTakenTR6(fileData);
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

        private void DisplayDistanceTravelledTRX(byte[] fileData)
        {
            UInt32 distanceTravelledRaw = GetDistanceTravelled(fileData);

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

        private void DisplayDistanceTravelledTRX2(byte[] fileData)
        {
            UInt32 distanceTravelledRaw = GetDistanceTravelled(fileData);

            decimal distanceTravelledMeters = distanceTravelledRaw / 419;
            decimal distanceToShow;

            distanceToShow = distanceTravelledMeters;

            nudDistanceTravelled.DecimalPlaces = 0;
            nudDistanceTravelled.Increment = 1;
            lblDistanceTravelledUnit.Text = "m";

            nudDistanceTravelled.Value = distanceToShow;
        }

        private void DisplayTimeTaken(byte[] fileData)
        {
            Int32 timeTakenRaw = GetTimeTaken(fileData);
            Int32 timeTakenSeconds = timeTakenRaw / 30;
            Int32 remainingSeconds = timeTakenSeconds % 60;
            Int32 totalMinutes = timeTakenSeconds / 60;
            Int32 remainingMinutes = totalMinutes % 60;
            Int32 totalHours = totalMinutes / 60;

            nudHours.Value = totalHours;
            nudMinutes.Value = remainingMinutes;
            nudSeconds.Value = remainingSeconds;
        }

        private void DisplayTimeTakenTR6(byte[] fileData)
        {
            Int32 timeTakenRaw = GetTimeTaken(fileData);
            Int32 timeTakenSeconds = timeTakenRaw / 60;
            Int32 remainingSeconds = timeTakenSeconds % 60;
            Int32 totalMinutes = timeTakenSeconds / 60;
            Int32 remainingMinutes = totalMinutes % 60;
            Int32 totalHours = totalMinutes / 60;

            nudHours.Value = totalHours;
            nudMinutes.Value = remainingMinutes;
            nudSeconds.Value = remainingSeconds;
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

        private Int32 GetAmmoUsedTRX(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + AMMO_USED_OFFSET);
        }

        private Int16 GetAmmoUsedTRX2(byte[] fileData)
        {
            return BitConverter.ToInt16(fileData, savegameOffset + AMMO_USED_OFFSET);
        }

        private Int32 GetAmmoUsedTR6(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + AMMO_USED_OFFSET);
        }

        private Int32 GetNumHits(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + HITS_OFFSET);
        }

        private Int32 GetNumKillsTRX(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + KILLS_OFFSET);
        }

        private UInt16 GetNumKillsTRX2(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + KILLS_OFFSET);
        }

        private UInt16 GetNumKillsTR6(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + KILLS_OFFSET);
        }

        private UInt32 GetDistanceTravelled(byte[] fileData)
        {
            return BitConverter.ToUInt32(fileData, savegameOffset + DISTANCE_TRAVELLED_OFFSET);
        }

        private Int32 GetTimeTaken(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + TIME_TAKEN_OFFSET);
        }

        private UInt16 GetNumSecretsFoundTRX(byte[] fileData)
        {
            UInt16 rawValue = BitConverter.ToUInt16(fileData, savegameOffset + SECRETS_FOUND_OFFSET);
            return RawSecretsValueToDisplayValue(rawValue);
        }

        private byte GetNumSecretsFoundTRX2(byte[] fileData)
        {
            return fileData[savegameOffset + SECRETS_FOUND_OFFSET];
        }

        private sbyte GetNumPickupsTRX(byte[] fileData)
        {
            return (sbyte)fileData[savegameOffset + PICKUPS_OFFSET];
        }

        private UInt16 GetNumPickupsTR6(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + PICKUPS_OFFSET);
        }

        private Int32 GetNumPickupsTRX2(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + PICKUPS_OFFSET);
        }

        private sbyte GetNumMedipacksUsedTRX(byte[] fileData)
        {
            return (sbyte)fileData[savegameOffset + MEDIPACKS_USED_OFFSET];
        }

        private byte GetNumMedipacksUsedTRX2(byte[] fileData)
        {
            return fileData[savegameOffset + MEDIPACKS_USED_OFFSET];
        }

        private UInt16 GetNumHealthItemsFound(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + HEALTH_ITEMS_FOUND_OFFSET);
        }

        private byte GetNumChocobarsFound(byte[] fileData)
        {
            return fileData[savegameOffset + CHOCOBARS_FOUND_OFFSET];
        }

        private byte GetHealthRestored(byte[] fileData)
        {
            return fileData[savegameOffset + MEDIPACKS_USED_OFFSET];
        }

        private Int32 GetNumCrystalsFound(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + CRYSTALS_FOUND_OFFSET);
        }

        private Int32 GetNumVesselsBroken(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + VESSELS_BROKEN_OFFSET);
        }

        private Int32 GetNumCrystalsUsed(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + CRYSTALS_USED_OFFSET);
        }

        private void WriteAmmoUsedTRX(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + AMMO_USED_OFFSET, value);
        }

        private void WriteAmmoUsedTRX2(byte[] fileData, Int16 value)
        {
            WriteInt16ToBuffer(fileData, savegameOffset + AMMO_USED_OFFSET, value);
        }

        private void WriteAmmoUsedTR6(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + AMMO_USED_OFFSET, value);
        }

        private void WriteNumHits(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + HITS_OFFSET, value);
        }

        private void WriteNumKillsTRX(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + KILLS_OFFSET, value);
        }

        private void WriteNumKillsTRX2(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + KILLS_OFFSET, value);
        }

        private void WriteNumKillsTR6(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + KILLS_OFFSET, value);
        }

        private void WriteHealthRestored(byte[] fileData, byte value)
        {
            fileData[savegameOffset + MEDIPACKS_USED_OFFSET] = value;
        }

        private void WriteNumSecretsFoundTRX(byte[] fileData, UInt16 value)
        {
            UInt16 rawValue = 0;

            for (int i = 0; i < value; i++)
            {
                rawValue |= (UInt16)(1 << i);
            }

            WriteUInt16ToBuffer(fileData, savegameOffset + SECRETS_FOUND_OFFSET, rawValue);
        }

        private void WriteNumSecretsFoundTRX2(byte[] fileData, byte value)
        {
            fileData[savegameOffset + SECRETS_FOUND_OFFSET] = value;
        }

        private void WriteNumPickupsTRX(byte[] fileData, sbyte value)
        {
            fileData[savegameOffset + PICKUPS_OFFSET] = (byte)value;
        }

        private void WriteNumPickupsTRX2(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + PICKUPS_OFFSET, value);
        }

        private void WriteNumPickupsTR6(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + PICKUPS_OFFSET, value);
        }

        private void WriteNumMedipacksUsedTRX(byte[] fileData, sbyte value)
        {
            fileData[savegameOffset + MEDIPACKS_USED_OFFSET] = (byte)value;
        }

        private void WriteNumMedipacksUsedTRX2(byte[] fileData, byte value)
        {
            fileData[savegameOffset + MEDIPACKS_USED_OFFSET] = value;
        }

        private void WriteNumCrystalsFound(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + CRYSTALS_FOUND_OFFSET, value);
        }

        private void WriteNumCrystalsUsed(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + CRYSTALS_USED_OFFSET, value);
        }

        private void WriteTimeTaken(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + TIME_TAKEN_OFFSET, value);
        }

        private void WriteTimeTakenToTimestamp(byte[] fileData, Int32 value)
        {
            Int32 totalSeconds = value / 30;

            Int32 days = totalSeconds / 86400;                      // 86400 seconds in a day
            Int32 hours = (totalSeconds % 86400) / 3600;            // Remaining hours
            Int32 minutes = (totalSeconds % 3600) / 60;             // Remaining minutes
            Int32 seconds = totalSeconds % 60;                      // Remaining seconds

            WriteInt32ToBuffer(fileData, savegameOffset + TIMESTAMP_DAYS_OFFSET, days);
            WriteInt32ToBuffer(fileData, savegameOffset + TIMESTAMP_HOURS_OFFSET, hours);
            WriteInt32ToBuffer(fileData, savegameOffset + TIMESTAMP_MINUTES_OFFSET, minutes);
            WriteInt32ToBuffer(fileData, savegameOffset + TIMESTAMP_SECONDS_OFFSET, seconds);
        }

        private void WriteDistanceTravelledTRX(byte[] fileData, decimal value)
        {
            bool isMeter = lblDistanceTravelledUnit.Text == "m";

            if (!isMeter)
            {
                value = (decimal)(value * 1000);
            }

            value *= 445;

            WriteUInt32ToBuffer(fileData, savegameOffset + DISTANCE_TRAVELLED_OFFSET, (UInt32)value);
        }

        private void WriteDistanceTravelledTRX2(byte[] fileData, decimal value)
        {
            value *= 419;

            WriteUInt32ToBuffer(fileData, savegameOffset + DISTANCE_TRAVELLED_OFFSET, (UInt32)value);
        }

        private void WriteVesselsBroken(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + VESSELS_BROKEN_OFFSET, value);
        }

        private void WriteNumHealthItemsFound(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + HEALTH_ITEMS_FOUND_OFFSET, value);
        }

        private void WriteNumChocobarsFound(byte[] fileData, byte value)
        {
            fileData[savegameOffset + CHOCOBARS_FOUND_OFFSET] = value;
        }

        private void WriteChanges()
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(savegamePath);

                if (!IsSavegamePresent(fileData))
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
                    WriteAmmoUsedTRX(fileData, (Int32)nudAmmoUsed.Value);
                    WriteNumHits(fileData, (Int32)nudHits.Value);
                    WriteNumKillsTRX(fileData, (Int32)nudKills.Value);
                    WriteNumPickupsTRX(fileData, (sbyte)nudPickups.Value);
                    WriteNumMedipacksUsedTRX(fileData, (sbyte)(nudMedipacksUsed.Value * 2));
                    WriteTimeTaken(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteDistanceTravelledTRX(fileData, (decimal)nudDistanceTravelled.Value);
                    WriteNumSecretsFoundTRX(fileData, (UInt16)nudSecretsFound.Value);

                    if (nudCrystalsFound.Enabled)
                    {
                        WriteNumCrystalsFound(fileData, (Int32)nudCrystalsFound.Value);
                    }

                    if (nudCrystalsUsed.Enabled)
                    {
                        WriteNumCrystalsUsed(fileData, (Int32)nudCrystalsUsed.Value);
                    }
                }
                else if (SELECTED_TAB == TAB_TR4 || SELECTED_TAB == TAB_TR5)
                {
                    WriteAmmoUsedTRX2(fileData, (Int16)nudAmmoUsed.Value);
                    WriteNumKillsTRX2(fileData, (UInt16)nudKills.Value);
                    WriteNumPickupsTRX2(fileData, (Int32)nudPickups.Value);
                    WriteNumMedipacksUsedTRX2(fileData, (byte)nudMedipacksUsed.Value);
                    WriteNumSecretsFoundTRX2(fileData, (byte)nudSecretsFound.Value);
                    WriteTimeTaken(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteTimeTakenToTimestamp(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteDistanceTravelledTRX2(fileData, (decimal)nudDistanceTravelled.Value);

                    if (nudVesselsBroken.Enabled)
                    {
                        WriteVesselsBroken(fileData, (Int32)nudVesselsBroken.Value);
                    }
                }
                else if (SELECTED_TAB == TAB_TR6)
                {
                    WriteAmmoUsedTR6(fileData, (Int16)nudAmmoUsed.Value);
                    WriteHealthRestored(fileData, (byte)nudMedipacksUsed.Value);
                    WriteNumHits(fileData, (Int32)nudHits.Value);
                    WriteNumKillsTR6(fileData, (UInt16)nudKills.Value);
                    WriteNumPickupsTR6(fileData, (UInt16)nudPickups.Value);
                    WriteNumHealthItemsFound(fileData, (UInt16)nudHealthItemsFound.Value);
                    WriteNumChocobarsFound(fileData, (byte)nudChocobarsFound.Value);
                    WriteDistanceTravelledTRX2(fileData, (decimal)nudDistanceTravelled.Value);
                    WriteTimeTaken(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 60);
                }

                File.WriteAllBytes(savegamePath, fileData);

                DisableButtons();
                UpdateSavegameDisplayName(fileData);

                slblStatus.Text = $"Successfully patched statistics of savegame: '{selectedSavegame}'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slblStatus.Text = $"Error editing savegame statistics.";
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

        private void nudHealthItemsFound_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                EnableButtons();
            }
        }

        private void nudChocobarsFound_ValueChanged(object sender, EventArgs e)
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

        private void nudHealthItemsFound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
        }

        private void nudChocobarsFound_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                EnableButtons();
            }
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

        private readonly Dictionary<byte, int> pickupsFoundMaxTR6 = new Dictionary<byte, int>
        {
            {  0, 19 },  // Parisian Back Streets
            {  1, 11 },  // Derelict Apartment Block
            {  2, 5  },  // Margot Carvier's Apartment
            {  3, 14 },  // Industrial Roof Tops
            {  4, 2  },  // Parisian Ghetto (Part 1)
            {  5, 0  },  // Parisian Ghetto (Part 2)
            {  6, 4  },  // Parisian Ghetto (Part 3)
            {  7, 35 },  // The Serpent Rouge
            {  8, 9  },  // Rennes' Pawnshop
            {  9, 0  },  // Willowtree Herbalist
            { 10, 5  },  // St. Aicard's Church
            { 11, 2  },  // Cafe Metro
            { 12, 7  },  // St. Aicard's Graveyard
            { 13, 8  },  // Bouchard's Hideout
            { 14, 6  },  // Louvre Storm Drains
            { 15, 12 },  // Louvre Galleries
            { 16, 10 },  // Galleries Under Siege
            { 17, 5  },  // Tomb of Ancients
            { 18, 4  },  // The Archaeological Dig
            { 19, 36 },  // Von Croy's Apartment
            { 20, 8  },  // The Monstrum Crimescene
            { 21, 20 },  // The Strahov Fortress
            { 22, 26 },  // The Bio-Research Facility
            { 23, 3  },  // Aquatic Research Area
            { 24, 13 },  // The Sanitarium
            { 25, 10 },  // Maximum Containment Area
            { 26, 5  },  // The Vault of Trophies
            { 27, 2  },  // Boaz Returns
            { 28, 7  },  // Eckhardt's Lab
            { 29, 1  },  // The Lost Domain
            { 30, 17 },  // The Hall of Seasons
            { 31, 8  },  // Neptune's Hall
            { 32, 4  },  // Wrath of the Beast
            { 33, 3  },  // The Sanctuary of Flame
            { 34, 6  },  // The Breath of Hades
        };

        private readonly Dictionary<byte, int> healthItemsFoundMaxTR6 = new Dictionary<byte, int>
        {
            {  0, 5  },  // Parisian Back Streets
            {  1, 3  },  // Derelict Apartment Block
            {  2, 1  },  // Margot Carvier's Apartment
            {  3, 5  },  // Industrial Roof Tops
            {  4, 1  },  // Parisian Ghetto (Part 1)
            {  5, 0  },  // Parisian Ghetto (Part 2)
            {  6, 0  },  // Parisian Ghetto (Part 3)
            {  7, 4  },  // The Serpent Rouge
            {  8, 0  },  // Rennes' Pawnshop
            {  9, 0  },  // Willowtree Herbalist
            { 10, 1  },  // St. Aicard's Church
            { 11, 0  },  // Cafe Metro
            { 12, 3  },  // St. Aicard's Graveyard
            { 13, 2  },  // Bouchard's Hideout
            { 14, 1  },  // Louvre Storm Drains
            { 15, 5  },  // Louvre Galleries
            { 16, 1  },  // Galleries Under Siege
            { 17, 2  },  // Tomb of Ancients
            { 18, 0  },  // The Archaeological Dig
            { 19, 6  },  // Von Croy's Apartment
            { 20, 2  },  // The Monstrum Crimescene
            { 21, 2  },  // The Strahov Fortress
            { 22, 7  },  // The Bio-Research Facility
            { 23, 1  },  // Aquatic Research Area
            { 24, 2  },  // The Sanitarium
            { 25, 1  },  // Maximum Containment Area
            { 26, 2  },  // The Vault of Trophies
            { 27, 0  },  // Boaz Returns
            { 28, 2  },  // Eckhardt's Lab
            { 29, 1  },  // The Lost Domain
            { 30, 4  },  // The Hall of Seasons
            { 31, 3  },  // Neptune's Hall
            { 32, 1  },  // Wrath of the Beast
            { 33, 1  },  // The Sanctuary of Flame
            { 34, 1  },  // The Breath of Hades
        };

        private readonly Dictionary<byte, int> chocobarsFoundMaxTR6 = new Dictionary<byte, int>
        {
            {  0, 3  },  // Parisian Back Streets
            {  1, 1  },  // Derelict Apartment Block
            {  2, 0  },  // Margot Carvier's Apartment
            {  3, 1  },  // Industrial Roof Tops
            {  4, 1  },  // Parisian Ghetto (Part 1)
            {  5, 0  },  // Parisian Ghetto (Part 2)
            {  6, 0  },  // Parisian Ghetto (Part 3)
            {  7, 4  },  // The Serpent Rouge
            {  8, 0  },  // Rennes' Pawnshop
            {  9, 0  },  // Willowtree Herbalist
            { 10, 0  },  // St. Aicard's Church
            { 11, 0  },  // Cafe Metro
            { 12, 1  },  // St. Aicard's Graveyard
            { 13, 0  },  // Bouchard's Hideout
            { 14, 1  },  // Louvre Storm Drains
            { 15, 0  },  // Louvre Galleries
            { 16, 0  },  // Galleries Under Siege
            { 17, 0  },  // Tomb of Ancients
            { 18, 0  },  // The Archaeological Dig
            { 19, 1  },  // Von Croy's Apartment
            { 20, 0  },  // The Monstrum Crimescene
            { 21, 1  },  // The Strahov Fortress
            { 22, 0  },  // The Bio-Research Facility
            { 23, 0  },  // Aquatic Research Area
            { 24, 3  },  // The Sanitarium
            { 25, 2  },  // Maximum Containment Area
            { 26, 0  },  // The Vault of Trophies
            { 27, 0  },  // Boaz Returns
            { 28, 0  },  // Eckhardt's Lab
            { 29, 0  },  // The Lost Domain
            { 30, 0  },  // The Hall of Seasons
            { 31, 0  },  // Neptune's Hall
            { 32, 0  },  // Wrath of the Beast
            { 33, 0  },  // The Sanctuary of Flame
            { 34, 0  },  // The Breath of Hades
        };
    }
}
