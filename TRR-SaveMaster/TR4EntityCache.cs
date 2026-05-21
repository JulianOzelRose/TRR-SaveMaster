using System.Collections.Generic;

namespace TRR_SaveMaster
{
    public class TR4EntityCache
    {
        public static readonly Dictionary<byte, int> EligibleStaticMeshCounts = new Dictionary<byte, int>()
        {
            {  1, 0  },     // Angkor Wat
            {  2, 0  },     // Race for the Iris
            {  3, 0  },     // The Tomb of Seth
            {  4, 2  },     // Burial Chambers
            {  5, 0  },     // Valley of the Kings
            {  6, 0  },     // KV5
            {  7, 5  },     // Temple of Karnak
            {  8, 0  },     // The Great Hypostyle Hall
            {  9, 0  },     // Sacred Lake
            { 11, 13 },     // Tomb of Semerkhet
            { 12, 0  },     // Guardian of Semerkhet
            { 13, 7  },     // Desert Railroad
            { 14, 0  },     // Alexandria
            { 15, 11 },     // Coastal Ruins
            { 16, 8  },     // Pharos, Temple of Isis
            { 17, 12 },     // Cleopatra's Palaces
            { 18, 61 },     // Catacombs
            { 19, 20 },     // Temple of Poseidon
            { 20, 16 },     // The Lost Library
            { 21, 0  },     // Hall of Demetrius
            { 22, 6  },     // City of the Dead
            { 23, 3  },     // Trenches
            { 24, 5  },     // Chambers of Tulun
            { 25, 0  },     // Street Bazaar
            { 26, 3  },     // Citadel Gate
            { 27, 2  },     // Citadel
            { 28, 11 },     // The Sphinx Complex
            { 30, 0  },     // Underneath the Sphinx
            { 31, 0  },     // Menkaure's Pyramid
            { 32, 0  },     // Inside Menkaure's Pyramid 
            { 33, 4  },     // The Mastabas
            { 34, 3  },     // The Great Pyramid
            { 35, 17 },     // Khufu's Queens Pyramids
            { 36, 0  },     // Inside the Great Pyramid
            { 37, 0  },     // Temple of Horus
            { 38, 0  },     // Temple of Horus (Part 2)
            { 40, 18 },     // The Times Exclusive
        };

        public static readonly Dictionary<byte, int> LevelCameraCounts = new Dictionary<byte, int>()
        {
            {  1, 7  },     // Angkor Wat
            {  2, 7  },     // Race for the Iris
            {  3, 5  },     // The Tomb of Seth
            {  4, 6  },     // Burial Chambers
            {  5, 0  },     // Valley of the Kings
            {  6, 0  },     // KV5
            {  7, 15 },     // Temple of Karnak
            {  8, 2  },     // The Great Hypostyle Hall
            {  9, 2  },     // Sacred Lake
            { 11, 7  },     // Tomb of Semerkhet
            { 12, 0  },     // Guardian of Semerkhet
            { 13, 8  },     // Desert Railroad
            { 14, 0  },     // Alexandria
            { 15, 5  },     // Coastal Ruins
            { 16, 4  },     // Pharos, Temple of Isis
            { 17, 2  },     // Cleopatra's Palaces
            { 18, 5  },     // Catacombs
            { 19, 1  },     // Temple of Poseidon
            { 20, 2  },     // The Lost Library
            { 21, 0  },     // Hall of Demetrius
            { 22, 12 },     // City of the Dead
            { 23, 10 },     // Trenches
            { 24, 6  },     // Chambers of Tulun
            { 25, 10 },     // Street Bazaar
            { 26, 8  },     // Citadel Gate
            { 27, 14 },     // Citadel
            { 28, 1  },     // The Sphinx Complex
            { 30, 5  },     // Underneath the Sphinx
            { 31, 1  },     // Menkaure's Pyramid
            { 32, 4  },     // Inside Menkaure's Pyramid
            { 33, 2  },     // The Mastabas
            { 34, 0  },     // The Great Pyramid
            { 35, 1  },     // Khufu's Queens Pyramids
            { 36, 4  },     // Inside the Great Pyramid
            { 37, 0  },     // Temple of Horus
            { 38, 2  },     // Temple of Horus (Part 2)
            { 40, 1  },     // The Times Exclusive
        };

