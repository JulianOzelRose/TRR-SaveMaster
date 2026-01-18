using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR4Utilities
    {
        // Savegame constants & offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int SAVE_NUMBER_OFFSET = 0x008;
        private const int GAME_MODE_OFFSET = 0x01C;
        private const int LEVEL_INDEX_OFFSET = 0x26F;
        private const int BASE_SAVEGAME_OFFSET_TR4 = 0x2000;
        private const int MAX_SAVEGAME_OFFSET_TR4 = 0x14AE00;
        private const int SAVEGAME_SIZE = 0xA470;
        private const int MAX_SAVEGAMES = 32;

        // Item offsets
        private const int GOLDEN_SKULLS_OFFSET = 0x1A6;
        private const int SMALL_MEDIPACK_OFFSET = 0x1BE;
        private const int LARGE_MEDIPACK_OFFSET = 0x1C0;
        private const int FLARES_OFFSET = 0x1C2;

        // Weapon offsets
        private const int PISTOLS_OFFSET = 0x194;
        private const int UZI_OFFSET = 0x195;
        private const int SHOTGUN_OFFSET = 0x196;
        private const int CROSSBOW_OFFSET = 0x197;
        private const int GRENADE_GUN_OFFSET = 0x199;
        private const int REVOLVER_OFFSET = 0x19A;

        // Ammo offsets
        private const int UZI_AMMO_OFFSET = 0x1C6;
        private const int REVOLVER_AMMO_OFFSET = 0x1C8;
        private const int SHOTGUN_NORMAL_AMMO_OFFSET = 0x1CA;
        private const int SHOTGUN_WIDESHOT_AMMO_OFFSET = 0x1CC;
        private const int GRENADE_GUN_NORMAL_AMMO_OFFSET = 0x1D0;
        private const int GRENADE_GUN_SUPER_AMMO_OFFSET = 0x1D2;
        private const int GRENADE_GUN_FLASH_AMMO_OFFSET = 0x1D4;
        private const int CROSSBOW_NORMAL_AMMO_OFFSET = 0x1D6;
        private const int CROSSBOW_POISON_AMMO_OFFSET = 0x1D8;
        private const int CROSSBOW_EXPLOSIVE_AMMO_OFFSET = 0x1DA;

        // Weapon byte flags
        private const byte WEAPON_PRESENT = 0x9;
        private const byte WEAPON_PRESENT_WITH_SIGHT = 0xD;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private int MAX_HEALTH_OFFSET;
        private int MIN_HEALTH_OFFSET;
        private const byte FULL_HEALTH_TOGGLE_BYTE = 0x08;          // Toggle byte when health is full (not stored)
        private const byte PARTIAL_HEALTH_TOGGLE_BYTE = 0x0C;       // Toggle byte when health is partial (stored)
        private const byte TOGGLE_DELTA = 0x04;                     // Difference between full and partial toggle bytes

        // Misc
        private string savegamePath;
        private int savegameOffset;

        // Level names
        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
        {
            {  1, "Angkor Wat"                      },
            {  2, "Race for the Iris"               },
            {  3, "The Tomb of Seth"                },
            {  4, "Burial Chambers"                 },
            {  5, "Valley of the Kings"             },
            {  6, "KV5"                             },
            {  7, "Temple of Karnak"                },
            {  8, "The Great Hypostyle Hall"        },
            {  9, "Sacred Lake"                     },
            { 11, "Tomb of Semerkhet"               },
            { 12, "Guardian of Semerkhet"           },
            { 13, "Desert Railroad"                 },
            { 14, "Alexandria"                      },
            { 15, "Coastal Ruins"                   },
            { 16, "Pharos, Temple of Isis"          },
            { 17, "Cleopatra's Palaces"             },
            { 18, "Catacombs"                       },
            { 19, "Temple of Poseidon"              },
            { 20, "The Lost Library"                },
            { 21, "Hall of Demetrius"               },
            { 22, "City of the Dead"                },
            { 23, "Trenches"                        },
            { 24, "Chambers of Tulun"               },
            { 25, "Street Bazaar"                   },
            { 26, "Citadel Gate"                    },
            { 27, "Citadel"                         },
            { 28, "The Sphinx Complex"              },
            { 30, "Underneath the Sphinx"           },
            { 31, "Menkaure's Pyramid"              },
            { 32, "Inside Menkaure's Pyramid"       },
            { 33, "The Mastabas"                    },
            { 34, "The Great Pyramid"               },
            { 35, "Khufu's Queens Pyramids"         },
            { 36, "Inside the Great Pyramid"        },
            { 37, "Temple of Horus"                 },
            { 38, "Temple of Horus"                 },
            { 39, "The Times Office"                },
            { 40, "The Times Exclusive"             },
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

            for (int offset = MIN_HEALTH_OFFSET; offset <= MAX_HEALTH_OFFSET; offset++)
            {
                int valueIndex = savegameOffset + offset;

                if (valueIndex + 1 >= savegameData.Length)
                {
                    break;
                }

                UInt16 value = BitConverter.ToUInt16(savegameData, valueIndex);

                if ((value >= MIN_HEALTH_VALUE && value < MAX_HEALTH_VALUE) || value == 0)
                {
                    int flagIndex1 = savegameOffset + offset - 7;
                    int flagIndex2 = savegameOffset + offset - 6;
                    int flagIndex3 = savegameOffset + offset - 5;
                    int flagIndex4 = savegameOffset + offset - 4;

                    if (flagIndex4 >= savegameData.Length)
                    {
                        continue;
                    }

                    byte byteFlag1 = savegameData[flagIndex1];
                    byte byteFlag2 = savegameData[flagIndex2];
                    byte byteFlag3 = savegameData[flagIndex3];
                    byte byteFlag4 = savegameData[flagIndex4];

                    bool isKnownByteFlagPattern = IsKnownByteFlagPattern(byteFlag1, byteFlag2, byteFlag3, byteFlag4);

                    if (isKnownByteFlagPattern)
                    {
                        if (value != 0)
                        {
                            return savegameOffset + offset;
                        }
                        else
                        {
                            int toggleIndex = savegameOffset + offset - 0x13;

                            if (toggleIndex < 0 || toggleIndex >= savegameData.Length)
                            {
                                continue;
                            }

                            byte toggleByte = savegameData[toggleIndex];

                            if (toggleByte == FULL_HEALTH_TOGGLE_BYTE)
                            {
                                return savegameOffset + offset;
                            }
                        }
                    }
                }
            }

            return -1;
        }

        public void DetermineOffsets(byte[] fileData)
        {
            byte levelIndex = GetLevelIndex(fileData);

            if (levelIndex == 1)        // Angkor Wat
            {
                MIN_HEALTH_OFFSET = 0x682;
                MAX_HEALTH_OFFSET = 0x684;
            }
            else if (levelIndex == 2)   // Race for the Iris
            {
                MIN_HEALTH_OFFSET = 0xE5C;
                MAX_HEALTH_OFFSET = 0x192A;
            }
            else if (levelIndex == 3)   // Tomb of Seth
            {
                MIN_HEALTH_OFFSET = 0x7C4;
                MAX_HEALTH_OFFSET = 0x98A;
            }
            else if (levelIndex == 4)   // Burial Chambers
            {
                MIN_HEALTH_OFFSET = 0x808;
                MAX_HEALTH_OFFSET = 0xE4D;
            }
            else if (levelIndex == 5)   // Valley of the Kings
            {
                MIN_HEALTH_OFFSET = 0x5F0;
                MAX_HEALTH_OFFSET = 0x1627;
            }
            else if (levelIndex == 6)   // KV5
            {
                MIN_HEALTH_OFFSET = 0x94E;
                MAX_HEALTH_OFFSET = 0xF34;
            }
            else if (levelIndex == 7)   // Temple of Karnak
            {
                MIN_HEALTH_OFFSET = 0x612;
                MAX_HEALTH_OFFSET = 0x109F;
            }
            else if (levelIndex == 8)   // The Great Hypostyle Wall
            {
                MIN_HEALTH_OFFSET = 0xC6C;
                MAX_HEALTH_OFFSET = 0x1D56;
            }
            else if (levelIndex == 9)   // Sacred Lake
            {
                MIN_HEALTH_OFFSET = 0x7EE;
                MAX_HEALTH_OFFSET = 0x1D1C;
            }
            else if (levelIndex == 11)  // Tomb of Semerkhet
            {
                MIN_HEALTH_OFFSET = 0xDCD;
                MAX_HEALTH_OFFSET = 0x3116;
            }
            else if (levelIndex == 12)  // Guardian of Semerkhet
            {
                MIN_HEALTH_OFFSET = 0x75F;
                MAX_HEALTH_OFFSET = 0x1E9D;
            }
            else if (levelIndex == 13)  // Desert Railroad
            {
                MIN_HEALTH_OFFSET = 0x654;
                MAX_HEALTH_OFFSET = 0x6A2;
            }
            else if (levelIndex == 14)  // Alexandria
            {
                MIN_HEALTH_OFFSET = 0x5DE;
                MAX_HEALTH_OFFSET = 0x3F6B;
            }
            else if (levelIndex == 15)  // Coastal Ruins
            {
                MIN_HEALTH_OFFSET = 0x978;
                MAX_HEALTH_OFFSET = 0x386D;
            }
            else if (levelIndex == 16)  // Pharos, Temple of Isis
            {
                MIN_HEALTH_OFFSET = 0x73A;
                MAX_HEALTH_OFFSET = 0x4BC2;
            }
            else if (levelIndex == 17)  // Cleopatra's Palaces
            {
                MIN_HEALTH_OFFSET = 0x688;
                MAX_HEALTH_OFFSET = 0x5305;
            }
            else if (levelIndex == 18)  // Catacombs
            {
                MIN_HEALTH_OFFSET = 0x5F0;
                MAX_HEALTH_OFFSET = 0x24F5;
            }
            else if (levelIndex == 19)  // Temple of Poseidon
            {
                MIN_HEALTH_OFFSET = 0x8F3;
                MAX_HEALTH_OFFSET = 0x2B2E;
            }
            else if (levelIndex == 20)  // The Lost Library
            {
                MIN_HEALTH_OFFSET = 0xE7B;
                MAX_HEALTH_OFFSET = 0x3FE7;
            }
            else if (levelIndex == 21)  // Hall of Demetrius
            {
                MIN_HEALTH_OFFSET = 0x5FA;
                MAX_HEALTH_OFFSET = 0x3E94;
            }
            else if (levelIndex == 22)  // City of the Dead
            {
                MIN_HEALTH_OFFSET = 0x651;
                MAX_HEALTH_OFFSET = 0x76A;
            }
            else if (levelIndex == 23)  // Trenches
            {
                MIN_HEALTH_OFFSET = 0xB74;
                MAX_HEALTH_OFFSET = 0x2645;
            }
            else if (levelIndex == 24)  // Chambers of Tulun
            {
                MIN_HEALTH_OFFSET = 0xDAC;
                MAX_HEALTH_OFFSET = 0x1848;
            }
            else if (levelIndex == 25)  // Street Bazaar
            {
                MIN_HEALTH_OFFSET = 0x6DD;
                MAX_HEALTH_OFFSET = 0x2736;
            }
            else if (levelIndex == 26)  // Citadel Gate
            {
                MIN_HEALTH_OFFSET = 0x77A;
                MAX_HEALTH_OFFSET = 0x19CA;
            }
            else if (levelIndex == 27)  // Citadel
            {
                MIN_HEALTH_OFFSET = 0x8EA;
                MAX_HEALTH_OFFSET = 0x1070;
            }
            else if (levelIndex == 28)  // The Sphinx Complex
            {
                MIN_HEALTH_OFFSET = 0x64B;
                MAX_HEALTH_OFFSET = 0x1880;
            }
            else if (levelIndex == 30)  // Underneath the Sphinx
            {
                MIN_HEALTH_OFFSET = 0x9C4;
                MAX_HEALTH_OFFSET = 0x1199;
            }
            else if (levelIndex == 31)  // Menkaure's Pyramid
            {
                MIN_HEALTH_OFFSET = 0x5FC;
                MAX_HEALTH_OFFSET = 0x2307;
            }
            else if (levelIndex == 32)  // Inside Menkaure's Pyramid
            {
                MIN_HEALTH_OFFSET = 0x8BA;
                MAX_HEALTH_OFFSET = 0x2AE9;
            }
            else if (levelIndex == 33)  // The Mastabas
            {
                MIN_HEALTH_OFFSET = 0xA8C;
                MAX_HEALTH_OFFSET = 0x44AE;
            }
            else if (levelIndex == 34)  // The Great Pyramid
            {
                MIN_HEALTH_OFFSET = 0x69A;
                MAX_HEALTH_OFFSET = 0x500C;
            }
            else if (levelIndex == 35)  // Khufu's Queens Pyramids
            {
                MIN_HEALTH_OFFSET = 0xA6B;
                MAX_HEALTH_OFFSET = 0x55F1;
            }
            else if (levelIndex == 36)  // Inside the Great Pyramid
            {
                MIN_HEALTH_OFFSET = 0x612;
                MAX_HEALTH_OFFSET = 0x5D36;
            }
            else if (levelIndex == 37)  // Temple of Horus
            {
                MIN_HEALTH_OFFSET = 0x88B;
                MAX_HEALTH_OFFSET = 0x79CF;
            }
            else if (levelIndex == 38)  // Temple of Horus (Part 2)
            {
                MIN_HEALTH_OFFSET = 0x9ED;
                MAX_HEALTH_OFFSET = 0x8B04;
            }
            else if (levelIndex == 40)  // The Times Exclusive
            {
                MIN_HEALTH_OFFSET = 0x9F2;
                MAX_HEALTH_OFFSET = 0xFCD;
            }
        }

        private Int32 GetSaveNumber(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + SAVE_NUMBER_OFFSET);
        }

        private byte GetLevelIndex(byte[] fileData)
        {
            return fileData[savegameOffset + LEVEL_INDEX_OFFSET];
        }

        private UInt16 GetNumSmallMedipacks(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + SMALL_MEDIPACK_OFFSET);
        }

        private UInt16 GetNumLargeMedipacks(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + LARGE_MEDIPACK_OFFSET);
        }

        private UInt16 GetNumFlares(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + FLARES_OFFSET);
        }

        private sbyte GetNumGoldenSkulls(byte[] fileData)
        {
            return (sbyte)fileData[savegameOffset + GOLDEN_SKULLS_OFFSET];
        }

        private UInt16 GetUziAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + UZI_AMMO_OFFSET);
        }

        private UInt16 GetRevolverAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + REVOLVER_AMMO_OFFSET);
        }

        private UInt16 GetShotgunNormalAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_NORMAL_AMMO_OFFSET) / 6);
        }

        private UInt16 GetShotgunWideshotAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_WIDESHOT_AMMO_OFFSET) / 6);
        }

        private UInt16 GetGrenadeGunNormalAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + GRENADE_GUN_NORMAL_AMMO_OFFSET);
        }

        private UInt16 GetGrenadeGunSuperAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + GRENADE_GUN_SUPER_AMMO_OFFSET);
        }

        private UInt16 GetGrenadeGunFlashAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + GRENADE_GUN_FLASH_AMMO_OFFSET);
        }

        private UInt16 GetCrossbowNormalAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + CROSSBOW_NORMAL_AMMO_OFFSET);
        }

        private UInt16 GetCrossbowPoisonAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + CROSSBOW_POISON_AMMO_OFFSET);
        }

        private UInt16 GetCrossbowExplosiveAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + CROSSBOW_EXPLOSIVE_AMMO_OFFSET);
        }

        private byte GetRevolverFlag(byte[] fileData)
        {
            return fileData[savegameOffset + REVOLVER_OFFSET];
        }

        private byte GetCrossbowFlag(byte[] fileData)
        {
            return fileData[savegameOffset + CROSSBOW_OFFSET];
        }

        private UInt16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            UInt16 rawHealth = BitConverter.ToUInt16(fileData, healthOffset);

            if (rawHealth != 0)
            {
                return rawHealth;
            }

            return MAX_HEALTH_VALUE;
        }

        private bool IsPistolsPresent(byte[] fileData)
        {
            return fileData[savegameOffset + PISTOLS_OFFSET] != 0;
        }

        private bool IsUziPresent(byte[] fileData)
        {
            return fileData[savegameOffset + UZI_OFFSET] != 0;
        }

        private bool IsRevolverPresent(byte[] fileData)
        {
            return fileData[savegameOffset + REVOLVER_OFFSET] != 0;
        }

        private bool IsShotgunPresent(byte[] fileData)
        {
            return fileData[savegameOffset + SHOTGUN_OFFSET] != 0;
        }

        private bool IsGrenadeGunPresent(byte[] fileData)
        {
            return fileData[savegameOffset + GRENADE_GUN_OFFSET] != 0;
        }

        private bool IsCrossbowPresent(byte[] fileData)
        {
            return fileData[savegameOffset + CROSSBOW_OFFSET] != 0;
        }

        private void WriteSaveNumber(byte[] fileData, Int32 value)
        {
            WriteInt32ToBuffer(fileData, savegameOffset + SAVE_NUMBER_OFFSET, value);
        }

        private void WriteNumSmallMedipacks(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SMALL_MEDIPACK_OFFSET, value);
        }

        private void WriteNumLargeMedipacks(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + LARGE_MEDIPACK_OFFSET, value);
        }

        private void WriteNumFlares(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + FLARES_OFFSET, value);
        }

        private void WriteNumGoldenSkulls(byte[] fileData, sbyte value)
        {
            fileData[savegameOffset + GOLDEN_SKULLS_OFFSET] = (byte)value;
        }

        private void WritePistolsPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + PISTOLS_OFFSET] = WEAPON_PRESENT;
            }
            else
            {
                fileData[savegameOffset + PISTOLS_OFFSET] = 0;
            }
        }

        private void WriteUziPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + UZI_OFFSET] = WEAPON_PRESENT;
            }
            else
            {
                fileData[savegameOffset + UZI_OFFSET] = 0;
            }
        }

        private void WriteRevolverPresent(byte[] fileData, bool isPresent, byte prevRevolverFlag)
        {
            if (isPresent && prevRevolverFlag != 0)
            {
                fileData[savegameOffset + REVOLVER_OFFSET] = prevRevolverFlag;
            }
            else if (isPresent)
            {
                fileData[savegameOffset + REVOLVER_OFFSET] = WEAPON_PRESENT_WITH_SIGHT;
            }
            else
            {
                fileData[savegameOffset + REVOLVER_OFFSET] = 0;
            }
        }

        private void WriteShotgunPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + SHOTGUN_OFFSET] = WEAPON_PRESENT;
            }
            else
            {
                fileData[savegameOffset + SHOTGUN_OFFSET] = 0;
            }
        }

        private void WriteGrenadeGunPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + GRENADE_GUN_OFFSET] = WEAPON_PRESENT;
            }
            else
            {
                fileData[savegameOffset + GRENADE_GUN_OFFSET] = 0;
            }
        }

        private void WriteCrossbowPresent(byte[] fileData, bool isPresent, byte prevCrossbowFlag)
        {
            if (isPresent && prevCrossbowFlag != 0)
            {
                fileData[savegameOffset + CROSSBOW_OFFSET] = prevCrossbowFlag;
            }
            else if (isPresent)
            {
                fileData[savegameOffset + CROSSBOW_OFFSET] = WEAPON_PRESENT_WITH_SIGHT;
            }
            else
            {
                fileData[savegameOffset + CROSSBOW_OFFSET] = 0;
            }
        }

        private void WriteUziAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);
        }

        private void WriteRevolverAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + REVOLVER_AMMO_OFFSET, ammo);
        }

        private void WriteShotgunNormalAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_NORMAL_AMMO_OFFSET, ammo);
        }

        private void WriteShotgunWideshotAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_WIDESHOT_AMMO_OFFSET, ammo);
        }

        private void WriteGrenadeGunNormalAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRENADE_GUN_NORMAL_AMMO_OFFSET, ammo);
        }

        private void WriteGrenadeGunSuperAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRENADE_GUN_SUPER_AMMO_OFFSET, ammo);
        }

        private void WriteGrenadeGunFlashAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRENADE_GUN_FLASH_AMMO_OFFSET, ammo);
        }

        private void WriteCrossbowNormalAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + CROSSBOW_NORMAL_AMMO_OFFSET, ammo);
        }

        private void WriteCrossbowPoisonAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + CROSSBOW_POISON_AMMO_OFFSET, ammo);
        }

        private void WriteCrossbowExplosiveAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + CROSSBOW_EXPLOSIVE_AMMO_OFFSET, ammo);
        }

        private void WriteHealthValue(byte[] fileData, UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                int toggleOffset = healthOffset - 0x13;
                byte currentToggle = fileData[toggleOffset];

                bool currentlyFull = (currentToggle == FULL_HEALTH_TOGGLE_BYTE);
                bool currentlyPartial = (currentToggle == PARTIAL_HEALTH_TOGGLE_BYTE);
                bool newIsPartial = newHealth < MAX_HEALTH_VALUE;


                if (currentlyFull && newIsPartial)
                {
                    // Full health -> Partial health
                    fileData[toggleOffset] = (byte)(currentToggle + TOGGLE_DELTA);
                    WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
                    ShiftBytesRight(ref fileData, healthOffset);
                }
                else if (currentlyPartial && !newIsPartial)
                {
                    // Partial health -> Full health
                    fileData[toggleOffset] = (byte)(currentToggle - TOGGLE_DELTA);
                    WriteUInt16ToBuffer(fileData, healthOffset, 0);
                    ShiftBytesLeft(ref fileData, healthOffset);
                }
                else if (currentlyFull && !newIsPartial)
                {
                    // Already full health
                    WriteUInt16ToBuffer(fileData, healthOffset, 0);
                }
                else
                {
                    // Partial health -> Partial health
                    WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
                }
            }
        }

        private void ShiftBytesRight(ref byte[] fileData, int healthOffset)
        {
            int boundary = savegameOffset + SAVEGAME_SIZE;

            Array.Resize(ref fileData, fileData.Length + 2);

            for (int i = boundary - 1; i >= healthOffset + 2; i--)
            {
                fileData[i + 2] = fileData[i];
            }
        }

        private void ShiftBytesLeft(ref byte[] fileData, int healthOffset)
        {
            int boundary = savegameOffset + SAVEGAME_SIZE;

            for (int i = healthOffset + 2; i < boundary - 2; i++)
            {
                fileData[i] = fileData[i + 2];
            }

            Array.Resize(ref fileData, fileData.Length - 2);
        }

        public void DisplayGameInfo(byte[] fileData, NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudFlares, NumericUpDown nudGoldenSkulls, Label lblGoldenSkulls, CheckBox chkPistols, CheckBox chkShotgun, CheckBox chkUzi,
            CheckBox chkRevolver, CheckBox chkGrenadeGun, CheckBox chkCrossbow, TrackBar trbHealth, Label lblHealth,
            Label lblHealthError, NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, NumericUpDown nudUziAmmo,
            NumericUpDown nudRevolverAmmo, NumericUpDown nudCrossbowNormalAmmo, NumericUpDown nudGrenadeGunFlashAmmo,
            NumericUpDown nudGrenadeGunNormalAmmo, NumericUpDown nudGrenadeGunSuperAmmo, NumericUpDown nudCrossbowPoisonAmmo,
            NumericUpDown nudCrossbowExplosiveAmmo)
        {
            DetermineOffsets(fileData);

            nudSaveNumber.Value = GetSaveNumber(fileData);
            nudSmallMedipacks.Value = GetNumSmallMedipacks(fileData);
            nudLargeMedipacks.Value = GetNumLargeMedipacks(fileData);
            nudFlares.Value = GetNumFlares(fileData);

            chkPistols.Checked = IsPistolsPresent(fileData);
            chkUzi.Checked = IsUziPresent(fileData);
            chkShotgun.Checked = IsShotgunPresent(fileData);
            chkGrenadeGun.Checked = IsGrenadeGunPresent(fileData);
            chkCrossbow.Checked = IsCrossbowPresent(fileData);
            chkRevolver.Checked = IsRevolverPresent(fileData);

            nudUziAmmo.Value = GetUziAmmo(fileData);
            nudRevolverAmmo.Value = GetRevolverAmmo(fileData);
            nudShotgunNormalAmmo.Value = GetShotgunNormalAmmo(fileData);
            nudShotgunWideshotAmmo.Value = GetShotgunWideshotAmmo(fileData);
            nudCrossbowNormalAmmo.Value = GetCrossbowNormalAmmo(fileData);
            nudCrossbowPoisonAmmo.Value = GetCrossbowPoisonAmmo(fileData);
            nudCrossbowExplosiveAmmo.Value = GetCrossbowExplosiveAmmo(fileData);
            nudGrenadeGunNormalAmmo.Value = GetGrenadeGunNormalAmmo(fileData);
            nudGrenadeGunSuperAmmo.Value = GetGrenadeGunSuperAmmo(fileData);
            nudGrenadeGunFlashAmmo.Value = GetGrenadeGunFlashAmmo(fileData);

            byte levelIndex = GetLevelIndex(fileData);

            if (levelIndex == 1 || levelIndex == 2) // Angkor Wat and Race for the Iris
            {
                lblGoldenSkulls.Visible = true;
                nudGoldenSkulls.Visible = true;
                nudGoldenSkulls.Enabled = true;
                nudGoldenSkulls.Value = GetNumGoldenSkulls(fileData);
            }
            else
            {
                lblGoldenSkulls.Visible = false;
                nudGoldenSkulls.Visible = false;
                nudGoldenSkulls.Enabled = false;
                nudGoldenSkulls.Value = 0;
            }

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

        public void WriteChanges(byte[] fileData, NumericUpDown nudSaveNumber, NumericUpDown nudGoldenSkulls, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, NumericUpDown nudFlares, CheckBox chkPistols, CheckBox chkUzi, CheckBox chkRevolver,
            CheckBox chkShotgun, CheckBox chkGrenadeGun, CheckBox chkCrossbow, NumericUpDown nudUziAmmo, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, NumericUpDown nudGrenadeGunNormalAmmo, NumericUpDown nudGrenadeGunSuperAmmo,
            NumericUpDown nudGrenadeGunFlashAmmo, NumericUpDown nudCrossbowNormalAmmo, NumericUpDown nudCrossbowPoisonAmmo, NumericUpDown nudCrossbowExplosiveAmmo,
            TrackBar trbHealth)
        {
            byte prevCrossbowFlag = GetCrossbowFlag(fileData);
            byte prevRevolverFlag = GetRevolverFlag(fileData);

            WriteSaveNumber(fileData, (Int32)nudSaveNumber.Value);
            WriteNumSmallMedipacks(fileData, (UInt16)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks(fileData, (UInt16)nudLargeMedipacks.Value);
            WriteNumFlares(fileData, (UInt16)nudFlares.Value);

            WritePistolsPresent(fileData, chkPistols.Checked);
            WriteUziPresent(fileData, chkUzi.Checked);
            WriteShotgunPresent(fileData, chkShotgun.Checked);
            WriteGrenadeGunPresent(fileData, chkGrenadeGun.Checked);
            WriteCrossbowPresent(fileData, chkCrossbow.Checked, prevCrossbowFlag);
            WriteRevolverPresent(fileData, chkRevolver.Checked, prevRevolverFlag);

            WriteUziAmmo(fileData, (UInt16)nudUziAmmo.Value);
            WriteRevolverAmmo(fileData, (UInt16)nudRevolverAmmo.Value);
            WriteShotgunNormalAmmo(fileData, (UInt16)(nudShotgunNormalAmmo.Value * 6));
            WriteShotgunWideshotAmmo(fileData, (UInt16)(nudShotgunWideshotAmmo.Value * 6));
            WriteCrossbowNormalAmmo(fileData, (UInt16)nudCrossbowNormalAmmo.Value);
            WriteCrossbowPoisonAmmo(fileData, (UInt16)nudCrossbowPoisonAmmo.Value);
            WriteCrossbowExplosiveAmmo(fileData, (UInt16)nudCrossbowExplosiveAmmo.Value);
            WriteGrenadeGunNormalAmmo(fileData, (UInt16)nudGrenadeGunNormalAmmo.Value);
            WriteGrenadeGunSuperAmmo(fileData, (UInt16)nudGrenadeGunSuperAmmo.Value);
            WriteGrenadeGunFlashAmmo(fileData, (UInt16)nudGrenadeGunFlashAmmo.Value);

            if (nudGoldenSkulls.Enabled)
            {
                WriteNumGoldenSkulls(fileData, (sbyte)nudGoldenSkulls.Value);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (UInt16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
        }

        private bool IsKnownByteFlagPattern(byte byteFlag1, byte byteFlag2, byte byteFlag3, byte byteFlag4)
        {
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x00 && byteFlag4 == 0x52) return true;  // Standing
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x00 && byteFlag4 == 0x67) return true;  // Standing
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x47 && byteFlag4 == 0x67) return true;  // Standing
            if (byteFlag1 == 0x50 && byteFlag2 == 0x50 && byteFlag3 == 0x00 && byteFlag4 == 0x07) return true;  // Crawling
            if (byteFlag1 == 0x50 && byteFlag2 == 0x50 && byteFlag3 == 0x47 && byteFlag4 == 0x07) return true;  // Crawling
            if (byteFlag1 == 0x47 && byteFlag2 == 0x47 && byteFlag3 == 0x00 && byteFlag4 == 0xDE) return true;  // Crouching
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x06) return true;  // Running forward
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0xF4) return true;  // Sprinting
            if (byteFlag1 == 0x03 && byteFlag2 == 0x03 && byteFlag3 == 0x00 && byteFlag4 == 0x4D) return true;  // Jumping forward
            if (byteFlag1 == 0x17 && byteFlag2 == 0x02 && byteFlag3 == 0x00 && byteFlag4 == 0x93) return true;  // Rolling
            if (byteFlag1 == 0x13 && byteFlag2 == 0x13 && byteFlag3 == 0x00 && byteFlag4 == 0x61) return true;  // Climbing
            if (byteFlag1 == 0x2A && byteFlag2 == 0x00 && byteFlag3 == 0x00 && byteFlag4 == 0x83) return true;  // Using puzzle item
            if (byteFlag1 == 0x2B && byteFlag2 == 0x00 && byteFlag3 == 0x00 && byteFlag4 == 0x86) return true;  // Using puzzle item
            if (byteFlag1 == 0x21 && byteFlag2 == 0x21 && byteFlag3 == 0x00 && byteFlag4 == 0x6E) return true;  // On water
            if (byteFlag1 == 0x21 && byteFlag2 == 0x21 && byteFlag3 == 0x00 && byteFlag4 == 0x75) return true;  // Wading through water
            if (byteFlag1 == 0x0D && byteFlag2 == 0x0D && byteFlag3 == 0x00 && byteFlag4 == 0x6C) return true;  // Underwater
            if (byteFlag1 == 0x0D && byteFlag2 == 0x12 && byteFlag3 == 0x00 && byteFlag4 == 0x6C) return true;  // Underwater
            if (byteFlag1 == 0x12 && byteFlag2 == 0x12 && byteFlag3 == 0x00 && byteFlag4 == 0xC6) return true;  // Swimming forward
            if (byteFlag1 == 0x12 && byteFlag2 == 0x0D && byteFlag3 == 0x00 && byteFlag4 == 0xC8) return true;  // Swimming forward
            if (byteFlag1 == 0x18 && byteFlag2 == 0x18 && byteFlag3 == 0x00 && byteFlag4 == 0x46) return true;  // Sliding downhill
            if (byteFlag1 == 0x09 && byteFlag2 == 0x09 && byteFlag3 == 0x00 && byteFlag4 == 0x17) return true;  // Freefalling
            if (byteFlag1 == 0x00 && byteFlag2 == 0x00 && byteFlag3 == 0x00 && byteFlag4 == 0x40) return true;  // Jeep
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x34) return true;  // Jeep
            if (byteFlag1 == 0x0B && byteFlag2 == 0x0B && byteFlag3 == 0x00 && byteFlag4 == 0x38) return true;  // Jeep
            if (byteFlag1 == 0x0B && byteFlag2 == 0x0C && byteFlag3 == 0x00 && byteFlag4 == 0x38) return true;  // Jeep
            if (byteFlag1 == 0x0C && byteFlag2 == 0x0C && byteFlag3 == 0x47 && byteFlag4 == 0x3A) return true;  // Jeep
            if (byteFlag1 == 0x00 && byteFlag2 == 0x47 && byteFlag3 == 0x47 && byteFlag4 == 0x40) return true;  // Jeep
            if (byteFlag1 == 0x0F && byteFlag2 == 0x0F && byteFlag3 == 0x00 && byteFlag4 == 0x34) return true;  // Motorbike
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x24) return true;  // Motorbike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x08 && byteFlag3 == 0x00 && byteFlag4 == 0x38) return true;  // Motorbike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x08 && byteFlag3 == 0x00 && byteFlag4 == 0x39) return true;  // Motorbike
            if (byteFlag1 == 0x11 && byteFlag2 == 0x11 && byteFlag3 == 0x00 && byteFlag4 == 0x3A) return true;  // Motorbike
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x27) return true;  // Motorbike

            return false;
        }

        public bool IsLaraInVehicle(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 7];
            byte byteFlag2 = fileData[healthOffset - 6];
            byte byteFlag3 = fileData[healthOffset - 5];
            byte byteFlag4 = fileData[healthOffset - 4];

            if (byteFlag1 == 0x00 && byteFlag2 == 0x00 && byteFlag3 == 0x00 && byteFlag4 == 0x40) return true;  // Jeep
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x34) return true;  // Jeep
            if (byteFlag1 == 0x0B && byteFlag2 == 0x0B && byteFlag3 == 0x00 && byteFlag4 == 0x38) return true;  // Jeep
            if (byteFlag1 == 0x0B && byteFlag2 == 0x0C && byteFlag3 == 0x00 && byteFlag4 == 0x38) return true;  // Jeep
            if (byteFlag1 == 0x0C && byteFlag2 == 0x0C && byteFlag3 == 0x47 && byteFlag4 == 0x3A) return true;  // Jeep
            if (byteFlag1 == 0x00 && byteFlag2 == 0x47 && byteFlag3 == 0x47 && byteFlag4 == 0x40) return true;  // Jeep
            if (byteFlag1 == 0x0F && byteFlag2 == 0x0F && byteFlag3 == 0x00 && byteFlag4 == 0x34) return true;  // Motorbike
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x24) return true;  // Motorbike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x08 && byteFlag3 == 0x00 && byteFlag4 == 0x38) return true;  // Motorbike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x08 && byteFlag3 == 0x00 && byteFlag4 == 0x39) return true;  // Motorbike
            if (byteFlag1 == 0x11 && byteFlag2 == 0x11 && byteFlag3 == 0x00 && byteFlag4 == 0x3A) return true;  // Motorbike
            if (byteFlag1 == 0x01 && byteFlag2 == 0x01 && byteFlag3 == 0x00 && byteFlag4 == 0x27) return true;  // Motorbike

            return false;
        }

        public bool IsLaraFreefalling(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 7];
            byte byteFlag2 = fileData[healthOffset - 6];
            byte byteFlag3 = fileData[healthOffset - 5];
            byte byteFlag4 = fileData[healthOffset - 4];

            if (byteFlag1 == 0x09 && byteFlag2 == 0x09 && byteFlag3 == 0x00 && byteFlag4 == 0x17) return true;

            return false;
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
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR4 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR4)
                {
                    byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool savegamePresent = slotStatus != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR4) / SAVEGAME_SIZE;

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
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR4 + (i * SAVEGAME_SIZE);

                byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool savegamePresent = slotStatus != 0;

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR4) / SAVEGAME_SIZE;
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
