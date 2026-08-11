# Tomb Raider I-VI Remastered Savegame Editor
An open source savegame editor for Tomb Raider I-VI Remastered. Main features are listed below. The next section contains
basic use instructions as well as how to edit savegames from platforms other than PC. If you are interested in reverse engineering, there is a technical portion
on the bottom section of this README. For a tool that allows you to import savegames, convert to PC/PS4/Android/NS format,
and reorder/delete savegames, check out [TombExtract](https://github.com/JulianOzelRose/TombExtract).

### ✨ Features
- 🎒 Edit Inventory & Items
- 🔫 Edit Weapons & Ammo
- ❤️ Edit Health
- 📍 Edit Position / Teleport
- 📊 Edit Statistics
- 🔓 Unlock NG+ & Outfits
- 🗑️ Savegame Deletion
- 🖥️ Cross-Platform Compatibility (PC/PS4/Android/NS/iOS)
- 🔄 Patch 5 & Pre-Patch Compatible

<br>
<img width="723" height="640" alt="MainForm" src="https://github.com/user-attachments/assets/256a1653-9961-4d64-8ea7-e49f1925c45b" />

## Installation and use
To download and use this savegame editor, navigate to the [Releases](https://github.com/JulianOzelRose/TRR-SaveMaster/releases) page,
then download the `.exe` file of the latest version under "Assets". You can save it anywhere on your computer. Once downloaded, open the file.
The editor will then prompt you to select your savegame path, click "Yes". The editor will automatically open to your `TRX/TRX2` folder.
Once there, navigate to the numeric folder that represents your Steam Community ID. If you have multiple accounts with Tomb Raider Remastered, there may be multiple folders.

Once the savegames are populated in the editor, you can select them using the dropdown labeled "Savegame" in the top-right corner.
The editor will automatically refresh savegame data when switching tabs or clicking the savegame dropdown. If another savegame is added and not displaying,
you can click "File" -> "Refresh savegame list" to re-populate the savegames.

Once you are done making changes, click "Save" to apply them. Because the game caches savegames into memory, you must restart your game in order for the changes to take effect.

## Editing savegames from other platforms
By default, this savegame editor assumes PC format of savegames. To change the savegame platform, click "Settings" -> "Platform", then select your savegame platform.

Current supported platforms for Tomb Raider I-III Patch 5 are PC, PS4, and Android. Nintendo Switch savegames are not yet supported for Tomb Raider I-III Patch 5 savegames.
All platforms are supported for Tomb Raider IV-VI.

Console format (PS4/NS) savegames must be decrypted first. You can find more information on how to do that [here](https://github.com/JulianOzelRose/TombExtract/issues/1#issuecomment-1978837071).

For mobile format (Android/iOS), accessing the savegame file requires a rooted device. Rooting your device may void your warranty and can introduce security risks, so it is generally not recommended.
However, editing mobile savegames is still possible if your device is rooted.

## Using the Position Editor
<img width="359" height="344" alt="PositionForm-UI" src="https://github.com/user-attachments/assets/19d932cf-6e2e-4812-aeb6-5de21b417c8f" />
<br>

This savegame editor includes a Position Editor feature. To use it, click "Edit" -> "Position".
Once in the Position Editor menu, you can teleport to pre-determined coordinates, such as the start of the level, the end of the level, or secret locations.  

- The **X-coordinate** represents Lara's horizontal position in the game. Decreasing its value moves her to the left, while increasing it moves her to the right.  
- The **Y-coordinate** represents Lara's vertical position in the game. Decreasing it moves her up, while increasing it moves her down.  
- The **Z-coordinate** represents Lara's depth position in the game. Increasing it moves her forward, while decreasing it moves her backward.  
- The **Orientation** value determines the direction Lara is facing, measured in degrees.
- The **Room/Zone** value represents the unique room number/loaded zone that Lara or Kurtis is currently located in.

It's essential that the Room/Zone number matches Lara's current coordinates. Otherwise, the game will not interpret her position correctly. Click "Save" in this menu to apply changes, or "Cancel" to retain Lara's current
position. Position cannot be edited while Lara is in a vehicle. If you try to teleport while Lara is interacting with a puzzle, it may result in the game crashing.

## Using the Statistics Editor
<img width="391" height="502" alt="StatisticsForm-UI" src="https://github.com/user-attachments/assets/f8079c59-353f-46ec-b7f2-cbdc0ae1e48b" />
<br>

This savegame editor also includes a Statistics Editor feature. To use it, click "Edit," then select "Statistics".<br>

For Tomb Raider I-III, use the level dropdown to choose which level's statistics to edit. "Current Level" represents the level currently being played, while selecting any other level allows you to edit the statistics recorded for that completed level.
For Tomb Raider VI, use the dropdown to switch between "Current Level" statistics and "Final Statistics", which represent the cumulative statistics for the entire playthrough.
For Tomb Raider IV and V, the statistics are global rather than level-specific, meaning they track cumulative progress across the entire game, including total playtime, total kills, and total pickups.

## Unlocks and Outfits
<img width="337" height="363" alt="UnlocksForm" src="https://github.com/user-attachments/assets/8b9f129d-8b08-44d5-abe5-16122f55383e" />
<br>

To access the Unlocks Editor, click "Edit" -> "Unlocks".

From here, you can:
- Unlock New Game+
- Unlock Society of Raiders
- Unlock Outfits


## Dark Mode
<img width="723" height="618" alt="DarkMode-UI" src="https://github.com/user-attachments/assets/76a00668-5a68-4ef3-87ac-fd141ee62b58" />
<br>

If you prefer a darker interface, you can enable Dark Mode from the Settings menu at the top of the program.
Please note that Dark Mode may not display correctly when using very high or very low DPI settings.
If you have trouble viewing the checkboxes on your display, you can try changing "Settings" -> "Advanced" -> "Use flat style checkboxes for Dark Mode".

## Tomb Raider I-III Remastered Savegame Format
This section details the technical aspects of reverse engineering the savegames of the Tomb Raider I-III Remastered trilogy. All savegames are stored in the `savegame.dat` file.
Savegames for expansions are stored in the same slots as the original game. Each savegame slot for each game begins at a specific offset in the file, with a maximum of 32
slots per game. If you want to see a more detailed layout of the savegame format for Tomb Raider I-III, [this one](https://gist.github.com/Doliman100/2cc56dee0b73b5e344ae9468b29e12e9) is excellent.

| Game                               | Offset   |
|:-----------------------------------|:---------|
| Tomb Raider I                      | 0x002004 |
| Tomb Raider II                     | 0x0D2004 |
| Tomb Raider III                    | 0x1A2004 |

Because each savegame has a constant size of `0x6800` bytes, that value can be used as an iterator when cycling through savegames.
When a savegame slot is occupied, the value at offset `0x004` is set to 1. When a savegame slot is empty,
the value is 0. See the code below.

```
for (int i = 0; i < Globals.MAX_SAVEGAMES; i++)
{
    int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR3 + (i * SAVEGAME_SIZE);

    Int16 levelIndex = BitConverter.ToInt16(fileData, currentSavegameOffset + LEVEL_INDEX_OFFSET);
    Int32 saveNumber = BitConverter.ToInt32(fileData, currentSavegameOffset + SAVE_NUMBER_OFFSET);
    bool isSavegamePresent = BitConverter.ToInt32(fileData, currentSavegameOffset + Globals.SLOT_STATUS_OFFSET) != 0;

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
```

Because you are dealing with multiple savegames stored in a single file, you need to use relative offsets and calculate them accordingly. You can find more
details on this for each game in the sections below further. The tables below denote the static offsets for all 3 games. Note, they are relative offsets.
So when calculating, you will have to add them to the base savegame offset.

#### Tomb Raider I
| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x000     | Int32   | Slot Status        |
| 0x004     | Int32   | New Game+          |
| 0x008     | Int32   | Save Number        |
| 0x4BE     | UInt16  | Magnum Ammo 1      |
| 0x4C0     | UInt16  | Uzi Ammo 1         |
| 0x4C2     | UInt16  | Shotgun Ammo 1     |
| 0x4C4     | UInt8   | Small Medipack     |
| 0x4C5     | UInt8   | Large Medipack     |
| 0x4E8     | UInt8   | Weapons            |
| 0x60C     | Int32   | Crystals Used      |
| 0x610     | Int32   | Time Taken         |
| 0x614     | Int32   | Ammo Used          |
| 0x618     | Int32   | Hits               |
| 0x61C     | Int32   | Kills              |
| 0x620     | UInt32  | Distance Travelled |
| 0x624     | UInt16  | Secrets Found      |
| 0x626     | Int8    | Pickups            |
| 0x627     | Int8    | Medi Packs Used    |
| 0x628     | Int16   | Level Index        |
| 0x6E0     | UInt32  | Savegame Version   |

#### Tomb Raider II
| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x000     | Int32   | Slot Status        |
| 0x004     | Int32   | New Game+          |
| 0x008     | Int32   | Save Number        |
| 0x60C     | Int32   | Time Taken         |
| 0x610     | Int32   | Ammo Used          |
| 0x614     | Int32   | Hits               |
| 0x618     | Int32   | Kills              |
| 0x61C     | UInt32  | Distance Travelled |
| 0x620     | UInt16  | Secrets Found      |
| 0x622     | Int8    | Pickups            |
| 0x623     | Int8    | Medi Packs Used    |
| 0x624     | Int16   | Level Index        |
| 0x6A4     | UInt32  | Savegame Version   |

#### Tomb Raider III
| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x000     | Int32   | Slot Status        |
| 0x004     | Int32   | New Game+          |
| 0x008     | Int32   | Save Number        |
| 0x8A0     | Int32   | Crystals Found     |
| 0x8A4     | Int32   | Crystals Used      |
| 0x8A8     | Int32   | Time Taken         |
| 0x8AC     | Int32   | Ammo Used          |
| 0x8B0     | Int32   | Hits               |
| 0x8B4     | Int32   | Kills              |
| 0x8B8     | UInt32  | Distance Travelled |
| 0x8BC     | UInt16  | Secrets Found      |
| 0x8BE     | Int8    | Pickups            |
| 0x8BF     | Int8    | Medi Packs Used    |
| 0x8D2     | Int16   | Level Index        |
| 0x988     | UInt32  | Savegame Version   |

## Tomb Raider I Deserializer
### Pre-Entity Data
The Tomb Raider I deserializer starts at a fixed offset, which depends on the savegame platform and version. It first checks for the savegame version flag and the Challenge Mode flag.
If the respective flags show Patch 5 and Challenge Mode, it then reads an extra `0xC` bytes for the Challenge Mode parameter block. After several fixed reads, it then reads level state entries
from the savegame in a loop, each 2-byte integers. If the savegame is native Patch 5, an additional DWORD is read.

```
sgBufferCursor = GetEntityBlockStart();

if (isChallengeMode && isNativePatch5)
{
    byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
    byte enemyType = GetChallengeModeEnemyType(fileData);
    Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);
    levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

    sgBufferCursor += Globals.CHALLENGE_MODE_PARAM_BLOCK_SIZE;
}

sgBufferCursor += 4;
sgBufferCursor += 0x118;

int gLevelStateEntryCount = TR1EntityCache.LevelStateEntryCounts[levelIndex];
sgBufferCursor += gLevelStateEntryCount * 2;

if (isNativePatch5)
{
    sgBufferCursor += 4;
}
```

### Entity Loop
Then, the entity deserializer loop begins. For native Patch 5 savegames, an additional DWORD is read for each entity.
It then performs a series of bitmask checks for each entity type, and reads additional data accordingly.
Health is located by identifying Lara's entity (ID 0) and recording the offset `0x24` within her entity block.
After the loop ends, additional Lara info is deserialized, which is where the secondary ammo data is stored.
<br>

```
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
```

## Tomb Raider II Deserializer
### Pre-Entity Data
The Tomb Raider II deserializer also starts at a fixed offset, which depends on the savegame platform and version. It first checks for the savegame version flag and the Challenge Mode flag.
If the respective flags show Patch 5 and Challenge Mode, it then reads an extra `0xC` bytes for the Challenge Mode parameter block.
After several fixed reads, it then reads level state entries from the savegame in a loop, each 2-byte integers. If the savegame is native Patch 5, an additional DWORD is read.

```
sgBufferCursor = GetEntityBlockStart(isPrepatch);

if (isChallengeMode && isNativePatch5 && !isPrepatch)
{
    byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
    byte enemyType = GetChallengeModeEnemyType(fileData);
    Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);
    levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

    sgBufferCursor += Globals.CHALLENGE_MODE_PARAM_BLOCK_SIZE;
}

sgBufferCursor += 4;
sgBufferCursor += 0x118;

int gLevelStateEntryCount = TR2EntityCache.LevelStateEntryCounts[levelIndex];
sgBufferCursor += gLevelStateEntryCount * 2;

if (isNativePatch5 && !isPrepatch)
{
    sgBufferCursor += 4;
}
```

### Entity Loop
Next is the entity deserializer loop. It is structurally similar to the Tomb Raider I entity loop, with some differences in deserializing actor data.
For native Patch 5 savegames, an additional DWORD is read for each entity. It then performs a series of bitmask checks for each entity type, and reads additional data accordingly.
Health is located by identifying Lara's entity (ID 0) and recording the offset `0x24` within her entity block.

The base size of the `0x20` actor block depends on the `0x02` flag. If the entity's AI-active bit is set, an additional AI block is present and the cursor is advanced by `0xC` bytes.
Certain entities mutate the runtime object ID of another entity during deserialization. When this condition is detected, the target entity's object ID is updated to `0xD` for the rest of the deserializer.
Several objects also have special handling at the tail of the loop, as additional data is deserialized from them specifically.

After the loop ends, additional Lara info is deserialized, which is where the secondary ammo data and Lara's vehicle status (`LARA_VEHICLE_ITEM_OFFSET`) is stored.
<br>

```
for (int itemIndex = 0; itemIndex < levelObjectIds.Count; itemIndex++)
{
    int objectId = levelObjectIds[itemIndex];

    if (isNativePatch5 && !isPrepatch)
    {
        sgBufferCursor += 4;
    }

    if (!TR2EntityCache.TR2ObjectsByLevel.TryGetValue(levelIndex, out var levelObjects))
    {
        throw new Exception($"{Globals.ERROR_MSG_MISSING_LEVEL_DEFINITION} {levelIndex}.");
    }

    if (!levelObjects.TryGetValue(objectId, out var tr2Object))
    {
        throw new Exception($"{Globals.ERROR_MSG_MISSING_OBJECT_DEFINITION} (object ID: 0x{objectId:X}).");
    }

    if (tr2Object.ObjectId == Globals.LARA_ENTITY_ID)
    {
        HEALTH_OFFSET = sgBufferCursor + 0x24;
    }

    if ((tr2Object.Flags00 & 0x08) != 0)
    {
        sgBufferCursor += 0x1A;
    }

    if ((tr2Object.Flags00 & 0x40) != 0)
    {
        sgBufferCursor += 0x0A;
    }

    if ((tr2Object.Flags00 & 0x10) != 0)
    {
        sgBufferCursor += 0x02;
    }

    if ((tr2Object.Flags00 & 0x20) != 0)
    {
        int blockStart = sgBufferCursor;
        bool has02 = (tr2Object.Flags00 & 0x02) != 0;

        ushort u2 = BitConverter.ToUInt16(fileData, savegameOffset + blockStart + (has02 ? 0 : -2));

        bool isEntityAIActive = has02 && (u2 & 0x0080) != 0;

        int increment = has02 ? 0x16 : 0x14;

        if (isEntityAIActive)
        {
            increment += ENTITY_AI_BLOCK_SIZE;
        }

        sgBufferCursor += increment;

        bool mutatesTargetEntity = (u2 & 0x06) == 0x04;

        if (mutatesTargetEntity &&
            TR2EntityCache.ControllerTargetEntitiesByLevel.TryGetValue(levelIndex, out var controllerTargets) &&
            controllerTargets.TryGetValue(itemIndex, out int targetItemIndex))
        {
            levelObjectIds[targetItemIndex] = 0x0D;
        }
    }

    if (objectId == 0x0D || objectId == 0x0E)
    {
        sgBufferCursor += 0x18;
    }
    else if (objectId == 0x41)
    {
        sgBufferCursor += 0x08;
    }
}

LARA_VEHICLE_ITEM_OFFSET = sgBufferCursor + 0x28;

automaticPistolsAmmoOffset2 = sgBufferCursor + 0x148;
uziAmmoOffset2 = sgBufferCursor + 0x150;
shotgunAmmoOffset2 = sgBufferCursor + 0x158;
harpoonGunAmmoOffset2 = sgBufferCursor + 0x160;
grenadeLauncherAmmoOffset2 = sgBufferCursor + 0x168;
m16AmmoOffset2 = sgBufferCursor + 0x178;
```

## Tomb Raider III Deserializer
### Pre-Entity Data
The Tomb Raider III deserializer is very similar to the Tomb Raider II deserializer.
It also starts at a fixed offset, which depends on the savegame platform and version. It first checks for the savegame version flag and the Challenge Mode flag.
If the respective flags show Patch 5 and Challenge Mode, it then reads an extra `0xC` bytes for the Challenge Mode parameter block.
After several fixed reads, it then reads level state entries from the savegame in a loop, each 2-byte integers. If the savegame is native Patch 5, an additional DWORD is read.

```
sgBufferCursor = GetEntityBlockStart(isPrepatch);

if (isChallengeMode && isNativePatch5 && !isPrepatch)
{
    byte enemyNumbers = GetChallengeModeEnemyNumbers(fileData);
    byte enemyType = GetChallengeModeEnemyType(fileData);
    Int32 challengeModeRNGSeed = GetChallengeModeRNGSeed(fileData);
    levelObjectIds = ApplyChallengeModeMutations(levelObjectIds, levelIndex, enemyNumbers, enemyType, challengeModeRNGSeed);

    sgBufferCursor += Globals.CHALLENGE_MODE_PARAM_BLOCK_SIZE;
}

sgBufferCursor += 4;
sgBufferCursor += 0x118;

int gLevelStateEntryCount = TR3EntityCache.LevelStateEntryCounts[levelIndex];
sgBufferCursor += gLevelStateEntryCount * 2;

if (isNativePatch5 && !isPrepatch)
{
    sgBufferCursor += 4;
}
```


### Entity Loop
Next is the entity deserializer loop. It is structurally similar to the Tomb Raider II entity loop.
For native Patch 5 savegames, an additional DWORD is read for each entity. It then performs a series of bitmask checks for each entity type, and reads additional data accordingly.
Health is located by identifying Lara's entity (ID 0) and recording the offset `0x24` within her entity block.

The base size of the `0x20` actor block depends on the `0x02` flag. If the entity's AI-active bit is set, an additional AI block is present and the cursor is advanced by `0xA` bytes.
In Tomb Raider III's deserializer, more objects have special handling at the tail of the loop.

After the loop ends, additional Lara info is deserialized, which is where the secondary ammo data and Lara's vehicle status (`LARA_VEHICLE_ITEM_OFFSET`) is stored.

```
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

    if (tr3Object.ObjectId == Globals.LARA_ENTITY_ID)
    {
        HEALTH_OFFSET = sgBufferCursor + 0x24;
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
```


## Tomb Raider IV-VI Remastered Savegame Format
This section details the technical aspects of reverse engineering the savegames of the Tomb Raider IV-VI Remastered trilogy. Like the first trilogy, all savegames are stored in the `savegame.dat` file.
Each savegame slot for each game begins at a specific offset in the file, with a maximum of 32 slots per game. Each savegame has a fixed size of 0xA470 bytes. See the table below.

| Game                               | Offset   |
|:-----------------------------------|:---------|
| Tomb Raider IV                     | 0x002004 |
| Tomb Raider V                      | 0x14AE04 |
| Tomb Raider VI                     | 0x293C04 |

Below are the offset tables for Tomb Raider IV-VI. With the exception of health, most of the offsets are static. For Tomb Raider VI, the table only shows the header offsets, as the savegame data is very dynamic.

#### Tomb Raider IV
| Offset    | Type    | Description             |
|:----------|:--------|:------------------------|
| 0x000     | Int32   | Slot Status             |
| 0x004     | Int32   | Save Number             |
| 0x018     | Int32   | New Game+               |
| 0x26B     | UInt8   | Level Index             |
| 0x1BA     | UInt16  | Small Medipack          |
| 0x1BC     | UInt16  | Large Medipack          |
| 0x1BE     | UInt16  | Flares                  |
| 0x190     | UInt8   | Pistols                 |
| 0x191     | UInt8   | Uzi                     |
| 0x192     | UInt8   | Shotgun                 |
| 0x193     | UInt8   | Crossbow                |
| 0x195     | UInt8   | Grenade Gun             |
| 0x196     | UInt8   | Revolver                |
| 0x1C2     | UInt16  | Uzi Ammo                |
| 0x1C4     | UInt16  | Revolver Ammo           |
| 0x1C6     | UInt16  | Shotgun Normal Ammo     |
| 0x1C8     | UInt16  | Shotgun Wideshot Ammo   |
| 0x1CC     | UInt16  | Grenade Gun Normal Ammo |
| 0x1CE     | UInt16  | Grenade Gun Super Ammo  |
| 0x1D0     | UInt16  | Grenade Gun Flash Ammo  |
| 0x1D2     | UInt16  | Crossbow Normal Ammo    |
| 0x1D4     | UInt16  | Crossbow Poison Ammo    |
| 0x1D6     | UInt16  | Crossbow Explosive Ammo |
| 0x22C     | Int32   | Time Taken              |
| 0x230     | UInt32  | Distance Travelled      |
| 0x234     | Int16   | Ammo Used               |
| 0x23C     | Int32   | Pickups                 |
| 0x240     | UInt16  | Kills                   |
| 0x242     | UInt8   | Secrets Found           |
| 0x243     | UInt8   | Health Packs Used       |
| 0x27C     | Int32   | Vessels Broken          |


#### Tomb Raider V
| Offset    | Type    | Description                  |
|:----------|:--------|:-----------------------------|
| 0x000     | Int32   | Slot Status                  |
| 0x004     | Int32   | Save Number                  |
| 0x018     | Int32   | New Game+                    |
| 0x26B     | UInt8   | Level Index                  |
| 0x1BA     | UInt16  | Small Medipack               |
| 0x1BC     | UInt16  | Large Medipack               |
| 0x1BE     | UInt16  | Flares                       |
| 0x190     | UInt8   | Pistols                      |
| 0x191     | UInt8   | Uzi                          |
| 0x192     | UInt8   | Shotgun                      |
| 0x193     | UInt8   | Grappling Gun                |
| 0x194     | UInt8   | HK Gun                       |
| 0x196     | UInt8   | Revolver / Desert Eagle      |
| 0x1C2     | UInt16  | Uzi Ammo                     |
| 0x1C4     | UInt16  | Revolver / Desert Eagle Ammo |
| 0x1C6     | UInt16  | Shotgun Normal Ammo          |
| 0x1C8     | UInt16  | Shotgun Wideshot Ammo        |
| 0x1CA     | UInt16  | HK Gun Ammo                  |
| 0x1D2     | UInt16  | Grappling Gun Ammo           |
| 0x22C     | Int32   | Time Taken                   |
| 0x230     | UInt32  | Distance Travelled           |
| 0x234     | Int16   | Ammo Used                    |
| 0x23C     | Int32   | Pickups                      |
| 0x240     | UInt16  | Kills                        |
| 0x242     | UInt8   | Secrets Found                |
| 0x243     | UInt8   | Health Packs Used            |

#### Tomb Raider VI
| Offset    | Type    | Description                  |
|:----------|:--------|:-----------------------------|
| 0x000     | Int32   | Slot Status                  |
| 0x004     | UInt32  | Savegame Version             |
| 0x010     | UInt8   | Level Index                  |
| 0x118     | UInt32  | Save Number                  |
| 0x23C     | Int32   | Time Taken                   |
| 0x240     | UInt32  | Distance Travelled           |
| 0x244     | Int32   | Ammo Used                    |
| 0x248     | Int32   | Hits                         |
| 0x24C     | UInt16  | Pickups                      |
| 0x24E     | UInt16  | Health Items Found           |
| 0x250     | UInt8   | Chocobars Found              |
| 0x252     | UInt16  | Kills                        |
| 0x254     | UInt8   | Health Restored              |
| 0x358     | Int32   | New Game+                    |
| 0x360     | UInt32  | Compressed Block Size        |

## Tomb Raider IV Deserializer
### Pre-Entity Data
The Tomb Raider IV deserializer begins by reading several fixed blocks. It then deserializes static mesh counts,
then post-static mesh flags, then camera data, and spotcam data.

```
sgBufferCursor += 0xB;
sgBufferCursor += 0x20;
sgBufferCursor += 0x11F;

if (TR4EntityCache.EligibleStaticMeshCounts.TryGetValue(levelIndex, out int eligibleStaticMeshCount))
{
    sgBufferCursor += ((eligibleStaticMeshCount + 15) / 16) * 2;
}

sgBufferCursor += 0x04;

if (TR4EntityCache.LevelCameraCounts.TryGetValue(levelIndex, out int cameraCount))
{
    sgBufferCursor += cameraCount * 0x02;
}

if (TR4EntityCache.LevelSpotcamCounts.TryGetValue(levelIndex, out int spotcamCount))
{
    sgBufferCursor += spotcamCount * 0x02;
}
```

### Entity Loop
The entity loop for Tomb Raider IV is considerably more complex than those of the first three games. Each entity begins with a set of runtime flags that determine whether it should be deserialized and which data blocks are present.
Lara's health offset is calculated when her entity is encountered, with the presence of the health field determined by the corresponding runtime flag.

Near the end of the loop, additional runtime and object flags control the deserialization of creature-specific data. Finally, several object IDs receive special-case handling with additional serialized data.

```
for (int itemIndex = 0; itemIndex < tr4Objects.Count; itemIndex++)
{
    TR4Object tr4Object = tr4Objects[itemIndex];

    int itemFlagsOffset = ENTITY_STREAM_OFFSET + virtualCursorStart + sgBufferCursor;
    int itemFlagsAbsoluteOffset = savegameOffset + itemFlagsOffset;

    UInt32 itemFlags = BitConverter.ToUInt32(fileData, itemFlagsAbsoluteOffset);
    sgBufferCursor += 0x04;

    if ((itemFlags & 0x200) != 0)
    {
        continue;
    }

    if ((itemFlags & 0x800) == 0)
    {
        continue;
    }

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

    if ((tr4Object.Flags00 & 0x40) != 0)
    {
        sgBufferCursor += tr4Object.ObjectId == Globals.LARA_ENTITY_ID ? 0x07 : 0x06;
    }

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

        if ((extendedFlags & 0x80000000) != 0)
        {
            sgBufferCursor += 0x49;
        }
    }

    if ((tr4Object.ObjectFlags & 0x2000) != 0)
    {
        sgBufferCursor += 0x0C;
    }

    if (tr4Object.ObjectId == 0x1F)
    {
        sgBufferCursor += 0x28;
    }

    if (tr4Object.ObjectId == 0x20)
    {
        sgBufferCursor += 0x30;
    }
}
```

## Tomb Raider V Deserializer
### Pre-Entity Data
Similar to that of the previous title, the Tomb Raider V deserializer begins by reading several fixed blocks, followed by static mesh counts.
Next, it reads camera counts and spotcam counts.

```
sgBufferCursor = 0xB;

sgBufferCursor += 0x1E;
sgBufferCursor += 0x11F;

if (TR5EntityCache.EligibleStaticMeshCounts.TryGetValue(levelIndex, out int eligibleStaticMeshCount))
{
    sgBufferCursor += ((eligibleStaticMeshCount + 15) / 16) * 2;
}

sgBufferCursor += 0x05;

if (TR5EntityCache.LevelCameraCounts.TryGetValue(levelIndex, out int cameraCount))
{
    sgBufferCursor += cameraCount * 0x02;
}

if (TR5EntityCache.LevelSpotcamCounts.TryGetValue(levelIndex, out int spotcamCount))
{
    sgBufferCursor += spotcamCount * 0x02;
}
```

### Entity Loop
The Tomb Raider V entity loop is nearly identical to Tomb Raider IV's. It uses the same runtime flag checks to determine which data blocks are present, calculates Lara's health offset when her entity is encountered, and conditionally deserializes creature-specific data.
The primary differences are a handful of game-specific object checks and flag conditions.

```
for (int itemIndex = 0; itemIndex < tr5Objects.Count; itemIndex++)
{
    TR5Object tr5Object = tr5Objects[itemIndex];

    UInt32 itemFlags = BitConverter.ToUInt32(fileData, savegameOffset + ENTITY_STREAM_OFFSET + sgBufferCursor);
    sgBufferCursor += 0x04;

    if ((itemFlags & 0x200) != 0)
    {
        continue;
    }

    if (((itemFlags & 0x800) == 0))
    {
        continue;
    }

    if ((tr5Object.Flags00 & 0x08) != 0)
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

    if ((tr5Object.Flags00 & 0x40) != 0)
    {
        sgBufferCursor += tr5Object.ObjectId == Globals.LARA_ENTITY_ID ? 0x07 : 0x06;
    }

    if (((itemFlags & 0x400) != 0))
    {
        if (tr5Object.ObjectId == Globals.LARA_ENTITY_ID)
        {
            HEALTH_OFFSET = sgBufferCursor + ENTITY_STREAM_OFFSET;
            return;
        }

        sgBufferCursor += 0x02;
    }

    if ((tr5Object.Flags00 & 0x20) != 0)
    {
        UInt32 extendedFlags = BitConverter.ToUInt32(fileData, savegameOffset + ENTITY_STREAM_OFFSET + sgBufferCursor);

        sgBufferCursor += 0x24;

        if ((itemFlags & 0x80) != 0)
        {
            sgBufferCursor += 0x02;
        }

        if ((itemFlags & 0x100) != 0)
        {
            sgBufferCursor += 0x02;
        }

        if (((tr5Object.Flags00 & 0x02) != 0) || ((uint)(tr5Object.ObjectId - 0xA4) < 5))
        {
            sgBufferCursor += 0x02;
        }

        if ((extendedFlags & 0x80000000) != 0)
        {
            sgBufferCursor += 0x49;
        }
    }

    if ((tr5Object.ObjectFlags & 0x2000) != 0)
    {
        sgBufferCursor += 0x0C;
    }
}
```

## Tomb Raider VI Deserializer
Tomb Raider VI uses a markedly different engine than the previous five releases. The header mainly stores savegame metadata, such as the save number, level number, timestamp,
and the statistics data. The rest of the savegame data is compressed using a customized variant of the lossless [LZW](https://en.wikipedia.org/wiki/Lempel%E2%80%93Ziv%E2%80%93Welch) compression algorithm.
The compressed portion of the savegame data begins at offset `0x36C` of the header. This is what the deserializer parses. Because 3D animation state entity data is stored in the savegame, the Tomb Raider VI
is notably more complex than those of the previous five games.

```
UInt32 savegameVersion = GetSavegameVersion(fileData);
UInt32 compressedBlockSize = GetCompressedBlockSize(fileData);
byte[] compressedBlockData = ReadBytes(savegameOffset + COMPRESSED_BLOCK_START_OFFSET, (int)compressedBlockSize);

decompressedBuffer = new byte[0];   // Clear buffer
decompressedBuffer = Unpack(compressedBlockData);

// Cursor start
sgBufferCursor = 0x4;

using (MemoryStream ms = new MemoryStream(decompressedBuffer))
using (BinaryReader reader = new BinaryReader(ms))
{
    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
    sgCurrentLevel = reader.ReadByte();
    sgBufferCursor += 0x1;

    sgBufferCursor += 0x4;

    LoadCachedEntities();

    InvLoad(reader);
    MapLoad(reader);
    CamLoad();
    CamLoad();
    CamLoad();

    sgBufferCursor += 0x8;

    FxLoad(reader);
    AudioLoad(reader);
    MapPickupLoad(reader, savegameVersion);
}
```

### Deserialized Blocks

| Block           | Size             |
|:----------------|:-----------------|
| Header          | 0x009            |
| Inv             | 0x12F            |
| Map             | Dynamic          |
| Cam1            | 0x044            |
| Cam2            | 0x044            |
| Cam3            | 0x044            |
| FX              | Dynamic          |
| Audio           | Dynamic          |
| Pickup          | Dynamic          |
| Inv2            | Dynamic          |

First is the header block (not to be confused with the savegame header outside the compressed buffer) which stores a static "TOMB" signature string, followed by the level (UInt8), and the loaded zone (Int32).
Next is the `Inv` block, which stores more game state metadata such as cash and conversation flags. The subsequent blocks are dynamic and more complex.

### `MapLoad`
Next is the `Map` block, which is by far the largest and most dynamic. First, static map globals are loaded. Next, actor data is deserialized, then objects, then triggers, then emmiters.
Water data is then deserialized, followed by audio locators and room data.

```
private void MapLoad(BinaryReader reader)
{
    MapLoadGlobals(reader);

    for (int i = 0; i < actors.Count; i++)
    {
        MapActorLoad(reader, actors[i], i);
    }

    for (int i = 0; i < objects.Count; i++)
    {
        MapObjLoad(reader, objects[i]);
    }

    for (int i = 0; i < NUM_TRIGGERS; i++)
    {
        MapTrigLoad(reader);
    }

    for (int i = 0; i < NUM_EMITTERS; i++)
    {
        MapEmitterLoad(reader);
    }

    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
    Int16 puVar11 = reader.ReadInt16();
    sgBufferCursor += 0x2;

    if (puVar11 != 0)
    {
        int index = 0;

        do
        {
            sgBufferCursor += 0x4;
            MapLoadBaseNode();
            sgBufferCursor += 0x2;
            index = index + 1;
        } while (index < puVar11);
    }

    for (int i = 0; i < NUM_AUDIO_LOCATORS; i++)
    {
        MapLoadBaseNode();
    }

    for (int i = 0; i < rooms.Count; i++)
    {
        if (rooms[i].RoomMeta != 0)
        {
            sgBufferCursor += 0x4;
        }
    }

    return;
}
```

### `MapActorLoad`
This function is responsible for deserializing actor data. It begins by checking if the active bit flag is set. It exits the function early if it is set.  
If the actor is the player, a special loading sequence is run (`PlayLoad()`). Special handling is also executed for boss entities. Finally, APB (animation data)
is deserialized if the condition byte is set.

```
private void MapActorLoad(BinaryReader reader, EntityMock actor, int actorIndex)
{
    if ((actor.ActiveFlag & 0x400000) != 0)
    {
        return;
    }

    bool isPlayer = actor.IsPlayable;

    if (isPlayer)
    {
        PLAYER_BASE_OFFSET = sgBufferCursor;
    }

    MapLoadBaseNode();

    sgBufferCursor += 0x4;

    if (isPlayer)
    {
        PlayLoad(reader);
        PLAYER_HEALTH_OFFSET = sgBufferCursor;
        sgBufferCursor += 0x4;
    }
    else
    {
        if (!ShouldLoadBoss(actorIndex))
        {
            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            int offset35CValue = reader.ReadInt16();
            sgBufferCursor += 0x2;

            sgBufferCursor += 0xA;

            if (((ushort)(offset35CValue - 300) < 200) || (sgCurrentLevel == 0x13))
            {
                PathLoad(reader);
            }

            BoneControlLoad(reader);
            BoneControlLoad(reader);
            BoneControlLoad(reader);
            BoneControlLoad(reader);

            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            float health = reader.ReadSingle();
            sgBufferCursor += 0x4;

            sgBufferCursor += 0x1;
        }
        else
        {
            BossLoad(reader);
        }
    }

    sgBufferCursor += 0x4;

    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
    byte condByte = reader.ReadByte();
    sgBufferCursor += 0x1;

    if (condByte != 0)
    {
        APB_Load(reader, actor);

        if ((actor.ActiveFlag & 0x8000000) != 0)
        {
            sgBufferCursor += 0xC0;
        }
    }
}
```