        public static readonly Dictionary<byte, int> LevelSpotcamCounts = new Dictionary<byte, int>()
        {
            {  1, 0  },     // Angkor Wat
            {  2, 36 },     // Race for the Iris
            {  3, 53 },     // The Tomb of Seth
            {  4, 28 },     // Burial Chambers
            {  5, 9  },     // Valley of the Kings
            {  6, 0  },     // KV5
            {  7, 12 },     // Temple of Karnak
            {  8, 8  },     // The Great Hypostyle Hall
            {  9, 24 },     // Sacred Lake
            { 11, 29 },     // Tomb of Semerkhet
            { 12, 10 },     // Guardian of Semerkhet
            { 13, 40 },     // Desert Railroad
            { 14, 4  },     // Alexandria
            { 15, 22 },     // Coastal Ruins
            { 16, 0  },     // Pharos, Temple of Isis
            { 17, 10 },     // Cleopatra's Palaces
            { 18, 4  },     // Catacombs
            { 19, 0  },     // Temple of Poseidon
            { 20, 25 },     // The Lost Library
            { 21, 0  },     // Hall of Demetrius
            { 22, 0  },     // City of the Dead
            { 23, 4  },     // Trenches
            { 24, 15 },     // Chambers of Tulun
            { 25, 4  },     // Street Bazaar
            { 26, 21 },     // Citadel Gate
            { 27, 14 },     // Citadel
            { 28, 0  },     // The Sphinx Complex
            { 30, 4  },     // Underneath the Sphinx
            { 31, 0  },     // Menkaure's Pyramid
            { 32, 0  },     // Inside Menkaure's Pyramid
            { 33, 3  },     // The Mastabas
            { 34, 11 },     // The Great Pyramid
            { 35, 0  },     // Khufu's Queens Pyramids
            { 36, 8  },     // Inside the Great Pyramid
            { 37, 9  },     // Temple of Horus
            { 38, 0  },     // Temple of Horus (Part 2)
            { 40, 21 },     // The Times Exclusive
        };

