using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR2Utilities
    {
        // Static offsets
        private const int SAVEFILE_VERSION_OFFSET = 0x000;
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;
        private const int LEVEL_INDEX_OFFSET_PREPATCH = 0x628;

        // Platform or patch-dependent offsets
        private int LEVEL_INDEX_OFFSET;
        private int BASE_SAVEGAME_OFFSET_TR2;
        private int MAX_SAVEGAME_OFFSET_TR2;
        private int SAVEGAME_SIZE;
        private int SAVEGAME_VERSION_OFFSET;
        private int CHALLENGE_MODE_RNG_SEED_OFFSET;
        private int CHALLENGE_MODE_OFFSET;
        private int CHALLENGE_MODE_MAX_HEALTH_OFFSET;
        private int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET;
        private int CHALLENGE_MODE_ENEMY_TYPE_OFFSET;

        // Savegame constants
        private const int MAX_SAVEGAMES = 32;

        // PC offsets
        private const int LEVEL_INDEX_OFFSET_PC = 0x628;
        private const int SAVEGAME_VERSION_OFFSET_PC = 0x6A8;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PC = 0x6AC;
        private const int CHALLENGE_MODE_OFFSET_PC = 0x6B0;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC = 0x6C2;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC = 0x6C6;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC = 0x6C9;

        // Android offsets
        private const int LEVEL_INDEX_OFFSET_ANDROID = 0x658;
        private const int SAVEGAME_VERSION_OFFSET_ANDROID = 0x6D4;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID = 0x6D8;
        private const int CHALLENGE_MODE_OFFSET_ANDROID = 0x6DC;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID = 0x6F9;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID = 0x6FD;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID = 0x700;

        // PS4 offsets
        private const int LEVEL_INDEX_OFFSET_PS4 = 0x628;
        private const int SAVEGAME_VERSION_OFFSET_PS4 = 0x6A4;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PS4 = 0x6A8;
        private const int CHALLENGE_MODE_OFFSET_PS4 = 0x6AC;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PS4 = 0x6BE;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PS4 = 0x6C2;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PS4 = 0x6C5;

        // Patch-dependent
        private const int SAVEGAME_SIZE_PREPATCH = 0x3800;
        private const int SAVEGAME_SIZE_PATCH5 = 0x6800;
        private const int BASE_SAVEGAME_OFFSET_TR2_PREPATCH = 0x72000;
        private const int BASE_SAVEGAME_OFFSET_TR2_PATCH5 = 0xD2000;
        private const int MAX_SAVEGAME_OFFSET_TR2_PREPATCH = 0xE2000;
        private const int MAX_SAVEGAME_OFFSET_TR2_PATCH5 = 0x19B800;

        // Patch-related signatures
        private const byte SAVEFILE_PREPATCH = 0x3B;
        private const byte SAVEFILE_PATCH5 = 0x3C;

        // Static offsets (per level)
        private int SMALL_MEDIPACK_OFFSET;
        private int LARGE_MEDIPACK_OFFSET;
        private int FLARES_OFFSET;
        private int WEAPONS_CONFIG_NUM_OFFSET;
        private int AUTOMATIC_PISTOLS_AMMO_OFFSET;
        private int UZI_AMMO_OFFSET;
        private int SHOTGUN_AMMO_OFFSET;
        private int HARPOON_GUN_AMMO_OFFSET;
        private int M16_AMMO_OFFSET;
        private int GRENADE_LAUNCHER_AMMO_OFFSET;

        // Dynamic ammo offsets
        private int m16AmmoOffset2;
        private int grenadeLauncherAmmoOffset2;
        private int harpoonGunAmmoOffset2;
        private int shotgunAmmoOffset2;
        private int uziAmmoOffset2;
        private int automaticPistolsAmmoOffset2;

        // Weapon byte flags
        private const byte WEAPON_PISTOLS = 2;
        private const byte WEAPON_AUTOMATIC_PISTOLS = 4;
        private const byte WEAPON_UZIS = 8;
        private const byte WEAPON_SHOTGUN = 16;
        private const byte WEAPON_M16 = 32;
        private const byte WEAPON_GRENADE_LAUNCHER = 64;
        private const byte WEAPON_HARPOON_GUN = 128;

        // Challenge Mode constants
        private const byte CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL = 3;
        private const byte CHALLENGE_MODE_ENEMY_TYPE_NORMAL = 2;
        private const byte CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER = 5;

        // Entity block starts
        private const int ENTITY_BLOCK_START_PC = 0x6BC;
        private const int ENTITY_BLOCK_START_ANDROID = 0x6F3;
        private const int ENTITY_BLOCK_START_PS4 = 0x6B8;
        private const int ENTITY_BLOCK_START_PC_PREPATCH = 0x6A2;
        private const int ENTITY_BLOCK_START_PS4_PREPATCH = 0x69E;
        private const int ENTITY_BLOCK_START_NS_PREPATCH = 0x69E;

        // Health
        private const UInt16 MAX_HEALTH_VALUE_DEFAULT = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private UInt16 MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
        private int HEALTH_OFFSET;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private const int ENTITY_AI_BLOCK_SIZE = 0xC;
        private int AMMO_WRITE_LOWER_BOUND;
        private int AMMO_WRITE_UPPER_BOUND;
        private int sgBufferCursor = 0;
        private int rngState;

        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
        {
            {  1,  "The Great Wall"             },
            {  2,  "Venice"                     },
            {  3,  "Bartoli's Hideout"          },
            {  4,  "Opera House"                },
            {  5,  "Offshore Rig"               },
            {  6,  "Diving Area"                },
            {  7,  "40 Fathoms"                 },
            {  8,  "Wreck of the Maria Doria"   },
            {  9,  "Living Quarters"            },
            { 10,  "The Deck"                   },
            { 11,  "Tibetan Foothills"          },
            { 12,  "Barkhang Monastery"         },
            { 13,  "Catacombs of the Talion"    },
            { 14,  "Ice Palace"                 },
            { 15,  "Temple of Xian"             },
            { 16,  "Floating Islands"           },
            { 17,  "The Dragon's Lair"          },
            { 18,  "Home Sweet Home"            },
            { 19,  "The Cold War"               },
            { 20,  "Fool's Gold"                },
            { 21,  "Furnace of the Gods"        },
            { 22,  "Kingdom"                    },
            { 23,  "Nightmare in Vegas"         },
        };

        private void WriteInt32ToBuffer(byte[] buffer, int offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void WriteUInt16ToBuffer(byte[] buffer, int offset, UInt16 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 2);
        }

        public int GetHealthOffset(byte[] savegameData = null, bool areOffsetsDetermined = false)
        {
            if (savegameData == null)
            {
                savegameData = File.ReadAllBytes(savegamePath);
            }

            if (!areOffsetsDetermined)
            {
                DetermineDynamicOffsets(savegameData);
            }

            bool isPrepatch = IsPrepatchSavegameFile(savegameData);

            if (!isPrepatch)
            {
                bool isChallengeMode = IsChallengeMode(savegameData);
                MAX_HEALTH_VALUE = isChallengeMode ? GetChallengeModeMaxHealth(savegameData) : MAX_HEALTH_VALUE_DEFAULT;
            }
            else
            {
                MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
            }

            UInt16 value = BitConverter.ToUInt16(savegameData, savegameOffset + HEALTH_OFFSET);

            if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
            {
                return savegameOffset + HEALTH_OFFSET;
            }

            return -1;
        }

        public void DetermineOffsets(byte[] fileData)
        {
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR2 = BASE_SAVEGAME_OFFSET_TR2_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR2 = MAX_SAVEGAME_OFFSET_TR2_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR2 = BASE_SAVEGAME_OFFSET_TR2_PATCH5;
                MAX_SAVEGAME_OFFSET_TR2 = MAX_SAVEGAME_OFFSET_TR2_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;

                if (platform == Platform.PC)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PC;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_PC;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_PC;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PC;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC;
                }
                else if (platform == Platform.Android)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_ANDROID;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_ANDROID;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_ANDROID;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID;
                }
                else if (platform == Platform.PlayStation4)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PS4;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_PS4;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_PS4;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PS4;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_PS4;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PS4;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PS4;
                }
            }

            byte levelIndex = GetLevelIndex(fileData);

            AUTOMATIC_PISTOLS_AMMO_OFFSET = 0x12 + (levelIndex * 0x30);
            UZI_AMMO_OFFSET = 0x14 + (levelIndex * 0x30);
            SHOTGUN_AMMO_OFFSET = 0x16 + (levelIndex * 0x30);
            M16_AMMO_OFFSET = 0x18 + (levelIndex * 0x30);
            GRENADE_LAUNCHER_AMMO_OFFSET = 0x1A + (levelIndex * 0x30);
            HARPOON_GUN_AMMO_OFFSET = 0x1C + (levelIndex * 0x30);
            SMALL_MEDIPACK_OFFSET = 0x1E + (levelIndex * 0x30);
            LARGE_MEDIPACK_OFFSET = 0x1F + (levelIndex * 0x30);
            FLARES_OFFSET = 0x21 + (levelIndex * 0x30);
            WEAPONS_CONFIG_NUM_OFFSET = 0x3C + (levelIndex * 0x30);
        }

        private bool IsPrepatchSavegameFile(byte[] fileData)
        {
            return fileData[SAVEFILE_VERSION_OFFSET] == SAVEFILE_PREPATCH;
        }

        private bool IsNativePatch5Format(byte[] fileData)
        {
            Int32 savegameVersion = BitConverter.ToInt32(fileData, savegameOffset + SAVEGAME_VERSION_OFFSET);
            return savegameVersion >= 2;
        }

        public bool IsChallengeMode(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_OFFSET] == 1;
        }

        public UInt16 GetChallengeModeMaxHealth(byte[] fileData)
        {
            byte maxHealthSetting = fileData[savegameOffset + CHALLENGE_MODE_MAX_HEALTH_OFFSET];

            if (maxHealthSetting == 0) return (UInt16)100;
            if (maxHealthSetting == 1) return (UInt16)250;
            if (maxHealthSetting == 2) return (UInt16)500;
            if (maxHealthSetting == 3) return (UInt16)1000;
            if (maxHealthSetting == 4) return (UInt16)1500;
            if (maxHealthSetting == 5) return (UInt16)1750;
            if (maxHealthSetting == 6) return (UInt16)2000;
            if (maxHealthSetting == 7) return (UInt16)5000;

            return MAX_HEALTH_VALUE_DEFAULT;
        }

        private byte GetChallengeModeEnemyNumbers(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET];
        }

        private byte GetChallengeModeEnemyType(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_TYPE_OFFSET];
        }

        private Int32 GetChallengeModeRNGSeed(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + CHALLENGE_MODE_RNG_SEED_OFFSET);
        }

        private Int32 GetSaveNumber(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + SAVE_NUMBER_OFFSET);
        }

        private byte GetLevelIndex(byte[] fileData)
        {
            return fileData[savegameOffset + LEVEL_INDEX_OFFSET];
        }

        private byte GetNumSmallMedipacks(byte[] fileData)
        {
            return fileData[savegameOffset + SMALL_MEDIPACK_OFFSET];
        }

        private byte GetNumLargeMedipacks(byte[] fileData)
        {
            return fileData[savegameOffset + LARGE_MEDIPACK_OFFSET];
        }

        private byte GetNumFlares(byte[] fileData)
        {
            return fileData[savegameOffset + FLARES_OFFSET];
        }

        private byte GetWeaponsConfigNum(byte[] fileData)
        {
            return fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET];
        }

        private UInt16 GetShotgunAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET) / 6);
        }

        private UInt16 GetAutomaticPistolsAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + AUTOMATIC_PISTOLS_AMMO_OFFSET);
        }

        private UInt16 GetUziAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + UZI_AMMO_OFFSET);
        }

        private UInt16 GetM16Ammo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + M16_AMMO_OFFSET);
        }

        private UInt16 GetGrenadeLauncherAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + GRENADE_LAUNCHER_AMMO_OFFSET);
        }

        private UInt16 GetHarpoonGunAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + HARPOON_GUN_AMMO_OFFSET);
        }

        private UInt16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            return BitConverter.ToUInt16(fileData, healthOffset);
        }

        public bool IsLaraInVehicle(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 10];
            byte byteFlag2 = fileData[healthOffset - 9];
            byte byteFlag3 = fileData[healthOffset - 8];
            byte byteFlag4 = fileData[healthOffset - 7];

            if (byteFlag1 == 0x01 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Motorboat
            if (byteFlag1 == 0x05 && byteFlag2 == 0x00 && byteFlag3 == 0x05 && byteFlag4 == 0x00) return true;  // Motorboat
            if (byteFlag1 == 0x08 && byteFlag2 == 0x00 && byteFlag3 == 0x08 && byteFlag4 == 0x00) return true;  // Snowmobile
            if (byteFlag1 == 0x04 && byteFlag2 == 0x00 && byteFlag3 == 0x04 && byteFlag4 == 0x00) return true;  // Snowmobile

            return false;
        }

        public bool IsLaraFreefalling(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 10];
            byte byteFlag2 = fileData[healthOffset - 9];
            byte byteFlag3 = fileData[healthOffset - 8];
            byte byteFlag4 = fileData[healthOffset - 7];

            if (byteFlag1 == 0x09 && byteFlag2 == 0x00 && byteFlag3 == 0x09 && byteFlag4 == 0x00) return true;

            return false;
        }

        private void WriteSaveNumber(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + SAVE_NUMBER_OFFSET, value);
        }

        private void WriteNumSmallMedipacks(byte[] fileData, byte value)
        {
            fileData[savegameOffset + SMALL_MEDIPACK_OFFSET] = value;
        }

        private void WriteNumLargeMedipacks(byte[] fileData, byte value)
        {
            fileData[savegameOffset + LARGE_MEDIPACK_OFFSET] = value;
        }

        private void WriteNumFlares(byte[] fileData, byte value)
        {
            fileData[savegameOffset + FLARES_OFFSET] = value;
        }

        private void WriteWeaponsConfigNum(byte[] fileData, byte value)
        {
            fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET] = value;
        }

        private void WriteHealthValue(byte[] fileData, UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            if (shotgunAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || shotgunAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, (Int32)ammo);
            }
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteAutomaticPistolsAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + AUTOMATIC_PISTOLS_AMMO_OFFSET, ammo);

            if (automaticPistolsAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || automaticPistolsAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + automaticPistolsAmmoOffset2, (Int32)ammo);
            }
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + automaticPistolsAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);

            if (uziAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || uziAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + uziAmmoOffset2, (Int32)ammo);
            }
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private void WriteM16Ammo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + M16_AMMO_OFFSET, ammo);

            if (m16AmmoOffset2 < AMMO_WRITE_LOWER_BOUND || m16AmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + m16AmmoOffset2, (Int32)ammo);
            }
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + m16AmmoOffset2, 0);
            }
        }

        private void WriteGrenadeLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRENADE_LAUNCHER_AMMO_OFFSET, ammo);

            if (grenadeLauncherAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || grenadeLauncherAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, (Int32)ammo);
            }
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, 0);
            }
        }

        private void WriteHarpoonGunAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + HARPOON_GUN_AMMO_OFFSET, ammo);

            if (harpoonGunAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || harpoonGunAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + harpoonGunAmmoOffset2, (Int32)ammo);
            }
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + harpoonGunAmmoOffset2, 0);
            }
        }

        public void SetLevelParams(byte[] fileData, CheckBox chkPistols, CheckBox chkShotgun, CheckBox chkAutomaticPistols,
            CheckBox chkUzis, CheckBox chkM16, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudShotgunAmmo,
            NumericUpDown nudAutomaticPistolsAmmo, NumericUpDown nudUziAmmo, NumericUpDown nudM16Ammo,
            NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudHarpoonGunAmmo, Label lblPistolAmmo)
        {
            byte levelIndex = GetLevelIndex(fileData);

            if (levelIndex == 18)       // Home Sweet Home
            {
                chkPistols.Enabled = false;
                chkShotgun.Enabled = true;
                chkAutomaticPistols.Enabled = false;
                chkUzis.Enabled = false;
                chkM16.Enabled = false;
                chkGrenadeLauncher.Enabled = false;
                chkHarpoonGun.Enabled = false;
                nudShotgunAmmo.Enabled = true;
                nudAutomaticPistolsAmmo.Enabled = false;
                nudUziAmmo.Enabled = false;
                nudM16Ammo.Enabled = false;
                nudGrenadeLauncherAmmo.Enabled = false;
                nudHarpoonGunAmmo.Enabled = false;
                lblPistolAmmo.Enabled = false;
            }
            else if (levelIndex == 23)  // Nightmare in Vegas
            {
                chkPistols.Enabled = true;
                chkShotgun.Enabled = true;
                chkAutomaticPistols.Enabled = true;
                chkUzis.Enabled = true;
                chkM16.Enabled = false;
                chkGrenadeLauncher.Enabled = false;
                chkHarpoonGun.Enabled = false;
                nudShotgunAmmo.Enabled = true;
                nudAutomaticPistolsAmmo.Enabled = true;
                nudUziAmmo.Enabled = true;
                nudM16Ammo.Enabled = false;
                nudGrenadeLauncherAmmo.Enabled = false;
                nudHarpoonGunAmmo.Enabled = false;
                lblPistolAmmo.Enabled = true;
            }
            else
            {
                chkPistols.Enabled = true;
                chkShotgun.Enabled = true;
                chkAutomaticPistols.Enabled = true;
                chkUzis.Enabled = true;
                chkM16.Enabled = true;
                chkGrenadeLauncher.Enabled = true;
                chkHarpoonGun.Enabled = true;
                nudShotgunAmmo.Enabled = true;
                nudAutomaticPistolsAmmo.Enabled = true;
                nudUziAmmo.Enabled = true;
                nudM16Ammo.Enabled = true;
                nudGrenadeLauncherAmmo.Enabled = true;
                nudHarpoonGunAmmo.Enabled = true;
                lblPistolAmmo.Enabled = true;
            }
        }

        private void SeedRNG(int seed)
        {
            rngState = seed;
        }

        private int NextRNG()
        {
            rngState = rngState * 0x343FD + 0x269EC3;
            return (rngState >> 0x10) & 0x7FFF;
        }

        private HashSet<int> BuildRemovalSet(
            List<int> entityIds,
            Dictionary<int, TR2Object> levelObjects,
            byte levelIndex,
            byte enemyNumbers)
        {
            var removalSet = new HashSet<int>();

            // Only applies to EN modes below Normal
            if (enemyNumbers >= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                return removalSet;
            }

            // =========================
            // 1. Build candidate pool
            // =========================
            var candidates = new List<int>();

            for (int i = 0; i < entityIds.Count; i++)
            {
                int objectId = entityIds[i];

                // Must exist in EnemyDefinitions
                if (!TR2EntityCache.TR2EnemyRemovableByObjectId.TryGetValue(objectId, out bool removable)) continue;

                // Must be removable
                if (!removable) continue;

                // Skip unchangeable indices
                if (TR2EntityCache.UnchangeableEntitiesByLevel.TryGetValue(levelIndex, out var locked) && locked.Contains(i)) continue;

                candidates.Add(i);
            }

            int candidateCount = candidates.Count;
            if (candidateCount == 0)
            {
                return removalSet;
            }

            // =========================
            // 2. Compute removal count
            // =========================
            int rawPercent = TR2EntityCache.EnemyRemovalPercents[enemyNumbers];

            // Engine negates this
            int percent = -rawPercent;

            int removeCount = ComputeRemovalCount(candidateCount, percent);

            if (removeCount <= 0)
            {
                return removalSet;
            }

            // =========================
            // 3. RNG selection (retry)
            // =========================
            while (removalSet.Count < removeCount)
            {
                int roll = NextRNG();
                int idx = roll % candidateCount;

                int entityIndex = candidates[idx];

                if (removalSet.Contains(entityIndex))
                {
                    continue; // retry (CRITICAL)
                }

                removalSet.Add(entityIndex);
            }

            return removalSet;
        }

        private int ComputeRemovalCount(int candidateCount, int percent)
        {
            // percent is negative
            double value = (candidateCount * percent) / 100.0;

            int floor = (int)value;
            double fraction = value - floor;

            if (fraction < 0.5)
            {
                return Math.Max(0, floor);
            }

            if (fraction > 0.5)
            {
                return Math.Max(0, floor + 1);
            }

            // exactly 0.5 -> RNG tie-break
            int roll = NextRNG() % 100;

            int result = (roll < 50) ? floor : floor + 1;

            return Math.Max(0, result);
        }

        private void ApplyAddEnemies(
            List<int> result,
            byte levelIndex,
            byte enemyNumbers)
        {
            if (enemyNumbers <= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                return;
            }

            if (!TR2EntityCache.TR2AddEnemyTableByLevel.TryGetValue(levelIndex, out var addList))
            {
                return;
            }

            int totalAddEntries = addList.Count;
            if (totalAddEntries == 0)
            {
                return;
            }

            int percent = TR2EntityCache.EnemyRemovalPercents[enemyNumbers];
            // Same table: 25/50/100 for > Normal

            int selectedCount = ComputePositiveSelectionCount(totalAddEntries, percent);

            if (selectedCount <= 0)
            {
                return;
            }

            var selected = new bool[totalAddEntries];
            int selectedSoFar = 0;

            while (selectedSoFar < selectedCount)
            {
                int randomIndex = NextRNG() % totalAddEntries;

                if (selected[randomIndex])
                {
                    continue;
                }

                selected[randomIndex] = true;
                selectedSoFar++;
            }

            // IMPORTANT: Append in original add-table order
            for (int i = 0; i < totalAddEntries; i++)
            {
                if (selected[i])
                {
                    result.Add(addList[i]);
                }
            }
        }

        private int ComputePositiveSelectionCount(int totalCount, int percent)
        {
            double value = (double)(totalCount * percent) / 100.0;
            int floor = (int)value;
            double fraction = value - floor;

            if (fraction < 0.5)
            {
                return floor;
            }

            if (fraction > 0.5)
            {
                return floor + 1;
            }

            // exactly .5
            int roll = NextRNG() % 100;
            return (roll < 50) ? floor : floor + 1;
        }

        private List<int> ApplyChallengeModeMutations(List<int> baseList, byte levelIndex, byte enemyNumbers, byte enemyType, Int32 seed)
        {
            var result = new List<int>(baseList);

            List<int> tail = null;

            if (TR2EntityCache.SplitIndexByLevel.TryGetValue(levelIndex, out int splitIndex))
            {
                tail = result.Skip(splitIndex).ToList();
                result = result.Take(splitIndex).ToList();
            }

            // Special exception for Fool's Gold
            if (levelIndex == 20 && result.Count > 82)
            {
                result[82] = 0x88;
            }

            if (enemyNumbers <= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL && enemyType == CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            if (!TR2EntityCache.ChallengeModeItemCountModifiersByLevel.TryGetValue(levelIndex, out var levelModifiers))
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            if (!levelModifiers.TryGetValue(enemyNumbers, out int addCount))
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            if (addCount <= 0 && enemyType == CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            SeedRNG(seed);

            if (!TR2EntityCache.TR2ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
            {
                if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    return tail != null ? result.Concat(tail).ToList() : result;
                }
            }

            // ===================================
            // EN APPEND FIRST
            // ===================================
            if (enemyNumbers > CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                ApplyAddEnemies(result, levelIndex, enemyNumbers);
            }

            // ===================================
            // SINGLE ET MUTATION PASS (FULL LIST)
            // ===================================
            if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                var catType = enemyType;

                if (!TR2EntityCache.ChallengeModeCatGroups.TryGetValue(catType, out var catGroups))
                {
                    return tail != null ? result.Concat(tail).ToList() : result;
                }

                Dictionary<string, string> catMapping = null;

                if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    if (!TR2EntityCache.ChallengeModeCatMapping.TryGetValue(enemyType, out catMapping))
                    {
                        return tail != null ? result.Concat(tail).ToList() : result;
                    }
                }

                var objectToCat = new Dictionary<int, string>();

                foreach (var kvp in catGroups)
                {
                    foreach (var entry in kvp.Value)
                    {
                        objectToCat[entry.ObjectId] = kvp.Key;
                    }
                }

                var removalSet = BuildRemovalSet(result, levelObjects, levelIndex, enemyNumbers);

                for (int i = 0; i < result.Count; i++)
                {
                    int originalId = result[i];

                    if (!levelObjects.TryGetValue(originalId, out var obj)) continue;
                    if ((obj.Flags00 & 0x02) == 0) continue;
                    if (!objectToCat.TryGetValue(originalId, out var sourceCat)) continue;
                    if (!catGroups.TryGetValue(sourceCat, out var sourceEntries)) continue;
                    if (TR2EntityCache.UnchangeableEntitiesByLevel.TryGetValue(levelIndex, out var set) && set.Contains(i)) continue;
                    if (removalSet.Contains(i)) continue;

                    TR2CatEntry sourceEntry = null;

                    foreach (var e in sourceEntries)
                    {
                        if (e.ObjectId == originalId)
                        {
                            sourceEntry = e;
                            break;
                        }
                    }

                    if (sourceEntry == null) continue;

                    int gateRoll = NextRNG() % 100;
                    if (sourceEntry.Weight < gateRoll) continue;

                    string targetCat = enemyType == CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER ? sourceCat : catMapping[sourceCat];

                    if (!catGroups.TryGetValue(targetCat, out var targetEntries)) continue;

                    int pickRoll = NextRNG() % 100;
                    int cumulative = 0;

                    foreach (var entry in targetEntries)
                    {
                        cumulative += entry.Meta2;
                        if (pickRoll <= cumulative)
                        {
                            result[i] = entry.ObjectId;
                            break;
                        }
                    }
                }
            }

            // ===================================
            // RECOMBINE SPLIT LIST
            // ===================================
            if (tail != null)
            {
                result.AddRange(tail);
            }

            return result;
        }

        private int GetEntityBlockStart(bool isPrepatch)
        {
            if (isPrepatch)
            {
                if (platform == Platform.PC)
                {
                    return ENTITY_BLOCK_START_PC_PREPATCH;
                }
                else if (platform == Platform.PlayStation4)
                {
                    return ENTITY_BLOCK_START_PS4_PREPATCH;
                }
                else if (platform == Platform.NintendoSwitch)
                {
                    return ENTITY_BLOCK_START_NS_PREPATCH;
                }

                return ENTITY_BLOCK_START_PC_PREPATCH;
            }
            else
            {
                if (platform == Platform.PC)
                {
                    return ENTITY_BLOCK_START_PC;
                }
                else if (platform == Platform.Android)
                {
                    return ENTITY_BLOCK_START_ANDROID;
                }
                else if (platform == Platform.PlayStation4)
                {
                    return ENTITY_BLOCK_START_PS4;
                }

                return ENTITY_BLOCK_START_PC;
            }
        }

        private void DetermineDynamicOffsets(byte[] fileData)
        {
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNativePatch5 = IsNativePatch5Format(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            byte levelIndex = GetLevelIndex(fileData);

            var baseList = TR2EntityCache.LevelObjectIdsByLevel[levelIndex];
            var levelObjectIds = new List<int>(baseList);

            sgBufferCursor = GetEntityBlockStart(isPrepatch);

            if (isChallengeMode && isNativePatch5 && !isPrepatch)
            {
                byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
                byte enemyType = GetChallengeModeEnemyType(fileData);
                Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);

                levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

                sgBufferCursor += 0x0C;
            }

            sgBufferCursor += 4;

            sgBufferCursor += 0x118;

            int gLevelStateEntryCount = TR2EntityCache.LevelStateEntryCounts[levelIndex];
            sgBufferCursor += gLevelStateEntryCount * 2;

            if (isNativePatch5 && !isPrepatch)
            {
                sgBufferCursor += 4;
            }

            for (int itemIndex = 0; itemIndex < levelObjectIds.Count; itemIndex++)
            {
                int objectId = levelObjectIds[itemIndex];

                if (isNativePatch5 && !isPrepatch)
                {
                    sgBufferCursor += 4;
                }

                if (!TR2EntityCache.TR2ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
                {
                    throw new Exception($"FATAL: Missing level definition for level {levelIndex}.");
                }

                if (!levelObjects.TryGetValue(objectId, out var tr2Object))
                {
                    throw new Exception($"FATAL: Missing object definition (object ID: 0x{objectId:X}).");
                }

                if (tr2Object.ObjectId == 0)
                {
                    HEALTH_OFFSET = sgBufferCursor + 0x28;
                }

                if ((tr2Object.Flags00 & 0x08) != 0)
                {
                    sgBufferCursor += 0x1A;
                }

                if ((tr2Object.Flags00 & 0x40) != 0)
                {
                    sgBufferCursor += 0x0A;
                }

                if ((tr2Object.Flags00 & 0x10) != 0)
                {
                    sgBufferCursor += 0x02;
                }

                if ((tr2Object.Flags00 & 0x20) != 0)
                {
                    int blockStart = sgBufferCursor;
                    bool has02 = (tr2Object.Flags00 & 0x02) != 0;

                    ushort u2 = BitConverter.ToUInt16(fileData, savegameOffset + blockStart + (has02 ? 4 : 2));

                    bool isEntityAIActive = has02 && (u2 & 0x0080) != 0;

                    int increment = has02 ? 0x16 : 0x14;

                    if (isEntityAIActive)
                    {
                        increment += ENTITY_AI_BLOCK_SIZE;
                    }

                    sgBufferCursor += increment;
                }

                if (objectId == 0x0D || objectId == 0x0E)
                {
                    sgBufferCursor += 0x18;
                }
                else if (objectId == 0x41)
                {
                    sgBufferCursor += 0x08;
                }
            }

            automaticPistolsAmmoOffset2 = sgBufferCursor + 0x14C;
            uziAmmoOffset2 = sgBufferCursor + 0x154;
            shotgunAmmoOffset2 = sgBufferCursor + 0x15C;
            harpoonGunAmmoOffset2 = sgBufferCursor + 0x164;
            grenadeLauncherAmmoOffset2 = sgBufferCursor + 0x16C;
            m16AmmoOffset2 = sgBufferCursor + 0x17C;
        }

        public void DisplayGameInfo(byte[] fileData, CheckBox chkPistols, CheckBox chkAutomaticPistols, CheckBox chkUzis,
            CheckBox chkM16, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudSaveNumber,
            NumericUpDown nudAutomaticPistolsAmmo, CheckBox chkShotgun, NumericUpDown nudUziAmmo,
            NumericUpDown nudM16Ammo, NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudHarpoonGunAmmo,
            NumericUpDown nudShotgunAmmo, NumericUpDown nudFlares, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, TrackBar trbHealth, Label lblHealth, Label lblHealthError)
        {
            DetermineOffsets(fileData);
            DetermineDynamicOffsets(fileData);

            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);

            MAX_HEALTH_VALUE = (isChallengeMode && !isPrepatch) ? GetChallengeModeMaxHealth(fileData) : MAX_HEALTH_VALUE_DEFAULT;
            trbHealth.Maximum = MAX_HEALTH_VALUE;

            nudSaveNumber.Value = GetSaveNumber(fileData);
            nudSmallMedipacks.Value = GetNumSmallMedipacks(fileData);
            nudLargeMedipacks.Value = GetNumLargeMedipacks(fileData);
            nudFlares.Value = GetNumFlares(fileData);

            byte levelIndex = GetLevelIndex(fileData);

            if (levelIndex == 18)       // Home Sweet Home
            {
                nudAutomaticPistolsAmmo.Value = 0;
                nudUziAmmo.Value = 0;
                nudM16Ammo.Value = 0;
                nudGrenadeLauncherAmmo.Value = 0;
                nudHarpoonGunAmmo.Value = 0;
            }
            else if (levelIndex == 23)  // Nightmare in Vegas
            {
                nudAutomaticPistolsAmmo.Value = GetAutomaticPistolsAmmo(fileData);
                nudUziAmmo.Value = GetUziAmmo(fileData);
                nudM16Ammo.Value = 0;
                nudGrenadeLauncherAmmo.Value = 0;
                nudHarpoonGunAmmo.Value = 0;
            }
            else
            {
                nudAutomaticPistolsAmmo.Value = GetAutomaticPistolsAmmo(fileData);
                nudUziAmmo.Value = GetUziAmmo(fileData);
                nudM16Ammo.Value = GetM16Ammo(fileData);
                nudGrenadeLauncherAmmo.Value = GetGrenadeLauncherAmmo(fileData);
                nudHarpoonGunAmmo.Value = GetHarpoonGunAmmo(fileData);
            }

            nudShotgunAmmo.Value = GetShotgunAmmo(fileData);

            byte weaponsConfigNum = GetWeaponsConfigNum(fileData);

            if (weaponsConfigNum == 1)
            {
                chkPistols.Checked = false;
                chkAutomaticPistols.Checked = false;
                chkUzis.Checked = false;
                chkShotgun.Checked = false;
                chkM16.Checked = false;
                chkGrenadeLauncher.Checked = false;
                chkHarpoonGun.Checked = false;
            }
            else
            {
                chkPistols.Checked = (weaponsConfigNum & WEAPON_PISTOLS) != 0;
                chkAutomaticPistols.Checked = (weaponsConfigNum & WEAPON_AUTOMATIC_PISTOLS) != 0;
                chkUzis.Checked = (weaponsConfigNum & WEAPON_UZIS) != 0;
                chkShotgun.Checked = (weaponsConfigNum & WEAPON_SHOTGUN) != 0;
                chkM16.Checked = (weaponsConfigNum & WEAPON_M16) != 0;
                chkGrenadeLauncher.Checked = (weaponsConfigNum & WEAPON_GRENADE_LAUNCHER) != 0;
                chkHarpoonGun.Checked = (weaponsConfigNum & WEAPON_HARPOON_GUN) != 0;
            }

            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                UInt16 health = GetHealthValue(fileData, healthOffset);
                double healthPercentage = ((double)health / MAX_HEALTH_VALUE) * 100;
                trbHealth.Value = health;
                trbHealth.Enabled = true;
                lblHealth.Text = healthPercentage.ToString("0.0") + "%";
                lblHealthError.Visible = false;
                lblHealth.Visible = true;
            }
            else
            {
                trbHealth.Enabled = false;
                trbHealth.Value = trbHealth.Minimum;
                lblHealthError.Visible = true;
                lblHealth.Visible = false;
            }
        }

        public void WriteChanges(byte[] fileData, CheckBox chkPistols, CheckBox chkAutomaticPistols, CheckBox chkUzis, CheckBox chkShotgun,
            CheckBox chkM16, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudSaveNumber, NumericUpDown nudFlares,
            NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks, NumericUpDown nudAutomaticPistolsAmmo,
            NumericUpDown nudUziAmmo, NumericUpDown nudM16Ammo, NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudHarpoonGunAmmo,
            NumericUpDown nudShotgunAmmo, TrackBar trbHealth)
        {
            DetermineOffsets(fileData);
            DetermineDynamicOffsets(fileData);

            WriteSaveNumber(fileData, (Int32)nudSaveNumber.Value);
            WriteNumSmallMedipacks(fileData, (byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks(fileData, (byte)nudLargeMedipacks.Value);
            WriteNumFlares(fileData, (byte)nudFlares.Value);

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += WEAPON_PISTOLS;
            if (chkAutomaticPistols.Checked) newWeaponsConfigNum += WEAPON_AUTOMATIC_PISTOLS;
            if (chkUzis.Checked) newWeaponsConfigNum += WEAPON_UZIS;
            if (chkShotgun.Checked) newWeaponsConfigNum += WEAPON_SHOTGUN;
            if (chkM16.Checked) newWeaponsConfigNum += WEAPON_M16;
            if (chkGrenadeLauncher.Checked) newWeaponsConfigNum += WEAPON_GRENADE_LAUNCHER;
            if (chkHarpoonGun.Checked) newWeaponsConfigNum += WEAPON_HARPOON_GUN;

            WriteWeaponsConfigNum(fileData, newWeaponsConfigNum);

            byte levelIndex = GetLevelIndex(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            int entityBlockStart = GetEntityBlockStart(isPrepatch);

            AMMO_WRITE_LOWER_BOUND = entityBlockStart;
            AMMO_WRITE_UPPER_BOUND = SAVEGAME_SIZE - 4;

            if (levelIndex == 18)       // Home Sweet Home
            {
                WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6), isPrepatch);
            }
            else if (levelIndex == 23)  // Nightmare in Vegas
            {
                WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6), isPrepatch);
                WriteAutomaticPistolsAmmo(fileData, chkAutomaticPistols.Checked, (UInt16)nudAutomaticPistolsAmmo.Value, isPrepatch);
                WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value, isPrepatch);
            }
            else
            {
                WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6), isPrepatch);
                WriteAutomaticPistolsAmmo(fileData, chkAutomaticPistols.Checked, (UInt16)nudAutomaticPistolsAmmo.Value, isPrepatch);
                WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value, isPrepatch);
                WriteHarpoonGunAmmo(fileData, chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value, isPrepatch);
                WriteGrenadeLauncherAmmo(fileData, chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value, isPrepatch);
                WriteM16Ammo(fileData, chkM16.Checked, (UInt16)nudM16Ammo.Value, isPrepatch);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (UInt16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
        }

        public void SetPlatform(Platform platform)
        {
            this.platform = platform;
        }

        public void SetSavegamePath(string path)
        {
            savegamePath = path;
        }

        public void SetSavegameOffset(int offset)
        {
            savegameOffset = offset;
        }

        public bool IsSavegamePresent(byte[] fileData)
        {
            return fileData[savegameOffset + SLOT_STATUS_OFFSET] != 0;
        }

        public void UpdateDisplayName(Savegame savegame, byte[] fileData)
        {
            bool savegamePresent = fileData[savegame.Offset + SLOT_STATUS_OFFSET] != 0;

            if (savegamePresent)
            {
                byte levelIndex = fileData[savegame.Offset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, savegame.Offset + SAVE_NUMBER_OFFSET);

                if (levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    bool isPrepatch = IsPrepatchSavegameFile(fileData);
                    string levelName = levelNames[levelIndex];
                    GameMode gameMode = fileData[savegame.Offset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                    bool isChallengeMode = fileData[savegame.Offset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    savegame.UpdateDisplayName(levelName, saveNumber, gameMode, isChallengeMode);
                }
            }
        }

        public void PopulateEmptySlots(ComboBox cmbSavegames)
        {
            if (cmbSavegames.Items.Count == MAX_SAVEGAMES)
            {
                return;
            }

            byte[] fileData = File.ReadAllBytes(savegamePath);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR2 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR2)
                {
                    byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);

                    bool savegamePresent = slotStatus != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR2) / SAVEGAME_SIZE;

                        bool savegameExists = false;

                        foreach (Savegame existingSavegame in cmbSavegames.Items)
                        {
                            if (existingSavegame.Slot == slot)
                            {
                                savegameExists = true;
                                break;
                            }
                        }

                        if (!savegameExists)
                        {
                            string levelName = levelNames[levelIndex];
                            GameMode gameMode = fileData[currentSavegameOffset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                            bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, false, isChallengeMode);
                            cmbSavegames.Items.Add(savegame);
                        }
                    }
                }
            }
        }

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            byte[] fileData = File.ReadAllBytes(savegamePath);
            int numSavegames = 0;

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR2 = BASE_SAVEGAME_OFFSET_TR2_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR2 = MAX_SAVEGAME_OFFSET_TR2_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR2 = BASE_SAVEGAME_OFFSET_TR2_PATCH5;
                MAX_SAVEGAME_OFFSET_TR2 = MAX_SAVEGAME_OFFSET_TR2_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;

                if (platform == Platform.PC)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PC;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PC;
                }
                else if (platform == Platform.Android)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_ANDROID;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_ANDROID;
                }
                else if (platform == Platform.PlayStation4)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PS4;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PS4;
                }
            }

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR2 + (i * SAVEGAME_SIZE);

                byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool savegamePresent = slotStatus != 0;

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR2) / SAVEGAME_SIZE;
                    GameMode gameMode = fileData[currentSavegameOffset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                    bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, false, isChallengeMode);
                    cmbSavegames.Items.Add(savegame);

                    numSavegames++;
                }
            }

            if (numSavegames > 0)
            {
                cmbSavegames.SelectedIndex = 0;
            }
        }
    }
}
