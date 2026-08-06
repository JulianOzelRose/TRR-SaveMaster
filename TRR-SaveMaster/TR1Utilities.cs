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
        private const int NEW_GAME_PLUS_OFFSET = 0x004;
        private const int SAVE_NUMBER_OFFSET = 0x008;
        private const int LEVEL_INDEX_OFFSET_PREPATCH = 0x628;

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

        // PC offsets
        private const int LEVEL_INDEX_OFFSET_PC = 0x628;
        private const int SAVEGAME_VERSION_OFFSET_PC = 0x6E0;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PC = 0x6E4;
        private const int CHALLENGE_MODE_OFFSET_PC = 0x6E8;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PC = 0x6F2;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PC = 0x6F6;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PC = 0x6F9;

        // Android offsets
        private const int LEVEL_INDEX_OFFSET_ANDROID = 0x658;
        private const int SAVEGAME_VERSION_OFFSET_ANDROID = 0x70C;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_ANDROID = 0x710;
        private const int CHALLENGE_MODE_OFFSET_ANDROID = 0x714;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_ANDROID = 0x72D;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_ANDROID = 0x731;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_ANDROID = 0x734;

        // PS4 offsets
        private const int LEVEL_INDEX_OFFSET_PS4 = 0x628;
        private const int SAVEGAME_VERSION_OFFSET_PS4 = 0x6DC;
        private const int CHALLENGE_MODE_RNG_SEED_OFFSET_PS4 = 0x6E0;
        private const int CHALLENGE_MODE_OFFSET_PS4 = 0x6E4;
        private const int CHALLENGE_MODE_MAX_HEALTH_OFFSET_PS4 = 0x6EE;
        private const int CHALLENGE_MODE_ENEMY_NUMBERS_OFFSET_PS4 = 0x6F2;
        private const int CHALLENGE_MODE_ENEMY_TYPE_OFFSET_PS4 = 0x6F5;

        // Patch-dependent
        private const int BASE_SAVEGAME_OFFSET_TR1_PREPATCH = 0x2004;
        private const int BASE_SAVEGAME_OFFSET_TR1_PATCH5 = 0x2004;
        private const int MAX_SAVEGAME_OFFSET_TR1_PREPATCH = 0x72004;
        private const int MAX_SAVEGAME_OFFSET_TR1_PATCH5 = 0xCB804;

        // Static weapon offsets
        private const int MAGNUM_AMMO_OFFSET = 0x4BE;
        private const int UZI_AMMO_OFFSET = 0x4C0;
        private const int SHOTGUN_AMMO_OFFSET = 0x4C2;
        private const int SMALL_MEDIPACK_OFFSET = 0x4C4;
        private const int LARGE_MEDIPACK_OFFSET = 0x4C5;
        private const int WEAPONS_CONFIG_NUM_OFFSET = 0x4E8;

        // Dynamic ammo offsets
        private int uziAmmoOffset2;
        private int shotgunAmmoOffset2;
        private int magnumAmmoOffset2;

        // Weapon byte flags
        private const byte WEAPON_PISTOLS = 2;
        private const byte WEAPON_MAGNUMS = 4;
        private const byte WEAPON_UZIS = 8;
        private const byte WEAPON_SHOTGUN = 16;

        // Entity block starts
        private const int ENTITY_BLOCK_START_PC = 0x6F0;
        private const int ENTITY_BLOCK_START_ANDROID = 0x72B;
        private const int ENTITY_BLOCK_START_PS4 = 0x6EC;

        // Health
        private const Int16 MAX_HEALTH_VALUE_DEFAULT = 1000;
        private const Int16 MIN_HEALTH_VALUE = 1;
        private Int16 MAX_HEALTH_VALUE = MAX_HEALTH_VALUE_DEFAULT;
        private int HEALTH_OFFSET = -1;

        // Misc
        private Platform platform;
        private string savegamePath;
        private int savegameOffset;
        private int AMMO_WRITE_LOWER_BOUND;
        private int AMMO_WRITE_UPPER_BOUND;
        private int sgBufferCursor = 0;
        private int rngState;

        public readonly Dictionary<int, string> levelNames = new Dictionary<int, string>()
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

            bool isPrepatch = IsPrepatchSavegameFile(savegameData);
            bool isChallengeMode = IsChallengeMode(savegameData);

            if (!isPrepatch && !areOffsetsDetermined)
            {
                DetermineDynamicOffsets(savegameData);
            }

            MAX_HEALTH_VALUE = (isChallengeMode && !isPrepatch) ? GetChallengeModeMaxHealth(savegameData) : MAX_HEALTH_VALUE_DEFAULT;

            if (HEALTH_OFFSET != -1)
            {
                Int16 value = BitConverter.ToInt16(savegameData, savegameOffset + HEALTH_OFFSET);

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
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;

                Int16 levelIndex = GetLevelIndex(fileData);

                if (levelIndex == 1)        // Caves
                {
                    HEALTH_OFFSET = 0x821;
                    magnumAmmoOffset2 = 0x1075;
                    uziAmmoOffset2 = 0x107D;
                    shotgunAmmoOffset2 = 0x1085;
                }
                else if (levelIndex == 2)   // City of Vilacamba
                {
                    HEALTH_OFFSET = 0x1819;
                    magnumAmmoOffset2 = 0x1995;
                    uziAmmoOffset2 = 0x199D;
                    shotgunAmmoOffset2 = 0x19A5;
                }
                else if (levelIndex == 3)   // Lost Valley
                {
                    HEALTH_OFFSET = 0x829;
                    magnumAmmoOffset2 = 0x1053;
                    uziAmmoOffset2 = 0x105B;
                    shotgunAmmoOffset2 = 0x1063;
                }
                else if (levelIndex == 4)   // Tomb of Qualopec
                {
                    HEALTH_OFFSET = 0xC3D;
                    magnumAmmoOffset2 = 0x1377;
                    uziAmmoOffset2 = 0x137F;
                    shotgunAmmoOffset2 = 0x1387;
                }
                else if (levelIndex == 5)   // St. Francis' Folly
                {
                    HEALTH_OFFSET = 0x1A35;
                    magnumAmmoOffset2 = 0x1C51;
                    uziAmmoOffset2 = 0x1C59;
                    shotgunAmmoOffset2 = 0x1C61;
                }
                else if (levelIndex == 6)   // Colosseum
                {
                    HEALTH_OFFSET = 0xF4B;
                    magnumAmmoOffset2 = 0x1743;
                    uziAmmoOffset2 = 0x174B;
                    shotgunAmmoOffset2 = 0x1753;
                }
                else if (levelIndex == 7)   // Palace Midas
                {
                    HEALTH_OFFSET = 0x82B;
                    magnumAmmoOffset2 = 0x1C1D;
                    uziAmmoOffset2 = 0x1C25;
                    shotgunAmmoOffset2 = 0x1C2D;
                }
                else if (levelIndex == 8)   // The Cistern
                {
                    HEALTH_OFFSET = 0x1977;
                    magnumAmmoOffset2 = 0x1B89;
                    uziAmmoOffset2 = 0x1B91;
                    shotgunAmmoOffset2 = 0x1B99;
                }
                else if (levelIndex == 9)   // Tomb of Tihocan
                {
                    HEALTH_OFFSET = 0xA25;
                    magnumAmmoOffset2 = 0x168B;
                    uziAmmoOffset2 = 0x1693;
                    shotgunAmmoOffset2 = 0x169B;
                }
                else if (levelIndex == 10)  // City of Khamoon
                {
                    HEALTH_OFFSET = 0x823;
                    magnumAmmoOffset2 = 0x1553;
                    uziAmmoOffset2 = 0x155B;
                    shotgunAmmoOffset2 = 0x1563;
                }
                else if (levelIndex == 11)  // Obelisk of Khamoon
                {
                    HEALTH_OFFSET = 0xA8B;
                    magnumAmmoOffset2 = 0x165B;
                    uziAmmoOffset2 = 0x1663;
                    shotgunAmmoOffset2 = 0x166B;
                }
                else if (levelIndex == 12)  // Sanctuary of the Scion
                {
                    HEALTH_OFFSET = 0x114B;
                    magnumAmmoOffset2 = 0x1303;
                    uziAmmoOffset2 = 0x130B;
                    shotgunAmmoOffset2 = 0x1313;
                }
                else if (levelIndex == 13)  // Natla's Mines
                {
                    HEALTH_OFFSET = 0x12CF;
                    magnumAmmoOffset2 = 0x1659;
                    uziAmmoOffset2 = 0x1661;
                    shotgunAmmoOffset2 = 0x1669;
                }
                else if (levelIndex == 14)  // Atlantis
                {
                    HEALTH_OFFSET = 0xD0B;
                    magnumAmmoOffset2 = 0x2457;
                    uziAmmoOffset2 = 0x245F;
                    shotgunAmmoOffset2 = 0x2467;
                }
                else if (levelIndex == 15)  // The Great Pyramid
                {
                    HEALTH_OFFSET = 0x10F9;
                    magnumAmmoOffset2 = 0x179D;
                    uziAmmoOffset2 = 0x17A5;
                    shotgunAmmoOffset2 = 0x17AD;
                }
                else if (levelIndex == 16)   // Return to Egypt
                {
                    HEALTH_OFFSET = 0x8EF;
                    magnumAmmoOffset2 = 0x1F09;
                    uziAmmoOffset2 = 0x1F11;
                    shotgunAmmoOffset2 = 0x1F19;
                }
                else if (levelIndex == 17)   // Temple of the Cat
                {
                    HEALTH_OFFSET = 0xE19;
                    magnumAmmoOffset2 = 0x25A5;
                    uziAmmoOffset2 = 0x25AD;
                    shotgunAmmoOffset2 = 0x25B5;
                }
                else if (levelIndex == 18)  // Atlantean Stronghold
                {
                    HEALTH_OFFSET = 0xE31;
                    magnumAmmoOffset2 = 0x1ED7;
                    uziAmmoOffset2 = 0x1EDF;
                    shotgunAmmoOffset2 = 0x1EE7;
                }
                else if (levelIndex == 19)  // The Hive
                {
                    HEALTH_OFFSET = 0x10DB;
                    magnumAmmoOffset2 = 0x271F;
                    uziAmmoOffset2 = 0x2727;
                    shotgunAmmoOffset2 = 0x272F;
                }

                if (platform != Platform.PC)
                {
                    HEALTH_OFFSET -= 4;

                    magnumAmmoOffset2 -= 4;
                    uziAmmoOffset2 -= 4;
                    shotgunAmmoOffset2 -= 4;
                }
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PATCH5;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PATCH5;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PATCH5;

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
            Int16 levelIndex,
            byte enemyNumbers)
        {
            if (enemyNumbers <= Globals.CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL)
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

        private List<int> ApplyChallengeModeMutations(List<int> baseList, Int16 levelIndex, byte enemyNumbers, byte enemyType, Int32 seed)
        {
            var result = new List<int>(baseList);

            List<int> tail = null;

            if (TR1EntityCache.SplitIndexByLevel.TryGetValue(levelIndex, out int splitIndex))
            {
                tail = result.Skip(splitIndex).ToList();
                result = result.Take(splitIndex).ToList();
            }

            if (enemyNumbers <= Globals.CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL && enemyType == Globals.CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
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

            if (addCount <= 0 && enemyType == Globals.CHALLENGE_MODE_ENEMY_TYPE_NORMAL)
            {
                return tail != null ? result.Concat(tail).ToList() : result;
            }

            SeedRNG(seed);

            if (!TR1EntityCache.TR1ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
            {
                if (enemyType != Globals.CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
                {
                    return tail != null ? result.Concat(tail).ToList() : result;
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

                if (!TR1EntityCache.ChallengeModeCatGroups.TryGetValue(catType, out var catGroups))
                {
                    return tail != null ? result.Concat(tail).ToList() : result;
                }

                Dictionary<string, string> catMapping = null;

                if (enemyType != Globals.CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER)
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

                    string targetCat = enemyType == Globals.CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER ? sourceCat : catMapping[sourceCat];

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

        private int GetEntityBlockStart()
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

        private void DetermineDynamicOffsets(byte[] fileData)
        {
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNativePatch5 = IsNativePatch5Format(fileData);
            Int16 levelIndex = GetLevelIndex(fileData);

            // Entity & ID lists
            var baseList = TR1EntityCache.LevelObjectIdsByLevel[levelIndex];
            var levelObjectIds = new List<int>(baseList);

            // Reset health offset
            HEALTH_OFFSET = -1;

            // Cursor start
            sgBufferCursor = GetEntityBlockStart();

            // Challenge Mode param block
            if (isChallengeMode && isNativePatch5)
            {
                byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
                byte enemyType = GetChallengeModeEnemyType(fileData);
                Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);
                levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

                sgBufferCursor += Globals.CHALLENGE_MODE_PARAM_BLOCK_SIZE;
            }

            // Fixed blocks
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
                    throw new Exception($"{Globals.ERROR_MSG_MISSING_LEVEL_DEFINITION} {levelIndex}.");
                }

                if (!levelObjects.TryGetValue(objectId, out var tr1Object))
                {
                    throw new Exception($"{Globals.ERROR_MSG_MISSING_OBJECT_DEFINITION} (object ID: 0x{objectId:X}).");
                }

                if (tr1Object.ObjectId == Globals.LARA_ENTITY_ID)
                {
                    HEALTH_OFFSET = sgBufferCursor + 0x24;
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

            magnumAmmoOffset2 = sgBufferCursor + 0x148;
            uziAmmoOffset2 = sgBufferCursor + 0x150;
            shotgunAmmoOffset2 = sgBufferCursor + 0x158;
        }

        private bool IsPrepatchSavegameFile(byte[] fileData)
        {
            return BitConverter.ToUInt32(fileData, Globals.SAVEFILE_VERSION_OFFSET) == Globals.SAVEFILE_TRX_PREPATCH;
        }

        private bool IsNewGamePlus(byte[] fileData)
        {
            return BitConverter.ToInt32(fileData, savegameOffset + NEW_GAME_PLUS_OFFSET) != 0;
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

            if (maxHealthSetting == 0) return (Int16)100;
            if (maxHealthSetting == 1) return (Int16)250;
            if (maxHealthSetting == 2) return (Int16)500;
            if (maxHealthSetting == 3) return (Int16)1000;
            if (maxHealthSetting == 4) return (Int16)1500;
            if (maxHealthSetting == 5) return (Int16)1750;
            if (maxHealthSetting == 6) return (Int16)2000;
            if (maxHealthSetting == 7) return (Int16)5000;

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

        private void WriteWeaponsConfigNum(byte[] fileData, byte value)
        {
            fileData[savegameOffset + WEAPONS_CONFIG_NUM_OFFSET] = value;
        }

        private void WriteHealthValue(byte[] fileData, Int16 newHealth)
        {
            int healthOffset = GetHealthOffset(fileData, true);

            if (healthOffset != -1)
            {
                WriteInt16ToBuffer(fileData, healthOffset, newHealth);
            }
        }

        private void WriteShotgunAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + SHOTGUN_AMMO_OFFSET, ammo);

            if (!isPrepatch && (shotgunAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || shotgunAmmoOffset2 > AMMO_WRITE_UPPER_BOUND))
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

        private void WriteMagnumAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + MAGNUM_AMMO_OFFSET, ammo);

            if (!isPrepatch && (magnumAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || magnumAmmoOffset2 > AMMO_WRITE_UPPER_BOUND))
            {
                return;
            }

            if (isPresent)
            {
                WriteInt32ToBuffer(fileData, savegameOffset + magnumAmmoOffset2, (Int32)ammo);
            }
            else
            {
                WriteInt32ToBuffer(fileData, savegameOffset + magnumAmmoOffset2, 0);
            }
        }

        private void WriteUziAmmo(byte[] fileData, bool isPresent, UInt16 ammo, bool isPrepatch)
        {
            WriteUInt16ToBuffer(fileData, savegameOffset + UZI_AMMO_OFFSET, ammo);

            if (!isPrepatch && (uziAmmoOffset2 < AMMO_WRITE_LOWER_BOUND || uziAmmoOffset2 > AMMO_WRITE_UPPER_BOUND))
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

        public void DisplayGameInfo(byte[] fileData, CheckBox chkPistols, CheckBox chkMagnums, CheckBox chkUzis,
            CheckBox chkShotgun, NumericUpDown nudSmallMedipacks, NumericUpDown nudLargeMedipacks,
            NumericUpDown nudUziAmmo, NumericUpDown nudShotgunAmmo, NumericUpDown nudMagnumAmmo,
            NumericUpDown nudSaveNumber, TrackBar trbHealth, Label lblHealth, Label lblHealthError)
        {
            DetermineOffsets(fileData);

            bool isPrepatch = IsPrepatchSavegameFile(fileData);
            bool isChallengeMode = IsChallengeMode(fileData);
            bool isNewGamePlus = IsNewGamePlus(fileData);

            MAX_HEALTH_VALUE = (isChallengeMode && !isPrepatch) ? GetChallengeModeMaxHealth(fileData) : MAX_HEALTH_VALUE_DEFAULT;
            trbHealth.Maximum = MAX_HEALTH_VALUE;

            nudSmallMedipacks.Enabled = !isNewGamePlus;
            nudLargeMedipacks.Enabled = !isNewGamePlus;

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

                int entityBlockStart = GetEntityBlockStart();

                AMMO_WRITE_LOWER_BOUND = entityBlockStart;
                AMMO_WRITE_UPPER_BOUND = SAVEGAME_SIZE - 4;
            }

            WriteUziAmmo(fileData, chkUzis.Checked, (UInt16)nudUziAmmo.Value, isPrepatch);
            WriteMagnumAmmo(fileData, chkMagnums.Checked, (UInt16)nudMagnumAmmo.Value, isPrepatch);
            WriteShotgunAmmo(fileData, chkShotgun.Checked, (UInt16)(nudShotgunAmmo.Value * 6), isPrepatch);

            if (trbHealth.Enabled)
            {
                WriteHealthValue(fileData, (Int16)trbHealth.Value);
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
            return BitConverter.ToInt32(fileData, savegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;
        }

        public void UpdateDisplayName(Savegame savegame, byte[] fileData)
        {
            bool isSavegamePresent = BitConverter.ToInt32(fileData, savegame.Offset + Globals.SLOT_STATUS_OFFSET) != 0;

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

            for (int i = cmbSavegames.Items.Count; i < Globals.MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR1)
                {
                    Int16 levelIndex = BitConverter.ToInt16(fileData, currentSavegameOffset + LEVEL_INDEX_OFFSET);
                    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;

                    if (isSavegamePresent && levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
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
                            bool isNewGamePlus = BitConverter.ToInt32(fileData, currentSavegameOffset + NEW_GAME_PLUS_OFFSET) != 0;
                            bool isChallengeMode = fileData[currentSavegameOffset + CHALLENGE_MODE_OFFSET] == 1 && !isPrepatch;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, isNewGamePlus, false, isChallengeMode);
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
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PREPATCH;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PREPATCH;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PREPATCH;
                LEVEL_INDEX_OFFSET = LEVEL_INDEX_OFFSET_PREPATCH;
            }
            else
            {
                BASE_SAVEGAME_OFFSET_TR1 = BASE_SAVEGAME_OFFSET_TR1_PATCH5;
                MAX_SAVEGAME_OFFSET_TR1 = MAX_SAVEGAME_OFFSET_TR1_PATCH5;
                SAVEGAME_SIZE = Globals.SAVEGAME_SIZE_TRX_PATCH5;

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

            for (int i = 0; i < Globals.MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_SIZE);

                Int16 levelIndex = BitConverter.ToInt16(fileData, currentSavegameOffset + LEVEL_INDEX_OFFSET);
                Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
                bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;

                if (isSavegamePresent && levelNames.TryGetValue(levelIndex, out string levelName) && saveNumber >= 0)
                {
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR1) / SAVEGAME_SIZE;
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