        public static readonly Dictionary<int, List<TR4Object>> TR4ObjectsByLevel = new Dictionary<int, List<TR4Object>>()
        {
            [1] = new List<TR4Object> // Angkor Wat
            {
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x0000707B,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 397,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 329,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 397,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 115,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 329,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 329,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 329,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 329,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
            },
            [2] = new List<TR4Object> // Race for the Iris
            {
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 317,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x0000707B,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 39,
                    ObjectFlags = 0x0000707B,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 315,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 315,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 73,
                    ObjectFlags = 0x0000067B,
                },
            },
            [3] = new List<TR4Object> // The Tomb of Seth
            {
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 187,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000327B,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 134,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 261,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 188,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 172,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 176,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
            },
            [4] = new List<TR4Object> // Burial Chambers
            {
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 178,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 261,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 383,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 383,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 136,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 344,
                    ObjectFlags = 0x00002201,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 177,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 176,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 262,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
            },
            [5] = new List<TR4Object> // Valley of the Kings
            {
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 32,
                    ObjectFlags = 0x00000279,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 34,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000327B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 37,
                    ObjectFlags = 0x0000327B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 363,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
            },
            [6] = new List<TR4Object> // KV5
            {
                new TR4Object
                {
                    ObjectId = 32,
                    ObjectFlags = 0x00000279,
                },
                new TR4Object
                {
                    ObjectId = 34,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
            },
            [7] = new List<TR4Object> // Temple of Karnak
            {
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 262,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 261,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 176,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 188,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 204,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
            },
            [8] = new List<TR4Object> // The Great Hypostyle Hall
            {
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 285,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 165,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 165,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 165,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 187,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 313,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 316,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 316,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 316,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
            },
            [9] = new List<TR4Object> // Sacred Lake
            {
                new TR4Object
                {
                    ObjectId = 124,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 177,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 315,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
            },
            [11] = new List<TR4Object> // Tomb of Semerkhet
            {
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 112,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 346,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 108,
                    ObjectFlags = 0x00000239,
                },
                new TR4Object
                {
                    ObjectId = 109,
                    ObjectFlags = 0x00000239,
                },
                new TR4Object
                {
                    ObjectId = 110,
                    ObjectFlags = 0x00000239,
                },
                new TR4Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 111,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 244,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 157,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 158,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 159,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 264,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 193,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 194,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 138,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 179,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 86,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 87,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
            },
            [12] = new List<TR4Object> // Guardian of Semerkhet
            {
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 181,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x00001E7B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 180,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 317,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 169,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 171,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
            },
            [13] = new List<TR4Object> // Desert Railroad
            {
                new TR4Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 246,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 34,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 34,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 34,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 34,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 361,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
            },
            [14] = new List<TR4Object> // Alexandria
            {
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 57,
                    ObjectFlags = 0x00004269,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 370,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
            },
            [15] = new List<TR4Object> // Coastal Ruins
            {
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 194,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 356,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 356,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 193,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 147,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 293,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 212,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 203,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 232,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
            },
            [16] = new List<TR4Object> // Pharos, Temple of Isis
            {
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 93,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 269,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 270,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 334,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 231,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 186,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 271,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 250,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 186,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 231,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 186,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 231,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 249,
                    ObjectFlags = 0x00000229,
                },
            },
            [17] = new List<TR4Object> // Cleopatra's Palaces
            {
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 255,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 81,
                    ObjectFlags = 0x0000027B,
                },
                new TR4Object
                {
                    ObjectId = 81,
                    ObjectFlags = 0x0000027B,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 257,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 184,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 168,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 328,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 269,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 164,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 104,
                    ObjectFlags = 0x00000C7B,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 264,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 145,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 186,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 253,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 327,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 327,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 254,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 196,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 195,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 75,
                    ObjectFlags = 0x0000067B,
                },
            },
            [18] = new List<TR4Object> // Catacombs
            {
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 383,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 88,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 153,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 153,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 153,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 153,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 88,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 157,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
            },
            [19] = new List<TR4Object> // Temple of Poseidon
            {
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 88,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 88,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 339,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 256,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 425,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 88,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 35,
                    ObjectFlags = 0x00003AFB,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
            },
            [20] = new List<TR4Object> // The Lost Library
            {
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 245,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002021,
                },
                new TR4Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002021,
                },
                new TR4Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002021,
                },
                new TR4Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002021,
                },
                new TR4Object
                {
                    ObjectId = 426,
                    ObjectFlags = 0x00002021,
                },
                new TR4Object
                {
                    ObjectId = 262,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 262,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 262,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 86,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 176,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 140,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 140,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 177,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 65,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 180,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 140,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 86,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 185,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 177,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 177,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 313,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 160,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 86,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 86,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 139,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 261,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 140,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 53,
                    ObjectFlags = 0x00003EFB,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 158,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 157,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 159,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 335,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
            },
            [21] = new List<TR4Object> // Hall of Demetrius
            {
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 184,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
            },
            [22] = new List<TR4Object> // City of the Dead
            {
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 319,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 31,
                    ObjectFlags = 0x00000279,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 101,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 363,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 361,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 120,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 87,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 87,
                    ObjectFlags = 0x00001279,
                },
                new TR4Object
                {
                    ObjectId = 107,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 121,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 370,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
            },
            [23] = new List<TR4Object> // Trenches
            {
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 31,
                    ObjectFlags = 0x00000279,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 127,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 187,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 163,
                    ObjectFlags = 0x00000E01,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 107,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 179,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 363,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 313,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 162,
                    ObjectFlags = 0x00001EFB,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
            },
            [24] = new List<TR4Object> // Chambers of Tulun
            {
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 326,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 77,
                    ObjectFlags = 0x00001E7B,
                },
                new TR4Object
                {
                    ObjectId = 178,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 31,
                    ObjectFlags = 0x00000279,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 327,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 361,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 390,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 325,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 317,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 313,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
            },
            [25] = new List<TR4Object> // Street Bazaar
            {
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 173,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 157,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 173,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 157,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 447,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x00001E7B,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 202,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 107,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 261,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 95,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 189,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 190,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00004261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 201,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 107,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 107,
                    ObjectFlags = 0x00000021,
                },
            },
            [26] = new List<TR4Object> // Citadel Gate
            {
                new TR4Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 63,
                    ObjectFlags = 0x00001E7B,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 188,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 31,
                    ObjectFlags = 0x00000279,
                },
                new TR4Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 313,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 445,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 337,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
            },
            [27] = new List<TR4Object> // Citadel
            {
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 147,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 364,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 359,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 61,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 61,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 157,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 158,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 159,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 363,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 363,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 315,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 382,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 61,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 61,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
            },
            [28] = new List<TR4Object> // The Sphinx Complex
            {
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 187,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 188,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 203,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 295,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 284,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 318,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
            },
            [30] = new List<TR4Object> // Underneath the Sphinx
            {
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 260,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 261,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 262,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 263,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 133,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 179,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 179,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 179,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 179,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 361,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 175,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 118,
                    ObjectFlags = 0x00000269,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 308,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 178,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 176,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 177,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 243,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 343,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 342,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 341,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x00001E7B,
                },
                new TR4Object
                {
                    ObjectId = 49,
                    ObjectFlags = 0x00001E7B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 141,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 166,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 137,
                    ObjectFlags = 0x00000261,
                },
            },
            [31] = new List<TR4Object> // Menkaure's Pyramid
            {
                new TR4Object
                {
                    ObjectId = 127,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000467B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000467B,
                },
                new TR4Object
                {
                    ObjectId = 214,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 295,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
            },
            [32] = new List<TR4Object> // Inside Menkaure's Pyramid
            {
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 127,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 341,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 342,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 343,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 340,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 170,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 321,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 146,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 180,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 79,
                    ObjectFlags = 0x0000027B,
                },
                new TR4Object
                {
                    ObjectId = 123,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 122,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 295,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 307,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
            },
            [33] = new List<TR4Object> // The Mastabas
            {
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 174,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 181,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 296,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 231,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 232,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 320,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 71,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 69,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 67,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 182,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 312,
                    ObjectFlags = 0x00002261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
            },
            [34] = new List<TR4Object> // The Great Pyramid
            {
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 361,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 126,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 332,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
            },
            [35] = new List<TR4Object> // Khufu's Queens Pyramids
            {
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 362,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 363,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 294,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 351,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 356,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 361,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000467B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 55,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 330,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 59,
                    ObjectFlags = 0x0000467B,
                },
                new TR4Object
                {
                    ObjectId = 295,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 84,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 125,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 324,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 183,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 79,
                    ObjectFlags = 0x0000027B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
            },
            [36] = new List<TR4Object> // Inside the Great Pyramid
            {
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 356,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 295,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 451,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 443,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 381,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 43,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 267,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 41,
                    ObjectFlags = 0x0000267B,
                },
                new TR4Object
                {
                    ObjectId = 354,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 265,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 268,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 152,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 424,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 266,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 247,
                    ObjectFlags = 0x00000029,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 437,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
            },
            [37] = new List<TR4Object> // Temple of Horus
            {
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 113,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 300,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 102,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 449,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 135,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 102,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 113,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 102,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 113,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 148,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 90,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 345,
                    ObjectFlags = 0x00002201,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
            },
            [38] = new List<TR4Object> // Temple of Horus
            {
                new TR4Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 132,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 155,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 323,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 154,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 113,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 433,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 45,
                    ObjectFlags = 0x0000127B,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 394,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 422,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 348,
                    ObjectFlags = 0x00002221,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 252,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 306,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
            },
            [40] = new List<TR4Object> // The Times Exclusive
            {
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 352,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 408,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 151,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 453,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 435,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 441,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 231,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 423,
                    ObjectFlags = 0x00000221,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 150,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 47,
                    ObjectFlags = 0x00001A7B,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 130,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 370,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 431,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 457,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 366,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 51,
                    ObjectFlags = 0x0000077B,
                },
                new TR4Object
                {
                    ObjectId = 315,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 367,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 144,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 0,
                    ObjectFlags = 0x00000079,
                },
                new TR4Object
                {
                    ObjectId = 83,
                    ObjectFlags = 0x00000001,
                },
                new TR4Object
                {
                    ObjectId = 322,
                    ObjectFlags = 0x00002269,
                },
                new TR4Object
                {
                    ObjectId = 127,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 356,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 358,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 353,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 336,
                    ObjectFlags = 0x00000201,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 106,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 429,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 427,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 439,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 368,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 156,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 357,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 355,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 91,
                    ObjectFlags = 0x0000067B,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 143,
                    ObjectFlags = 0x00000021,
                },
                new TR4Object
                {
                    ObjectId = 455,
                    ObjectFlags = 0x00000261,
                },
                new TR4Object
                {
                    ObjectId = 369,
                    ObjectFlags = 0x00000229,
                },
                new TR4Object
                {
                    ObjectId = 373,
                    ObjectFlags = 0x00000229,
                },
            },
        };
    }
}
