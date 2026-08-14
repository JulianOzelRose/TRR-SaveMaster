using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using TRR_SaveMaster.Properties;
using static TRR_SaveMaster.MainForm;

namespace TRR_SaveMaster
{
    public partial class StatisticsForm : Form
    {
        // Offsets
        private int SLOT_STATUS_OFFSET;
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
        private int WORLD_STATE_OFFSET_TR3;

        // Common offsets (TR1-5)
        private const int SLOT_STATUS_OFFSET_DEFAULT = 0x0;

        // TR1 offsets (PC)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR1_PC = 0x4C;
        private const int LEVEL_INDEX_OFFSET_TR1_PC = 0x628;
        private const int CRYSTALS_USED_OFFSET_TR1_PC = 0x60C;
        private const int AMMO_USED_OFFSET_TR1_PC = 0x614;
        private const int HITS_OFFSET_TR1_PC = 0x618;
        private const int KILLS_OFFSET_TR1_PC = 0x61C;
        private const int SECRETS_FOUND_OFFSET_TR1_PC = 0x624;
        private const int PICKUPS_OFFSET_TR1_PC = 0x626;
        private const int MEDIPACKS_USED_OFFSET_TR1_PC = 0x627;
        private const int DISTANCE_TRAVELLED_OFFSET_TR1_PC = 0x620;
        private const int TIME_TAKEN_OFFSET_TR1_PC = 0x610;

        // TR1 offsets (Prepatch)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR1_PREPATCH = 0x4C;
        private const int LEVEL_INDEX_OFFSET_TR1_PREPATCH = 0x628;
        private const int CRYSTALS_USED_OFFSET_TR1_PREPATCH = 0x60C;
        private const int AMMO_USED_OFFSET_TR1_PREPATCH = 0x614;
        private const int HITS_OFFSET_TR1_PREPATCH = 0x618;
        private const int KILLS_OFFSET_TR1_PREPATCH = 0x61C;
        private const int SECRETS_FOUND_OFFSET_TR1_PREPATCH = 0x624;
        private const int PICKUPS_OFFSET_TR1_PREPATCH = 0x626;
        private const int MEDIPACKS_USED_OFFSET_TR1_PREPATCH = 0x627;
        private const int DISTANCE_TRAVELLED_OFFSET_TR1_PREPATCH = 0x620;
        private const int TIME_TAKEN_OFFSET_TR1_PREPATCH = 0x610;

        // TR1 offsets (Mobile)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR1_MOBILE = 0x7C;
        private const int LEVEL_INDEX_OFFSET_TR1_MOBILE = 0x658;
        private const int CRYSTALS_USED_OFFSET_TR1_MOBILE = 0x63C;
        private const int AMMO_USED_OFFSET_TR1_MOBILE = 0x644;
        private const int HITS_OFFSET_TR1_MOBILE = 0x648;
        private const int KILLS_OFFSET_TR1_MOBILE = 0x64C;
        private const int SECRETS_FOUND_OFFSET_TR1_MOBILE = 0x654;
        private const int PICKUPS_OFFSET_TR1_MOBILE = 0x656;
        private const int MEDIPACKS_USED_OFFSET_TR1_MOBILE = 0x657;
        private const int DISTANCE_TRAVELLED_OFFSET_TR1_MOBILE = 0x650;
        private const int TIME_TAKEN_OFFSET_TR1_MOBILE = 0x640;

        // TR1 offsets (PS4)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR1_PS4 = 0x4C;
        private const int LEVEL_INDEX_OFFSET_TR1_PS4 = 0x628;
        private const int CRYSTALS_USED_OFFSET_TR1_PS4 = 0x60C;
        private const int AMMO_USED_OFFSET_TR1_PS4 = 0x614;
        private const int HITS_OFFSET_TR1_PS4 = 0x618;
        private const int KILLS_OFFSET_TR1_PS4 = 0x61C;
        private const int SECRETS_FOUND_OFFSET_TR1_PS4 = 0x624;
        private const int PICKUPS_OFFSET_TR1_PS4 = 0x626;
        private const int MEDIPACKS_USED_OFFSET_TR1_PS4 = 0x627;
        private const int DISTANCE_TRAVELLED_OFFSET_TR1_PS4 = 0x620;
        private const int TIME_TAKEN_OFFSET_TR1_PS4 = 0x610;

        // TR2 offsets (PC)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR2_PC = 0x50;
        private const int LEVEL_INDEX_OFFSET_TR2_PC = 0x624;
        private const int AMMO_USED_OFFSET_TR2_PC = 0x610;
        private const int HITS_OFFSET_TR2_PC = 0x614;
        private const int KILLS_OFFSET_TR2_PC = 0x618;
        private const int SECRETS_FOUND_OFFSET_TR2_PC = 0x620;
        private const int PICKUPS_OFFSET_TR2_PC = 0x622;
        private const int MEDIPACKS_USED_OFFSET_TR2_PC = 0x623;
        private const int DISTANCE_TRAVELLED_OFFSET_TR2_PC = 0x61C;
        private const int TIME_TAKEN_OFFSET_TR2_PC = 0x60C;

        // TR2 offsets (Prepatch)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR2_PREPATCH = 0x50;
        private const int LEVEL_INDEX_OFFSET_TR2_PREPATCH = 0x624;
        private const int AMMO_USED_OFFSET_TR2_PREPATCH = 0x610;
        private const int HITS_OFFSET_TR2_PREPATCH = 0x614;
        private const int KILLS_OFFSET_TR2_PREPATCH = 0x618;
        private const int SECRETS_FOUND_OFFSET_TR2_PREPATCH = 0x620;
        private const int PICKUPS_OFFSET_TR2_PREPATCH = 0x622;
        private const int MEDIPACKS_USED_OFFSET_TR2_PREPATCH = 0x623;
        private const int DISTANCE_TRAVELLED_OFFSET_TR2_PREPATCH = 0x61C;
        private const int TIME_TAKEN_OFFSET_TR2_PREPATCH = 0x60C;

        // TR2 offsets (Mobile)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR2_MOBILE = 0x80;
        private const int LEVEL_INDEX_OFFSET_TR2_MOBILE = 0x654;
        private const int AMMO_USED_OFFSET_TR2_MOBILE = 0x640;
        private const int HITS_OFFSET_TR2_MOBILE = 0x644;
        private const int KILLS_OFFSET_TR2_MOBILE = 0x648;
        private const int SECRETS_FOUND_OFFSET_TR2_MOBILE = 0x650;
        private const int PICKUPS_OFFSET_TR2_MOBILE = 0x652;
        private const int MEDIPACKS_USED_OFFSET_TR2_MOBILE = 0x653;
        private const int DISTANCE_TRAVELLED_OFFSET_TR2_MOBILE = 0x64C;
        private const int TIME_TAKEN_OFFSET_TR2_MOBILE = 0x63C;

        // TR2 offsets (PS4)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR2_PS4 = 0x50;
        private const int LEVEL_INDEX_OFFSET_TR2_PS4 = 0x624;
        private const int AMMO_USED_OFFSET_TR2_PS4 = 0x610;
        private const int HITS_OFFSET_TR2_PS4 = 0x614;
        private const int KILLS_OFFSET_TR2_PS4 = 0x618;
        private const int SECRETS_FOUND_OFFSET_TR2_PS4 = 0x620;
        private const int PICKUPS_OFFSET_TR2_PS4 = 0x622;
        private const int MEDIPACKS_USED_OFFSET_TR2_PS4 = 0x623;
        private const int DISTANCE_TRAVELLED_OFFSET_TR2_PS4 = 0x61C;
        private const int TIME_TAKEN_OFFSET_TR2_PS4 = 0x60C;

        // TR3 offsets (PC)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR3_PC = 0xBC;
        private const int LEVEL_INDEX_OFFSET_TR3_PC = 0x8D2;
        private const int CRYSTALS_FOUND_OFFSET_TR3_PC = 0x8A0;
        private const int CRYSTALS_USED_OFFSET_TR3_PC = 0x8A4;
        private const int TIME_TAKEN_OFFSET_TR3_PC = 0x8A8;
        private const int AMMO_USED_OFFSET_TR3_PC = 0x8AC;
        private const int HITS_OFFSET_TR3_PC = 0x8B0;
        private const int KILLS_OFFSET_TR3_PC = 0x8B4;
        private const int DISTANCE_TRAVELLED_OFFSET_TR3_PC = 0x8B8;
        private const int SECRETS_FOUND_OFFSET_TR3_PC = 0x8BC;
        private const int PICKUPS_OFFSET_TR3_PC = 0x8BE;
        private const int MEDIPACKS_USED_OFFSET_TR3_PC = 0x8BF;
        private const int WORLD_STATE_OFFSET_TR3_PC = 0x984;

        // TR3 offsets (Prepatch)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR3_PREPATCH = 0xBC;
        private const int LEVEL_INDEX_OFFSET_TR3_PREPATCH = 0x8D2;
        private const int CRYSTALS_FOUND_OFFSET_TR3_PREPATCH = 0x8A0;
        private const int CRYSTALS_USED_OFFSET_TR3_PREPATCH = 0x8A4;
        private const int TIME_TAKEN_OFFSET_TR3_PREPATCH = 0x8A8;
        private const int AMMO_USED_OFFSET_TR3_PREPATCH = 0x8AC;
        private const int HITS_OFFSET_TR3_PREPATCH = 0x8B0;
        private const int KILLS_OFFSET_TR3_PREPATCH = 0x8B4;
        private const int DISTANCE_TRAVELLED_OFFSET_TR3_PREPATCH = 0x8B8;
        private const int SECRETS_FOUND_OFFSET_TR3_PREPATCH = 0x8BC;
        private const int PICKUPS_OFFSET_TR3_PREPATCH = 0x8BE;
        private const int MEDIPACKS_USED_OFFSET_TR3_PREPATCH = 0x8BF;
        private const int WORLD_STATE_OFFSET_TR3_PREPATCH = 0x984;

        // TR3 offsets (Mobile)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR3_MOBILE = 0xFC;
        private const int LEVEL_INDEX_OFFSET_TR3_MOBILE = 0x912;
        private const int CRYSTALS_FOUND_OFFSET_TR3_MOBILE = 0x8E0;
        private const int CRYSTALS_USED_OFFSET_TR3_MOBILE = 0x8E4;
        private const int TIME_TAKEN_OFFSET_TR3_MOBILE = 0x8E8;
        private const int AMMO_USED_OFFSET_TR3_MOBILE = 0x8EC;
        private const int HITS_OFFSET_TR3_MOBILE = 0x8F0;
        private const int KILLS_OFFSET_TR3_MOBILE = 0x8F4;
        private const int DISTANCE_TRAVELLED_OFFSET_TR3_MOBILE = 0x8F8;
        private const int SECRETS_FOUND_OFFSET_TR3_MOBILE = 0x8FC;
        private const int PICKUPS_OFFSET_TR3_MOBILE = 0x8FE;
        private const int MEDIPACKS_USED_OFFSET_TR3_MOBILE = 0x8FF;
        private const int WORLD_STATE_OFFSET_TR3_MOBILE = 0x9C2;

        // TR3 offsets (PS4)
        private const int STATISTICS_ARRAY_BASE_OFFSET_TR3_PS4 = 0xBC;
        private const int LEVEL_INDEX_OFFSET_TR3_PS4 = 0x8D2;
        private const int CRYSTALS_FOUND_OFFSET_TR3_PS4 = 0x8A0;
        private const int CRYSTALS_USED_OFFSET_TR3_PS4 = 0x8A4;
        private const int TIME_TAKEN_OFFSET_TR3_PS4 = 0x8A8;
        private const int AMMO_USED_OFFSET_TR3_PS4 = 0x8AC;
        private const int HITS_OFFSET_TR3_PS4 = 0x8B0;
        private const int KILLS_OFFSET_TR3_PS4 = 0x8B4;
        private const int DISTANCE_TRAVELLED_OFFSET_TR3_PS4 = 0x8B8;
        private const int SECRETS_FOUND_OFFSET_TR3_PS4 = 0x8BC;
        private const int PICKUPS_OFFSET_TR3_PS4 = 0x8BE;
        private const int MEDIPACKS_USED_OFFSET_TR3_PS4 = 0x8BF;
        private const int WORLD_STATE_OFFSET_TR3_PS4 = 0x984;

