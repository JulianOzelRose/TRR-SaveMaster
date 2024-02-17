# Tomb Raider I-III Remastered Savegame Editor
This is a savegame editor for Tomb Raider I-III Remastered. It works on all levels and expansions. You can change health, weapons, ammunition and more.
This editor was built to work for PC savegames, but it may work for PS4 savegames as well. For instructions on how to use this editor, scroll down to
the next section below. Additionally, technical details on reverse engineering the Tomb Raider I-III Remastered series are included on later on in this README.

![TRR-SaveMaster-UI](https://github.com/JulianOzelRose/TRR-SaveMaster/assets/95890436/81f76d43-0996-454a-9d2d-105f429a20a9)

## Installation and use
To download this savegame editor, simply navigate to the [Release](https://github.com/JulianOzelRose/TRR-SaveMaster/tree/master/TRR-SaveMaster/bin/x64/Release) folder,
then download `TRR-SaveMaster.exe`. You can save it anywhere on your computer. Once downloaded, run the file. The editor will prompt you to select your savegame path,
click "Yes". Your savegame path should be as follows:

`C:\Users\USERNAME\AppData\Roaming\TRX\77777777777777777\savegame.dat`

Just replace "USERNAME" with your actual username, and "77777777777777777" with whatever numeric ID you see. Presumably this number is some sort of hash of your Steam ID, so if
you have multiple accounts with Tomb Raider I-III Remastered, there may be multiple folders. If you are trying to edit PS4 savegames, the savegame file is `memory.dat`. Because
the savegame is located in a hidden directory, you will have to enable "Show hidden files, folders, or drives" in Windows Explorer.

Once you have selected your savegame path, your savegames should populate in the editor. The editor will remember your savegame directory, so there is no need to re-enter it every time.
Since Tomb Raider I-III Remastered saves and loads savegames for the expansions in the same slots as the originals, this editor does the same. So the "Tomb Raider I" tab will also display
Unfinished Business savegames, the "Tomb Raider II" tab will display The Golden Mask savegames, and the "Tomb Raider III" tab will display The Lost Artifact savegames.

Once the savegames are populated in the editor, you can select them using the combo box labeled "Savegame" in the corner. The editor will automatically refresh savegame
data when switching tabs or selecting savegames -- but if another savegame is added and not displaying, you can click "Refresh" to re-populate the savegames. If you would
like to create a backup of your savegame file before writing to it, you can click "File" then "Create backup", and a file `savegame.dat.bak` will be created in the same
directory as your savegame file. Once you are done making changes, click "Save" to apply changes.

## Reverse engineering Tomb Raider I-III Remastered
This section details the technical aspects of reverse engineering Tomb Raider I-III Remastered. All savegames are stored in a single file; `savegame.dat`.
Savegames for expansions are stored in the same slots as the original game. Each savegame slot for each game begins at a specific offset in the file.
See the table below.

| Game                               | Offset  |
|------------------------------------|---------|
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
