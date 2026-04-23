using System.Collections.Generic;

namespace TRR_SaveMaster
{
    public class TR1EntityCache
    {
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

        public static readonly Dictionary<int, int> SplitIndexByLevel = new Dictionary<int, int>
        {
            { 5,  107 },    // St. Francis' Folly
            { 6,  86  },    // Colosseum
            { 8,  112 },    // The Cistern
            { 9,  88  },    // Tomb of Tihocan
            { 14, 192 },    // Atlantis
            { 15, 129 },    // The Great Pyramid
            { 18, 174 },    // Atlantean Stronghold
            { 19, 186 },    // The Hive
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
                    { 4, 4  },  // Reinforcement
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
                    { 4, 10 },  // Reinforcement
                    { 5, 20 },  // Crowded
                    { 6, 40 },  // All Hands on Deck
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
                    { 5, 15 },  // Crowded
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

        public static readonly Dictionary<byte, Dictionary<string, List<TR1CatEntry>>> ChallengeModeCatGroups = new Dictionary<byte, Dictionary<string, List<TR1CatEntry>>>()
        {
            {
                0, // Downscaling
                new Dictionary<string, List<TR1CatEntry>>
                {
                    {
                        "CAT1 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0010, 0, 100),
                        }
                    },
                    {
                        "CAT2 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x000F, 75, 50),
                            new TR1CatEntry(0x0007, 75, 50),
                        }
                    },
                    {
                        "CAT3 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0008, 75, 30),
                            new TR1CatEntry(0x000C, 75, 30),
                            new TR1CatEntry(0x000D, 75, 20),
                            new TR1CatEntry(0x000A, 75, 10),
                            new TR1CatEntry(0x0013, 75, 10),
                        }
                    },
                    {
                        "CAT4 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0015, 75, 0),
                            new TR1CatEntry(0x0016, 75, 0),
                            new TR1CatEntry(0x000E, 75, 0),
                        }
                    }
                }
            },
            {
                1, // Upscaling
                new Dictionary<string, List<TR1CatEntry>>
                {
                    {
                        "CAT1 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0010, 25, 0),
                        }
                    },
                    {
                        "CAT2 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x000F, 75, 50),
                            new TR1CatEntry(0x0007, 75, 50),
                        }
                    },
                    {
                        "CAT3 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0008, 75, 30),
                            new TR1CatEntry(0x000C, 75, 30),
                            new TR1CatEntry(0x000D, 75, 20),
                            new TR1CatEntry(0x000A, 75, 10),
                            new TR1CatEntry(0x0013, 75, 10),
                        }
                    },
                    {
                        "CAT4 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0015, 0, 20),
                            new TR1CatEntry(0x0016, 0, 20),
                            new TR1CatEntry(0x000E, 0, 60),
                        }
                    }
                }
            },
            {
                3, // Atlantean Advancements
                new Dictionary<string, List<TR1CatEntry>>
                {
                    {
                        "CAT3 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0008, 50, 0),
                            new TR1CatEntry(0x000C, 50, 0),
                            new TR1CatEntry(0x000D, 50, 0),
                            new TR1CatEntry(0x000A, 50, 0),
                            new TR1CatEntry(0x0013, 50, 0),
                        }
                    },
                    {
                        "CAT4 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0015, 100, 50),
                            new TR1CatEntry(0x0016, 100, 50),
                            new TR1CatEntry(0x000E, 75, 0),
                        }
                    }
                }
            },
            {
                4, // Cryptid Chaos
                new Dictionary<string, List<TR1CatEntry>>
                {
                    {
                        "CAT2 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x000F, 50, 0),
                            new TR1CatEntry(0x0007, 50, 0),
                        }
                    },
                    {
                        "CAT3 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0008, 75, 0),
                            new TR1CatEntry(0x000C, 75, 0),
                            new TR1CatEntry(0x000D, 75, 0),
                            new TR1CatEntry(0x000A, 75, 0),
                            new TR1CatEntry(0x0013, 100, 100),
                        }
                    },
                    {
                        "CAT4 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0015, 75, 0),
                            new TR1CatEntry(0x0016, 75, 0),
                            new TR1CatEntry(0x000E, 75, 0),
                        }
                    }
                }
            },
            {
                5, // Randomizer
                new Dictionary<string, List<TR1CatEntry>>
                {
                    {
                        "CAT1 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0010, 100, 100),
                        }
                    },
                    {
                        "CAT2 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x000F, 75, 50),
                            new TR1CatEntry(0x0007, 75, 50),
                        }
                    },
                    {
                        "CAT3 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0008, 75, 30),
                            new TR1CatEntry(0x000C, 75, 30),
                            new TR1CatEntry(0x000D, 75, 20),
                            new TR1CatEntry(0x000A, 75, 10),
                            new TR1CatEntry(0x0013, 75, 10),
                        }
                    },
                    {
                        "CAT4 - Enemy",
                        new List<TR1CatEntry>
                        {
                            new TR1CatEntry(0x0015, 75, 20),
                            new TR1CatEntry(0x0016, 75, 20),
                            new TR1CatEntry(0x000E, 75, 60),
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<byte, Dictionary<int, string>> ChallengeModeObjectIdToCategory = BuildObjectIdToCategoryMap();

        private static Dictionary<byte, Dictionary<int, string>> BuildObjectIdToCategoryMap()
        {
            var result = new Dictionary<byte, Dictionary<int, string>>();

            foreach (var etEntry in ChallengeModeCatGroups)
            {
                byte enemyType = etEntry.Key;
                var catGroups = etEntry.Value;

                var objectToCat = new Dictionary<int, string>();

                foreach (var catEntry in catGroups)
                {
                    string catName = catEntry.Key;
                    var entries = catEntry.Value;

                    foreach (var entry in entries)
                    {
                        objectToCat[entry.ObjectId] = catName;
                    }
                }

                result[enemyType] = objectToCat;
            }

            return result;
        }

        public static readonly Dictionary<byte, Dictionary<string, string>> ChallengeModeCatMapping = new Dictionary<byte, Dictionary<string, string>>()
        {
            {
                0, // Downscaling
                new Dictionary<string, string>
                {
                    { "CAT2 - Enemy", "CAT1 - Enemy" },
                    { "CAT3 - Enemy", "CAT2 - Enemy" },
                    { "CAT4 - Enemy", "CAT3 - Enemy" },
                }
            },
            {
                1, // Upscaling
                new Dictionary<string, string>
                {
                    { "CAT1 - Enemy", "CAT2 - Enemy" },
                    { "CAT2 - Enemy", "CAT3 - Enemy" },
                    { "CAT3 - Enemy", "CAT4 - Enemy" },
                }
            },
            {
                3, // Atlantean Advancements
                new Dictionary<string, string>
                {
                    { "CAT3 - Enemy", "CAT4 - Enemy" },
                    { "CAT4 - Enemy", "CAT4 - Enemy" },
                }
            },
            {
                4, // Cryptid Chaos
                new Dictionary<string, string>
                {
                    { "CAT2 - Enemy", "CAT3 - Enemy" },
                    { "CAT3 - Enemy", "CAT3 - Enemy" },
                    { "CAT4 - Enemy", "CAT3 - Enemy" },
                }
            }
        };

        public static readonly Dictionary<byte, List<int>> ENCandidatePools = new Dictionary<byte, List<int>>()
        {
                {
                    1, // Caves
                    new List<int>
                    {
                        0x0007, 0x0007, 0x0007, 0x0007, 0x000F, 0x0008,
                        0x0007, 0x0007, 0x0007, 0x0007, 0x000F, 0x000F,
                        0x0009, 0x0009, 0x0009, 0x000F, 0x000F, 0x000F
                    }
                },
                {
                    2, // City of Vilcabamba
                    new List<int>
                    {
                        0x0007, 0x0007, 0x0008, 0x0010, 0x0008, 0x000B,
                        0x0007, 0x000F, 0x0009, 0x0010, 0x0010, 0x000F,
                        0x000F, 0x000F, 0x000F, 0x000B, 0x0007, 0x0007,
                        0x0007, 0x0007
                    }
                },
                {
                    3, // Lost Valley
                    new List<int>
                    {
                        0x000B, 0x0013, 0x0013, 0x0013, 0x0007, 0x000F,
                        0x0013, 0x000F, 0x0013, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0012
                    }
                },
                {
                    4, // Tomb of Qualopec
                    new List<int>
                    {
                        0x0007, 0x0007, 0x0013, 0x000F, 0x0013, 0x000F,
                        0x0013, 0x0016, 0x0016, 0x0007, 0x0007, 0x0008,
                        0x0013, 0x0009, 0x0009, 0x0013
                    }
                },
                {
                    5, // St. Francis' Folly
                    new List<int>
                    {
                        0x000F, 0x000F, 0x000D, 0x000D, 0x000F, 0x000F,
                        0x000C, 0x000F, 0x000F, 0x000F, 0x0009, 0x0009,
                        0x000F, 0x0009, 0x000B, 0x0010, 0x0010, 0x000F
                    }
                },
                {
                    6, // Colosseum
                    new List<int>
                    {
                        0x000C, 0x000E, 0x000F, 0x000C, 0x000D, 0x0008,
                        0x000E, 0x000E, 0x000C, 0x0010, 0x0010, 0x000F,
                        0x0016, 0x0009, 0x000F, 0x0009, 0x0009
                    }
                },
                {
                    7, // Palace Midas
                    new List<int>
                    {
                        0x000E, 0x000F, 0x000F, 0x0008, 0x000E, 0x000C,
                        0x000A, 0x0013, 0x0013, 0x0010, 0x0010, 0x000E,
                        0x000C, 0x000C, 0x000C
                    }
                },
                {
                    8, // The Cistern
                    new List<int>
                    {
                        0x0010, 0x0009, 0x0009, 0x000A, 0x000A, 0x000E,
                        0x000C, 0x000D, 0x000B, 0x0010, 0x0007, 0x0011,
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0010, 0x0010, 0x0010, 0x0010, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x000F, 0x000F
                    }
                },
                {
                    9, // Tomb of Tihocan
                    new List<int>
                    {
                        0x0010, 0x000A, 0x0008, 0x000F, 0x000F, 0x000B,
                        0x0010, 0x000B, 0x0011, 0x0016, 0x0016, 0x0007,
                        0x0007, 0x0009, 0x0009, 0x0009, 0x0009, 0x0010,
                        0x0010, 0x0010
                    }
                },
                {
                    10, // City of Khamoon
                    new List<int>
                    {
                        0x0009, 0x000E, 0x0016, 0x000E, 0x000E, 0x0009,
                        0x000B, 0x000C, 0x000E, 0x000F, 0x000F, 0x000D,
                        0x000C, 0x000D, 0x000B, 0x0009, 0x0009
                    }
                },
                {
                    11, // Obelisk of Khamoon
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0010, 0x000D,
                        0x000C, 0x000E, 0x0016, 0x000B, 0x000E, 0x0016,
                        0x0010, 0x0010, 0x0009, 0x0009, 0x0009, 0x000B,
                        0x000B, 0x0009, 0x0009, 0x0010, 0x0010, 0x0010,
                        0x0010, 0x0010, 0x0009, 0x0009, 0x0010, 0x0010,
                        0x0010, 0x0010, 0x0010, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x0009
                    }
                },
                {
                    12, // Sanctuary of the Scion
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0016, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x000E, 0x000E, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x000B, 0x000B, 0x000B, 0x0009, 0x0009,
                        0x0009, 0x000E, 0x0010, 0x0010, 0x000D, 0x000C,
                        0x0010, 0x0010
                    }
                },
                {
                    14, // Atlantis
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x0013, 0x0009, 0x0009,
                        0x0009, 0x0013, 0x0009, 0x0009, 0x0009, 0x000B,
                        0x000B, 0x000B, 0x0013, 0x0013, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0010, 0x0014
                    }
                },
                {
                    15, // The Great Pyramid
                    new List<int>
                    {
                        0x0013, 0x0013, 0x0009, 0x000E, 0x000F, 0x000F,
                        0x0009, 0x0009, 0x0009, 0x0009
                    }
                },
                {
                    16, // Return to Egypt
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x000B, 0x000B, 0x000B,
                        0x0010, 0x0009, 0x0009, 0x0009, 0x0009, 0x0010,
                        0x0010, 0x0010, 0x0010, 0x000E, 0x0011, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0009, 0x000F,
                        0x000F, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0010, 0x000F, 0x0009, 0x0009,
                        0x0009, 0x000D, 0x000C, 0x0010, 0x0010, 0x0013,
                        0x0013, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x000E
                    }
                },
                {
                    17, // Temple of the Cat
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x000B, 0x0010, 0x0010,
                        0x0009, 0x0009, 0x000C, 0x000D, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x000F, 0x0010, 0x0010,
                        0x0009, 0x0009, 0x0009, 0x000E, 0x000E, 0x000F,
                        0x000F, 0x000F, 0x000F, 0x0009, 0x0009, 0x0009,
                        0x0009
                    }
                },
                {
                    18, // Atlantean Stronghold
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0013, 0x0013,
                        0x0009, 0x0009, 0x0013, 0x0013, 0x0009, 0x0013,
                        0x0013, 0x0013, 0x0013, 0x0013, 0x0013, 0x000B,
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009
                    }
                },
                {
                    19, // The Hive
                    new List<int>
                    {
                        0x0009, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x0015, 0x0013, 0x0013,
                        0x0013, 0x0009, 0x0009, 0x0009, 0x0009, 0x0009,
                        0x0009, 0x0009, 0x0009, 0x000B, 0x000B
                    }
                },
        };

        public static readonly Dictionary<int, HashSet<int>> UnchangeableEntitiesByLevel = new Dictionary<int, HashSet<int>>()
        {
            [17] = new HashSet<int>     // Temple of the Cat
            {
                26, 27, 95,
                118, 119, 120,
                121, 122, 123
            },
        };

        public static readonly Dictionary<int, bool> TR1EnemyRemovableByObjectId = new Dictionary<int, bool>
        {
            [0x0009] = true,
            [0x0008] = true,
            [0x0017] = false,
            [0x000A] = true,
            [0x000B] = true,
            [0x0011] = true,
            [0x0010] = true,
            [0x0022] = false,
            [0x000F] = true,
            [0x000D] = true,
            [0x000C] = true,
            [0x0018] = true,
            [0x0014] = true,
            [0x0021] = false,
            [0x000E] = true,
            [0x0013] = true,
            [0x0012] = false,
            [0x0007] = true,
            [0x001B] = false,
            [0x001C] = false,
            [0x001F] = false,
            [0x001E] = false,
            [0x0020] = false,
            [0x0006] = false,
            [0x0015] = true,
            [0x0016] = true,
        };

        public static readonly Dictionary<byte, int> EnemyRemovalPercents = new Dictionary<byte, int>
        {
            [0] = -75,
            [1] = -50,
            [2] = -25,
            [3] = 0,
            [4] = 25,
            [5] = 50,
            [6] = 100
        };

        public static readonly Dictionary<int, List<int>> TR1AddEnemyTableByLevel = new Dictionary<int, List<int>>
        {
            [1] = new List<int> // Caves
            {
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
            },
            [2] = new List<int>     // City of Vilcabamba
            {
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
                0x0007,
            },
            [3] = new List<int>     // Lost Valley
            {
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
                0x0012,
            },
            [4] = new List<int>     // Tomb of Qualopec
            {
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
                0x0013,
            },
            [5] = new List<int>     // St. Francis' Folly
            {
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
            },
            [6] = new List<int>     // Colosseum
            {
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
            },
            [7] = new List<int>     // Palace Midas
            {
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
                0x000C,
            },
            [8] = new List<int>     // The Cistern
            {
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
            },
            [9] = new List<int>     // Tomb of Tihocan
            {
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
            },
            [10] = new List<int>    // City of Khamoon
            {
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
                0x0009,
            },
            [11] = new List<int>    // Obelisk of Khamoon
            {
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
                0x0009,
            },
            [12] = new List<int>    // Sanctuary of the Scion
            {
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
                0x0010,
            },
            [14] = new List<int>    // Atlantis
            {
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
            },
            [15] = new List<int>    // The Great Pyramid
            {
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
            },
            [16] = new List<int>    // Return to Egypt
            {
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
                0x000E,
            },
            [17] = new List<int>    // Temple of the Cat
            {
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
                0x0009,
            },
            [18] = new List<int>    // Atlantean Stronghold
            {
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
            },
            [19] = new List<int>    // The Hive
            {
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
            },
        };

        public static readonly Dictionary<int, List<int>> LevelObjectIdsByLevel = new Dictionary<int, List<int>>
        {
            {
                1, new List<int>    // Caves
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
                    0x005E
                }
            },
            {
                2, new List<int>    // City of Vilcabamba
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
                    0x003E
                }
            },
            {
                3, new List<int>    // Lost Valley
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
                    0x0059
                }
            },
            {
                4, new List<int>    // Tomb of Qualopec
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
                    0x0037
                }
            },
            {
                5, new List<int>    // St. Francis' Folly
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
                6, new List<int>    // Colosseum
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
                    0x0056,
                    0x0090,
                    0x0081,
                    0x0056,
                    0x0090,
                    0x0081
                }
            },
            {
                7, new List<int>    // Palace Midas
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
                    0x0053
                }
            },
            {
                8, new List<int>    // The Cistern
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
                9, new List<int>    // Tomb of Tihocan
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
                10, new List<int>   // City of Khamoon
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
                    0x0016
                }
            },
            {
                11, new List<int>   // Obelisk of Khamoon
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
                    0x0089
                }
            },
            {
                12, new List<int>   // Sanctuary of the Scion
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
                    0x008F
                }
            },
            {
                13, new List<int>   // Natla's Mines
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
                14, new List<int>   // Atlantis
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
                15, new List<int>   // The Great Pyramid
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
                    0x0022
                }
            },
            {
                16, new List<int>   // Return to Egypt
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
                    0x0045
                }
            },
            {
                17, new List<int>   // Temple of the Cat
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
                    0x0016
                }
            },
            {
                18, new List<int>   // Atlantean Stronghold
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
                    0x0015,
                    0x0015,
                    0x0016,
                    0x0016
                }
            },
            {
                19, new List<int>   // The Hive
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
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x68,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [2] = new Dictionary<int, TR1Object> // City of Vilcabamba
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x01,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [3] = new Dictionary<int, TR1Object> // Lost Valley
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x21,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x21,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x21,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x21,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
            },
            [4] = new Dictionary<int, TR1Object> // Tomb of Qualopec
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x69,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x69,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [5] = new Dictionary<int, TR1Object> // St. Francis' Folly
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x69,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x61,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x61,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x21,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x69,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x69,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x21,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x21,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x21,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x01,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x01,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x01,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x21,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x21,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x21,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
            },
            [6] = new Dictionary<int, TR1Object> // Colosseum
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [7] = new Dictionary<int, TR1Object> // Palace Midas
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x21,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x01,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x01,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x01,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x00,
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x00,
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x00,
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x20,
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x21,
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x68,
                },
            },
            [8] = new Dictionary<int, TR1Object> // The Cistern
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x00,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x21,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x21,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x01,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x01,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x21,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x21,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x21,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [9] = new Dictionary<int, TR1Object> // Tomb of Tihocan
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x21,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x01,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x21,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x21,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x61,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [10] = new Dictionary<int, TR1Object> // City of Khamoon
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [11] = new Dictionary<int, TR1Object> // Obelisk of Khamoon
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x61,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x60,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x21,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x21,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x21,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x01,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x01,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x01,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x21,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x21,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x21,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [12] = new Dictionary<int, TR1Object> // Sanctuary of the Scion
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x68,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x21,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x01,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x21,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x21,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
            },
            [13] = new Dictionary<int, TR1Object> // Natla's Mines
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x00,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x69,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x69,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x69,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x69,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x60,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x21,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x21,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x01,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x01,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x21,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x21,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x61,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x21,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x00,
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x00,
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x68,
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x00,
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x69,
                },
                [183] = new TR1Object
                {
                    ObjectId = 183,
                    Flags00 = 0x20,
                },
            },
            [14] = new Dictionary<int, TR1Object> // Atlantis
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x60,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x21,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x61,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                },
            },
            [15] = new Dictionary<int, TR1Object> // The Great Pyramid
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x61,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x21,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x69,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x60,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x60,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x60,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x21,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x21,
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                },
                [183] = new TR1Object
                {
                    ObjectId = 183,
                    Flags00 = 0x21,
                },
            },
            [16] = new Dictionary<int, TR1Object> // Return to Egypt
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x69,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [17] = new Dictionary<int, TR1Object> // Temple of the Cat
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x00,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x78,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x7B,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x7B,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x01,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x7B,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x7B,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x7B,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x7B,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x7B,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x20,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x20,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x60,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x61,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x61,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x60,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x60,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x60,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x60,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x01,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x01,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x01,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x21,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x21,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x21,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x21,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x21,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x01,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x21,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x20,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x60,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x00,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x00,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x00,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
            },
            [18] = new Dictionary<int, TR1Object> // Atlantean Stronghold
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x00,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x00,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x00,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x00,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x00,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x00,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x00,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x00,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x60,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x21,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x61,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                },
            },
            [19] = new Dictionary<int, TR1Object> // The Hive
            {
                [0] = new TR1Object
                {
                    ObjectId = 0,
                    Flags00 = 0x79,
                },
                [1] = new TR1Object
                {
                    ObjectId = 1,
                    Flags00 = 0x01,
                },
                [2] = new TR1Object
                {
                    ObjectId = 2,
                    Flags00 = 0x01,
                },
                [3] = new TR1Object
                {
                    ObjectId = 3,
                    Flags00 = 0x01,
                },
                [4] = new TR1Object
                {
                    ObjectId = 4,
                    Flags00 = 0x01,
                },
                [5] = new TR1Object
                {
                    ObjectId = 5,
                    Flags00 = 0x01,
                },
                [6] = new TR1Object
                {
                    ObjectId = 6,
                    Flags00 = 0x79,
                },
                [7] = new TR1Object
                {
                    ObjectId = 7,
                    Flags00 = 0x7B,
                },
                [8] = new TR1Object
                {
                    ObjectId = 8,
                    Flags00 = 0x7B,
                },
                [9] = new TR1Object
                {
                    ObjectId = 9,
                    Flags00 = 0x7B,
                },
                [10] = new TR1Object
                {
                    ObjectId = 10,
                    Flags00 = 0x7B,
                },
                [11] = new TR1Object
                {
                    ObjectId = 11,
                    Flags00 = 0x7B,
                },
                [12] = new TR1Object
                {
                    ObjectId = 12,
                    Flags00 = 0x7B,
                },
                [13] = new TR1Object
                {
                    ObjectId = 13,
                    Flags00 = 0x7B,
                },
                [14] = new TR1Object
                {
                    ObjectId = 14,
                    Flags00 = 0x7B,
                },
                [15] = new TR1Object
                {
                    ObjectId = 15,
                    Flags00 = 0x7B,
                },
                [16] = new TR1Object
                {
                    ObjectId = 16,
                    Flags00 = 0x7B,
                },
                [17] = new TR1Object
                {
                    ObjectId = 17,
                    Flags00 = 0x7B,
                },
                [18] = new TR1Object
                {
                    ObjectId = 18,
                    Flags00 = 0x7B,
                },
                [19] = new TR1Object
                {
                    ObjectId = 19,
                    Flags00 = 0x7B,
                },
                [20] = new TR1Object
                {
                    ObjectId = 20,
                    Flags00 = 0x7B,
                },
                [21] = new TR1Object
                {
                    ObjectId = 21,
                    Flags00 = 0x7B,
                },
                [22] = new TR1Object
                {
                    ObjectId = 22,
                    Flags00 = 0x7B,
                },
                [23] = new TR1Object
                {
                    ObjectId = 23,
                    Flags00 = 0x7B,
                },
                [24] = new TR1Object
                {
                    ObjectId = 24,
                    Flags00 = 0x71,
                },
                [25] = new TR1Object
                {
                    ObjectId = 25,
                    Flags00 = 0x00,
                },
                [26] = new TR1Object
                {
                    ObjectId = 26,
                    Flags00 = 0x00,
                },
                [27] = new TR1Object
                {
                    ObjectId = 27,
                    Flags00 = 0x00,
                },
                [28] = new TR1Object
                {
                    ObjectId = 28,
                    Flags00 = 0x00,
                },
                [29] = new TR1Object
                {
                    ObjectId = 29,
                    Flags00 = 0x00,
                },
                [30] = new TR1Object
                {
                    ObjectId = 30,
                    Flags00 = 0x00,
                },
                [31] = new TR1Object
                {
                    ObjectId = 31,
                    Flags00 = 0x00,
                },
                [32] = new TR1Object
                {
                    ObjectId = 32,
                    Flags00 = 0x00,
                },
                [33] = new TR1Object
                {
                    ObjectId = 33,
                    Flags00 = 0x00,
                },
                [34] = new TR1Object
                {
                    ObjectId = 34,
                    Flags00 = 0x00,
                },
                [35] = new TR1Object
                {
                    ObjectId = 35,
                    Flags00 = 0x68,
                },
                [36] = new TR1Object
                {
                    ObjectId = 36,
                    Flags00 = 0x60,
                },
                [37] = new TR1Object
                {
                    ObjectId = 37,
                    Flags00 = 0x01,
                },
                [38] = new TR1Object
                {
                    ObjectId = 38,
                    Flags00 = 0x69,
                },
                [39] = new TR1Object
                {
                    ObjectId = 39,
                    Flags00 = 0x21,
                },
                [40] = new TR1Object
                {
                    ObjectId = 40,
                    Flags00 = 0x21,
                },
                [41] = new TR1Object
                {
                    ObjectId = 41,
                    Flags00 = 0x00,
                },
                [42] = new TR1Object
                {
                    ObjectId = 42,
                    Flags00 = 0x61,
                },
                [43] = new TR1Object
                {
                    ObjectId = 43,
                    Flags00 = 0x68,
                },
                [44] = new TR1Object
                {
                    ObjectId = 44,
                    Flags00 = 0x60,
                },
                [45] = new TR1Object
                {
                    ObjectId = 45,
                    Flags00 = 0x60,
                },
                [46] = new TR1Object
                {
                    ObjectId = 46,
                    Flags00 = 0x20,
                },
                [47] = new TR1Object
                {
                    ObjectId = 47,
                    Flags00 = 0x68,
                },
                [48] = new TR1Object
                {
                    ObjectId = 48,
                    Flags00 = 0x69,
                },
                [49] = new TR1Object
                {
                    ObjectId = 49,
                    Flags00 = 0x68,
                },
                [50] = new TR1Object
                {
                    ObjectId = 50,
                    Flags00 = 0x68,
                },
                [51] = new TR1Object
                {
                    ObjectId = 51,
                    Flags00 = 0x68,
                },
                [52] = new TR1Object
                {
                    ObjectId = 52,
                    Flags00 = 0x68,
                },
                [53] = new TR1Object
                {
                    ObjectId = 53,
                    Flags00 = 0x68,
                },
                [54] = new TR1Object
                {
                    ObjectId = 54,
                    Flags00 = 0x68,
                },
                [55] = new TR1Object
                {
                    ObjectId = 55,
                    Flags00 = 0x61,
                },
                [56] = new TR1Object
                {
                    ObjectId = 56,
                    Flags00 = 0x61,
                },
                [57] = new TR1Object
                {
                    ObjectId = 57,
                    Flags00 = 0x60,
                },
                [58] = new TR1Object
                {
                    ObjectId = 58,
                    Flags00 = 0x60,
                },
                [59] = new TR1Object
                {
                    ObjectId = 59,
                    Flags00 = 0x61,
                },
                [60] = new TR1Object
                {
                    ObjectId = 60,
                    Flags00 = 0x61,
                },
                [61] = new TR1Object
                {
                    ObjectId = 61,
                    Flags00 = 0x61,
                },
                [62] = new TR1Object
                {
                    ObjectId = 62,
                    Flags00 = 0x61,
                },
                [63] = new TR1Object
                {
                    ObjectId = 63,
                    Flags00 = 0x61,
                },
                [64] = new TR1Object
                {
                    ObjectId = 64,
                    Flags00 = 0x61,
                },
                [65] = new TR1Object
                {
                    ObjectId = 65,
                    Flags00 = 0x61,
                },
                [66] = new TR1Object
                {
                    ObjectId = 66,
                    Flags00 = 0x61,
                },
                [67] = new TR1Object
                {
                    ObjectId = 67,
                    Flags00 = 0x00,
                },
                [68] = new TR1Object
                {
                    ObjectId = 68,
                    Flags00 = 0x00,
                },
                [69] = new TR1Object
                {
                    ObjectId = 69,
                    Flags00 = 0x00,
                },
                [70] = new TR1Object
                {
                    ObjectId = 70,
                    Flags00 = 0x00,
                },
                [71] = new TR1Object
                {
                    ObjectId = 71,
                    Flags00 = 0x01,
                },
                [72] = new TR1Object
                {
                    ObjectId = 72,
                    Flags00 = 0x01,
                },
                [73] = new TR1Object
                {
                    ObjectId = 73,
                    Flags00 = 0x00,
                },
                [74] = new TR1Object
                {
                    ObjectId = 74,
                    Flags00 = 0x20,
                },
                [75] = new TR1Object
                {
                    ObjectId = 75,
                    Flags00 = 0x20,
                },
                [76] = new TR1Object
                {
                    ObjectId = 76,
                    Flags00 = 0x20,
                },
                [77] = new TR1Object
                {
                    ObjectId = 77,
                    Flags00 = 0x00,
                },
                [78] = new TR1Object
                {
                    ObjectId = 78,
                    Flags00 = 0x00,
                },
                [79] = new TR1Object
                {
                    ObjectId = 79,
                    Flags00 = 0x00,
                },
                [80] = new TR1Object
                {
                    ObjectId = 80,
                    Flags00 = 0x00,
                },
                [81] = new TR1Object
                {
                    ObjectId = 81,
                    Flags00 = 0x01,
                },
                [82] = new TR1Object
                {
                    ObjectId = 82,
                    Flags00 = 0x01,
                },
                [83] = new TR1Object
                {
                    ObjectId = 83,
                    Flags00 = 0x21,
                },
                [84] = new TR1Object
                {
                    ObjectId = 84,
                    Flags00 = 0x21,
                },
                [85] = new TR1Object
                {
                    ObjectId = 85,
                    Flags00 = 0x21,
                },
                [86] = new TR1Object
                {
                    ObjectId = 86,
                    Flags00 = 0x21,
                },
                [87] = new TR1Object
                {
                    ObjectId = 87,
                    Flags00 = 0x21,
                },
                [88] = new TR1Object
                {
                    ObjectId = 88,
                    Flags00 = 0x20,
                },
                [89] = new TR1Object
                {
                    ObjectId = 89,
                    Flags00 = 0x21,
                },
                [90] = new TR1Object
                {
                    ObjectId = 90,
                    Flags00 = 0x21,
                },
                [91] = new TR1Object
                {
                    ObjectId = 91,
                    Flags00 = 0x21,
                },
                [92] = new TR1Object
                {
                    ObjectId = 92,
                    Flags00 = 0x20,
                },
                [93] = new TR1Object
                {
                    ObjectId = 93,
                    Flags00 = 0x21,
                },
                [94] = new TR1Object
                {
                    ObjectId = 94,
                    Flags00 = 0x21,
                },
                [95] = new TR1Object
                {
                    ObjectId = 95,
                    Flags00 = 0x01,
                },
                [96] = new TR1Object
                {
                    ObjectId = 96,
                    Flags00 = 0x01,
                },
                [97] = new TR1Object
                {
                    ObjectId = 97,
                    Flags00 = 0x01,
                },
                [98] = new TR1Object
                {
                    ObjectId = 98,
                    Flags00 = 0x00,
                },
                [99] = new TR1Object
                {
                    ObjectId = 99,
                    Flags00 = 0x01,
                },
                [100] = new TR1Object
                {
                    ObjectId = 100,
                    Flags00 = 0x01,
                },
                [101] = new TR1Object
                {
                    ObjectId = 101,
                    Flags00 = 0x01,
                },
                [102] = new TR1Object
                {
                    ObjectId = 102,
                    Flags00 = 0x01,
                },
                [103] = new TR1Object
                {
                    ObjectId = 103,
                    Flags00 = 0x01,
                },
                [104] = new TR1Object
                {
                    ObjectId = 104,
                    Flags00 = 0x01,
                },
                [105] = new TR1Object
                {
                    ObjectId = 105,
                    Flags00 = 0x01,
                },
                [106] = new TR1Object
                {
                    ObjectId = 106,
                    Flags00 = 0x01,
                },
                [107] = new TR1Object
                {
                    ObjectId = 107,
                    Flags00 = 0x00,
                },
                [108] = new TR1Object
                {
                    ObjectId = 108,
                    Flags00 = 0x01,
                },
                [109] = new TR1Object
                {
                    ObjectId = 109,
                    Flags00 = 0x01,
                },
                [110] = new TR1Object
                {
                    ObjectId = 110,
                    Flags00 = 0x20,
                },
                [111] = new TR1Object
                {
                    ObjectId = 111,
                    Flags00 = 0x20,
                },
                [112] = new TR1Object
                {
                    ObjectId = 112,
                    Flags00 = 0x20,
                },
                [113] = new TR1Object
                {
                    ObjectId = 113,
                    Flags00 = 0x20,
                },
                [114] = new TR1Object
                {
                    ObjectId = 114,
                    Flags00 = 0x00,
                },
                [115] = new TR1Object
                {
                    ObjectId = 115,
                    Flags00 = 0x00,
                },
                [116] = new TR1Object
                {
                    ObjectId = 116,
                    Flags00 = 0x00,
                },
                [117] = new TR1Object
                {
                    ObjectId = 117,
                    Flags00 = 0x00,
                },
                [118] = new TR1Object
                {
                    ObjectId = 118,
                    Flags00 = 0x20,
                },
                [119] = new TR1Object
                {
                    ObjectId = 119,
                    Flags00 = 0x20,
                },
                [120] = new TR1Object
                {
                    ObjectId = 120,
                    Flags00 = 0x20,
                },
                [121] = new TR1Object
                {
                    ObjectId = 121,
                    Flags00 = 0x20,
                },
                [122] = new TR1Object
                {
                    ObjectId = 122,
                    Flags00 = 0x20,
                },
                [123] = new TR1Object
                {
                    ObjectId = 123,
                    Flags00 = 0x20,
                },
                [124] = new TR1Object
                {
                    ObjectId = 124,
                    Flags00 = 0x20,
                },
                [125] = new TR1Object
                {
                    ObjectId = 125,
                    Flags00 = 0x20,
                },
                [126] = new TR1Object
                {
                    ObjectId = 126,
                    Flags00 = 0x20,
                },
                [127] = new TR1Object
                {
                    ObjectId = 127,
                    Flags00 = 0x00,
                },
                [128] = new TR1Object
                {
                    ObjectId = 128,
                    Flags00 = 0x00,
                },
                [129] = new TR1Object
                {
                    ObjectId = 129,
                    Flags00 = 0x20,
                },
                [130] = new TR1Object
                {
                    ObjectId = 130,
                    Flags00 = 0x20,
                },
                [131] = new TR1Object
                {
                    ObjectId = 131,
                    Flags00 = 0x20,
                },
                [132] = new TR1Object
                {
                    ObjectId = 132,
                    Flags00 = 0x20,
                },
                [133] = new TR1Object
                {
                    ObjectId = 133,
                    Flags00 = 0x00,
                },
                [134] = new TR1Object
                {
                    ObjectId = 134,
                    Flags00 = 0x00,
                },
                [135] = new TR1Object
                {
                    ObjectId = 135,
                    Flags00 = 0x00,
                },
                [136] = new TR1Object
                {
                    ObjectId = 136,
                    Flags00 = 0x00,
                },
                [137] = new TR1Object
                {
                    ObjectId = 137,
                    Flags00 = 0x20,
                },
                [138] = new TR1Object
                {
                    ObjectId = 138,
                    Flags00 = 0x20,
                },
                [139] = new TR1Object
                {
                    ObjectId = 139,
                    Flags00 = 0x20,
                },
                [140] = new TR1Object
                {
                    ObjectId = 140,
                    Flags00 = 0x20,
                },
                [141] = new TR1Object
                {
                    ObjectId = 141,
                    Flags00 = 0x20,
                },
                [142] = new TR1Object
                {
                    ObjectId = 142,
                    Flags00 = 0x20,
                },
                [143] = new TR1Object
                {
                    ObjectId = 143,
                    Flags00 = 0x20,
                },
                [144] = new TR1Object
                {
                    ObjectId = 144,
                    Flags00 = 0x20,
                },
                [145] = new TR1Object
                {
                    ObjectId = 145,
                    Flags00 = 0x20,
                },
                [146] = new TR1Object
                {
                    ObjectId = 146,
                    Flags00 = 0x21,
                },
                [147] = new TR1Object
                {
                    ObjectId = 147,
                    Flags00 = 0x61,
                },
                [148] = new TR1Object
                {
                    ObjectId = 148,
                    Flags00 = 0x00,
                },
                [149] = new TR1Object
                {
                    ObjectId = 149,
                    Flags00 = 0x00,
                },
                [150] = new TR1Object
                {
                    ObjectId = 150,
                    Flags00 = 0x01,
                },
                [151] = new TR1Object
                {
                    ObjectId = 151,
                    Flags00 = 0x01,
                },
                [152] = new TR1Object
                {
                    ObjectId = 152,
                    Flags00 = 0x00,
                },
                [153] = new TR1Object
                {
                    ObjectId = 153,
                    Flags00 = 0x01,
                },
                [154] = new TR1Object
                {
                    ObjectId = 154,
                    Flags00 = 0x00,
                },
                [155] = new TR1Object
                {
                    ObjectId = 155,
                    Flags00 = 0x01,
                },
                [156] = new TR1Object
                {
                    ObjectId = 156,
                    Flags00 = 0x01,
                },
                [157] = new TR1Object
                {
                    ObjectId = 157,
                    Flags00 = 0x00,
                },
                [158] = new TR1Object
                {
                    ObjectId = 158,
                    Flags00 = 0x01,
                },
                [159] = new TR1Object
                {
                    ObjectId = 159,
                    Flags00 = 0x00,
                },
                [160] = new TR1Object
                {
                    ObjectId = 160,
                    Flags00 = 0x01,
                },
                [161] = new TR1Object
                {
                    ObjectId = 161,
                    Flags00 = 0x00,
                },
                [162] = new TR1Object
                {
                    ObjectId = 162,
                    Flags00 = 0x60,
                },
                [163] = new TR1Object
                {
                    ObjectId = 163,
                    Flags00 = 0x61,
                },
                [164] = new TR1Object
                {
                    ObjectId = 164,
                    Flags00 = 0x01,
                },
                [165] = new TR1Object
                {
                    ObjectId = 165,
                    Flags00 = 0x00,
                },
                [166] = new TR1Object
                {
                    ObjectId = 166,
                    Flags00 = 0x01,
                },
                [167] = new TR1Object
                {
                    ObjectId = 167,
                    Flags00 = 0x00,
                },
                [168] = new TR1Object
                {
                    ObjectId = 168,
                    Flags00 = 0x01,
                },
                [169] = new TR1Object
                {
                    ObjectId = 169,
                    Flags00 = 0x01,
                },
                [170] = new TR1Object
                {
                    ObjectId = 170,
                    Flags00 = 0x20,
                },
                [171] = new TR1Object
                {
                    ObjectId = 171,
                    Flags00 = 0x00,
                },
                [172] = new TR1Object
                {
                    ObjectId = 172,
                    Flags00 = 0x01,
                },
                [173] = new TR1Object
                {
                    ObjectId = 173,
                    Flags00 = 0x01,
                },
                [174] = new TR1Object
                {
                    ObjectId = 174,
                    Flags00 = 0x00,
                },
                [175] = new TR1Object
                {
                    ObjectId = 175,
                    Flags00 = 0x00,
                },
                [176] = new TR1Object
                {
                    ObjectId = 176,
                    Flags00 = 0x01,
                },
                [177] = new TR1Object
                {
                    ObjectId = 177,
                    Flags00 = 0x21,
                },
                [178] = new TR1Object
                {
                    ObjectId = 178,
                    Flags00 = 0x01,
                },
                [179] = new TR1Object
                {
                    ObjectId = 179,
                    Flags00 = 0x20,
                },
                [180] = new TR1Object
                {
                    ObjectId = 180,
                    Flags00 = 0x69,
                },
                [181] = new TR1Object
                {
                    ObjectId = 181,
                    Flags00 = 0x61,
                },
                [182] = new TR1Object
                {
                    ObjectId = 182,
                    Flags00 = 0x68,
                },
            },
        };
    }
}
