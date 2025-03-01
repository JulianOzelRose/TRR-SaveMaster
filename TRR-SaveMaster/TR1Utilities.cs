using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR1Utilities
    {
        // Savegame constants
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;
        private const int LEVEL_INDEX_OFFSET = 0x62C;
        private const int BASE_SAVEGAME_OFFSET_TR1 = 0x2000;
        private const int MAX_SAVEGAME_OFFSET_TR1 = 0x72000;
        private const int SAVEGAME_SIZE = 0x3800;
        private const int MAX_SAVEGAMES = 32;

        // Static offsets
        private const int magnumAmmoOffset = 0x4C2;
        private const int uziAmmoOffset = 0x4C4;
        private const int shotgunAmmoOffset = 0x4C6;
        private const int smallMedipackOffset = 0x4C8;
        private const int largeMedipackOffset = 0x4C9;
        private const int weaponsConfigNumOffset = 0x4EC;

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
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private List<int> healthOffsets = new List<int>();

        // Platform
        private Platform platform;

        // Strings
        private string savegamePath;

        // Misc
        private int savegameOffset;

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

        public bool IsSavegamePresent()
        {
            return ReadByte(savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        private GameMode GetGameMode()
        {
            int gameMode = ReadByte(savegameOffset + GAME_MODE_OFFSET);
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
        }

        private byte GetNumSmallMedipacks()
        {
            return ReadByte(savegameOffset + smallMedipackOffset);
        }

        private byte GetNumLargeMedipacks()
        {
            return ReadByte(savegameOffset + largeMedipackOffset);
        }

        private Int32 GetSaveNumber()
        {
            return ReadInt32(savegameOffset + SAVE_NUMBER_OFFSET);
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + LEVEL_INDEX_OFFSET);
        }

        private byte GetWeaponsConfigNum()
        {
            return ReadByte(savegameOffset + weaponsConfigNumOffset);
        }

        private UInt16 GetUziAmmo()
        {
            return ReadUInt16(savegameOffset + uziAmmoOffset);
        }

        private UInt16 GetMagnumAmmo()
        {
            return ReadUInt16(savegameOffset + magnumAmmoOffset);
        }

        private UInt16 GetShotgunAmmo()
        {
            return ReadUInt16(savegameOffset + shotgunAmmoOffset);
        }

        public int GetHealthOffset()
        {
            for (int i = 0; i < healthOffsets.Count; i++)
            {
                UInt16 value = ReadUInt16(savegameOffset + healthOffsets[i]);

                if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
                {
                    byte byteFlag1 = ReadByte(savegameOffset + healthOffsets[i] - 10);
                    byte byteFlag2 = ReadByte(savegameOffset + healthOffsets[i] - 9);
                    byte byteFlag3 = ReadByte(savegameOffset + healthOffsets[i] - 8);

                    if (IsKnownByteFlagPattern(byteFlag1, byteFlag2, byteFlag3))
                    {
                        return (savegameOffset + healthOffsets[i]);
                    }
                }
            }

            return -1;
        }

        private UInt16 GetHealthValue(int healthOffset)
        {
            return ReadUInt16(healthOffset);
        }

        private void WriteSaveNumber(Int32 value)
        {
            WriteInt32(savegameOffset + SAVE_NUMBER_OFFSET, value);
        }

        private void WriteNumSmallMedipacks(byte value)
        {
            WriteByte(savegameOffset + smallMedipackOffset, value);
        }

        private void WriteNumLargeMedipacks(byte value)
        {
            WriteByte(savegameOffset + largeMedipackOffset, value);
        }

        private void WriteWeaponsConfigNum(byte value)
        {
            WriteByte(savegameOffset + weaponsConfigNumOffset, value);
        }

        private void WriteHealthValue(UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                WriteUInt16(healthOffset, newHealth);
            }
        }

        private void WriteUziAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + uziAmmoOffset, ammo);

            if (isPresent)
            {
                WriteUInt16(savegameOffset + uziAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16(savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private void WriteShotgunAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + shotgunAmmoOffset, ammo);

            if (isPresent)
            {
                WriteUInt16(savegameOffset + shotgunAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16(savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteMagnumAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + magnumAmmoOffset, ammo);

            if (isPresent)
            {
                WriteUInt16(savegameOffset + magnumAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16(savegameOffset + magnumAmmoOffset2, 0);
            }
        }

        private bool IsKnownByteFlagPattern(byte byteFlag1, byte byteFlag2, byte byteFlag3)
        {
            if (byteFlag1 == 0x02 && byteFlag2 == 0x00 && byteFlag3 == 0x02) return true;       // Standing
            if (byteFlag1 == 0x13 && byteFlag2 == 0x00 && byteFlag3 == 0x13) return true;       // Climbing
            if (byteFlag1 == 0x21 && byteFlag2 == 0x00 && byteFlag3 == 0x21) return true;       // On water
            if (byteFlag1 == 0x0D && byteFlag2 == 0x00 && byteFlag3 == 0x0D) return true;       // Underwater
            if (byteFlag1 == 0x17 && byteFlag2 == 0x00 && byteFlag3 == 0x02) return true;       // Rolling
            if (byteFlag1 == 0x41 && byteFlag2 == 0x00 && byteFlag3 == 0x02) return true;       // Walking on top of water
            if (byteFlag1 == 0x41 && byteFlag2 == 0x00 && byteFlag3 == 0x41) return true;       // Walking on top of water 2
            if (byteFlag1 == 0x03 && byteFlag2 == 0x00 && byteFlag3 == 0x03) return true;       // Sliding forward
            if (byteFlag1 == 0x20 && byteFlag2 == 0x00 && byteFlag3 == 0x20) return true;       // Sliding backward

            return false;
        }

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

        private void SetHealthOffsets(params int[] offsets)
        {
            healthOffsets.Clear();

            for (int i = 0; i < offsets.Length; i++)
            {
                healthOffsets.Add(offsets[i]);
            }
        }

        private void DetermineOffsets()
        {
            byte levelIndex = GetLevelIndex();

            healthOffsets.Clear();

            if (levelIndex == 1)        // Caves
            {
                magnumAmmoOffset2 = 0x1079;
                uziAmmoOffset2 = 0x1081;
                shotgunAmmoOffset2 = 0x1089;

                SetHealthOffsets(0x825);
            }
            else if (levelIndex == 2)   // City of Vilacamba
            {
                magnumAmmoOffset2 = 0x1999;
                uziAmmoOffset2 = 0x19A1;
                shotgunAmmoOffset2 = 0x19A9;

                SetHealthOffsets(0x181D);
            }
            else if (levelIndex == 3)   // Lost Valley
            {
                magnumAmmoOffset2 = 0x1057;
                uziAmmoOffset2 = 0x105F;
                shotgunAmmoOffset2 = 0x1067;

                SetHealthOffsets(0x82D);
            }
            else if (levelIndex == 4)   // Tomb of Qualopec
            {
                magnumAmmoOffset2 = 0x137B;
                uziAmmoOffset2 = 0x1383;
                shotgunAmmoOffset2 = 0x138B;

                SetHealthOffsets(0xC41);
            }
            else if (levelIndex == 5)   // St. Francis' Folly
            {
                magnumAmmoOffset2 = 0x1C55;
                uziAmmoOffset2 = 0x1C5D;
                shotgunAmmoOffset2 = 0x1C65;

                SetHealthOffsets(0x1A39);
            }
            else if (levelIndex == 6)   // Colosseum
            {
                magnumAmmoOffset2 = 0x1747;
                uziAmmoOffset2 = 0x174F;
                shotgunAmmoOffset2 = 0x1757;

                SetHealthOffsets(0xF4F);
            }
            else if (levelIndex == 7)   // Palace Midas
            {
                magnumAmmoOffset2 = 0x1C21;
                uziAmmoOffset2 = 0x1C29;
                shotgunAmmoOffset2 = 0x1C31;

                SetHealthOffsets(0x82F);
            }
            else if (levelIndex == 8)   // The Cistern
            {
                magnumAmmoOffset2 = 0x1B8D;
                uziAmmoOffset2 = 0x1B95;
                shotgunAmmoOffset2 = 0x1B9D;

                SetHealthOffsets(0x197B);
            }
            else if (levelIndex == 9)   // Tomb of Tihocan
            {
                magnumAmmoOffset2 = 0x168F;
                uziAmmoOffset2 = 0x1697;
                shotgunAmmoOffset2 = 0x169F;

                SetHealthOffsets(0xA29);
            }
            else if (levelIndex == 10)  // City of Khamoon
            {
                magnumAmmoOffset2 = 0x1557;
                uziAmmoOffset2 = 0x155F;
                shotgunAmmoOffset2 = 0x1567;

                SetHealthOffsets(0x827);
            }
            else if (levelIndex == 11)  // Obelisk of Khamoon
            {
                magnumAmmoOffset2 = 0x165F;
                uziAmmoOffset2 = 0x1667;
                shotgunAmmoOffset2 = 0x166F;

                SetHealthOffsets(0xA8F);
            }
            else if (levelIndex == 12)  // Sanctuary of the Scion
            {
                magnumAmmoOffset2 = 0x1307;
                uziAmmoOffset2 = 0x130F;
                shotgunAmmoOffset2 = 0x1317;

                SetHealthOffsets(0x114F);
            }
            else if (levelIndex == 13)  // Natla's Mines
            {
                magnumAmmoOffset2 = 0x165D;
                uziAmmoOffset2 = 0x1665;
                shotgunAmmoOffset2 = 0x166D;

                SetHealthOffsets(0x12D3);
            }
            else if (levelIndex == 14)  // Atlantis
            {
                magnumAmmoOffset2 = 0x245B;
                uziAmmoOffset2 = 0x2463;
                shotgunAmmoOffset2 = 0x246B;

                SetHealthOffsets(0xD0F);
            }
            else if (levelIndex == 15)  // The Great Pyramid
            {
                magnumAmmoOffset2 = 0x17A1;
                uziAmmoOffset2 = 0x17A9;
                shotgunAmmoOffset2 = 0x17B1;

                SetHealthOffsets(0x10FD);
            }
            else if (levelIndex == 16)   // Return to Egypt
            {
                magnumAmmoOffset2 = 0x1F0D;
                uziAmmoOffset2 = 0x1F15;
                shotgunAmmoOffset2 = 0x1F1D;

                SetHealthOffsets(0x8F3);
            }
            else if (levelIndex == 17)   // Temple of the Cat
            {
                magnumAmmoOffset2 = 0x25A9;
                uziAmmoOffset2 = 0x25B1;
                shotgunAmmoOffset2 = 0x25B9;

                SetHealthOffsets(0xE1D);
            }
            else if (levelIndex == 18)  // Atlantean Stronghold
            {
                magnumAmmoOffset2 = 0x1EDB;
                uziAmmoOffset2 = 0x1EE3;
                shotgunAmmoOffset2 = 0x1EEB;

                SetHealthOffsets(0xE35);
            }
            else if (levelIndex == 19)  // The Hive
            {
                magnumAmmoOffset2 = 0x2723;
                uziAmmoOffset2 = 0x272B;
                shotgunAmmoOffset2 = 0x2733;

                SetHealthOffsets(0x10DF);
            }

            if (platform != Platform.PC)
            {
                for (int i = 0; i < healthOffsets.Count; i++)
                {
                    healthOffsets[i] -= 4;
                }

                magnumAmmoOffset2 -= 4;
                uziAmmoOffset2 -= 4;
                shotgunAmmoOffset2 -= 4;
            }
        }

        public void DisplayGameInfo(CheckBox chkPistols, CheckBox chkMagnums, CheckBox chkUzis,
            CheckBox chkShotgun, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudUziAmmo, NumericUpDown nudShotgunAmmo, NumericUpDown nudMagnumAmmo,
            NumericUpDown nudSaveNumber, TrackBar trbHealth, Label lblHealth, Label lblHealthError)
        {
            DetermineOffsets();

            GameMode gameMode = GetGameMode();

            nudSmallMedipacks.Enabled = gameMode == GameMode.Normal;
            nudLargeMedipacks.Enabled = gameMode == GameMode.Normal;

            byte weaponsConfigNum = GetWeaponsConfigNum();

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

            nudSaveNumber.Value = GetSaveNumber();
            nudSmallMedipacks.Value = GetNumSmallMedipacks();
            nudLargeMedipacks.Value = GetNumLargeMedipacks();

            nudUziAmmo.Value = GetUziAmmo();
            nudMagnumAmmo.Value = GetMagnumAmmo();
            nudShotgunAmmo.Value = GetShotgunAmmo() / 6;

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
                trbHealth.Value = trbHealth.Minimum;
                lblHealthError.Visible = true;
                lblHealth.Visible = false;
            }
        }

        public void WriteChanges(CheckBox chkPistols, CheckBox chkMagnums, CheckBox chkUzis,
            CheckBox chkShotgun, NumericUpDown nudSaveNumber, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, NumericUpDown nudUziAmmo, NumericUpDown nudMagnumAmmo,
            NumericUpDown nudShotgunAmmo, TrackBar trbHealth)
        {
            WriteSaveNumber((Int32)nudSaveNumber.Value);
            WriteNumSmallMedipacks((byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks((byte)nudLargeMedipacks.Value);

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += WEAPON_PISTOLS;
            if (chkMagnums.Checked) newWeaponsConfigNum += WEAPON_MAGNUMS;
            if (chkUzis.Checked) newWeaponsConfigNum += WEAPON_UZIS;
            if (chkShotgun.Checked) newWeaponsConfigNum += WEAPON_SHOTGUN;

            WriteWeaponsConfigNum(newWeaponsConfigNum);

            WriteUziAmmo(chkUzis.Checked, (UInt16)nudUziAmmo.Value);
            WriteMagnumAmmo(chkMagnums.Checked, (UInt16)nudMagnumAmmo.Value);
            WriteShotgunAmmo(chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));

            if (trbHealth.Enabled)
            {
                WriteHealthValue((UInt16)trbHealth.Value);
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

        public void PopulateEmptySlots(ComboBox cmbSavegames)
        {
            if (cmbSavegames.Items.Count == 32)
            {
                return;
            }

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR1)
                {
                    Int32 saveNumber = ReadInt32(currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    byte levelIndex = ReadByte(currentSavegameOffset + LEVEL_INDEX_OFFSET);
                    bool savegamePresent = ReadByte(currentSavegameOffset + SLOT_STATUS_OFFSET) != 0;

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
                            GameMode gameMode = ReadByte(currentSavegameOffset + GAME_MODE_OFFSET) == 0 ? GameMode.Normal : GameMode.Plus;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode);
                            cmbSavegames.Items.Add(savegame);
                        }
                    }
                }
            }
        }

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            int numSaves = 0;

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_SIZE);
                SetSavegameOffset(currentSavegameOffset);

                Int32 saveNumber = GetSaveNumber();
                byte levelIndex = GetLevelIndex();
                bool savegamePresent = IsSavegamePresent();

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR1) / SAVEGAME_SIZE;
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
