using System.Collections.Generic;

namespace TRR_SaveMaster
{
    public class EntityMock
    {
        public int BaseOffset { get; set; }
        public Dictionary<int, int> Substructures { get; set; } = new Dictionary<int, int>();
        public int? APB_Loop_Counter { get; set; }
        public int? EntityType { get; set; }

        // New properties
        public int ID { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }
        public int ActiveFlag { get; set; }
        public int ObjTypeID { get; set; }
        public int RoomMeta { get; set; }
        public int ExtraRoomData { get; set; }

        public EntityMock(int baseOffset)
        {
            BaseOffset = baseOffset;
        }

        public class GmxObjectInfo
        {
            public string Name { get; set; }
            public int Index { get; set; }
        }
    }
}
