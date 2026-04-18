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

    public sealed class TR1CatEntry
    {
        public int ObjectId { get; set; }
        public int Weight { get; set; }
        public int Meta2 { get; set; }

        public TR1CatEntry(int objectId, int weight, int meta2)
        {
            ObjectId = objectId;
            Weight = weight;
            Meta2 = meta2;
        }
    }
}
