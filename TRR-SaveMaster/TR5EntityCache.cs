using System.Collections.Generic;

namespace TRR_SaveMaster
{
    public class TR5EntityCache
    {
        public static readonly Dictionary<byte, int> LevelRoomCounts = new Dictionary<byte, int>()
        {
            {  1, 242 },    // Streets of Rome
            {  2, 252 },    // Trajan's Markets
            {  3, 130 },    // The Colosseum
            {  4, 169 },    // The Base
            {  5, 195 },    // The Submarine
            {  6, 137 },    // Deepsea Dive
            {  7, 191 },    // Sinking Submarine
            {  8, 243 },    // Gallows Tree
            {  9, 254 },    // Labyrinth
            { 10, 211 },    // Old Mill
            { 11, 165 },    // The 13th Floor
            { 12, 179 },    // Escape with the Iris
            { 14, 218 },    // Red Alert!
        };

        public static readonly Dictionary<byte, int> EligibleStaticMeshCounts = new Dictionary<byte, int>()
        {
            {  1, 3  },     // Streets of Rome
            {  2, 2  },     // Trajan's Markets
            {  3, 0  },     // The Colosseum
            {  4, 3  },     // The Base
            {  5, 0  },     // The Submarine
            {  6, 0  },     // Deepsea Dive
            {  7, 0  },     // Sinking Submarine
            {  8, 0  },     // Gallows Tree
            {  9, 0  },     // Labyrinth
            { 10, 0  },     // Old Mill
            { 11, 17 },     // The 13th Floor
            { 12, 26 },     // Escape with the Iris
            { 14, 28 },     // Red Alert!
        };

        public static readonly Dictionary<byte, int> LevelCameraCounts = new Dictionary<byte, int>()
        {
            {  1, 14 },     // Streets of Rome
            {  2, 5  },     // Trajan's Markets
            {  3, 2  },     // The Colosseum
            {  4, 1  },     // The Base
            {  5, 1  },     // The Submarine
            {  6, 10 },     // Deepsea Dive
            {  7, 1  },     // Sinking Submarine
            {  8, 12 },     // Gallows Tree
            {  9, 7  },     // Labyrinth
            { 10, 19 },     // Old Mill
            { 11, 7  },     // The 13th Floor
            { 12, 22 },     // Escape with the Iris
            { 14, 4  },     // Red Alert!
        };

        public static readonly Dictionary<byte, int> LevelSpotcamCounts = new Dictionary<byte, int>()
        {
            {  1, 24 },     // Streets of Rome
            {  2, 37 },     // Trajan's Markets
            {  3, 18 },     // The Colosseum
            {  4, 10 },     // The Base
            {  5, 0  },     // The Submarine
            {  6, 0  },     // Deepsea Dive
            {  7, 5  },     // Sinking Submarine
            {  8, 11 },     // Gallows Tree
            {  9, 54 },     // Labyrinth
            { 10, 23 },     // Old Mill
            { 11, 56 },     // The 13th Floor
            { 12, 50 },     // Escape with the Iris
            { 14, 16 },     // Red Alert!
        };

