namespace TRR_SaveMaster
{
    public class Savegame
    {
        public int Offset { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public Savegame(int savegameOffset, int saveNumber, string levelName)
        {
            Number = saveNumber;
            Name = levelName;
            Offset = savegameOffset;
        }

        public override string ToString()
        {
            return $"{Name} - {Number}";
        }
    }
}
