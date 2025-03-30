using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using static TRR_SaveMaster.TR6Utilities;

namespace TRR_SaveMaster
{
    internal class TR6Utilities
    {
        // Paths
        private string savegamePath = "";

        // Offsets
        private const int SLOT_STATUS_OFFSET = 0x004;
        private const int GAME_MODE_OFFSET = 0x35C;
        private const int LEVEL_INDEX_OFFSET = 0x14;
        private const int SAVE_NUMBER_OFFSET = 0x11C;

        // Savegame constants
        private const int BASE_SAVEGAME_OFFSET_TR6 = 0x293C00;
        private const int MAX_SAVEGAME_OFFSET_TR6 = 0x484910;
        private const int SAVEGAME_SIZE = 0xA470;
        private const int MAX_SAVEGAMES = 32;

        // Compressed block offsets/constants
        private const int COMPRESSED_BLOCK_START_OFFSET = 0x36C;
        private const int COMPRESSED_BLOCK_SIZE_OFFSET = 0x364;
        private const int COMPRESSED_BLOCK_MAX_SIZE = 0xFFFFFF;

        // Entity Mocks
        List<EntityMock> actors = new List<EntityMock>();
        List<EntityMock> objects = new List<EntityMock>();
        List<EntityMock> rooms = new List<EntityMock>();

        // Entity counts
        int NUM_AUDIO_LOCATORS = 0;
        int NUM_EMITTERS = 0;
        int NUM_TRIGGERS = 0;

        // Offsets to save
        private const int CASH_OFFSET = 0x9;
        private int PLAYER_BASE_OFFSET;
        private int PLAYER_HEALTH_OFFSET;
        private int PLAYER_HEALTH_OFFSET_2;

        // Buffer-related
        private int INVENTORY_START_OFFSET;
        private int INVENTORY_END_OFFSET;
        private int POST_INVENTORY_END_OFFSET;

        // Inventories
        List<InventoryItem> invLara = new List<InventoryItem>();
        List<InventoryItem> invKurtis = new List<InventoryItem>();

        // Inventory types
        private const int INVENTORY_TYPE_WEAPON = 3;
        private const int INVENTORY_TYPE_ITEM = 4;
        private const int INVENTORY_TYPE_AMMO = 7;

        // Actor DB
        public class Actor
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsPlayable { get; set; }

            public Actor(int id, string name, bool isPlayable)
            {
                ID = id;
                Name = name;
                IsPlayable = isPlayable;
            }
        }

        // Entity types
        private const int ENTITY_TYPE_ACTOR = 2;
        private const int ENTITY_TYPE_OBJECT = 0;

        // Offset tracking
        int sgBufferCursor = 0;

        // Vars to read
        byte sgCurrentLevel = 0;
        float playerHealth = 0;

        // Buffer
        private byte[] decompressedBuffer = null;

        // Misc
        private int savegameOffset;

