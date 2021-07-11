namespace EngineCore.Universe.Characters
{
    public class CharacterScheme
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CelestialObjectId { get; set; }

        // TODO: Add ranks classification
        public string Rank { get; set; }
    }
}
