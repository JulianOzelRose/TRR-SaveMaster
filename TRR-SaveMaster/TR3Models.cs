namespace TRR_SaveMaster
{
    public class TR3Object
    {
        public int ObjectId { get; set; }
        public byte Flags00 { get; set; }
        public string Name { get; set; } = "";
    }

    public sealed class TR3LevelItem
    {
        public int ObjectId { get; set; }
    }
}
