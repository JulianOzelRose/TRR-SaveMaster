namespace TRR_SaveMaster
{
    public class EntityMock
    {
        // APB values
        public int APB_Loop_Counter { get; set; }
        public int Second_APB_Value { get; set; }

        // Types and IDs
        public int ID { get; set; }
        public int EntityType { get; set; }
        public int ObjTypeID { get; set; }

        // Other flags
        public bool IsPlayable { get; set; }
        public int ActiveFlag { get; set; }
        public int RoomMeta { get; set; }

        public EntityMock()
        {

        }
    }
}