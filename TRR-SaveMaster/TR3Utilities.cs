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
        private const int saveNumberOffset = 0x00C;
        private const int levelIndexOffset = 0x8D6;

        // Dynamic offsets
        private int smallMedipackOffset;
        private int largeMedipackOffset;
        private int flaresOffset;
        private int weaponsConfigNumOffset;
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
        private const int SAVEGAME_ITERATOR = 0x3800;

        // Health
        private const UInt16 MAX_HEALTH_VALUE = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private List<int> healthOffsets = new List<int>();

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

        private UInt16 GetSaveNumber()
        {
            return ReadUInt16(savegameOffset + saveNumberOffset);
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

        private int GetHealthOffset()
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

        private double GetHealthPercentage(int healthOffset)
        {
            UInt16 health = ReadUInt16(healthOffset);
            double healthPercentage = ((double)health / MAX_HEALTH_VALUE) * 100.0;

            return healthPercentage;
        }

        private bool IsHarpoonGunPresent()
        {
            return ReadByte(savegameOffset + harpoonGunOffset) != 0;
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

        private void WriteHealthValue(double newHealthPercentage)
        {
            int healthOffset = GetHealthOffset();

            if (healthOffset != -1)
            {
                UInt16 newHealth = (UInt16)(newHealthPercentage / 100.0 * MAX_HEALTH_VALUE);
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
            weaponsConfigNumOffset = 0xA0 + (levelIndex * 0x40);
            harpoonGunOffset = 0xA1 + (levelIndex * 0x40);

            healthOffsets.Clear();

            if (levelIndex == 1)        // Jungle
            {
                deagleAmmoOffset2 = 0x1EDA;
                uziAmmoOffset2 = 0x1EE2;
                shotgunAmmoOffset2 = 0x1EEA;
                harpoonGunAmmoOffset2 = 0x1EF2;
                rocketLauncherAmmoOffset2 = 0x1EFA;
                grenadeLauncherAmmoOffset2 = 0x1F02;
                mp5AmmoOffset2 = 0x1F0A;

                SetHealthOffsets(0xB26);
            }
            else if (levelIndex == 2)   // Temple Ruins
            {
                deagleAmmoOffset2 = 0x3068;
                uziAmmoOffset2 = 0x3070;
                shotgunAmmoOffset2 = 0x3078;
                harpoonGunAmmoOffset2 = 0x3080;
                rocketLauncherAmmoOffset2 = 0x3088;
                grenadeLauncherAmmoOffset2 = 0x3090;
                mp5AmmoOffset2 = 0x3098;

                SetHealthOffsets(0xDCC);
            }
            else if (levelIndex == 3)   // The River Ganges
            {
                deagleAmmoOffset2 = 0x2152;
                uziAmmoOffset2 = 0x215A;
                shotgunAmmoOffset2 = 0x2162;
                harpoonGunAmmoOffset2 = 0x216A;
                rocketLauncherAmmoOffset2 = 0x2172;
                grenadeLauncherAmmoOffset2 = 0x217A;
                mp5AmmoOffset2 = 0x2182;

                SetHealthOffsets(0xAFC);
            }
            else if (levelIndex == 4)   // Caves of Kaliya
            {
                deagleAmmoOffset2 = 0x131A;
                uziAmmoOffset2 = 0x1322;
                shotgunAmmoOffset2 = 0x132A;
                harpoonGunAmmoOffset2 = 0x1332;
                rocketLauncherAmmoOffset2 = 0x133A;
                grenadeLauncherAmmoOffset2 = 0x1342;
                mp5AmmoOffset2 = 0x134A;

                SetHealthOffsets(0x1038);
            }
            else if (levelIndex == 5)   // Coastal Village
            {
                deagleAmmoOffset2 = 0x21E8;
                uziAmmoOffset2 = 0x21F0;
                shotgunAmmoOffset2 = 0x21F8;
                harpoonGunAmmoOffset2 = 0x2200;
                rocketLauncherAmmoOffset2 = 0x2208;
                grenadeLauncherAmmoOffset2 = 0x2210;
                mp5AmmoOffset2 = 0x2218;

                SetHealthOffsets(0xCB8);
            }
            else if (levelIndex == 6)   // Crash Site
            {
                deagleAmmoOffset2 = 0x222A;
                uziAmmoOffset2 = 0x2232;
                shotgunAmmoOffset2 = 0x223A;
                harpoonGunAmmoOffset2 = 0x2242;
                rocketLauncherAmmoOffset2 = 0x224A;
                grenadeLauncherAmmoOffset2 = 0x2252;
                mp5AmmoOffset2 = 0x225A;

                SetHealthOffsets(0x2046);
            }
            else if (levelIndex == 7)   // Madubu Gorge
            {
                deagleAmmoOffset2 = 0x1D52;
                uziAmmoOffset2 = 0x1D5A;
                shotgunAmmoOffset2 = 0x1D62;
                harpoonGunAmmoOffset2 = 0x1D6A;
                rocketLauncherAmmoOffset2 = 0x1D72;
                grenadeLauncherAmmoOffset2 = 0x1D7A;
                mp5AmmoOffset2 = 0x1D82;

                SetHealthOffsets(0x1250);
            }
            else if (levelIndex == 8)   // Temple of Puna
            {
                deagleAmmoOffset2 = 0x1810;
                uziAmmoOffset2 = 0x1818;
                shotgunAmmoOffset2 = 0x1820;
                harpoonGunAmmoOffset2 = 0x1828;
                rocketLauncherAmmoOffset2 = 0x1830;
                grenadeLauncherAmmoOffset2 = 0x1838;
                mp5AmmoOffset2 = 0x1840;

                SetHealthOffsets(0xAD2);
            }

            else if (levelIndex == 9)   // Thames Wharf
            {
                deagleAmmoOffset2 = 0x21D6;
                uziAmmoOffset2 = 0x21DE;
                shotgunAmmoOffset2 = 0x21E6;
                harpoonGunAmmoOffset2 = 0x21EE;
                rocketLauncherAmmoOffset2 = 0x21F6;
                grenadeLauncherAmmoOffset2 = 0x21FE;
                mp5AmmoOffset2 = 0x2206;

                SetHealthOffsets(0x10AA);
            }
            else if (levelIndex == 10)  // Aldwych
            {
                deagleAmmoOffset2 = 0x2F1E;
                uziAmmoOffset2 = 0x2F26;
                shotgunAmmoOffset2 = 0x2F2E;
                harpoonGunAmmoOffset2 = 0x2F36;
                rocketLauncherAmmoOffset2 = 0x2F3E;
                grenadeLauncherAmmoOffset2 = 0x2F46;
                mp5AmmoOffset2 = 0x2F4E;

                SetHealthOffsets(0x2C9A);
            }
            else if (levelIndex == 11)  // Lud's Gate
            {
                deagleAmmoOffset2 = 0x27F0;
                uziAmmoOffset2 = 0x27F8;
                shotgunAmmoOffset2 = 0x2800;
                harpoonGunAmmoOffset2 = 0x2808;
                rocketLauncherAmmoOffset2 = 0x2810;
                grenadeLauncherAmmoOffset2 = 0x2818;
                mp5AmmoOffset2 = 0x2820;

                SetHealthOffsets(0xFF0, 0x100A);
            }
            else if (levelIndex == 12)  // City
            {
                deagleAmmoOffset2 = 0x10EA;
                uziAmmoOffset2 = 0x10F2;
                shotgunAmmoOffset2 = 0x10FA;
                harpoonGunAmmoOffset2 = 0x1102;
                rocketLauncherAmmoOffset2 = 0x110A;
                grenadeLauncherAmmoOffset2 = 0x1112;
                mp5AmmoOffset2 = 0x111A;

                SetHealthOffsets(0xBB2);
            }
            else if (levelIndex == 13)  // Nevada Desert
            {
                deagleAmmoOffset2 = 0x2126;
                uziAmmoOffset2 = 0x212E;
                shotgunAmmoOffset2 = 0x2136;
                harpoonGunAmmoOffset2 = 0x213E;
                rocketLauncherAmmoOffset2 = 0x2146;
                grenadeLauncherAmmoOffset2 = 0x214E;
                mp5AmmoOffset2 = 0x2156;

                SetHealthOffsets(0xAF8);
            }
            else if (levelIndex == 14)  // High Security Compound
            {
                deagleAmmoOffset2 = 0x29DE;
                uziAmmoOffset2 = 0x29E6;
                shotgunAmmoOffset2 = 0x29EE;
                harpoonGunAmmoOffset2 = 0x29F6;
                rocketLauncherAmmoOffset2 = 0x29FE;
                grenadeLauncherAmmoOffset2 = 0x2A06;
                mp5AmmoOffset2 = 0x2A0E;

                SetHealthOffsets(0xB4C);
            }
            else if (levelIndex == 15)  // Area 51
            {
                deagleAmmoOffset2 = 0x2CB0;
                uziAmmoOffset2 = 0x2CB8;
                shotgunAmmoOffset2 = 0x2CC0;
                harpoonGunAmmoOffset2 = 0x2CC8;
                rocketLauncherAmmoOffset2 = 0x2CD0;
                grenadeLauncherAmmoOffset2 = 0x2CD8;
                mp5AmmoOffset2 = 0x2CE0;

                SetHealthOffsets(0x11E4);
            }
            else if (levelIndex == 16)  // Antarctica
            {
                deagleAmmoOffset2 = 0x2320;
                uziAmmoOffset2 = 0x2328;
                shotgunAmmoOffset2 = 0x2330;
                harpoonGunAmmoOffset2 = 0x2338;
                rocketLauncherAmmoOffset2 = 0x2340;
                grenadeLauncherAmmoOffset2 = 0x2348;
                mp5AmmoOffset2 = 0x2350;

                SetHealthOffsets(0xB12);
            }
            else if (levelIndex == 17)  // RX-Tech Mines
            {
                deagleAmmoOffset2 = 0x2368;
                uziAmmoOffset2 = 0x2370;
                shotgunAmmoOffset2 = 0x2378;
                harpoonGunAmmoOffset2 = 0x2380;
                rocketLauncherAmmoOffset2 = 0x2388;
                grenadeLauncherAmmoOffset2 = 0x2390;
                mp5AmmoOffset2 = 0x2398;

                SetHealthOffsets(0xFB0);
            }
            else if (levelIndex == 18)  // Lost City of Tinnos
            {
                deagleAmmoOffset2 = 0x28F4;
                uziAmmoOffset2 = 0x28FC;
                shotgunAmmoOffset2 = 0x2904;
                harpoonGunAmmoOffset2 = 0x290C;
                rocketLauncherAmmoOffset2 = 0x2914;
                grenadeLauncherAmmoOffset2 = 0x291C;
                mp5AmmoOffset2 = 0x2924;

                SetHealthOffsets(0xB7C);
            }
            else if (levelIndex == 19)  // Meteorite Cavern
            {
                deagleAmmoOffset2 = 0x109A;
                uziAmmoOffset2 = 0x10A2;
                shotgunAmmoOffset2 = 0x10AA;
                harpoonGunAmmoOffset2 = 0x10B2;
                rocketLauncherAmmoOffset2 = 0x10BA;
                grenadeLauncherAmmoOffset2 = 0x10C2;
                mp5AmmoOffset2 = 0x10CA;

                SetHealthOffsets(0xAD0);
            }
            else if (levelIndex == 20)  // All Hallows
            {
                //deagleAmmoOffset2 = 0;
                //uziAmmoOffset2 = 0;
                //shotgunAmmoOffset2 = 0;
                //harpoonGunAmmoOffset2 = 0;
                //rocketLauncherAmmoOffset2 = 0;
                //grenadeLauncherAmmoOffset2 = 0;
                //mp5AmmoOffset2 = 0;
            }
            else if (levelIndex == 21)  // Highland Fling
            {
                deagleAmmoOffset2 = 0x2102;
                uziAmmoOffset2 = 0x210A;
                shotgunAmmoOffset2 = 0x2112;
                harpoonGunAmmoOffset2 = 0x211A;
                rocketLauncherAmmoOffset2 = 0x2122;
                grenadeLauncherAmmoOffset2 = 0x212A;
                mp5AmmoOffset2 = 0x2132;

                SetHealthOffsets(0x1BF4);
            }
            else if (levelIndex == 22)  // Willard's Lair
            {
                deagleAmmoOffset2 = 0x2486;
                uziAmmoOffset2 = 0x248E;
                shotgunAmmoOffset2 = 0x2496;
                harpoonGunAmmoOffset2 = 0x249E;
                rocketLauncherAmmoOffset2 = 0x24A6;
                grenadeLauncherAmmoOffset2 = 0x24AE;
                mp5AmmoOffset2 = 0x24B6;

                SetHealthOffsets(0x15EE);
            }
            else if (levelIndex == 23)  // Shakespeare Cliff
            {
                deagleAmmoOffset2 = 0x2524;
                uziAmmoOffset2 = 0x252C;
                shotgunAmmoOffset2 = 0x2534;
                harpoonGunAmmoOffset2 = 0x253C;
                rocketLauncherAmmoOffset2 = 0x2544;
                grenadeLauncherAmmoOffset2 = 0x254C;
                mp5AmmoOffset2 = 0x2554;

                SetHealthOffsets(0x1338);
            }
            else if (levelIndex == 24)  // Sleeping with the Fishes
            {
                deagleAmmoOffset2 = 0x2326;
                uziAmmoOffset2 = 0x232E;
                shotgunAmmoOffset2 = 0x2336;
                harpoonGunAmmoOffset2 = 0x233E;
                rocketLauncherAmmoOffset2 = 0x2346;
                grenadeLauncherAmmoOffset2 = 0x234E;
                mp5AmmoOffset2 = 0x2356;

                SetHealthOffsets(0xB5A);
            }
            else if (levelIndex == 25)  // It's a Madhouse!
            {
                deagleAmmoOffset2 = 0x1F84;
                uziAmmoOffset2 = 0x1F8C;
                shotgunAmmoOffset2 = 0x1F94;
                harpoonGunAmmoOffset2 = 0x1F9C;
                rocketLauncherAmmoOffset2 = 0x1FA4;
                grenadeLauncherAmmoOffset2 = 0x1FAC;
                mp5AmmoOffset2 = 0x1FB4;

                SetHealthOffsets(0x1084);
            }
            else if (levelIndex == 26)  // Reunion
            {
                deagleAmmoOffset2 = 0x1994;
                uziAmmoOffset2 = 0x199C;
                shotgunAmmoOffset2 = 0x19A4;
                harpoonGunAmmoOffset2 = 0x19AC;
                rocketLauncherAmmoOffset2 = 0x19B4;
                grenadeLauncherAmmoOffset2 = 0x19BC;
                mp5AmmoOffset2 = 0x19C4;

                SetHealthOffsets(0x1810);
            }
        }

        public void DisplayGameInfo(CheckBox chkPistols, CheckBox chkShotgun, CheckBox chkDeagle, CheckBox chkUzi, CheckBox chkMP5,
            CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun,
            NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks, NumericUpDown nudFlares,
            NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo, NumericUpDown nudGrenadeLauncherAmmo,
            NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo, NumericUpDown nudMP5Ammo, NumericUpDown nudUziAmmo,
            TrackBar trbHealth, Label lblHealth, Label lblHealthError)
        {
            DetermineOffsets();

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
                double healthPercentage = GetHealthPercentage(healthOffset);
                trbHealth.Value = (UInt16)healthPercentage;
                trbHealth.Enabled = true;

                lblHealth.Text = healthPercentage.ToString("0.0") + "%";
                lblHealthError.Visible = false;
                lblHealth.Visible = true;
            }
            else
            {
                trbHealth.Enabled = false;
                trbHealth.Value = 0;
                lblHealthError.Visible = true;
                lblHealth.Visible = false;
            }
        }

        public void WriteChanges(CheckBox chkPistols, CheckBox chkDeagle, CheckBox chkUzi, CheckBox chkShotgun,
            CheckBox chkMP5, CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun,
            NumericUpDown nudFlares, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo, NumericUpDown nudGrenadeLauncherAmmo,
            NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo, NumericUpDown nudMP5Ammo,
            NumericUpDown nudUziAmmo, TrackBar trbHealth)
        {
            DetermineOffsets();

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

            secondaryAmmoIndex = GetSecondaryAmmoIndex();

            if (secondaryAmmoIndex != -1)
            {
                mp5AmmoOffset2 = GetSecondaryAmmoOffset(mp5AmmoOffset2);
                grenadeLauncherAmmoOffset2 = GetSecondaryAmmoOffset(grenadeLauncherAmmoOffset2);
                rocketLauncherAmmoOffset2 = GetSecondaryAmmoOffset(rocketLauncherAmmoOffset2);
                harpoonGunAmmoOffset2 = GetSecondaryAmmoOffset(harpoonGunAmmoOffset2);
                shotgunAmmoOffset2 = GetSecondaryAmmoOffset(shotgunAmmoOffset2);
                uziAmmoOffset2 = GetSecondaryAmmoOffset(uziAmmoOffset2);
                deagleAmmoOffset2 = GetSecondaryAmmoOffset(deagleAmmoOffset2);
            }

            WriteShotgunAmmo(chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));
            WriteDeagleAmmo(chkDeagle.Checked, (UInt16)nudDeagleAmmo.Value);
            WriteGrenadeLauncherAmmo(chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value);
            WriteRocketLauncherAmmo(chkRocketLauncher.Checked, (UInt16)nudRocketLauncherAmmo.Value);
            WriteHarpoonGunAmmo(chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value);
            WriteMP5Ammo(chkMP5.Checked, (UInt16)nudMP5Ammo.Value);
            WriteUziAmmo(chkUzi.Checked, (UInt16)nudUziAmmo.Value);

            if (trbHealth.Enabled)
            {
                WriteHealthValue((double)trbHealth.Value);
            }
        }

        private bool IsKnownByteFlagPattern(byte byteFlag1, byte byteFlag2, byte byteFlag3)
        {
            if (byteFlag1 == 0x02 && byteFlag2 == 0x00 && byteFlag3 == 0x02) return true;       // Standing
            if (byteFlag1 == 0x13 && byteFlag2 == 0x00 && byteFlag3 == 0x13) return true;       // Climbing
            if (byteFlag1 == 0x21 && byteFlag2 == 0x00 && byteFlag3 == 0x21) return true;       // On water
            if (byteFlag1 == 0x0D && byteFlag2 == 0x00 && byteFlag3 == 0x0D) return true;       // Underwater

            return false;
        }

        private void SetHealthOffsets(params int[] offsets)
        {
            healthOffsets.Clear();

            for (int i = 0; i < offsets.Length; i++)
            {
                healthOffsets.Add(offsets[i]);
            }
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
            { 20, "All Hallows"                 },  // Need to test this level...
            { 21, "Highland Fling"              },
            { 22, "Willard's Lair"              },
            { 23, "Shakespeare Cliff"           },
            { 24, "Sleeping with the Fishes"    },
            { 25, "It's a Madhouse!"            },
            { 26, "Reunion"                     },
        };

        private readonly Dictionary<byte, int[]> ammoIndexData = new Dictionary<byte, int[]>()
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
            { 21, new int[] { 0x21AE, 0x21AF, 0x21B0, 0x21B1 } },   // Highland Fling
            { 22, new int[] { 0x2532, 0x2533, 0x2534, 0x2535 } },   // Willard's Lair
            { 23, new int[] { 0x25D0, 0x25D1, 0x25D2, 0x25D3 } },   // Shakespeare Cliff
            { 24, new int[] { 0x23D2, 0x23D3, 0x23D4, 0x23D5 } },   // Sleeping with the Fishes
            { 25, new int[] { 0x2030, 0x2031, 0x2032, 0x2033 } },   // It's a Madhouse!
            { 26, new int[] { 0x1A40, 0x1A41, 0x1A42, 0x1A43 } },   // Reunion
        };

        private int GetSecondaryAmmoIndex()
        {
            byte levelIndex = GetLevelIndex();

            if (ammoIndexData.ContainsKey(levelIndex))
            {
                int[] indexData = ammoIndexData[levelIndex];

                int[] offsets = new int[indexData.Length];

                for (int index = 0; index < 10; index++)
                {
                    Array.Copy(indexData, offsets, indexData.Length);

                    for (int i = 0; i < indexData.Length; i++)
                    {
                        offsets[i] += savegameOffset + (index * 0x1A);
                    }

                    if (offsets.All(offset => ReadByte(offset) == 0xFF))
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

        public void SetSavegamePath(string path)
        {
            savegamePath = path;
        }

        public void SetSavegameOffset(int offset)
        {
            savegameOffset = offset;
        }

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            int currentSavegameOffset;
            int numSaves = 0;

            for (int i = 0; i < 32; i++)
            {
                currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_ITERATOR);
                SetSavegameOffset(currentSavegameOffset);

                UInt16 saveNumber = GetSaveNumber();
                byte levelIndex = GetLevelIndex();

                if (saveNumber != 0 && levelIndex >= 1 && levelIndex <= 26)
                {
                    string levelName = levelNames[levelIndex];

                    Savegame savegame = new Savegame(currentSavegameOffset, saveNumber, levelName);
                    cmbSavegames.Items.Add(savegame);

                    numSaves++;
                }
            }

            if (numSaves > 0 && cmbSavegames.SelectedIndex == -1)
            {
                cmbSavegames.SelectedIndex = 0;
            }
        }
    }
}
