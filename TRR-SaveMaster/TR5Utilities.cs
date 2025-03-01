using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR5Utilities
    {
        // Savegame constants
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
        private const int WEAPON_PRESENT = 0x9;
        private const int WEAPON_PRESENT_WITH_SIGHT = 0xD;

        // Platform
        //private Platform platform;

        // Strings
        private string savegamePath;

        // Misc
        private int savegameOffset;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private int MAX_HEALTH_OFFSET;
        private int MIN_HEALTH_OFFSET;


        private byte ReadByte(int offset)
        {
            using (FileStream fileStream = new FileStream(savegamePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                return (byte)fileStream.ReadByte();
            }
        }

        private void WriteByte(int offset, byte value)
        {
            using (FileStream fileStream = new FileStream(savegamePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
                byte[] byteData = { value };
                fileStream.Write(byteData, 0, byteData.Length);
            }
        }

        private UInt16 ReadUInt16(int offset)
        {
            byte lowerByte = ReadByte(offset);
            byte upperByte = ReadByte(offset + 1);

            return (UInt16)(lowerByte + (upperByte << 8));
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

        private Int32 ReadInt32(int offset)
        {
            byte byte1 = ReadByte(offset);
            byte byte2 = ReadByte(offset + 1);
            byte byte3 = ReadByte(offset + 2);
            byte byte4 = ReadByte(offset + 3);

            return (Int32)(byte1 + (byte2 << 8) + (byte3 << 16) + (byte4 << 24));
        }

        private void WriteInt32(int offset, Int32 value)
        {
            WriteByte(offset, (byte)value);
            WriteByte(offset + 1, (byte)(value >> 8));
            WriteByte(offset + 2, (byte)(value >> 16));
            WriteByte(offset + 3, (byte)(value >> 24));
        }

        private sbyte ReadInt8(int offset)
        {
            return (sbyte)ReadByte(offset);
        }

        private void WriteInt8(int offset, sbyte value)
        {
            WriteByte(offset, (byte)value);
        }

        private Int32 GetSaveNumber()
        {
            return ReadInt32(savegameOffset + SAVE_NUMBER_OFFSET);
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + LEVEL_INDEX_OFFSET);
        }

        public void SetSavegamePath(string path)
        {
            savegamePath = path;
        }

        public void SetSavegameOffset(int offset)
        {
            savegameOffset = offset;
        }

        public bool IsSavegamePresent()
        {
            return ReadByte(savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        private GameMode GetGameMode()
        {
            int gameMode = ReadByte(savegameOffset + GAME_MODE_OFFSET);
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
        }

        public void PopulateEmptySlots(ComboBox cmbSavegames)
        {
            if (cmbSavegames.Items.Count == MAX_SAVEGAMES)
            {
                return;
            }

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR5 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR5)
                {
                    Int32 saveNumber = ReadInt32(currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    byte levelIndex = ReadByte(currentSavegameOffset + LEVEL_INDEX_OFFSET);
                    bool savegamePresent = ReadByte(currentSavegameOffset + SLOT_STATUS_OFFSET) != 0;

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
                            GameMode gameMode = ReadByte(currentSavegameOffset + GAME_MODE_OFFSET) == 0 ? GameMode.Normal : GameMode.Plus;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode);
                            cmbSavegames.Items.Add(savegame);
                        }
                    }
                }
            }
        }

        public void UpdateDisplayName(Savegame savegame)
        {
            bool savegamePresent = ReadByte(savegame.Offset + SLOT_STATUS_OFFSET) != 0;

            if (savegamePresent)
            {
                byte levelIndex = ReadByte(savegame.Offset + LEVEL_INDEX_OFFSET);
                string levelName = levelNames[levelIndex];
                Int32 saveNumber = ReadInt32(savegame.Offset + SAVE_NUMBER_OFFSET);
                GameMode gameMode = ReadByte(savegame.Offset + GAME_MODE_OFFSET) == 0 ? GameMode.Normal : GameMode.Plus;

                savegame.UpdateDisplayName(levelName, saveNumber, gameMode);
            }
        }

        private bool IsPistolsPresent()
        {
            return ReadByte(savegameOffset + PISTOLS_OFFSET) != 0;
        }

        private bool IsRevolverPresent()
        {
            return ReadByte(savegameOffset + REVOLVER_OFFSET) != 0;
        }

        private bool IsDeaglePresent()
        {
            return ReadByte(savegameOffset + DEAGLE_OFFSET) != 0;
        }

        private bool IsShotgunPresent()
        {
            return ReadByte(savegameOffset + SHOTGUN_OFFSET) != 0;
        }

        private bool IsUziPresent()
        {
            return ReadByte(savegameOffset + UZI_OFFSET) != 0;
        }

        private bool IsHKGunPresent()
        {
            return ReadByte(savegameOffset + HK_GUN_OFFSET) != 0;
        }

        private bool IsGrapplingGunPresent()
        {
            return ReadByte(savegameOffset + GRAPPLING_GUN_OFFSET) != 0;
        }

        private UInt16 GetNumSmallMedipacks()
        {
            return ReadUInt16(savegameOffset + SMALL_MEDIPACK_OFFSET);
        }

        private UInt16 GetNumLargeMedipacks()
        {
            return ReadUInt16(savegameOffset + LARGE_MEDIPACK_OFFSET);
        }

        private UInt16 GetNumFlares()
        {
            return ReadUInt16(savegameOffset + FLARES_OFFSET);
        }

        private byte GetNumSecrets()
        {
            return ReadByte(savegameOffset + SECRETS_OFFSET);
        }

        private UInt16 GetUziAmmo()
        {
            return ReadUInt16(savegameOffset + UZI_AMMO_OFFSET);
        }

        private UInt16 GetRevolverAmmo()
        {
            return ReadUInt16(savegameOffset + REVOLVER_AMMO_OFFSET);
        }

        private UInt16 GetDeagleAmmo()
        {
            return ReadUInt16(savegameOffset + DEAGLE_AMMO_OFFSET);
        }

        private UInt16 GetShotgunNormalAmmo()
        {
            return (UInt16)(ReadUInt16(savegameOffset + SHOTGUN_NORMAL_AMMO_OFFSET) / 6);
        }

        private UInt16 GetShotgunWideshotAmmo()
        {
            return (UInt16)(ReadUInt16(savegameOffset + SHOTGUN_WIDESHOT_AMMO_OFFSET) / 6);
        }

        private UInt16 GetHKGunAmmo()
        {
            return ReadUInt16(savegameOffset + HK_GUN_AMMO_OFFSET);
        }

        private UInt16 GetGrapplingGunAmmo()
        {
            return ReadUInt16(savegameOffset + GRAPPLING_GUN_AMMO_OFFSET);
        }

        private UInt16 GetHealthValue(int healthOffset)
        {
            return ReadUInt16(healthOffset);
        }

        private void WriteSaveNumber(Int32 value)
        {
            WriteInt32(savegameOffset + SAVE_NUMBER_OFFSET, value);
        }

        private void WriteNumSmallMedipacks(UInt16 value)
        {
            WriteUInt16(savegameOffset + SMALL_MEDIPACK_OFFSET, value);
        }

        private void WriteNumLargeMedipacks(UInt16 value)
        {
            WriteUInt16(savegameOffset + LARGE_MEDIPACK_OFFSET, value);
        }

        private void WriteNumFlares(UInt16 value)
        {
            WriteUInt16(savegameOffset + FLARES_OFFSET, value);
        }

        private void WriteNumSecrets(byte value)
        {
            WriteByte(savegameOffset + SECRETS_OFFSET, value);
        }

        private void WritePistolsPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + PISTOLS_OFFSET, WEAPON_PRESENT);
            }
            else
            {
                WriteByte(savegameOffset + PISTOLS_OFFSET, 0);
            }
        }

        private void WriteRevolverPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + REVOLVER_OFFSET, WEAPON_PRESENT_WITH_SIGHT);
            }
            else
            {
                WriteByte(savegameOffset + REVOLVER_OFFSET, 0);
            }
        }

        private void WriteDeaglePresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + DEAGLE_OFFSET, WEAPON_PRESENT_WITH_SIGHT);
            }
            else
            {
                WriteByte(savegameOffset + DEAGLE_OFFSET, 0);
            }
        }

        private void WriteUziPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + UZI_OFFSET, WEAPON_PRESENT);
            }
            else
            {
                WriteByte(savegameOffset + UZI_OFFSET, 0);
            }
        }

        private void WriteHKGunPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + HK_GUN_OFFSET, WEAPON_PRESENT);
            }
            else
            {
                WriteByte(savegameOffset + HK_GUN_OFFSET, 0);
            }
        }

        private void WriteGrapplingGunPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + GRAPPLING_GUN_OFFSET, WEAPON_PRESENT_WITH_SIGHT);
            }
            else
            {
                WriteByte(savegameOffset + GRAPPLING_GUN_OFFSET, 0);
            }
        }

        private void WriteShotgunPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + SHOTGUN_OFFSET, WEAPON_PRESENT);
            }
            else
            {
                WriteByte(savegameOffset + SHOTGUN_OFFSET, 0);
            }
        }

        private void WriteRevolverAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + REVOLVER_AMMO_OFFSET, ammo);
        }

        private void WriteDeagleAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + DEAGLE_AMMO_OFFSET, ammo);
        }

        private void WriteUziAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + UZI_AMMO_OFFSET, ammo);
        }

        private void WriteHKGunAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + HK_GUN_AMMO_OFFSET, ammo);
        }

        private void WriteGrapplingGunAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + GRAPPLING_GUN_AMMO_OFFSET, ammo);
        }

        private void WriteShotgunNormalAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + SHOTGUN_NORMAL_AMMO_OFFSET, ammo);
        }

        private void WriteShotgunWideshotAmmo(UInt16 ammo)
        {
            WriteUInt16(savegameOffset + SHOTGUN_WIDESHOT_AMMO_OFFSET, ammo);
        }

        private void WriteHealthValue(UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                WriteUInt16(healthOffset, newHealth);
            }
        }

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

        public void DetermineOffsets()
        {
            byte levelIndex = GetLevelIndex();

            if (levelIndex == 1)        // Streets of Rome
            {
                MIN_HEALTH_OFFSET = 0x623;
                MAX_HEALTH_OFFSET = 0x623;
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
                MAX_HEALTH_OFFSET = 0x860;
            }
            else if (levelIndex == 6)   // Deepsea Dive
            {
                MIN_HEALTH_OFFSET = 0xA55;
                MAX_HEALTH_OFFSET = 0xADD;
            }
            else if (levelIndex == 7)   // Sinking Submarine
            {
                MIN_HEALTH_OFFSET = 0x9A3;
                MAX_HEALTH_OFFSET = 0xC1E;
            }
            else if (levelIndex == 8)   // Gallows Tree
            {
                MIN_HEALTH_OFFSET = 0x63B;
                MAX_HEALTH_OFFSET = 0x6DF;
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
                MAX_HEALTH_OFFSET = 0x65B;
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

        public void SetLevelParams(CheckBox chkRevolver, CheckBox chkDeagle, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudDeagleAmmo, CheckBox chkUzi, NumericUpDown nudUziAmmo, CheckBox chkShotgun,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, CheckBox chkGrapplingGun,
            NumericUpDown nudGrapplingGunAmmo, CheckBox chkHKGun, NumericUpDown nudHKGunAmmo, CheckBox chkPistols,
            NumericUpDown nudFlares)
        {
            byte levelIndex = GetLevelIndex();

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
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 5)   // The Submarine
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
                nudFlares.Enabled = true;
            }
            else if (levelIndex == 6)   // Deepsea Dive
            {
                chkRevolver.Enabled = false;
                chkDeagle.Enabled = false;
                nudRevolverAmmo.Enabled = false;
                nudDeagleAmmo.Enabled = false;
                chkUzi.Enabled = false;
                nudUziAmmo.Enabled = false;
                chkShotgun.Enabled = true;
                nudShotgunNormalAmmo.Enabled = true;
                nudShotgunWideshotAmmo.Enabled = true;
                chkGrapplingGun.Enabled = false;
                nudGrapplingGunAmmo.Enabled = false;
                chkHKGun.Enabled = false;
                nudHKGunAmmo.Enabled = false;
                chkPistols.Enabled = true;
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
                nudFlares.Enabled = false;
            }
        }

        public void DisplayGameInfo(NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudFlares, NumericUpDown nudSecrets, CheckBox chkPistols, CheckBox chkRevolver, CheckBox chkDeagle,
            CheckBox chkUzi, CheckBox chkHKGun, CheckBox chkGrapplingGun, CheckBox chkShotgun, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudDeagleAmmo, NumericUpDown nudUziAmmo, NumericUpDown nudHKGunAmmo, NumericUpDown nudGrapplingGunAmmo,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, TrackBar trbHealth, Label lblHealth,
            Label lblHealthError)
        {
            nudSaveNumber.Value = GetSaveNumber();
            nudSmallMedipacks.Value = GetNumSmallMedipacks();
            nudLargeMedipacks.Value = GetNumLargeMedipacks();
            nudFlares.Value = GetNumFlares();
            nudSecrets.Value = GetNumSecrets();

            nudUziAmmo.Value = GetUziAmmo();
            nudRevolverAmmo.Value = GetRevolverAmmo();
            nudShotgunNormalAmmo.Value = GetShotgunNormalAmmo();
            nudShotgunWideshotAmmo.Value = GetShotgunWideshotAmmo();
            nudHKGunAmmo.Value = GetHKGunAmmo();
            nudGrapplingGunAmmo.Value = GetGrapplingGunAmmo();

            chkPistols.Checked = IsPistolsPresent();
            chkShotgun.Checked = IsShotgunPresent();
            chkUzi.Checked = IsUziPresent();
            chkHKGun.Checked = IsHKGunPresent();
            chkGrapplingGun.Checked = IsGrapplingGunPresent();

            if (chkRevolver.Enabled)
            {
                chkRevolver.Checked = IsRevolverPresent();
                nudRevolverAmmo.Value = GetRevolverAmmo();

                chkDeagle.Checked = false;
                nudDeagleAmmo.Value = 0;
            }
            else if (chkDeagle.Enabled)
            {
                chkDeagle.Checked = IsDeaglePresent();
                nudDeagleAmmo.Value = GetDeagleAmmo();

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
                UInt16 health = GetHealthValue(healthOffset);
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
                trbHealth.Value = 1;
                lblHealthError.Visible = true;
                lblHealth.Visible = false;
            }
        }

        public void WriteChanges(NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudFlares, NumericUpDown nudSecrets, CheckBox chkPistols, CheckBox chkRevolver, CheckBox chkDeagle,
            CheckBox chkUzi, CheckBox chkHKGun, CheckBox chkGrapplingGun, CheckBox chkShotgun, NumericUpDown nudRevolverAmmo,
            NumericUpDown nudDeagleAmmo, NumericUpDown nudUziAmmo, NumericUpDown nudHKGunAmmo, NumericUpDown nudGrapplingGunAmmo,
            NumericUpDown nudShotgunNormalAmmo, NumericUpDown nudShotgunWideshotAmmo, TrackBar trbHealth)
        {
            DetermineOffsets();

            WriteSaveNumber((Int32)nudSaveNumber.Value);
            WriteNumSmallMedipacks((UInt16)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks((UInt16)nudLargeMedipacks.Value);
            WriteNumFlares((UInt16)nudFlares.Value);
            WriteNumSecrets((byte)nudSecrets.Value);

            WritePistolsPresent(chkPistols.Checked);
            WriteUziPresent(chkUzi.Checked);
            WriteHKGunPresent(chkHKGun.Checked);
            WriteGrapplingGunPresent(chkGrapplingGun.Checked);
            WriteShotgunPresent(chkShotgun.Checked);

            WriteUziAmmo((UInt16)nudUziAmmo.Value);
            WriteHKGunAmmo((UInt16)nudHKGunAmmo.Value);
            WriteGrapplingGunAmmo((UInt16)nudGrapplingGunAmmo.Value);
            WriteShotgunNormalAmmo((UInt16)(nudShotgunNormalAmmo.Value * 6));
            WriteShotgunWideshotAmmo((UInt16)(nudShotgunWideshotAmmo.Value * 6));

            if (chkRevolver.Enabled)
            {
                WriteRevolverPresent(chkRevolver.Checked);
            }
            else if (chkDeagle.Enabled)
            {
                WriteDeaglePresent(chkDeagle.Checked);
            }

            if (nudRevolverAmmo.Enabled)
            {
                WriteRevolverAmmo((UInt16)nudRevolverAmmo.Value);
            }
            else if (nudDeagleAmmo.Enabled)
            {
                WriteDeagleAmmo((UInt16)nudDeagleAmmo.Value);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue((UInt16)trbHealth.Value);
            }
        }

        private bool IsKnownByteFlagPattern(byte byteFlag1, byte byteFlag2, byte byteFlag3, byte byteFlag4)
        {
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x00 && byteFlag4 == 0x52) return true;
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x00 && byteFlag4 == 0x67) return true;
            if (byteFlag1 == 0x02 && byteFlag2 == 0x02 && byteFlag3 == 0x47 && byteFlag4 == 0x67) return true;
            if (byteFlag1 == 0x50 && byteFlag2 == 0x50 && byteFlag3 == 0x00 && byteFlag4 == 0x07) return true;
            if (byteFlag1 == 0x50 && byteFlag2 == 0x50 && byteFlag3 == 0x47 && byteFlag4 == 0x07) return true;
            if (byteFlag1 == 0x47 && byteFlag2 == 0x47 && byteFlag3 == 0x00 && byteFlag4 == 0xDE) return true;
            if (byteFlag1 == 0x0D && byteFlag2 == 0x0D && byteFlag3 == 0x00 && byteFlag4 == 0x6C) return true;  // Underwater

            return false;
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

                    if (flagIndex1 < 0 || flagIndex2 < 0 || flagIndex3 < 0 || flagIndex4 < 0 || flagIndex4 >= savegameData.Length)
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

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            int numSaves = 0;

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR5 + (i * SAVEGAME_SIZE);
                SetSavegameOffset(currentSavegameOffset);

                Int32 saveNumber = GetSaveNumber();
                byte levelIndex = GetLevelIndex();
                bool savegamePresent = IsSavegamePresent();


                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR5) / SAVEGAME_SIZE;
                    GameMode gameMode = GetGameMode();

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
