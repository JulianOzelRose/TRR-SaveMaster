# Tomb Raider I-III Remastered Savegame Editor
This is a savegame editor for Tomb Raider I-III Remastered. It works on all levels and expansions. You can change health, weapons, ammunition and more.
Compatible with PC and PS4 savegames. For instructions on how to download and use this savegame editor, scroll down to
the section below. Additionally, technical details on reverse engineering the Tomb Raider I-III Remastered series are included on later on in this README.
For a tool that allows you to transfer individual savegames from one file to another and convert to PC/PS4, check out [TombExtract](https://github.com/JulianOzelRose/TombExtract).

![TRR-SaveMaster-UI](https://github.com/JulianOzelRose/TRR-SaveMaster/assets/95890436/81f76d43-0996-454a-9d2d-105f429a20a9)

## Installation and use
To download this savegame editor, simply navigate to the [Release](https://github.com/JulianOzelRose/TRR-SaveMaster/tree/master/TRR-SaveMaster/bin/x64/Release) folder,
then download `TRR-SaveMaster.exe`. You can save it anywhere on your computer. Once downloaded, run the file. The editor will then prompt you to select your savegame path,
click "Yes". Your savegame path should be as follows:

`C:\Users\USERNAME\AppData\Roaming\TRX\77777777777777777\savegame.dat`

Just replace "USERNAME" with your actual username, and "77777777777777777" with whatever numeric ID you see. Presumably this number is some sort of hash of your Steam ID, so if
you have multiple accounts with Tomb Raider I-III Remastered, there may be multiple folders. Because the savegame file is located in a hidden directory, you will have to enable
"Show hidden files, folders, or drives" in Windows Explorer. If you are trying to edit PS4 savegames, the savegame file is `memory.dat`.

Once you have selected your savegame path, your savegames should populate in the editor. The editor will remember your savegame path, so there is no need to re-enter it every time.
Since Tomb Raider I-III Remastered saves and loads savegames for the expansions in the same slots as the originals, this editor does the same. So the "Tomb Raider I" tab will also display
Unfinished Business savegames, the "Tomb Raider II" tab will display The Golden Mask savegames, and the "Tomb Raider III" tab will display The Lost Artifact savegames.

Once the savegames are populated in the editor, you can select them using the combo box labeled "Savegame" in the corner. The editor will automatically refresh savegame
data when switching tabs or selecting savegames -- but if another savegame is added and not displaying, you can click "Refresh" to re-populate the savegames. If you would
like to create a backup of your savegame file before writing to it, you can click "File" then "Create backup", and a file `savegame.dat.bak` will be created in the same
directory as your savegame file. Once you are done making changes, click "Save" to apply changes. Because the game caches savegames into memory, you must restart your game
for the changes to take effect.

## Reverse engineering Tomb Raider I-III Remastered
This section details the technical aspects of reverse engineering Tomb Raider I-III Remastered. All savegames are stored in a single file; `savegame.dat`.
Savegames for expansions are stored in the same slots as the original game. Each savegame slot for each game begins at a specific offset in the file.
See the table below.

| Game                               | Offset  |
|:-----------------------------------|:--------|
| Tomb Raider I                      | 0x02000 |
| Tomb Raider II                     | 0x72000 |
| Tomb Raider III                    | 0xE2000 |

There is a consistent difference of 0x3800 between each savegame, so that value can be used as an iterator when cycling between savegames. When a savegame slot
is empty, the space will be occupied by null padding. There are a number of ways to check if a savegame is present in the slot. One way is to check if the
level index falls within a valid range, and if the save number is not equal to 0. See the example below.

```
for (int i = 0; i < 32; i++)
{
    currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR1 + (i * SAVEGAME_ITERATOR);
    SetSavegameOffset(currentSavegameOffset);

    UInt16 saveNumber = GetSaveNumber();
    byte levelIndex = GetLevelIndex();

    if (saveNumber != 0 && levelIndex >= 1 && levelIndex <= 19)
    {
        string levelName = levelNames[levelIndex];

        Savegame savegame = new Savegame(currentSavegameOffset, saveNumber, levelName);
        cmbSavegames.Items.Add(savegame);

        numSaves++;
    }
}
```

Because you are dealing with multiple savegames stored in a single file, it is best to use relative offsets and calculate them accordingly. You can find more
details on this for each game in the sections below.

## Tomb Raider I
Because almost all of the offsets in Tomb Raider I are static, it is the most straightforward game to reverse of the series. Weapons inventory configuration
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
level -- so there is no need to recalculate them once the level index is determined. See the table below for Tomb Raider I offsets. Note, they are relative offsets.
So when calculating, you will have to add them to the base savegame offset.

| Offset    | Type    | Description        |
|:----------|:--------|:-------------------|
| 0x00C     | UInt16  | Save Number        |
| 0x4EC     | BYTE    | Weapons            |
| 0x4C2     | UInt16  | Magnum Ammo 1      |
| 0x4C4     | UInt16  | Uzi Ammo 1         |
| 0x4C6     | UInt16  | Shotgun Ammo 1     |
| 0x4C8     | BYTE    | Small Medipack     |
| 0x4C9     | BYTE    | Large Medipack     |
| 0x62C     | BYTE    | Level Index        |

## Tomb Raider II
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

There are only two static offsets in Tomb Raider II savegames; the number of saves is stored on `0x00C`, and the level index is stored on `0x628`. Everything else must
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
only are the secondary ammo offsets allocated dynamically based on the level, they are also dynamically allocated ***throughout*** a level. In other words, they shift.
In order to calculate the secondary ammo offsets, you need to find the ammo index. The ammo index is correlated with the number of active entities in the game. If there
are 0 entities, the index is 0. If there are 2 entities, the index is 2, and so on.

There is an array consisting of `{0xFF, 0xFF, 0xFF, 0xFF}` that shifts consistently along with the secondary ammo offsets. This array's location can be used to calculate
both the base secondary ammo offsets, as well as the secondary ammo index itself. While the distance is mostly consistent, there are some exceptions. Each index corresponds
to two possible locations of the 0xFF array. The second location is +0xA bytes away from the first. See the code below.

```
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
```

## Tomb Raider III
Similar to Tomb Raider II, most of the offsets in Tomb Raider III are dynamic. The only exceptions are the save number on `0x00C` and the
level index on `0x8D6`. You can calculate most of the remaining offsets based on the level index, just as with Tomb Raider II. See the code below.

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
weaponsConfigNumOffset = 0xA0 + (levelIndex * 0x40);
harpoonGunOffset = 0xA1 + (levelIndex * 0x40);
```

Weapons information is also stored on a single offset, the same as with Tomb Raider II. The only exception is the Harpoon Gun, which is stored
as a boolean value, +1 byte away from the weapons configuration number. You can use bitwise to extract which weapons are present
in inventory along with the byte flags. See the table below for Tomb Raider III weapon byte flags.

| Weapon           | Byte flag        |
|------------------|------------------|
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
```
