using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TRR_SaveMaster
{
    class TR1Utilities
    {
        // Static offsets
        private const int SAVEFILE_VERSION_OFFSET = 0x000;
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x008;
        private const int SAVE_NUMBER_OFFSET = 0x00C;

        // Platform or patch-dependent offsets
        private int LEVEL_INDEX_OFFSET;
        private int BASE_SAVEGAME_OFFSET_TR1;
        private int MAX_SAVEGAME_OFFSET_TR1;
        private int SAVEGAME_SIZE;
        private int SAVEGAME_VERSION_OFFSET;
        private int CHALLENGE_MODE_RNG_SEED_OFFSET;
        private int CHALLENGE_MODE_OFFSET;
        private int CHALLENGE_MODE_MAX_HEALTH_OFFSET;
        private int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET;
        private int CHALLENGE_MODE_ENEMY_TYPE_OFFSET;

        // Savegame constants
        private const int HEADER_SIZE = 0x6F0;
        private const int MAX_SAVEGAMES = 32;

        // PC offsets
        private const int LEVEL_INDEX_OFFSET_PC = 0x62C;
        private const int SAVEGAME_VERSION_OFFSET_PC = 0x6E4;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PC = 0x6E8;
        private const int CHALLENGE_MODE_OFFSET_PC = 0x6EC;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC = 0x6F6;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC = 0x6FA;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC = 0x6FD;

        // Android offsets
        private const int LEVEL_INDEX_OFFSET_ANDROID = 0x65C;
        private const int SAVEGAME_VERSION_OFFSET_ANDROID = 0x710;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID = 0x714;
        private const int CHALLENGE_MODE_OFFSET_ANDROID = 0x718;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID = 0x731;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID = 0x735;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID = 0x738;

        // Patch-dependent
        private const int SAVEGAME_SIZE_PREPATCH = 0x3800;
        private const int SAVEGAME_SIZE_PATCH5 = 0x6800;
        private const int BASE_SAVEGAME_OFFSET_TR1_PREPATCH = 0x2000;
        private const int BASE_SAVEGAME_OFFSET_TR1_PATCH5 = 0x2000;
        private const int MAX_SAVEGAME_OFFSET_TR1_PREPATCH = 0x72000;
        private const int MAX_SAVEGAME_OFFSET_TR1_PATCH5 = 0xCB800;

        // Patch-related signatures
        private const byte SAVEFILE_PREPATCH = 0x3B;
        private const byte SAVEFILE_PATCH5 = 0x3C;

        // Static weapon offsets
        private const int MAGNUM_AMMO_OFFSET = 0x4C2;
        private const int UZI_AMMO_OFFSET = 0x4C4;
        private const int SHOTGUN_AMMO_OFFSET = 0x4C6;
        private const int SMALL_MEDIPACK_OFFSET = 0x4C8;
        private const int LARGE_MEDIPACK_OFFSET = 0x4C9;
        private const int WEAPONS_CONFIG_NUM_OFFSET = 0x4EC;

        // Dynamic ammo offsets
        private int uziAmmoOffset2;
        private int shotgunAmmoOffset2;
        private int magnumAmmoOffset2;

        // Weapon byte flags
        private const byte WEAPON_PISTOLS = 2;
        private const byte WEAPON_MAGNUMS = 4;
        private const byte WEAPON_UZIS = 8;
        private const byte WEAPON_SHOTGUN = 16;

        // Challenge Mode constants
        private const byte CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL = 3;
        private const byte CHALLENGE_MODE_ENEMY_TYPE_NORMAL = 2;
        private const byte CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER = 5;

        // Health
        private const UInt16 MAX_HEALTH_VALUE_DEFAULT = 1000;
        private const UInt16 MIN_HEALTH_VALUE = 1;
        private UInt16 MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
        private int HEALTH_OFFSET = -1;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private int AMMO_WRITE_LOWER_BOUND;
        private int AMMO_WRITE_UPPER_BOUND;
        private int sgBufferCursor = 0;
        private int rngState;

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

        public int GetHealthOffset(byte[] fileData = null, bool areOffsetsDetermined = false)
        {
            if (fileData == null)
            {
                fileData = File.ReadAllBytes(savegamePath);
            }

            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);

            if (!isPrepatch && !areOffsetsDetermined)
            {
                DetermineDynamicOffsets(fileData);
            }

            MAX_HEALTH_VALUE = (isChallengeMode && !isPrepatch) ? GetChallengeModeMaxHealth(fileData) : MAX_HEALTH_VALUE_DEFAULT;

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

        public void DetermineOffsets(byte[] fileData)
        {
            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PATCH5;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;
            }

            LEVEL_INDEX_OFFSET = platform == Platform.Android ? LEVEL_INDEX_OFFSET_ANDROID : LEVEL_INDEX_OFFSET_PC;
            SAVEGAME_VERSION_OFFSET = platform == Platform.Android ? SAVEGAME_VERSION_OFFSET_ANDROID : SAVEGAME_VERSION_OFFSET_PC;
            CHALLENGE_MODE_RNG_SEED_OFFSET = platform == Platform.Android ? CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID : CHALLENGE_MODE_RNG_SEED_OFFSET_PC;
            CHALLENGE_MODE_OFFSET = platform == Platform.Android ? CHALLENGE_MODE_OFFSET_ANDROID : CHALLENGE_MODE_OFFSET_PC;
            CHALLENGE_MODE_MAX_HEALTH_OFFSET = platform == Platform.Android ? CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID : CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC;
            CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET = platform == Platform.Android ? CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID : CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC;
            CHALLENGE_MODE_ENEMY_TYPE_OFFSET = platform == Platform.Android ? CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID : CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC;

            byte levelIndex = GetLevelIndex(fileData);

            if (isPrepatch)
            {
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
            Dictionary<int, TR1Object> levelObjects,
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
                if (!TR1EntityCache.TR1EnemyRemovableByObjectId.TryGetValue(objectId, out bool removable)) continue;

                // Must be removable
                if (!removable) continue;

                // Skip unchangeable indices
                if (TR1EntityCache.UnchangeableEntitiesByLevel.TryGetValue(levelIndex, out var locked) && locked.Contains(i)) continue;

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
            int rawPercent = TR1EntityCache.EnemyRemovalPercents[enemyNumbers];

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

            // Natla's Mines has no add-enemy table (AddEnemyCount = 0)
            // EN > Normal is disabled in-game and the append pipeline is a no-op
            // Early return mirrors engine behavior
            if (levelIndex == 13)
            {
                return;
            }

            if (!TR1EntityCache.TR1AddEnemyTableByLevel.TryGetValue(levelIndex, out var addList))
            {
                return;
            }

            int totalAddEntries = addList.Count;
            if (totalAddEntries == 0)
            {
                return;
            }

            int percent = TR1EntityCache.EnemyRemovalPercents[enemyNumbers];
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

            List<int> tail = null;

            if (TR1EntityCache.SplitIndexByLevel.TryGetValue(levelIndex, out int splitIndex))
            {
                tail = result.Skip(splitIndex).ToList();
                result = result.Take(splitIndex).ToList();
            }

            if (enemyNumbers <= CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL && enemyType == CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            if (!TR1EntityCache.ChallengeModeItemCountModifiersByLevel.TryGetValue(levelIndex, out var levelModifiers))
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            if (!levelModifiers.TryGetValue(enemyNumbers, out int addCount))
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            if (addCount <= 0 && enemyType == CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            SeedRNG(seed);

            if (!TR1EntityCache.TR1ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
            {
                if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    return tail != null ? result.Concat(tail).ToList() : result;
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

                if (!TR1EntityCache.ChallengeModeCatGroups.TryGetValue(catType, out var catGroups))
                {
                    return tail != null ? result.Concat(tail).ToList() : result;
                }

                Dictionary<string, string> catMapping = null;

                if (enemyType != CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    if (!TR1EntityCache.ChallengeModeCatMapping.TryGetValue(enemyType, out catMapping))
                    {
                        return tail != null ? result.Concat(tail).ToList() : result;
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
                    if (!objectToCat.TryGetValue(originalId, out var sourceCat)) continue;
                    if (!catGroups.TryGetValue(sourceCat, out var sourceEntries)) continue;
                    if (TR1EntityCache.UnchangeableEntitiesByLevel.TryGetValue(levelIndex, out var set) && set.Contains(i)) continue;
                    if (removalSet.Contains(i)) continue;

                    TR1CatEntry sourceEntry = null;

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

                    string targetCat = enemyType == CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER ? sourceCat : catMapping[sourceCat];

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

            // ===================================
            // RECOMBINE SPLIT LIST
            // ===================================
            if (tail != null)
            {
                result.AddRange(tail);
            }

            return result;
        }

        private void DetermineDynamicOffsets(byte[] fileData)
        {
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNativePatch5 = IsNativePatch5Format(fileData);
            byte levelIndex = GetLevelIndex(fileData);

            var baseList = TR1EntityCache.LevelObjectIdsByLevel[levelIndex];
            var levelObjectIds = new List<int>(baseList);

            sgBufferCursor = platform == Platform.Android ? 0x72B : 0x6F0;

            if (isChallengeMode && isNativePatch5)
            {
                byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
                byte enemyType = GetChallengeModeEnemyType(fileData);
                Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);

                levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

                sgBufferCursor += 0x0C;
            }

            sgBufferCursor += 4;

            sgBufferCursor += 0x118;

            int gLevelStateEntryCount = TR1EntityCache.LevelStateEntryCounts[levelIndex];
            sgBufferCursor += gLevelStateEntryCount * 2;

            if (isNativePatch5)
            {
                sgBufferCursor += 4;
            }

            for (int itemIndex = 0; itemIndex < levelObjectIds.Count; itemIndex++)
            {
                int objectId = levelObjectIds[itemIndex];

                if (isNativePatch5)
                {
                    sgBufferCursor += 4;
                }

                if (!TR1EntityCache.TR1ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
                {
                    throw new Exception($"FATAL: Missing level definition for level {levelIndex}.");
                }

                if (!levelObjects.TryGetValue(objectId, out var tr1Object))
                {
                    throw new Exception($"FATAL: Missing object definition (object ID: 0x{objectId:X}).");
                }

                if (tr1Object.ObjectId == 0)
                {
                    HEALTH_OFFSET = sgBufferCursor + 0x28;
                }

                if ((tr1Object.Flags00 & 0x08) != 0)
                {
                    sgBufferCursor += 0x1A;
                }

                if ((tr1Object.Flags00 & 0x40) != 0)
                {
                    sgBufferCursor += 10;
                }

                if ((tr1Object.Flags00 & 0x10) != 0)
                {
                    sgBufferCursor += 0x02;
                }

                if ((tr1Object.Flags00 & 0x20) != 0)
                {
                    bool has02 = (tr1Object.Flags00 & 0x02) != 0;
                    sgBufferCursor += has02 ? 0x10 : 0x04;
                }

                if ((tr1Object.Flags00 & 0x20) != 0)
                {
                    sgBufferCursor += 0x10;
                }
            }

            magnumAmmoOffset2 = sgBufferCursor + 0x14C;
            uziAmmoOffset2 = sgBufferCursor + 0x154;
            shotgunAmmoOffset2 = sgBufferCursor + 0x15C;
        }

        private bool IsPrepatchSavegameFile(byte[] fileData)
        {
            return fileData[SAVEFILE_VERSION_OFFSET] == SAVEFILE_PREPATCH;
        }

        private GameMode GetGameMode(byte[] fileData)
        {
            byte gameMode = fileData[savegameOffset + GAME_MODE_OFFSET];
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
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

            return (UInt16)1000;
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
            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                WriteUInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (!isPrepatch && (shotgunAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || shotgunAmmoOffset2 > AMMO_WRITE_UPPER_BOUND))
            {
                return;
            }

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

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (!isPrepatch && (magnumAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || magnumAmmoOffset2 > AMMO_WRITE_UPPER_BOUND))
            {
                return;
            }

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

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (!isPrepatch && (uziAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || uziAmmoOffset2 > AMMO_WRITE_UPPER_BOUND))
            {
                return;
            }

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

            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);

            MAX_HEALTH_VALUE = (isChallengeMode && !isPrepatch) ? GetChallengeModeMaxHealth(fileData) : MAX_HEALTH_VALUE_DEFAULT;
            trbHealth.Maximum = MAX_HEALTH_VALUE;

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

            if (!isPrepatch)
            {
                DetermineDynamicOffsets(fileData);
            }

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

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (!isPrepatch)
            {
                DetermineDynamicOffsets(fileData);

                AMMO_WRITE_LOWER_BOUND = HEADER_SIZE;
                AMMO_WRITE_UPPER_BOUND = SAVEGAME_SIZE - 2;
            }

            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value);
            WriteMagnumAmmo(fileData, chkMagnums.Checked, (UInt16)nudMagnumAmmo.Value);
            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6));

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (UInt16)trbHealth.Value);
            }

            File.WriteAllBytes(savegamePath, fileData);
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
            int numSaves = 0;

            bool isPrepatch = IsPrepatchSavegameFile(fileData);

            if (isPrepatch)
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PREPATCH;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PATCH5;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PATCH5;
                SAVEGAME_SIZE = SAVEGAME_SIZE_PATCH5;
            }

            LEVEL_INDEX_OFFSET = platform == Platform.Android ? LEVEL_INDEX_OFFSET_ANDROID : LEVEL_INDEX_OFFSET_PC;
            CHALLENGE_MODE_OFFSET = platform == Platform.Android ? CHALLENGE_MODE_OFFSET_ANDROID : CHALLENGE_MODE_OFFSET_PC;

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
                    bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, false, isChallengeMode);
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
