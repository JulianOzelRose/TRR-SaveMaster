using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR4Utilities
    {
        // Savegame constants & offsets
        private const int SAVE_NUMBER_OFFSET = 0x004;
        private const int NEW_GAME_PLUS_OFFSET = 0x018;
        private const int LEVEL_INDEX_OFFSET = 0x26B;
        private const int BASE_SAVEGAME_OFFSET_TR4 = 0x2004;
        private const int MAX_SAVEGAME_OFFSET_TR4 = 0x14AE04;

        // Item offsets
        private const int GOLDEN_SKULLS_OFFSET = 0x1A2;
        private const int SMALL_MEDIPACK_OFFSET = 0x1BA;
        private const int LARGE_MEDIPACK_OFFSET = 0x1BC;
        private const int FLARES_OFFSET = 0x1BE;

        // Weapon offsets
        private const int PISTOLS_OFFSET = 0x190;
        private const int UZI_OFFSET = 0x191;
        private const int SHOTGUN_OFFSET = 0x192;
        private const int CROSSBOW_OFFSET = 0x193;
        private const int GRENADE_GUN_OFFSET = 0x195;
        private const int REVOLVER_OFFSET = 0x196;

        // Ammo offsets
        private const int UZI_AMMO_OFFSET = 0x1C2;
        private const int REVOLVER_AMMO_OFFSET = 0x1C4;
        private const int SHOTGUN_NORMAL_AMMO_OFFSET = 0x1C6;
        private const int SHOTGUN_WIDESHOT_AMMO_OFFSET = 0x1C8;
        private const int GRENADE_GUN_NORMAL_AMMO_OFFSET = 0x1CC;
        private const int GRENADE_GUN_SUPER_AMMO_OFFSET = 0x1CE;
        private const int GRENADE_GUN_FLASH_AMMO_OFFSET = 0x1D0;
        private const int CROSSBOW_NORMAL_AMMO_OFFSET = 0x1D2;
        private const int CROSSBOW_POISON_AMMO_OFFSET = 0x1D4;
        private const int CROSSBOW_EXPLOSIVE_AMMO_OFFSET = 0x1D6;

        // Weapon byte flags
        private const byte WEAPON_PRESENT = 0x9;
        private const byte WEAPON_PRESENT_WITH_SIGHT = 0xD;

        // Health
        private const Int16 MAX_HEALTH_VALUE = 1000;
        private const Int16 MIN_HEALTH_VALUE = 1;
        private const UInt32 ITEM_HEALTH_SERIALIZED_STATE = 0x400;
        private bool IS_LARA_HEALTH_SERIALIZED = true;
        private int LARA_DWORD_OFFSET = -1;
        private int HEALTH_OFFSET = -1;

        // Hub-related
        private const int HUB_LEVEL_COUNT = 10;
        private const int HUB_LEVEL_IDS_OFFSET = 0x1F8;
        private const int HUB_OFFSET_TABLE_OFFSET = 0x202;

        // Entity block constant
        private const int ENTITY_STREAM_OFFSET = 0x470;

        // Misc
        private string savegamePath;
        private int savegameOffset;
        private const int LARA_VEHICLE_ITEM_OFFSET = 0x56;
        private int sgBufferCursor;

        private readonly Dictionary<int, string> levelNames = new Dictionary<int, string>()
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
            { 40, "The Times Exclusive"             },
        };

        private void WriteInt32ToBuffer(byte[] buffer, int offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void WriteUInt32ToBuffer(byte[] buffer, int offset, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

        private void WriteUInt16ToBuffer(byte[] buffer, int offset, UInt16 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 2);
        }

        private void WriteInt16ToBuffer(byte[] buffer, int offset, Int16 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, 2);
        }

        public int GetHealthOffset(byte[] savegameData = null, bool areOffsetsDetermined = false)
        {
            if (savegameData == null)
            {
                savegameData = File.ReadAllBytes(savegamePath);
            }

            if (!areOffsetsDetermined)
            {
                DetermineDynamicOffsets(savegameData);
            }

            if (HEALTH_OFFSET != -1)
            {
                if (!IS_LARA_HEALTH_SERIALIZED)
                {
                    return savegameOffset + HEALTH_OFFSET;
                }

                Int16 value = BitConverter.ToInt16(savegameData, savegameOffset + HEALTH_OFFSET);

                if (value >= MIN_HEALTH_VALUE && value < MAX_HEALTH_VALUE)
                {
                    return savegameOffset + HEALTH_OFFSET;
                }
            }

            return -1;
        }

        private int GetVirtualCursorStartOffset(byte[] fileData, byte levelIndex)
        {
            for (int i = 0; i < HUB_LEVEL_COUNT; i++)
            {
                byte hubLevel = fileData[savegameOffset + HUB_LEVEL_IDS_OFFSET + i];

                if (hubLevel == levelIndex)
                {
                    return BitConverter.ToUInt16(fileData, savegameOffset + HUB_OFFSET_TABLE_OFFSET + (i * 2));
                }
            }

            return 0;
        }

        private void DetermineDynamicOffsets(byte[] fileData)
        {
            byte levelIndex = GetLevelIndex(fileData);

            // Reset health detection vars
            HEALTH_OFFSET = -1;
            LARA_DWORD_OFFSET = -1;

            // Cursor starts
            sgBufferCursor = 0;
            int virtualCursorStart = GetVirtualCursorStartOffset(fileData, levelIndex);

            // Initial fixed blocks
            sgBufferCursor += 0xB;
            sgBufferCursor += 0x20;
            sgBufferCursor += 0x11F;

            if (TR4EntityCache.EligibleStaticMeshCounts.TryGetValue(levelIndex, out int eligibleStaticMeshCount))
            {
                sgBufferCursor += ((eligibleStaticMeshCount + 15) / 16) * 2;
            }

            // Post-static-mesh flags block
            sgBufferCursor += 0x04;

            if (TR4EntityCache.LevelCameraCounts.TryGetValue(levelIndex, out int cameraCount))
            {
                sgBufferCursor += cameraCount * 0x02;
            }

            if (TR4EntityCache.LevelSpotcamCounts.TryGetValue(levelIndex, out int spotcamCount))
            {
                sgBufferCursor += spotcamCount * 0x02;
            }

            List<TR4Object> tr4Objects = TR4EntityCache.TR4ObjectsByLevel[levelIndex];

            for (int itemIndex = 0; itemIndex < tr4Objects.Count; itemIndex++)
            {
                TR4Object tr4Object = tr4Objects[itemIndex];

                int itemFlagsOffset = ENTITY_STREAM_OFFSET + virtualCursorStart + sgBufferCursor;
                int itemFlagsAbsoluteOffset = savegameOffset + itemFlagsOffset;

                UInt32 itemFlags = BitConverter.ToUInt32(fileData, itemFlagsAbsoluteOffset);
                sgBufferCursor += 0x04;

                // Deleted / killed item marker
                if ((itemFlags & 0x200) != 0)
                {
                    continue;
                }

                // No serialized item state
                if ((itemFlags & 0x800) == 0)
                {
                    continue;
                }

                // Save position
                if ((tr4Object.Flags00 & 0x08) != 0)
                {
                    sgBufferCursor += 0x09;

                    if ((itemFlags & 0x01) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }

                    if ((itemFlags & 0x02) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }

                    if ((itemFlags & 0x20) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }

                    if ((itemFlags & 0x40) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }
                }

                // Save animation
                if ((tr4Object.Flags00 & 0x40) != 0)
                {
                    sgBufferCursor += tr4Object.ObjectId == Globals.LARA_ENTITY_ID ? 0x07 : 0x06;
                }

                // Health / hit points
                bool hasHealthField = (itemFlags & 0x400) != 0;

                if (tr4Object.ObjectId == Globals.LARA_ENTITY_ID)
                {
                    HEALTH_OFFSET = ENTITY_STREAM_OFFSET + virtualCursorStart + sgBufferCursor;
                    IS_LARA_HEALTH_SERIALIZED = hasHealthField;
                    LARA_DWORD_OFFSET = itemFlagsOffset;
                    return;
                }

                if (hasHealthField)
                {
                    sgBufferCursor += 0x02;
                }

                // Extended item flags
                if ((tr4Object.Flags00 & 0x20) != 0)
                {
                    UInt32 extendedFlags = BitConverter.ToUInt32(fileData, savegameOffset + ENTITY_STREAM_OFFSET + virtualCursorStart + sgBufferCursor);

                    sgBufferCursor += 0x24;

                    if ((itemFlags & 0x80) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }

                    if ((itemFlags & 0x100) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }

                    if ((tr4Object.Flags00 & 0x02) != 0)
                    {
                        sgBufferCursor += 0x02;
                    }

                    // Creature / AI data block
                    if ((extendedFlags & 0x80000000) != 0)
                    {
                        sgBufferCursor += 0x49;
                    }
                }

                // Save mesh / extra object data
                if ((tr4Object.ObjectFlags & 0x2000) != 0)
                {
                    sgBufferCursor += 0x0C;
                }

                // TR4-specific object data blocks
                if (tr4Object.ObjectId == 0x1F)
                {
                    sgBufferCursor += 0x28;
                }

                if (tr4Object.ObjectId == 0x20)
                {
                    sgBufferCursor += 0x30;
                }
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

        private Int16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            if (!IS_LARA_HEALTH_SERIALIZED)
            {
                return MAX_HEALTH_VALUE;
            }

            return BitConverter.ToInt16(fileData, healthOffset);
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

        private byte[] WriteHealthValue(byte[] fileData, Int16 newHealth)
        {
            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                int laraDwordOffset = savegameOffset + LARA_DWORD_OFFSET;
                UInt32 laraDword = BitConverter.ToUInt32(fileData, laraDwordOffset);

                bool isPacked = (laraDword & ITEM_HEALTH_SERIALIZED_STATE) == 0;
                bool shouldPack = newHealth == MAX_HEALTH_VALUE;

                if (isPacked && !shouldPack)
                {
                    // Full health -> Partial health
                    UInt32 unpackedDword = laraDword | ITEM_HEALTH_SERIALIZED_STATE;
                    WriteUInt32ToBuffer(fileData, laraDwordOffset, unpackedDword);

                    ShiftBytesRight(ref fileData, healthOffset);
                    WriteInt16ToBuffer(fileData, healthOffset, newHealth);
                }
                else if (!isPacked && shouldPack)
                {
                    // Partial health -> Full health
                    UInt32 packedDword = laraDword & ~ITEM_HEALTH_SERIALIZED_STATE;
                    WriteUInt32ToBuffer(fileData, laraDwordOffset, packedDword);

                    ShiftBytesLeft(ref fileData, healthOffset);
                }
                else if (isPacked && shouldPack)
                {
                    // Already full health, no-op
                }
                else
                {
                    // Partial health -> Partial health
                    WriteInt16ToBuffer(fileData, healthOffset, newHealth);
                }
            }

            return fileData;
        }

        private void ShiftBytesRight(ref byte[] fileData, int healthOffset)
        {
            int boundary = savegameOffset + Globals.SAVEGAME_SIZE_TRX2;

            Array.Resize(ref fileData, fileData.Length + 2);

            for (int i = boundary - 1; i >= healthOffset; i--)
            {
                fileData[i + 2] = fileData[i];
            }
        }

        private void ShiftBytesLeft(ref byte[] fileData, int healthOffset)
        {
            int boundary = savegameOffset + Globals.SAVEGAME_SIZE_TRX2;

            for (int i = healthOffset; i < boundary - 2; i++)
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
            DetermineDynamicOffsets(fileData);

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

            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                Int16 health = GetHealthValue(fileData, healthOffset);
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
            DetermineDynamicOffsets(fileData);

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
                fileData = WriteHealthValue(fileData, (Int16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
        }

        public bool IsLaraInVehicle(byte[] fileData)
        {
            return BitConverter.ToInt16(fileData, savegameOffset + LARA_VEHICLE_ITEM_OFFSET) != -1;
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
            return BitConverter.ToInt32(fileData, savegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;
        }

        public void UpdateDisplayName(Savegame savegame, byte[] fileData)
        {
            bool isSavegamePresent = BitConverter.ToInt32(fileData, savegame.Offset + Globals.SLOT_STATUS_OFFSET) != 0;

            if (isSavegamePresent)
            {
                byte levelIndex = fileData[savegame.Offset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, savegame.Offset + SAVE_NUMBER_OFFSET);

                if (levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
                {
                    bool isNewGamePlus = BitConverter.ToInt32(fileData, savegame.Offset + NEW_GAME_PLUS_OFFSET) != 0;

                    savegame.UpdateDisplayName(levelName, saveNumber, isNewGamePlus);
                }
            }
        }

        public void PopulateEmptySlots(ComboBox cmbSavegames)
        {
            if (cmbSavegames.Items.Count == Globals.MAX_SAVEGAMES)
            {
                return;
            }

            byte[] fileData = File.ReadAllBytes(savegamePath);

            for (int i = cmbSavegames.Items.Count; i < Globals.MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR4 + (i * Globals.SAVEGAME_SIZE_TRX2);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR4)
                {
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;

                    if (isSavegamePresent && levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR4) / Globals.SAVEGAME_SIZE_TRX2;

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
                            bool isNewGamePlus = BitConverter.ToInt32(fileData, currentSavegameOffset + NEW_GAME_PLUS_OFFSET) != 0;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, isNewGamePlus);
                            cmbSavegames.Items.Add(savegame);
                        }
                    }
                }
            }
        }

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            byte[] fileData = File.ReadAllBytes(savegamePath);
            int numSavegames = 0;

            for (int i = 0; i < Globals.MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR4 + (i * Globals.SAVEGAME_SIZE_TRX2);

                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;

                if (isSavegamePresent && levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
                {
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR4) / Globals.SAVEGAME_SIZE_TRX2;
                    bool isNewGamePlus = BitConverter.ToInt32(fileData, currentSavegameOffset + NEW_GAME_PLUS_OFFSET) != 0;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, isNewGamePlus);
                    cmbSavegames.Items.Add(savegame);

                    numSavegames++;
                }
            }

            if (numSavegames > 0)
            {
                cmbSavegames.SelectedIndex = 0;
            }
        }
    }
}
