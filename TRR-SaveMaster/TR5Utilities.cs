using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR5Utilities
    {
        // Savegame constants & offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int SAVE_NUMBER_OFFSET = 0x008;
        private const int GAME_MODE_OFFSET = 0x01C;
        private const int LEVEL_INDEX_OFFSET = 0x26F;
        private const int BASE_SAVEGAME_OFFSET_TR5 = 0x14AE00;
        private const int MAX_SAVEGAME_OFFSET_TR5 = 0x33BB10;
        private const int SAVEGAME_SIZE = 0xA470;
        private const int MAX_SAVEGAMES = 32;

        // Item offsets
        private const int SMALL_MEDIPACK_OFFSET = 0x1BE;
        private const int LARGE_MEDIPACK_OFFSET = 0x1C0;
        private const int FLARES_OFFSET = 0x1C2;
        private const int SECRETS_OFFSET = 0x474;

        // Ammo offsets
        private const int UZI_AMMO_OFFSET = 0x1C6;
        private const int REVOLVER_AMMO_OFFSET = 0x1C8;
        private const int DEAGLE_AMMO_OFFSET = 0x1C8;
        private const int SHOTGUN_NORMAL_AMMO_OFFSET = 0x1CA;
        private const int SHOTGUN_WIDESHOT_AMMO_OFFSET = 0x1CC;
        private const int HK_GUN_AMMO_OFFSET = 0x1CE;
        private const int GRAPPLING_GUN_AMMO_OFFSET = 0x1D6;

        // Weapon offsets
        private const int PISTOLS_OFFSET = 0x194;
        private const int UZI_OFFSET = 0x195;
        private const int SHOTGUN_OFFSET = 0x196;
        private const int GRAPPLING_GUN_OFFSET = 0x197;
        private const int HK_GUN_OFFSET = 0x198;
        private const int REVOLVER_OFFSET = 0x19A;
        private const int DEAGLE_OFFSET = 0x19A;

        // Weapon byte flags
        private const byte WEAPON_PRESENT = 0x9;
        private const byte WEAPON_PRESENT_WITH_SILENCER = 0xB;
        private const byte WEAPON_PRESENT_WITH_SIGHT = 0xD;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private int MAX_HEALTH_OFFSET;
        private int MIN_HEALTH_OFFSET;

        // Misc
        private int savegameOffset;
        private string savegamePath;

        // Level names
        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
        {
            {  1, "Streets of Rome"                      },
            {  2, "Trajan's Markets"                     },
            {  3, "The Colosseum"                        },
            {  4, "The Base"                             },
            {  5, "The Submarine"                        },
            {  6, "Deepsea Dive"                         },
            {  7, "Sinking Submarine"                    },
            {  8, "Gallows Tree"                         },
            {  9, "Labyrinth"                            },
            { 10, "Old Mill"                             },
            { 11, "The 13th Floor"                       },
            { 12, "Escape with the Iris"                 },
            { 14, "Red Alert!"                           },
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

                if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
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

            if (levelIndex == 1)        // Streets of Rome
            {
                MIN_HEALTH_OFFSET = 0x623;
                MAX_HEALTH_OFFSET = 0x627;
            }
            else if (levelIndex == 2)   // Trajan's Markets
            {
                MIN_HEALTH_OFFSET = 0x6B7;
                MAX_HEALTH_OFFSET = 0x886;
            }
            else if (levelIndex == 3)   // The Colosseum
            {
                MIN_HEALTH_OFFSET = 0x605;
                MAX_HEALTH_OFFSET = 0x886;
            }
            else if (levelIndex == 4)   // The Base
            {
                MIN_HEALTH_OFFSET = 0x752;
                MAX_HEALTH_OFFSET = 0xBC9;
            }
            else if (levelIndex == 5)   // The Submarine
            {
                MIN_HEALTH_OFFSET = 0x6E2;
                MAX_HEALTH_OFFSET = 0x921;
            }
            else if (levelIndex == 6)   // Deepsea Dive
            {
                MIN_HEALTH_OFFSET = 0x3F8;
                MAX_HEALTH_OFFSET = 0xB52;
            }
            else if (levelIndex == 7)   // Sinking Submarine
            {
                MIN_HEALTH_OFFSET = 0x9A3;
                MAX_HEALTH_OFFSET = 0xC1E;
            }
            else if (levelIndex == 8)   // Gallows Tree
            {
                MIN_HEALTH_OFFSET = 0x63B;
                MAX_HEALTH_OFFSET = 0x71C;
            }
            else if (levelIndex == 9)   // Labyrinth
            {
                MIN_HEALTH_OFFSET = 0x693;
                MAX_HEALTH_OFFSET = 0x813;
            }
            else if (levelIndex == 10)  // Old Mill
            {
                MIN_HEALTH_OFFSET = 0x659;
                MAX_HEALTH_OFFSET = 0x8C9;
            }
            else if (levelIndex == 11)  // The 13th Floor
            {
                MIN_HEALTH_OFFSET = 0x65B;
                MAX_HEALTH_OFFSET = 0x65D;
            }
            else if (levelIndex == 12)  // Escape with the Iris
            {
                MIN_HEALTH_OFFSET = 0xAC2;
                MAX_HEALTH_OFFSET = 0x1BD7;
            }
            else if (levelIndex == 14)  // Red Alert!
            {
                MIN_HEALTH_OFFSET = 0x727;
                MAX_HEALTH_OFFSET = 0x8C3;
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

        private byte GetNumSecrets(byte[] fileData)
        {
            return fileData[savegameOffset + SECRETS_OFFSET];
        }

        private UInt16 GetUziAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + UZI_AMMO_OFFSET);
        }

        private UInt16 GetRevolverAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + REVOLVER_AMMO_OFFSET);
        }

        private UInt16 GetDeagleAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + DEAGLE_AMMO_OFFSET);
        }

        private UInt16 GetShotgunNormalAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_NORMAL_AMMO_OFFSET) / 6);
        }

        private UInt16 GetShotgunWideshotAmmo(byte[] fileData)
        {
            return (UInt16)(BitConverter.ToUInt16(fileData, savegameOffset + SHOTGUN_WIDESHOT_AMMO_OFFSET) / 6);
        }

        private UInt16 GetHKGunAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + HK_GUN_AMMO_OFFSET);
        }

        private UInt16 GetGrapplingGunAmmo(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + GRAPPLING_GUN_AMMO_OFFSET);
        }

        private byte GetRevolverFlag(byte[] fileData)
        {
            return fileData[savegameOffset + REVOLVER_OFFSET];
        }

        private byte GetDeagleFlag(byte[] fileData)
        {
            return fileData[savegameOffset + DEAGLE_OFFSET];
        }

        private byte GetHKGunFlag(byte[] fileData)
        {
            return fileData[savegameOffset + HK_GUN_OFFSET];
        }

        private UInt16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            return BitConverter.ToUInt16(fileData, healthOffset);
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

        private bool IsDeaglePresent(byte[] fileData)
        {
            return fileData[savegameOffset + DEAGLE_OFFSET] != 0;
        }

        private bool IsHKGunPresent(byte[] fileData)
        {
            return fileData[savegameOffset + HK_GUN_OFFSET] != 0;
        }

        private bool IsGrapplingGunPresent(byte[] fileData)
        {
            return fileData[savegameOffset + GRAPPLING_GUN_OFFSET] != 0;
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

        private void WriteNumSecrets(byte[] fileData, byte value)
        {
            fileData[savegameOffset + SECRETS_OFFSET] = value;
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

        private void WriteDeaglePresent(byte[] fileData, bool isPresent, byte prevDeagleFlag)
        {
            if (isPresent && prevDeagleFlag != 0)
            {
                fileData[savegameOffset + DEAGLE_OFFSET] = prevDeagleFlag;
            }
            else if (isPresent)
            {
                fileData[savegameOffset + DEAGLE_OFFSET] = WEAPON_PRESENT_WITH_SIGHT;
            }
            else
            {
                fileData[savegameOffset + DEAGLE_OFFSET] = 0;
            }
        }

        private void WriteHKGunPresent(byte[] fileData, bool isPresent, byte prevHKGunFlag)
        {
            if (isPresent && prevHKGunFlag != 0)
            {
                fileData[savegameOffset + HK_GUN_OFFSET] = prevHKGunFlag;
            }
            else if (isPresent)
            {
                fileData[savegameOffset + HK_GUN_OFFSET] = WEAPON_PRESENT_WITH_SILENCER;
            }
            else
            {
                fileData[savegameOffset + HK_GUN_OFFSET] = 0;
            }
        }

        private void WriteGrapplingGunPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + GRAPPLING_GUN_OFFSET] = WEAPON_PRESENT_WITH_SIGHT;
            }
            else
            {
                fileData[savegameOffset + GRAPPLING_GUN_OFFSET] = 0;
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

        private void WriteDeagleAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + DEAGLE_AMMO_OFFSET, ammo);
        }

        private void WriteShotgunNormalAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_NORMAL_AMMO_OFFSET, ammo);
        }

        private void WriteShotgunWideshotAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_WIDESHOT_AMMO_OFFSET, ammo);
        }

        private void WriteHKGunAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + HK_GUN_AMMO_OFFSET, ammo);
        }

        private void WriteGrapplingGunAmmo(byte[] fileData, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRAPPLING_GUN_AMMO_OFFSET, ammo);
        }

        private void WriteHealthValue(byte[] fileData, UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        public void SetLevelParams(byte[] fileData, CheckBox chkRevolver, CheckBox chkDeagle, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudDeagleAmmo, CheckBox chkUzi, NumericUpDown nudUziAmmo, CheckBox chkShotgun,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, CheckBox chkGrapplingGun,
            NumericUpDown nudGrapplingGunAmmo, CheckBox chkHKGun, NumericUpDown nudHKGunAmmo, CheckBox chkPistols,
            NumericUpDown nudFlares, Label lblPistolAmmo)
        {
            byte levelIndex = GetLevelIndex(fileData);

            if (levelIndex == 1)        // Streets of Rome
            {
                chkRevolver.Enabled = true;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = true;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 2)   // Trajan's Markets
            {
                chkRevolver.Enabled = true;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = true;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 3)   // The Colosseum
            {
                chkRevolver.Enabled = true;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = true;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = true;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 4)   // The Base
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = true;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = true;
                chkUzi.Enabled = true;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 5)   // The Submarine
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = true;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 6)   // Deepsea Dive
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = true;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 7)   // Sinking Submarine
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = true;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = true;
                chkUzi.Enabled = true;
                nudUziAmmo.Enabled = true;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                lblPistolAmmo.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 8)   // Gallows Tree
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = false;
                lblPistolAmmo.Enabled = false;
                nudFlares.Enabled = false;
            }
            else if (levelIndex == 9)   // Labyrinth
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = false;
                lblPistolAmmo.Enabled = false;
                nudFlares.Enabled = false;
            }
            else if (levelIndex == 10)  // Old Mill
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = false;
                lblPistolAmmo.Enabled = false;
                nudFlares.Enabled = false;
            }
            else if (levelIndex == 11)  // The 13th Floor
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = true;
                nudHKGunAmmo.Enabled = true;
                chkPistols.Enabled = false;
                lblPistolAmmo.Enabled = false;
                nudFlares.Enabled = false;
            }
            else if (levelIndex == 12)  // Escape with the Iris
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = true;
                nudHKGunAmmo.Enabled = true;
                chkPistols.Enabled = false;
                lblPistolAmmo.Enabled = false;
                nudFlares.Enabled = false;
            }
            else if (levelIndex == 14)  // Red Alert!
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = false;
                nudShotgunNormalAmmo.Enabled = false;
                nudShotgunWideshotAmmo.Enabled = false;
                chkGrapplingGun.Enabled = true;
                nudGrapplingGunAmmo.Enabled = true;
                chkHKGun.Enabled = true;
                nudHKGunAmmo.Enabled = true;
                chkPistols.Enabled = false;
                lblPistolAmmo.Enabled = false;
                nudFlares.Enabled = false;
            }
        }

        public void DisplayGameInfo(byte[] fileData, NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudFlares, NumericUpDown nudSecrets, CheckBox chkPistols, CheckBox chkRevolver, CheckBox chkDeagle,
            CheckBox chkUzi, CheckBox chkHKGun, CheckBox chkGrapplingGun, CheckBox chkShotgun, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudDeagleAmmo, NumericUpDown nudUziAmmo, NumericUpDown nudHKGunAmmo, NumericUpDown nudGrapplingGunAmmo,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, TrackBar trbHealth, Label lblHealth,
            Label lblHealthError)
        {
            DetermineOffsets(fileData);

            nudSaveNumber.Value = GetSaveNumber(fileData);
            nudSmallMedipacks.Value = GetNumSmallMedipacks(fileData);
            nudLargeMedipacks.Value = GetNumLargeMedipacks(fileData);
            nudSecrets.Value = GetNumSecrets(fileData);

            nudUziAmmo.Value = GetUziAmmo(fileData);
            nudRevolverAmmo.Value = GetRevolverAmmo(fileData);
            nudShotgunNormalAmmo.Value = GetShotgunNormalAmmo(fileData);
            nudShotgunWideshotAmmo.Value = GetShotgunWideshotAmmo(fileData);
            nudHKGunAmmo.Value = GetHKGunAmmo(fileData);
            nudGrapplingGunAmmo.Value = GetGrapplingGunAmmo(fileData);

            chkPistols.Checked = IsPistolsPresent(fileData);
            chkShotgun.Checked = IsShotgunPresent(fileData);
            chkUzi.Checked = IsUziPresent(fileData);
            chkHKGun.Checked = IsHKGunPresent(fileData);
            chkGrapplingGun.Checked = IsGrapplingGunPresent(fileData);

            if (nudFlares.Enabled)
            {
                nudFlares.Value = GetNumFlares(fileData);
            }
            else
            {
                nudFlares.Value = 0;
            }

            if (chkRevolver.Enabled)
            {
                chkRevolver.Checked = IsRevolverPresent(fileData);
                nudRevolverAmmo.Value = GetRevolverAmmo(fileData);

                chkDeagle.Checked = false;
                nudDeagleAmmo.Value = 0;
            }
            else if (chkDeagle.Enabled)
            {
                chkDeagle.Checked = IsDeaglePresent(fileData);
                nudDeagleAmmo.Value = GetDeagleAmmo(fileData);

                chkRevolver.Checked = false;
                nudRevolverAmmo.Value = 0;
            }
            else
            {
                chkRevolver.Checked = false;
                nudRevolverAmmo.Value = 0;

                chkDeagle.Checked = false;
                nudDeagleAmmo.Value = 0;
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

        public void WriteChanges(byte[] fileData, NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudFlares, NumericUpDown nudSecrets, CheckBox chkPistols, CheckBox chkRevolver, CheckBox chkDeagle,
            CheckBox chkUzi, CheckBox chkHKGun, CheckBox chkGrapplingGun, CheckBox chkShotgun, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudDeagleAmmo, NumericUpDown nudUziAmmo, NumericUpDown nudHKGunAmmo, NumericUpDown nudGrapplingGunAmmo,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, TrackBar trbHealth)
        {
            DetermineOffsets(fileData);

            byte prevHKGunFlag = GetHKGunFlag(fileData);

            WriteSaveNumber(fileData, (Int32)nudSaveNumber.Value);
            WriteNumSmallMedipacks(fileData, (UInt16)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks(fileData, (UInt16)nudLargeMedipacks.Value);
            WriteNumSecrets(fileData, (byte)nudSecrets.Value);

            WritePistolsPresent(fileData, chkPistols.Checked);
            WriteUziPresent(fileData, chkUzi.Checked);
            WriteHKGunPresent(fileData, chkHKGun.Checked, prevHKGunFlag);
            WriteGrapplingGunPresent(fileData, chkGrapplingGun.Checked);
            WriteShotgunPresent(fileData, chkShotgun.Checked);

            WriteUziAmmo(fileData, (UInt16)nudUziAmmo.Value);
            WriteHKGunAmmo(fileData, (UInt16)nudHKGunAmmo.Value);
            WriteGrapplingGunAmmo(fileData, (UInt16)nudGrapplingGunAmmo.Value);
            WriteShotgunNormalAmmo(fileData, (UInt16)(nudShotgunNormalAmmo.Value * 6));
            WriteShotgunWideshotAmmo(fileData, (UInt16)(nudShotgunWideshotAmmo.Value * 6));

            if (nudFlares.Enabled)
            {
                WriteNumFlares(fileData, (UInt16)nudFlares.Value);
            }

            if (chkRevolver.Enabled)
            {
                byte prevRevolverFlag = GetRevolverFlag(fileData);
                WriteRevolverPresent(fileData, chkRevolver.Checked, prevRevolverFlag);
            }
            else if (chkDeagle.Enabled)
            {
                byte prevDeagleFlag = GetDeagleFlag(fileData);
                WriteDeaglePresent(fileData, chkDeagle.Checked, prevDeagleFlag);
            }

            if (nudRevolverAmmo.Enabled)
            {
                WriteRevolverAmmo(fileData, (UInt16)nudRevolverAmmo.Value);
            }
            else if (nudDeagleAmmo.Enabled)
            {
                WriteDeagleAmmo(fileData, (UInt16)nudDeagleAmmo.Value);
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
            if (byteFlag1 == 0x09 && byteFlag2 == 0x09 && byteFlag3 == 0x47 && byteFlag4 == 0x17) return true;  // Freefalling
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x00 && byteFlag4 == 0x18) return true;  // Fall recovery

            return false;
        }

        public bool IsLaraFreefalling(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 7];
            byte byteFlag2 = fileData[healthOffset - 6];
            byte byteFlag3 = fileData[healthOffset - 5];
            byte byteFlag4 = fileData[healthOffset - 4];

            if (byteFlag1 == 0x09 && byteFlag2 == 0x09 && byteFlag3 == 0x00 && byteFlag4 == 0x17) return true;
            if (byteFlag1 == 0x09 && byteFlag2 == 0x09 && byteFlag3 == 0x47 && byteFlag4 == 0x17) return true;

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
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR5 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR5)
                {
                    byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool savegamePresent = slotStatus != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR5) / SAVEGAME_SIZE;

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
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR5 + (i * SAVEGAME_SIZE);

                byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool savegamePresent = slotStatus != 0;

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR5) / SAVEGAME_SIZE;
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
