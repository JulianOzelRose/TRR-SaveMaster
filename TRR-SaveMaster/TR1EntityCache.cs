using System.Collections.Generic;

namespace TRR_SaveMaster
{
    public class TR1EntityCache
    {
        public static readonly Dictionary<int, int> BaseLevelItemCounts = new Dictionary<int, int>()
        {
            { 1,  60  },    // Caves
            { 2,  95  },    // City of Vilcabamba
            { 3,  64  },    // Lost Valley
            { 4,  77  },    // Tomb of Qualopec
            { 5,  114 },    // St. Francis' Folly
            { 6,  92  },    // Colosseum
            { 7,  136 },    // Palace Midas
            { 8,  121 },    // The Cistern
            { 9,  96  },    // Tomb of Tihocan
            { 10, 94  },    // City of Khamoon
            { 11, 104 },    // Obelisk of Khamoon
            { 12, 74  },    // Sanctuary of the Scion
            { 13, 104 },    // Natla's Mines
            { 14, 210 },    // Atlantis
            { 15, 130 },    // The Great Pyramid
            { 16, 210 },    // Return to Egypt
            { 17, 199 },    // Temple of the Cat
            { 18, 178 },    // Atlantean Stronghold
            { 19, 199 },    // The Hive
        };

        public static readonly Dictionary<int, int> LevelStateEntryCounts = new Dictionary<int, int>()
        {
            { 1,  2  },     // Caves
            { 2,  6  },     // City of Vilcabamba
            { 3,  6  },     // Lost Valley
            { 4,  10 },     // Tomb of Qualopec
            { 5,  14 },     // St. Francis' Folly
            { 6,  10 },     // Colosseum
            { 7,  7  },     // Palace Midas
            { 8,  7  },     // The Cistern
            { 9,  15 },     // Tomb of Tihocan
            { 10, 3  },     // City of Khamoon
            { 11, 8  },     // Obelisk of Khamoon
            { 12, 12 },     // Sanctuary of the Scion
            { 13, 15 },     // Natla's Mines
            { 14, 6  },     // Atlantis
            { 15, 2  },     // The Great Pyramid
            { 16, 15 },     // Return to Egypt
            { 17, 30 },     // Temple of the Cat
            { 18, 24 },     // Atlantean Stronghold
            { 19, 14 },     // The Hive
        };

