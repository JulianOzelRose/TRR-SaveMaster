using System;

namespace TRR_SaveMaster
{
    public class Inventory
    {
        // Items
        public const ushort POISON_ANTIDOTE = 0x91;
        public const ushort CHOCOLATE_BAR = 0x94;
        public const ushort HEALTH_BANDAGES = 0x96;
        public const ushort HEALTH_PILLS = 0x92;
        public const ushort LARGE_HEALTH_PACK = 0x95;
        public const ushort SMALL_MEDIPACK = 0x206;

        // Ammo
        public const ushort SCORPION_X_AMMO = 0x10D;
        public const ushort DART_SS_AMMO = 0x10F;
        public const ushort DESERT_RANGER_AMMO = 0x11A;
        public const ushort MV9_AMMO = 0x11C;
        public const ushort RIGG_09_AMMO = 0x11E;
        public const ushort VECTOR_R35_AMMO = 0x122;
        public const ushort VPACKER_AMMO = 0x127;
        public const ushort VIPER_SMG_AMMO = 0x12A;
        public const ushort MAG_VEGA_AMMO = 0x12C;
        public const ushort K2_IMPACTOR_AMMO = 0x1A9;
        public const ushort BORAN_X_AMMO = 0x265;

        // Weapons
        public const ushort SCORPION_X = 0x10C;
        public const ushort DART_SS = 0x10E;
        public const ushort DESERT_RANGER = 0x110;
        public const ushort MV9 = 0x11B;
        public const ushort RIGG_09 = 0x11D;
        public const ushort K2_IMPACTOR = 0x11F;
        public const ushort VECTOR_R35 = 0x120;
        public const ushort VECTOR_R35_PAIR = 0x121;
        public const ushort VPACKER = 0x126;
        public const ushort VIPER_SMG = 0x129;
        public const ushort MAG_VEGA = 0x12B;
        public const ushort SCORPION_X_PAIR = 0x255;
        public const ushort BORAN_X = 0x264;
        public const ushort CHIRUGAI_BLADE = 0x266;
    }

    public struct InventoryItem
    {
        public ushort ClassId { get; set; }
        public Int32 Type { get; set; }
        public Int32 Quantity { get; set; }

        public InventoryItem(ushort classId, int type, int quantity)
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