        private byte ReadByte(int offset)
        {
            using (FileStream saveFile = new FileStream(savegamePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                saveFile.Seek(offset, SeekOrigin.Begin);
                return (byte)saveFile.ReadByte();
            }
        }

        private Int32 ReadInt32(int offset)
        {
            byte byte1 = ReadByte(offset);
            byte byte2 = ReadByte(offset + 1);
            byte byte3 = ReadByte(offset + 2);
            byte byte4 = ReadByte(offset + 3);

            return (Int32)(byte1 + (byte2 << 8) + (byte3 << 16) + (byte4 << 24));
        }

        private UInt16 ReadUInt16(int offset)
        {
            byte lowerByte = ReadByte(offset);
            byte upperByte = ReadByte(offset + 1);

            return (UInt16)(lowerByte + (upperByte << 8));
        }

        private byte[] ReadBytes(string filePath, long offset, int length)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                fs.Seek(offset, SeekOrigin.Begin);
                return br.ReadBytes(length);
            }
        }

        public bool IsSavegamePresent()
        {
            return ReadByte(savegameOffset + SLOT_STATUS_OFFSET) != 0;
        }

        private byte GetLevelIndex()
        {
            return ReadByte(savegameOffset + LEVEL_INDEX_OFFSET);
        }

        private Int32 GetSaveNumber()
        {
            return ReadInt32(savegameOffset + SAVE_NUMBER_OFFSET);
        }

        private GameMode GetGameMode()
        {
            int gameMode = ReadByte(savegameOffset + GAME_MODE_OFFSET);
            return gameMode == 0 ? GameMode.Normal : GameMode.Plus;
        }

        public void DisplayGameInfo(TrackBar trbHealth, Label lblHealth, Label lblHealthError, NumericUpDown nudCash)
        {
            ParseInventory();

            // Load cash and health directly from buffer
            using (MemoryStream ms = new MemoryStream(decompressedBuffer))
            using (BinaryReader reader = new BinaryReader(ms))
            {
                // Read cash (Int32)
                ms.Seek(CASH_OFFSET, SeekOrigin.Begin);
                Int32 cashValue = reader.ReadInt32();
                nudCash.Value = cashValue;

                // Read health (Float)
                ms.Seek(PLAYER_HEALTH_OFFSET_2, SeekOrigin.Begin);
                playerHealth = reader.ReadSingle();
            }

            if (playerHealth > 0 && playerHealth <= 100)
            {
                trbHealth.Enabled = true;
                lblHealth.Visible = true;
                lblHealthError.Visible = false;
                trbHealth.Value = (int)playerHealth;
                double healthPercentage = ((double)trbHealth.Value / (double)100) * 100;
                lblHealth.Text = $"{healthPercentage}%";
            }
            else
            {
                trbHealth.Value = trbHealth.Minimum;
                trbHealth.Enabled = false;
                lblHealth.Visible = false;
                lblHealthError.Visible = true;
            }
        }

        public void ParseInventory()
        {
            using (MemoryStream ms = new MemoryStream(decompressedBuffer))
            {
                using (BinaryReader reader = new BinaryReader(ms))
                {
                    invLara.Clear();
                    invKurtis.Clear();

                    Console.WriteLine();

                    Int32 itemType;
                    ushort itemClassID;
                    Int32 itemCount;
                    Int32 itemQuantity;

                    int invActive;

                    int characterIndex = 0;

                    // Loop through inventory for Lara and Kent
                    do
                    {
                        invActive = characterIndex;

                        // Read the number of items in the current category
                        reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                        itemCount = reader.ReadByte();
                        sgBufferCursor += 0x1;

                        //Debug.WriteLine($"{(characterIndex == 0 ? "Lara" : "Kurtis")} Inventory Item Count = {itemCount}");

                        // If there are items for this character, process each one
                        if (itemCount != 0)
                        {
                            int currentItemIndex = 0;

                            do
                            {
                                // Read item class ID
                                reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                                itemClassID = reader.ReadUInt16();
                                sgBufferCursor += 0x2;

                                // Read item type
                                reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                                itemType = reader.ReadInt32();
                                sgBufferCursor += 0x4;

                                // Read item quantity
                                reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                                itemQuantity = reader.ReadInt32();
                                sgBufferCursor += 0x4;

                                //Debug.WriteLine($"Item: ClassID=0x{itemClassID:X}, Type={itemType}, Quantity={itemQuantity}, Quantity_Offset=0x{(sgBufferCursor - 4):X}");

                                InventoryItem inventoryItem = new InventoryItem(itemClassID, itemType, itemQuantity);

                                if (characterIndex == 0)
                                {
                                    invLara.Add(inventoryItem);
                                }
                                else
                                {
                                    invKurtis.Add(inventoryItem);
                                }

                                currentItemIndex++;
                            } while (currentItemIndex < itemCount);
                        }

                        characterIndex++;
                    } while (characterIndex < 2);

                    INVENTORY_END_OFFSET = sgBufferCursor;
                    PLAYER_HEALTH_OFFSET_2 = sgBufferCursor;

                    Debug.WriteLine($"INVENTORY_END_OFFSET = 0x{sgBufferCursor:X}");

                    //======================================================//
                    //  Post-inventory data
                    //======================================================//

                    // Starting at the beginning of the block
                    sgBufferCursor += 0x3A;   // pbVar7 = base + 0x3A

                    // Loop 3 times: each iteration should add exactly 1 byte
                    int count = 3;
                    while (count-- > 0)
                    {
                        sgBufferCursor += 0x1;
                    }

                    // Loop 8 times: each iteration adds 4 bytes
                    count = 8;
                    while (count-- > 0)
                    {
                        sgBufferCursor += 0x4;
                    }

                    // Finally, add 5 bytes to match the final pointer assignment:
                    sgBufferCursor += 0x5;

                    POST_INVENTORY_END_OFFSET = sgBufferCursor;
                }
            }
        }

        public void DetermineOffsets(Savegame savegame)
        {
            //Debug.WriteLine($"Savegame offset: 0x{savegame.Offset:X}");

            // Read the compressed block size (UInt16)
            UInt16 compressedBlockSize = ReadUInt16(savegame.Offset + COMPRESSED_BLOCK_SIZE_OFFSET);
            //Debug.WriteLine($"Compressed block size: 0x{compressedBlockSize:X}");

            // Read the compressed block from the savegame file
            byte[] compressedBlockData = ReadBytes(savegamePath, savegame.Offset + COMPRESSED_BLOCK_START_OFFSET, compressedBlockSize);
            decompressedBuffer = new byte[0];   // Clear buffer
            decompressedBuffer = Unpack(compressedBlockData);

            sgBufferCursor = 0x4;    // Skip past "TOMB" signature

            using (MemoryStream ms = new MemoryStream(decompressedBuffer))
            {
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
                    MapPickupLoad(reader);
                }
            }
        }

        private void LoadCachedEntities()
        {
            NUM_AUDIO_LOCATORS = TR6EntityCache.GetNumAudioLocators(sgCurrentLevel);
            NUM_EMITTERS = TR6EntityCache.GetNumEmitters(sgCurrentLevel);
            NUM_TRIGGERS = TR6EntityCache.GetNumTriggers(sgCurrentLevel);

            actors.Clear();
            actors = TR6EntityCache.GetActorArray(sgCurrentLevel);

            rooms.Clear();
            rooms = TR6EntityCache.GetRoomArray(sgCurrentLevel);

            objects.Clear();
            objects = TR6EntityCache.GetObjectArray(sgCurrentLevel);
        }


        private void MapPickupLoad(BinaryReader reader)
        {
            //Debug.WriteLine($"MapPickupLoad Start: 0x{sgBufferCursor:X}");

            if (sgCurrentLevel == 4 || sgCurrentLevel == 5 || sgCurrentLevel == 6 ||
                sgCurrentLevel == 7 || sgCurrentLevel == 8 || sgCurrentLevel == 9 ||
                sgCurrentLevel == 10 || sgCurrentLevel == 0xB || sgCurrentLevel == 0xD ||
                sgCurrentLevel == 0x11 || sgCurrentLevel == 0x1E || sgCurrentLevel == 0x1F ||
                sgCurrentLevel == 0x20 || sgCurrentLevel == 0x21 || sgCurrentLevel == 0x22)
            {
                int numPickupLevels = 0xF;  // 15 levels in TRR6

                for (int level = 0; level < numPickupLevels; level++)
                {
                    // Read the 2-byte pickup count
                    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                    ushort pickupCount = reader.ReadUInt16();
                    sgBufferCursor += 0x2;

                    // For each pickup, advance by 8 bytes
                    sgBufferCursor += pickupCount * 8;

                    // Advance by 0x13 bytes (19 bytes) for the final adjustment.
                    sgBufferCursor += 0x13;
                }
            }

            INVENTORY_START_OFFSET = sgBufferCursor;

            //Debug.WriteLine($"MapPickupLoad End: 0x{sgBufferCursor:X}");
        }

        private void AudioLoad(BinaryReader reader)
        {
            //Debug.WriteLine($"AudioLoad Start: 0x{sgBufferCursor:X}");

            // Revised
            reader.BaseStream.Seek(sgBufferCursor + 0x14, SeekOrigin.Begin);
            //Debug.WriteLine($"AudioLoop counter offset = 0x{(sgBufferCursor + 0x14):X}");
            int loopCount = reader.ReadUInt16();

            // Advance pointer by 6 bytes.
            sgBufferCursor += 0x6;

            // Loop: for each of loopCount iterations, advance by 1.
            if ((uint)(loopCount - 1) < 0x2800)
            {
                //Debug.WriteLine($"AudioLoad: Looping 0x{loopCount:X} times");
                sgBufferCursor += loopCount;
            }

            sgBufferCursor += 0x12;  // Manual correction

            //Debug.WriteLine($"AudioLoad End = 0x{sgBufferCursor:X}");
        }

        private void FxLoad(BinaryReader reader)
        {
            //Debug.WriteLine($"FxLoad Start: 0x{sgBufferCursor:X}");

            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            byte condByte = reader.ReadByte();
            sgBufferCursor += 0x1;

            if (condByte != 0)
            {
                sgBufferCursor += 0x31E;
            }

            sgBufferCursor += 0x8;

            //Debug.WriteLine($"FxLoad End: 0x{sgBufferCursor:X}");
        }

        private void InvLoad(BinaryReader reader)
        {
            //Debug.WriteLine($"InvLoad() was called. Current offset: 0x{sgBufferCursor:X}");

            // Read gGameCash (4 bytes)
            sgBufferCursor += 0x4;

            sgBufferCursor += 0x12B;

            //Debug.WriteLine($"End of InvLoad(). Current offset: 0x{sgBufferCursor:X}");
        }

        private void MapLoad(BinaryReader reader)
        {
            MapLoadGlobals(reader);

            //Debug.WriteLine($"MapLoad offset after loading globals: 0x{sgBufferCursor:X}");

            // Load Actors
            for (int i = 0; i < actors.Count; i++)
            {
                MapActorLoad(reader, actors[i], i);
            }

            //Console.WriteLine();
            //Debug.WriteLine($"Map Offset AFTER loading Actors: 0x{sgBufferCursor:X}");


            //Debug.WriteLine($"{objects.Count} objects for current map.");
            for (int i = 0; i < objects.Count; i++)
            {
                MapObjLoad(reader, objects[i]);
            }

            //Debug.WriteLine($"Map Offset AFTER loading Objects: 0x{sgBufferCursor.ToString("X")}");


            // Load Triggers
            for (int i = 0; i < NUM_TRIGGERS; i++)
            {
                MapTrigLoad(reader);
            }

            //Debug.WriteLine($"Map Offset AFTER loading Triggers: 0x{sgBufferCursor:X}");


            // Load Emitters
            for (int i = 0; i < NUM_EMITTERS; i++)
            {
                MapEmitterLoad(reader);
            }

            //Debug.WriteLine($"Map Offset AFTER loading Emitters: 0x{sgBufferCursor:X}");

            // Load Water
            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            Int16 puVar11 = reader.ReadInt16();
            sgBufferCursor += 0x2;

            //Debug.WriteLine($"Water load condition var = 0x{puVar11:X}");

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

            //Debug.WriteLine($"Map Offset AFTER loading Water: 0x{sgBufferCursor.ToString("X")}");


            // Load Audio Locators
            for (int i = 0; i < NUM_AUDIO_LOCATORS; i++)
            {
                MapLoadBaseNode();
            }

            //Debug.WriteLine($"Map Offset AFTER loading Audio Locators: 0x{sgBufferCursor.ToString("X")}");

            // Flip rooms
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomMeta != 0)
                {
                    sgBufferCursor += 0x4;
                }
            }

            //Debug.WriteLine($"Map Block End = 0x{sgBufferCursor:X}");
            return;
        }

        private void MapLoadBaseNode()
        {
            sgBufferCursor += 0x148;
        }

        private void CamLoad()
        {
            //Debug.WriteLine($"CamLoad start: 0x{sgBufferCursor:X}");

            sgBufferCursor += 0x44;
        }

        private void BossLoad(BinaryReader reader)
        {
            //Debug.WriteLine($"BossLoad start: 0x{sgBufferCursor:X}");

            sgBufferCursor += 0x23C0;

            //Debug.WriteLine($"BossLoad end: 0x{sgBufferCursor:X}");
        }

        private bool ShouldLoadBoss(int actorIndex)
        {
            if (sgCurrentLevel == 28)   // Eckhardt's Lab
            {
                if (actorIndex == 0) return true;
                if (actorIndex == 2) return true;
                if (actorIndex == 6) return true;
                if (actorIndex == 7) return true;
                if (actorIndex == 8) return true;
            }
            if (sgCurrentLevel == 27)   // Boaz Returns
            {
                if (actorIndex == 1) return true;
                if (actorIndex == 2) return true;
            }

            return false;
        }

        private void MapActorLoad(BinaryReader reader, EntityMock actor, int actorIndex)
        {
            // Early exit check using the Active Flag
            if ((actor.ActiveFlag & 0x400000) != 0)
            {
                //Debug.WriteLine($"Active Flag has the 0x400000 bit set (0x{actor.ActiveFlag:X}). Returning early.");
                return;
            }

            bool isPlayer = actor.IsPlayable;

            if (isPlayer)
            {
                PLAYER_BASE_OFFSET = sgBufferCursor;
                //Debug.WriteLine($"Player base: 0x{PLAYER_BASE_OFFSET:X}");
            }

            MapLoadBaseNode();


            // Advance 4 bytes for actor flags (pActor+0x1FC to +0x1FF)
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
                    //Debug.WriteLine($"Offset before running actorLoad: 0x{sgBufferCursor:X}");

                    // Read 12 bytes, extracting the first 2 as a conditional value
                    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                    int offset35CValue = reader.ReadInt16(); // Read first 2 bytes
                    //Debug.WriteLine($"PathLoad condition value: 0x{offset35CValue:X} on offset: 0x{sgBufferCursor:X}");
                    sgBufferCursor += 0x2;


                    sgBufferCursor += 0xA; // Skip remaining 10 bytes (total 12 bytes consumed)

                    // Conditional PathLoad execution
                    if (((ushort)(offset35CValue - 300) < 200) || (sgCurrentLevel == 0x13))
                    {
                        //Debug.WriteLine("Executing PathLoad...");
                        PathLoad(reader);
                    }

                    // Call BoneControlLoad 4 times.
                    BoneControlLoad(reader);
                    BoneControlLoad(reader);
                    BoneControlLoad(reader);
                    BoneControlLoad(reader);
                    //Debug.WriteLine($"Offset after loading BoneControlLoad four times: 0x{sgBufferCursor:X}");

                    // Read NPC health
                    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                    float health = reader.ReadSingle();
                    sgBufferCursor += 0x4;

                    //Debug.WriteLine($"NPC HEALTH: {health} at Offset 0x{(sgBufferCursor - 4):X}");


                    sgBufferCursor += 0x1; // <--- Needed for the APB condition to load properly
                }
                else
                {
                    //Debug.WriteLine($"LOADING BOSS (ID: 0x{actor.ID:X})");
                    BossLoad(reader);
                }
            }

            // Advance 4 bytes (matching assembly’s progression)
            sgBufferCursor += 0x4;

            // Read one byte for APB_Load condition
            //Debug.WriteLine($"Offset for reading APB_Load condition: 0x{sgBufferCursor:X}");
            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            byte pcVar13 = reader.ReadByte();
            sgBufferCursor += 0x1;

            // If pcVar13 is nonzero, call APB_Load
            if (pcVar13 != 0)
            {
                //Debug.WriteLine($"APB_Load being called, offset: 0x{sgBufferCursor:X}");
                APB_Load(reader, actor);

                if ((actor.ActiveFlag & 0x8000000) != 0)
                {
                    sgBufferCursor += 0xC0;
                }
            }
        }

        private void MapObjLoad(BinaryReader reader, EntityMock obj)
        {
            // Start by calling MapLoadBaseNode, which advances the pointer by 328 bytes.
            MapLoadBaseNode();
            //Debug.WriteLine($"Offset after MapLoadBaseNode = 0x{currentOffset:X}");

            long groupStart = sgBufferCursor;  // Store the base position before struct assignments.

            // Read 10 bytes (skipping individual struct assignments for now).
            sgBufferCursor += 0xA;

            // Read condition byte at sgBufferCursor[10] BEFORE advancing sgBufferCursor.
            reader.BaseStream.Seek(groupStart + 0xA, SeekOrigin.Begin);  // Adjust to correct offset.
            byte condByte = reader.ReadByte();

            // Advance the cursor AFTER reading condByte (simulating sgBufferCursor += 1).
            sgBufferCursor += 0x1;

            // If the condition byte is not zero, then execute the APB_Load branch.
            if (condByte != 0)
            {
                //Debug.WriteLine("APB_Load for Object");
                int apbLoopCounter = obj.APB_Loop_Counter;

                APB_Load(reader, null, apbLoopCounter);
            }
        }

        private void MapTrigLoad(BinaryReader reader)
        {
            MapLoadBaseNode();
            sgBufferCursor += 0x4;
            return;
        }

        private void MapEmitterLoad(BinaryReader reader)
        {
            MapLoadBaseNode();
            return;
        }

        private void APB_Load(BinaryReader reader, EntityMock entity, int objApbLoopCounter = 0)
        {
            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            ushort bVar2 = reader.ReadByte();
            sgBufferCursor += 0x1;

            if ((bVar2 & 1) != 0)
            {
                Int32 param_1;

                reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                param_1 = reader.ReadInt32();
                sgBufferCursor += 0x4;

                sgBufferCursor += 0x4;

                sgBufferCursor += 0x10;

                int apbLoopCounter = 0;

                if (entity != null)
                {
                    apbLoopCounter = entity.APB_Loop_Counter;
                }
                else
                {
                    apbLoopCounter = objApbLoopCounter;
                }

                if (apbLoopCounter > 0)
                {
                    int index = 0;

                    do
                    {
                        sgBufferCursor += 0x4;

                        if (entity != null)
                        {
                            sgBufferCursor += 0x4;

                            sgBufferCursor += 0x4;
                        }

                        index++;
                    } while (index < apbLoopCounter);
                }

                APB_LoadAnimationControl(reader, (bVar2 & 2));


                if ((bVar2 & 4) != 0)
                {
                    APB_LoadAnimationControl(reader, (bVar2 & 4));
                }
                if ((bVar2 & 8) != 0)
                {
                    APB_LoadAnimationControl(reader, (bVar2 & 8));
                }

                sgBufferCursor += 0x4;

                sgBufferCursor += 0x4;

                sgBufferCursor += 0x4;

                sgBufferCursor += 0x4;

                sgBufferCursor += 0x4;

                sgBufferCursor += 0x90;

                if ((param_1 & 0x80000) == 0)
                {
                    int secondApbValue = entity != null ? entity.Second_APB_Value : 0;

                    reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                    reader.ReadBytes((secondApbValue * 0x20) / 0x8);
                    sgBufferCursor += ((secondApbValue * 0x20) / 0x8);
                }
                else
                {
                    if (apbLoopCounter > 0) // TODO: Need to evaluate how to handle this case more gracefully...
                    {
                        reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                        reader.ReadBytes((apbLoopCounter * 0x20) / 0x8);
                        sgBufferCursor += ((apbLoopCounter * 0x20) / 0x8);
                    }
                }

                reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
                reader.ReadBytes(32);
                sgBufferCursor += 0x20;
            }

            return;
        }

        private void APB_LoadAnimationControl(BinaryReader reader, int param_2)
        {
            sgBufferCursor += 0x4;

            APB_LoadAnimationInfo(reader);

            if (param_2 != 0)
            {
                APB_LoadAnimationInfo(reader);
            }

            sgBufferCursor += 0xC;

            return;
        }

        private void APB_LoadAnimationInfo(BinaryReader reader)
        {
            sgBufferCursor += 0x24;

            return;
        }

        private void PathLoad(BinaryReader reader)
        {
            // Read first 3 blocks (48 bytes total)
            for (int i = 0; i < 3; i++)
            {
                sgBufferCursor += 0x10;
            }

            // Read three 16-bit values
            sgBufferCursor += 0x2;

            sgBufferCursor += 0x2;

            sgBufferCursor += 0x2;

            // Read the flag at offset 0x3E
            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            short flag3E = reader.ReadInt16();
            sgBufferCursor += 0x2;

            if (flag3E == 1)
            {
                sgBufferCursor += 0x8;
            }

            // Read next 8 bytes block (always)
            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            byte[] eightByteBlock = reader.ReadBytes(8);
            sgBufferCursor += 0x8;

            short offset44Value = BitConverter.ToInt16(eightByteBlock, 0x4); // from puVar3[0x44]
            int varLength = (offset44Value * 0x2) + 0x4;

            reader.BaseStream.Seek(sgBufferCursor, SeekOrigin.Begin);
            byte[] variableData = reader.ReadBytes(varLength);
            sgBufferCursor += varLength;

            Console.WriteLine($"PathLoad End = 0x{sgBufferCursor:X}");
        }


        private void PlayLoad(BinaryReader reader)
        {
            //Debug.WriteLine($"PlayLoad Start = 0x{sgBufferCursor:X}");

            sgBufferCursor += 0x8C;

            sgBufferCursor += (0x17E - 0x8C);  // (382 - 140) = 242 bytes

            // Manual correction
            sgBufferCursor += 0x10D;

            for (int i = 0; i < 5; i++)
            {
                BoneControlLoad(reader);
            }

            //Debug.WriteLine($"PlayLoad End = 0x{sgBufferCursor:X}");
        }

        private void BoneControlLoad(BinaryReader reader)
        {
            sgBufferCursor += 0x4C;
        }

        private void MapLoadGlobals(BinaryReader reader)
        {
            sgBufferCursor += 0x6C;
        }

        private readonly Dictionary<byte, string> levelNames = new Dictionary<byte, string>()
        {
            {  0, "Parisian Back Streets"       },
            {  1, "Derelict Apartment Block"    },
            {  2, "Margot Carvier's Apartment"  },
            {  3, "Industrial Roof Tops"        },
            {  4, "Parisian Ghetto"             },
            {  5, "Parisian Ghetto"             },
            {  6, "Parisian Ghetto"             },
            {  7, "The Serpent Rouge"           },
            {  8, "Rennes' Pawnshop"            },
            {  9, "Willowtree Herbalist"        },
            { 10, "St. Aicard's Church"         },
            { 11, "Café Metro"                  },
            { 12, "St. Aicard's Graveyard"      },
            { 13, "Bouchard's Hideout"          },
            { 14, "Louvre Storm Drains"         },
            { 15, "Louvre Galleries"            },
            { 16, "Galleries Under Siege"       },
            { 17, "Tomb of Ancients"            },
            { 18, "The Archaeological Dig"      },
            { 19, "Von Croy's Apartment"        },
            { 20, "The Monstrum Crimescene"     },
            { 21, "The Strahov Fortress"        },
            { 22, "The Bio-Research Facility"   },
            { 23, "Aquatic Research Area"       },
            { 24, "The Sanitarium"              },
            { 25, "Maximum Containment Area"    },
            { 26, "The Vault of Trophies"       },
            { 27, "Boaz Returns"                },
            { 28, "Eckhardt's Lab"              },
            { 29, "The Lost Domain"             },
            { 30, "The Hall of Seasons"         },
            { 31, "Neptune's Hall"              },
            { 32, "Wrath of the Beast"          },
            { 33, "The Sanctuary of Flame"      },
            { 34, "The Breath of Hades"         }
        };

        public byte[] Unpack(byte[] compressedData)
        {
            // The skip table from DAT_00240d80:
            byte[] offsetTable = new byte[8] { 0x00, 0x3C, 0x18, 0x54, 0x30, 0x0C, 0x48, 0x24 };

            // Constants
            int MAX_BUFFER_SIZE = COMPRESSED_BLOCK_MAX_SIZE;
            int LZW_BUFFER_SIZE = 0x1000;  // 4096 entries
            int[] LZW_BUFFER = new int[LZW_BUFFER_SIZE];
            byte[] output_buffer = new byte[MAX_BUFFER_SIZE];  // Decompressed output buffer
            int output_pos = 0;

            // Check for LZW header
            if (compressedData.Length >= 3 &&
                compressedData[0] == 0x1F &&
                compressedData[1] == 0x9D &&
                compressedData[2] == 0x8C)
            {
                // Setup
                int uVar8 = 3 & 3;    // starting offset after header
                int uVar9 = uVar8 * 8;
                uint uVar7 = 0x100;   // next dictionary index
                uint uVar10 = 0x1FF;  // dictionary mask for 9 bits
                int local_2c = 9;     // starting bit length
                int local_20 = uVar9; // remember offset at last CLEAR

                // Main loop
                while (uVar9 <= ((compressedData.Length - 3 + uVar8) * 8 - 9))
                {
                    // Increase code size if dictionary is about full
                    if (uVar10 < uVar7 && local_2c < 12)
                    {
                        local_2c += 1;
                        uVar10 = (uVar10 * 2) + 1;
                    }

                    // Record new dictionary code's output offset
                    if (uVar7 < 0x1000)
                    {
                        LZW_BUFFER[(int)(uVar7 - 256)] = output_pos;
                    }

                    // Extract bits from compressedBlockData
                    int shift_amt = uVar9 & 0x1F;
                    int byte_offset = (uVar9 >> 5) * 4 + (3 - uVar8);

                    if (byte_offset + 4 > compressedData.Length)
                    {
                        Debug.WriteLine($"Byte offset 0x{byte_offset:X} is out of bounds!");
                        break;
                    }

                    uint uVar3 = BitConverter.ToUInt32(compressedData, byte_offset);

                    if (shift_amt != 0)
                    {
                        int sVar4 = shift_amt;
                        int next_offset = byte_offset + 4;
                        if (next_offset + 4 > compressedData.Length)
                        {
                            Debug.WriteLine($"Next offset 0x{next_offset:X} is out of bounds!");
                            break;
                        }
                        uVar3 = (uVar3 >> sVar4)
                            | (BitConverter.ToUInt32(compressedData, next_offset)
                               << ((32 - sVar4) & 0x1F));
                    }

                    uVar3 &= uVar10;
                    uVar9 += local_2c;

                    // Handle LZW codes
                    if (uVar3 == 0x100)
                    {
                        // CLEAR code
                        local_2c = 9;
                        // Use the actual table skip:
                        int bitsSinceLastClear = uVar9 - local_20;
                        int index = (bitsSinceLastClear >> 2) & 7;     // (uVar11 - uVar13) >> 2 & 7
                        byte skip = offsetTable[index];
                        uVar9 += skip; // add the table-based offset

                        // Reset dictionary
                        uVar7 = 0x100;
                        uVar10 = 0x1FF;
                        local_20 = uVar9;
                    }
                    else if (uVar3 < 0x100)
                    {
                        // Direct literal byte
                        if (output_pos >= output_buffer.Length)
                        {
                            Console.WriteLine("Output position exceeds buffer size!");
                            break;
                        }
                        output_buffer[output_pos++] = (byte)uVar3;
                        uVar7++;
                    }
                    else
                    {
                        // Dictionary-based copy
                        int idx1 = (int)(uVar3 - 257);
                        int idx2 = (int)(uVar3 - 256);

                        if (idx1 >= LZW_BUFFER.Length || idx2 >= LZW_BUFFER.Length)
                        {
                            Console.WriteLine("LZW buffer index out of bounds!");
                            break;
                        }
                        int puVar1 = LZW_BUFFER[idx1];
                        int puVar2 = LZW_BUFFER[idx2];

                        if (puVar1 >= output_buffer.Length || puVar2 >= output_buffer.Length)
                        {
                            Console.WriteLine($"Invalid access to output buffer: puVar1={puVar1}, puVar2={puVar2}");
                            break;
                        }
                        if (output_pos >= output_buffer.Length)
                        {
                            Console.WriteLine("Output position exceeds buffer size!");
                            break;
                        }

                        // Copy the first byte
                        output_buffer[output_pos++] = output_buffer[puVar1++];

                        // Copy the rest
                        while (puVar1 <= puVar2)
                        {
                            if (output_pos >= output_buffer.Length)
                            {
                                Console.WriteLine("Output position exceeds buffer size!");
                                break;
                            }
                            output_buffer[output_pos++] = output_buffer[puVar1++];
                        }
                        uVar7++;
                    }
                }

                // Return decompressed data
                byte[] result = new byte[output_pos];
                Array.Copy(output_buffer, result, output_pos);
                return result;
            }
            else
            {
                Console.WriteLine("Invalid header in compressed data");
                return null;
            }
        }

        public byte[] Pack(byte[] rawData)
        {
            const int MAX_BITS = 12;
            const int INIT_BITS = 9;
            const uint MAX_CODE = (1U << MAX_BITS) - 1;
            const uint CLEAR_CODE = 0x100;
            const uint FIRST_CODE = 0x101;
            const int HASH_SIZE = 0x1400;

            // Write the 3-byte header.
            List<byte> destBuffer = new List<byte> { 0x1F, 0x9D, 0x8C };

            // Bit-packing state.
            ulong bitBuffer = 0;
            int bitCount = 0;
            // Start after the header: 3 bytes = 24 bits.
            int bitTotal = 24;

            // Dictionary.
            uint[] dictionary = new uint[HASH_SIZE];
            int codeWidth = INIT_BITS;
            uint maxCode = (1U << codeWidth) - 1;
            uint nextCode = FIRST_CODE;

            // Keep track of the bit offset at the beginning of the current dictionary block.
            int blockBase = bitTotal;

            if (rawData.Length == 0)
                return destBuffer.ToArray();

            uint currentCode = rawData[0];
            int inputPos = 1;

            // Clear code table
            byte[] clearTable = new byte[8] { 0x00, 0x3C, 0x18, 0x54, 0x30, 0x0C, 0x48, 0x24 };

            void WriteBits(uint code, int width)
            {
                bitBuffer |= ((ulong)code << bitCount);
                bitCount += width;
                bitTotal += width;
                while (bitCount >= 8)
                {
                    byte outByte = (byte)(bitBuffer & 0xFF);
                    destBuffer.Add(outByte);

                    bitBuffer >>= 8;
                    bitCount -= 8;
                }
            }

            void FlushBits()
            {
                if (bitCount > 0)
                {
                    byte finalByte = (byte)(bitBuffer & 0xFF);
                    destBuffer.Add(finalByte);
                    bitBuffer = 0;
                    bitCount = 0;
                }
            }

            // Main Compression Loop.
            while (inputPos < rawData.Length)
            {
                byte nextChar = rawData[inputPos++];
                uint combinedCode = (currentCode << 8) | nextChar;
                uint hashIndex = ((uint)nextChar << 4) ^ currentCode;
                hashIndex %= HASH_SIZE;

                bool found = false;
                uint step = (hashIndex == 0) ? 1u : (0x13FFu - hashIndex);

                while (dictionary[hashIndex] != 0)
                {
                    int entry = unchecked((int)dictionary[hashIndex]);
                    int adjusted = entry + ((entry >> 31) & 0xFFF);
                    if ((adjusted >> 12) == (int)combinedCode)
                    {
                        currentCode = (uint)(entry & 0xFFF);
                        found = true;
                        break;
                    }

                    // Apply probe arithmetic
                    int tempIndex = (int)hashIndex - (int)step;
                    if (tempIndex < 0)
                        tempIndex += 0x13FF; // wraparound
                    hashIndex = (uint)tempIndex;
                }

                if (!found)
                {
                    WriteBits(currentCode, codeWidth);

                    if (nextCode > maxCode && codeWidth < MAX_BITS)
                    {
                        codeWidth++;
                        maxCode = (1U << codeWidth) - 1;
                    }

                    if (nextCode <= MAX_CODE)
                    {
                        dictionary[hashIndex] = (combinedCode << 12) | nextCode;
                        nextCode++;
                    }
                    else
                    {
                        // Dictionary full: emit CLEAR code and then flush extra bits based on the clear table.
                        WriteBits(CLEAR_CODE, codeWidth);
                        // Compute how many bits have been output since the start of this dictionary block.
                        int bitsSince = bitTotal - blockBase;
                        int index = (bitsSince >> 2) & 7;
                        int extraBits = clearTable[index]; // extra bits to flush
                        WriteBits(0, extraBits);
                        // Reset dictionary and LZW state.
                        dictionary = new uint[HASH_SIZE];
                        codeWidth = INIT_BITS;
                        maxCode = (1U << codeWidth) - 1;
                        nextCode = FIRST_CODE;
                        // Reset blockBase to the current bit total.
                        blockBase = bitTotal;
                    }

                    currentCode = nextChar;
                }
            }

            // Final write.
            WriteBits(currentCode, codeWidth);
            FlushBits();

            return destBuffer.ToArray();
        }

        public void UpdateInventoryFromUI(ComboBox cmbInventory, NumericUpDown nudChocolateBar, NumericUpDown nudHealthPills,
            CheckBox chkMV9, CheckBox chkVPacker, NumericUpDown nudMV9Ammo, NumericUpDown nudVPackerAmmo,
            CheckBox chkBoranX, NumericUpDown nudBoranXAmmo, NumericUpDown nudSmallMedipack,
            NumericUpDown nudHealthBandages, CheckBox chkK2Impactor, NumericUpDown nudK2ImpactorAmmo,
            NumericUpDown nudLargeHealthPack, CheckBox chkScorpionX, NumericUpDown nudScorpionXAmmo,
            CheckBox chkVectorR35, NumericUpDown nudVectorR35Ammo, CheckBox chkDesertRanger,
            NumericUpDown nudDesertRangerAmmo, CheckBox chkDartSS, NumericUpDown nudDartSSAmmo,
            CheckBox chkRigg09, NumericUpDown nudRigg09Ammo, CheckBox chkViperSMG, NumericUpDown nudViperSMGAmmo,
            CheckBox chkMagVega, NumericUpDown nudMagVegaAmmo, CheckBox chkVectorR35Pair, CheckBox chkScorpionXPair,
            NumericUpDown nudPoisonAntidote, CheckBox chkChirugaiBlade)
        {
            // Determine whose inventory to update
            List<InventoryItem> selectedInventory = cmbInventory.SelectedIndex == 1 ? invKurtis : invLara;

            // Weapons (checkboxes)
            UpdateWeapon(selectedInventory, Inventory.MV9, chkMV9.Checked);
            UpdateWeapon(selectedInventory, Inventory.VPACKER, chkVPacker.Checked);
            UpdateWeapon(selectedInventory, Inventory.BORAN_X, chkBoranX.Checked);
            UpdateWeapon(selectedInventory, Inventory.K2_IMPACTOR, chkK2Impactor.Checked);
            UpdateWeapon(selectedInventory, Inventory.SCORPION_X, chkScorpionX.Checked);
            UpdateWeapon(selectedInventory, Inventory.VECTOR_R35, chkVectorR35.Checked);
            UpdateWeapon(selectedInventory, Inventory.DESERT_RANGER, chkDesertRanger.Checked);
            UpdateWeapon(selectedInventory, Inventory.DART_SS, chkDartSS.Checked);
            UpdateWeapon(selectedInventory, Inventory.RIGG_09, chkRigg09.Checked);
            UpdateWeapon(selectedInventory, Inventory.VIPER_SMG, chkViperSMG.Checked);
            UpdateWeapon(selectedInventory, Inventory.MAG_VEGA, chkMagVega.Checked);
            UpdateWeapon(selectedInventory, Inventory.SCORPION_X_PAIR, chkScorpionXPair.Checked);
            UpdateWeapon(selectedInventory, Inventory.VECTOR_R35_PAIR, chkVectorR35Pair.Checked);
            UpdateWeapon(selectedInventory, Inventory.CHIRUGAI_BLADE, chkChirugaiBlade.Checked);

            // Items (quantifiable, can be removed when 0)
            UpdateItem(selectedInventory, Inventory.CHOCOLATE_BAR, (Int32)nudChocolateBar.Value);
            UpdateItem(selectedInventory, Inventory.SMALL_MEDIPACK, (Int32)nudSmallMedipack.Value);
            UpdateItem(selectedInventory, Inventory.HEALTH_BANDAGES, (Int32)nudHealthBandages.Value);
            UpdateItem(selectedInventory, Inventory.HEALTH_PILLS, (Int32)nudHealthPills.Value);
            UpdateItem(selectedInventory, Inventory.LARGE_HEALTH_PACK, (Int32)nudLargeHealthPack.Value);
            UpdateItem(selectedInventory, Inventory.POISON_ANTIDOTE, (Int32)nudPoisonAntidote.Value);

            // Ammo (separate handling)
            UpdateAmmo(selectedInventory, Inventory.MV9_AMMO, (Int32)nudMV9Ammo.Value);
            UpdateAmmo(selectedInventory, Inventory.VPACKER_AMMO, (Int32)nudVPackerAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.BORAN_X_AMMO, (Int32)nudBoranXAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.K2_IMPACTOR_AMMO, (Int32)nudK2ImpactorAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.SCORPION_X_AMMO, (Int32)nudScorpionXAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.VECTOR_R35_AMMO, (Int32)nudVectorR35Ammo.Value);
            UpdateAmmo(selectedInventory, Inventory.DESERT_RANGER_AMMO, (Int32)nudDesertRangerAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.DART_SS_AMMO, (Int32)nudDartSSAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.RIGG_09_AMMO, (Int32)nudRigg09Ammo.Value);
            UpdateAmmo(selectedInventory, Inventory.VIPER_SMG_AMMO, (Int32)nudViperSMGAmmo.Value);
            UpdateAmmo(selectedInventory, Inventory.MAG_VEGA_AMMO, (Int32)nudMagVegaAmmo.Value);
        }

        private void UpdateWeapon(List<InventoryItem> inventory, ushort classId, bool isChecked)
        {
            int index = inventory.FindIndex(i => i.ClassId == classId);

            if (isChecked)
            {
                if (index == -1) // Weapon does not exist, add it
                {
                    inventory.Add(new InventoryItem(classId, INVENTORY_TYPE_WEAPON, 1));
                }
            }
            else
            {
                if (index != -1) // Weapon exists, remove it
                {
                    inventory.RemoveAt(index);
                }
            }
        }

        private void UpdateItem(List<InventoryItem> inventory, ushort classId, int quantity)
        {
            // Find existing item
            int index = inventory.FindIndex(i => i.ClassId == classId);

            if (quantity > 0)
            {
                if (index != -1)
                {
                    inventory[index] = new InventoryItem(classId, INVENTORY_TYPE_ITEM, quantity); // Update existing item
                }
                else
                {
                    inventory.Add(new InventoryItem(classId, INVENTORY_TYPE_ITEM, quantity)); // Add new item
                }
            }
            else
            {
                if (index != -1)
                {
                    inventory.RemoveAt(index); // Remove if quantity is 0
                }
            }
        }

        private void UpdateAmmo(List<InventoryItem> inventory, ushort classId, int quantity)
        {
            // Find existing ammo item
            int index = inventory.FindIndex(i => i.ClassId == classId);

            if (quantity > 0)
            {
                if (index != -1)
                {
                    inventory[index] = new InventoryItem(classId, INVENTORY_TYPE_AMMO, quantity); // Update existing ammo
                }
                else
                {
                    inventory.Add(new InventoryItem(classId, INVENTORY_TYPE_AMMO, quantity)); // Add new ammo
                }
            }
            else
            {
                if (index != -1)
                {
                    inventory.RemoveAt(index); // Remove if quantity is 0
                }
            }
        }

        public void UpdateInventoryUI(ComboBox cmbInventory, NumericUpDown nudChocolateBar, NumericUpDown nudHealthPills,
            CheckBox chkMV9, CheckBox chkVPacker, NumericUpDown nudMV9Ammo, NumericUpDown nudVPackerAmmo,
            CheckBox chkBoranX, NumericUpDown nudBoranXAmmo, NumericUpDown nudSmallMedipack,
            NumericUpDown nudHealthBandages, CheckBox chkK2Impactor, NumericUpDown nudK2ImpactorAmmo,
            NumericUpDown nudLargeHealthPack, CheckBox chkScorpionX, NumericUpDown nudScorpionXAmmo,
            CheckBox chkVectorR35, NumericUpDown nudVectorR35Ammo, CheckBox chkDesertRanger,
            NumericUpDown nudDesertRangerAmmo, CheckBox chkDartSS, NumericUpDown nudDartSSAmmo,
            CheckBox chkRigg09, NumericUpDown nudRigg09Ammo, CheckBox chkViperSMG, NumericUpDown nudViperSMGAmmo,
            CheckBox chkMagVega, NumericUpDown nudMagVegaAmmo, CheckBox chkVectorR35Pair, CheckBox chkScorpionXPair,
            NumericUpDown nudPoisonAntidote, CheckBox chkChirugaiBlade)
        {
            // Determine whose inventory to update
            List<InventoryItem> selectedInventory = cmbInventory.SelectedIndex == 1 ? invKurtis : invLara;

            // Copy list to safely iterate without modifying it
            List<InventoryItem> inventoryCopy = selectedInventory.ToList();

            // Reset UI fields
            nudChocolateBar.Value = 0;
            nudSmallMedipack.Value = 0;
            nudHealthBandages.Value = 0;
            nudLargeHealthPack.Value = 0;
            nudHealthPills.Value = 0;
            nudPoisonAntidote.Value = 0;
            chkMV9.Checked = false;
            chkVPacker.Checked = false;
            nudMV9Ammo.Value = 0;
            nudVPackerAmmo.Value = 0;
            chkBoranX.Checked = false;
            nudBoranXAmmo.Value = 0;
            chkK2Impactor.Checked = false;
            nudK2ImpactorAmmo.Value = 0;
            chkScorpionX.Checked = false;
            chkScorpionXPair.Checked = false;
            nudScorpionXAmmo.Value = 0;
            chkVectorR35.Checked = false;
            chkVectorR35Pair.Checked = false;
            nudVectorR35Ammo.Value = 0;
            chkDesertRanger.Checked = false;
            nudDesertRangerAmmo.Value = 0;
            chkDartSS.Checked = false;
            nudDartSSAmmo.Value = 0;
            chkRigg09.Checked = false;
            nudRigg09Ammo.Value = 0;
            chkViperSMG.Checked = false;
            nudViperSMGAmmo.Value = 0;
            chkMagVega.Checked = false;
            nudMagVegaAmmo.Value = 0;
            chkChirugaiBlade.Checked = false;

            // Conditionally enable weapons
            chkMV9.Enabled = cmbInventory.SelectedIndex == 0;
            nudMV9Ammo.Enabled = cmbInventory.SelectedIndex == 0;
            chkVPacker.Enabled = cmbInventory.SelectedIndex == 0;
            nudVPackerAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            chkScorpionX.Enabled = cmbInventory.SelectedIndex == 0;
            chkScorpionXPair.Enabled = cmbInventory.SelectedIndex == 0;
            nudScorpionXAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            chkK2Impactor.Enabled = cmbInventory.SelectedIndex == 0;
            nudK2ImpactorAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            chkVectorR35.Enabled = cmbInventory.SelectedIndex == 0;
            chkVectorR35Pair.Enabled = cmbInventory.SelectedIndex == 0;
            nudVectorR35Ammo.Enabled = cmbInventory.SelectedIndex == 0;
            chkDesertRanger.Enabled = cmbInventory.SelectedIndex == 0;
            nudDesertRangerAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            chkMagVega.Enabled = cmbInventory.SelectedIndex == 0;
            nudMagVegaAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            chkDartSS.Enabled = cmbInventory.SelectedIndex == 0;
            nudDartSSAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            chkRigg09.Enabled = cmbInventory.SelectedIndex == 0;
            nudRigg09Ammo.Enabled = cmbInventory.SelectedIndex == 0;
            chkViperSMG.Enabled = cmbInventory.SelectedIndex == 0;
            nudViperSMGAmmo.Enabled = cmbInventory.SelectedIndex == 0;
            nudBoranXAmmo.Enabled = cmbInventory.SelectedIndex == 1;
            chkBoranX.Enabled = cmbInventory.SelectedIndex == 1;
            chkChirugaiBlade.Enabled = cmbInventory.SelectedIndex == 1;

            // Update UI based on inventory contents
            foreach (var item in inventoryCopy)
            {
                switch (item.ClassId)
                {
                    case Inventory.CHOCOLATE_BAR:
                        nudChocolateBar.Value = item.Quantity;
                        break;
                    case Inventory.SMALL_MEDIPACK:
                        nudSmallMedipack.Value = item.Quantity;
                        break;
                    case Inventory.HEALTH_BANDAGES:
                        nudHealthBandages.Value = item.Quantity;
                        break;
                    case Inventory.HEALTH_PILLS:
                        nudHealthPills.Value = item.Quantity;
                        break;
                    case Inventory.LARGE_HEALTH_PACK:
                        nudLargeHealthPack.Value = item.Quantity;
                        break;
                    case Inventory.MV9:
                        chkMV9.Checked = true;
                        break;
                    case Inventory.MV9_AMMO:
                        nudMV9Ammo.Value = item.Quantity;
                        break;
                    case Inventory.VPACKER:
                        chkVPacker.Checked = true;
                        break;
                    case Inventory.VPACKER_AMMO:
                        nudVPackerAmmo.Value = item.Quantity;
                        break;
                    case Inventory.BORAN_X:
                        chkBoranX.Checked = true;
                        break;
                    case Inventory.K2_IMPACTOR:
                        chkK2Impactor.Checked = true;
                        break;
                    case Inventory.K2_IMPACTOR_AMMO:
                        nudK2ImpactorAmmo.Value = item.Quantity;
                        break;
                    case Inventory.BORAN_X_AMMO:
                        nudBoranXAmmo.Value = item.Quantity;
                        break;
                    case Inventory.SCORPION_X:
                        chkScorpionX.Checked = true;
                        break;
                    case Inventory.SCORPION_X_AMMO:
                        nudScorpionXAmmo.Value = item.Quantity;
                        break;
                    case Inventory.VECTOR_R35:
                        chkVectorR35.Checked = true;
                        break;
                    case Inventory.VECTOR_R35_AMMO:
                        nudVectorR35Ammo.Value = item.Quantity;
                        break;
                    case Inventory.DESERT_RANGER:
                        chkDesertRanger.Checked = true;
                        break;
                    case Inventory.DESERT_RANGER_AMMO:
                        nudDesertRangerAmmo.Value = item.Quantity;
                        break;
                    case Inventory.DART_SS:
                        chkDartSS.Checked = true;
                        break;
                    case Inventory.DART_SS_AMMO:
                        nudDartSSAmmo.Value = item.Quantity;
                        break;
                    case Inventory.RIGG_09:
                        chkRigg09.Checked = true;
                        break;
                    case Inventory.RIGG_09_AMMO:
                        nudRigg09Ammo.Value = item.Quantity;
                        break;
                    case Inventory.VIPER_SMG:
                        chkViperSMG.Checked = true;
                        break;
                    case Inventory.VIPER_SMG_AMMO:
                        nudViperSMGAmmo.Value = item.Quantity;
                        break;
                    case Inventory.MAG_VEGA:
                        chkMagVega.Checked = true;
                        break;
                    case Inventory.MAG_VEGA_AMMO:
                        nudMagVegaAmmo.Value = item.Quantity;
                        break;
                    case Inventory.SCORPION_X_PAIR:
                        chkScorpionXPair.Checked = true;
                        break;
                    case Inventory.VECTOR_R35_PAIR:
                        chkVectorR35Pair.Checked = true;
                        break;
                    case Inventory.CHIRUGAI_BLADE:
                        chkChirugaiBlade.Checked = true;
                        break;
                    case Inventory.POISON_ANTIDOTE:
                        nudPoisonAntidote.Value = item.Quantity;
                        break;
                }
            }

            //Debug.WriteLine($"Inventory UI Updated for {(cmbInventory.SelectedIndex == 1 ? "Kurtis" : "Lara")}.");
        }

        public void WriteChanges(NumericUpDown nudCash, TrackBar trbHealth)
        {
            if (decompressedBuffer == null || decompressedBuffer.Length == 0)
            {
                string errorMessage = $"Savegame buffer is null or empty.";
                throw new Exception(errorMessage);
            }

            try
            {
                // Extract the post-inventory block BEFORE modifying offsets
                //Debug.WriteLine($"Extracting Post-Inventory Block: 0x{INVENTORY_END_OFFSET:X} - 0x{POST_INVENTORY_END_OFFSET:X}");

                if (POST_INVENTORY_END_OFFSET > decompressedBuffer.Length)
                {
                    Debug.WriteLine($"Warning: POST_INVENTORY_END_OFFSET ({POST_INVENTORY_END_OFFSET:X}) exceeds buffer size ({decompressedBuffer.Length:X}). Clamping...");
                    POST_INVENTORY_END_OFFSET = decompressedBuffer.Length;
                }

                byte[] postInventoryBlock = decompressedBuffer
                    .Skip(INVENTORY_END_OFFSET)
                    .Take(POST_INVENTORY_END_OFFSET - INVENTORY_END_OFFSET)
                    .ToArray();

                // Modify the pre-inventory block (cash & health)
                byte[] preInventoryBlock = decompressedBuffer
                    .Take(INVENTORY_START_OFFSET)
                    .ToArray();

                using (MemoryStream ms = new MemoryStream(preInventoryBlock))
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
                    // Write cash value (Int32)
                    ms.Seek(CASH_OFFSET, SeekOrigin.Begin);
                    writer.Write((int)nudCash.Value);

                    // Write first health value (Float)
                    ms.Seek(PLAYER_HEALTH_OFFSET, SeekOrigin.Begin);
                    writer.Write((float)trbHealth.Value);

                    //Debug.WriteLine($"Writing Health: {healthValue} (Raw Bytes: {BitConverter.ToString(healthBytes)})");
                }

                // Construct the new inventory block
                byte[] newInventoryBlock;
                using (MemoryStream inventoryStream = new MemoryStream())
                using (BinaryWriter invWriter = new BinaryWriter(inventoryStream))
                {
                    // Write Lara's inventory
                    invWriter.Write((byte)invLara.Count); // Item count
                    foreach (var item in invLara)
                    {
                        invWriter.Write((ushort)item.ClassId);
                        invWriter.Write((int)item.Type);
                        invWriter.Write((int)item.Quantity);
                    }

                    // Write Kurtis' inventory
                    invWriter.Write((byte)invKurtis.Count); // Item count
                    foreach (var item in invKurtis)
                    {
                        invWriter.Write((ushort)item.ClassId);
                        invWriter.Write((int)item.Type);
                        invWriter.Write((int)item.Quantity);
                    }

                    newInventoryBlock = inventoryStream.ToArray();
                }

                // Modify post-inventory block (second health value)
                using (MemoryStream ms = new MemoryStream(postInventoryBlock))
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
                    writer.Seek(0, SeekOrigin.Begin); // First byte
                    writer.Write((float)trbHealth.Value);
                }

                //Debug.WriteLine($"New Inventory Block Size: 0x{newInventoryBlock.Length:X}");

                // Update Offsets AFTER New Inventory Block is Created
                int originalInventorySize = INVENTORY_END_OFFSET - INVENTORY_START_OFFSET;
                int newInventorySize = newInventoryBlock.Length;
                int inventorySizeDelta = newInventorySize - originalInventorySize;

                INVENTORY_END_OFFSET += inventorySizeDelta;
                POST_INVENTORY_END_OFFSET += inventorySizeDelta;
                PLAYER_HEALTH_OFFSET_2 += inventorySizeDelta;

                //Debug.WriteLine($"Updated INVENTORY_END_OFFSET: 0x{INVENTORY_END_OFFSET:X}");
                //Debug.WriteLine($"Updated POST_INVENTORY_END_OFFSET: 0x{POST_INVENTORY_END_OFFSET:X}");

                // Merge the three parts back together
                byte[] modifiedBuffer = preInventoryBlock
                    .Concat(newInventoryBlock)
                    .Concat(postInventoryBlock)
                    .ToArray();

                //Debug.WriteLine($"Modified Buffer Size: 0x{modifiedBuffer.Length:X}");

                // Compress the modified buffer
                byte[] compressedBuffer = Pack(modifiedBuffer);
                int compressedBufferSize = compressedBuffer.Length;

                // Write the compressed data to the savegame file
                using (FileStream fs = new FileStream(savegamePath, FileMode.Open, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    // Write compressed block size
                    fs.Seek(savegameOffset + COMPRESSED_BLOCK_SIZE_OFFSET, SeekOrigin.Begin);
                    writer.Write(compressedBufferSize);

                    Debug.WriteLine($"Wrote compressed buffer size: 0x{compressedBufferSize:X} at offset 0x{savegameOffset + COMPRESSED_BLOCK_SIZE_OFFSET:X}");

                    // Write the compressed buffer to the savegame
                    fs.Seek(savegameOffset + COMPRESSED_BLOCK_START_OFFSET, SeekOrigin.Begin);
                    writer.Write(compressedBuffer);

                    //Debug.WriteLine($"Wrote compressed buffer data at offset 0x{(savegameOffset + COMPRESSED_BLOCK_START_OFFSET):X}, size 0x{compressedBufferSize:X} bytes.");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error while writing to buffer: {ex.Message}.";
                throw new Exception(errorMessage);
            }
        }

        public void SetSavegameOffset(int offset)
        {
            savegameOffset = offset;
        }

        public void SetSavegamePath(string path)
        {
            savegamePath = path;
        }

        public int GetPlayerBaseOffset()
        {
            return PLAYER_BASE_OFFSET;
        }

        public void UpdateDisplayName(Savegame savegame)
        {
            bool savegamePresent = ReadByte(savegame.Offset + SLOT_STATUS_OFFSET) != 0;

            if (savegamePresent)
            {
                byte levelIndex = ReadByte(savegame.Offset + LEVEL_INDEX_OFFSET);
                Int32 saveNumber = ReadInt32(savegame.Offset + SAVE_NUMBER_OFFSET);

                if (levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    GameMode gameMode = ReadByte(savegame.Offset + GAME_MODE_OFFSET) == 0 ? GameMode.Normal : GameMode.Plus;

                    savegame.UpdateDisplayName(levelName, saveNumber, gameMode);
                }
            }
        }

        public void PopulateEmptySlots(ComboBox cmbSavegames)
        {
            if (cmbSavegames.Items.Count == MAX_SAVEGAMES)
            {
                return;
            }

            for (int i = cmbSavegames.Items.Count; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR6 + (i * SAVEGAME_SIZE);

                if (currentSavegameOffset < MAX_SAVEGAME_OFFSET_TR6)
                {
                    Int32 saveNumber = ReadInt32(currentSavegameOffset + SAVE_NUMBER_OFFSET);
                    byte levelIndex = ReadByte(currentSavegameOffset + LEVEL_INDEX_OFFSET);
                    bool savegamePresent = ReadByte(currentSavegameOffset + SLOT_STATUS_OFFSET) != 0;

                    if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                    {
                        int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR6) / SAVEGAME_SIZE;

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
                            GameMode gameMode = ReadByte(currentSavegameOffset + GAME_MODE_OFFSET) == 0 ? GameMode.Normal : GameMode.Plus;

                            Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, true);
                            cmbSavegames.Items.Add(savegame);
                        }
                    }
                }
            }
        }

        public void PopulateSavegames(ComboBox cmbSavegames)
        {
            int numSaves = 0;

            for (int i = 0; i < MAX_SAVEGAMES; i++)
            {
                int currentSavegameOffset = BASE_SAVEGAME_OFFSET_TR6 + (i * SAVEGAME_SIZE);
                SetSavegameOffset(currentSavegameOffset);

                Int32 saveNumber = GetSaveNumber();
                byte levelIndex = GetLevelIndex();
                bool savegamePresent = IsSavegamePresent();

                if (savegamePresent && levelNames.ContainsKey(levelIndex) && saveNumber >= 0)
                {
                    string levelName = levelNames[levelIndex];
                    int slot = (currentSavegameOffset - BASE_SAVEGAME_OFFSET_TR6) / SAVEGAME_SIZE;
                    GameMode gameMode = GetGameMode();

                    Savegame savegame = new Savegame(currentSavegameOffset, slot, saveNumber, levelName, gameMode, true);
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
