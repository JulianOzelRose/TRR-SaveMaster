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
        private const int SLOT_STATUS_OFFSET = 0x0;
        private const int NEW_GAME_PLUS_OFFSET = 0x004;
        private const int SAVE_NUMBER_OFFSET = 0x008;
        private const int LEVEL_INDEX_OFFSET_PREPATCH = 0x8D2;
        private const int LARA_OUTFIT_OFFSET_PREPATCH = 0x970;

        // Platform or patch-dependent offsets
        private int LEVEL_INDEX_OFFSET;
        private int BASE_SAVEGAME_OFFSET_TR3;
        private int MAX_SAVEGAME_OFFSET_TR3;
        private int SAVEGAME_SIZE;
        private int LARA_OUTFIT_OFFSET;
        private int SAVEGAME_VERSION_OFFSET;
        private int CHALLENGE_MODE_RNG_SEED_OFFSET;
        private int CHALLENGE_MODE_OFFSET;
        private int CHALLENGE_MODE_MAX_HEALTH_OFFSET;
        private int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET;
        private int CHALLENGE_MODE_ENEMY_TYPE_OFFSET;
        private int CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET;

        // PC offsets
        private const int LEVEL_INDEX_OFFSET_PC = 0x8D2;
        private const int LARA_OUTFIT_OFFSET_PC = 0x970;
        private const int SAVEGAME_VERSION_OFFSET_PC = 0x988;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PC = 0x990;
        private const int CHALLENGE_MODE_OFFSET_PC = 0x98C;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC = 0x99A;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC = 0x99E;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC = 0x9A1;
        private const int CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET_PC = 0x9A3;

        // Mobile offsets
        private const int LEVEL_INDEX_OFFSET_MOBILE = 0x912;
        private const int LARA_OUTFIT_OFFSET_MOBILE = 0x9B0;
        private const int SAVEGAME_VERSION_OFFSET_MOBILE = 0x9C8;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_MOBILE = 0x9D0;
        private const int CHALLENGE_MODE_OFFSET_MOBILE = 0x9CC;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_MOBILE = 0x9E5;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_MOBILE = 0x9E9;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_MOBILE = 0x9EC;
        private const int CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET_MOBILE = 0x9EE;

        // Console offsets
        private const int LEVEL_INDEX_OFFSET_CONSOLE = 0x8D2;
        private const int LARA_OUTFIT_OFFSET_CONSOLE = 0x970;
        private const int SAVEGAME_VERSION_OFFSET_CONSOLE = 0x988;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_CONSOLE = 0x990;
        private const int CHALLENGE_MODE_OFFSET_CONSOLE = 0x98C;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_CONSOLE = 0x99A;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_CONSOLE = 0x99E;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_CONSOLE = 0x9A1;
        private const int CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET_CONSOLE = 0x9A3;

        // Patch-dependent
        private const int BASE_SAVEGAME_OFFSET_TR3_PREPATCH = 0xE2004;
        private const int BASE_SAVEGAME_OFFSET_TR3_PATCH5 = 0x1A2004;
        private const int MAX_SAVEGAME_OFFSET_TR3_PREPATCH = 0x152004;
        private const int MAX_SAVEGAME_OFFSET_TR3_PATCH5 = 0x26B804;

        // Static offsets (per level)
        private int SMALL_MEDIPACK_OFFSET;
        private int LARGE_MEDIPACK_OFFSET;
        private int FLARES_OFFSET;
        private int WEAPONS_CONFIG_NUM_OFFSET;
        private int COLLECTIBLE_CRYSTALS_OFFSET;
        private int DEAGLE_AMMO_OFFSET;
        private int HARPOON_GUN_AMMO_OFFSET;
        private int MP5_AMMO_OFFSET;
        private int UZI_AMMO_OFFSET;
        private int ROCKET_LAUNCHER_AMMO_OFFSET;
        private int GRENADE_LAUNCHER_AMMO_OFFSET;
        private int SHOTGUN_AMMO_OFFSET;

        // Dynamic ammo offsets
        private int harpoonGunAmmoOffset2;
        private int deagleAmmoOffset2;
        private int mp5AmmoOffset2;
        private int uziAmmoOffset2;
        private int rocketLauncherAmmoOffset2;
        private int grenadeLauncherAmmoOffset2;
        private int shotgunAmmoOffset2;

        // Weapon flags
        private const UInt16 WEAPON_AVAILABLE = 0x1;
        private const UInt16 WEAPON_PISTOLS = 0x2;
        private const UInt16 WEAPON_DEAGLE = 0x4;
        private const UInt16 WEAPON_UZIS = 0x8;
        private const UInt16 WEAPON_SHOTGUN = 0x10;
        private const UInt16 WEAPON_MP5 = 0x20;
        private const UInt16 WEAPON_ROCKET_LAUNCHER = 0x40;
        private const UInt16 WEAPON_GRENADE_LAUNCHER = 0x80;
        private const UInt16 WEAPON_HARPOON_GUN = 0x100;
        private const UInt16 WEAPONS_MASK = WEAPON_PISTOLS | WEAPON_DEAGLE | WEAPON_UZIS | WEAPON_SHOTGUN | WEAPON_MP5 | WEAPON_ROCKET_LAUNCHER | WEAPON_GRENADE_LAUNCHER | WEAPON_HARPOON_GUN;

        // Entity block starts
        private const int ENTITY_BLOCK_START_PC = 0x998;
        private const int ENTITY_BLOCK_START_MOBILE = 0x9E3;
        private const int ENTITY_BLOCK_START_CONSOLE = 0x998;
        private const int ENTITY_BLOCK_START_PC_PREPATCH = 0x988;
        private const int ENTITY_BLOCK_START_CONSOLE_PREPATCH = 0x986;
        private const int ENTITY_BLOCK_START_NS_PREPATCH = 0x986;

        // Health
        private const Int16 MAX_HEALTH_VALUE_DEFAULT = 1000;
        private const Int16 MIN_HEALTH_VALUE = 1;
        private Int16 MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
        private int HEALTH_OFFSET = -1;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private const int ENTITY_AI_BLOCK_SIZE = 0x1A;
        private int AMMO_WRITE_LOWER_BOUND;
        private int AMMO_WRITE_UPPER_BOUND;
        private int LARA_VEHICLE_ITEM_OFFSET;
        private int sgBufferCursor = 0;
        private UInt32 rngState;

        public readonly Dictionary<int, string> levelNames = new Dictionary<int, string>()
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

            bool isPrepatch = IsPrepatchSavegameFile(savegameData);

            if (!isPrepatch)
            {
                bool isChallengeMode = IsChallengeMode(savegameData);
                MAX_HEALTH_VALUE = isChallengeMode ? GetChallengeModeMaxHealth(savegameData) : MAX_HEALTH_VALUE_DEFAULT;
            }
            else
            {
                MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
            }

            Int16 value = BitConverter.ToInt16(savegameData, savegameOffset + HEALTH_OFFSET);

            if (value >= MIN_HEALTH_VALUE && value <= MAX_HEALTH_VALUE)
            {
                return savegameOffset + HEALTH_OFFSET;
            }

            return -1;
        }

        public void DetermineOffsets(byte[] fileData)
        {
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PREPATCH;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
                LARA_OUTFIT_OFFSET = LARA_OUTFIT_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PATCH5;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PATCH5;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PATCH5;

                if (platform == Platform.PC)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PC;
                    LARA_OUTFIT_OFFSET = LARA_OUTFIT_OFFSET_PC;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_PC;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_PC;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PC;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC;
                    CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET = CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET_PC;
                }
                else if (platform.IsMobile())
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_MOBILE;
                    LARA_OUTFIT_OFFSET = LARA_OUTFIT_OFFSET_MOBILE;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_MOBILE;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_MOBILE;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_MOBILE;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_MOBILE;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_MOBILE;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_MOBILE;
                    CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET = CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET_MOBILE;
                }
                else if (platform.IsConsole())
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_CONSOLE;
                    LARA_OUTFIT_OFFSET = LARA_OUTFIT_OFFSET_CONSOLE;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_CONSOLE;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_CONSOLE;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_CONSOLE;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_CONSOLE;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_CONSOLE;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_CONSOLE;
                    CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET = CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET_CONSOLE;
                }
            }

            Int16 levelIndex = GetLevelIndex(fileData);

            DEAGLE_AMMO_OFFSET = 0x62 + (levelIndex * 0x40);
            UZI_AMMO_OFFSET = 0x64 + (levelIndex * 0x40);
            SHOTGUN_AMMO_OFFSET = 0x66 + (levelIndex * 0x40);
            MP5_AMMO_OFFSET = 0x68 + (levelIndex * 0x40);
            ROCKET_LAUNCHER_AMMO_OFFSET = 0x6A + (levelIndex * 0x40);
            HARPOON_GUN_AMMO_OFFSET = 0x6C + (levelIndex * 0x40);
            GRENADE_LAUNCHER_AMMO_OFFSET = 0x6E + (levelIndex * 0x40);
            SMALL_MEDIPACK_OFFSET = 0x70 + (levelIndex * 0x40);
            LARGE_MEDIPACK_OFFSET = 0x71 + (levelIndex * 0x40);
            FLARES_OFFSET = 0x73 + (levelIndex * 0x40);
            COLLECTIBLE_CRYSTALS_OFFSET = 0x74 + (levelIndex * 0x40);
            WEAPONS_CONFIG_NUM_OFFSET = 0x9C + (levelIndex * 0x40);
        }

        private void SeedRNG(UInt32 seed)
        {
            rngState = seed;
        }

        private int NextRNG()
        {
            rngState = unchecked(rngState * 0x343FDu + 0x269EC3u);
            return (int)((rngState >> 0x10) & 0x7FFFu);
        }

        private HashSet<int> BuildRemovalSet(
            List<int> entityIds,
            Dictionary<int, TR3Object> levelObjects,
            Int16 levelIndex,
            byte enemyNumbers)
        {
            var removalSet = new HashSet<int>();

            // Only applies to EN modes below Normal
            if (enemyNumbers >= Globals.CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                return removalSet;
            }

            // =========================
            // 1. Build candidate pool
            // =========================
            var candidates = new List<int>();

            for (int i = 0; i < entityIds.Count; i++)
            {
                int objectId = entityIds[i];

                // Must exist in EnemyDefinitions
                if (!TR3EntityCache.TR3EnemyRemovableByObjectId.TryGetValue(objectId, out bool removable)) continue;

                // Must be removable
                if (!removable) continue;

                // Skip unchangeable indices
                if (TR3EntityCache.UnchangeableEntitiesByLevel.TryGetValue(levelIndex, out var locked) && locked.Contains(i)) continue;

                candidates.Add(i);
            }

            int candidateCount = candidates.Count;
            if (candidateCount == 0)
            {
                return removalSet;
            }

            // =========================
            // 2. Compute removal count
            // =========================
            int rawPercent = TR3EntityCache.EnemyRemovalPercents[enemyNumbers];

            // Engine negates this
            int percent = -rawPercent;

            int removeCount = ComputeRemovalCount(candidateCount, percent);

            if (removeCount <= 0)
            {
                return removalSet;
            }

            // =========================
            // 3. RNG selection (retry)
            // =========================
            while (removalSet.Count < removeCount)
            {
                int roll = NextRNG();
                int idx = roll % candidateCount;

                int entityIndex = candidates[idx];

                if (removalSet.Contains(entityIndex))
                {
                    continue; // retry (CRITICAL)
                }

                removalSet.Add(entityIndex);
            }

            return removalSet;
        }

        private int ComputeRemovalCount(int candidateCount, int percent)
        {
            // percent is negative
            double value = (candidateCount * percent) / 100.0;

            int floor = (int)value;
            double fraction = value - floor;

            if (fraction < 0.5)
            {
                return Math.Max(0, floor);
            }

            if (fraction > 0.5)
            {
                return Math.Max(0, floor + 1);
            }

            // exactly 0.5 -> RNG tie-break
            int roll = NextRNG() % 100;

            int result = (roll < 50) ? floor : floor + 1;

            return Math.Max(0, result);
        }

        private void ApplyAddEnemies(
            List<int> result,
            Int16 levelIndex,
            byte enemyNumbers)
        {
            if (enemyNumbers <= Globals.CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                return;
            }

            if (!TR3EntityCache.TR3AddEnemyTableByLevel.TryGetValue(levelIndex, out var addList))
            {
                return;
            }

            int totalAddEntries = addList.Count;
            if (totalAddEntries == 0)
            {
                return;
            }

            int percent = TR3EntityCache.EnemyRemovalPercents[enemyNumbers];
            // Same table: 25/50/100 for > Normal

            int selectedCount = ComputePositiveSelectionCount(totalAddEntries, percent);

            if (selectedCount <= 0)
            {
                return;
            }

            var selected = new bool[totalAddEntries];
            int selectedSoFar = 0;

            while (selectedSoFar < selectedCount)
            {
                int randomIndex = NextRNG() % totalAddEntries;

                if (selected[randomIndex])
                {
                    continue;
                }

                selected[randomIndex] = true;
                selectedSoFar++;
            }

            // IMPORTANT: Append in original add-table order
            for (int i = 0; i < totalAddEntries; i++)
            {
                if (selected[i])
                {
                    result.Add(addList[i]);
                }
            }
        }

        private int ComputePositiveSelectionCount(int totalCount, int percent)
        {
            double value = (double)(totalCount * percent) / 100.0;
            int floor = (int)value;
            double fraction = value - floor;

            if (fraction < 0.5)
            {
                return floor;
            }

            if (fraction > 0.5)
            {
                return floor + 1;
            }

            // exactly .5
            int roll = NextRNG() % 100;
            return (roll < 50) ? floor : floor + 1;
        }

        private List<int> ApplyChallengeModeMutations(List<int> baseList, Int16 levelIndex, byte enemyNumbers, byte enemyType, UInt32 seed)
        {
            var result = new List<int>(baseList);

            if (enemyNumbers <= Globals.CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL && enemyType == Globals.CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return result;
            }

            if (!TR3EntityCache.ChallengeModeItemCountModifiersByLevel.TryGetValue(levelIndex, out var levelModifiers))
            {
                return result;
            }

            if (!levelModifiers.TryGetValue(enemyNumbers, out int addCount))
            {
                return result;
            }

            if (addCount <= 0 && enemyType == Globals.CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return result;
            }

            SeedRNG(seed);

            if (!TR3EntityCache.TR3ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
            {
                if (enemyType != Globals.CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    return result;
                }
            }

            // ===================================
            // EN APPEND FIRST
            // ===================================
            if (enemyNumbers > Globals.CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                ApplyAddEnemies(result, levelIndex, enemyNumbers);
            }

            // ===================================
            // SINGLE ET MUTATION PASS (FULL LIST)
            // ===================================
            if (enemyType != Globals.CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                var catType = enemyType;

                if (!TR3EntityCache.ChallengeModeCatGroups.TryGetValue(catType, out var catGroups))
                {
                    return result;
                }

                Dictionary<string, string> catMapping = null;

                if (enemyType != Globals.CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    if (!TR3EntityCache.ChallengeModeCatMapping.TryGetValue(enemyType, out catMapping))
                    {
                        return result;
                    }
                }

                var objectToCat = new Dictionary<int, string>();

                foreach (var kvp in catGroups)
                {
                    foreach (var entry in kvp.Value)
                    {
                        objectToCat[entry.ObjectId] = kvp.Key;
                    }
                }

                var removalSet = BuildRemovalSet(result, levelObjects, levelIndex, enemyNumbers);

                for (int i = 0; i < result.Count; i++)
                {
                    int originalId = result[i];

                    if (!levelObjects.TryGetValue(originalId, out var obj)) continue;
                    if ((obj.Flags00 & 0x02) == 0) continue;

                    bool isFriendly =
                        (TR3EntityCache.TR3EnemyFriendlyByObjectId.TryGetValue(originalId, out bool isUniversallyFriendly) && isUniversallyFriendly) ||
                        (TR3EntityCache.TR3EnemyFriendlyByLevel.TryGetValue(levelIndex, out int[] friendlyIds) && friendlyIds.Contains(originalId));

                    if (isFriendly)
                    {
                        continue;
                    }

                    if (!objectToCat.TryGetValue(originalId, out var sourceCat)) continue;
                    if (!catGroups.TryGetValue(sourceCat, out var sourceEntries)) continue;
                    if (TR3EntityCache.UnchangeableEntitiesByLevel.TryGetValue(levelIndex, out var set) && set.Contains(i)) continue;
                    if (removalSet.Contains(i)) continue;

                    TR3CatEntry sourceEntry = null;

                    foreach (var e in sourceEntries)
                    {
                        if (e.ObjectId == originalId)
                        {
                            sourceEntry = e;
                            break;
                        }
                    }

                    if (sourceEntry == null) continue;

                    int gateRoll = NextRNG() % 100;
                    if (sourceEntry.Weight < gateRoll) continue;

                    string targetCat;

                    if (enemyType == Globals.CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                    {
                        targetCat = sourceCat;
                    }
                    else
                    {
                        if (!catMapping.TryGetValue(sourceCat, out targetCat))
                        {
                            continue; // mapping missing = no mutation, but gate RNG was already consumed
                        }
                    }

                    if (!catGroups.TryGetValue(targetCat, out var targetEntries)) continue;

                    int pickRoll = NextRNG() % 100;
                    int cumulative = 0;

                    foreach (var entry in targetEntries)
                    {
                        cumulative += entry.Meta2;
                        if (pickRoll <= cumulative)
                        {
                            result[i] = entry.ObjectId;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private int GetEntityBlockStart(bool isPrepatch)
        {
            if (isPrepatch)
            {
                if (platform == Platform.PC)
                {
                    return ENTITY_BLOCK_START_PC_PREPATCH;
                }
                else if (platform.IsConsole())
                {
                    return ENTITY_BLOCK_START_CONSOLE_PREPATCH;
                }

                return ENTITY_BLOCK_START_PC_PREPATCH;
            }
            else
            {
                if (platform == Platform.PC)
                {
                    return ENTITY_BLOCK_START_PC;
                }
                else if (platform.IsMobile())
                {
                    return ENTITY_BLOCK_START_MOBILE;
                }
                else if (platform.IsConsole())
                {
                    return ENTITY_BLOCK_START_CONSOLE;
                }

                return ENTITY_BLOCK_START_PC;
            }
        }

        private void DetermineDynamicOffsets(byte[] fileData)
        {
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNativePatch5 = IsNativePatch5Format(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            Int16 levelIndex = GetLevelIndex(fileData);

            // Entity & ID lists
            var baseList = TR3EntityCache.LevelObjectIdsByLevel[levelIndex];
            var levelObjectIds = new List<int>(baseList);

            // Reset health offset
            HEALTH_OFFSET = -1;

            // Cursor start
            sgBufferCursor = GetEntityBlockStart(isPrepatch);

            // Challenge Mode param block
            if (isChallengeMode && isNativePatch5 && !isPrepatch)
            {
                byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
                byte enemyType = GetChallengeModeEnemyType(fileData);
                UInt32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);
                levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

                sgBufferCursor += Globals.CHALLENGE_MODE_PARAM_BLOCK_SIZE;
            }

            // Fixed blocks
            sgBufferCursor += 4;
            sgBufferCursor += 0x118;

            int gLevelStateEntryCount = TR3EntityCache.LevelStateEntryCounts[levelIndex];
            sgBufferCursor += gLevelStateEntryCount * 2;

            if (isNativePatch5 && !isPrepatch)
            {
                sgBufferCursor += 4;
            }

            for (int itemIndex = 0; itemIndex < levelObjectIds.Count; itemIndex++)
            {
                int objectId = levelObjectIds[itemIndex];

                if (isNativePatch5 && !isPrepatch)
                {
                    sgBufferCursor += 4;
                }

                if (!TR3EntityCache.TR3ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
                {
                    throw new Exception($"{Globals.ERROR_MSG_MISSING_LEVEL_DEFINITION} {levelIndex}.");
                }

                if (!levelObjects.TryGetValue(objectId, out var tr3Object))
                {
                    throw new Exception($"{Globals.ERROR_MSG_MISSING_OBJECT_DEFINITION} (object ID: 0x{objectId:X}).");
                }

                if ((tr3Object.Flags00 & 0x08) != 0)
                {
                    sgBufferCursor += 0x1A;
                }

                if ((tr3Object.Flags00 & 0x40) != 0)
                {
                    sgBufferCursor += 0x0A;
                }

                if ((tr3Object.Flags00 & 0x10) != 0)
                {
                    if (tr3Object.ObjectId == Globals.LARA_ENTITY_ID)
                    {
                        HEALTH_OFFSET = sgBufferCursor;
                    }

                    sgBufferCursor += 0x02;
                }

                if ((tr3Object.Flags00 & 0x20) != 0)
                {
                    int blockStart = sgBufferCursor;
                    bool has02 = (tr3Object.Flags00 & 0x02) != 0;

                    int increment = has02 ? 0x18 : 0x16;

                    short aiWord = BitConverter.ToInt16(fileData, savegameOffset + blockStart + 2);
                    bool isEntityAIActive = aiWord < 0 && (aiWord & 0x00FF) != 0;

                    if (isEntityAIActive)
                    {
                        increment += ENTITY_AI_BLOCK_SIZE;
                    }

                    sgBufferCursor += increment;
                }

                if ((tr3Object.Flags00 & 0x80) != 0)
                {
                    sgBufferCursor += 0x4;
                }

                if (objectId == 0x12)
                {
                    sgBufferCursor += 0x8;
                }

                if (objectId == 0xF)
                {
                    sgBufferCursor += 0x1C;
                }

                if (objectId == 0xE)
                {
                    sgBufferCursor += 0x30;
                }

                if (objectId == 0x11)
                {
                    sgBufferCursor += 0x20;
                }

                if (objectId == 0x10)
                {
                    sgBufferCursor += 0x2C;
                }

                if (objectId == 0x13)
                {
                    sgBufferCursor += 0x10;
                }

                if (objectId == 0x123)
                {
                    sgBufferCursor += 0x2;
                }
            }

            LARA_VEHICLE_ITEM_OFFSET = sgBufferCursor + 0x48;

            deagleAmmoOffset2 = sgBufferCursor + 0x168;
            uziAmmoOffset2 = sgBufferCursor + 0x170;
            shotgunAmmoOffset2 = sgBufferCursor + 0x178;
            harpoonGunAmmoOffset2 = sgBufferCursor + 0x180;
            rocketLauncherAmmoOffset2 = sgBufferCursor + 0x188;
            grenadeLauncherAmmoOffset2 = sgBufferCursor + 0x190;
            mp5AmmoOffset2 = sgBufferCursor + 0x198;
        }

        private bool IsNewGamePlus(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + NEW_GAME_PLUS_OFFSET) != 0;
        }

        private bool IsTheLostArtifact(Int16 levelIndex)
        {
            return levelIndex >= 21;
        }

        private bool IsPrepatchSavegameFile(byte[] fileData)
        {
            return BitConverter.ToUInt32(fileData, Globals.SAVEFILE_VERSION_OFFSET) == Globals.SAVEFILE_TRX_PREPATCH;
        }

        private bool IsNativePatch5Format(byte[] fileData)
        {
            UInt32 savegameVersion = BitConverter.ToUInt32(fileData, savegameOffset + SAVEGAME_VERSION_OFFSET);
            return savegameVersion >= 2;
        }

        public bool IsChallengeMode(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_OFFSET] == 1;
        }

        public Int16 GetChallengeModeMaxHealth(byte[] fileData)
        {
            byte maxHealthSetting = fileData[savegameOffset + CHALLENGE_MODE_MAX_HEALTH_OFFSET];

            Int16 maxHealth;

            if (maxHealthSetting == 0) maxHealth = 100;
            else if (maxHealthSetting == 1) maxHealth = 250;
            else if (maxHealthSetting == 2) maxHealth = 500;
            else if (maxHealthSetting == 3) maxHealth = 1000;
            else if (maxHealthSetting == 4) maxHealth = 1500;
            else if (maxHealthSetting == 5) maxHealth = 1750;
            else if (maxHealthSetting == 6) maxHealth = 2000;
            else if (maxHealthSetting == 7) maxHealth = 5000;
            else maxHealth = MAX_HEALTH_VALUE_DEFAULT;

            bool useOutfitBonus = (fileData[savegameOffset + CHALLENGE_MODE_USE_OUTFIT_BONUS_OFFSET] & 0x02) != 0;

            if (useOutfitBonus)
            {
                Int32 outfit = BitConverter.ToInt32(fileData, savegameOffset + LARA_OUTFIT_OFFSET);
                int outfitBonus = (outfit - 0x0F) / 3;

                if (outfitBonus == 8)
                {
                    maxHealth = (Int16)(maxHealth * 0.5);
                }

                if (outfitBonus == 7)
                {
                    maxHealth = (Int16)(maxHealth * 1.25);
                }
            }

            return maxHealth;
        }

        private byte GetChallengeModeEnemyNumbers(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET];
        }

        private byte GetChallengeModeEnemyType(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_TYPE_OFFSET];
        }

        private UInt32 GetChallengeModeRNGSeed(byte[] fileData)
        {
            return BitConverter.ToUInt32(fileData, savegameOffset + CHALLENGE_MODE_RNG_SEED_OFFSET);
        }

        private Int32 GetSaveNumber(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + SAVE_NUMBER_OFFSET);
        }

        private Int16 GetLevelIndex(byte[] fileData)
        {
            return BitConverter.ToInt16(fileData, savegameOffset + LEVEL_INDEX_OFFSET);
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

        private UInt16 GetWeaponsConfigNum(byte[] fileData)
        {
            return BitConverter.ToUInt16(fileData, savegameOffset + WEAPONS_CONFIG_NUM_OFFSET);
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

        private Int16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            return BitConverter.ToInt16(fileData, healthOffset);
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

        private void WriteWeaponsConfigNum(byte[] fileData, UInt16 value)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + WEAPONS_CONFIG_NUM_OFFSET, value);
        }

        private void WriteHealthValue(byte[] fileData, Int16 newHealth)
        {
            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                WriteInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            if (shotgunAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || shotgunAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteDeagleAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + DEAGLE_AMMO_OFFSET, ammo);

            if (deagleAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || deagleAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + deagleAmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + deagleAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);

            if (uziAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || uziAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + uziAmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private void WriteGrenadeLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + GRENADE_LAUNCHER_AMMO_OFFSET, ammo);

            if (grenadeLauncherAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || grenadeLauncherAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, 0);
            }
        }

        private void WriteMP5Ammo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + MP5_AMMO_OFFSET, ammo);

            if (mp5AmmoOffset2 < AMMO_WRITE_LOWER_BOUND || mp5AmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + mp5AmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + mp5AmmoOffset2, 0);
            }
        }

        private void WriteRocketLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + ROCKET_LAUNCHER_AMMO_OFFSET, ammo);

            if (rocketLauncherAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || rocketLauncherAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + rocketLauncherAmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + rocketLauncherAmmoOffset2, 0);
            }
        }

        private void WriteHarpoonGunAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + HARPOON_GUN_AMMO_OFFSET, ammo);

            if (harpoonGunAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || harpoonGunAmmoOffset2 > AMMO_WRITE_UPPER_BOUND)
            {
                return;
            }

            WriteInt32ToBuffer(fileData, savegameOffset + harpoonGunAmmoOffset2, (Int32)ammo);
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
            DetermineDynamicOffsets(fileData);

            Int16 levelIndex = GetLevelIndex(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNewGamePlus = IsNewGamePlus(fileData);
            bool isTheLostArtifact = IsTheLostArtifact(levelIndex);

            MAX_HEALTH_VALUE = (isChallengeMode && !isPrepatch) ? GetChallengeModeMaxHealth(fileData) : MAX_HEALTH_VALUE_DEFAULT;
            trbHealth.Maximum = MAX_HEALTH_VALUE;

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

            if (isTheLostArtifact)
            {
                nudCollectibleCrystals.Enabled = false;
                lblCollectibleCrystals.Visible = false;
                nudCollectibleCrystals.Value = 0;
                nudCollectibleCrystals.Visible = false;
            }
            else
            {
                lblCollectibleCrystals.Text = isNewGamePlus ? "Savegame Crystals:" : "Collectible Crystals:";
                nudCollectibleCrystals.Enabled = true;
                lblCollectibleCrystals.Visible = true;
                nudCollectibleCrystals.Value = GetNumCollectibleCrystals(fileData);
                nudCollectibleCrystals.Visible = true;
            }

            UInt16 weaponsConfigNum = GetWeaponsConfigNum(fileData);

            chkPistols.Checked = (weaponsConfigNum & WEAPON_PISTOLS) != 0;
            chkDeagle.Checked = (weaponsConfigNum & WEAPON_DEAGLE) != 0;
            chkUzis.Checked = (weaponsConfigNum & WEAPON_UZIS) != 0;
            chkShotgun.Checked = (weaponsConfigNum & WEAPON_SHOTGUN) != 0;
            chkMP5.Checked = (weaponsConfigNum & WEAPON_MP5) != 0;
            chkRocketLauncher.Checked = (weaponsConfigNum & WEAPON_ROCKET_LAUNCHER) != 0;
            chkGrenadeLauncher.Checked = (weaponsConfigNum & WEAPON_GRENADE_LAUNCHER) != 0;
            chkHarpoonGun.Checked = (weaponsConfigNum & WEAPON_HARPOON_GUN) != 0;

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

        public void WriteChanges(byte[] fileData, CheckBox chkPistols, CheckBox chkDeagle, CheckBox chkUzis, CheckBox chkShotgun,
            CheckBox chkMP5, CheckBox chkRocketLauncher, CheckBox chkGrenadeLauncher, CheckBox chkHarpoonGun,
            NumericUpDown nudSaveNumber, NumericUpDown nudFlares, NumericUpDown nudSmallMedipacks,
            NumericUpDown nudLargeMedipacks, NumericUpDown nudShotgunAmmo, NumericUpDown nudDeagleAmmo,
            NumericUpDown nudGrenadeLauncherAmmo, NumericUpDown nudRocketLauncherAmmo, NumericUpDown nudHarpoonGunAmmo,
            NumericUpDown nudMP5Ammo, NumericUpDown nudUziAmmo, TrackBar trbHealth, NumericUpDown nudCollectibleCrystals)
        {
            DetermineOffsets(fileData);
            DetermineDynamicOffsets(fileData);

            WriteSaveNumber(fileData, (Int32)nudSaveNumber.Value);
            WriteNumFlares(fileData, (byte)nudFlares.Value);
            WriteNumSmallMedipacks(fileData, (byte)nudSmallMedipacks.Value);
            WriteNumLargeMedipacks(fileData, (byte)nudLargeMedipacks.Value);

            UInt16 newWeaponsConfigNum = GetWeaponsConfigNum(fileData);

            newWeaponsConfigNum &= unchecked((UInt16)~WEAPONS_MASK);
            newWeaponsConfigNum |= WEAPON_AVAILABLE;

            if (chkPistols.Checked) newWeaponsConfigNum |= WEAPON_PISTOLS;
            if (chkDeagle.Checked) newWeaponsConfigNum |= WEAPON_DEAGLE;
            if (chkUzis.Checked) newWeaponsConfigNum |= WEAPON_UZIS;
            if (chkShotgun.Checked) newWeaponsConfigNum |= WEAPON_SHOTGUN;
            if (chkMP5.Checked) newWeaponsConfigNum |= WEAPON_MP5;
            if (chkRocketLauncher.Checked) newWeaponsConfigNum |= WEAPON_ROCKET_LAUNCHER;
            if (chkGrenadeLauncher.Checked) newWeaponsConfigNum |= WEAPON_GRENADE_LAUNCHER;
            if (chkHarpoonGun.Checked) newWeaponsConfigNum |= WEAPON_HARPOON_GUN;

            WriteWeaponsConfigNum(fileData, newWeaponsConfigNum);

            Int16 levelIndex = GetLevelIndex(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isTheLostArtifact = IsTheLostArtifact(levelIndex);

            int entityBlockStart = GetEntityBlockStart(isPrepatch);

            AMMO_WRITE_LOWER_BOUND = entityBlockStart;
            AMMO_WRITE_UPPER_BOUND = SAVEGAME_SIZE - 4;

            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));
            WriteDeagleAmmo(fileData, chkDeagle.Checked, (UInt16)nudDeagleAmmo.Value);
            WriteGrenadeLauncherAmmo(fileData, chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value);
            WriteRocketLauncherAmmo(fileData, chkRocketLauncher.Checked, (UInt16)nudRocketLauncherAmmo.Value);
            WriteHarpoonGunAmmo(fileData, chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value);
            WriteMP5Ammo(fileData, chkMP5.Checked, (UInt16)nudMP5Ammo.Value);
            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value);

            if (!isTheLostArtifact)
            {
                WriteNumCollectibleCrystals(fileData, (byte)nudCollectibleCrystals.Value);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (Int16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
        }

        public bool IsLaraInVehicle(byte[] fileData)
        {
            return BitConverter.ToInt16(fileData, savegameOffset + LARA_VEHICLE_ITEM_OFFSET) != -1;
        }

        public bool IsLaraFreefalling(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 10];
            byte byteFlag2 = fileData[healthOffset - 9];
            byte byteFlag3 = fileData[healthOffset - 8];
            byte byteFlag4 = fileData[healthOffset - 7];

            if (byteFlag1 == 0x09 && byteFlag2 == 0x00 && byteFlag3 == 0x09 && byteFlag4 == 0x00) return true;

            return false;
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
            return BitConverter.ToInt32(fileData, savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        public void UpdateDisplayName(Savegame savegame, byte[] fileData)
        {
            bool isSavegamePresent = BitConverter.ToInt32(fileData, savegame.Offset + SLOT_STATUS_OFFSET) != 0;

            if (isSavegamePresent)
            {
                Int16 levelIndex = BitConverter.ToInt16(fileData, savegame.Offset + LEVEL_INDEX_OFFSET);
                Int32 saveNumber = BitConverter.ToInt32(fileData, savegame.Offset + SAVE_NUMBER_OFFSET);

                if (levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
                {
                    bool isPrepatch = IsPrepatchSavegameFile(fileData);
                    bool isNewGamePlus = BitConverter.ToInt32(fileData, savegame.Offset + NEW_GAME_PLUS_OFFSET) != 0;
                    bool isChallengeMode = fileData[savegame.Offset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    savegame.UpdateDisplayName(levelName, saveNumber, isNewGamePlus, isChallengeMode);
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
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            for (int i = 0; i < Globals.MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR3)
                {
                    Int16 levelIndex = BitConverter.ToInt16(fileData, currentSavegameOffset + LEVEL_INDEX_OFFSET);
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + SLOT_STATUS_OFFSET) != 0;

                    if (isSavegamePresent && levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
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
                            bool isNewGamePlus = BitConverter.ToInt32(fileData, currentSavegameOffset + NEW_GAME_PLUS_OFFSET) != 0;
                            bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, isNewGamePlus, false, isChallengeMode);

                            int insertIndex = 0;

                            while (insertIndex < cmbSavegames.Items.Count && cmbSavegames.Items[insertIndex] is Savegame existingSavegame && existingSavegame.Slot < slot)
                            {
                                insertIndex++;
                            }

                            cmbSavegames.Items.Insert(insertIndex, savegame);
                        }
                    }
                }
            }
        }

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            byte[] fileData = File.ReadAllBytes(savegamePath);
            int numSavegames = 0;

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PREPATCH;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PATCH5;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PATCH5;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PATCH5;

                if (platform == Platform.PC)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PC;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PC;
                }
                else if (platform.IsMobile())
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_MOBILE;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_MOBILE;
                }
                else if (platform.IsConsole())
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_CONSOLE;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_CONSOLE;
                }
            }

            for (int i = 0; i < Globals.MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

                Int16 levelIndex = BitConverter.ToInt16(fileData, currentSavegameOffset + LEVEL_INDEX_OFFSET);
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + SLOT_STATUS_OFFSET) != 0;

                if (isSavegamePresent && levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
                {
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR3) / SAVEGAME_SIZE;
                    bool isNewGamePlus = BitConverter.ToInt32(fileData, currentSavegameOffset + NEW_GAME_PLUS_OFFSET) != 0;
                    bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, isNewGamePlus, false, isChallengeMode);
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
