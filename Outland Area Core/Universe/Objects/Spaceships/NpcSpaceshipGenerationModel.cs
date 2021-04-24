using System;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    [Serializable]
    public class NpcSpaceshipGenerationModel
    {
        public int SpaceShipClass { get; set; }
        public int SpaceShipType { get; set; }
        public int Standing { get; set; }
        public string Message { get; set; }

        public NpcSpaceshipGenerationModel(int spaceShipClass, int spaceShipType, int standing, string message)
        {
            SpaceShipClass = spaceShipClass;
            SpaceShipType = spaceShipType;
            Standing = standing;
            Message = message;
        }
    }
}