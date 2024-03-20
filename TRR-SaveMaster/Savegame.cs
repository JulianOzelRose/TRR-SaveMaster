using System;

namespace TRR_SaveMaster
{
    public enum Platform
    {
        PC,
        PlayStation4,
        NintendoSwitch
    }

    public enum GameMode
    {
        Normal,
        Plus
    }

    public static class PlatformExtensions
    {
        public static string ToFriendlyString(this Platform platform)
        {
            switch (platform)
            {
                case Platform.PC:
                    return "PC";
                case Platform.PlayStation4:
                    return "PS4";
                case Platform.NintendoSwitch:
                    return "Nintendo Switch";
                default:
                    return platform.ToString();
            }
        }
    }

    public class Savegame
    {
        public int Offset { get; set; }
        public Int32 Number { get; set; }
        public int Slot { get; set; }
        public string Name { get; set; }
        public GameMode Mode { get; set; }

        public Savegame(int savegameOffset, int slot, Int32 saveNumber, string levelName, GameMode gameMode)
        {
            Number = saveNumber;
            Name = levelName;
            Offset = savegameOffset;
            Slot = slot;
            Mode = gameMode;
        }

        public void UpdateDisplayName(string levelName, Int32 saveNumber, GameMode gameMode)
        {
            Name = levelName;
            Number = saveNumber;
            Mode = gameMode;
        }

        public override string ToString()
        {
            string modeSuffix = Mode == GameMode.Plus ? "+" : "";
            return $"{Name}{modeSuffix} - {Number}";
        }
    }
}
