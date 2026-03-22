using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR1Utilities
    {
        // Savegame constants & offsets
        private const int SAVEGAME_VERSION_OFFSET = 0x000;
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;
        private const int LEVEL_INDEX_OFFSET = 0x62C;
        private const int CHALLENGE_MODE_OFFSET = 0x6EC;
        private const int CHALLENGE_MODE_HEALTH_HANDICAP_OFFSET = 0x6F6;
        private const int CHALLENGE_MODE_ENEMY_COUNT_OFFSET = 0x6FA;
        private const byte CHALLENGE_MODE_ENEMY_NUMBERS_REINFORCEMENT = 4;
        private const int MAX_SAVEGAMES = 32;

        // Patch-dependent
        private int BASE_SAVEGAME_OFFSET_TR1;
        private int MAX_SAVEGAME_OFFSET_TR1;
        private int SAVEGAME_SIZE;
        private const int SAVEGAME_SIZE_PREPATCH = 0x3800;
        private const int SAVEGAME_SIZE_PATCH5 = 0x6800;
        private const int BASE_SAVEGAME_OFFSET_TR1_PREPATCH = 0x2000;
        private const int BASE_SAVEGAME_OFFSET_TR1_PATCH5 = 0x2000;
        private const int MAX_SAVEGAME_OFFSET_TR1_PREPATCH = 0x72000;
        private const int MAX_SAVEGAME_OFFSET_TR1_PATCH5 = 0xCB800;

        // Patch-related signatures
        private const byte PATCH5_SIGNATURE = 0x3C;
        private const int PATCH5_SHIFT = 0x13;

        // Static offsets
        private const int MAGNUM_AMMO_OFFSET = 0x4C2;
        private const int UZI_AMMO_OFFSET = 0x4C4;
        private const int SHOTGUN_AMMO_OFFSET = 0x4C6;
        private const int SMALL_MEDIPACK_OFFSET = 0x4C8;
        private const int LARGE_MEDIPACK_OFFSET = 0x4C9;
        private const int WEAPONS_CONFIG_NUM_OFFSET = 0x4EC;

        // Dynamic offsets
        private int uziAmmoOffset2;
        private int shotgunAmmoOffset2;
        private int magnumAmmoOffset2;

        // Weapon byte flags
        private const byte WEAPON_PISTOLS = 2;
        private const byte WEAPON_MAGNUMS = 4;
        private const byte WEAPON_UZIS = 8;
        private const byte WEAPON_SHOTGUN = 16;

        // Health
        private const UInt16 MAX_HEALTH_VALUE_DEFAULT = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private UInt16 MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
        private int HEALTH_OFFSET = -1;
        private int MAX_HEALTH_OFFSET;
        private int MIN_HEALTH_OFFSET;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private int secondaryAmmoIndex = -1;
        private bool usingConvertedLayout = false;
        private const int MAX_ENTITY_COUNT = 50;
        private const int ENTITY_STRIDE = 0xC;

        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
        {
            { 1,  "Caves"                   },
            { 2,  "City of Vilcabamba"      },
            { 3,  "Lost Valley"             },
            { 4,  "Tomb of Qualopec"        },
            { 5,  "St. Francis' Folly"      },
            { 6,  "Colosseum"               },
            { 7,  "Palace Midas"            },
            { 8,  "The Cistern"             },
            { 9,  "Tomb of Tihocan"         },
            { 10, "City of Khamoon"         },
            { 11, "Obelisk of Khamoon"      },
            { 12, "Sanctuary of the Scion"  },
            { 13, "Natla's Mines"           },
            { 14, "Atlantis"                },
            { 15, "The Great Pyramid"       },
            { 16, "Return to Egypt"         },
            { 17, "Temple of the Cat"       },
            { 18, "Atlantean Stronghold"    },
            { 19, "The Hive"                },
        };

        private readonly Dictionary<byte, int[]> ammoIndexDataPC = new Dictionary<byte, int[]>
        {
            {  1, new int[] { 0x1130, 0x1131, 0x1132, 0x1133 } },   // Caves
            {  2, new int[] { 0x1A58, 0x1A59, 0x1A5A, 0x1A5B } },   // City of Vilcabamba
            {  3, new int[] { 0x121A, 0x121B, 0x121C, 0x121D } },   // Lost Valley
            {  4, new int[] { 0x143A, 0x143B, 0x143C, 0x143D } },   // Tomb of Qualopec
            {  5, new int[] { 0x1EE0, 0x1EE1, 0x1EE2, 0x1EE3 } },   // St. Francis' Folly
            {  6, new int[] { 0x1806, 0x1807, 0x1808, 0x1809 } },   // Colosseum
            {  7, new int[] { 0x1F04, 0x1F05, 0x1F06, 0x1F07 } },   // Palace Midas
            {  8, new int[] { 0x1E34, 0x1E35, 0x1E36, 0x1E37 } },   // The Cistern
            {  9, new int[] { 0x18D2, 0x18D3, 0x18D4, 0x18D5 } },   // Tomb of Tihocan
            { 10, new int[] { 0x1792, 0x1793, 0x1794, 0x1795 } },   // City of Khamoon
            { 11, new int[] { 0x171E, 0x171F, 0x1720, 0x1721 } },   // Obelisk of Khamoon
            { 12, new int[] { 0x13C6, 0x13C7, 0x13C8, 0x13C9 } },   // Sanctuary of the Scion
            { 13, new int[] { 0x171C, 0x171D, 0x171E, 0x171F } },   // Natla's Mines
            { 14, new int[] { 0x2866, 0x2867, 0x2868, 0x2869 } },   // Atlantis
            { 15, new int[] { 0x1A6C, 0x1A6D, 0x1A6E, 0x1A6F } },   // The Great Pyramid
            { 16, new int[] { 0x2318, 0x2319, 0x231A, 0x231B } },   // Return to Egypt
            { 17, new int[] { 0x2988, 0x2989, 0x298A, 0x298B } },   // Temple of the Cat
            { 18, new int[] { 0x2266, 0x2267, 0x2268, 0x2269 } },   // Atlantean Stronghold
            { 19, new int[] { 0x2B02, 0x2B03, 0x2B04, 0x2B05 } },   // The Hive
        };

        private readonly Dictionary<byte, int[]> ammoIndexDataConvertedPC = new Dictionary<byte, int[]>
        {
            {  1, new int[] { 0x1138, 0x1139, 0x113A, 0x113B } },   // Caves
            {  3, new int[] { 0x1116, 0x1117, 0x1118, 0x1119 } },   // Lost Valley
            {  5, new int[] { 0x1D14, 0x1D15, 0x1D16, 0x1D17 } },   // St. Francis' Folly
            {  7, new int[] { 0x1CE0, 0x1CE1, 0x1CE2, 0x1CE3 } },   // Palace Midas
            {  8, new int[] { 0x1C4C, 0x1C4D, 0x1C4E, 0x1C4F } },   // The Cistern
            {  9, new int[] { 0x174E, 0x174F, 0x1750, 0x1751 } },   // Tomb of Tihocan
            { 10, new int[] { 0x1616, 0x1617, 0x1618, 0x1619 } },   // City of Khamoon
            { 15, new int[] { 0x1860, 0x1861, 0x1862, 0x1863 } },   // The Great Pyramid
            { 16, new int[] { 0x1FCC, 0x1FCD, 0x1FCE, 0x1FCF } },   // Return to Egypt
            { 17, new int[] { 0x2668, 0x2669, 0x266A, 0x266B } },   // Temple of the Cat
            { 18, new int[] { 0x1F9A, 0x1F9B, 0x1F9C, 0x1F9D } },   // Atlantean Stronghold
            { 19, new int[] { 0x27E2, 0x27E3, 0x27E4, 0x27E5 } },   // The Hive
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

        public int GetHealthOffset(byte[] fileData)
        {
            bool isPatch5 = IsPatch5Savegame(fileData);

            UInt16 value;

            if (!isPatch5)
            {
                if (HEALTH_OFFSET != -1)
                {
                    value = BitConverter.ToUInt16(fileData, savegameOffset + HEALTH_OFFSET);

                    if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
                    {
                        return savegameOffset + HEALTH_OFFSET;
                    }
                }

                return -1;
            }
            else
            {
                byte[] savegameData = fileData;

                bool isChallengeMode = IsChallengeMode(savegameData);
                MAX_HEALTH_VALUE = isChallengeMode ? GetChallengeModeMaxHealth(savegameData) : MAX_HEALTH_VALUE_DEFAULT;

                for (int offset = MIN_HEALTH_OFFSET; offset <= MAX_HEALTH_OFFSET; offset++)
                {
                    int valueIndex = savegameOffset + offset;

                    if (valueIndex + 2 >= savegameData.Length)
                    {
                        break;
                    }

                    value = BitConverter.ToUInt16(savegameData, valueIndex);

                    if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
                    {
                        int flagIndex1 = savegameOffset + offset - 10;
                        int flagIndex2 = savegameOffset + offset - 9;
                        int flagIndex3 = savegameOffset + offset - 8;
                        int flagIndex4 = savegameOffset + offset - 7;

                        if (flagIndex4 >= savegameData.Length)
                        {
                            continue;
                        }

                        byte byteFlag1 = savegameData[flagIndex1];
                        byte byteFlag2 = savegameData[flagIndex2];
                        byte byteFlag3 = savegameData[flagIndex3];
                        byte byteFlag4 = savegameData[flagIndex4];

                        if (IsKnownByteFlagPattern(byteFlag1, byteFlag2, byteFlag3, byteFlag4))
                        {
                            return savegameOffset + offset;
                        }
                    }
                }

                return -1;
            }
        }

        public void DetermineOffsets(byte[] fileData)
        {
            bool isPatch5 = IsPatch5Savegame(fileData);

            if (isPatch5)
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PATCH5;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
            }

            byte levelIndex = GetLevelIndex(fileData);

            if (levelIndex == 1)        // Caves
            {
                HEALTH_OFFSET = 0x825;
                magnumAmmoOffset2 = 0x1079;
                uziAmmoOffset2 = 0x1081;
                shotgunAmmoOffset2 = 0x1089;
            }
            else if (levelIndex == 2)   // City of Vilacamba
            {
                HEALTH_OFFSET = 0x181D;
                magnumAmmoOffset2 = 0x1999;
                uziAmmoOffset2 = 0x19A1;
                shotgunAmmoOffset2 = 0x19A9;
            }
            else if (levelIndex == 3)   // Lost Valley
            {
                HEALTH_OFFSET = 0x82D;
                magnumAmmoOffset2 = 0x1057;
                uziAmmoOffset2 = 0x105F;
                shotgunAmmoOffset2 = 0x1067;
            }
            else if (levelIndex == 4)   // Tomb of Qualopec
            {
                HEALTH_OFFSET = 0xC41;
                magnumAmmoOffset2 = 0x137B;
                uziAmmoOffset2 = 0x1383;
                shotgunAmmoOffset2 = 0x138B;
            }
            else if (levelIndex == 5)   // St. Francis' Folly
            {
                HEALTH_OFFSET = 0x1A39;
                magnumAmmoOffset2 = 0x1C55;
                uziAmmoOffset2 = 0x1C5D;
                shotgunAmmoOffset2 = 0x1C65;
            }
            else if (levelIndex == 6)   // Colosseum
            {
                HEALTH_OFFSET = 0xF4F;
                magnumAmmoOffset2 = 0x1747;
                uziAmmoOffset2 = 0x174F;
                shotgunAmmoOffset2 = 0x1757;
            }
            else if (levelIndex == 7)   // Palace Midas
            {
                HEALTH_OFFSET = 0x82F;
                magnumAmmoOffset2 = 0x1C21;
                uziAmmoOffset2 = 0x1C29;
                shotgunAmmoOffset2 = 0x1C31;
            }
            else if (levelIndex == 8)   // The Cistern
            {
                HEALTH_OFFSET = 0x197B;
                magnumAmmoOffset2 = 0x1B8D;
                uziAmmoOffset2 = 0x1B95;
                shotgunAmmoOffset2 = 0x1B9D;
            }
            else if (levelIndex == 9)   // Tomb of Tihocan
            {
                HEALTH_OFFSET = 0xA29;
                magnumAmmoOffset2 = 0x168F;
                uziAmmoOffset2 = 0x1697;
                shotgunAmmoOffset2 = 0x169F;
            }
            else if (levelIndex == 10)  // City of Khamoon
            {
                HEALTH_OFFSET = 0x827;
                magnumAmmoOffset2 = 0x1557;
                uziAmmoOffset2 = 0x155F;
                shotgunAmmoOffset2 = 0x1567;
            }
            else if (levelIndex == 11)  // Obelisk of Khamoon
            {
                HEALTH_OFFSET = 0xA8F;
                magnumAmmoOffset2 = 0x165F;
                uziAmmoOffset2 = 0x1667;
                shotgunAmmoOffset2 = 0x166F;
            }
            else if (levelIndex == 12)  // Sanctuary of the Scion
            {
                HEALTH_OFFSET = 0x114F;
                magnumAmmoOffset2 = 0x1307;
                uziAmmoOffset2 = 0x130F;
                shotgunAmmoOffset2 = 0x1317;
            }
            else if (levelIndex == 13)  // Natla's Mines
            {
                HEALTH_OFFSET = 0x12D3;
                magnumAmmoOffset2 = 0x165D;
                uziAmmoOffset2 = 0x1665;
                shotgunAmmoOffset2 = 0x166D;
            }
            else if (levelIndex == 14)  // Atlantis
            {
                HEALTH_OFFSET = 0xD0F;
                magnumAmmoOffset2 = 0x245B;
                uziAmmoOffset2 = 0x2463;
                shotgunAmmoOffset2 = 0x246B;
            }
            else if (levelIndex == 15)  // The Great Pyramid
            {
                HEALTH_OFFSET = 0x10FD;
                magnumAmmoOffset2 = 0x17A1;
                uziAmmoOffset2 = 0x17A9;
                shotgunAmmoOffset2 = 0x17B1;
            }
            else if (levelIndex == 16)   // Return to Egypt
            {
                HEALTH_OFFSET = 0x8F3;
                magnumAmmoOffset2 = 0x1F0D;
                uziAmmoOffset2 = 0x1F15;
                shotgunAmmoOffset2 = 0x1F1D;
            }
            else if (levelIndex == 17)   // Temple of the Cat
            {
                HEALTH_OFFSET = 0xE1D;
                magnumAmmoOffset2 = 0x25A9;
                uziAmmoOffset2 = 0x25B1;
                shotgunAmmoOffset2 = 0x25B9;
            }
            else if (levelIndex == 18)  // Atlantean Stronghold
            {
                HEALTH_OFFSET = 0xE35;
                magnumAmmoOffset2 = 0x1EDB;
                uziAmmoOffset2 = 0x1EE3;
                shotgunAmmoOffset2 = 0x1EEB;
            }
            else if (levelIndex == 19)  // The Hive
            {
                HEALTH_OFFSET = 0x10DF;
                magnumAmmoOffset2 = 0x2723;
                uziAmmoOffset2 = 0x272B;
                shotgunAmmoOffset2 = 0x2733;
            }

            if (isPatch5)
            {
                MIN_HEALTH_OFFSET = HEALTH_OFFSET + PATCH5_SHIFT;
                MAX_HEALTH_OFFSET = HEALTH_OFFSET + PATCH5_SHIFT * MAX_ENTITY_COUNT;
            }

            if (platform != Platform.PC)
            {
                HEALTH_OFFSET -= 4;
                MIN_HEALTH_OFFSET -= 4;
                MAX_HEALTH_OFFSET -= 4;

                magnumAmmoOffset2 -= 4;
                uziAmmoOffset2 -= 4;
                shotgunAmmoOffset2 -= 4;
            }
        }

        private bool IsPatch5Savegame(byte[] fileData)
        {
            return fileData[SAVEGAME_VERSION_OFFSET] >= PATCH5_SIGNATURE;
        }

        private GameMode GetGameMode(byte[] fileData)
        {
            byte gameMode = fileData[savegameOffset + GAME_MODE_OFFSET];
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
        }

        public bool IsChallengeMode(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_OFFSET] == 1;
        }

        public UInt16 GetChallengeModeMaxHealth(byte[] fileData)
        {
            byte maxHealthSetting = fileData[savegameOffset + CHALLENGE_MODE_HEALTH_HANDICAP_OFFSET];

            if (maxHealthSetting == 0) return (UInt16)100;
            if (maxHealthSetting == 1) return (UInt16)250;
            if (maxHealthSetting == 2) return (UInt16)500;
            if (maxHealthSetting == 3) return (UInt16)1000;
            if (maxHealthSetting == 4) return (UInt16)1500;
            if (maxHealthSetting == 5) return (UInt16)1750;
            if (maxHealthSetting == 6) return (UInt16)2000;
            if (maxHealthSetting == 7) return (UInt16)5000;

            return (UInt16)1000;
        }

        private byte GetChallengeModeEnemyNumbers(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_COUNT_OFFSET];
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

        private byte GetWeaponsConfigNum(byte[] fileData)
        {
            return fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET];
        }

        private UInt16 GetShotgunAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET) / 6);
        }

        private UInt16 GetMagnumAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + MAGNUM_AMMO_OFFSET);
        }

        private UInt16 GetUziAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + UZI_AMMO_OFFSET);
        }

        private UInt16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            return BitConverter.ToUInt16(fileData, healthOffset);
        }

        private int GetSecondaryAmmoOffset(int baseOffset)
        {
            return baseOffset + (secondaryAmmoIndex * ENTITY_STRIDE);
        }

        private int GetSecondaryAmmoIndex(byte[] fileData)
        {
            byte levelIndex = GetLevelIndex(fileData);

            Dictionary<byte, int[]> ammoIndexData = ammoIndexDataPC;

            if (ammoIndexData.ContainsKey(levelIndex))
            {
                int[] indexData = ammoIndexData[levelIndex];

                int[] offsets1 = new int[indexData.Length];
                int[] offsets2 = new int[indexData.Length];

                for (int index = 0; index < MAX_ENTITY_COUNT; index++)
                {
                    Array.Copy(indexData, offsets1, indexData.Length);

                    for (int i = 0; i < indexData.Length; i++)
                    {
                        offsets2[i] = offsets1[i] + 0xA;

                        offsets1[i] += savegameOffset + (index * ENTITY_STRIDE);
                        offsets2[i] += savegameOffset + (index * ENTITY_STRIDE);
                    }

                    if (offsets1.All(offset => fileData[offset] == 0xFF))
                    {
                        usingConvertedLayout = false;
                        return index;
                    }

                    if (offsets2.All(offset => fileData[offset] == 0xFF))
                    {
                        usingConvertedLayout = false;
                        return index;
                    }
                }

                // Hardcoded exceptions for converted pre-patch savegames
                if (levelIndex == 1 || levelIndex == 3 || levelIndex == 5 ||
                    levelIndex == 7 || levelIndex == 8 || levelIndex == 9 ||
                    levelIndex == 10 || levelIndex == 15 || levelIndex == 16 ||
                    levelIndex == 17 || levelIndex == 18 || levelIndex == 19)
                {
                    ammoIndexData = ammoIndexDataConvertedPC;

                    if (ammoIndexData.ContainsKey(levelIndex))
                    {
                        indexData = ammoIndexData[levelIndex];

                        int[] offsets = new int[indexData.Length];

                        Array.Copy(indexData, offsets, indexData.Length);

                        for (int i = 0; i < offsets.Length; i++)
                        {
                            offsets[i] += savegameOffset;
                        }

                        if (offsets.All(offset => fileData[offset] == 0xFF))
                        {
                            usingConvertedLayout = true;
                            return 0;
                        }
                    }
                }
            }

            return -1;
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

        private void WriteWeaponsConfigNum(byte[] fileData, byte value)
        {
            fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET] = value;
        }

        private void WriteHealthValue(byte[] fileData, UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset(fileData);

            if (healthOffset != -1)
            {
                WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPatch5)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            if (isPatch5 && secondaryAmmoIndex == -1)
            {
                return;
            }

            bool isChallengeMode = IsChallengeMode(fileData);
            bool isHighEnemyCount = GetChallengeModeEnemyNumbers(fileData) >= CHALLENGE_MODE_ENEMY_NUMBERS_REINFORCEMENT;

            if (isPatch5 && isChallengeMode && isHighEnemyCount)
            {
                return;
            }

            if (isPresent)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteMagnumAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPatch5)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + MAGNUM_AMMO_OFFSET, ammo);

            if (isPatch5 && secondaryAmmoIndex == -1)
            {
                return;
            }

            bool isChallengeMode = IsChallengeMode(fileData);
            bool isHighEnemyCount = GetChallengeModeEnemyNumbers(fileData) >= CHALLENGE_MODE_ENEMY_NUMBERS_REINFORCEMENT;

            if (isPatch5 && isChallengeMode && isHighEnemyCount)
            {
                return;
            }

            if (isPresent)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + magnumAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + magnumAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPatch5)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);

            if (isPatch5 && secondaryAmmoIndex == -1)
            {
                return;
            }

            bool isChallengeMode = IsChallengeMode(fileData);
            bool isHighEnemyCount = GetChallengeModeEnemyNumbers(fileData) >= CHALLENGE_MODE_ENEMY_NUMBERS_REINFORCEMENT;

            if (isPatch5 && isChallengeMode && isHighEnemyCount)
            {
                return;
            }

            if (isPresent)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + uziAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private bool IsKnownByteFlagPattern(byte byteFlag1, byte byteFlag2, byte byteFlag3, byte byteFlag4)
        {
            if (byteFlag1 == 0x02 && byteFlag2 == 0x00 && byteFlag3 == 0x02 && byteFlag4 == 0x00) return true;  // Standing
            if (byteFlag1 == 0x13 && byteFlag2 == 0x00 && byteFlag3 == 0x13 && byteFlag4 == 0x00) return true;  // Climbing
            if (byteFlag1 == 0x21 && byteFlag2 == 0x00 && byteFlag3 == 0x21 && byteFlag4 == 0x00) return true;  // On water
            if (byteFlag1 == 0x0D && byteFlag2 == 0x00 && byteFlag3 == 0x0D && byteFlag4 == 0x00) return true;  // Underwater
            if (byteFlag1 == 0x12 && byteFlag2 == 0x00 && byteFlag3 == 0x12 && byteFlag4 == 0x00) return true;  // Swimming
            if (byteFlag1 == 0x17 && byteFlag2 == 0x00 && byteFlag3 == 0x02 && byteFlag4 == 0x00) return true;  // Rolling
            if (byteFlag1 == 0x41 && byteFlag2 == 0x00 && byteFlag3 == 0x02 && byteFlag4 == 0x00) return true;  // Walking through water
            if (byteFlag1 == 0x22 && byteFlag2 == 0x00 && byteFlag3 == 0x22 && byteFlag4 == 0x00) return true;  // Wading through water
            if (byteFlag1 == 0x01 && byteFlag2 == 0x00 && byteFlag3 == 0x02 && byteFlag4 == 0x00) return true;  // Running forward
            if (byteFlag1 == 0x03 && byteFlag2 == 0x00 && byteFlag3 == 0x03 && byteFlag4 == 0x00) return true;  // Jumping forward
            if (byteFlag1 == 0x20 && byteFlag2 == 0x00 && byteFlag3 == 0x20 && byteFlag4 == 0x00) return true;  // Sliding backward
            if (byteFlag1 == 0x18 && byteFlag2 == 0x00 && byteFlag3 == 0x18 && byteFlag4 == 0x00) return true;  // Sliding downhill
            if (byteFlag1 == 0x2A && byteFlag2 == 0x00 && byteFlag3 == 0x02 && byteFlag4 == 0x00) return true;  // Using puzzle item

            return false;
        }

        public void DisplayGameInfo(byte[] fileData, CheckBox chkPistols, CheckBox chkMagnums, CheckBox chkUzis,
            CheckBox chkShotgun, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudUziAmmo, NumericUpDown nudShotgunAmmo, NumericUpDown nudMagnumAmmo,
            NumericUpDown nudSaveNumber, TrackBar trbHealth, Label lblHealth, Label lblHealthError)
        {
            DetermineOffsets(fileData);

            GameMode gameMode = GetGameMode(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);

            nudSmallMedipacks.Enabled = gameMode == GameMode.Normal;
            nudLargeMedipacks.Enabled = gameMode == GameMode.Normal;

            MAX_HEALTH_VALUE = isChallengeMode ? GetChallengeModeMaxHealth(fileData) : MAX_HEALTH_VALUE_DEFAULT;
            trbHealth.Maximum = MAX_HEALTH_VALUE;

            byte weaponsConfigNum = GetWeaponsConfigNum(fileData);

            if (weaponsConfigNum == 1)
            {
                chkPistols.Checked = false;
                chkMagnums.Checked = false;
                chkUzis.Checked = false;
                chkShotgun.Checked = false;
            }
            else
            {
                chkPistols.Checked = (weaponsConfigNum & WEAPON_PISTOLS) != 0;
                chkMagnums.Checked = (weaponsConfigNum & WEAPON_MAGNUMS) != 0;
                chkUzis.Checked = (weaponsConfigNum & WEAPON_UZIS) != 0;
                chkShotgun.Checked = (weaponsConfigNum & WEAPON_SHOTGUN) != 0;
            }

            nudSaveNumber.Value = GetSaveNumber(fileData);
            nudSmallMedipacks.Value = GetNumSmallMedipacks(fileData);
            nudLargeMedipacks.Value = GetNumLargeMedipacks(fileData);
            nudUziAmmo.Value = GetUziAmmo(fileData);
            nudMagnumAmmo.Value = GetMagnumAmmo(fileData);
            nudShotgunAmmo.Value = GetShotgunAmmo(fileData);

            int healthOffset = GetHealthOffset(fileData);

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

            bool isPatch5 = IsPatch5Savegame(fileData);
            bool isHighEnemyCount = GetChallengeModeEnemyNumbers(fileData) >= CHALLENGE_MODE_ENEMY_NUMBERS_REINFORCEMENT;

            if (isPatch5 && isChallengeMode && isHighEnemyCount)
            {
                nudUziAmmo.Enabled = false;
                nudMagnumAmmo.Enabled = false;
                nudShotgunAmmo.Enabled = false;
            }
            else
            {
                nudUziAmmo.Enabled = true;
                nudMagnumAmmo.Enabled = true;
                nudShotgunAmmo.Enabled = true;
            }
        }

        public void WriteChanges(byte[] fileData, CheckBox chkPistols, CheckBox chkMagnums, CheckBox chkUzis,
            CheckBox chkShotgun, NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, NumericUpDown nudUziAmmo, NumericUpDown nudMagnumAmmo,
            NumericUpDown nudShotgunAmmo, TrackBar trbHealth)
        {
            WriteSaveNumber(fileData, (Int32)nudSaveNumber.Value);
            WriteNumSmallMedipacks(fileData, (byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks(fileData, (byte)nudLargeMedipacks.Value);

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += WEAPON_PISTOLS;
            if (chkMagnums.Checked) newWeaponsConfigNum += WEAPON_MAGNUMS;
            if (chkUzis.Checked) newWeaponsConfigNum += WEAPON_UZIS;
            if (chkShotgun.Checked) newWeaponsConfigNum += WEAPON_SHOTGUN;

            WriteWeaponsConfigNum(fileData, newWeaponsConfigNum);

            bool isPatch5 = IsPatch5Savegame(fileData);

            if (isPatch5)
            {
                secondaryAmmoIndex = GetSecondaryAmmoIndex(fileData);
                byte levelIndex = GetLevelIndex(fileData);

                if (secondaryAmmoIndex != -1)
                {
                    Dictionary<byte, int[]> ammoIndexData = usingConvertedLayout ? ammoIndexDataConvertedPC : ammoIndexDataPC;

                    int baseSecondaryAmmoOffset = ammoIndexData[levelIndex][0];

                    uziAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0xA4);
                    magnumAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0xAC);
                    shotgunAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x9C);
                }
            }

            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value, isPatch5);
            WriteMagnumAmmo(fileData, chkMagnums.Checked, (UInt16)nudMagnumAmmo.Value, isPatch5);
            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6), isPatch5);

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (UInt16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
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
                    bool isPatch5 = IsPatch5Savegame(fileData);
                    string levelName = levelNames[levelIndex];
                    GameMode gameMode = fileData[savegame.Offset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                    bool isChallengeMode = fileData[savegame.Offset + CHALLENGE_MODE_OFFSET] == 1 && isPatch5;

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
            bool isPatch5 = IsPatch5Savegame(fileData);

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR1)
                {
                    byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool savegamePresent = slotStatus != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR1) / SAVEGAME_SIZE;
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
                            bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && isPatch5;

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
            int numSaves = 0;

            bool isPatch5 = IsPatch5Savegame(fileData);

            if (isPatch5)
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PATCH5;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
            }

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_SIZE);

                byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool savegamePresent = slotStatus != 0;

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR1) / SAVEGAME_SIZE;
                    GameMode gameMode = fileData[currentSavegameOffset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                    bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && isPatch5;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, false, isChallengeMode);
                    cmbSavegames.Items.Add(savegame);

                    numSaves++;
                }
            }

            if (numSaves > 0)
            {
                cmbSavegames.SelectedIndex = 0;
            }
        }
    }
}
