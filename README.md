# Tomb Raider I-III Remastered Savegame Editor
This is a savegame editor for Tomb Raider I-III Remastered. It works on all levels, including bonus levels. You can edit items, health, weapons, ammunition, statistics, and coordinates.
Compatible with PC, PS4, and Nintendo Switch savegames. For instructions on how to download and use this savegame editor, scroll down to
the section below. Additionally, technical details on reverse engineering the Tomb Raider I-III Remastered trilogy are included on later on in this README.
For a tool that allows you to transfer individual savegames between files, convert savegames to PC/PS4/Nintendo Switch format, and reorder or delete savegames,
check out [TombExtract](https://github.com/JulianOzelRose/TombExtract).

![TRR-SaveMaster-UI](https://github.com/JulianOzelRose/TRR-SaveMaster/assets/95890436/5ebcc4b9-ff5c-4303-bcb8-4706c15a1124)

## Installation and use
To download this savegame editor, simply navigate to the [Releases](https://github.com/JulianOzelRose/TRR-SaveMaster/releases) page,
then download the .exe file of the latest version under "Assets". You can save it anywhere on your computer. Once downloaded, open the file.
The editor will then prompt you to select your savegame path, click "Yes". Your savegame path should be as follows:

`C:\Users\USERNAME\AppData\Roaming\TRX\77777777777777777\savegame.dat`

Just replace "USERNAME" with your actual username, and "77777777777777777" with whatever numeric ID you see. The number is your Steam Community ID, so if
you have multiple accounts with Tomb Raider I-III Remastered, there may be multiple folders. Because the savegame file is located in a hidden directory, you will have to enable
"Show hidden files, folders, or drives" in Windows Explorer. Once you have selected your savegame path, your savegames should populate in the editor. The editor will remember
your savegame path, so there is no need to re-enter it every time.

By default, this savegame editor assumes PC format of savegames. To change the savegame platform, click "Settings", then "Platform", then select your savegame platform.
Current supported platforms are PC, PS4, and Nintendo Switch. Once the savegames are populated in the editor, you can select them using the combo box labeled "Savegame"
in the top-right corner. The editor will automatically refresh savegame data when switching tabs or clicking the savegame combo box. If another savegame is added and not displaying,
you can click "Refresh" to re-populate the savegames. Once you are done making changes, click "Save" to apply them. Because the game caches savegames into memory,
you must restart your game in order for the changes to take effect.

This savegame editor has an auto backup feature, which will automatically create backups of your savegame file before writing. It is enabled by default. You can toggle this feature on or
off by clicking "File", then checking "Backup before saving". The backup will be saved in the same directory as your savegame file, with `.bak` suffixed to the file name. It is highly recommended that you
leave this feature enabled. While this savegame editor has been thoroughly tested and employs error handling to prevent faulty writes, no system is perfect.
Regular backups can safeguard your progress in the event of unforeseen issues or errors during the editing process. If you would like to manually create a backup of your savegame file,
you can also do this by clicking "File" then "Create backup".

## Reverse engineering Tomb Raider I-III Remastered
This section details the technical aspects of reverse engineering the savegames of the Tomb Raider I-III Remastered trilogy. All savegames are stored in the `savegame.dat` file.
Savegames for expansions are stored in the same slots as the original game. Each savegame slot for each game begins at a specific offset in the file, with a maximum of 32
slots per game. See the table below.

| Game                               | Offset  |
|:-----------------------------------|:--------|
| Tomb Raider I                      | 0x02000 |
| Tomb Raider II                     | 0x72000 |
| Tomb Raider III                    | 0xE2000 |

Because each savegame has a constant size of 0x3800 bytes, that value can be used as an iterator when cycling through savegames.
When a savegame slot is occupied, the value at offset `0x004` is set to 1. When a savegame slot is empty,
the value is 0. See the code below.

```
for (int i = 0; i < 32; i++)
{
    int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_ITERATOR);
    SetSavegameOffset(currentSavegameOffset);

    Int32 saveNumber = GetSaveNumber();
    byte levelIndex = GetLevelIndex();
    bool savegamePresent = IsSavegamePresent();

    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
    {
        string levelName = levelNames[levelIndex];
        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR1) / SAVEGAME_ITERATOR;
        GameMode gameMode = GetGameMode();

        Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode);
        cmbSavegames.Items.Add(savegame);

        numSaves++;
    }
}
```

Because you are dealing with multiple savegames stored in a single file, you need to use relative offsets and calculate them accordingly. You can find more
details on this for each game in the sections below further. The tables below denote the static offsets for all 3 games. Note, they are relative offsets.
So when calculating, you will have to add them to the base savegame offset.

#### Tomb Raider I
| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x004     | UInt8   | Slot Occupied      |
| 0x008     | UInt8   | Game Mode          |
| 0x00C     | Int32   | Save Number        |
| 0x4C2     | UInt16  | Magnum Ammo 1      |
| 0x4C4     | UInt16  | Uzi Ammo 1         |
| 0x4C6     | UInt16  | Shotgun Ammo 1     |
| 0x4C8     | UInt8   | Small Medipack     |
| 0x4C9     | UInt8   | Large Medipack     |
| 0x4EC     | UInt8   | Weapons            |
| 0x610     | Int32   | Crystals Used      |
| 0x614     | Int32   | Time Taken         |
| 0x618     | Int32   | Ammo Used          |
| 0x61C     | Int32   | Hits               |
| 0x620     | Int32   | Kills              |
| 0x624     | UInt32  | Distance Travelled |
| 0x628     | UInt16  | Secrets Found      |
| 0x62A     | Int8    | Pickups            |
| 0x62B     | Int8    | Medi Packs Used    |
| 0x62C     | UInt8   | Level Index        |

#### Tomb Raider II
| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x004     | UInt8   | Slot Occupied      |
| 0x008     | UInt8   | Game Mode          |
| 0x00C     | Int32   | Save Number        |
| 0x610     | Int32   | Time Taken         |
| 0x614     | Int32   | Ammo Used          |
| 0x618     | Int32   | Hits               |
| 0x61C     | Int32   | Kills              |
| 0x620     | UInt32  | Distance Travelled |
| 0x624     | UInt16  | Secrets Found      |
| 0x626     | Int8    | Pickups            |
| 0x627     | Int8    | Medi Packs Used    |
| 0x628     | UInt8   | Level Index        |

#### Tomb Raider III
| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x004     | UInt8   | Slot Occupied      |
| 0x008     | UInt8   | Game Mode          |
| 0x00C     | Int32   | Save Number        |
| 0x8A4     | Int32   | Crystals Found     |
| 0x8A8     | Int32   | Crystals Used      |
| 0x8AC     | Int32   | Time Taken         |
| 0x8B0     | Int32   | Ammo Used          |
| 0x8B4     | Int32   | Hits               |
| 0x8B8     | Int32   | Kills              |
| 0x8BC     | UInt32  | Distance Travelled |
| 0x8C0     | UInt16  | Secrets Found      |
| 0x8C2     | Int8    | Pickups            |
| 0x8C3     | Int8    | Medi Packs Used    |
| 0x8D6     | UInt8   | Level Index        |

## Using heuristics to find the health offset
In all 3 games, health is stored as a UInt16 value ranging from 1 (lowest health possible) to 1000 (maximum health). Because
health is dynamically allocated, it is necessary to use heuristics to determine its location. The health offset tends to shift
to a higher address when additional entities become active, and to a lower address as entities become inactive or die.

Because health is always stored right next to character movement data, it is possible to determine the current health offset
by checking the surrounding data for character movement byte flags. The algorithm below is for Tomb Raider III health detection.
First, it iterates through the predetermined health offset range for the level. Next, it checks if the value of the current offset
falls within a valid health range (1 to 1000 inclusive). If the value falls within a valid range, it performs one more heuristic check
by examining the surrounding data for character movement byte flags. If a valid pattern is found, the offset is returned as the
current health offset.

This algorithm is able to determine the correct health offset ~96% of the time. Although it is theoretically possible to increase
the detection rate by adding more character movement byte flags, doing so would result in false positives, as certain character movement
byte flags coincide with null padding or other unrelated data.

```
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
```

## Reverse engineering Tomb Raider I savegames
Because almost all of the offsets in Tomb Raider I are static, it is the most straightforward game to reverse of the trilogy. Weapons inventory configuration
is stored on a single offset, referred to in this editor's code as `weaponsConfigNum`. It has a base number of 1, which indicates no weapons present.
You can use bitwise to determine which weapons are present in inventory. Each weapon corresponds to a specific byte flag. See the table blow.

| Weapon   | Byte flag |
|:---------|:----------|
| Pistols  | 2         |
| Magnums  | 4         |
| Uzis     | 8         |
| Shotgun  | 16        |

Ammunition is stored on up to two offsets. If a weapon is not equipped, it is only stored on one offset (primary). If the weapon is equipped, it is stored on
both offsets (primary and secondary). The primary offsets in Tomb Raider I are static. While the secondary offsets are dynamic, they only vary based on the
level -- so there is no need to recalculate them once they have been determined based on the level index. When removing a weapon from inventory, the editor
zeroes the secondary ammo bytes to free its address space. See the code below.

```
private void WriteShotgunAmmo(bool isPresent, UInt16 ammo)
{
    WriteUInt16(savegameOffset + shotgunAmmoOffset, ammo);

    if (isPresent)
    {
        WriteUInt16(savegameOffset + shotgunAmmoOffset2, ammo);
    }
    else
    {
        WriteUInt16(savegameOffset + shotgunAmmoOffset2, 0);
    }
}
```

## Reverse engineering Tomb Raider II savegames
Reversing Tomb Raider II presents more challenges than Tomb Raider I. This is because most of the game's offsets are dynamic. However, weapons are stored in the
same fashion as they are in Tomb Raider I; on a single offset. You can use bitwise to extract which weapons are present in inventory the same way as in Tomb Raider I.
See the table below for weapon byte flags.

| Weapon           | Byte flag        |
|:-----------------|:-----------------|
| Pistols          | 2                |
| Automatic Pistols| 4                |
| Uzis             | 8                |
| Shotgun          | 16               |
| M16              | 32               |
| Grenade Launcher | 64               |
| Harpoon Gun      | 128              |

There are very few static offsets in Tomb Raider II savegames; just level index, save number, and statistics are stored statically. Everything else must
be calculated dynamically. This can be done based on just the level index. See the code below.

```
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
```

Note that the ammunition offsets calculated in that code snippet are just the primary ammo offsets. Secondary ammo offsets must be calculated in a different manner. Not
only are the secondary ammo offsets allocated dynamically based on the level, they are also dynamically allocated throughout a level. In other words, they shift.
In order to calculate the secondary ammo offsets, you need to find the ammo index. The ammo index is correlated with the number of active entities in the game. If there
are 0 entities, the index is 0. If there are 2 entities, the index is 2, and so on.

There is an array consisting of `{0xFF, 0xFF, 0xFF, 0xFF}` that precedes the null padding of the savegame and shifts consistently along with the secondary ammo offsets.
This array's location can be used to calculate both the base secondary ammo offsets, as well as the secondary ammo index itself. While the distance is mostly consistent,
there are some exceptions. Each index corresponds to two possible locations of the 0xFF array. The second location is +0xA bytes away from the first. See the code below.

```
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

        for (int index = 0; index < 25; index++)
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
```

Once the secondary ammo index has been determined, all that remains is to calculate the offsets and write the ammo values. Similar to the Tomb Raider I
implementation, the editor also zeroes the secondary ammo bytes when removing a weapon to free its address space. However, due to the dynamic
nature of the ammo index in Tomb Raider II, it is important to account for edge cases where the ammo index cannot be found. In such cases, the editor
only writes to the primary offset to avoid corrupting the savegame.

```
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
```

## Reverse engineering Tomb Raider III savegames
Similar to Tomb Raider II, most of the offsets in Tomb Raider III are dynamic. The only exceptions are the save number, the level index, and the statistics.
You can calculate most of the remaining offsets based on the level index, just as with Tomb Raider II. See the code below.

```
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
```

Weapons information is also stored on a single offset, the same as with Tomb Raider II. The only exception is the Harpoon Gun, which is stored
on its own offset as a boolean value, +1 byte away from the weapons configuration number. You can use bitwise to extract which weapons are present
in inventory along with the byte flags. See the table below for Tomb Raider III weapon byte flags.

| Weapon           | Byte flag        |
|:-----------------|:-----------------|
| Pistols          | 2                |
| Deagle           | 4                |
| Uzis             | 8                |
| Shotgun          | 16               |
| MP5              | 32               |
| Rocket Launcher  | 64               |
| Grenade Launcher | 128              |

Ammunition is stored in a similar fashion to Tomb Raider II. The logic of a primary offset and secondary offset still apply; unequipped weapons
only store ammo on the primary offset, and equipped weapons store ammo on both offsets. The secondary ammo index also correlates with the number
of active entities, and the index can be determined by the location of the `{0xFF, 0xFF, 0xFF, 0xFF}` array. The ammo index in Tomb Raider III
shifts by a consistent value of 0x1A. See the code below for calculating the secondary ammo index.

```
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

        int[] offsets = new int[indexData.Length];

        for (int index = 0; index < 15; index++)
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
```

Once the secondary ammo index has been determined and the offsets have been calculated, the process of writing to the ammo offsets is the same as in Tomb Raider II.
When removing a weapon, the secondary ammo bytes must be zeroed to free up its address space. If the ammo index cannot be determined, the editor will only write
to the primary offset to avoid corrupting the savegame.

```
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
```