        // TR4 offsets
        private const int LEVEL_INDEX_OFFSET_TR4 = 0x26B;
        private const int TIME_TAKEN_OFFSET_TR4 = 0x22C;
        private const int DISTANCE_TRAVELLED_OFFSET_TR4 = 0x230;
        private const int AMMO_USED_OFFSET_TR4 = 0x234;
        private const int PICKUPS_OFFSET_TR4 = 0x23C;
        private const int KILLS_OFFSET_TR4 = 0x240;
        private const int SECRETS_FOUND_OFFSET_TR4 = 0x242;
        private const int MEDIPACKS_USED_OFFSET_TR4 = 0x243;
        private const int VESSELS_BROKEN_OFFSET_TR4 = 0x27C;
        private const int TIMESTAMP_DAYS_OFFSET_TR4 = 0x008;
        private const int TIMESTAMP_HOURS_OFFSET_TR4 = 0x00C;
        private const int TIMESTAMP_MINUTES_OFFSET_TR4 = 0x010;
        private const int TIMESTAMP_SECONDS_OFFSET_TR4 = 0x014;
        private const int GAME_FLAGS_OFFSET_TR4 = 0x278;

        // TR5 offsets
        private const int LEVEL_INDEX_OFFSET_TR5 = 0x26B;
        private const int TIME_TAKEN_OFFSET_TR5 = 0x22C;
        private const int DISTANCE_TRAVELLED_OFFSET_TR5 = 0x230;
        private const int AMMO_USED_OFFSET_TR5 = 0x234;
        private const int PICKUPS_OFFSET_TR5 = 0x23C;
        private const int KILLS_OFFSET_TR5 = 0x240;
        private const int SECRETS_FOUND_OFFSET_TR5 = 0x242;
        private const int MEDIPACKS_USED_OFFSET_TR5 = 0x243;
        private const int TIMESTAMP_DAYS_OFFSET_TR5 = 0x008;
        private const int TIMESTAMP_HOURS_OFFSET_TR5 = 0x00C;
        private const int TIMESTAMP_MINUTES_OFFSET_TR5 = 0x010;
        private const int TIMESTAMP_SECONDS_OFFSET_TR5 = 0x014;

        // TR6 offsets
        private const int LEVEL_INDEX_OFFSET_TR6 = 0x10;
        private const int SLOT_STATUS_OFFSET_TR6 = 0x11C;
        private const int TIME_TAKEN_OFFSET_TR6 = 0x23C;
        private const int DISTANCE_TRAVELLED_OFFSET_TR6 = 0x240;
        private const int AMMO_USED_OFFSET_TR6 = 0x244;
        private const int HITS_OFFSET_TR6 = 0x248;
        private const int PICKUPS_OFFSET_TR6 = 0x24C;
        private const int HEALTH_ITEMS_FOUND_OFFSET_TR6 = 0x24E;
        private const int CHOCOBARS_FOUND_OFFSET_TR6 = 0x250;
        private const int KILLS_OFFSET_TR6 = 0x252;
        private const int MEDIPACKS_USED_OFFSET_TR6 = 0x254;
        private const int TIME_TAKEN_OFFSET_FINAL_TR6 = 0x220;
        private const int DISTANCE_TRAVELLED_OFFSET_FINAL_TR6 = 0x224;
        private const int AMMO_USED_OFFSET_FINAL_TR6 = 0x228;
        private const int HITS_OFFSET_FINAL_TR6 = 0x22C;
        private const int PICKUPS_OFFSET_FINAL_TR6 = 0x230;
        private const int HEALTH_ITEMS_FOUND_OFFSET_FINAL_TR6 = 0x232;
        private const int CHOCOBARS_FOUND_OFFSET_FINAL_TR6 = 0x234;
        private const int KILLS_OFFSET_FINAL_TR6 = 0x236;
        private const int MEDIPACKS_USED_OFFSET_FINAL_TR6 = 0x238;
        private const int GAME_FLAGS_OFFSET_TR6 = 0x258;

        // Maxes (TR3)
        private const int MAX_PICKUPS_COASTAL_VILLAGE_TR3 = 30;

        // Maxes (TR4)
        private const int MAX_PICKUPS_TR4 = 568;
        private const int MAX_PICKUPS_ALT_TR4 = 589;
        private const int MAX_VESSELS_BROKEN_TR4 = 170;
        private const int MAX_VESSELS_BROKEN_ALT_TR4 = 169;
        private const int MAX_SECRETS_FOUND_TR4 = 70;

        // Maxes (TR5)
        private const int MAX_SECRETS_FOUND_TR5 = 36;
        private const int MAX_PICKUPS_TR5 = 239;

        // Maxes (TR6)
        private const int PICKUPS_MAX_FINAL_TR6 = 320;
        private const int PICKUPS_MAX_FINAL_PREPATCH_TR6 = 318;
        private const int PICKUPS_ALLOWED_MAX_FINAL_TR6 = 323;
        private const int HEALTH_ITEMS_FOUND_MAX_FINAL_TR6 = 70;
        private const int CHOCOBARS_FOUND_MAX_FINAL_TR6 = 20;
        private const int CHOCOBARS_FOUND_MAX_FINAL_PREPATCH_TR6 = 19;

        // Utils
        private readonly TR1Utilities tr1Utilities = new TR1Utilities();
        private readonly TR2Utilities tr2Utilities = new TR2Utilities();
        private readonly TR3Utilities tr3Utilities = new TR3Utilities();
        private readonly TR4Utilities tr4Utilities = new TR4Utilities();
        private readonly TR5Utilities tr5Utilities = new TR5Utilities();
        private readonly TR6Utilities tr6Utilities = new TR6Utilities();

        // Misc
        private Savegame selectedSavegame;
        private string savegamePath;
        private int savegameOffset;
        private ToolStripStatusLabel slblStatus;
        private MainForm mainForm;
        private bool isLoading = true;
        private bool backupBeforeSaving = false;
        private int SELECTED_TAB;
        private Platform platform;
        private bool isPrepatch;
        private const byte FINAL_STATISTICS = 0xFF;
        private bool distanceTravelledDirty;

        // Flags
        private const UInt32 STATS_MAX_FLAG_TR4 = 0x800;
        private const UInt32 STATS_PATCH_FLAG_TR6 = 0x08000000;

        // TR3 world masks & shifts
        private const int WORLD_REQUIRED_SHIFT_TR3 = 2;
        private const UInt32 WORLD_REQUIRED_MASK_TR3 = 0x07;
        private const UInt32 TR3_WORLD_INDIA_COMPLETE_MASK = 0x20;
        private const UInt32 TR3_WORLD_SOUTH_PACIFIC_COMPLETE_MASK = 0x40;
        private const UInt32 TR3_WORLD_LONDON_COMPLETE_MASK = 0x80;
        private const UInt32 TR3_WORLD_NEVADA_COMPLETE_MASK = 0x100;

        // TR3 worlds
        private const int TR3_WORLD_NONE = 0;
        private const int TR3_WORLD_INDIA = 1;
        private const int TR3_WORLD_SOUTH_PACIFIC = 2;
        private const int TR3_WORLD_LONDON = 3;
        private const int TR3_WORLD_NEVADA = 4;

        // Statistics array offsets
        private int STATISTICS_ARRAY_BASE_OFFSET;
        private int STATISTICS_ARRAY_STRIDE;
        private int SECRETS_FOUND_ARRAY_OFFSET;
        private int KILLS_ARRAY_OFFSET;
        private int HITS_ARRAY_OFFSET;
        private int AMMO_USED_ARRAY_OFFSET;
        private int DISTANCE_TRAVELLED_ARRAY_OFFSET;
        private int TIME_TAKEN_ARRAY_OFFSET;
        private int PICKUPS_ARRAY_OFFSET;
        private int MEDIPACKS_USED_ARRAY_OFFSET;
        private int CRYSTALS_FOUND_ARRAY_OFFSET;
        private int CRYSTALS_USED_ARRAY_OFFSET;

        // Statistics array strides
        private const int STATISTICS_ARRAY_STRIDE_TR1 = 0x30;
        private const int STATISTICS_ARRAY_STRIDE_TR2 = 0x30;
        private const int STATISTICS_ARRAY_STRIDE_TR3 = 0x40;

        // TR1 statistics array offsets
        private const int CRYSTALS_USED_ARRAY_OFFSET_TR1 = 0x00;
        private const int TIME_TAKEN_ARRAY_OFFSET_TR1 = 0x04;
        private const int AMMO_USED_ARRAY_OFFSET_TR1 = 0x08;
        private const int HITS_ARRAY_OFFSET_TR1 = 0x0C;
        private const int KILLS_ARRAY_OFFSET_TR1 = 0x10;
        private const int DISTANCE_TRAVELLED_ARRAY_OFFSET_TR1 = 0x14;
        private const int SECRETS_FOUND_ARRAY_OFFSET_TR1 = 0x18;
        private const int PICKUPS_ARRAY_OFFSET_TR1 = 0x1A;
        private const int MEDIPACKS_USED_ARRAY_OFFSET_TR1 = 0x1B;

        // TR2 statistics array offsets
        private const int TIME_TAKEN_ARRAY_OFFSET_TR2 = 0x00;
        private const int AMMO_USED_ARRAY_OFFSET_TR2 = 0x04;
        private const int HITS_ARRAY_OFFSET_TR2 = 0x08;
        private const int KILLS_ARRAY_OFFSET_TR2 = 0x0C;
        private const int DISTANCE_TRAVELLED_ARRAY_OFFSET_TR2 = 0x10;
        private const int SECRETS_FOUND_ARRAY_OFFSET_TR2 = 0x14;
        private const int PICKUPS_ARRAY_OFFSET_TR2 = 0x16;
        private const int MEDIPACKS_USED_ARRAY_OFFSET_TR2 = 0x17;

        // TR3 statistics array offsets
        private const int CRYSTALS_FOUND_ARRAY_OFFSET_TR3 = 0x00;
        private const int CRYSTALS_USED_ARRAY_OFFSET_TR3 = 0x04;
        private const int TIME_TAKEN_ARRAY_OFFSET_TR3 = 0x08;
        private const int AMMO_USED_ARRAY_OFFSET_TR3 = 0x0C;
        private const int HITS_ARRAY_OFFSET_TR3 = 0x10;
        private const int KILLS_ARRAY_OFFSET_TR3 = 0x14;
        private const int DISTANCE_TRAVELLED_ARRAY_OFFSET_TR3 = 0x18;
        private const int SECRETS_FOUND_ARRAY_OFFSET_TR3 = 0x1C;
        private const int PICKUPS_ARRAY_OFFSET_TR3 = 0x1E;
        private const int MEDIPACKS_USED_ARRAY_OFFSET_TR3 = 0x1F;

        private class StatisticsTarget
        {
            public string DisplayName { get; set; }
            public int? LevelIndex { get; set; }

            public override string ToString()
            {
                return DisplayName;
            }
        }

        private static readonly int[] TR1_UB_LEVEL_ORDER =
        {
            18, // Atlantean Stronghold
            19, // The Hive
            16, // Return to Egypt
            17  // Temple of the Cat
        };

        private enum TR6StatisticsTarget
        {
            CurrentLevel,
            FinalStatistics
        }

