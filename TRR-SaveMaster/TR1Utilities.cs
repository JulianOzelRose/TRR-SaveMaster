using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR1Utilities
    {
        // Savegame constants & offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;
        private const int LEVEL_INDEX_OFFSET = 0x62C;
        private const int BASE_SAVEGAME_OFFSET_TR1 = 0x2000;
        private const int MAX_SAVEGAME_OFFSET_TR1 = 0x72000;
        private const int SAVEGAME_SIZE = 0x3800;
        private const int MAX_SAVEGAMES = 32;

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
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private int HEALTH_OFFSET = -1;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;

        // Level names
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
            if (HEALTH_OFFSET != -1)
            {
                UInt16 value = BitConverter.ToUInt16(fileData, savegameOffset + HEALTH_OFFSET);

                if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
                {
                    return savegameOffset + HEALTH_OFFSET;
                }
            }

            return -1;
        }

        private void DetermineOffsets(byte[] fileData)
        {
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

            if (platform != Platform.PC)
            {
                HEALTH_OFFSET -= 4;
                magnumAmmoOffset2 -= 4;
                uziAmmoOffset2 -= 4;
                shotgunAmmoOffset2 -= 4;
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

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            if (isPresent)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteMagnumAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + MAGNUM_AMMO_OFFSET, ammo);

            if (isPresent)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + magnumAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + magnumAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);

            if (isPresent)
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + uziAmmoOffset2, ammo);
            }
            else
            {
                WriteUInt16ToBuffer(fileData, savegameOffset + uziAmmoOffset2, 0);
            }
        }

        public void DisplayGameInfo(byte[] fileData, CheckBox chkPistols, CheckBox chkMagnums, CheckBox chkUzis,
            CheckBox chkShotgun, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudUziAmmo, NumericUpDown nudShotgunAmmo, NumericUpDown nudMagnumAmmo,
            NumericUpDown nudSaveNumber, TrackBar trbHealth, Label lblHealth, Label lblHealthError)
        {
            DetermineOffsets(fileData);

            GameMode gameMode = GetGameMode(fileData);

            nudSmallMedipacks.Enabled = gameMode == GameMode.Normal;
            nudLargeMedipacks.Enabled = gameMode == GameMode.Normal;

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

            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value);
            WriteMagnumAmmo(fileData, chkMagnums.Checked, (UInt16)nudMagnumAmmo.Value);
            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));

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
