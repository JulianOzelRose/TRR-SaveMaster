using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR3Utilities
    {
        // Static offsets
        private const int SAVEFILE_VERSION_OFFSET = 0x000;
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;
        private const int LEVEL_INDEX_OFFSET_PREPATCH = 0x8D6;

        // Platform or patch-dependent offsets
        private int LEVEL_INDEX_OFFSET;
        private int BASE_SAVEGAME_OFFSET_TR3;
        private int MAX_SAVEGAME_OFFSET_TR3;
        private int SAVEGAME_SIZE;
        private int SAVEGAME_VERSION_OFFSET;
        private int CHALLENGE_MODE_RNG_SEED_OFFSET;
        private int CHALLENGE_MODE_OFFSET;
        private int CHALLENGE_MODE_MAX_HEALTH_OFFSET;
        private int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET;
        private int CHALLENGE_MODE_ENEMY_TYPE_OFFSET;

        // Savegame constants
        private const int MAX_SAVEGAMES = 32;

        // PC offsets
        private const int LEVEL_INDEX_OFFSET_PC = 0x8D6;
        private const int SAVEGAME_VERSION_OFFSET_PC = 0x98C;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PC = 0x994;
        private const int CHALLENGE_MODE_OFFSET_PC = 0x990;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC = 0x99E;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC = 0x9A2;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC = 0x9A5;

        // Android offsets
        private const int LEVEL_INDEX_OFFSET_ANDROID = 0x916;
        private const int SAVEGAME_VERSION_OFFSET_ANDROID = 0x9CC;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID = 0x9D4;
        private const int CHALLENGE_MODE_OFFSET_ANDROID = 0x9D0;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID = 0x9DE;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID = 0x9E2;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID = 0x9E5;

        // PS4 offsets
        private const int LEVEL_INDEX_OFFSET_PS4 = 0x8D6;
        private const int SAVEGAME_VERSION_OFFSET_PS4 = 0x98C;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PS4 = 0x994;
        private const int CHALLENGE_MODE_OFFSET_PS4 = 0x990;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PS4 = 0x99E;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PS4 = 0x9A2;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PS4 = 0x9A5;

        // Patch-dependent
        private const int SAVEGAME_SIZE_PREPATCH = 0x3800;
        private const int SAVEGAME_SIZE_PATCH5 = 0x6800;
        private const int BASE_SAVEGAME_OFFSET_TR3_PREPATCH = 0xE2000;
        private const int BASE_SAVEGAME_OFFSET_TR3_PATCH5 = 0x1A2000;
        private const int MAX_SAVEGAME_OFFSET_TR3_PREPATCH = 0x152000;
        private const int MAX_SAVEGAME_OFFSET_TR3_PATCH5 = 0x26B800;

        // Patch-related signatures
        private const byte SAVEFILE_PREPATCH = 0x3B;
        private const byte SAVEFILE_PATCH5 = 0x3C;

        // Static offsets (per level)
        private int SMALL_MEDIPACK_OFFSET;
        private int LARGE_MEDIPACK_OFFSET;
        private int FLARES_OFFSET;
        private int WEAPONS_CONFIG_NUM_OFFSET;
        private int COLLECTIBLE_CRYSTALS_OFFSET;
        private int HARPOON_GUN_OFFSET;
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

        // Weapon byte flags
        private const byte WEAPON_PISTOLS = 2;
        private const byte WEAPON_DEAGLE = 4;
        private const byte WEAPON_UZIS = 8;
        private const byte WEAPON_SHOTGUN = 16;
        private const byte WEAPON_MP5 = 32;
        private const byte WEAPON_ROCKET_LAUNCHER = 64;
        private const byte WEAPON_GRENADE_LAUNCHER = 128;

        // Challenge Mode constants
        private const byte CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL = 3;
        private const byte CHALLENGE_MODE_ENEMY_TYPE_NORMAL = 2;
        private const byte CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER = 5;

        // Entity block starts
        private const int ENTITY_BLOCK_START_PC = 0x998;
        private const int ENTITY_BLOCK_START_ANDROID = 0x9E3;
        private const int ENTITY_BLOCK_START_PS4 = 0x998;
        private const int ENTITY_BLOCK_START_PC_PREPATCH = 0x988;
        private const int ENTITY_BLOCK_START_PS4_PREPATCH = 0x986;
        private const int ENTITY_BLOCK_START_NS_PREPATCH = 0x986;

        // Health
        private const UInt16 MAX_HEALTH_VALUE_DEFAULT = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private UInt16 MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
        private int HEALTH_OFFSET;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private const int ENTITY_AI_BLOCK_SIZE = 0x1A;
        private int AMMO_WRITE_LOWER_BOUND;
        private int AMMO_WRITE_UPPER_BOUND;
        private int sgBufferCursor = 0;
        private int rngState;

        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
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

            UInt16 value = BitConverter.ToUInt16(savegameData, savegameOffset + HEALTH_OFFSET);

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
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PATCH5;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;

                if (platform == Platform.PC)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PC;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_PC;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_PC;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PC;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC;
                }
                else if (platform == Platform.Android)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_ANDROID;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_ANDROID;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_ANDROID;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID;
                }
                else if (platform == Platform.PlayStation4)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PS4;
                    SAVEGAME_VERSION_OFFSET = SAVEGAME_VERSION_OFFSET_PS4;
                    CHALLENGE_MODE_RNG_SEED_OFFSET = CHALLENGE_MODE_RNG_SEED_OFFSET_PS4;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PS4;
                    CHALLENGE_MODE_MAX_HEALTH_OFFSET = CHALLENGE_MODE_MAX_HEALTH_OFFSET_PS4;
                    CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PS4;
                    CHALLENGE_MODE_ENEMY_TYPE_OFFSET = CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PS4;
                }
            }

            byte levelIndex = GetLevelIndex(fileData);

            DEAGLE_AMMO_OFFSET = 0x66 + (levelIndex * 0x40);
            UZI_AMMO_OFFSET = 0x68 + (levelIndex * 0x40);
            SHOTGUN_AMMO_OFFSET = 0x6A + (levelIndex * 0x40);
            MP5_AMMO_OFFSET = 0x6C + (levelIndex * 0x40);
            ROCKET_LAUNCHER_AMMO_OFFSET = 0x6E + (levelIndex * 0x40);
            HARPOON_GUN_AMMO_OFFSET = 0x70 + (levelIndex * 0x40);
            GRENADE_LAUNCHER_AMMO_OFFSET = 0x72 + (levelIndex * 0x40);
            SMALL_MEDIPACK_OFFSET = 0x74 + (levelIndex * 0x40);
            LARGE_MEDIPACK_OFFSET = 0x75 + (levelIndex * 0x40);
            FLARES_OFFSET = 0x77 + (levelIndex * 0x40);
            COLLECTIBLE_CRYSTALS_OFFSET = 0x78 + (levelIndex * 0x40);
            WEAPONS_CONFIG_NUM_OFFSET = 0xA0 + (levelIndex * 0x40);
            HARPOON_GUN_OFFSET = 0xA1 + (levelIndex * 0x40);
        }

        private void SeedRNG(int seed)
        {
            rngState = seed;
        }

        private int NextRNG()
        {
            rngState = rngState * 0x343FD + 0x269EC3;
            return (rngState >> 0x10) & 0x7FFF;
        }

        private HashSet<int> BuildRemovalSet(
            List<int> entityIds,
            Dictionary<int, TR3Object> levelObjects,
            byte levelIndex,
            byte enemyNumbers)
        {
            var removalSet = new HashSet<int>();

            // Only applies to EN modes below Normal
            if (enemyNumbers >= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
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
            byte levelIndex,
            byte enemyNumbers)
        {
            if (enemyNumbers <= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
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

        private List<int> ApplyChallengeModeMutations(List<int> baseList, byte levelIndex, byte enemyNumbers, byte enemyType, Int32 seed)
        {
            var result = new List<int>(baseList);

            if (enemyNumbers <= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL && enemyType == CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
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

            if (addCount <= 0 && enemyType == CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return result;
            }

            SeedRNG(seed);

            if (!TR3EntityCache.TR3ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
            {
                if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    return result;
                }
            }

            // ===================================
            // EN APPEND FIRST
            // ===================================
            if (enemyNumbers > CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
            {
                ApplyAddEnemies(result, levelIndex, enemyNumbers);
            }

            // ===================================
            // SINGLE ET MUTATION PASS (FULL LIST)
            // ===================================
            if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                var catType = enemyType;

                if (!TR3EntityCache.ChallengeModeCatGroups.TryGetValue(catType, out var catGroups))
                {
                    return result;
                }

                Dictionary<string, string> catMapping = null;

                if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
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

                    if (TR3EntityCache.TR3EnemyFriendlyByObjectId.TryGetValue(originalId, out bool isFriendly) && isFriendly)
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

                    if (enemyType == CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
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
                else if (platform == Platform.PlayStation4)
                {
                    return ENTITY_BLOCK_START_PS4_PREPATCH;
                }
                else if (platform == Platform.NintendoSwitch)
                {
                    return ENTITY_BLOCK_START_NS_PREPATCH;
                }

                return ENTITY_BLOCK_START_PC_PREPATCH;
            }
            else
            {
                if (platform == Platform.PC)
                {
                    return ENTITY_BLOCK_START_PC;
                }
                else if (platform == Platform.Android)
                {
                    return ENTITY_BLOCK_START_ANDROID;
                }
                else if (platform == Platform.PlayStation4)
                {
                    return ENTITY_BLOCK_START_PS4;
                }

                return ENTITY_BLOCK_START_PC;
            }
        }

        private void DetermineDynamicOffsets(byte[] fileData)
        {
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNativePatch5 = IsNativePatch5Format(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            byte levelIndex = GetLevelIndex(fileData);

            var baseList = TR3EntityCache.LevelObjectIdsByLevel[levelIndex];
            var levelObjectIds = new List<int>(baseList);

            sgBufferCursor = GetEntityBlockStart(isPrepatch);

            if (isChallengeMode && isNativePatch5 && !isPrepatch)
            {
                byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
                byte enemyType = GetChallengeModeEnemyType(fileData);
                Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);

                levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

                sgBufferCursor += 0x0C;
            }

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
                    throw new Exception($"FATAL: Missing level definition for level {levelIndex}.");
                }

                if (!levelObjects.TryGetValue(objectId, out var tr3Object))
                {
                    throw new Exception($"FATAL: Missing object definition (object ID: 0x{objectId:X}).");
                }

                if (tr3Object.ObjectId == 0)
                {
                    HEALTH_OFFSET = sgBufferCursor + 0x28;
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
                    sgBufferCursor += 0x02;
                }

                if ((tr3Object.Flags00 & 0x20) != 0)
                {
                    int blockStart = sgBufferCursor;
                    bool has02 = (tr3Object.Flags00 & 0x02) != 0;

                    int increment = has02 ? 0x18 : 0x16;

                    short aiWord = BitConverter.ToInt16(fileData, savegameOffset + blockStart + 6);
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

            deagleAmmoOffset2 = sgBufferCursor + 0x16C;
            uziAmmoOffset2 = sgBufferCursor + 0x174;
            shotgunAmmoOffset2 = sgBufferCursor + 0x17C;
            harpoonGunAmmoOffset2 = sgBufferCursor + 0x184;
            rocketLauncherAmmoOffset2 = sgBufferCursor + 0x18C;
            grenadeLauncherAmmoOffset2 = sgBufferCursor + 0x194;
            mp5AmmoOffset2 = sgBufferCursor + 0x19C;
        }

        private GameMode GetGameMode(byte[] fileData)
        {
            byte gameMode = fileData[savegameOffset + GAME_MODE_OFFSET];
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
        }

        private bool IsPrepatchSavegameFile(byte[] fileData)
        {
            return fileData[SAVEFILE_VERSION_OFFSET] == SAVEFILE_PREPATCH;
        }

        private bool IsNativePatch5Format(byte[] fileData)
        {
            Int32 savegameVersion = BitConverter.ToInt32(fileData, savegameOffset + SAVEGAME_VERSION_OFFSET);
            return savegameVersion >= 2;
        }

        public bool IsChallengeMode(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_OFFSET] == 1;
        }

        public UInt16 GetChallengeModeMaxHealth(byte[] fileData)
        {
            byte maxHealthSetting = fileData[savegameOffset + CHALLENGE_MODE_MAX_HEALTH_OFFSET];

            if (maxHealthSetting == 0) return (UInt16)100;
            if (maxHealthSetting == 1) return (UInt16)250;
            if (maxHealthSetting == 2) return (UInt16)500;
            if (maxHealthSetting == 3) return (UInt16)1000;
            if (maxHealthSetting == 4) return (UInt16)1500;
            if (maxHealthSetting == 5) return (UInt16)1750;
            if (maxHealthSetting == 6) return (UInt16)2000;
            if (maxHealthSetting == 7) return (UInt16)5000;

            return MAX_HEALTH_VALUE_DEFAULT;
        }

        private byte GetChallengeModeEnemyNumbers(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET];
        }

        private byte GetChallengeModeEnemyType(byte[] fileData)
        {
            return fileData[savegameOffset + CHALLENGE_MODE_ENEMY_TYPE_OFFSET];
        }

        private Int32 GetChallengeModeRNGSeed(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + CHALLENGE_MODE_RNG_SEED_OFFSET);
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

        private byte GetNumFlares(byte[] fileData)
        {
            return fileData[savegameOffset + FLARES_OFFSET];
        }

        private byte GetNumCollectibleCrystals(byte[] fileData)
        {
            return fileData[savegameOffset + COLLECTIBLE_CRYSTALS_OFFSET];
        }

        private byte GetWeaponsConfigNum(byte[] fileData)
        {
            return fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET];
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

        private UInt16 GetHealthValue(byte[] fileData, int healthOffset)
        {
            return BitConverter.ToUInt16(fileData, healthOffset);
        }

        private bool IsHarpoonGunPresent(byte[] fileData)
        {
            return fileData[savegameOffset + HARPOON_GUN_OFFSET] != 0;
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

        private void WriteWeaponsConfigNum(byte[] fileData, byte value)
        {
            fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET] = value;
        }

        private void WriteHealthValue(byte[] fileData, UInt16 newHealth)
        {
            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteHarpoonGunPresent(byte[] fileData, bool isPresent)
        {
            if (isPresent)
            {
                fileData[savegameOffset + HARPOON_GUN_OFFSET] = 1;
            }
            else
            {
                fileData[savegameOffset + HARPOON_GUN_OFFSET] = 0;
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + shotgunAmmoOffset2, 0);
            }
        }

        private void WriteDeagleAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + deagleAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + uziAmmoOffset2, 0);
            }
        }

        private void WriteGrenadeLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + grenadeLauncherAmmoOffset2, 0);
            }
        }

        private void WriteMP5Ammo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + mp5AmmoOffset2, 0);
            }
        }

        private void WriteRocketLauncherAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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
            else if (!isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + rocketLauncherAmmoOffset2, 0);
            }
        }

        private void WriteHarpoonGunAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
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

            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);

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

            if (GetLevelIndex(fileData) >= 21)
            {
                nudCollectibleCrystals.Enabled = false;
                lblCollectibleCrystals.Visible = false;
                nudCollectibleCrystals.Value = 0;
                nudCollectibleCrystals.Visible = false;
            }
            else
            {
                lblCollectibleCrystals.Text = GetGameMode(fileData) == GameMode.Normal ? "Collectible Crystals:" : "Savegame Crystals:";
                nudCollectibleCrystals.Enabled = true;
                lblCollectibleCrystals.Visible = true;
                nudCollectibleCrystals.Value = GetNumCollectibleCrystals(fileData);
                nudCollectibleCrystals.Visible = true;
            }

            byte weaponsConfigNum = GetWeaponsConfigNum(fileData);

            if (weaponsConfigNum == 1)
            {
                chkPistols.Checked = false;
                chkDeagle.Checked = false;
                chkUzis.Checked = false;
                chkShotgun.Checked = false;
                chkMP5.Checked = false;
                chkRocketLauncher.Checked = false;
                chkGrenadeLauncher.Checked = false;
            }
            else
            {
                chkPistols.Checked = (weaponsConfigNum & WEAPON_PISTOLS) != 0;
                chkDeagle.Checked = (weaponsConfigNum & WEAPON_DEAGLE) != 0;
                chkUzis.Checked = (weaponsConfigNum & WEAPON_UZIS) != 0;
                chkShotgun.Checked = (weaponsConfigNum & WEAPON_SHOTGUN) != 0;
                chkMP5.Checked = (weaponsConfigNum & WEAPON_MP5) != 0;
                chkRocketLauncher.Checked = (weaponsConfigNum & WEAPON_ROCKET_LAUNCHER) != 0;
                chkGrenadeLauncher.Checked = (weaponsConfigNum & WEAPON_GRENADE_LAUNCHER) != 0;
            }

            chkHarpoonGun.Checked = IsHarpoonGunPresent(fileData);

            int healthOffset = GetHealthOffset(fileData, true);

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

            byte newWeaponsConfigNum = 1;

            if (chkPistols.Checked) newWeaponsConfigNum += WEAPON_PISTOLS;
            if (chkDeagle.Checked) newWeaponsConfigNum += WEAPON_DEAGLE;
            if (chkUzis.Checked) newWeaponsConfigNum += WEAPON_UZIS;
            if (chkShotgun.Checked) newWeaponsConfigNum += WEAPON_SHOTGUN;
            if (chkMP5.Checked) newWeaponsConfigNum += WEAPON_MP5;
            if (chkRocketLauncher.Checked) newWeaponsConfigNum += WEAPON_ROCKET_LAUNCHER;
            if (chkGrenadeLauncher.Checked) newWeaponsConfigNum += WEAPON_GRENADE_LAUNCHER;

            WriteWeaponsConfigNum(fileData, newWeaponsConfigNum);
            WriteHarpoonGunPresent(fileData, chkHarpoonGun.Checked);

            byte levelIndex = GetLevelIndex(fileData);
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            int entityBlockStart = GetEntityBlockStart(isPrepatch);

            AMMO_WRITE_LOWER_BOUND = entityBlockStart;
            AMMO_WRITE_UPPER_BOUND = SAVEGAME_SIZE - 4;

            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6), isPrepatch);
            WriteDeagleAmmo(fileData, chkDeagle.Checked, (UInt16)nudDeagleAmmo.Value, isPrepatch);
            WriteGrenadeLauncherAmmo(fileData, chkGrenadeLauncher.Checked, (UInt16)nudGrenadeLauncherAmmo.Value, isPrepatch);
            WriteRocketLauncherAmmo(fileData, chkRocketLauncher.Checked, (UInt16)nudRocketLauncherAmmo.Value, isPrepatch);
            WriteHarpoonGunAmmo(fileData, chkHarpoonGun.Checked, (UInt16)nudHarpoonGunAmmo.Value, isPrepatch);
            WriteMP5Ammo(fileData, chkMP5.Checked, (UInt16)nudMP5Ammo.Value, isPrepatch);
            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value, isPrepatch);

            if (levelIndex < 21)
            {
                WriteNumCollectibleCrystals(fileData, (byte)nudCollectibleCrystals.Value);
            }

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (UInt16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
        }

        public bool IsLaraInVehicle(int healthOffset, byte[] fileData)
        {
            byte byteFlag1 = fileData[healthOffset - 10];
            byte byteFlag2 = fileData[healthOffset - 9];
            byte byteFlag3 = fileData[healthOffset - 8];
            byte byteFlag4 = fileData[healthOffset - 7];

            if (byteFlag1 == 0x0F && byteFlag2 == 0x00 && byteFlag3 == 0x0F && byteFlag4 == 0x00) return true;  // Quad Bike
            if (byteFlag1 == 0x08 && byteFlag2 == 0x00 && byteFlag3 == 0x08 && byteFlag4 == 0x00) return true;  // Quad Bike
            if (byteFlag1 == 0x05 && byteFlag2 == 0x00 && byteFlag3 == 0x05 && byteFlag4 == 0x00) return true;  // UPV
            if (byteFlag1 == 0x01 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Kayak or Boat
            if (byteFlag1 == 0x03 && byteFlag2 == 0x00 && byteFlag3 == 0x01 && byteFlag4 == 0x00) return true;  // Kayak or Boat
            if (byteFlag1 == 0x06 && byteFlag2 == 0x00 && byteFlag3 == 0x06 && byteFlag4 == 0x00) return true;  // Mine Cart
            if (byteFlag1 == 0x0C && byteFlag2 == 0x00 && byteFlag3 == 0x0C && byteFlag4 == 0x00) return true;  // Mine Cart

            return false;
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
                    bool isPrepatch = IsPrepatchSavegameFile(fileData);
                    string levelName = levelNames[levelIndex];
                    GameMode gameMode = fileData[savegame.Offset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                    bool isChallengeMode = fileData[savegame.Offset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    savegame.UpdateDisplayName(levelName, saveNumber, gameMode, isChallengeMode);
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
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR3)
                {
                    byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                    byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool savegamePresent = slotStatus != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
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
                            string levelName = levelNames[levelIndex];
                            GameMode gameMode = fileData[currentSavegameOffset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                            bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, false, isChallengeMode);
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

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR3 = BASE_SAVEGAME_OFFSET_TR3_PATCH5;
                MAX_SAVEGAME_OFFSET_TR3 = MAX_SAVEGAME_OFFSET_TR3_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;

                if (platform == Platform.PC)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PC;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PC;
                }
                else if (platform == Platform.Android)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_ANDROID;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_ANDROID;
                }
                else if (platform == Platform.PlayStation4)
                {
                    LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PS4;
                    CHALLENGE_MODE_OFFSET = CHALLENGE_MODE_OFFSET_PS4;
                }
            }

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

                byte slotStatus = fileData[currentSavegameOffset + SLOT_STATUS_OFFSET];
                byte levelIndex = fileData[currentSavegameOffset + LEVEL_INDEX_OFFSET];
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool savegamePresent = slotStatus != 0;

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR3) / SAVEGAME_SIZE;
                    GameMode gameMode = fileData[currentSavegameOffset + GAME_MODE_OFFSET] == 0 ? GameMode.Normal : GameMode.Plus;
                    bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, false, isChallengeMode);
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
