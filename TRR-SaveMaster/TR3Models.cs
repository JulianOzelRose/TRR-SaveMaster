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

    public sealed class TR3CatEntry
    {
        public int ObjectId { get; set; }
        public int Weight { get; set; }
        public int Meta2 { get; set; }

        public TR3CatEntry(int objectId, int weight, int meta2)
        {
            ObjectId = objectId;
            Weight = weight;
            Meta2 = meta2;
        }
    }
}