        public static readonly Dictionary<int, List<TR5Object>> TR5ObjectsByLevel = new Dictionary<int, List<TR5Object>>()
        {
            [1] = new List<TR5Object> // Streets of Rome
            {
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 414,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 258,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 45,
                    ObjectFlags = 0x0000467B,
                },
                new TR5Object
                {
                    ObjectId = 45,
                    ObjectFlags = 0x0000467B,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 292,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 272,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 283,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 283,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 221,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 196,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 94,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 347,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
            },
            [2] = new List<TR5Object> // Trajan's Markets
            {
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 240,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 421,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 421,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 389,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 94,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 282,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 94,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 282,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 244,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 176,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 65,
                    ObjectFlags = 0x00002E79,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 45,
                    ObjectFlags = 0x0000467B,
                },
                new TR5Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 94,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 292,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 63,
                    ObjectFlags = 0x00001EFB,
                },
                new TR5Object
                {
                    ObjectId = 63,
                    ObjectFlags = 0x00001EFB,
                },
                new TR5Object
                {
                    ObjectId = 63,
                    ObjectFlags = 0x00001EFB,
                },
                new TR5Object
                {
                    ObjectId = 245,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 246,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 158,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 61,
                    ObjectFlags = 0x00002A7B,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 129,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 338,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 129,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 129,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
            },
            [3] = new List<TR5Object> // The Colosseum
            {
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 57,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 245,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 114,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 258,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 196,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 57,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 245,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 395,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 187,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 282,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 186,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 57,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 220,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 61,
                    ObjectFlags = 0x00002A7B,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 259,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 57,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 197,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
            },
            [4] = new List<TR5Object> // The Base
            {
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 85,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 347,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 264,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 202,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 203,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 85,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 414,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 414,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 414,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 142,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 147,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 264,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 85,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 272,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 202,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
            },
            [5] = new List<TR5Object> // The Submarine
            {
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 292,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 338,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 184,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 421,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 419,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 44,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 44,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 185,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 244,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 245,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 421,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 421,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 417,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 419,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 98,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 124,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 124,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 124,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 124,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 264,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 202,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 87,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 201,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 187,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 186,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
            },
            [6] = new List<TR5Object> // Deepsea Dive
            {
                new TR5Object
                {
                    ObjectId = 81,
                    ObjectFlags = 0x00001F7B,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 81,
                    ObjectFlags = 0x00001F7B,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 81,
                    ObjectFlags = 0x00001F7B,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
            },
            [7] = new List<TR5Object> // Sinking Submarine
            {
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 44,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 44,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 412,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 412,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 98,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 243,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 64,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 412,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 203,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 272,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 98,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 173,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 56,
                    ObjectFlags = 0x00004221,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 201,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 98,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 264,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 280,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 274,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 347,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 98,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
            },
            [8] = new List<TR5Object> // Gallows Tree
            {
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00002061,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 182,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 105,
                    ObjectFlags = 0x00002229,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 94,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 94,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 36,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 38,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 40,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 42,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 46,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 48,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 50,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 183,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 241,
                    ObjectFlags = 0x00000029,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
            },
            [9] = new List<TR5Object> // Labyrinth
            {
                new TR5Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 328,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 329,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 331,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 243,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 220,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 396,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 396,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 396,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 396,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 71,
                    ObjectFlags = 0x0000047B,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 71,
                    ObjectFlags = 0x0000047B,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 77,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 117,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
            },
            [10] = new List<TR5Object> // Old Mill
            {
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 89,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 241,
                    ObjectFlags = 0x00000029,
                },
                new TR5Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 173,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 79,
                    ObjectFlags = 0x0000077B,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 278,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 280,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
            },
            [11] = new List<TR5Object> // The 13th Floor
            {
                new TR5Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 374,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 221,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 290,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 69,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 202,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 388,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 69,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 69,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 69,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 412,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 244,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 69,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 438,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 203,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 298,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 235,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 235,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 269,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 388,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 292,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 245,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 236,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 114,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00000269,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 54,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
            },
            [12] = new List<TR5Object> // Escape with the Iris
            {
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 434,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 345,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 413,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 392,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 153,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 418,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 269,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 235,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 236,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 350,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 249,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 440,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 416,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 128,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 235,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 235,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 221,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 304,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 413,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 376,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 244,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 430,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 243,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 387,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 249,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 436,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 235,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 161,
                    ObjectFlags = 0x00000261,
                },
            },
            [14] = new List<TR5Object> // Red Alert!
            {
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 272,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 391,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 391,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 391,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 391,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 391,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 365,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 342,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR5Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 444,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 420,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 114,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 131,
                    ObjectFlags = 0x00002221,
                },
                new TR5Object
                {
                    ObjectId = 452,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 442,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 448,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 398,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 398,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 397,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 397,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x00001E7B,
                },
                new TR5Object
                {
                    ObjectId = 269,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 341,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 341,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 342,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 273,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 428,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 131,
                    ObjectFlags = 0x00002221,
                },
                new TR5Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 446,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 242,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 409,
                    ObjectFlags = 0x00000001,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000201,
                },
                new TR5Object
                {
                    ObjectId = 97,
                    ObjectFlags = 0x00000E71,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 388,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 33,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 388,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 314,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 388,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x00000261,
                },
                new TR5Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 67,
                    ObjectFlags = 0x00001C7B,
                },
                new TR5Object
                {
                    ObjectId = 181,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 149,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 288,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 67,
                    ObjectFlags = 0x00001C7B,
                },
                new TR5Object
                {
                    ObjectId = 180,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 131,
                    ObjectFlags = 0x00002221,
                },
                new TR5Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 375,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 410,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 411,
                    ObjectFlags = 0x00000221,
                },
                new TR5Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 342,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 302,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 286,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x0000067B,
                },
                new TR5Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 432,
                    ObjectFlags = 0x00002261,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000021,
                },
                new TR5Object
                {
                    ObjectId = 349,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00002269,
                },
                new TR5Object
                {
                    ObjectId = 114,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 223,
                    ObjectFlags = 0x00000229,
                },
                new TR5Object
                {
                    ObjectId = 114,
                    ObjectFlags = 0x00000229,
                },
            },
        };
    }
}
