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
        private const int saveNumberOffset = 0x00C;
        private const int levelIndexOffset = 0x628;

        // Dynamic offsets
        private int smallMedipackOffset;
        private int largeMedipackOffset;
        private int flaresOffset;
        private int weaponsConfigNumOffset;
        private int automaticPistolsAmmoOffset;
        private int uziAmmoOffset;
        private int shotgunAmmoOffset;
        private int harpoonGunAmmoOffset;
        private int m16AmmoOffset;
        private int grenadeLauncherAmmoOffset;
        private int m16AmmoOffset2;
        private int grenadeLauncherAmmoOffset2;
        private int harpoonGunAmmoOffset2;
        private int shotgunAmmoOffset2;
        private int uziAmmoOffset2;
        private int automaticPistolsAmmoOffset2;

        // Constants
        private const int BASE_SAVEGAME_OFFSET_TR2 = 0x72000;
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

        private UInt16 GetShotgunAmmo()
        {
            return ReadUInt16(savegameOffset + shotgunAmmoOffset);
        }

        private UInt16 GetM16Ammo()
        {
            return ReadUInt16(savegameOffset + m16AmmoOffset);
        }

        private UInt16 GetUziAmmo()
        {
            return ReadUInt16(savegameOffset + uziAmmoOffset);
        }

        private UInt16 GetHarpoonGunAmmo()
        {
            return ReadUInt16(savegameOffset + harpoonGunAmmoOffset);
        }

        private UInt16 GetAutomaticPistolsAmmo()
        {
            return ReadUInt16(savegameOffset + automaticPistolsAmmoOffset);
        }

        private UInt16 GetGrenadeLauncherAmmo()
        {
            return ReadUInt16(savegameOffset + grenadeLauncherAmmoOffset);
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

        private readonly Dictionary<byte, int[]> ammoIndexData = new Dictionary<byte, int[]>
        {
            {  1, new int[] { 0x19BA, 0x19BB, 0x19BC, 0x19BD } },   // The Great Wall
            {  2, new int[] { 0x1CFC, 0x1CFD, 0x1CFE, 0x1CFF } },   // Venice
            {  3, new int[] { 0x1F10, 0x1F11, 0x1F12, 0x1F13 } },   // Bartoli's Hideout
            {  4, new int[] { 0x2A22, 0x2A23, 0x2A24, 0x2A25 } },   // Opera House
            {  5, new int[] { 0x1AEE, 0x1AEF, 0x1AF0, 0x1AF1 } },   // Offshore Rig
            {  6, new int[] { 0x1EBC, 0x1EBD, 0x1EBE, 0x1EBF } },   // Diving Area
            {  7, new int[] { 0x1410, 0x1411, 0x1412, 0x1413 } },   // 40 Fathoms
            {  8, new int[] { 0x2598, 0x2599, 0x259A, 0x259B } },   // Wreck of the Maria Doria
            {  9, new int[] { 0x17C2, 0x17C3, 0x17C4, 0x17C5 } },   // Living Quarters
            { 10, new int[] { 0x1C0E, 0x1C0F, 0x1C10, 0x1C11 } },   // The Deck
            { 11, new int[] { 0x1F62, 0x1F63, 0x1F64, 0x1F65 } },   // Tibetan Foothills
            { 12, new int[] { 0x2B56, 0x2B57, 0x2B58, 0x2B59 } },   // Barkhang Monastery
            { 13, new int[] { 0x2282, 0x2283, 0x2284, 0x2285 } },   // Catacombs of the Talion
            { 14, new int[] { 0x1DEE, 0x1DEF, 0x1DF0, 0x1DF1 } },   // Ice Palace
            { 15, new int[] { 0x2CB2, 0x2CB3, 0x2CB4, 0x2CB5 } },   // Temple of Xian
            { 16, new int[] { 0x1E42, 0x1E43, 0x1E44, 0x1E45 } },   // Floating Islands
            { 17, new int[] { 0x157C, 0x157D, 0x157E, 0x157F } },   // The Dragon's Lair
            { 18, new int[] { 0x1AB0, 0x1AB1, 0x1AB2, 0x1AB3 } },   // Home Sweet Home
            { 19, new int[] { 0x2CFA, 0x2CFB, 0x2CFC, 0x2CFD } },   // The Cold War
            { 20, new int[] { 0x2CF2, 0x2CF3, 0x2CF4, 0x2CF5 } },   // Fool's Gold
            { 21, new int[] { 0x2AF0, 0x2AF1, 0x2AF2, 0x2AF3 } },   // Furnace of the Gods
            { 22, new int[] { 0x210A, 0x210B, 0x210C, 0x210D } },   // Kingdom
        };

        private int GetSecondaryAmmoIndex()
        {
            byte levelIndex = GetLevelIndex();

            if (ammoIndexData.ContainsKey(levelIndex))
            {
                int[] indexData = ammoIndexData[levelIndex];

                int[] offsets1 = new int[indexData.Length];
                int[] offsets2 = new int[indexData.Length];

                for (int index = 0; index < 20; index++)
                {
                    Array.Copy(indexData, offsets1, indexData.Length);

                    for (int i = 0; i < indexData.Length; i++)
                    {
                        offsets2[i] = offsets1[i] + 0xA;

                        offsets1[i] += savegameOffset + (index * 0xC);
                        offsets2[i] += savegameOffset + (index * 0xC);
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
            return baseOffset + (secondaryAmmoIndex * 0xC);
        }

        private bool IsKnownByteFlagPattern(byte byteFlag1, byte byteFlag2, byte byteFlag3)
        {
            if (byteFlag1 == 0x02 && byteFlag2 == 0x00 && byteFlag3 == 0x02) return true;       // Standing
            if (byteFlag1 == 0x13 && byteFlag2 == 0x00 && byteFlag3 == 0x13) return true;       // Climbing
            if (byteFlag1 == 0x21 && byteFlag2 == 0x00 && byteFlag3 == 0x21) return true;       // On water
            if (byteFlag1 == 0x0D && byteFlag2 == 0x00 && byteFlag3 == 0x0D) return true;       // Underwater

            return false;
        }

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
            { 23,  "Nightmare in Vegas"         },  // Need to test this level...
        };

        private void SetHealthOffsets(params int[] offsets)
        {
            healthOffsets.Clear();

            for (int i = 0; i < offsets.Length; i++)
            {
                healthOffsets.Add(offsets[i]);
            }
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

        private void WriteAutomaticPistolsAmmo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + automaticPistolsAmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + automaticPistolsAmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + automaticPistolsAmmoOffset2, 0);
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

        private void WriteM16Ammo(bool isPresent, UInt16 ammo)
        {
            WriteUInt16(savegameOffset + m16AmmoOffset, ammo);

            if (isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + m16AmmoOffset2, ammo);
            }
            else if (!isPresent && secondaryAmmoIndex != -1)
            {
                WriteUInt16(savegameOffset + m16AmmoOffset2, 0);
            }
        }

        private bool IsPS4Savegame()
        {
            FileInfo fileInfo = new FileInfo(savegamePath);
            return fileInfo.Length == 0x400000;
        }

        private void DetermineOffsets()
        {
            byte levelIndex = GetLevelIndex();

            automaticPistolsAmmoOffset = 0x12 + (levelIndex * 0x30);
            uziAmmoOffset = 0x14 + (levelIndex * 0x30);
            shotgunAmmoOffset = 0x16 + (levelIndex * 0x30);
            m16AmmoOffset = 0x18 + (levelIndex * 0x30);
            grenadeLauncherAmmoOffset = 0x1A + (levelIndex * 0x30);
            harpoonGunAmmoOffset = 0x1C + (levelIndex * 0x30);

            smallMedipackOffset = 0x1E + (levelIndex * 0x30);
            largeMedipackOffset = 0x1F + (levelIndex * 0x30);
            flaresOffset = 0x21 + (levelIndex * 0x30);
            weaponsConfigNumOffset = 0x3C + (levelIndex * 0x30);

            healthOffsets.Clear();

            if (levelIndex == 1)        // The Great Wall
            {
                SetHealthOffsets(0xB64, 0xB70, 0xB7C);
            }
            else if (levelIndex == 2)   // Venice
            {
                SetHealthOffsets(0x7FA);
            }
            else if (levelIndex == 3)   // Bartoli's Hideout
            {
                SetHealthOffsets(0x1734, 0x1740, 0x174C, 0x1758);
            }
            else if (levelIndex == 4)   // Opera House
            {
                SetHealthOffsets(0x1E20, 0x1E2C, 0x1E38);
            }
            else if (levelIndex == 5)   // Offshore Rig
            {
                SetHealthOffsets(0xAC4, 0xAD0, 0xADC);
            }
            else if (levelIndex == 6)   // Diving Area
            {
                SetHealthOffsets(0x12DE, 0x12EA, 0x12F6, 0x1302, 0x130E, 0x131A);
            }
            else if (levelIndex == 7)   // 40 Fathoms
            {
                SetHealthOffsets(0x7FC);
            }
            else if (levelIndex == 8)   // Wreck of the Maria Doria
            {
                SetHealthOffsets(0x238E, 0x239A, 0x23A6, 0x23B2, 0x23BE, 0x23CA, 0x23D6, 0x23E2, 0x23EE);
            }
            else if (levelIndex == 9)   // Living Quarters
            {
                SetHealthOffsets(0x90A);
            }
            else if (levelIndex == 10)  // The Deck
            {
                SetHealthOffsets(0xBAC, 0xBB8, 0xBC4, 0xBD0, 0xBDC, 0xBE8, 0xBF4);
            }
            else if (levelIndex == 11)  // Tibetan Foothills
            {
                SetHealthOffsets(0x12E4, 0x12F0, 0x12FC, 0x1308, 0x1314);
            }
            else if (levelIndex == 12)  // Barkhang Monastery
            {
                SetHealthOffsets(0x2522, 0x252E, 0x253A, 0x2546, 0x2552);
            }
            else if (levelIndex == 13)  // Catacombs of the Talion
            {
                SetHealthOffsets(0x7F8);
            }
            else if (levelIndex == 14)  // Ice Palace
            {
                SetHealthOffsets(0xE2A, 0xE36, 0xE42, 0xE4E);
            }
            else if (levelIndex == 15)  // Temple of Xian
            {
                SetHealthOffsets(0x2A7A, 0x2A86, 0x2A92, 0x2A9E);
            }
            else if (levelIndex == 16)  // Floating Islands
            {
                SetHealthOffsets(0x9CC, 0x9D8);
            }
            else if (levelIndex == 17)  // The Dragon's Lair
            {
                SetHealthOffsets(0xF78, 0xF84, 0xF90);
            }
            else if (levelIndex == 18)  // Home Sweet Home
            {
                SetHealthOffsets(0xEC2);
            }
            else if (levelIndex == 19)  // The Cold War
            {
                SetHealthOffsets(0x1632, 0x163E);
            }
            else if (levelIndex == 20)  // Fool's Gold
            {
                SetHealthOffsets(0x1D80);
            }
            else if (levelIndex == 21)  // Furnace of the Gods
            {
                SetHealthOffsets(0x1FD4, 0x1FE0);
            }
            else if (levelIndex == 22)  // Kingdom
            {
                SetHealthOffsets(0x91A);
            }
            else if (levelIndex == 23)  // Nightmare in Vegas
            {
                // Need to find health offsets for this level...
            }

            if (IsPS4Savegame())
            {
                for (int i = 0; i < healthOffsets.Count; i++)
                {
                    if (healthOffsets[i] >= 0x690)
                    {
                        healthOffsets[i] -= 4;
                    }
                }
            }
        }

        public void SetLevelParams(CheckBox chkPistols, CheckBox chkAutomaticPistols, CheckBox chkUzis, CheckBox chkM16,
            CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudAutomaticPistolsAmmo, NumericUpDown nudUziAmmo,
            NumericUpDown nudM16Ammo, NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudHarpoonGunAmmo)
        {
            if (GetLevelIndex() == 18)
            {
                chkPistols.Enabled = false;
                chkAutomaticPistols.Enabled = false;
                chkUzis.Enabled = false;
                chkM16.Enabled = false;
                chkGrenadeLauncher.Enabled = false;
                chkHarpoonGun.Enabled = false;
                nudAutomaticPistolsAmmo.Enabled = false;
                nudUziAmmo.Enabled = false;
                nudM16Ammo.Enabled = false;
                nudGrenadeLauncherAmmo.Enabled = false;
                nudHarpoonGunAmmo.Enabled = false;
            }
            else
            {
                chkPistols.Enabled = true;
                chkAutomaticPistols.Enabled = true;
                chkUzis.Enabled = true;
                chkM16.Enabled = true;
                chkGrenadeLauncher.Enabled = true;
                chkHarpoonGun.Enabled = true;
                nudAutomaticPistolsAmmo.Enabled = true;
                nudUziAmmo.Enabled = true;
                nudM16Ammo.Enabled = true;
                nudGrenadeLauncherAmmo.Enabled = true;
                nudHarpoonGunAmmo.Enabled = true;
            }
        }

        public void DisplayGameInfo(CheckBox chkPistols, CheckBox chkAutomaticPistols, CheckBox chkUzis,
            CheckBox chkM16, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudAutomaticPistolsAmmo,
            CheckBox chkShotgun, NumericUpDown nudUziAmmo, NumericUpDown nudM16Ammo, NumericUpDown nudGrenadeLauncherAmmo,
            NumericUpDown nudHarpoonGunAmmo, NumericUpDown nudShotgunAmmo, NumericUpDown nudFlares,
            NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks, TrackBar trbHealth, Label lblHealth,
            Label lblHealthError)
        {
            DetermineOffsets();

            nudSmallMedipacks.Value = GetNumSmallMedipacks();
            nudLargeMedipacks.Value = GetNumLargeMedipacks();
            nudFlares.Value = GetNumFlares();

            if (GetLevelIndex() == 18)
            {
                nudAutomaticPistolsAmmo.Value = 0;
                nudUziAmmo.Value = 0;
                nudM16Ammo.Value = 0;
                nudGrenadeLauncherAmmo.Value = 0;
                nudHarpoonGunAmmo.Value = 0;
            }
            else
            {
                nudAutomaticPistolsAmmo.Value = GetAutomaticPistolsAmmo();
                nudUziAmmo.Value = GetUziAmmo();
                nudM16Ammo.Value = GetM16Ammo();
                nudGrenadeLauncherAmmo.Value = GetGrenadeLauncherAmmo();
                nudHarpoonGunAmmo.Value = GetHarpoonGunAmmo();
            }

            nudShotgunAmmo.Value = GetShotgunAmmo() / 6;

            byte weaponsConfigNum = GetWeaponsConfigNum();

            const byte Pistols = 2;
            const byte AutomaticPistols = 4;
            const byte Uzis = 8;
            const byte Shotgun = 16;
            const byte M16 = 32;
            const byte GrenadeLauncher = 64;
            const byte HarpoonGun = 128;

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
                chkPistols.Checked = (weaponsConfigNum & Pistols) != 0;
                chkAutomaticPistols.Checked = (weaponsConfigNum & AutomaticPistols) != 0;
                chkUzis.Checked = (weaponsConfigNum & Uzis) != 0;
                chkShotgun.Checked = (weaponsConfigNum & Shotgun) != 0;
                chkM16.Checked = (weaponsConfigNum & M16) != 0;
                chkGrenadeLauncher.Checked = (weaponsConfigNum & GrenadeLauncher) != 0;
                chkHarpoonGun.Checked = (weaponsConfigNum & HarpoonGun) != 0;
            }

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

        public void WriteChanges(CheckBox chkPistols, CheckBox chkAutomaticPistols, CheckBox chkUzis, CheckBox chkShotgun,
            CheckBox chkM16, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun, NumericUpDown nudFlares,
            NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks, NumericUpDown nudAutomaticPistolsAmmo,
            NumericUpDown nudUziAmmo, NumericUpDown nudM16Ammo, NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudHarpoonGunAmmo,
            NumericUpDown nudShotgunAmmo, TrackBar trbHealth)
        {
            WriteNumSmallMedipacks((byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks((byte)nudLargeMedipacks.Value);
            WriteNumFlares((byte)nudFlares.Value);

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += 2;
            if (chkAutomaticPistols.Checked) newWeaponsConfigNum += 4;
            if (chkUzis.Checked) newWeaponsConfigNum += 8;
            if (chkShotgun.Checked) newWeaponsConfigNum += 16;
            if (chkM16.Checked) newWeaponsConfigNum += 32;
            if (chkGrenadeLauncher.Checked) newWeaponsConfigNum += 64;
            if (chkHarpoonGun.Checked) newWeaponsConfigNum += 128;

            WriteWeaponsConfigNum(newWeaponsConfigNum);

            byte levelIndex = GetLevelIndex();
            secondaryAmmoIndex = GetSecondaryAmmoIndex();

            if (secondaryAmmoIndex != -1)
            {
                int baseSecondaryAmmoOffset = ammoIndexData[levelIndex][0];

                automaticPistolsAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0xAC);
                uziAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0xA4);
                shotgunAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x9C);
                harpoonGunAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x94);
                grenadeLauncherAmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x8C);
                m16AmmoOffset2 = GetSecondaryAmmoOffset(baseSecondaryAmmoOffset - 0x7C);
            }

            if (levelIndex != 18)
            {
                WriteAutomaticPistolsAmmo(chkAutomaticPistols.Checked, (UInt16)nudAutomaticPistolsAmmo.Value);
                WriteUziAmmo(chkUzis.Checked, (UInt16)nudUziAmmo.Value);
                WriteHarpoonGunAmmo(chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value);
                WriteGrenadeLauncherAmmo(chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value);
                WriteM16Ammo(chkM16.Checked, (UInt16)nudM16Ammo.Value);
            }

            WriteShotgunAmmo(chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));

            if (trbHealth.Enabled)
            {
                WriteHealthValue((double)trbHealth.Value);
            }
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
                currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR2 + (i * SAVEGAME_ITERATOR);
                SetSavegameOffset(currentSavegameOffset);

                UInt16 saveNumber = GetSaveNumber();
                byte levelIndex = GetLevelIndex();

                if (saveNumber != 0 && levelIndex >= 1 && levelIndex <= 22)
                {
                    string levelName = levelNames[levelIndex];

                    Savegame savegame = new Savegame(currentSavegameOffset, saveNumber, levelName);
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
