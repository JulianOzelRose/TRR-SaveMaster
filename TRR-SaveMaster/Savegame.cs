using System;

namespace TRR_SaveMaster
{
    public class Savegame
    {
        public int Offset { get; set; }
        public Int32 Number { get; set; }
        public int Slot { get; set; }
        public string Name { get; set; }

        public Savegame(int savegameOffset, int slot, Int32 saveNumber, string levelName)
        {
            Number = saveNumber;
            Name = levelName;
            Offset = savegameOffset;
            Slot = slot;
        }

        public void UpdateDisplayName(string levelName, Int32 saveNumber)
        {
            Name = levelName;
            Number = saveNumber;
        }

        public override string ToString()
        {
            return $"{Name} - {Number}";
        }
    }
}
