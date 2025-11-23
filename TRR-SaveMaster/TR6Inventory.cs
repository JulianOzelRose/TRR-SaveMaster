using System;

namespace TRR_SaveMaster
{
    public class Inventory
    {
        // Items
        public const UInt16 GPS_SAVE_GAME = 0x49;
        public const UInt16 POISON_ANTIDOTE = 0x91;
        public const UInt16 CHOCOLATE_BAR = 0x94;
        public const UInt16 HEALTH_BANDAGES = 0x96;
        public const UInt16 HEALTH_PILLS = 0x92;
        public const UInt16 LARGE_HEALTH_PACK = 0x95;
        public const UInt16 SMALL_MEDIPACK = 0x206;

        // Ammo
        public const UInt16 SCORPION_X_AMMO = 0x10D;
        public const UInt16 DART_SS_AMMO = 0x10F;
        public const UInt16 DESERT_RANGER_AMMO = 0x11A;
        public const UInt16 MV9_AMMO = 0x11C;
        public const UInt16 RIGG_09_AMMO = 0x11E;
        public const UInt16 VECTOR_R35_AMMO = 0x122;
        public const UInt16 VPACKER_AMMO = 0x127;
        public const UInt16 VIPER_SMG_AMMO = 0x12A;
        public const UInt16 MAG_VEGA_AMMO = 0x12C;
        public const UInt16 K2_IMPACTOR_AMMO = 0x1A9;
        public const UInt16 BORAN_X_AMMO = 0x265;

        // Weapons
        public const UInt16 SCORPION_X = 0x10C;
        public const UInt16 DART_SS = 0x10E;
        public const UInt16 DESERT_RANGER = 0x110;
        public const UInt16 MV9 = 0x11B;
        public const UInt16 RIGG_09 = 0x11D;
        public const UInt16 K2_IMPACTOR = 0x11F;
        public const UInt16 VECTOR_R35 = 0x120;
        public const UInt16 VECTOR_R35_PAIR = 0x121;
        public const UInt16 VPACKER = 0x126;
        public const UInt16 VIPER_SMG = 0x129;
        public const UInt16 MAG_VEGA = 0x12B;
        public const UInt16 SCORPION_X_PAIR = 0x255;
        public const UInt16 BORAN_X = 0x264;
        public const UInt16 CHIRUGAI_BLADE = 0x266;
    }

    public struct InventoryItem
    {
        public UInt16 ClassId { get; set; }
        public Int32 Type { get; set; }
        public Int32 Quantity { get; set; }

        public InventoryItem(UInt16 classId, Int32 type, Int32 quantity)
        {
            ClassId = classId;
            Type = type;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"ClassId: 0x{ClassId:X}, Type: {Type}, Quantity: {Quantity}";
        }
    }
}
