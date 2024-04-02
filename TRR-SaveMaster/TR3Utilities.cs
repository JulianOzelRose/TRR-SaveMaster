using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR3Utilities
    {
        // Static offsets
        private const int slotStatusOffset = 0x004;
        private const int gameModeOffset = 0x008;
        private const int saveNumberOffset = 0x00C;
        private const int levelIndexOffset = 0x8D6;

        // Dynamic offsets
        private int smallMedipackOffset;
        private int largeMedipackOffset;
        private int flaresOffset;
        private int weaponsConfigNumOffset;
        private int collectibleCrystalsOffset;
        private int harpoonGunOffset;
        private int deagleAmmoOffset;
        private int harpoonGunAmmoOffset;
        private int mp5AmmoOffset;
        private int uziAmmoOffset;
        private int rocketLauncherAmmoOffset;
        private int grenadeLauncherAmmoOffset;
        private int shotgunAmmoOffset;
        private int harpoonGunAmmoOffset2;
        private int deagleAmmoOffset2;
        private int mp5AmmoOffset2;
        private int uziAmmoOffset2;
        private int rocketLauncherAmmoOffset2;
        private int grenadeLauncherAmmoOffset2;
        private int shotgunAmmoOffset2;

        // Constants
        private const int BASE_SAVEGAME_OFFSET_TR3 = 0xE2000;
        private const int MAX_SAVEGAME_OFFSET_TR3 = 0x152000;
        private const int SAVEGAME_ITERATOR = 0x3800;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private int MAX_HEALTH_OFFSET;
        private int MIN_HEALTH_OFFSET;

        // Platform
        private Platform platform;

        // Strings
        private string savegamePath;

        // Misc
        private int savegameOffset;
        private int secondaryAmmoIndex = -1;

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
            return ReadByte(savegameOffset + slotStatusOffset) != 0;
        }

        private GameMode GetGameMode()
        {
            int gameMode = ReadByte(savegameOffset + gameModeOffset);
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
        }

        private Int32 GetSaveNumber()
        {
            return ReadInt32(savegameOffset + saveNumberOffset);
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + levelIndexOffset);
        }

        private byte GetWeaponsConfigNum()
        {
            return ReadByte(savegameOffset + weaponsConfigNumOffset);
        }

        private byte GetNumSmallMedipacks()
        {
            return ReadByte(savegameOffset + smallMedipackOffset);
        }

        private byte GetNumLargeMedipacks()
        {
            return ReadByte(savegameOffset + largeMedipackOffset);
        }

        private byte GetNumFlares()
        {
            return ReadByte(savegameOffset + flaresOffset);
        }

        private byte GetNumCollectibleCrystals()
        {
            return ReadByte(savegameOffset + collectibleCrystalsOffset);
        }

        private UInt16 GetShotgunAmmo()
        {
            return ReadUInt16(savegameOffset + shotgunAmmoOffset);
        }

        private UInt16 GetUziAmmo()
        {
            return ReadUInt16(savegameOffset + uziAmmoOffset);
        }

        private UInt16 GetMP5Ammo()
        {
            return ReadUInt16(savegameOffset + mp5AmmoOffset);
        }

        private UInt16 GetHarpoonGunAmmo()
        {
            return ReadUInt16(savegameOffset + harpoonGunAmmoOffset);
        }

        private UInt16 GetDeagleAmmo()
        {
            return ReadUInt16(savegameOffset + deagleAmmoOffset);
        }

        private UInt16 GetGrenadeLauncherAmmo()
        {
            return ReadUInt16(savegameOffset + grenadeLauncherAmmoOffset);
        }

        private UInt16 GetRocketLauncherAmmo()
        {
            return ReadUInt16(savegameOffset + rocketLauncherAmmoOffset);
        }

        public int GetHealthOffset()
        {
            for (int offset = MIN_HEALTH_OFFSET; offset <= MAX_HEALTH_OFFSET; offset += 0x1A)
            {
                UInt16 value = ReadUInt16(savegameOffset + offset);

                if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
                {
                    byte byteFlag1 = ReadByte(savegameOffset + offset - 10);
                    byte byteFlag2 = ReadByte(savegameOffset + offset - 9);
                    byte byteFlag3 = ReadByte(savegameOffset + offset - 8);

                    if (IsKnownByteFlagPattern(byteFlag1, byteFlag2, byteFlag3))
                    {
                        return (savegameOffset + offset);
                    }
                }
            }

            return -1;
        }

        private UInt16 GetHealthValue(int healthOffset)
        {
            return ReadUInt16(healthOffset);
        }

        private bool IsHarpoonGunPresent()
        {
            return ReadByte(savegameOffset + harpoonGunOffset) != 0;
        }

        private void WriteSaveNumber(Int32 value)
        {
            WriteInt32(savegameOffset + saveNumberOffset, value);
        }

        private void WriteNumSmallMedipacks(byte value)
        {
            WriteByte(savegameOffset + smallMedipackOffset, value);
        }

        private void WriteNumLargeMedipacks(byte value)
        {
            WriteByte(savegameOffset + largeMedipackOffset, value);
        }

        private void WriteNumFlares(byte value)
        {
            WriteByte(savegameOffset + flaresOffset, value);
        }

        private void WriteWeaponsConfigNum(byte value)
        {
            WriteByte(savegameOffset + weaponsConfigNumOffset, value);
        }

        private void WriteNumCollectibleCrystals(byte value)
        {
            WriteByte(savegameOffset + collectibleCrystalsOffset, value);
        }

        private void WriteHealthValue(UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                WriteUInt16(healthOffset, newHealth);
            }
        }

        private void WriteHarpoonGunPresent(bool isPresent)
        {
            if (isPresent)
            {
                WriteByte(savegameOffset + harpoonGunOffset, 1);
            }
            else
            {
                WriteByte(savegameOffset + harpoonGunOffset, 0);
            }
        }

        private void WriteShotgunAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + shotgunAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + shotgunAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteDeagleAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + deagleAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + deagleAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + deagleAmmoOffset2, 0);
            }
        }

        private void WriteGrenadeLauncherAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + grenadeLauncherAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + grenadeLauncherAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + grenadeLauncherAmmoOffset2, 0);
            }
        }

        private void WriteRocketLauncherAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + rocketLauncherAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + rocketLauncherAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + rocketLauncherAmmoOffset2, 0);
            }
        }

        private void WriteHarpoonGunAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + harpoonGunAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + harpoonGunAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + harpoonGunAmmoOffset2, 0);
            }
        }

        private void WriteMP5Ammo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + mp5AmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + mp5AmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + mp5AmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + uziAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + uziAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private void DetermineOffsets()
        {
            byte levelIndex = GetLevelIndex();

            deagleAmmoOffset = 0x66 + (levelIndex * 0x40);
            uziAmmoOffset = 0x68 + (levelIndex * 0x40);
            shotgunAmmoOffset = 0x6A + (levelIndex * 0x40);
            mp5AmmoOffset = 0x6C + (levelIndex * 0x40);
            rocketLauncherAmmoOffset = 0x6E + (levelIndex * 0x40);
            harpoonGunAmmoOffset = 0x70 + (levelIndex * 0x40);
            grenadeLauncherAmmoOffset = 0x72 + (levelIndex * 0x40);

            smallMedipackOffset = 0x74 + (levelIndex * 0x40);
            largeMedipackOffset = 0x75 + (levelIndex * 0x40);
            flaresOffset = 0x77 + (levelIndex * 0x40);
            collectibleCrystalsOffset = 0x78 + (levelIndex * 0x40);
            weaponsConfigNumOffset = 0xA0 + (levelIndex * 0x40);
            harpoonGunOffset = 0xA1 + (levelIndex * 0x40);

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
                MAX_HEALTH_OFFSET = 0x10AA;
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

        public void DisplayGameInfo(CheckBox chkPistols, CheckBox chkShotgun, CheckBox chkDeagle, CheckBox chkUzi, CheckBox chkMP5,
            CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudSaveNumber,
            NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks, NumericUpDown nudFlares,
            NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo, NumericUpDown nudGrenadeLauncherAmmo,
            NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo, NumericUpDown nudMP5Ammo, NumericUpDown nudUziAmmo,
            TrackBar trbHealth, Label lblHealth, Label lblHealthError, NumericUpDown nudCollectibleCrystals,
            Label lblCollectibleCrystals)
        {
            DetermineOffsets();

            nudSaveNumber.Value = GetSaveNumber();
            nudSmallMedipacks.Value = GetNumSmallMedipacks();
            nudLargeMedipacks.Value = GetNumLargeMedipacks();
            nudFlares.Value = GetNumFlares();

            nudShotgunAmmo.Value = GetShotgunAmmo() / 6;
            nudDeagleAmmo.Value = GetDeagleAmmo();
            nudGrenadeLauncherAmmo.Value = GetGrenadeLauncherAmmo();
            nudRocketLauncherAmmo.Value = GetRocketLauncherAmmo();
            nudHarpoonGunAmmo.Value = GetHarpoonGunAmmo();
            nudMP5Ammo.Value = GetMP5Ammo();
            nudUziAmmo.Value = GetUziAmmo();

            if (GetLevelIndex() >= 21)
            {
                nudCollectibleCrystals.Enabled = false;
                lblCollectibleCrystals.Visible = false;
                nudCollectibleCrystals.Value = 0;
                nudCollectibleCrystals.Visible = false;
            }
            else
            {
                lblCollectibleCrystals.Text = GetGameMode() == GameMode.Normal ? "Collectible Crystals:" : "Savegame Crystals:";
                nudCollectibleCrystals.Enabled = true;
                lblCollectibleCrystals.Visible = true;
                nudCollectibleCrystals.Value = GetNumCollectibleCrystals();
                nudCollectibleCrystals.Visible = true;
            }

            byte weaponsConfigNum = GetWeaponsConfigNum();

            const byte Pistols = 2;
            const byte Deagle = 4;
            const byte Uzis = 8;
            const byte Shotgun = 16;
            const byte MP5 = 32;
            const byte RocketLauncher = 64;
            const byte GrenadeLauncher = 128;

            if (weaponsConfigNum == 1)
            {
                chkPistols.Checked = false;
                chkShotgun.Checked = false;
                chkDeagle.Checked = false;
                chkUzi.Checked = false;
                chkMP5.Checked = false;
                chkRocketLauncher.Checked = false;
                chkGrenadeLauncher.Checked = false;
            }
            else
            {
                chkPistols.Checked = (weaponsConfigNum & Pistols) != 0;
                chkShotgun.Checked = (weaponsConfigNum & Shotgun) != 0;
                chkDeagle.Checked = (weaponsConfigNum & Deagle) != 0;
                chkUzi.Checked = (weaponsConfigNum & Uzis) != 0;
                chkMP5.Checked = (weaponsConfigNum & MP5) != 0;
                chkRocketLauncher.Checked = (weaponsConfigNum & RocketLauncher) != 0;
                chkGrenadeLauncher.Checked = (weaponsConfigNum & GrenadeLauncher) != 0;
            }

            chkHarpoonGun.Checked = IsHarpoonGunPresent();

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

        public void WriteChanges(CheckBox chkPistols, CheckBox chkDeagle, CheckBox chkUzi, CheckBox chkShotgun,
            CheckBox chkMP5, CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun,
            NumericUpDown nudSaveNumber, NumericUpDown nudFlares, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo,
            NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo,
            NumericUpDown nudMP5Ammo, NumericUpDown nudUziAmmo, TrackBar trbHealth, NumericUpDown nudCollectibleCrystals)
        {
            DetermineOffsets();

            WriteSaveNumber((Int32)nudSaveNumber.Value);
            WriteNumFlares((byte)nudFlares.Value);
            WriteNumSmallMedipacks((byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks((byte)nudLargeMedipacks.Value);

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += 2;
            if (chkDeagle.Checked) newWeaponsConfigNum += 4;
            if (chkUzi.Checked) newWeaponsConfigNum += 8;
            if (chkShotgun.Checked) newWeaponsConfigNum += 16;
            if (chkMP5.Checked) newWeaponsConfigNum += 32;
            if (chkRocketLauncher.Checked) newWeaponsConfigNum += 64;
            if (chkGrenadeLauncher.Checked) newWeaponsConfigNum += 128;

            WriteWeaponsConfigNum(newWeaponsConfigNum);
            WriteHarpoonGunPresent(chkHarpoonGun.Checked);

            byte levelIndex = GetLevelIndex();
            secondaryAmmoIndex = GetSecondaryAmmoIndex();

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

            WriteShotgunAmmo(chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));
            WriteDeagleAmmo(chkDeagle.Checked, (UInt16)nudDeagleAmmo.Value);
            WriteGrenadeLauncherAmmo(chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value);
            WriteRocketLauncherAmmo(chkRocketLauncher.Checked, (UInt16)nudRocketLauncherAmmo.Value);
            WriteHarpoonGunAmmo(chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value);
            WriteMP5Ammo(chkMP5.Checked, (UInt16)nudMP5Ammo.Value);
            WriteUziAmmo(chkUzi.Checked, (UInt16)nudUziAmmo.Value);

            if (levelIndex < 21)
            {
                WriteNumCollectibleCrystals((byte)nudCollectibleCrystals.Value);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue((UInt16)trbHealth.Value);
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
            {  1, "Jungle"                      },
            {  2, "Temple Ruins"                },
            {  3, "The River Ganges"            },
            {  4, "Caves of Kaliya"             },
            {  5, "Coastal Village"             },
            {  6, "Crash Site"                  },
            {  7, "Madubu Gorge"                },
            {  8, "Temple Of Puna"              },
            {  9, "Thames Wharf"                },
            { 10, "Aldwych"                     },
            { 11, "Lud's Gate"                  },
            { 12, "City"                        },
            { 13, "Nevada Desert"               },
            { 14, "High Security Compound"      },
            { 15, "Area 51"                     },
            { 16, "Antarctica"                  },
            { 17, "RX-Tech Mines"               },
            { 18, "Lost City Of Tinnos"         },
            { 19, "Meteorite Cavern"            },
            { 20, "All Hallows"                 },
            { 21, "Highland Fling"              },
            { 22, "Willard's Lair"              },
            { 23, "Shakespeare Cliff"           },
            { 24, "Sleeping with the Fishes"    },
            { 25, "It's a Madhouse!"            },
            { 26, "Reunion"                     },
        };

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

        private int GetSecondaryAmmoIndex()
        {
            byte levelIndex = GetLevelIndex();

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

                for (int index = 0; index < 15; index++)
                {
                    Array.Copy(indexData, offsets1, indexData.Length);

                    for (int i = 0; i < indexData.Length; i++)
                    {
                        offsets2[i] = offsets1[i] + 0xA;

                        offsets1[i] += savegameOffset + (index * 0x1A);
                        offsets2[i] += savegameOffset + (index * 0x1A);
                    }

                    if (offsets1.All(offset => ReadByte(offset) == 0xFF))
                    {
                        return index;
                    }

                    if (offsets2.All(offset => ReadByte(offset) == 0xFF))
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

        public void UpdateDisplayName(Savegame savegame)
        {
            bool savegamePresent = ReadByte(savegame.Offset + slotStatusOffset) != 0;

            if (savegamePresent)
            {
                byte levelIndex = ReadByte(savegame.Offset + levelIndexOffset);
                string levelName = levelNames[levelIndex];
                Int32 saveNumber = ReadInt32(savegame.Offset + saveNumberOffset);
                GameMode gameMode = ReadByte(savegame.Offset + gameModeOffset) == 0 ? GameMode.Normal : GameMode.Plus;

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

            for (int i = cmbSavegames.Items.Count; i < 32; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_ITERATOR);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR3)
                {
                    Int32 saveNumber = ReadInt32(currentSavegameOffset + saveNumberOffset);
                    byte levelIndex = ReadByte(currentSavegameOffset + levelIndexOffset);
                    bool savegamePresent = ReadByte(currentSavegameOffset + slotStatusOffset) != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR3) / SAVEGAME_ITERATOR;

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
                            GameMode gameMode = ReadByte(currentSavegameOffset + gameModeOffset) == 0 ? GameMode.Normal : GameMode.Plus;

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

            for (int i = 0; i < 32; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_ITERATOR);
                SetSavegameOffset(currentSavegameOffset);

                Int32 saveNumber = GetSaveNumber();
                byte levelIndex = GetLevelIndex();
                bool savegamePresent = IsSavegamePresent();

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR3) / SAVEGAME_ITERATOR;
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
