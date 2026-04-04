namespace TRR_SaveMaster
{
    public class TR1Object
    {
        public int ObjectId { get; set; }
        public byte Flags00 { get; set; }
        public string Name { get; set; } = "";
    }

    public sealed class TR1LevelItem
    {
        public int ObjectId { get; set; }
    }
}