        public static readonly Dictionary<int, Dictionary<byte, int>> ChallengeModeItemCountModifiersByLevel = new Dictionary<int, Dictionary<byte, int>>()
        {
            {
                1, new Dictionary<byte, int>()      // Caves
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 5  },  // Reinforcement
                    { 5, 9  },  // Crowded
                    { 6, 18 },  // All Hands on Deck
                }
            },
            {
                2, new Dictionary<byte, int>()      // City of Vilcabamba
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 5  },  // Reinforcement
                    { 5, 10 },  // Crowded
                    { 6, 20 },  // All Hands on Deck
                }
            },
            {
                3, new Dictionary<byte, int>()      // Lost Valley
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 4  },  // Reinforcement
                    { 5, 8  },  // Crowded
                    { 6, 15 },  // All Hands on Deck
                }
            },
            {
                4, new Dictionary<byte, int>()      // Tomb of Qualopec
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 4  },  // Reinforcement
                    { 5, 8  },  // Crowded
                    { 6, 16 },  // All Hands on Deck
                }
            },
            {
                5, new Dictionary<byte, int>()      // St. Francis' Folly
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 5  },  // Reinforcement
                    { 5, 9  },  // Crowded
                    { 6, 18 },  // All Hands on Deck
                }
            },
            {
                6, new Dictionary<byte, int>()      // Colosseum
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 4  },  // Reinforcement
                    { 5, 9  },  // Crowded
                    { 6, 17 },  // All Hands on Deck
                }
            },
            {
                7, new Dictionary<byte, int>()      // Palace Midas
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 4  },  // Reinforcement
                    { 5, 8  },  // Crowded
                    { 6, 15 },  // All Hands on Deck
                }
            },
            {
                8, new Dictionary<byte, int>()      // The Cistern
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 7  },  // Reinforcement
                    { 5, 14 },  // Crowded
                    { 6, 28 },  // All Hands on Deck
                }
            },
            {
                9, new Dictionary<byte, int>()      // Tomb of Tihocan
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 5  },  // Reinforcement
                    { 5, 10 },  // Crowded
                    { 6, 20 },  // All Hands on Deck
                }
            },
            {
                10, new Dictionary<byte, int>()      // City of Khamoon
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 4  },  // Reinforcement
                    { 5, 9  },  // Crowded
                    { 6, 17 },  // All Hands on Deck
                }
            },
            {
                11, new Dictionary<byte, int>()      // Obelisk of Khamoon
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 4  },  // Reinforcement
                    { 5, 9  },  // Crowded
                    { 6, 17 },  // All Hands on Deck
                }
            },
            {
                12, new Dictionary<byte, int>()      // Sanctuary of the Scion
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 8  },  // Reinforcement
                    { 5, 16 },  // Crowded
                    { 6, 32 },  // All Hands on Deck
                }
            },
            {
                13, new Dictionary<byte, int>()      // Natla's Mines
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 0  },  // Reinforcement
                    { 5, 0  },  // Crowded
                    { 6, 0  },  // All Hands on Deck
                }
            },
            {
                14, new Dictionary<byte, int>()      // Atlantis
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 8  },  // Reinforcement
                    { 5, 15 },  // Crowded
                    { 6, 30 },  // All Hands on Deck
                }
            },
            {
                15, new Dictionary<byte, int>()      // The Great Pyramid
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 3  },  // Reinforcement
                    { 5, 5  },  // Crowded
                    { 6, 10 },  // All Hands on Deck
                }
            },
            {
                16, new Dictionary<byte, int>()      // The Great Pyramid
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 13 },  // Reinforcement
                    { 5, 26 },  // Crowded
                    { 6, 52 },  // All Hands on Deck
                }
            },
            {
                17, new Dictionary<byte, int>()      // Temple of the Cat
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 8  },  // Reinforcement
                    { 5, 16 },  // Crowded
                    { 6, 31 },  // All Hands on Deck
                }
            },
            {
                18, new Dictionary<byte, int>()      // Atlantean Stronghold
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 6  },  // Reinforcement
                    { 5, 12 },  // Crowded
                    { 6, 24 },  // All Hands on Deck
                }
            },
            {
                19, new Dictionary<byte, int>()      // The Hive
                {
                    { 0, 0  },  // Ghost Town
                    { 1, 0  },  // Scarcity
                    { 2, 0  },  // Understaffed
                    { 3, 0  },  // Normal
                    { 4, 6  },  // Reinforcement
                    { 5, 12 },  // Crowded
                    { 6, 23 },  // All Hands on Deck
                }
            },
        };

        public static readonly Dictionary<int, List<int>> LevelObjectIdsByLevel = new Dictionary<int, List<int>>
        {
            {
                1, new List<int>	// Caves
                {
                    0x0000,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x00A9,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x003C,
                    0x0037,
                    0x0009,
                    0x0039,
                    0x003A,
                    0x0046,
                    0x0045,
                    0x0044,
                    0x0044,
                    0x0045,
                    0x0046,
                    0x0046,
                    0x0045,
                    0x0044,
                    0x0045,
                    0x0044,
                    0x0046,
                    0x0007,
                    0x0007,
                    0x003B,
                    0x005D,
                    0x0008,
                    0x0009,
                    0x0009,
                    0x0053,
                    0x005D,
                    0x0039,
                    0x003A,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x00A9,
                    0x0037,
                    0x003A,
                    0x0039,
                    0x0007,
                    0x0007,
                    0x005D,
                    0x005D,
                    0x0009,
                    0x0023,
                    0x0023,
                    0x0037,
                    0x0007,
                    0x005E,
                    0x0028,
                    0x0028,
                    0x0007,
                    0x005D,
                    0x005E,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x000F,
                    0x0008,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x000F,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x000F,
                    0x000F
                }
            },
            {
                2, new List<int>	// City of Vilcabamba
                {
                    0x0030,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x005E,
                    0x0053,
                    0x0007,
                    0x005D,
                    0x003A,
                    0x0089,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0007,
                    0x0007,
                    0x003A,
                    0x0037,
                    0x0007,
                    0x0007,
                    0x006E,
                    0x0081,
                    0x0007,
                    0x003A,
                    0x0023,
                    0x0023,
                    0x0009,
                    0x0009,
                    0x0041,
                    0x0037,
                    0x005D,
                    0x0038,
                    0x0038,
                    0x003C,
                    0x005D,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x005E,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x005D,
                    0x003A,
                    0x003A,
                    0x0009,
                    0x0059,
                    0x0037,
                    0x005D,
                    0x0009,
                    0x0024,
                    0x0024,
                    0x0024,
                    0x003B,
                    0x0037,
                    0x0041,
                    0x0041,
                    0x00A9,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0037,
                    0x0053,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0039,
                    0x0076,
                    0x003B,
                    0x00A9,
                    0x0008,
                    0x0037,
                    0x0037,
                    0x0009,
                    0x0008,
                    0x005A,
                    0x005D,
                    0x005B,
                    0x003D,
                    0x003E,
                    0x003D,
                    0x0000,
                    0x003E,
                    0x0007,
                    0x0007,
                    0x0008,
                    0x0010,
                    0x0008,
                    0x000B,
                    0x0007,
                    0x000F,
                    0x0009,
                    0x0010,
                    0x0010,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000B,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007
                }
            },
            {
                3, new List<int>	// Lost Valley
                {
                    0x0000,
                    0x003E,
                    0x0045,
                    0x0045,
                    0x004A,
                    0x004B,
                    0x004C,
                    0x0076,
                    0x0076,
                    0x0076,
                    0x0037,
                    0x0044,
                    0x0055,
                    0x0053,
                    0x005E,
                    0x00AA,
                    0x00AA,
                    0x00AA,
                    0x0059,
                    0x0059,
                    0x005D,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x00AA,
                    0x0007,
                    0x005E,
                    0x00AA,
                    0x00AA,
                    0x0059,
                    0x0013,
                    0x006E,
                    0x0013,
                    0x00AA,
                    0x00AA,
                    0x00AA,
                    0x00AA,
                    0x0053,
                    0x006E,
                    0x0039,
                    0x0013,
                    0x0013,
                    0x0045,
                    0x0045,
                    0x0046,
                    0x0045,
                    0x0044,
                    0x0044,
                    0x00AA,
                    0x0046,
                    0x0053,
                    0x006E,
                    0x00AA,
                    0x0012,
                    0x0013,
                    0x0013,
                    0x005A,
                    0x005E,
                    0x005B,
                    0x0059,
                    0x005A,
                    0x0059,
                    0x000B,
                    0x0013,
                    0x0013,
                    0x0013,
                    0x0007,
                    0x000F,
                    0x0013,
                    0x000F,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0012
                }
            },
            {
                4, new List<int>	// Tomb of Qualopec
                {
                    0x003E,
                    0x0023,
                    0x0025,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x005A,
                    0x008F,
                    0x003C,
                    0x0018,
                    0x0018,
                    0x0035,
                    0x0035,
                    0x0035,
                    0x005A,
                    0x005E,
                    0x0055,
                    0x001B,
                    0x005E,
                    0x0040,
                    0x0053,
                    0x0000,
                    0x0013,
                    0x0037,
                    0x003D,
                    0x0035,
                    0x0035,
                    0x003A,
                    0x0039,
                    0x003B,
                    0x00A9,
                    0x0053,
                    0x0026,
                    0x0013,
                    0x0013,
                    0x0053,
                    0x0034,
                    0x0034,
                    0x00A9,
                    0x00A9,
                    0x0037,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0023,
                    0x0007,
                    0x0007,
                    0x0007,
                    0x005D,
                    0x0030,
                    0x0037,
                    0x005D,
                    0x0037,
                    0x0030,
                    0x0030,
                    0x0035,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x003D,
                    0x0037,
                    0x003D,
                    0x0037,
                    0x0007,
                    0x0007,
                    0x0013,
                    0x000F,
                    0x0013,
                    0x000F,
                    0x0013,
                    0x0016,
                    0x0016,
                    0x0007,
                    0x0007,
                    0x0008,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0013
                }
            },
            {
                5, new List<int>	// St. Francis' Folly
                {
                    0x0030,
                    0x0039,
                    0x000C,
                    0x001C,
                    0x000D,
                    0x005E,
                    0x0039,
                    0x0037,
                    0x0039,
                    0x0037,
                    0x005A,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0053,
                    0x0039,
                    0x005D,
                    0x0055,
                    0x0037,
                    0x0030,
                    0x0030,
                    0x005D,
                    0x0055,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0053,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x002B,
                    0x0037,
                    0x0009,
                    0x0037,
                    0x0039,
                    0x005D,
                    0x0009,
                    0x0009,
                    0x0053,
                    0x0039,
                    0x005E,
                    0x0009,
                    0x0009,
                    0x0053,
                    0x002E,
                    0x002C,
                    0x003C,
                    0x0081,
                    0x0037,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x0039,
                    0x0083,
                    0x005D,
                    0x0059,
                    0x000B,
                    0x002F,
                    0x002F,
                    0x002F,
                    0x002F,
                    0x0037,
                    0x0089,
                    0x008A,
                    0x008B,
                    0x008C,
                    0x000D,
                    0x000D,
                    0x003F,
                    0x001C,
                    0x0053,
                    0x0084,
                    0x003B,
                    0x003B,
                    0x0082,
                    0x0026,
                    0x005D,
                    0x003A,
                    0x000F,
                    0x0023,
                    0x005E,
                    0x0059,
                    0x0038,
                    0x0026,
                    0x003E,
                    0x003D,
                    0x0000,
                    0x005A,
                    0x005E,
                    0x000F,
                    0x000F,
                    0x000D,
                    0x000D,
                    0x000F,
                    0x000F,
                    0x000C,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x0009,
                    0x000B,
                    0x0010,
                    0x0010,
                    0x000F,
                    0x0056,
                    0x0090,
                    0x0081,
                    0x002D,
                    0x0056,
                    0x0090,
                    0x0081
                }
            },
            {
                6, new List<int>	// Colosseum
                {
                    0x0053,
                    0x000C,
                    0x000B,
                    0x003A,
                    0x000C,
                    0x000C,
                    0x005E,
                    0x005D,
                    0x00A9,
                    0x003E,
                    0x000F,
                    0x0030,
                    0x0037,
                    0x000C,
                    0x003D,
                    0x000F,
                    0x0059,
                    0x000D,
                    0x005D,
                    0x003D,
                    0x0037,
                    0x003D,
                    0x000F,
                    0x0089,
                    0x0053,
                    0x0037,
                    0x0037,
                    0x003D,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0053,
                    0x000B,
                    0x003D,
                    0x0037,
                    0x0037,
                    0x00A9,
                    0x0037,
                    0x003F,
                    0x0026,
                    0x0037,
                    0x0037,
                    0x0056,
                    0x005E,
                    0x005E,
                    0x005B,
                    0x0039,
                    0x0040,
                    0x0037,
                    0x0081,
                    0x0030,
                    0x005D,
                    0x005D,
                    0x0053,
                    0x003A,
                    0x0000,
                    0x0040,
                    0x003F,
                    0x003F,
                    0x0059,
                    0x000C,
                    0x000D,
                    0x000D,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000C,
                    0x000D,
                    0x000C,
                    0x00A9,
                    0x003D,
                    0x0040,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000C,
                    0x001C,
                    0x0040,
                    0x0009,
                    0x0009,
                    0x001C,
                    0x000A,
                    0x000A,
                    0x005D,
                    0x0059,
                    0x000C,
                    0x000E,
                    0x000F,
                    0x000C,
                    0x000D,
                    0x0008,
                    0x000E,
                    0x000E,
                    0x000C,
                    0x0010,
                    0x0010,
                    0x000F,
                    0x0016,
                    0x0009,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0056,
                    0x0090,
                    0x0081,
                    0x0056,
                    0x0090,
                    0x0081
                }
            },
            {
                7, new List<int>	// Palace Midas
                {
                    0x0000,
                    0x00A9,
                    0x002A,
                    0x002A,
                    0x0025,
                    0x0023,
                    0x005D,
                    0x0059,
                    0x0056,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x005E,
                    0x003E,
                    0x000C,
                    0x000C,
                    0x0009,
                    0x0009,
                    0x007E,
                    0x0053,
                    0x003D,
                    0x00A9,
                    0x000C,
                    0x000B,
                    0x000A,
                    0x003E,
                    0x0076,
                    0x0076,
                    0x0076,
                    0x0011,
                    0x0011,
                    0x00B3,
                    0x00B3,
                    0x00B3,
                    0x0053,
                    0x0011,
                    0x007E,
                    0x00B3,
                    0x00B3,
                    0x0053,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x007E,
                    0x000F,
                    0x003A,
                    0x003B,
                    0x003C,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x005D,
                    0x000F,
                    0x005D,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x005E,
                    0x003D,
                    0x000F,
                    0x005D,
                    0x005A,
                    0x0039,
                    0x0059,
                    0x0053,
                    0x0053,
                    0x0037,
                    0x0030,
                    0x000C,
                    0x000C,
                    0x000F,
                    0x005A,
                    0x005A,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x000F,
                    0x005E,
                    0x000B,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x000F,
                    0x000C,
                    0x005B,
                    0x0059,
                    0x005D,
                    0x0053,
                    0x000B,
                    0x005A,
                    0x005D,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x005E,
                    0x0031,
                    0x003F,
                    0x000F,
                    0x000F,
                    0x0037,
                    0x003F,
                    0x005E,
                    0x0080,
                    0x0053,
                    0x0037,
                    0x0053,
                    0x000E,
                    0x000F,
                    0x000F,
                    0x0008,
                    0x000E,
                    0x000C,
                    0x000A,
                    0x0013,
                    0x0013,
                    0x0010,
                    0x0010,
                    0x000E,
                    0x000C,
                    0x000C,
                    0x000C
                }
            },
            {
                8, new List<int>	// The Cistern
                {
                    0x000B,
                    0x000B,
                    0x005E,
                    0x0059,
                    0x005D,
                    0x0037,
                    0x0039,
                    0x0030,
                    0x0010,
                    0x0041,
                    0x0041,
                    0x0037,
                    0x001C,
                    0x0011,
                    0x0011,
                    0x0039,
                    0x0039,
                    0x008A,
                    0x008A,
                    0x0053,
                    0x0089,
                    0x000F,
                    0x0053,
                    0x0011,
                    0x0083,
                    0x003B,
                    0x008B,
                    0x000F,
                    0x000F,
                    0x001C,
                    0x0010,
                    0x0010,
                    0x0056,
                    0x005E,
                    0x0039,
                    0x0037,
                    0x000A,
                    0x000A,
                    0x0053,
                    0x000A,
                    0x005E,
                    0x0010,
                    0x0025,
                    0x0010,
                    0x0010,
                    0x003B,
                    0x0082,
                    0x00A9,
                    0x0010,
                    0x001C,
                    0x0010,
                    0x0037,
                    0x0038,
                    0x00A9,
                    0x005D,
                    0x0055,
                    0x005E,
                    0x0010,
                    0x0010,
                    0x0053,
                    0x003B,
                    0x0082,
                    0x003B,
                    0x008B,
                    0x0025,
                    0x000B,
                    0x005D,
                    0x0081,
                    0x0037,
                    0x0030,
                    0x003A,
                    0x000D,
                    0x000D,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0025,
                    0x0025,
                    0x005D,
                    0x005A,
                    0x005A,
                    0x005E,
                    0x0010,
                    0x0010,
                    0x0039,
                    0x000C,
                    0x000C,
                    0x000C,
                    0x0037,
                    0x0025,
                    0x005E,
                    0x005A,
                    0x005A,
                    0x005A,
                    0x0031,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0083,
                    0x0010,
                    0x0059,
                    0x0053,
                    0x003B,
                    0x0010,
                    0x003B,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x005E,
                    0x0000,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x000A,
                    0x000A,
                    0x000E,
                    0x000C,
                    0x000D,
                    0x000B,
                    0x0010,
                    0x0007,
                    0x0011,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x000F,
                    0x0056,
                    0x0090,
                    0x0081,
                    0x0056,
                    0x0090,
                    0x0081,
                    0x0056,
                    0x0090,
                    0x0081
                }
            },
            {
                9, new List<int>	// Tomb of Tihocan
                {
                    0x005E,
                    0x0059,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x005A,
                    0x005B,
                    0x0059,
                    0x005E,
                    0x0081,
                    0x0039,
                    0x0028,
                    0x0028,
                    0x0000,
                    0x0037,
                    0x0038,
                    0x000A,
                    0x003B,
                    0x0037,
                    0x005D,
                    0x0030,
                    0x0010,
                    0x000A,
                    0x003D,
                    0x0059,
                    0x0059,
                    0x005A,
                    0x0024,
                    0x0053,
                    0x001C,
                    0x002A,
                    0x0037,
                    0x0010,
                    0x0038,
                    0x000F,
                    0x000F,
                    0x0025,
                    0x0025,
                    0x000D,
                    0x0037,
                    0x0053,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x005D,
                    0x0089,
                    0x005D,
                    0x0030,
                    0x0039,
                    0x0039,
                    0x0039,
                    0x0039,
                    0x0039,
                    0x0039,
                    0x008B,
                    0x008B,
                    0x005D,
                    0x0026,
                    0x0026,
                    0x0083,
                    0x005E,
                    0x002A,
                    0x0083,
                    0x000B,
                    0x000F,
                    0x0059,
                    0x000F,
                    0x0059,
                    0x005A,
                    0x0053,
                    0x00A1,
                    0x00A1,
                    0x0037,
                    0x0053,
                    0x003B,
                    0x00A9,
                    0x0037,
                    0x0053,
                    0x003C,
                    0x001C,
                    0x003A,
                    0x005A,
                    0x005A,
                    0x005E,
                    0x0089,
                    0x0010,
                    0x000A,
                    0x0008,
                    0x000F,
                    0x000F,
                    0x000B,
                    0x0010,
                    0x000B,
                    0x0011,
                    0x0016,
                    0x0016,
                    0x0007,
                    0x0007,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0056,
                    0x0090,
                    0x0081,
                    0x0017,
                    0x0017,
                    0x0056,
                    0x0090,
                    0x0081
                }
            },
            {
                10, new List<int>	// City of Khamoon
                {
                    0x0000,
                    0x0030,
                    0x003A,
                    0x005A,
                    0x005A,
                    0x000E,
                    0x005D,
                    0x0056,
                    0x000B,
                    0x0030,
                    0x005D,
                    0x005A,
                    0x0030,
                    0x0089,
                    0x0076,
                    0x0077,
                    0x0078,
                    0x0079,
                    0x003C,
                    0x003D,
                    0x0016,
                    0x0059,
                    0x0081,
                    0x0059,
                    0x0053,
                    0x0037,
                    0x005A,
                    0x0037,
                    0x0030,
                    0x0053,
                    0x0030,
                    0x0037,
                    0x0037,
                    0x0041,
                    0x0041,
                    0x0037,
                    0x000E,
                    0x005E,
                    0x0081,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0016,
                    0x003A,
                    0x0038,
                    0x0053,
                    0x005E,
                    0x005A,
                    0x00A9,
                    0x005D,
                    0x005B,
                    0x005A,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x00A9,
                    0x000A,
                    0x000A,
                    0x005A,
                    0x0026,
                    0x000E,
                    0x000E,
                    0x005E,
                    0x0039,
                    0x000E,
                    0x005D,
                    0x0039,
                    0x0039,
                    0x003B,
                    0x0089,
                    0x0037,
                    0x005A,
                    0x0025,
                    0x0041,
                    0x0045,
                    0x0045,
                    0x0044,
                    0x005A,
                    0x0059,
                    0x0053,
                    0x000E,
                    0x000E,
                    0x003A,
                    0x003A,
                    0x000E,
                    0x000E,
                    0x005D,
                    0x0016,
                    0x0009,
                    0x000E,
                    0x0016,
                    0x000E,
                    0x000E,
                    0x0009,
                    0x000B,
                    0x000C,
                    0x000E,
                    0x000F,
                    0x000F,
                    0x000D,
                    0x000C,
                    0x000D,
                    0x000B,
                    0x0009,
                    0x0009
                }
            },
            {
                11, new List<int>	// Obelisk of Khamoon
                {
                    0x003D,
                    0x003E,
                    0x0030,
                    0x0089,
                    0x0076,
                    0x0077,
                    0x0078,
                    0x0079,
                    0x003E,
                    0x003D,
                    0x0059,
                    0x00A9,
                    0x0037,
                    0x0037,
                    0x005E,
                    0x006E,
                    0x006F,
                    0x0070,
                    0x0071,
                    0x0029,
                    0x0029,
                    0x0029,
                    0x0029,
                    0x0039,
                    0x0000,
                    0x0039,
                    0x0039,
                    0x0039,
                    0x0037,
                    0x0053,
                    0x0059,
                    0x0053,
                    0x003A,
                    0x0089,
                    0x0037,
                    0x0037,
                    0x0059,
                    0x0037,
                    0x0030,
                    0x0030,
                    0x0030,
                    0x0030,
                    0x00A9,
                    0x0039,
                    0x0037,
                    0x0037,
                    0x005D,
                    0x0016,
                    0x0053,
                    0x005D,
                    0x0056,
                    0x005A,
                    0x005B,
                    0x005D,
                    0x005B,
                    0x005E,
                    0x005B,
                    0x0016,
                    0x0053,
                    0x005A,
                    0x000E,
                    0x0037,
                    0x005E,
                    0x000E,
                    0x000E,
                    0x0016,
                    0x0016,
                    0x005A,
                    0x003A,
                    0x0037,
                    0x0016,
                    0x005A,
                    0x005A,
                    0x0016,
                    0x0053,
                    0x0039,
                    0x0053,
                    0x005D,
                    0x005A,
                    0x0059,
                    0x005A,
                    0x0059,
                    0x005D,
                    0x005E,
                    0x0016,
                    0x000E,
                    0x005D,
                    0x000E,
                    0x0081,
                    0x000B,
                    0x005A,
                    0x005D,
                    0x0053,
                    0x0037,
                    0x000E,
                    0x005D,
                    0x003A,
                    0x005A,
                    0x0059,
                    0x005E,
                    0x005A,
                    0x0016,
                    0x0016,
                    0x0089,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x000D,
                    0x000C,
                    0x000E,
                    0x0016,
                    0x000B,
                    0x000E,
                    0x0016,
                    0x0010,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000B,
                    0x000B,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009
                }
            },
            {
                12, new List<int>	// Sanctuary of the Scion
                {
                    0x003B,
                    0x003B,
                    0x0015,
                    0x005A,
                    0x005A,
                    0x0015,
                    0x0016,
                    0x0016,
                    0x005A,
                    0x0076,
                    0x0057,
                    0x0076,
                    0x005B,
                    0x0053,
                    0x0039,
                    0x0039,
                    0x0038,
                    0x0037,
                    0x0059,
                    0x005B,
                    0x005A,
                    0x0037,
                    0x005A,
                    0x0053,
                    0x0014,
                    0x0059,
                    0x0059,
                    0x0039,
                    0x005E,
                    0x0053,
                    0x0037,
                    0x002A,
                    0x0014,
                    0x005E,
                    0x0014,
                    0x0014,
                    0x005D,
                    0x0053,
                    0x006E,
                    0x0017,
                    0x005D,
                    0x0081,
                    0x0014,
                    0x0053,
                    0x005E,
                    0x005A,
                    0x005A,
                    0x005A,
                    0x0089,
                    0x0039,
                    0x006E,
                    0x0017,
                    0x005D,
                    0x0053,
                    0x006F,
                    0x0053,
                    0x003C,
                    0x003C,
                    0x003D,
                    0x003E,
                    0x0077,
                    0x005A,
                    0x0056,
                    0x0016,
                    0x0016,
                    0x0017,
                    0x005A,
                    0x005E,
                    0x0030,
                    0x003E,
                    0x003D,
                    0x0000,
                    0x001B,
                    0x008F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0016,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000E,
                    0x000E,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000B,
                    0x000B,
                    0x000B,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000E,
                    0x0010,
                    0x0010,
                    0x000D,
                    0x000C,
                    0x0010,
                    0x0010
                }
            },
            {
                13, new List<int>	// Natla's Mines
                {
                    0x00A9,
                    0x0053,
                    0x00B6,
                    0x00AA,
                    0x0031,
                    0x0037,
                    0x0030,
                    0x0030,
                    0x005A,
                    0x0039,
                    0x0037,
                    0x0030,
                    0x002F,
                    0x0037,
                    0x005B,
                    0x0039,
                    0x006E,
                    0x001F,
                    0x0053,
                    0x0039,
                    0x005D,
                    0x00B1,
                    0x00B1,
                    0x00B1,
                    0x0037,
                    0x005A,
                    0x0076,
                    0x0076,
                    0x0076,
                    0x005A,
                    0x0053,
                    0x0023,
                    0x0031,
                    0x0026,
                    0x00B1,
                    0x0026,
                    0x006E,
                    0x0053,
                    0x0026,
                    0x0026,
                    0x0037,
                    0x0037,
                    0x006E,
                    0x0039,
                    0x00B1,
                    0x00B1,
                    0x0031,
                    0x0032,
                    0x0053,
                    0x0026,
                    0x001E,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x0053,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0037,
                    0x0033,
                    0x0033,
                    0x003A,
                    0x0033,
                    0x003A,
                    0x0053,
                    0x0037,
                    0x005B,
                    0x005E,
                    0x003A,
                    0x003A,
                    0x006F,
                    0x0037,
                    0x003B,
                    0x003C,
                    0x0020,
                    0x0077,
                    0x0033,
                    0x0000,
                    0x0037,
                    0x005B,
                    0x00A9,
                    0x0054,
                    0x00A9,
                    0x00A2,
                    0x005E,
                    0x0026,
                    0x005B,
                    0x005E,
                    0x0055,
                    0x005E,
                    0x005B,
                    0x0039,
                    0x0039,
                    0x005E,
                    0x005B,
                    0x0042,
                    0x0037,
                    0x005D,
                    0x005B,
                    0x005E,
                    0x0056,
                    0x0057,
                    0x0055
                }
            },
            {
                14, new List<int>	// Atlantis
                {
                    0x0014,
                    0x0014,
                    0x005B,
                    0x005B,
                    0x002A,
                    0x005B,
                    0x005B,
                    0x002A,
                    0x0014,
                    0x0014,
                    0x005B,
                    0x005B,
                    0x00B1,
                    0x00B1,
                    0x00B1,
                    0x0037,
                    0x0037,
                    0x003F,
                    0x003F,
                    0x0059,
                    0x005D,
                    0x003F,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x003F,
                    0x005B,
                    0x0037,
                    0x003C,
                    0x0042,
                    0x0016,
                    0x0016,
                    0x0037,
                    0x003F,
                    0x0057,
                    0x0000,
                    0x003E,
                    0x005B,
                    0x005B,
                    0x00A3,
                    0x00B1,
                    0x0037,
                    0x0053,
                    0x003F,
                    0x0037,
                    0x0026,
                    0x0026,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x003E,
                    0x005E,
                    0x0038,
                    0x0037,
                    0x005B,
                    0x005B,
                    0x0025,
                    0x0053,
                    0x003F,
                    0x0038,
                    0x0059,
                    0x003E,
                    0x0037,
                    0x0030,
                    0x005B,
                    0x005B,
                    0x003E,
                    0x0053,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x00A3,
                    0x00A3,
                    0x005E,
                    0x0059,
                    0x005B,
                    0x005B,
                    0x0014,
                    0x0037,
                    0x002A,
                    0x003F,
                    0x0030,
                    0x00A3,
                    0x00B1,
                    0x00B1,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x003F,
                    0x005B,
                    0x0030,
                    0x0030,
                    0x0030,
                    0x003F,
                    0x0026,
                    0x0042,
                    0x0042,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0053,
                    0x00B5,
                    0x0093,
                    0x0092,
                    0x005B,
                    0x005B,
                    0x0037,
                    0x0037,
                    0x0017,
                    0x005B,
                    0x005B,
                    0x003C,
                    0x0041,
                    0x0041,
                    0x0015,
                    0x00B1,
                    0x005B,
                    0x003D,
                    0x0040,
                    0x0006,
                    0x0026,
                    0x003B,
                    0x003B,
                    0x003E,
                    0x00B4,
                    0x003E,
                    0x0037,
                    0x003E,
                    0x003C,
                    0x0037,
                    0x00A3,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x0053,
                    0x003E,
                    0x00A3,
                    0x00A3,
                    0x005D,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x0053,
                    0x003E,
                    0x003E,
                    0x003E,
                    0x0026,
                    0x005B,
                    0x00A9,
                    0x005B,
                    0x0025,
                    0x0015,
                    0x0015,
                    0x005D,
                    0x005B,
                    0x0053,
                    0x0037,
                    0x0037,
                    0x0015,
                    0x0015,
                    0x0015,
                    0x0040,
                    0x002A,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0015,
                    0x005E,
                    0x005E,
                    0x005E,
                    0x005B,
                    0x005A,
                    0x005E,
                    0x005B,
                    0x005A,
                    0x0059,
                    0x005B,
                    0x005E,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000B,
                    0x000B,
                    0x000B,
                    0x0013,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x0014,
                    0x0015,
                    0x0014,
                    0x0015,
                    0x0015,
                    0x0014,
                    0x0016,
                    0x0014,
                    0x0014,
                    0x0014,
                    0x0014,
                    0x0014,
                    0x0017,
                    0x0014,
                    0x0016,
                    0x0015,
                    0x0015,
                    0x0014,
                    0x0014
                }
            },
            {
                15, new List<int>	// The Great Pyramid
                {
                    0x002A,
                    0x002A,
                    0x0023,
                    0x0053,
                    0x0030,
                    0x0030,
                    0x002A,
                    0x0037,
                    0x0039,
                    0x0030,
                    0x00B1,
                    0x00B1,
                    0x00B1,
                    0x0041,
                    0x0041,
                    0x00B4,
                    0x00B4,
                    0x00B4,
                    0x00B4,
                    0x0039,
                    0x0037,
                    0x005D,
                    0x00B1,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0024,
                    0x0026,
                    0x0025,
                    0x0025,
                    0x00B1,
                    0x00B1,
                    0x005B,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0023,
                    0x0023,
                    0x0025,
                    0x00B1,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0023,
                    0x005E,
                    0x005B,
                    0x005E,
                    0x005E,
                    0x00B1,
                    0x0053,
                    0x0023,
                    0x0023,
                    0x0023,
                    0x0024,
                    0x0026,
                    0x0026,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x005D,
                    0x0026,
                    0x0024,
                    0x00B3,
                    0x00B3,
                    0x00B3,
                    0x0023,
                    0x0024,
                    0x00B3,
                    0x00B3,
                    0x00B3,
                    0x00B3,
                    0x00B1,
                    0x00B1,
                    0x00B1,
                    0x00B1,
                    0x005B,
                    0x005B,
                    0x0053,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x003A,
                    0x0000,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x0026,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x0021,
                    0x0023,
                    0x00B5,
                    0x0093,
                    0x0091,
                    0x0053,
                    0x002E,
                    0x00B7,
                    0x0037,
                    0x0015,
                    0x0037,
                    0x0015,
                    0x0015,
                    0x0041,
                    0x0041,
                    0x003A,
                    0x00B1,
                    0x0026,
                    0x005B,
                    0x0026,
                    0x0026,
                    0x005E,
                    0x0059,
                    0x005A,
                    0x0037,
                    0x005B,
                    0x005B,
                    0x005E,
                    0x0013,
                    0x0013,
                    0x0009,
                    0x000E,
                    0x000F,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0022
                }
            },
            {
                16, new List<int>	// Return to Egypt
                {
                    0x00A9,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x00A9,
                    0x0000,
                    0x005E,
                    0x000E,
                    0x005A,
                    0x005A,
                    0x005D,
                    0x005A,
                    0x0076,
                    0x0077,
                    0x0078,
                    0x0079,
                    0x003C,
                    0x003D,
                    0x000B,
                    0x005A,
                    0x0059,
                    0x0039,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x005E,
                    0x005A,
                    0x0059,
                    0x003A,
                    0x0059,
                    0x0025,
                    0x000E,
                    0x00A9,
                    0x0055,
                    0x0025,
                    0x0025,
                    0x0059,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0059,
                    0x0025,
                    0x0030,
                    0x0030,
                    0x0041,
                    0x0041,
                    0x0037,
                    0x000E,
                    0x0059,
                    0x0055,
                    0x000E,
                    0x0046,
                    0x0044,
                    0x0044,
                    0x0044,
                    0x0081,
                    0x0045,
                    0x0046,
                    0x0046,
                    0x0046,
                    0x0046,
                    0x000E,
                    0x00A9,
                    0x0045,
                    0x0045,
                    0x0044,
                    0x0044,
                    0x0046,
                    0x0046,
                    0x0045,
                    0x0045,
                    0x0044,
                    0x0089,
                    0x003A,
                    0x000A,
                    0x0059,
                    0x005E,
                    0x00A9,
                    0x00A9,
                    0x0039,
                    0x000E,
                    0x000E,
                    0x000E,
                    0x000B,
                    0x0059,
                    0x0026,
                    0x000B,
                    0x005A,
                    0x0039,
                    0x005D,
                    0x0059,
                    0x000B,
                    0x0059,
                    0x000B,
                    0x0038,
                    0x000B,
                    0x0056,
                    0x005A,
                    0x005D,
                    0x000A,
                    0x000A,
                    0x000A,
                    0x000A,
                    0x000A,
                    0x000A,
                    0x000E,
                    0x000E,
                    0x005D,
                    0x0037,
                    0x005D,
                    0x0025,
                    0x0025,
                    0x000E,
                    0x0059,
                    0x00A9,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x003C,
                    0x003D,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0025,
                    0x0025,
                    0x005A,
                    0x0059,
                    0x000E,
                    0x000E,
                    0x000E,
                    0x005D,
                    0x0026,
                    0x0026,
                    0x0059,
                    0x0059,
                    0x0016,
                    0x0016,
                    0x0059,
                    0x0025,
                    0x00A9,
                    0x0025,
                    0x0016,
                    0x000E,
                    0x0059,
                    0x000E,
                    0x0045,
                    0x0044,
                    0x0045,
                    0x0045,
                    0x00A9,
                    0x0016,
                    0x0016,
                    0x000E,
                    0x005D,
                    0x000B,
                    0x0059,
                    0x0059,
                    0x005D,
                    0x005D,
                    0x000B,
                    0x000B,
                    0x0059,
                    0x0038,
                    0x003B,
                    0x000B,
                    0x0059,
                    0x000B,
                    0x000E,
                    0x0059,
                    0x005D,
                    0x005D,
                    0x000E,
                    0x005B,
                    0x0057,
                    0x005B,
                    0x0059,
                    0x0026,
                    0x005D,
                    0x005D,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0045,
                    0x0045,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0045,
                    0x0045,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000B,
                    0x000B,
                    0x000B,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x0010,
                    0x000E,
                    0x0011,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0010,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000D,
                    0x000C,
                    0x0010,
                    0x0010,
                    0x0013,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000E
                }
            },
            {
                17, new List<int>	// Temple of the Cat
                {
                    0x0059,
                    0x0030,
                    0x0030,
                    0x000E,
                    0x000E,
                    0x0059,
                    0x005D,
                    0x000E,
                    0x00A9,
                    0x0037,
                    0x003B,
                    0x005E,
                    0x0081,
                    0x005A,
                    0x005A,
                    0x0039,
                    0x000E,
                    0x000E,
                    0x005A,
                    0x0016,
                    0x0056,
                    0x005A,
                    0x005A,
                    0x005A,
                    0x0039,
                    0x0038,
                    0x0016,
                    0x0016,
                    0x0039,
                    0x0057,
                    0x005B,
                    0x005B,
                    0x005D,
                    0x0039,
                    0x000E,
                    0x0037,
                    0x003C,
                    0x005E,
                    0x0041,
                    0x0037,
                    0x0041,
                    0x0037,
                    0x0000,
                    0x000B,
                    0x0081,
                    0x00A9,
                    0x0081,
                    0x0081,
                    0x0081,
                    0x0081,
                    0x0089,
                    0x0089,
                    0x0089,
                    0x0089,
                    0x0089,
                    0x003A,
                    0x000E,
                    0x000E,
                    0x000E,
                    0x005A,
                    0x0030,
                    0x000E,
                    0x003A,
                    0x003C,
                    0x003D,
                    0x000B,
                    0x000B,
                    0x005A,
                    0x005A,
                    0x000E,
                    0x0037,
                    0x0037,
                    0x005D,
                    0x005D,
                    0x00A9,
                    0x0081,
                    0x003C,
                    0x003D,
                    0x0039,
                    0x005D,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0037,
                    0x0059,
                    0x005B,
                    0x000B,
                    0x005B,
                    0x000A,
                    0x005E,
                    0x000A,
                    0x000B,
                    0x0038,
                    0x005D,
                    0x005D,
                    0x0016,
                    0x0037,
                    0x0038,
                    0x0016,
                    0x0016,
                    0x0037,
                    0x0037,
                    0x0026,
                    0x005D,
                    0x005A,
                    0x0055,
                    0x000A,
                    0x003A,
                    0x003A,
                    0x0039,
                    0x0039,
                    0x003B,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x005B,
                    0x005B,
                    0x0037,
                    0x005B,
                    0x005E,
                    0x005B,
                    0x0039,
                    0x0057,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0037,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0030,
                    0x0016,
                    0x0059,
                    0x0055,
                    0x0059,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0059,
                    0x0016,
                    0x005B,
                    0x005E,
                    0x0026,
                    0x0026,
                    0x0059,
                    0x000E,
                    0x005D,
                    0x005D,
                    0x0041,
                    0x0041,
                    0x0041,
                    0x005D,
                    0x0059,
                    0x0039,
                    0x0030,
                    0x0030,
                    0x0037,
                    0x0030,
                    0x0030,
                    0x005E,
                    0x005B,
                    0x005A,
                    0x005D,
                    0x0030,
                    0x0030,
                    0x0016,
                    0x0016,
                    0x0089,
                    0x003C,
                    0x0089,
                    0x0016,
                    0x0016,
                    0x0037,
                    0x0016,
                    0x0025,
                    0x0025,
                    0x0037,
                    0x003B,
                    0x00A9,
                    0x005D,
                    0x000E,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x005D,
                    0x0030,
                    0x0016,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000B,
                    0x0010,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x000C,
                    0x000D,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000F,
                    0x0010,
                    0x0010,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000E,
                    0x000E,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x000F,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009
                }
            },
            {
                18, new List<int>	// Atlantean Stronghold
                {
                    0x0059,
                    0x005D,
                    0x0056,
                    0x0014,
                    0x003B,
                    0x0016,
                    0x0026,
                    0x0014,
                    0x0016,
                    0x0059,
                    0x005E,
                    0x0055,
                    0x0059,
                    0x005D,
                    0x0059,
                    0x0014,
                    0x00A3,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x005D,
                    0x0015,
                    0x00A3,
                    0x00A9,
                    0x00A9,
                    0x0017,
                    0x00B1,
                    0x00B1,
                    0x00B1,
                    0x0016,
                    0x005D,
                    0x005D,
                    0x0014,
                    0x0014,
                    0x0059,
                    0x005E,
                    0x005A,
                    0x0026,
                    0x0026,
                    0x0059,
                    0x0016,
                    0x0059,
                    0x00B1,
                    0x0000,
                    0x005D,
                    0x00B1,
                    0x0026,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x0017,
                    0x0017,
                    0x00B4,
                    0x0015,
                    0x0059,
                    0x00B1,
                    0x005D,
                    0x0028,
                    0x0028,
                    0x0028,
                    0x0016,
                    0x0016,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x003B,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x003B,
                    0x0015,
                    0x005E,
                    0x0037,
                    0x0038,
                    0x003C,
                    0x0016,
                    0x0059,
                    0x0059,
                    0x003C,
                    0x0059,
                    0x0016,
                    0x0059,
                    0x0037,
                    0x0016,
                    0x0016,
                    0x003C,
                    0x0015,
                    0x0015,
                    0x00B1,
                    0x005D,
                    0x005A,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x005D,
                    0x005A,
                    0x0037,
                    0x005A,
                    0x005A,
                    0x0038,
                    0x0038,
                    0x003E,
                    0x003E,
                    0x0059,
                    0x005A,
                    0x003E,
                    0x005B,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x00B1,
                    0x00B1,
                    0x0015,
                    0x0059,
                    0x005A,
                    0x0015,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x0025,
                    0x00B1,
                    0x00B5,
                    0x00B5,
                    0x0028,
                    0x0037,
                    0x005D,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x005A,
                    0x0016,
                    0x003D,
                    0x0037,
                    0x0038,
                    0x0038,
                    0x005E,
                    0x005A,
                    0x0059,
                    0x0040,
                    0x0040,
                    0x0059,
                    0x003C,
                    0x0037,
                    0x005D,
                    0x005D,
                    0x005B,
                    0x0059,
                    0x005A,
                    0x0059,
                    0x005D,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0013,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0013,
                    0x0013,
                    0x0009,
                    0x0013,
                    0x0013,
                    0x0013,
                    0x0013,
                    0x0013,
                    0x0013,
                    0x000B,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0015,
                    0x0015,
                    0x0016,
                    0x0016
                }
            },
            {
                19, new List<int>	// The Hive
                {
                    0x005B,
                    0x005B,
                    0x0014,
                    0x003F,
                    0x003F,
                    0x003C,
                    0x005E,
                    0x003F,
                    0x0059,
                    0x0059,
                    0x003F,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x00B1,
                    0x0059,
                    0x0055,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x0037,
                    0x0037,
                    0x003B,
                    0x005E,
                    0x005B,
                    0x005B,
                    0x003B,
                    0x0037,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00B5,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x00A3,
                    0x0017,
                    0x003C,
                    0x005D,
                    0x003C,
                    0x003C,
                    0x0037,
                    0x0000,
                    0x005A,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0026,
                    0x0015,
                    0x0015,
                    0x005B,
                    0x005B,
                    0x00B1,
                    0x005D,
                    0x0015,
                    0x005D,
                    0x0015,
                    0x002A,
                    0x0028,
                    0x0028,
                    0x005D,
                    0x002A,
                    0x0037,
                    0x0037,
                    0x005A,
                    0x0056,
                    0x0057,
                    0x005B,
                    0x00A3,
                    0x00A3,
                    0x0037,
                    0x00A9,
                    0x0017,
                    0x0015,
                    0x0015,
                    0x0015,
                    0x005B,
                    0x0015,
                    0x0015,
                    0x005A,
                    0x005A,
                    0x005B,
                    0x005D,
                    0x005D,
                    0x005D,
                    0x005D,
                    0x005D,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x005B,
                    0x005B,
                    0x003B,
                    0x0037,
                    0x0037,
                    0x003B,
                    0x005B,
                    0x005B,
                    0x003E,
                    0x003E,
                    0x005A,
                    0x0017,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005E,
                    0x005E,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x0037,
                    0x003B,
                    0x003B,
                    0x0017,
                    0x0015,
                    0x0015,
                    0x00B5,
                    0x00A3,
                    0x00A3,
                    0x003C,
                    0x0038,
                    0x0038,
                    0x003C,
                    0x003E,
                    0x0038,
                    0x0059,
                    0x0059,
                    0x0059,
                    0x005B,
                    0x005B,
                    0x005E,
                    0x005E,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x005B,
                    0x0016,
                    0x005D,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0015,
                    0x0013,
                    0x0013,
                    0x0013,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x0009,
                    0x000B,
                    0x000B,
                    0x0014,
                    0x0014,
                    0x0014,
                    0x0014,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0016,
                    0x0014,
                    0x0014,
                    0x0017,
                    0x0014,
                    0x0014
                }
            },
        };

        public static readonly Dictionary<int, Dictionary<int, TR1Object>> TR1ObjectsByLevel = new Dictionary<int, Dictionary<int, TR1Object>>
        {
            [1] = new Dictionary<int, TR1Object> // Caves
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x68,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [2] = new Dictionary<int, TR1Object> // City of Vilcabamba
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x01,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [3] = new Dictionary<int, TR1Object> // Lost Valley
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x21,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x21,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x21,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x21,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
            },
            [4] = new Dictionary<int, TR1Object> // Tomb of Qualopec
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x69,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x69,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [5] = new Dictionary<int, TR1Object> // St. Francis' Folly
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x69,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x61,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x61,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x21,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x69,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x69,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x21,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x21,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x21,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x01,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x01,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x01,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x21,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x21,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x21,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
            },
            [6] = new Dictionary<int, TR1Object> // Colosseum
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "OUTFIT_TR1_CLASSIC"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [7] = new Dictionary<int, TR1Object> // Palace Midas
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x01,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x01,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x00,
                    Name = "MAGNUM_ITEM"
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x00,
                    Name = ""
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                    Name = "UZI_ITEM"
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                    Name = ""
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x00,
                    Name = "GUN_AMMO_ITEM"
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x20,
                    Name = ""
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                    Name = "SG_AMMO_ITEM"
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x21,
                    Name = ""
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x68,
                    Name = "MAG_AMMO_ITEM"
                },
            },
            [8] = new Dictionary<int, TR1Object> // The Cistern
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x00,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x21,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x21,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x01,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x01,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x21,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x21,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x21,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [9] = new Dictionary<int, TR1Object> // Tomb of Tihocan
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x21,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x01,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x21,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x21,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x61,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [10] = new Dictionary<int, TR1Object> // City of Khamoon
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [11] = new Dictionary<int, TR1Object> // Obelisk of Khamoon
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x61,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x60,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x21,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x21,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x01,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x01,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x21,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x21,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [12] = new Dictionary<int, TR1Object> // Sanctuary of the Scion
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x21,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x01,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x21,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
            },
            [13] = new Dictionary<int, TR1Object> // Natla's Mines
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x69,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x69,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x69,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x21,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x01,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x21,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x61,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x21,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x00,
                    Name = "MAGNUM_ITEM"
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x00,
                    Name = ""
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                    Name = "UZI_ITEM"
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                    Name = ""
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                    Name = "GUN_AMMO_ITEM"
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                    Name = ""
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                    Name = "SG_AMMO_ITEM"
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                    Name = ""
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x68,
                    Name = "MAG_AMMO_ITEM"
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x00,
                    Name = ""
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x69,
                    Name = "UZI_AMMO_ITEM"
                },
                [183] = new TR1Object
                {
                    ObjectId = 183,
                    Flags00 = 0x20,
                    Name = ""
                },
            },
            [14] = new Dictionary<int, TR1Object> // Atlantis
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x60,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x21,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x61,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                    Name = "MAGNUM_ITEM"
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                    Name = ""
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                    Name = "UZI_ITEM"
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                    Name = ""
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                    Name = "GUN_AMMO_ITEM"
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                    Name = ""
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                    Name = "SG_AMMO_ITEM"
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                    Name = ""
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                    Name = "MAG_AMMO_ITEM"
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                    Name = ""
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                    Name = "UZI_AMMO_ITEM"
                },
            },
            [15] = new Dictionary<int, TR1Object> // The Great Pyramid
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x21,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x69,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x21,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                    Name = "MAGNUM_ITEM"
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                    Name = ""
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                    Name = "UZI_ITEM"
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                    Name = ""
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                    Name = "GUN_AMMO_ITEM"
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                    Name = ""
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                    Name = "SG_AMMO_ITEM"
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x21,
                    Name = ""
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                    Name = "MAG_AMMO_ITEM"
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                    Name = ""
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                    Name = "UZI_AMMO_ITEM"
                },
                [183] = new TR1Object
                {
                    ObjectId = 183,
                    Flags00 = 0x21,
                    Name = ""
                },
            },
            [16] = new Dictionary<int, TR1Object> // Return to Egypt
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [17] = new Dictionary<int, TR1Object> // Temple of the Cat
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
            },
            [18] = new Dictionary<int, TR1Object> // Atlantean Stronghold
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x00,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x00,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x00,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x00,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x00,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x00,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x00,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x00,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x60,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x21,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x61,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                    Name = "MAGNUM_ITEM"
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                    Name = ""
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                    Name = "UZI_ITEM"
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                    Name = ""
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                    Name = "GUN_AMMO_ITEM"
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                    Name = ""
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                    Name = "SG_AMMO_ITEM"
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                    Name = ""
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                    Name = "MAG_AMMO_ITEM"
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                    Name = ""
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                    Name = "UZI_AMMO_ITEM"
                },
            },
            [19] = new Dictionary<int, TR1Object> // The Hive
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                    Name = "HEAD_IDLE"
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                    Name = ""
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                    Name = "PISTOLS"
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                    Name = ""
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                    Name = "SHOTGUN"
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                    Name = ""
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                    Name = "MAGNUM"
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                    Name = "UZI"
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                    Name = "LARA_EXTRA"
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                    Name = "EVIL_LARA"
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                    Name = "WOLF"
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                    Name = "BEAR"
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                    Name = "BAT"
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                    Name = "CROCODILE"
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                    Name = ""
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                    Name = "LION"
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                    Name = ""
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                    Name = "LIONESS"
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x00,
                    Name = ""
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x00,
                    Name = "PUMA"
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x00,
                    Name = ""
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x00,
                    Name = "APE"
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x00,
                    Name = ""
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x00,
                    Name = "RAT"
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x00,
                    Name = ""
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x00,
                    Name = "RAT"
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                    Name = ""
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                    Name = "DINOSAUR"
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                    Name = ""
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                    Name = "RAPTOR"
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                    Name = ""
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                    Name = "WARRIOR1"
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                    Name = ""
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                    Name = "WARRIOR2"
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                    Name = ""
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                    Name = "WARRIOR3"
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                    Name = ""
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                    Name = "CENTAUR"
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                    Name = ""
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                    Name = "MUMMY"
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                    Name = ""
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                    Name = "DINO_WARRIOR"
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                    Name = ""
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                    Name = "FISH"
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                    Name = ""
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                    Name = "LARSON"
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                    Name = ""
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                    Name = "PIERRE"
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x60,
                    Name = ""
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                    Name = "SKATEBOARD"
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                    Name = ""
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                    Name = "MERCENARY1"
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                    Name = ""
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                    Name = "MERCENARY2"
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                    Name = ""
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                    Name = "MERCENARY3"
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                    Name = ""
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                    Name = "NATLA"
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                    Name = ""
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                    Name = "EVIL_NATLA"
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                    Name = ""
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                    Name = "FALLING_BLOCK"
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                    Name = ""
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                    Name = "PENDULUM"
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                    Name = ""
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                    Name = "SPIKES"
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                    Name = ""
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                    Name = "ROLLING_BALL"
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                    Name = ""
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                    Name = "DARTS"
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                    Name = ""
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                    Name = "DART_EMITTER"
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                    Name = ""
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                    Name = "DRAW_BRIDGE"
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                    Name = ""
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                    Name = "TEETH_TRAP"
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                    Name = ""
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                    Name = "DAMOCLES_SWORD"
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                    Name = ""
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                    Name = "THORS_HANDLE"
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                    Name = ""
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                    Name = "THORS_HEAD"
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                    Name = ""
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                    Name = "LIGHTNING_EMITTER"
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                    Name = ""
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                    Name = "MOVING_BAR"
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                    Name = ""
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK"
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                    Name = ""
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                    Name = "MOVABLE_BLOCK2"
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                    Name = ""
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK3"
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                    Name = ""
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                    Name = "MOVABLE_BLOCK4"
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                    Name = ""
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                    Name = "ROLLING_BLOCK"
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                    Name = ""
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING1"
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                    Name = ""
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                    Name = "FALLING_CEILING2"
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                    Name = ""
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE1"
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                    Name = ""
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                    Name = "SWITCH_TYPE2"
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                    Name = ""
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE1"
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                    Name = ""
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE2"
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                    Name = ""
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE3"
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                    Name = ""
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE4"
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                    Name = ""
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE5"
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                    Name = ""
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE6"
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                    Name = ""
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                    Name = "DOOR_TYPE7"
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                    Name = ""
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                    Name = "DOOR_TYPE8"
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                    Name = ""
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR"
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                    Name = ""
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                    Name = "TRAPDOOR2"
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                    Name = ""
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                    Name = "BIGTRAPDOOR"
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                    Name = ""
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                    Name = "BRIDGE_FLAT"
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                    Name = ""
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT1"
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                    Name = ""
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                    Name = "BRIDGE_TILT2"
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                    Name = ""
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                    Name = "PASSPORT_OPTION"
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                    Name = ""
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                    Name = "MAP_OPTION"
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                    Name = ""
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x21,
                    Name = "PHOTO_OPTION"
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                    Name = ""
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                    Name = "COG_1"
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                    Name = ""
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                    Name = "COG_2"
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                    Name = ""
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                    Name = "COG_3"
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                    Name = ""
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                    Name = "PLAYER_1"
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                    Name = ""
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                    Name = "PLAYER_2"
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                    Name = ""
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                    Name = "PLAYER_3"
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                    Name = ""
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                    Name = "PLAYER4"
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                    Name = ""
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                    Name = "PASSPORT_CLOSED"
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x61,
                    Name = ""
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                    Name = "MAP_CLOSED"
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                    Name = ""
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                    Name = "SAVEGAME_ITEM"
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                    Name = ""
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                    Name = "GUN_ITEM"
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                    Name = ""
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                    Name = "SHOTGUN_ITEM"
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                    Name = ""
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                    Name = "MAGNUM_ITEM"
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                    Name = ""
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                    Name = "UZI_ITEM"
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                    Name = ""
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                    Name = "GUN_AMMO_ITEM"
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                    Name = ""
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                    Name = "SG_AMMO_ITEM"
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                    Name = ""
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                    Name = "MAG_AMMO_ITEM"
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                    Name = ""
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                    Name = "UZI_AMMO_ITEM"
                },
            },
        };
    }
}