        public StatisticsForm(MainForm mainForm, ToolStripStatusLabel slblStatus, bool backupBeforeSaving, string savegamePath, int SELECTED_TAB, Platform platform, bool isPrepatch)
        {
            InitializeComponent();

            this.slblStatus = slblStatus;
            this.backupBeforeSaving = backupBeforeSaving;
            this.savegamePath = savegamePath;
            this.SELECTED_TAB = SELECTED_TAB;
            this.mainForm = mainForm;
            this.platform = platform;
            this.isPrepatch = isPrepatch;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            if (ThemeUtilities.DARK_MODE_ENABLED)
            {
                ThemeUtilities.ApplyDarkMode(this);
                ThemeUtilities.ApplyDarkTitleBar(this);

                picInfoStatisticsDropdown.Image = Resources.ToolTip_Image_DarkMode;
            }

            DetermineOffsets();

            try
            {
                byte[] fileData = File.ReadAllBytes(savegamePath);

                if (ShouldShowLevelSelect(fileData))
                {
                    PopulateStatisticsDropdown(fileData);
                    SetTooltipText();
                }
                else
                {
                    HideLevelSelectUI();
                    this.CenterToParent();
                }

                SetParams(fileData);
                DisplayStatistics(fileData);
            }
            catch (Exception ex)
            {
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

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmChanges();
            mainForm.RefreshGameInfoConditionally();
        }

        private void PopulateStatisticsDropdown(byte[] fileData = null)
        {
            if (fileData == null)
            {
                fileData = File.ReadAllBytes(savegamePath);
            }

            cmbStatistics.Items.Clear();

            cmbStatistics.Items.Add(
                new StatisticsTarget
                {
                    DisplayName = "Current Level",
                    LevelIndex = null
                });

            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                PopulateTR1StatisticsTargets(fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR2)
            {
                PopulateTR2StatisticsTargets(fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR3)
            {
                PopulateTR3StatisticsTargets(fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR6)
            {
                cmbStatistics.Items.Add(
                    new StatisticsTarget
                    {
                        DisplayName = "Final Statistics",
                        LevelIndex = FINAL_STATISTICS
                    });
            }

            cmbStatistics.SelectedIndex = 0;
            cmbStatistics.Enabled = cmbStatistics.Items.Count > 1;
        }

        private void PopulateTR1StatisticsTargets(byte[] fileData)
        {
            PopulateStatisticsTargets(fileData, tr1Utilities.levelNames);
        }

        private void PopulateTR2StatisticsTargets(byte[] fileData)
        {
            PopulateStatisticsTargets(fileData, tr2Utilities.levelNames);
        }

        private void PopulateTR3StatisticsTargets(byte[] fileData)
        {
            PopulateStatisticsTargets(fileData, tr3Utilities.levelNames);
        }

        private void PopulateStatisticsTargets(byte[] fileData, Dictionary<int, string> levelNames)
        {
            int currentLevel = GetLevelIndex(fileData);

            // Nightmare in Vegas is standalone
            if (SELECTED_TAB == Globals.TAB_TR2 && currentLevel == 23)
            {
                return;
            }

            // All Hallows is standalone
            if (SELECTED_TAB == Globals.TAB_TR3 && currentLevel == 20)
            {
                return;
            }

            IEnumerable<KeyValuePair<int, string>> orderedLevels;

            if (SELECTED_TAB == Globals.TAB_TR1 && currentLevel >= 16)
            {
                orderedLevels = TR1_UB_LEVEL_ORDER.Reverse().Select(levelIndex => new KeyValuePair<int, string>(levelIndex, levelNames[levelIndex]));
            }
            else
            {
                orderedLevels = levelNames.OrderByDescending(x => x.Key);
            }

            foreach (KeyValuePair<int, string> level in orderedLevels)
            {
                if (!IsPreviousLevel(fileData, level.Key, currentLevel))
                {
                    continue;
                }

                cmbStatistics.Items.Add(
                    new StatisticsTarget
                    {
                        DisplayName = level.Value,
                        LevelIndex = level.Key
                    });
            }
        }

        private bool IsPreviousLevel(byte[] fileData, int levelIndex, int currentLevel)
        {
            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                return IsPreviousTR1Level(levelIndex, currentLevel);
            }

            if (SELECTED_TAB == Globals.TAB_TR2)
            {
                return currentLevel >= 19 ? levelIndex >= 19 && levelIndex < currentLevel : levelIndex < currentLevel;
            }

            if (SELECTED_TAB == Globals.TAB_TR3)
            {
                return IsPreviousTR3Level(fileData, levelIndex, currentLevel);
            }

            return false;
        }

        private bool IsPreviousTR1Level(int levelIndex, int currentLevel)
        {
            // Main campaign is linear
            if (currentLevel <= 15)
            {
                return levelIndex < currentLevel;
            }

            // Unfinished Business uses a non-linear level index order
            int currentPosition = Array.IndexOf(TR1_UB_LEVEL_ORDER, currentLevel);
            int candidatePosition = Array.IndexOf(TR1_UB_LEVEL_ORDER, levelIndex);

            return currentPosition >= 0 && candidatePosition >= 0 && candidatePosition < currentPosition;
        }

        private bool IsPreviousTR3Level(byte[] fileData, int levelIndex, int currentLevel)
        {
            // Lost Artifact is linear
            if (currentLevel >= 21)
            {
                return levelIndex >= 21 && levelIndex < currentLevel;
            }

            // All Hallows is standalone
            if (currentLevel == 20)
            {
                return false;
            }

            // Exclude All Hallows and Lost Artifact from the main campaign
            if (levelIndex >= 20)
            {
                return false;
            }

            // Antarctica is linear and occurs after all four selectable regions
            if (currentLevel >= 16)
            {
                return levelIndex < currentLevel;
            }

            int candidateWorld = GetTR3World(levelIndex);
            int currentWorld = GetTR3World(currentLevel);

            // Earlier level within the region currently being played
            if (candidateWorld == currentWorld)
            {
                return levelIndex < currentLevel;
            }

            // Otherwise it must belong to an already completed region
            return IsTR3WorldComplete(fileData, candidateWorld);
        }

        private bool IsTR3WorldComplete(byte[] fileData, int world)
        {
            UInt32 worldState = BitConverter.ToUInt32(fileData, savegameOffset + WORLD_STATE_OFFSET_TR3);

            switch (world)
            {
                case TR3_WORLD_INDIA:
                    return (worldState & TR3_WORLD_INDIA_COMPLETE_MASK) != 0;

                case TR3_WORLD_SOUTH_PACIFIC:
                    return (worldState & TR3_WORLD_SOUTH_PACIFIC_COMPLETE_MASK) != 0;

                case TR3_WORLD_LONDON:
                    return (worldState & TR3_WORLD_LONDON_COMPLETE_MASK) != 0;

                case TR3_WORLD_NEVADA:
                    return (worldState & TR3_WORLD_NEVADA_COMPLETE_MASK) != 0;

                default:
                    return false;
            }
        }

        private int GetTR3World(int levelIndex)
        {
            if (levelIndex <= 4)
            {
                return TR3_WORLD_INDIA;
            }

            if (levelIndex <= 8)
            {
                return TR3_WORLD_SOUTH_PACIFIC;
            }

            if (levelIndex <= 12)
            {
                return TR3_WORLD_LONDON;
            }

            if (levelIndex <= 15)
            {
                return TR3_WORLD_NEVADA;
            }

            return TR3_WORLD_NONE;
        }

        private int GetTR3WorldRequired(byte[] fileData)
        {
            UInt32 worldState = BitConverter.ToUInt32(fileData, savegameOffset + WORLD_STATE_OFFSET_TR3);
            return (int)((worldState >> WORLD_REQUIRED_SHIFT_TR3) & WORLD_REQUIRED_MASK_TR3);
        }

        public void SetSavegame(Savegame savegame)
        {
            selectedSavegame = savegame;
            savegameOffset = savegame.Offset;
            grpSavegameStatistics.Text = $"{selectedSavegame}";
        }

        private void DetermineOffsets()
        {
            SLOT_STATUS_OFFSET = SLOT_STATUS_OFFSET_DEFAULT;

            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                if (isPrepatch)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR1_PREPATCH;
                    CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR1_PREPATCH;
                    AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR1_PREPATCH;
                    HITS_OFFSET = HITS_OFFSET_TR1_PREPATCH;
                    KILLS_OFFSET = KILLS_OFFSET_TR1_PREPATCH;
                    SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR1_PREPATCH;
                    PICKUPS_OFFSET = PICKUPS_OFFSET_TR1_PREPATCH;
                    MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR1_PREPATCH;
                    DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR1_PREPATCH;
                    TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR1_PREPATCH;
                    STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR1_PREPATCH;
                }
                else
                {
                    if (platform == Platform.PC)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR1_PC;
                        CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR1_PC;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR1_PC;
                        HITS_OFFSET = HITS_OFFSET_TR1_PC;
                        KILLS_OFFSET = KILLS_OFFSET_TR1_PC;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR1_PC;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR1_PC;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR1_PC;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR1_PC;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR1_PC;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR1_PC;
                    }
                    else if (platform == Platform.Android || platform == Platform.iOS)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR1_MOBILE;
                        CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR1_MOBILE;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR1_MOBILE;
                        HITS_OFFSET = HITS_OFFSET_TR1_MOBILE;
                        KILLS_OFFSET = KILLS_OFFSET_TR1_MOBILE;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR1_MOBILE;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR1_MOBILE;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR1_MOBILE;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR1_MOBILE;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR1_MOBILE;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR1_MOBILE;
                    }
                    else if (platform == Platform.PlayStation4)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR1_PS4;
                        CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR1_PS4;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR1_PS4;
                        HITS_OFFSET = HITS_OFFSET_TR1_PS4;
                        KILLS_OFFSET = KILLS_OFFSET_TR1_PS4;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR1_PS4;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR1_PS4;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR1_PS4;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR1_PS4;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR1_PS4;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR1_PS4;
                    }
                }

