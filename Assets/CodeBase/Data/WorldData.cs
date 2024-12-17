using System;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public WorldData(string initialLevel)
        {
            PositiononLevel = new PositionOnLevel(initialLevel);
        }

        public PositionOnLevel PositiononLevel { get; set; }
    }
}