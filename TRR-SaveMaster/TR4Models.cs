namespace TRR_SaveMaster
{
    public class TR4Object
    {
        public int ObjectId { get; set; }
        public uint ObjectFlags { get; set; }
        public byte Flags00
        {
            get { return (byte)(ObjectFlags & 0xFF); }
        }
        public string Name { get; set; } = "";
    }

    public sealed class TR4LevelItem
    {
        public int ObjectId { get; set; }
    }
}