                STATISTICS_ARRAY_STRIDE = STATISTICS_ARRAY_STRIDE_TR1;
                CRYSTALS_USED_ARRAY_OFFSET = CRYSTALS_USED_ARRAY_OFFSET_TR1;
                TIME_TAKEN_ARRAY_OFFSET = TIME_TAKEN_ARRAY_OFFSET_TR1;
                AMMO_USED_ARRAY_OFFSET = AMMO_USED_ARRAY_OFFSET_TR1;
                HITS_ARRAY_OFFSET = HITS_ARRAY_OFFSET_TR1;
                KILLS_ARRAY_OFFSET = KILLS_ARRAY_OFFSET_TR1;
                DISTANCE_TRAVELLED_ARRAY_OFFSET = DISTANCE_TRAVELLED_ARRAY_OFFSET_TR1;
                SECRETS_FOUND_ARRAY_OFFSET = SECRETS_FOUND_ARRAY_OFFSET_TR1;
                PICKUPS_ARRAY_OFFSET = PICKUPS_ARRAY_OFFSET_TR1;
                MEDIPACKS_USED_ARRAY_OFFSET = MEDIPACKS_USED_ARRAY_OFFSET_TR1;
            }
            else if (SELECTED_TAB == Globals.TAB_TR2)
            {
                if (isPrepatch)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR2_PREPATCH;
                    AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR2_PREPATCH;
                    HITS_OFFSET = HITS_OFFSET_TR2_PREPATCH;
                    KILLS_OFFSET = KILLS_OFFSET_TR2_PREPATCH;
                    SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR2_PREPATCH;
                    PICKUPS_OFFSET = PICKUPS_OFFSET_TR2_PREPATCH;
                    MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR2_PREPATCH;
                    DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR2_PREPATCH;
                    TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR2_PREPATCH;
                    STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR2_PREPATCH;
                }
                else
                {
                    if (platform == Platform.PC)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR2_PC;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR2_PC;
                        HITS_OFFSET = HITS_OFFSET_TR2_PC;
                        KILLS_OFFSET = KILLS_OFFSET_TR2_PC;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR2_PC;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR2_PC;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR2_PC;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR2_PC;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR2_PC;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR2_PC;
                    }
                    else if (platform == Platform.Android || platform == Platform.iOS)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR2_MOBILE;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR2_MOBILE;
                        HITS_OFFSET = HITS_OFFSET_TR2_MOBILE;
                        KILLS_OFFSET = KILLS_OFFSET_TR2_MOBILE;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR2_MOBILE;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR2_MOBILE;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR2_MOBILE;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR2_MOBILE;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR2_MOBILE;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR2_MOBILE;
                    }
                    else if (platform == Platform.PlayStation4)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR2_PS4;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR2_PS4;
                        HITS_OFFSET = HITS_OFFSET_TR2_PS4;
                        KILLS_OFFSET = KILLS_OFFSET_TR2_PS4;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR2_PS4;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR2_PS4;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR2_PS4;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR2_PS4;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR2_PS4;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR2_PS4;
                    }
                }

                STATISTICS_ARRAY_STRIDE = STATISTICS_ARRAY_STRIDE_TR2;
                TIME_TAKEN_ARRAY_OFFSET = TIME_TAKEN_ARRAY_OFFSET_TR2;
                AMMO_USED_ARRAY_OFFSET = AMMO_USED_ARRAY_OFFSET_TR2;
                HITS_ARRAY_OFFSET = HITS_ARRAY_OFFSET_TR2;
                KILLS_ARRAY_OFFSET = KILLS_ARRAY_OFFSET_TR2;
                DISTANCE_TRAVELLED_ARRAY_OFFSET = DISTANCE_TRAVELLED_ARRAY_OFFSET_TR2;
                SECRETS_FOUND_ARRAY_OFFSET = SECRETS_FOUND_ARRAY_OFFSET_TR2;
                PICKUPS_ARRAY_OFFSET = PICKUPS_ARRAY_OFFSET_TR2;
                MEDIPACKS_USED_ARRAY_OFFSET = MEDIPACKS_USED_ARRAY_OFFSET_TR2;
            }
            else if (SELECTED_TAB == Globals.TAB_TR3)
            {
                if (isPrepatch)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR3_PREPATCH;
                    CRYSTALS_FOUND_OFFSET = CRYSTALS_FOUND_OFFSET_TR3_PREPATCH;
                    CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR3_PREPATCH;
                    AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR3_PREPATCH;
                    HITS_OFFSET = HITS_OFFSET_TR3_PREPATCH;
                    KILLS_OFFSET = KILLS_OFFSET_TR3_PREPATCH;
                    SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR3_PREPATCH;
                    PICKUPS_OFFSET = PICKUPS_OFFSET_TR3_PREPATCH;
                    MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR3_PREPATCH;
                    DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR3_PREPATCH;
                    TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR3_PREPATCH;
                    WORLD_STATE_OFFSET_TR3 = WORLD_STATE_OFFSET_TR3_PREPATCH;
                    STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR3_PREPATCH;
                }
                else
                {
                    if (platform == Platform.PC)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR3_PC;
                        CRYSTALS_FOUND_OFFSET = CRYSTALS_FOUND_OFFSET_TR3_PC;
                        CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR3_PC;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR3_PC;
                        HITS_OFFSET = HITS_OFFSET_TR3_PC;
                        KILLS_OFFSET = KILLS_OFFSET_TR3_PC;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR3_PC;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR3_PC;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR3_PC;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR3_PC;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR3_PC;
                        WORLD_STATE_OFFSET_TR3 = WORLD_STATE_OFFSET_TR3_PC;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR3_PC;
                    }
                    else if (platform == Platform.Android || platform == Platform.iOS)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR3_MOBILE;
                        CRYSTALS_FOUND_OFFSET = CRYSTALS_FOUND_OFFSET_TR3_MOBILE;
                        CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR3_MOBILE;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR3_MOBILE;
                        HITS_OFFSET = HITS_OFFSET_TR3_MOBILE;
                        KILLS_OFFSET = KILLS_OFFSET_TR3_MOBILE;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR3_MOBILE;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR3_MOBILE;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR3_MOBILE;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR3_MOBILE;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR3_MOBILE;
                        WORLD_STATE_OFFSET_TR3 = WORLD_STATE_OFFSET_TR3_MOBILE;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR3_MOBILE;
                    }
                    else if (platform == Platform.PlayStation4)
                    {
                        LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR3_PS4;
                        CRYSTALS_FOUND_OFFSET = CRYSTALS_FOUND_OFFSET_TR3_PS4;
                        CRYSTALS_USED_OFFSET = CRYSTALS_USED_OFFSET_TR3_PS4;
                        AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR3_PS4;
                        HITS_OFFSET = HITS_OFFSET_TR3_PS4;
                        KILLS_OFFSET = KILLS_OFFSET_TR3_PS4;
                        SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR3_PS4;
                        PICKUPS_OFFSET = PICKUPS_OFFSET_TR3_PS4;
                        MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR3_PS4;
                        DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR3_PS4;
                        TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR3_PS4;
                        WORLD_STATE_OFFSET_TR3 = WORLD_STATE_OFFSET_TR3_PS4;
                        STATISTICS_ARRAY_BASE_OFFSET = STATISTICS_ARRAY_BASE_OFFSET_TR3_PS4;
                    }
                }

                STATISTICS_ARRAY_STRIDE = STATISTICS_ARRAY_STRIDE_TR3;
                CRYSTALS_FOUND_ARRAY_OFFSET = CRYSTALS_FOUND_ARRAY_OFFSET_TR3;
                CRYSTALS_USED_ARRAY_OFFSET = CRYSTALS_USED_ARRAY_OFFSET_TR3;
                TIME_TAKEN_ARRAY_OFFSET = TIME_TAKEN_ARRAY_OFFSET_TR3;
                AMMO_USED_ARRAY_OFFSET = AMMO_USED_ARRAY_OFFSET_TR3;
                HITS_ARRAY_OFFSET = HITS_ARRAY_OFFSET_TR3;
                KILLS_ARRAY_OFFSET = KILLS_ARRAY_OFFSET_TR3;
                DISTANCE_TRAVELLED_ARRAY_OFFSET = DISTANCE_TRAVELLED_ARRAY_OFFSET_TR3;
                SECRETS_FOUND_ARRAY_OFFSET = SECRETS_FOUND_ARRAY_OFFSET_TR3;
                PICKUPS_ARRAY_OFFSET = PICKUPS_ARRAY_OFFSET_TR3;
                MEDIPACKS_USED_ARRAY_OFFSET = MEDIPACKS_USED_ARRAY_OFFSET_TR3;
            }
            else if (SELECTED_TAB == Globals.TAB_TR4)
            {
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR4;
                TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR4;
                DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR4;
                AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR4;
                PICKUPS_OFFSET = PICKUPS_OFFSET_TR4;
                KILLS_OFFSET = KILLS_OFFSET_TR4;
                SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR4;
                MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR4;
                VESSELS_BROKEN_OFFSET = VESSELS_BROKEN_OFFSET_TR4;
                TIMESTAMP_DAYS_OFFSET = TIMESTAMP_DAYS_OFFSET_TR4;
                TIMESTAMP_HOURS_OFFSET = TIMESTAMP_HOURS_OFFSET_TR4;
                TIMESTAMP_MINUTES_OFFSET = TIMESTAMP_MINUTES_OFFSET_TR4;
                TIMESTAMP_SECONDS_OFFSET = TIMESTAMP_SECONDS_OFFSET_TR4;
            }
            else if (SELECTED_TAB == Globals.TAB_TR5)
            {
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR5;
                TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR5;
                DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR5;
                AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR5;
                PICKUPS_OFFSET = PICKUPS_OFFSET_TR5;
                KILLS_OFFSET = KILLS_OFFSET_TR5;
                SECRETS_FOUND_OFFSET = SECRETS_FOUND_OFFSET_TR5;
                MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR5;
                TIMESTAMP_DAYS_OFFSET = TIMESTAMP_DAYS_OFFSET_TR5;
                TIMESTAMP_HOURS_OFFSET = TIMESTAMP_HOURS_OFFSET_TR5;
                TIMESTAMP_MINUTES_OFFSET = TIMESTAMP_MINUTES_OFFSET_TR5;
                TIMESTAMP_SECONDS_OFFSET = TIMESTAMP_SECONDS_OFFSET_TR5;
            }
            else if (SELECTED_TAB == Globals.TAB_TR6)
            {
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_TR6;
                SLOT_STATUS_OFFSET = SLOT_STATUS_OFFSET_TR6;
                DISTANCE_TRAVELLED_OFFSET = DISTANCE_TRAVELLED_OFFSET_TR6;
                TIME_TAKEN_OFFSET = TIME_TAKEN_OFFSET_TR6;
                AMMO_USED_OFFSET = AMMO_USED_OFFSET_TR6;
                HITS_OFFSET = HITS_OFFSET_TR6;
                PICKUPS_OFFSET = PICKUPS_OFFSET_TR6;
                HEALTH_ITEMS_FOUND_OFFSET = HEALTH_ITEMS_FOUND_OFFSET_TR6;
                CHOCOBARS_FOUND_OFFSET = CHOCOBARS_FOUND_OFFSET_TR6;
                KILLS_OFFSET = KILLS_OFFSET_TR6;
                MEDIPACKS_USED_OFFSET = MEDIPACKS_USED_OFFSET_TR6;
            }
        }

        private void SetParams(byte[] fileData)
        {
            int levelIndex = GetLevelIndex(fileData);

            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR1.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR1.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;

                lblCrystalsFound.Enabled = false;
                lblCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;
                lblVesselsBroken.Enabled = false;
                lblChocobarsFound.Enabled = false;
                lblHealthItemsFound.Enabled = false;
            }
            else if (SELECTED_TAB == Globals.TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR2.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                lblCrystalsFound.Enabled = false;
                lblCrystalsUsed.Enabled = false;
                lblVesselsBroken.Enabled = false;
                lblChocobarsFound.Enabled = false;
                lblHealthItemsFound.Enabled = false;
            }
            else if (SELECTED_TAB == Globals.TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR3.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = levelIndex == 5 ? MAX_PICKUPS_COASTAL_VILLAGE_TR3 : nudPickupsMax.Value;

                nudCrystalsFound.Enabled = true;
                nudCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;

                lblCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;
                lblVesselsBroken.Enabled = false;
                lblChocobarsFound.Enabled = false;
                lblHealthItemsFound.Enabled = false;
            }
            else if (SELECTED_TAB == Globals.TAB_TR4)
            {
                bool useAlternateStatsMax = ShouldUseAlternateStatsMaxTR4(fileData);

                nudAmmoUsed.Maximum = Int16.MaxValue;
                nudAmmoUsed.Minimum = Int16.MinValue;

                nudPickups.Maximum = useAlternateStatsMax ? MAX_PICKUPS_ALT_TR4 : MAX_PICKUPS_TR4;
                nudPickups.Minimum = 0;

                nudKills.Maximum = UInt16.MaxValue;
                nudKills.Minimum = UInt16.MinValue;

                nudMedipacksUsed.Maximum = Byte.MaxValue;
                nudMedipacksUsed.Minimum = Byte.MinValue;

                nudSecretsFound.Maximum = MAX_SECRETS_FOUND_TR4;
                nudSecretsFound.Minimum = Byte.MinValue;

                nudVesselsBroken.Enabled = true;
                nudVesselsBroken.Maximum = useAlternateStatsMax ? MAX_VESSELS_BROKEN_ALT_TR4 : MAX_VESSELS_BROKEN_TR4;

                nudPickupsMax.Maximum = useAlternateStatsMax ? MAX_PICKUPS_ALT_TR4 : MAX_PICKUPS_TR4;
                nudSecretsFoundMax.Value = MAX_SECRETS_FOUND_TR4;
                nudVesselsBrokenMax.Value = useAlternateStatsMax ? MAX_VESSELS_BROKEN_ALT_TR4 : MAX_VESSELS_BROKEN_TR4;
                nudPickupsMax.Value = useAlternateStatsMax ? MAX_PICKUPS_ALT_TR4 : MAX_PICKUPS_TR4;

                nudCrystalsFound.Enabled = false;
                nudCrystalsUsed.Enabled = false;

                nudHits.Visible = false;
                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                lblAmmoUsedHits.Text = Globals.LABEL_TEXT_AMMO_USED;
                lblMedipacksUsed.Text = Globals.LABEL_TEXT_HEALTH_PACKS_USED;
                lblOf.Text = Globals.LABEL_TEXT_FORWARD_SLASH;
                lblOf2.Text = Globals.LABEL_TEXT_FORWARD_SLASH;

                lblSlash.Visible = false;

                lblCrystalsFound.Enabled = false;
                lblCrystalsUsed.Enabled = false;
                lblChocobarsFound.Enabled = false;
                lblHealthItemsFound.Enabled = false;
            }
            else if (SELECTED_TAB == Globals.TAB_TR5)
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

                lblAmmoUsedHits.Text = Globals.LABEL_TEXT_AMMO_USED;
                lblMedipacksUsed.Text = Globals.LABEL_TEXT_HEALTH_PACKS_USED;
                lblOf.Text = Globals.LABEL_TEXT_FORWARD_SLASH;
                lblOf2.Text = Globals.LABEL_TEXT_FORWARD_SLASH;

                lblSlash.Visible = false;

                lblCrystalsFound.Enabled = false;
                lblCrystalsUsed.Enabled = false;
                lblVesselsBroken.Enabled = false;
                lblChocobarsFound.Enabled = false;
                lblHealthItemsFound.Enabled = false;
            }
            else if (SELECTED_TAB == Globals.TAB_TR6)
            {
                bool usePatchedStatsMax = ShouldUsePatchedStatsMaxTR6(fileData);

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

                lblMedipacksUsed.Text = Globals.LABEL_TEXT_HEALTH_RESTORED;
                nudMedipacksUsed.Increment = 1;
                nudMedipacksUsed.DecimalPlaces = 0;

                nudChocobarsFound.Enabled = true;
                nudHealthItemsFound.Enabled = true;

                nudVesselsBroken.Enabled = false;

                nudPickupsMax.Value = pickupsFoundMaxTR6.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudHealthItemsFoundMax.Value = healthItemsFoundMaxTR6.TryGetValue(levelIndex, out var healthItemsMax) ? healthItemsMax : 0;
                nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                nudChocobarsFoundMax.Value = chocobarsFoundMaxTR6.TryGetValue(levelIndex, out var chocobarsMax) ? chocobarsMax : 0;
                nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;

                if (!usePatchedStatsMax)
                {
                    if (levelIndex == 7)            // The Serpent Rouge
                    {
                        nudPickupsMax.Value += 1;
                        nudPickups.Maximum = nudPickupsMax.Value;

                        nudHealthItemsFoundMax.Value += 1;
                        nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                        nudChocobarsFoundMax.Value -= 1;
                        nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;
                    }
                    else if (levelIndex == 0x0C)    // St. Aicard's Graveyard
                    {
                        nudPickupsMax.Value -= selectedSavegame.IsNewGamePlus ? 1 : 2;
                        nudPickups.Maximum = nudPickupsMax.Value;

                        if (!selectedSavegame.IsNewGamePlus)
                        {
                            nudHealthItemsFoundMax.Value -= 1;
                            nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;
                        }
                    }
                }

                lblOf2.Text = Globals.LABEL_TEXT_FORWARD_SLASH;

                lblCrystalsFound.Enabled = false;
                lblCrystalsUsed.Enabled = false;
                lblSecretsFound.Enabled = false;
                lblVesselsBroken.Enabled = false;
            }
        }

        private void UpdateDynamicParams(byte[] fileData)
        {
            int levelIndex = GetLevelIndex(fileData);

            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR1.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR1.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;
                lblCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;
            }
            else if (SELECTED_TAB == Globals.TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR2.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;
            }
            else if (SELECTED_TAB == Globals.TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR3.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = levelIndex == 5 ? MAX_PICKUPS_COASTAL_VILLAGE_TR3 : nudPickupsMax.Value;

                nudCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;
                lblCrystalsUsed.Enabled = selectedSavegame.IsNewGamePlus;
            }
            else if (SELECTED_TAB == Globals.TAB_TR4)
            {
                bool useAlternateStatsMax = ShouldUseAlternateStatsMaxTR4(fileData);

                nudPickupsMax.Value = useAlternateStatsMax ? MAX_PICKUPS_ALT_TR4 : MAX_PICKUPS_TR4;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudVesselsBrokenMax.Value = useAlternateStatsMax ? MAX_VESSELS_BROKEN_ALT_TR4 : MAX_VESSELS_BROKEN_TR4;
                nudVesselsBroken.Maximum = nudVesselsBrokenMax.Value;
            }
            else if (SELECTED_TAB == Globals.TAB_TR6)
            {
                bool usePatchedStatsMax = ShouldUsePatchedStatsMaxTR6(fileData);

                nudPickupsMax.Value = pickupsFoundMaxTR6.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;
                nudPickups.Maximum = nudPickupsMax.Value;

                nudHealthItemsFoundMax.Value = healthItemsFoundMaxTR6.TryGetValue(levelIndex, out var healthItemsMax) ? healthItemsMax : 0;
                nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                nudChocobarsFoundMax.Value = chocobarsFoundMaxTR6.TryGetValue(levelIndex, out var chocobarsMax) ? chocobarsMax : 0;
                nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;

                if (!usePatchedStatsMax)
                {
                    if (levelIndex == 7)            // The Serpent Rouge
                    {
                        nudPickupsMax.Value += 1;
                        nudPickups.Maximum = nudPickupsMax.Value;

                        nudHealthItemsFoundMax.Value += 1;
                        nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                        nudChocobarsFoundMax.Value -= 1;
                        nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;
                    }
                    else if (levelIndex == 0x0C)    // St. Aicard's Graveyard
                    {
                        nudPickupsMax.Value -= selectedSavegame.IsNewGamePlus ? 1 : 2;
                        nudPickups.Maximum = nudPickupsMax.Value;

                        if (!selectedSavegame.IsNewGamePlus)
                        {
                            nudHealthItemsFoundMax.Value -= 1;
                            nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;
                        }
                    }
                }
            }
        }

        private void UpdateDynamicParamsForLevel(byte[] fileData, int levelIndex)
        {
            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR1.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR1.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;
            }
            else if (SELECTED_TAB == Globals.TAB_TR2)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR2.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR2.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = nudPickupsMax.Value;
            }
            else if (SELECTED_TAB == Globals.TAB_TR3)
            {
                nudSecretsFoundMax.Value = secretsFoundMaxTR3.TryGetValue(levelIndex, out var secretsMax) ? secretsMax : 0;
                nudPickupsMax.Value = pickupsFoundMaxTR3.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;

                nudSecretsFound.Maximum = nudSecretsFoundMax.Value;
                nudPickups.Maximum = levelIndex == 5 ? MAX_PICKUPS_COASTAL_VILLAGE_TR3 : nudPickupsMax.Value;
            }
            else if (SELECTED_TAB == Globals.TAB_TR6)
            {
                StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;
                bool finalStatistics = target.LevelIndex == FINAL_STATISTICS;
                bool usePatchedStatsMax = ShouldUsePatchedStatsMaxTR6(fileData);

                if (finalStatistics)
                {
                    nudPickupsMax.Maximum = usePatchedStatsMax ? PICKUPS_MAX_FINAL_TR6 : PICKUPS_MAX_FINAL_PREPATCH_TR6;
                    nudPickupsMax.Value = usePatchedStatsMax ? PICKUPS_MAX_FINAL_TR6 : PICKUPS_MAX_FINAL_PREPATCH_TR6;
                    nudPickups.Maximum = PICKUPS_ALLOWED_MAX_FINAL_TR6;

                    nudHealthItemsFoundMax.Maximum = HEALTH_ITEMS_FOUND_MAX_FINAL_TR6;
                    nudHealthItemsFoundMax.Value = HEALTH_ITEMS_FOUND_MAX_FINAL_TR6;
                    nudHealthItemsFound.Maximum = HEALTH_ITEMS_FOUND_MAX_FINAL_TR6;

                    nudChocobarsFoundMax.Maximum = usePatchedStatsMax ? CHOCOBARS_FOUND_MAX_FINAL_TR6 : CHOCOBARS_FOUND_MAX_FINAL_PREPATCH_TR6;
                    nudChocobarsFoundMax.Value = usePatchedStatsMax ? CHOCOBARS_FOUND_MAX_FINAL_TR6 : CHOCOBARS_FOUND_MAX_FINAL_PREPATCH_TR6;
                    nudChocobarsFound.Maximum = usePatchedStatsMax ? CHOCOBARS_FOUND_MAX_FINAL_TR6 : CHOCOBARS_FOUND_MAX_FINAL_PREPATCH_TR6;
                }
                else
                {
                    nudPickupsMax.Value = pickupsFoundMaxTR6.TryGetValue(levelIndex, out var pickupsMax) ? pickupsMax : 0;
                    nudPickups.Maximum = nudPickupsMax.Value;

                    nudHealthItemsFoundMax.Value = healthItemsFoundMaxTR6.TryGetValue(levelIndex, out var healthItemsMax) ? healthItemsMax : 0;
                    nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                    nudChocobarsFoundMax.Value = chocobarsFoundMaxTR6.TryGetValue(levelIndex, out var chocobarsMax) ? chocobarsMax : 0;
                    nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;

                    if (!usePatchedStatsMax)
                    {
                        if (levelIndex == 7)            // The Serpent Rouge
                        {
                            nudPickupsMax.Value += 1;
                            nudPickups.Maximum = nudPickupsMax.Value;

                            nudHealthItemsFoundMax.Value += 1;
                            nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;

                            nudChocobarsFoundMax.Value -= 1;
                            nudChocobarsFound.Maximum = nudChocobarsFoundMax.Value;
                        }
                        else if (levelIndex == 0x0C)    // St. Aicard's Graveyard
                        {
                            nudPickupsMax.Value -= selectedSavegame.IsNewGamePlus ? 1 : 2;
                            nudPickups.Maximum = nudPickupsMax.Value;

                            if (!selectedSavegame.IsNewGamePlus)
                            {
                                nudHealthItemsFoundMax.Value -= 1;
                                nudHealthItemsFound.Maximum = nudHealthItemsFoundMax.Value;
                            }
                        }
                    }
                }
            }
        }

        private void HideLevelSelectUI()
        {
            // Hide level select controls
            cmbStatistics.Visible = false;
            lblEdit.Visible = false;
            lblSeparator.Visible = false;
            picInfoStatisticsDropdown.Visible = false;

            // Restore original group box size
            grpSavegameStatistics.Size = new Size(365, 346);

            // Restore control locations
            lblTimeTaken.Location = new Point(11, 23);
            nudHours.Location = new Point(149, 23);
            nudMinutes.Location = new Point(224, 23);
            nudSeconds.Location = new Point(299, 23);
            lblColon.Location = new Point(205, 27);
            lblColon2.Location = new Point(280, 27);
            lblSecretsFound.Location = new Point(11, 49);
            nudSecretsFound.Location = new Point(149, 49);
            lblOf.Location = new Point(204, 53);
            nudSecretsFoundMax.Location = new Point(224, 49);
            lblCrystalsFound.Location = new Point(11, 75);
            nudCrystalsFound.Location = new Point(149, 75);
            lblCrystalsUsed.Location = new Point(11, 101);
            nudCrystalsUsed.Location = new Point(149, 101);
            lblPickups.Location = new Point(11, 127);
            nudPickups.Location = new Point(149, 127);
            lblOf2.Location = new Point(204, 131);
            nudPickupsMax.Location = new Point(224, 127);
            lblKills.Location = new Point(11, 153);
            nudKills.Location = new Point(149, 153);
            lblAmmoUsedHits.Location = new Point(11, 179);
            nudAmmoUsed.Location = new Point(149, 179);
            lblSlash.Location = new Point(206, 183);
            nudHits.Location = new Point(224, 179);
            lblMedipacksUsed.Location = new Point(11, 205);
            nudMedipacksUsed.Location = new Point(149, 205);
            lblHealthItemsFound.Location = new Point(11, 231);
            nudHealthItemsFound.Location = new Point(149, 231);
            lblSlash2.Location = new Point(206, 235);
            nudHealthItemsFoundMax.Location = new Point(224, 231);
            lblChocobarsFound.Location = new Point(11, 257);
            nudChocobarsFound.Location = new Point(149, 257);
            lblSlash3.Location = new Point(206, 261);
            nudChocobarsFoundMax.Location = new Point(224, 257);
            lblDistanceTravelled.Location = new Point(11, 283);
            nudDistanceTravelled.Location = new Point(149, 283);
            lblDistanceTravelledUnit.Location = new Point(206, 287);
            lblVesselsBroken.Location = new Point(11, 309);
            nudVesselsBroken.Location = new Point(149, 309);
            lblSlash4.Location = new Point(206, 313);
            nudVesselsBrokenMax.Location = new Point(224, 309);

            // Restore button locations
            btnClose.Location = new Point(140, 357);
            btnCancel.Location = new Point(221, 357);
            btnSave.Location = new Point(302, 357);

            // Restore form size
            ClientSize = new Size(389, 387);
        }

        private void SetTooltipText()
        {
            if (SELECTED_TAB == Globals.TAB_TR6)
            {
                tipStatisticsDropdown.SetToolTip(picInfoStatisticsDropdown, Globals.TOOLTIP_TEXT_STATISTICS_DROPDOWN_TR6);
            }
            else
            {
                tipStatisticsDropdown.SetToolTip(picInfoStatisticsDropdown, Globals.TOOLTIP_TEXT_STATISTICS_DROPDOWN_TRX);
            }
        }

        private void UpdateSavegameDisplayName(byte[] fileData)
        {
            if (SELECTED_TAB == Globals.TAB_TR1)
            {
                tr1Utilities.SetPlatform(platform);
                tr1Utilities.DetermineOffsets(fileData);
                tr1Utilities.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR2)
            {
                tr2Utilities.SetPlatform(platform);
                tr2Utilities.DetermineOffsets(fileData);
                tr2Utilities.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR3)
            {
                tr3Utilities.SetPlatform(platform);
                tr3Utilities.DetermineOffsets(fileData);
                tr3Utilities.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR4)
            {
                tr4Utilities.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR5)
            {
                tr5Utilities.UpdateDisplayName(selectedSavegame, fileData);
            }
            else if (SELECTED_TAB == Globals.TAB_TR6)
            {
                tr6Utilities.UpdateDisplayName(selectedSavegame, fileData);
            }

            grpSavegameStatistics.Text = $"{selectedSavegame}";
        }

        private bool IsTRXSavegame()
        {
            return SELECTED_TAB == Globals.TAB_TR1 || SELECTED_TAB == Globals.TAB_TR2 || SELECTED_TAB == Globals.TAB_TR3;
        }

        private bool IsTR6Savegame()
        {
            return SELECTED_TAB == Globals.TAB_TR6;
        }

        private bool ShouldShowLevelSelect(byte[] fileData)
        {
            if ((SELECTED_TAB == Globals.TAB_TR1 || SELECTED_TAB == Globals.TAB_TR2 || SELECTED_TAB == Globals.TAB_TR3) && !selectedSavegame.IsChallengeMode)
            {
                int levelIndex = GetLevelIndex(fileData);

                if (SELECTED_TAB == Globals.TAB_TR2)
                {
                    // Nightmare in Vegas is standalone
                    if (levelIndex == 23)
                    {
                        return false;
                    }
                }

                if (SELECTED_TAB == Globals.TAB_TR3)
                {
                    // All Hallows is standalone
                    if (levelIndex == 20)
                    {
                        return false;
                    }
                }

                return true;
            }

            if (SELECTED_TAB == Globals.TAB_TR6)
            {
                return true;
            }

            return false;
        }

        private bool HasDynamicParams()
        {
            return SELECTED_TAB == Globals.TAB_TR1 || SELECTED_TAB == Globals.TAB_TR2 || SELECTED_TAB == Globals.TAB_TR3 || SELECTED_TAB == Globals.TAB_TR4 || SELECTED_TAB == Globals.TAB_TR6;
        }

        private bool ShouldUseAlternateStatsMaxTR4(byte[] fileData)
        {
            UInt32 gameFlags = BitConverter.ToUInt32(fileData, savegameOffset + GAME_FLAGS_OFFSET_TR4);
            return (gameFlags & STATS_MAX_FLAG_TR4) != 0;
        }

        private bool ShouldUsePatchedStatsMaxTR6(byte[] fileData)
        {
            UInt32 gameFlags = BitConverter.ToUInt32(fileData, savegameOffset + GAME_FLAGS_OFFSET_TR6);
            return (gameFlags & STATS_PATCH_FLAG_TR6) != 0;
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

            if (IsTR6Savegame())
            {
                return BitConverter.ToUInt32(fileData, savegameOffset + SLOT_STATUS_OFFSET) != 0;
            }
            
            return BitConverter.ToInt32(fileData, savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        private int GetLevelIndex(byte[] fileData = null)
        {
            if (fileData == null)
            {
                fileData = File.ReadAllBytes(savegamePath);
            }

            if (IsTRXSavegame())
            {
                return BitConverter.ToInt16(fileData, savegameOffset + LEVEL_INDEX_OFFSET);
            }

            return fileData[savegameOffset + LEVEL_INDEX_OFFSET];
        }

        private void DisplayTRXStatistics(byte[] fileData)
        {
            StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;

            if (target == null || target.LevelIndex == null)
            {
                DisplayCurrentLevelStatistics(fileData);
            }
            else
            {
                DisplayStatisticsRecord(fileData, target.LevelIndex.Value);
            }
        }

        private void DisplayCurrentLevelStatistics(byte[] fileData)
        {
            nudSecretsFound.Value = GetNumSecretsFoundTRX(fileData);
            nudPickups.Value = GetNumPickupsTRX(fileData);
            nudKills.Value = GetNumKillsTRX(fileData);
            nudAmmoUsed.Value = GetAmmoUsedTRX(fileData);
            nudHits.Value = GetNumHitsTRX(fileData);
            nudMedipacksUsed.Value = (decimal)GetNumMedipacksUsedTRX(fileData) / 2;

            if (nudCrystalsFound.Enabled)
            {
                nudCrystalsFound.Value = GetNumCrystalsFoundTRX(fileData);
            }

            if (nudCrystalsUsed.Enabled)
            {
                nudCrystalsUsed.Value = GetNumCrystalsUsedTRX(fileData);
            }

            DisplayDistanceTravelledTRX(fileData);
            DisplayTimeTakenTRX(fileData);
        }

        private void DisplayStatisticsRecord(byte[] fileData, int levelIndex)
        {
            nudSecretsFound.Value = GetNumSecretsFoundTRX(fileData, levelIndex);
            nudPickups.Value = GetNumPickupsTRX(fileData, levelIndex);
            nudKills.Value = GetNumKillsTRX(fileData, levelIndex);
            nudAmmoUsed.Value = GetAmmoUsedTRX(fileData, levelIndex);
            nudHits.Value = GetNumHitsTRX(fileData, levelIndex);
            nudMedipacksUsed.Value = (decimal)GetNumMedipacksUsedTRX(fileData, levelIndex) / 2;

            if (nudCrystalsFound.Enabled)
            {
                nudCrystalsFound.Value = GetNumCrystalsFoundTRX(fileData, levelIndex);
            }

            if (nudCrystalsUsed.Enabled)
            {
                nudCrystalsUsed.Value = GetNumCrystalsUsedTRX(fileData, levelIndex);
            }

            DisplayDistanceTravelledTRX(fileData, levelIndex);
            DisplayTimeTakenTRX(fileData, levelIndex);
        }

        private void DisplayTR6Statistics(byte[] fileData)
        {
            StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;

            if (target.LevelIndex == null)
            {
                DisplayTR6CurrentLevelStatistics(fileData);
            }
            else
            {
                DisplayTR6FinalStatistics(fileData);
            }
        }

        private void DisplayTR6CurrentLevelStatistics(byte[] fileData)
        {
            nudAmmoUsed.Value = GetAmmoUsedTR6(fileData);
            nudMedipacksUsed.Value = GetHealthRestoredTR6(fileData);
            nudHits.Value = GetNumHitsTR6(fileData);
            nudKills.Value = GetNumKillsTR6(fileData);
            nudPickups.Value = GetNumPickupsTR6(fileData);
            nudHealthItemsFound.Value = GetNumHealthItemsFoundTR6(fileData);
            nudChocobarsFound.Value = GetNumChocobarsFoundTR6(fileData);

            DisplayDistanceTravelledTR6(fileData);
            DisplayTimeTakenTR6(fileData);
        }

        private void DisplayTR6FinalStatistics(byte[] fileData)
        {
            nudAmmoUsed.Value = GetAmmoUsedTR6(fileData, true);
            nudMedipacksUsed.Value = GetHealthRestoredTR6(fileData, true);
            nudHits.Value = GetNumHitsTR6(fileData, true);
            nudKills.Value = GetNumKillsTR6(fileData, true);
            nudPickups.Value = GetNumPickupsTR6(fileData, true);
            nudHealthItemsFound.Value = GetNumHealthItemsFoundTR6(fileData, true);
            nudChocobarsFound.Value = GetNumChocobarsFoundTR6(fileData, true);

            DisplayDistanceTravelledTR6(fileData, true);
            DisplayTimeTakenTR6(fileData, true);
        }

        private void DisplayStatistics(byte[] fileData = null)
        {
            isLoading = true;
            distanceTravelledDirty = false;

            try
            {
                if (fileData == null)
                {
                    fileData = File.ReadAllBytes(savegamePath);
                }

                if (!IsSavegamePresent(fileData))
                {
                    SystemSounds.Hand.Play();

                    ThemedMessageBox.Show(
                        this,
                        Globals.DIALOG_MSG_SAVEGAME_NOT_FOUND,
                        Globals.DIALOG_TITLE_ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    DisableButtons();
                    this.Close();
                    return;
                }

                UpdateSavegameDisplayName(fileData);

                if (HasDynamicParams())
                {
                    StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;

                    if (target?.LevelIndex != null)
                    {
                        UpdateDynamicParamsForLevel(fileData, target.LevelIndex.Value);
                    }
                    else
                    {
                        UpdateDynamicParams(fileData);
                    }
                }

                if (IsTRXSavegame())
                {
                    DisplayTRXStatistics(fileData);
                }
                else if (SELECTED_TAB == Globals.TAB_TR4 || SELECTED_TAB == Globals.TAB_TR5)
                {
                    nudSecretsFound.Value = GetNumSecretsFoundTRX2(fileData);
                    nudMedipacksUsed.Value = GetNumMedipacksUsedTRX2(fileData);
                    nudKills.Value = GetNumKillsTRX2(fileData);
                    nudPickups.Value = GetNumPickupsTRX2(fileData);
                    nudAmmoUsed.Value = GetAmmoUsedTRX2(fileData);
                    DisplayDistanceTravelledTRX2(fileData);
                    DisplayTimeTakenTR45(fileData);

                    if (nudVesselsBroken.Enabled)
                    {
                        nudVesselsBroken.Value = GetNumVesselsBroken(fileData);
                    }
                }
                else if (SELECTED_TAB == Globals.TAB_TR6)
                {
                    DisplayTR6Statistics(fileData);
                }
            }
            catch (Exception ex)
            {
                slblStatus.Text = Globals.STATUS_MSG_STATISTICS_READ_ERROR;

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

        private void DisplayDistanceTravelledTRX(byte[] fileData, int? levelIndex = null)
        {
            UInt32 distanceTravelledRaw = GetDistanceTravelled(fileData, levelIndex);

            UInt32 distanceTravelledMeters = distanceTravelledRaw / 445;

            if (distanceTravelledMeters >= 1000)
            {
                decimal distanceToShow = (distanceTravelledMeters / 1000) + ((distanceTravelledMeters % 100) / 100.0m);

                nudDistanceTravelled.DecimalPlaces = 2;
                nudDistanceTravelled.Increment = 0.01m;
                nudDistanceTravelled.Value = distanceToShow;
                lblDistanceTravelledUnit.Text = Globals.LABEL_TEXT_UNIT_KILOMETER;
            }
            else
            {
                nudDistanceTravelled.DecimalPlaces = 0;
                nudDistanceTravelled.Increment = 1;
                nudDistanceTravelled.Value = distanceTravelledMeters;
                lblDistanceTravelledUnit.Text = Globals.LABEL_TEXT_UNIT_METER;
            }
        }

        private void DisplayDistanceTravelledTRX2(byte[] fileData)
        {
            UInt32 distanceTravelledRaw = GetDistanceTravelled(fileData);

            decimal distanceTravelledMeters = distanceTravelledRaw / 419;
            decimal distanceToShow;

            distanceToShow = distanceTravelledMeters;

            nudDistanceTravelled.DecimalPlaces = 0;
            nudDistanceTravelled.Increment = 1;
            lblDistanceTravelledUnit.Text = Globals.LABEL_TEXT_UNIT_METER;

            nudDistanceTravelled.Value = distanceToShow;
        }

        private void DisplayDistanceTravelledTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? DISTANCE_TRAVELLED_OFFSET_FINAL_TR6 : DISTANCE_TRAVELLED_OFFSET;

            UInt32 distanceTravelledRaw = BitConverter.ToUInt32(fileData, savegameOffset + offset);

            decimal distanceTravelledMeters = distanceTravelledRaw / 419;

            nudDistanceTravelled.DecimalPlaces = 0;
            nudDistanceTravelled.Increment = 1;
            lblDistanceTravelledUnit.Text = Globals.LABEL_TEXT_UNIT_METER;
            nudDistanceTravelled.Value = distanceTravelledMeters;
        }

        private void DisplayTimeTakenTR45(byte[] fileData)
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

        private void DisplayTimeTakenTRX(byte[] fileData, int? levelIndex = null)
        {
            Int32 timeTakenRaw = GetTimeTaken(fileData, levelIndex);
            Int32 timeTakenSeconds = timeTakenRaw / 30;
            Int32 remainingSeconds = timeTakenSeconds % 60;
            Int32 totalMinutes = timeTakenSeconds / 60;
            Int32 remainingMinutes = totalMinutes % 60;
            Int32 totalHours = totalMinutes / 60;

            nudHours.Value = totalHours;
            nudMinutes.Value = remainingMinutes;
            nudSeconds.Value = remainingSeconds;
        }

        private void DisplayTimeTakenTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? TIME_TAKEN_OFFSET_FINAL_TR6 : TIME_TAKEN_OFFSET;

            Int32 timeTakenRaw = BitConverter.ToInt32(fileData, savegameOffset + offset);
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

        private Int32 GetAmmoUsedTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToInt32(fileData, savegameOffset + AMMO_USED_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToInt32(fileData, recordOffset + AMMO_USED_ARRAY_OFFSET);
        }

        private Int16 GetAmmoUsedTRX2(byte[] fileData)
        {
            return BitConverter.ToInt16(fileData, savegameOffset + AMMO_USED_OFFSET);
        }

        private Int32 GetAmmoUsedTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? AMMO_USED_OFFSET_FINAL_TR6 : AMMO_USED_OFFSET;

            return BitConverter.ToInt32(fileData, savegameOffset + offset);
        }

        private Int32 GetNumHitsTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? HITS_OFFSET_FINAL_TR6 : HITS_OFFSET;

            return BitConverter.ToInt32(fileData, savegameOffset + offset);
        }

        private Int32 GetNumHitsTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToInt32(fileData, savegameOffset + HITS_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToInt32(fileData, recordOffset + HITS_ARRAY_OFFSET);
        }

        private Int32 GetNumKillsTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToInt32(fileData, savegameOffset + KILLS_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToInt32(fileData, recordOffset + KILLS_ARRAY_OFFSET);
        }

        private UInt16 GetNumKillsTRX2(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + KILLS_OFFSET);
        }

        private UInt16 GetNumKillsTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? KILLS_OFFSET_FINAL_TR6 : KILLS_OFFSET;

            return BitConverter.ToUInt16(fileData, savegameOffset + offset);
        }

        private UInt32 GetDistanceTravelled(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToUInt32(fileData, savegameOffset + DISTANCE_TRAVELLED_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToUInt32(fileData, recordOffset + DISTANCE_TRAVELLED_ARRAY_OFFSET);
        }

        private Int32 GetTimeTaken(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToInt32(fileData, savegameOffset + TIME_TAKEN_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToInt32(fileData, recordOffset + TIME_TAKEN_ARRAY_OFFSET);
        }

        private UInt16 GetNumSecretsFoundTRX(byte[] fileData, int? levelIndex = null)
        {
            UInt16 rawValue;

            if (levelIndex == null)
            {
                rawValue = BitConverter.ToUInt16(fileData, savegameOffset + SECRETS_FOUND_OFFSET);
                return RawSecretsValueToDisplayValue(rawValue);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            rawValue = BitConverter.ToUInt16(fileData, recordOffset + SECRETS_FOUND_ARRAY_OFFSET);

            return RawSecretsValueToDisplayValue(rawValue);
        }

        private byte GetNumSecretsFoundTRX2(byte[] fileData)
        {
            return fileData[savegameOffset + SECRETS_FOUND_OFFSET];
        }

        private sbyte GetNumPickupsTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return (sbyte)fileData[savegameOffset + PICKUPS_OFFSET];
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return (sbyte)fileData[recordOffset + PICKUPS_ARRAY_OFFSET];
        }

        private UInt16 GetNumPickupsTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? PICKUPS_OFFSET_FINAL_TR6 : PICKUPS_OFFSET;

            return BitConverter.ToUInt16(fileData, savegameOffset + offset);
        }

        private Int32 GetNumPickupsTRX2(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + PICKUPS_OFFSET);
        }

        private sbyte GetNumMedipacksUsedTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return (sbyte)fileData[savegameOffset + MEDIPACKS_USED_OFFSET];
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return (sbyte)fileData[recordOffset + MEDIPACKS_USED_ARRAY_OFFSET];
        }

        private byte GetNumMedipacksUsedTRX2(byte[] fileData)
        {
            return fileData[savegameOffset + MEDIPACKS_USED_OFFSET];
        }

        private UInt16 GetNumHealthItemsFoundTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? HEALTH_ITEMS_FOUND_OFFSET_FINAL_TR6 : HEALTH_ITEMS_FOUND_OFFSET;

            return BitConverter.ToUInt16(fileData, savegameOffset + offset);
        }

        private byte GetNumChocobarsFoundTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? CHOCOBARS_FOUND_OFFSET_FINAL_TR6 : CHOCOBARS_FOUND_OFFSET;

            return fileData[savegameOffset + offset];
        }

        private byte GetHealthRestoredTR6(byte[] fileData, bool finalStatistics = false)
        {
            int offset = finalStatistics ? MEDIPACKS_USED_OFFSET_FINAL_TR6 : MEDIPACKS_USED_OFFSET;

            return fileData[savegameOffset + offset];
        }

        private Int32 GetNumCrystalsFoundTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToInt32(fileData, savegameOffset + CRYSTALS_FOUND_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToInt32(fileData, recordOffset + CRYSTALS_FOUND_ARRAY_OFFSET);
        }

        private Int32 GetNumVesselsBroken(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + VESSELS_BROKEN_OFFSET);
        }

        private Int32 GetNumCrystalsUsedTRX(byte[] fileData, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                return BitConverter.ToInt32(fileData, savegameOffset + CRYSTALS_USED_OFFSET);
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            return BitConverter.ToInt32(fileData, recordOffset + CRYSTALS_USED_ARRAY_OFFSET);
        }

        private void WriteAmmoUsedTRX(byte[] fileData, Int32 value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + AMMO_USED_OFFSET, value);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteInt32ToBuffer(fileData, recordOffset + AMMO_USED_ARRAY_OFFSET, value);
        }

        private void WriteAmmoUsedTRX2(byte[] fileData, Int16 value)
        {
            WriteInt16ToBuffer(fileData, savegameOffset + AMMO_USED_OFFSET, value);
        }

        private void WriteAmmoUsedTR6(byte[] fileData, Int32 value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? AMMO_USED_OFFSET_FINAL_TR6 : AMMO_USED_OFFSET;

            WriteInt32ToBuffer(fileData, savegameOffset + offset, value);
        }

        private void WriteNumHitsTR6(byte[] fileData, Int32 value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? HITS_OFFSET_FINAL_TR6 : HITS_OFFSET;

            WriteInt32ToBuffer(fileData, savegameOffset + offset, value);
        }

        private void WriteNumHitsTRX(byte[] fileData, Int32 value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + HITS_OFFSET, value);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteInt32ToBuffer(fileData, recordOffset + HITS_ARRAY_OFFSET, value);
        }

        private void WriteNumKillsTRX(byte[] fileData, Int32 value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + KILLS_OFFSET, value);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteInt32ToBuffer(fileData, recordOffset + KILLS_ARRAY_OFFSET, value);
        }

        private void WriteNumKillsTRX2(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + KILLS_OFFSET, value);
        }

        private void WriteNumKillsTR6(byte[] fileData, UInt16 value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? KILLS_OFFSET_FINAL_TR6 : KILLS_OFFSET;

            WriteUInt16ToBuffer(fileData, savegameOffset + offset, value);
        }

        private void WriteHealthRestoredTR6(byte[] fileData, byte value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? MEDIPACKS_USED_OFFSET_FINAL_TR6 : MEDIPACKS_USED_OFFSET;

            fileData[savegameOffset + offset] = value;
        }

        private void WriteNumSecretsFoundTRX(byte[] fileData, UInt16 value, int? levelIndex = null)
        {
            UInt16 rawValue = 0;

            for (int i = 0; i < value; i++)
            {
                rawValue |= (UInt16)(1 << i);
            }

            if (levelIndex == null)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + SECRETS_FOUND_OFFSET, rawValue);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteUInt16ToBuffer(fileData, recordOffset + SECRETS_FOUND_ARRAY_OFFSET, rawValue);
        }

        private void WriteNumSecretsFoundTRX2(byte[] fileData, byte value)
        {
            fileData[savegameOffset + SECRETS_FOUND_OFFSET] = value;
        }

        private void WriteNumPickupsTRX(byte[] fileData, sbyte value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                fileData[savegameOffset + PICKUPS_OFFSET] = (byte)value;
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            fileData[recordOffset + PICKUPS_ARRAY_OFFSET] = (byte)value;
        }

        private void WriteNumPickupsTRX2(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + PICKUPS_OFFSET, value);
        }

        private void WriteNumPickupsTR6(byte[] fileData, UInt16 value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? PICKUPS_OFFSET_FINAL_TR6 : PICKUPS_OFFSET;

            WriteUInt16ToBuffer(fileData, savegameOffset + offset, value);
        }

        private void WriteNumMedipacksUsedTRX(byte[] fileData, sbyte value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                fileData[savegameOffset + MEDIPACKS_USED_OFFSET] = (byte)value;
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            fileData[recordOffset + MEDIPACKS_USED_ARRAY_OFFSET] = (byte)value;
        }

        private void WriteNumMedipacksUsedTRX2(byte[] fileData, byte value)
        {
            fileData[savegameOffset + MEDIPACKS_USED_OFFSET] = value;
        }

        private void WriteNumCrystalsFoundTRX(byte[] fileData, Int32 value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + CRYSTALS_FOUND_OFFSET, value);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteInt32ToBuffer(fileData, recordOffset + CRYSTALS_FOUND_ARRAY_OFFSET, value);
        }

        private void WriteNumCrystalsUsedTRX(byte[] fileData, Int32 value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + CRYSTALS_USED_OFFSET, value);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteInt32ToBuffer(fileData, recordOffset + CRYSTALS_USED_ARRAY_OFFSET, value);
        }

        private void WriteTimeTakenTR45(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + TIME_TAKEN_OFFSET, value);
        }

        private void WriteTimeTakenTR6(byte[] fileData, Int32 value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? TIME_TAKEN_OFFSET_FINAL_TR6 : TIME_TAKEN_OFFSET;

            value *= 60;

            WriteInt32ToBuffer(fileData, savegameOffset + offset, value);
        }

        private void WriteTimeTakenTRX(byte[] fileData, Int32 value, int? levelIndex = null)
        {
            if (levelIndex == null)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + TIME_TAKEN_OFFSET, value);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteInt32ToBuffer(fileData, recordOffset + TIME_TAKEN_ARRAY_OFFSET, value);
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

        private void WriteDistanceTravelledTRX(byte[] fileData, decimal value, int? levelIndex = null)
        {
            UInt32 distanceTravelledRaw;

            bool isMeter = lblDistanceTravelledUnit.Text == Globals.LABEL_TEXT_UNIT_METER;

            if (isMeter)
            {
                distanceTravelledRaw = (UInt32)(value * 445);
            }
            else
            {
                Int32 wholeKilometers = decimal.ToInt32(decimal.Truncate(value));
                Int32 fraction = decimal.ToInt32((value - wholeKilometers) * 100);

                UInt32 distanceTravelledMeters = (UInt32)(wholeKilometers * 1000 + fraction);
                distanceTravelledRaw = distanceTravelledMeters * 445;
            }

            if (levelIndex == null)
            {
                WriteUInt32ToBuffer(fileData, savegameOffset + DISTANCE_TRAVELLED_OFFSET, distanceTravelledRaw);
                return;
            }

            int recordOffset = savegameOffset + STATISTICS_ARRAY_BASE_OFFSET + ((levelIndex.Value - 1) * STATISTICS_ARRAY_STRIDE);

            WriteUInt32ToBuffer(fileData, recordOffset + DISTANCE_TRAVELLED_ARRAY_OFFSET, distanceTravelledRaw);
        }

        private void WriteDistanceTravelledTRX2(byte[] fileData, decimal value)
        {
            value *= 419;

            WriteUInt32ToBuffer(fileData, savegameOffset + DISTANCE_TRAVELLED_OFFSET, (UInt32)value);
        }

        private void WriteDistanceTravelledTR6(byte[] fileData, decimal value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? DISTANCE_TRAVELLED_OFFSET_FINAL_TR6 : DISTANCE_TRAVELLED_OFFSET;

            value *= 419;

            WriteUInt32ToBuffer(fileData, savegameOffset + offset, (UInt32)value);
        }

        private void WriteVesselsBroken(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + VESSELS_BROKEN_OFFSET, value);
        }

        private void WriteNumHealthItemsFoundTR6(byte[] fileData, UInt16 value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? HEALTH_ITEMS_FOUND_OFFSET_FINAL_TR6 : HEALTH_ITEMS_FOUND_OFFSET;

            WriteUInt16ToBuffer(fileData, savegameOffset + offset, value);
        }

        private void WriteNumChocobarsFoundTR6(byte[] fileData, byte value, bool finalStatistics = false)
        {
            int offset = finalStatistics ? CHOCOBARS_FOUND_OFFSET_FINAL_TR6 : CHOCOBARS_FOUND_OFFSET;

            fileData[savegameOffset + offset] = value;
        }

        private void WriteTRXStatistics(byte[] fileData)
        {
            WriteAmmoUsedTRX(fileData, (Int32)nudAmmoUsed.Value);
            WriteNumHitsTRX(fileData, (Int32)nudHits.Value);
            WriteNumKillsTRX(fileData, (Int32)nudKills.Value);
            WriteNumPickupsTRX(fileData, (sbyte)nudPickups.Value);
            WriteNumMedipacksUsedTRX(fileData, (sbyte)(nudMedipacksUsed.Value * 2));
            WriteTimeTakenTRX(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
            WriteNumSecretsFoundTRX(fileData, (UInt16)nudSecretsFound.Value);

            if (distanceTravelledDirty)
            {
                WriteDistanceTravelledTRX(fileData, (decimal)nudDistanceTravelled.Value);
            }

            if (nudCrystalsFound.Enabled)
            {
                WriteNumCrystalsFoundTRX(fileData, (Int32)nudCrystalsFound.Value);
            }

            if (nudCrystalsUsed.Enabled)
            {
                WriteNumCrystalsUsedTRX(fileData, (Int32)nudCrystalsUsed.Value);
            }
        }

        private void WriteTRXStatisticsRecord(byte[] fileData, int levelIndex)
        {
            WriteAmmoUsedTRX(fileData, (Int32)nudAmmoUsed.Value, levelIndex);
            WriteNumHitsTRX(fileData, (Int32)nudHits.Value, levelIndex);
            WriteNumKillsTRX(fileData, (Int32)nudKills.Value, levelIndex);
            WriteNumPickupsTRX(fileData, (sbyte)nudPickups.Value, levelIndex);
            WriteNumMedipacksUsedTRX(fileData, (sbyte)(nudMedipacksUsed.Value * 2), levelIndex);
            WriteTimeTakenTRX(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30, levelIndex);
            WriteDistanceTravelledTRX(fileData, (decimal)nudDistanceTravelled.Value, levelIndex);
            WriteNumSecretsFoundTRX(fileData, (UInt16)nudSecretsFound.Value, levelIndex);

            if (nudCrystalsFound.Enabled)
            {
                WriteNumCrystalsFoundTRX(fileData, (Int32)nudCrystalsFound.Value, levelIndex);
            }

            if (nudCrystalsUsed.Enabled)
            {
                WriteNumCrystalsUsedTRX(fileData, (Int32)nudCrystalsUsed.Value, levelIndex);
            }
        }

        private void WriteTR6CurrentLevelStatistics(byte[] fileData)
        {
            WriteAmmoUsedTR6(fileData, (Int32)nudAmmoUsed.Value);
            WriteHealthRestoredTR6(fileData, (byte)nudMedipacksUsed.Value);
            WriteNumHitsTR6(fileData, (Int32)nudHits.Value);
            WriteNumKillsTR6(fileData, (UInt16)nudKills.Value);
            WriteNumPickupsTR6(fileData, (UInt16)nudPickups.Value);
            WriteNumHealthItemsFoundTR6(fileData, (UInt16)nudHealthItemsFound.Value);
            WriteNumChocobarsFoundTR6(fileData, (byte)nudChocobarsFound.Value);
            WriteDistanceTravelledTR6(fileData, (decimal)nudDistanceTravelled.Value);
            WriteTimeTakenTR6(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value));
        }

        private void WriteTR6FinalStatistics(byte[] fileData)
        {
            WriteAmmoUsedTR6(fileData, (Int32)nudAmmoUsed.Value, true);
            WriteHealthRestoredTR6(fileData, (byte)nudMedipacksUsed.Value, true);
            WriteNumHitsTR6(fileData, (Int32)nudHits.Value, true);
            WriteNumKillsTR6(fileData, (UInt16)nudKills.Value, true);
            WriteNumPickupsTR6(fileData, (UInt16)nudPickups.Value, true);
            WriteNumHealthItemsFoundTR6(fileData, (UInt16)nudHealthItemsFound.Value, true);
            WriteNumChocobarsFoundTR6(fileData, (byte)nudChocobarsFound.Value, true);
            WriteDistanceTravelledTR6(fileData, (decimal)nudDistanceTravelled.Value, true);
            WriteTimeTakenTR6(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value), true);
        }

        private void WriteTR6Statistics(byte[] fileData)
        {
            StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;

            if (target.LevelIndex == null)
            {
                WriteTR6CurrentLevelStatistics(fileData);
            }
            else
            {
                WriteTR6FinalStatistics(fileData);
            }
        }

        private void WriteChanges()
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(savegamePath);

                if (!IsSavegamePresent(fileData))
                {
                    SystemSounds.Hand.Play();

                    ThemedMessageBox.Show(
                        this,
                        Globals.DIALOG_MSG_SAVEGAME_NOT_FOUND,
                        Globals.DIALOG_TITLE_ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

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
                    if (!ShouldShowLevelSelect(fileData))
                    {
                        WriteTRXStatistics(fileData);
                    }
                    else
                    {
                        StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;

                        if (target.LevelIndex == null)
                        {
                            WriteTRXStatistics(fileData);
                        }
                        else
                        {
                            WriteTRXStatisticsRecord(fileData, target.LevelIndex.Value);
                        }
                    }
                }
                else if (SELECTED_TAB == Globals.TAB_TR4 || SELECTED_TAB == Globals.TAB_TR5)
                {
                    WriteAmmoUsedTRX2(fileData, (Int16)nudAmmoUsed.Value);
                    WriteNumKillsTRX2(fileData, (UInt16)nudKills.Value);
                    WriteNumPickupsTRX2(fileData, (Int32)nudPickups.Value);
                    WriteNumMedipacksUsedTRX2(fileData, (byte)nudMedipacksUsed.Value);
                    WriteNumSecretsFoundTRX2(fileData, (byte)nudSecretsFound.Value);
                    WriteTimeTakenTR45(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteTimeTakenToTimestamp(fileData, (Int32)(nudHours.Value * 3600 + nudMinutes.Value * 60 + nudSeconds.Value) * 30);
                    WriteDistanceTravelledTRX2(fileData, (decimal)nudDistanceTravelled.Value);

                    if (nudVesselsBroken.Enabled)
                    {
                        WriteVesselsBroken(fileData, (Int32)nudVesselsBroken.Value);
                    }
                }
                else if (SELECTED_TAB == Globals.TAB_TR6)
                {
                    WriteTR6Statistics(fileData);
                }

                File.WriteAllBytes(savegamePath, fileData);

                DisableButtons();

                distanceTravelledDirty = false;

                UpdateSavegameDisplayName(fileData);

                if (HasDynamicParams())
                {
                    StatisticsTarget target = (StatisticsTarget)cmbStatistics.SelectedItem;

                    if (target?.LevelIndex != null)
                    {
                        UpdateDynamicParamsForLevel(fileData, target.LevelIndex.Value);
                    }
                    else
                    {
                        UpdateDynamicParams(fileData);
                    }
                }

                slblStatus.Text = $"{Globals.STATUS_MSG_STATISTICS_WRITE_SUCCESS} '{selectedSavegame}'";
            }
            catch (Exception ex)
            {
                slblStatus.Text = Globals.STATUS_MSG_STATISTICS_WRITE_ERROR;

                SystemSounds.Hand.Play();

                ThemedMessageBox.Show(
                    this,
                    ex.Message,
                    Globals.DIALOG_TITLE_ERROR,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                distanceTravelledDirty = true;
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
                distanceTravelledDirty = true;
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

        private void cmbStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                DisplayStatistics();
                DisableButtons();
            }
        }

        private readonly Dictionary<int, int> secretsFoundMaxTR1 = new Dictionary<int, int>
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

        private readonly Dictionary<int, int> secretsFoundMaxTR2 = new Dictionary<int, int>
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

        private readonly Dictionary<int, int> secretsFoundMaxTR3 = new Dictionary<int, int>
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

        private readonly Dictionary<int, int> pickupsFoundMaxTR3 = new Dictionary<int, int>
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

        private readonly Dictionary<int, int> pickupsFoundMaxTR2 = new Dictionary<int, int>
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

        private readonly Dictionary<int, int> pickupsFoundMaxTR1 = new Dictionary<int, int>
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

        private readonly Dictionary<int, int> pickupsFoundMaxTR6 = new Dictionary<int, int>
        {
            {  0, 19 },  // Parisian Back Streets
            {  1, 11 },  // Derelict Apartment Block
            {  2, 5  },  // Margot Carvier's Apartment
            {  3, 14 },  // Industrial Roof Tops
            {  4, 2  },  // Parisian Ghetto (Part 1)
            {  5, 0  },  // Parisian Ghetto (Part 2)
            {  6, 4  },  // Parisian Ghetto (Part 3)
            {  7, 33 },  // The Serpent Rouge
            {  8, 9  },  // Rennes' Pawnshop
            {  9, 0  },  // Willowtree Herbalist
            { 10, 5  },  // St. Aicard's Church
            { 11, 2  },  // Cafe Metro
            { 12, 9  },  // St. Aicard's Graveyard
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

        private readonly Dictionary<int, int> healthItemsFoundMaxTR6 = new Dictionary<int, int>
        {
            {  0, 5  },  // Parisian Back Streets
            {  1, 3  },  // Derelict Apartment Block
            {  2, 1  },  // Margot Carvier's Apartment
            {  3, 5  },  // Industrial Roof Tops
            {  4, 1  },  // Parisian Ghetto (Part 1)
            {  5, 0  },  // Parisian Ghetto (Part 2)
            {  6, 0  },  // Parisian Ghetto (Part 3)
            {  7, 3  },  // The Serpent Rouge
            {  8, 0  },  // Rennes' Pawnshop
            {  9, 0  },  // Willowtree Herbalist
            { 10, 1  },  // St. Aicard's Church
            { 11, 0  },  // Cafe Metro
            { 12, 4  },  // St. Aicard's Graveyard
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

        private readonly Dictionary<int, int> chocobarsFoundMaxTR6 = new Dictionary<int, int>
        {
            {  0, 3  },  // Parisian Back Streets
            {  1, 1  },  // Derelict Apartment Block
            {  2, 0  },  // Margot Carvier's Apartment
            {  3, 1  },  // Industrial Roof Tops
            {  4, 1  },  // Parisian Ghetto (Part 1)
            {  5, 0  },  // Parisian Ghetto (Part 2)
            {  6, 0  },  // Parisian Ghetto (Part 3)
            {  7, 5  },  // The Serpent Rouge
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
