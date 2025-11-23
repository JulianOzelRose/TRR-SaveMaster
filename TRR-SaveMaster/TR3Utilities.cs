using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR3Utilities
    {
        // Savegame constants & offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;
        private const int LEVEL_INDEX_OFFSET = 0x8D6;
        private const int BASE_SAVEGAME_OFFSET_TR3 = 0xE2000;
        private const int MAX_SAVEGAME_OFFSET_TR3 = 0x152000;
        private const int SAVEGAME_SIZE = 0x3800;
        private const int MAX_SAVEGAMES = 32;

        // Static offsets (per level)
        private int SMALL_MEDIPACK_OFFSET;
        private int LARGE_MEDIPACK_OFFSET;
        private int FLARES_OFFSET;
        private int WEAPONS_CONFIG_NUM_OFFSET;
        private int COLLECTIBLE_CRYSTALS_OFFSET;
        private int HARPOON_GUN_OFFSET;
        private int DEAGLE_AMMO_OFFSET;
        private int HARPOON_GUN_AMMO_OFFSET;
        private int MP5_AMMO_OFFSET;
        private int UZI_AMMO_OFFSET;
        private int ROCKET_LAUNCHER_AMMO_OFFSET;
        private int GRENADE_LAUNCHER_AMMO_OFFSET;
        private int SHOTGUN_AMMO_OFFSET;

        // Dynamic offsets
        private int harpoonGunAmmoOffset2;
        private int deagleAmmoOffset2;
        private int mp5AmmoOffset2;
        private int uziAmmoOffset2;
        private int rocketLauncherAmmoOffset2;
        private int grenadeLauncherAmmoOffset2;
        private int shotgunAmmoOffset2;

        // Weapon byte flags
        private const byte WEAPON_PISTOLS = 2;
        private const byte WEAPON_DEAGLE = 4;
        private const byte WEAPON_UZIS = 8;
        private const byte WEAPON_SHOTGUN = 16;
        private const byte WEAPON_MP5 = 32;
        private const byte WEAPON_ROCKET_LAUNCHER = 64;
        private const byte WEAPON_GRENADE_LAUNCHER = 128;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private int MAX_HEALTH_OFFSET;
        private int MIN_HEALTH_OFFSET;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private int secondaryAmmoIndex = -1;
        private const int MAX_ENTITY_COUNT = 20;

        // Level names
        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
        {
            {  1, "Jungle"                      },
            {  2, "Temple Ruins"                },
            {  3, "The River Ganges"            },
            {  4, "Caves of Kaliya"             },
            {  5, "Coastal Village"             },
            {  6, "Crash Site"                  },
            {  7, "Madubu Gorge"                },
            {  8, "Temple of Puna"              },
            {  9, "Thames Wharf"                },
            { 10, "Aldwych"                     },
            { 11, "Lud's Gate"                  },
            { 12, "City"                        },
            { 13, "Nevada Desert"               },
            { 14, "High Security Compound"      },
            { 15, "Area 51"                     },
            { 16, "Antarctica"                  },
            { 17, "RX-Tech Mines"               },
            { 18, "Lost City of Tinnos"         },
            { 19, "Meteorite Cavern"            },
            { 20, "All Hallows"                 },
            { 21, "Highland Fling"              },
            { 22, "Willard's Lair"              },
            { 23, "Shakespeare Cliff"           },
            { 24, "Sleeping with the Fishes"    },
            { 25, "It's a Madhouse!"            },
            { 26, "Reunion"                     },
        };

        // Ammo index data (PC)
        private readonly Dictionary<byte, int[]> ammoIndexDataPC = new Dictionary<byte, int[]>()
        {
            {  1, new int[] { 0x1F86, 0x1F87, 0x1F88, 0x1F89 } },   // Jungle
            {  2, new int[] { 0x3114, 0x3115, 0x3116, 0x3117 } },   // Temple Ruins
            {  3, new int[] { 0x21FE, 0x21FF, 0x2200, 0x2201 } },   // The River Ganges
            {  4, new int[] { 0x13C6, 0x13C7, 0x13C8, 0x13C9 } },   // Caves of Kaliya
            {  5, new int[] { 0x2294, 0x2295, 0x2296, 0x2297 } },   // Coastal Village
            {  6, new int[] { 0x22D6, 0x22D7, 0x22D8, 0x22D9 } },   // Crash Site
            {  7, new int[] { 0x1DFE, 0x1DFF, 0x1E00, 0x1E01 } },   // Madubu Gorge
            {  8, new int[] { 0x18BC, 0x18BD, 0x18BE, 0x18BF } },   // Temple of Puna
            {  9, new int[] { 0x2282, 0x2283, 0x2284, 0x2285 } },   // Thames Wharf
            { 10, new int[] { 0x2FCA, 0x2FCB, 0x2FCC, 0x2FCD } },   // Aldwych
            { 11, new int[] { 0x289C, 0x289D, 0x289E, 0x289F } },   // Lud's Gate
            { 12, new int[] { 0x1196, 0x1197, 0x1198, 0x1199 } },   // City
            { 13, new int[] { 0x21D2, 0x21D3, 0x21D4, 0x21D5 } },   // Nevada Desert
            { 14, new int[] { 0x2A8A, 0x2A8B, 0x2A8C, 0x2A8D } },   // High Security Compound
            { 15, new int[] { 0x2D5C, 0x2D5D, 0x2D5E, 0x2D5F } },   // Area 51
            { 16, new int[] { 0x23CC, 0x23CD, 0x23CE, 0x23CF } },   // Antarctica
            { 17, new int[] { 0x2414, 0x2415, 0x2416, 0x2417 } },   // RX-Tech Mines
            { 18, new int[] { 0x29A0, 0x29A1, 0x29A2, 0x29A3 } },   // Lost City of Tinnos
            { 19, new int[] { 0x1146, 0x1147, 0x1148, 0x1149 } },   // Meteorite Cavern
            { 20, new int[] { 0x1822, 0x1823, 0x1824, 0x1825 } },   // All Hallows
            { 21, new int[] { 0x21AE, 0x21AF, 0x21B0, 0x21B1 } },   // Highland Fling
            { 22, new int[] { 0x2532, 0x2533, 0x2534, 0x2535 } },   // Willard's Lair
            { 23, new int[] { 0x25D0, 0x25D1, 0x25D2, 0x25D3 } },   // Shakespeare Cliff
            { 24, new int[] { 0x23D2, 0x23D3, 0x23D4, 0x23D5 } },   // Sleeping with the Fishes
            { 25, new int[] { 0x2030, 0x2031, 0x2032, 0x2033 } },   // It's a Madhouse!
            { 26, new int[] { 0x1A40, 0x1A41, 0x1A42, 0x1A43 } },   // Reunion
        };

        // Ammo index data (Console)
        private readonly Dictionary<byte, int[]> ammoIndexDataConsole = new Dictionary<byte, int[]>()
        {
            {  1, new int[] { 0x1F84, 0x1F85, 0x1F86, 0x1F87 } },   // Jungle
            {  2, new int[] { 0x3112, 0x3113, 0x3114, 0x3115 } },   // Temple Ruins
            {  3, new int[] { 0x21FC, 0x21FD, 0x21FE, 0x21FF } },   // The River Ganges
            {  4, new int[] { 0x13C4, 0x13C5, 0x13C6, 0x13C7 } },   // Caves of Kaliya
            {  5, new int[] { 0x2292, 0x2293, 0x2294, 0x2295 } },   // Coastal Village
            {  6, new int[] { 0x22D4, 0x22D5, 0x22D6, 0x22D7 } },   // Crash Site
            {  7, new int[] { 0x1DFC, 0x1DFD, 0x1DFE, 0x1DFF } },   // Madubu Gorge
            {  8, new int[] { 0x18BA, 0x18BB, 0x18BC, 0x18BD } },   // Temple of Puna
            {  9, new int[] { 0x2280, 0x2281, 0x2282, 0x2283 } },   // Thames Wharf
            { 10, new int[] { 0x2FC8, 0x2FC9, 0x2FCA, 0x2FCB } },   // Aldwych
            { 11, new int[] { 0x289A, 0x289B, 0x289C, 0x289D } },   // Lud's Gate
            { 12, new int[] { 0x1194, 0x1195, 0x1196, 0x1197 } },   // City
            { 13, new int[] { 0x21D0, 0x21D1, 0x21D2, 0x21D3 } },   // Nevada Desert
            { 14, new int[] { 0x2A88, 0x2A89, 0x2A8A, 0x2A8B } },   // High Security Compound
            { 15, new int[] { 0x2D5A, 0x2D5B, 0x2D5C, 0x2D5D } },   // Area 51
            { 16, new int[] { 0x23CA, 0x23CB, 0x23CC, 0x23CD } },   // Antarctica
            { 17, new int[] { 0x2412, 0x2413, 0x2414, 0x2415 } },   // RX-Tech Mines
            { 18, new int[] { 0x299E, 0x299F, 0x29A0, 0x29A1 } },   // Lost City of Tinnos
            { 19, new int[] { 0x1144, 0x1145, 0x1146, 0x1147 } },   // Meteorite Cavern
            { 20, new int[] { 0x1820, 0x1821, 0x1822, 0x1823 } },   // All Hallows
            { 21, new int[] { 0x21AC, 0x21AD, 0x21AE, 0x21AF } },   // Highland Fling
            { 22, new int[] { 0x2530, 0x2531, 0x2532, 0x2533 } },   // Willard's Lair
            { 23, new int[] { 0x25CE, 0x25CF, 0x25D0, 0x25D1 } },   // Shakespeare Cliff
            { 24, new int[] { 0x23D0, 0x23D1, 0x23D2, 0x23D3 } },   // Sleeping with the Fishes
            { 25, new int[] { 0x202E, 0x202F, 0x2030, 0x2031 } },   // It's a Madhouse!
            { 26, new int[] { 0x1A3E, 0x1A3F, 0x1A40, 0x1A41 } },   // Reunion
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

        public int GetHealthOffset()
        {
            byte[] savegameData;

            using (FileStream fs = new FileStream(savegamePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                savegameData = new byte[fs.Length];
                fs.Read(savegameData, 0, savegameData.Length);
            }

            for (int offset = MIN_HEALTH_OFFSET; offset <= MAX_HEALTH_OFFSET; offset += 0x1A)
            {
                int valueIndex = savegameOffset + offset;

                if (valueIndex + 2 >= savegameData.Length)
                {
                    break;
                }

                UInt16 value = BitConverter.ToUInt16(savegameData, valueIndex);

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

        public void DetermineOffsets(byte[] fileData)
        {
            byte levelIndex = GetLevelIndex(fileData);

            DEAGLE_AMMO_OFFSET = 0x66 + (levelIndex * 0x40);
            UZI_AMMO_OFFSET = 0x68 + (levelIndex * 0x40);
            SHOTGUN_AMMO_OFFSET = 0x6A + (levelIndex * 0x40);
            MP5_AMMO_OFFSET = 0x6C + (levelIndex * 0x40);
            ROCKET_LAUNCHER_AMMO_OFFSET = 0x6E + (levelIndex * 0x40);
            HARPOON_GUN_AMMO_OFFSET = 0x70 + (levelIndex * 0x40);
            GRENADE_LAUNCHER_AMMO_OFFSET = 0x72 + (levelIndex * 0x40);
            SMALL_MEDIPACK_OFFSET = 0x74 + (levelIndex * 0x40);
            LARGE_MEDIPACK_OFFSET = 0x75 + (levelIndex * 0x40);
            FLARES_OFFSET = 0x77 + (levelIndex * 0x40);
            COLLECTIBLE_CRYSTALS_OFFSET = 0x78 + (levelIndex * 0x40);
            WEAPONS_CONFIG_NUM_OFFSET = 0xA0 + (levelIndex * 0x40);
            HARPOON_GUN_OFFSET = 0xA1 + (levelIndex * 0x40);

            if (levelIndex == 1)        // Jungle
            {
                MIN_HEALTH_OFFSET = 0xB26;
                MAX_HEALTH_OFFSET = 0xB26;
            }
            else if (levelIndex == 2)   // Temple Ruins
            {
                MIN_HEALTH_OFFSET = 0xDCC;
                MAX_HEALTH_OFFSET = 0xE34;
            }
            else if (levelIndex == 3)   // The River Ganges
            {
                MIN_HEALTH_OFFSET = 0xAFC;
                MAX_HEALTH_OFFSET = 0xAFC;
            }
            else if (levelIndex == 4)   // Caves of Kaliya
            {
                MIN_HEALTH_OFFSET = 0x1038;
                MAX_HEALTH_OFFSET = 0x118A;
            }
            else if (levelIndex == 5)   // Coastal Village
            {
                MIN_HEALTH_OFFSET = 0xCB8;
                MAX_HEALTH_OFFSET = 0xCB8;
            }
            else if (levelIndex == 6)   // Crash Site
            {
                MIN_HEALTH_OFFSET = 0x2046;
                MAX_HEALTH_OFFSET = 0x217E;
            }
            else if (levelIndex == 7)   // Madubu Gorge
            {
                MIN_HEALTH_OFFSET = 0x1250;
                MAX_HEALTH_OFFSET = 0x12B8;
            }
            else if (levelIndex == 8)   // Temple of Puna
            {
                MIN_HEALTH_OFFSET = 0xAD2;
                MAX_HEALTH_OFFSET = 0xAD2;
            }
            else if (levelIndex == 9)   // Thames Wharf
            {
                MIN_HEALTH_OFFSET = 0x10AA;
                MAX_HEALTH_OFFSET = 0x10DE;
            }
            else if (levelIndex == 10)  // Aldwych
            {
                MIN_HEALTH_OFFSET = 0x2C9A;
                MAX_HEALTH_OFFSET = 0x2D02;
            }
            else if (levelIndex == 11)  // Lud's Gate
            {
                MIN_HEALTH_OFFSET = 0xFF0;
                MAX_HEALTH_OFFSET = 0x1058;
            }
            else if (levelIndex == 12)  // City
            {
                MIN_HEALTH_OFFSET = 0xBB2;
                MAX_HEALTH_OFFSET = 0xBB2;
            }
            else if (levelIndex == 13)  // Nevada Desert
            {
                MIN_HEALTH_OFFSET = 0xAF8;
                MAX_HEALTH_OFFSET = 0xAF8;
            }
            else if (levelIndex == 14)  // High Security Compound
            {
                MIN_HEALTH_OFFSET = 0xB4C;
                MAX_HEALTH_OFFSET = 0xB66;
            }
            else if (levelIndex == 15)  // Area 51
            {
                MIN_HEALTH_OFFSET = 0x11E4;
                MAX_HEALTH_OFFSET = 0x129A;
            }
            else if (levelIndex == 16)  // Antarctica
            {
                MIN_HEALTH_OFFSET = 0xB12;
                MAX_HEALTH_OFFSET = 0xB12;
            }
            else if (levelIndex == 17)  // RX-Tech Mines
            {
                MIN_HEALTH_OFFSET = 0xFB0;
                MAX_HEALTH_OFFSET = 0xFCA;
            }
            else if (levelIndex == 18)  // Lost City of Tinnos
            {
                MIN_HEALTH_OFFSET = 0xB7C;
                MAX_HEALTH_OFFSET = 0xB7C;
            }
            else if (levelIndex == 19)  // Meteorite Cavern
            {
                MIN_HEALTH_OFFSET = 0xAD0;
                MAX_HEALTH_OFFSET = 0xAD0;
            }
            else if (levelIndex == 20)  // All Hallows
            {
                MIN_HEALTH_OFFSET = 0x1076;
                MAX_HEALTH_OFFSET = 0x10AA;
            }
            else if (levelIndex == 21)  // Highland Fling
            {
                MIN_HEALTH_OFFSET = 0x1BF4;
                MAX_HEALTH_OFFSET = 0x1CAA;
            }
            else if (levelIndex == 22)  // Willard's Lair
            {
                MIN_HEALTH_OFFSET = 0x15EE;
                MAX_HEALTH_OFFSET = 0x15EE;
            }
            else if (levelIndex == 23)  // Shakespeare Cliff
            {
                MIN_HEALTH_OFFSET = 0x1338;
                MAX_HEALTH_OFFSET = 0x1386;
            }
            else if (levelIndex == 24)  // Sleeping with the Fishes
            {
                MIN_HEALTH_OFFSET = 0xB5A;
                MAX_HEALTH_OFFSET = 0xB5A;
            }
            else if (levelIndex == 25)  // It's a Madhouse!
            {
                MIN_HEALTH_OFFSET = 0x1084;
                MAX_HEALTH_OFFSET = 0x1106;
            }
            else if (levelIndex == 26)  // Reunion
            {
                MIN_HEALTH_OFFSET = 0x1810;
                MAX_HEALTH_OFFSET = 0x18C6;
            }

            if (platform != Platform.PC)
            {
                MIN_HEALTH_OFFSET -= 2;
                MAX_HEALTH_OFFSET -= 2;
            }
        }

        private GameMode GetGameMode(byte[] fileData)
        {
            byte gameMode = fileData[savegameOffset + GAME_MODE_OFFSET];
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
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

        private byte GetNumCollectibleCrystals(byte[] fileData)
        {
            return fileData[savegameOffset + COLLECTIBLE_CRYSTALS_OFFSET];
        }

        private byte GetWeaponsConfigNum(byte[] fileData)
        {
            return fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET];
        }

        private UInt16 GetShotgunAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET) / 6);
        }

        private UInt16 GetDeagleAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + DEAGLE_AMMO_OFFSET);
        }

        private UInt16 GetUziAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + UZI_AMMO_OFFSET);
        }

        private UInt16 GetMP5Ammo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + MP5_AMMO_OFFSET);
        }

        private UInt16 GetRocketLauncherAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + ROCKET_LAUNCHER_AMMO_OFFSET);
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

        private bool IsHarpoonGunPresent(byte[] fileData)
        {
            return fileData[savegameOffset + HARPOON_GUN_OFFSET] != 0;
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

        private void WriteNumCollectibleCrystals(byte[] fileData, byte value)
        {
            fileData[savegameOffset + COLLECTIBLE_CRYSTALS_OFFSET] = value;
        }

        private void WriteWeaponsConfigNum(byte[] fileData, byte value)
        {
            fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET] = value;
        }

        private void WriteHealthValue(byte[] fileData, UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteHarpoonGunPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + HARPOON_GUN_OFFSET] = 1;
            }
            else
            {
                fileData[savegameOffset + HARPOON_GUN_OFFSET] = 0;
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteDeagleAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + DEAGLE_AMMO_OFFSET, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + deagleAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + deagleAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + uziAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private void WriteGrenadeLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRENADE_LAUNCHER_AMMO_OFFSET, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, 0);
            }
        }

        private void WriteMP5Ammo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + MP5_AMMO_OFFSET, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + mp5AmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + mp5AmmoOffset2, 0);
            }
        }

        private void WriteRocketLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + ROCKET_LAUNCHER_AMMO_OFFSET, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + rocketLauncherAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + rocketLauncherAmmoOffset2, 0);
            }
        }

        private void WriteHarpoonGunAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + HARPOON_GUN_AMMO_OFFSET, ammo);

            if (secondaryAmmoIndex != -1)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + harpoonGunAmmoOffset2, ammo);
            }
        }

        public void DisplayGameInfo(byte[] fileData, CheckBox chkPistols, CheckBox chkShotgun, CheckBox chkDeagle, CheckBox chkUzis,
            CheckBox chkMP5, CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudSaveNumber,
            NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks, NumericUpDown nudFlares,
            NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo, NumericUpDown nudGrenadeLauncherAmmo,
            NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo, NumericUpDown nudMP5Ammo, NumericUpDown nudUziAmmo,
            TrackBar trbHealth, Label lblHealth, Label lblHealthError, NumericUpDown nudCollectibleCrystals,
            Label lblCollectibleCrystals)
        {
            DetermineOffsets(fileData);

            nudSaveNumber.Value = GetSaveNumber(fileData);
            nudSmallMedipacks.Value = GetNumSmallMedipacks(fileData);
            nudLargeMedipacks.Value = GetNumLargeMedipacks(fileData);
            nudFlares.Value = GetNumFlares(fileData);

            nudShotgunAmmo.Value = GetShotgunAmmo(fileData);
            nudDeagleAmmo.Value = GetDeagleAmmo(fileData);
            nudGrenadeLauncherAmmo.Value = GetGrenadeLauncherAmmo(fileData);
            nudRocketLauncherAmmo.Value = GetRocketLauncherAmmo(fileData);
            nudHarpoonGunAmmo.Value = GetHarpoonGunAmmo(fileData);
            nudMP5Ammo.Value = GetMP5Ammo(fileData);
            nudUziAmmo.Value = GetUziAmmo(fileData);

            if (GetLevelIndex(fileData) >= 21)
            {
                nudCollectibleCrystals.Enabled = false;
                lblCollectibleCrystals.Visible = false;
                nudCollectibleCrystals.Value = 0;
                nudCollectibleCrystals.Visible = false;
            }
            else
            {
                lblCollectibleCrystals.Text = GetGameMode(fileData) == GameMode.Normal ? "Collectible Crystals:" : "Savegame Crystals:";
                nudCollectibleCrystals.Enabled = true;
                lblCollectibleCrystals.Visible = true;
                nudCollectibleCrystals.Value = GetNumCollectibleCrystals(fileData);
                nudCollectibleCrystals.Visible = true;
            }

            byte weaponsConfigNum = GetWeaponsConfigNum(fileData);

            if (weaponsConfigNum == 1)
            {
                chkPistols.Checked = false;
                chkDeagle.Checked = false;
                chkUzis.Checked = false;
                chkShotgun.Checked = false;
                chkMP5.Checked = false;
                chkRocketLauncher.Checked = false;
                chkGrenadeLauncher.Checked = false;
            }
            else
            {
                chkPistols.Checked = (weaponsConfigNum & WEAPON_PISTOLS) != 0;
                chkDeagle.Checked = (weaponsConfigNum & WEAPON_DEAGLE) != 0;
                chkUzis.Checked = (weaponsConfigNum & WEAPON_UZIS) != 0;
                chkShotgun.Checked = (weaponsConfigNum & WEAPON_SHOTGUN) != 0;
                chkMP5.Checked = (weaponsConfigNum & WEAPON_MP5) != 0;
                chkRocketLauncher.Checked = (weaponsConfigNum & WEAPON_ROCKET_LAUNCHER) != 0;
                chkGrenadeLauncher.Checked = (weaponsConfigNum & WEAPON_GRENADE_LAUNCHER) != 0;
            }

            chkHarpoonGun.Checked = IsHarpoonGunPresent(fileData);

            int healthOffset = GetHealthOffset();

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

        public void WriteChanges(byte[] fileData, CheckBox chkPistols, CheckBox chkDeagle, CheckBox chkUzis, CheckBox chkShotgun,
            CheckBox chkMP5, CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun,
            NumericUpDown nudSaveNumber, NumericUpDown nudFlares, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo,
            NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo,
            NumericUpDown nudMP5Ammo, NumericUpDown nudUziAmmo, TrackBar trbHealth, NumericUpDown nudCollectibleCrystals)
        {
            DetermineOffsets(fileData);

            WriteSaveNumber(fileData, (Int32)nudSaveNumber.Value);
            WriteNumFlares(fileData, (byte)nudFlares.Value);
            WriteNumSmallMedipacks(fileData, (byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks(fileData, (byte)nudLargeMedipacks.Value);

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += WEAPON_PISTOLS;
            if (chkDeagle.Checked) newWeaponsConfigNum += WEAPON_DEAGLE;
            if (chkUzis.Checked) newWeaponsConfigNum += WEAPON_UZIS;
            if (chkShotgun.Checked) newWeaponsConfigNum += WEAPON_SHOTGUN;
            if (chkMP5.Checked) newWeaponsConfigNum += WEAPON_MP5;
            if (chkRocketLauncher.Checked) newWeaponsConfigNum += WEAPON_ROCKET_LAUNCHER;
            if (chkGrenadeLauncher.Checked) newWeaponsConfigNum += WEAPON_GRENADE_LAUNCHER;

            WriteWeaponsConfigNum(fileData, newWeaponsConfigNum);
            WriteHarpoonGunPresent(fileData, chkHarpoonGun.Checked);

            byte levelIndex = GetLevelIndex(fileData);
            secondaryAmmoIndex = GetSecondaryAmmoIndex(fileData);

            if (secondaryAmmoIndex != -1)
            {
                Dictionary<byte, int[]> ammoIndexData;

                if (platform == Platform.PC)
                {
                    ammoIndexData = ammoIndexDataPC;
                }
                else
                {
                    ammoIndexData = ammoIndexDataConsole;
                }

                int baseSecondaryAmmoOffset = ammoIndexData[levelIndex][0];

                deagleAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0xAC);
                uziAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0xA4);
                shotgunAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x9C);
                harpoonGunAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x94);
                rocketLauncherAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x8C);
                grenadeLauncherAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x84);
                mp5AmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x7C);
            }

            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));
            WriteDeagleAmmo(fileData, chkDeagle.Checked, (UInt16)nudDeagleAmmo.Value);
            WriteGrenadeLauncherAmmo(fileData, chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value);
            WriteRocketLauncherAmmo(fileData, chkRocketLauncher.Checked, (UInt16)nudRocketLauncherAmmo.Value);
            WriteHarpoonGunAmmo(fileData, chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value);
            WriteMP5Ammo(fileData, chkMP5.Checked, (UInt16)nudMP5Ammo.Value);
            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value);

            if (levelIndex < 21)
            {
                WriteNumCollectibleCrystals(fileData, (byte)nudCollectibleCrystals.Value);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (UInt16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
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
            if (byteFlag1 == 0x49 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Sprinting
            if (byteFlag1 == 0x20 && byteFlag2 == 0x00 && byteFlag3 == 0x20 && byteFlag4 == 0x00) return true;  // Sliding backward
            if (byteFlag1 == 0x18 && byteFlag2 == 0x00 && byteFlag3 == 0x18 && byteFlag4 == 0x00) return true;  // Sliding downhill
            if (byteFlag1 == 0x47 && byteFlag2 == 0x00 && byteFlag3 == 0x47 && byteFlag4 == 0x00) return true;  // Crouching
            if (byteFlag1 == 0x50 && byteFlag2 == 0x00 && byteFlag3 == 0x50 && byteFlag4 == 0x00) return true;  // Kneeling
            if (byteFlag1 == 0x51 && byteFlag2 == 0x00 && byteFlag3 == 0x50 && byteFlag4 == 0x00) return true;  // Crawling forward
            if (byteFlag1 == 0x2A && byteFlag2 == 0x00 && byteFlag3 == 0x02 && byteFlag4 == 0x00) return true;  // Using puzzle item
            if (byteFlag1 == 0x0F && byteFlag2 == 0x00 && byteFlag3 == 0x0F && byteFlag4 == 0x00) return true;  // Quad Bike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x00 && byteFlag3 == 0x08 && byteFlag4 == 0x00) return true;  // Quad Bike
            if (byteFlag1 == 0x05 && byteFlag2 == 0x00 && byteFlag3 == 0x05 && byteFlag4 == 0x00) return true;  // UPV
            if (byteFlag1 == 0x01 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Kayak or Boat
            if (byteFlag1 == 0x03 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Kayak or Boat
            if (byteFlag1 == 0x06 && byteFlag2 == 0x00 && byteFlag3 == 0x06 && byteFlag4 == 0x00) return true;  // Mine Cart
            if (byteFlag1 == 0x0C && byteFlag2 == 0x00 && byteFlag3 == 0x0C && byteFlag4 == 0x00) return true;  // Mine Cart

            return false;
        }

        public bool IsLaraInVehicle(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 10];
            byte byteFlag2 = fileData[healthOffset - 9];
            byte byteFlag3 = fileData[healthOffset - 8];
            byte byteFlag4 = fileData[healthOffset - 7];

            if (byteFlag1 == 0x0F && byteFlag2 == 0x00 && byteFlag3 == 0x0F && byteFlag4 == 0x00) return true;  // Quad Bike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x00 && byteFlag3 == 0x08 && byteFlag4 == 0x00) return true;  // Quad Bike
            if (byteFlag1 == 0x05 && byteFlag2 == 0x00 && byteFlag3 == 0x05 && byteFlag4 == 0x00) return true;  // UPV
            if (byteFlag1 == 0x01 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Kayak or Boat
            if (byteFlag1 == 0x03 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Kayak or Boat
            if (byteFlag1 == 0x06 && byteFlag2 == 0x00 && byteFlag3 == 0x06 && byteFlag4 == 0x00) return true;  // Mine Cart
            if (byteFlag1 == 0x0C && byteFlag2 == 0x00 && byteFlag3 == 0x0C && byteFlag4 == 0x00) return true;  // Mine Cart

            return false;
        }

        private int GetSecondaryAmmoIndex(byte[] fileData)
        {
            byte levelIndex = GetLevelIndex(fileData);

            Dictionary<byte, int[]> ammoIndexData;

            if (platform == Platform.PC)
            {
                ammoIndexData = ammoIndexDataPC;
            }
            else
            {
                ammoIndexData = ammoIndexDataConsole;
            }

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

                        offsets1[i] += savegameOffset + (index * 0x1A);
                        offsets2[i] += savegameOffset + (index * 0x1A);
                    }

                    if (offsets1.All(offset => fileData[offset] == 0xFF))
                    {
                        return index;
                    }

                    if (offsets2.All(offset => fileData[offset] == 0xFF))
                    {
                        return index;
                    }
                }
            }

            return -1;
        }

        private int GetSecondaryAmmoOffset(int baseOffset)
        {
            return baseOffset + (secondaryAmmoIndex * 0x1A);
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
                    string levelName = levelNames[levelIndex];
                    GameMode gameMode = fileData[savegame.Offset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;

                    savegame.UpdateDisplayName(levelName, saveNumber, gameMode);
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

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR3)
                {
                    byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool savegamePresent = slotStatus != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR3) / SAVEGAME_SIZE;

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

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode);
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

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

                byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool savegamePresent = slotStatus != 0;

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR3) / SAVEGAME_SIZE;
                    GameMode gameMode = fileData[currentSavegameOffset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode);
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
