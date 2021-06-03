using EngineCore.Session;

namespace EngineCore.Universe.Equipment
{
    public interface IModule
    {
        int Id { get; set; }
        long OwnerId { get; set; }
        string Name { get; set; }
        Category Category { get; set; }
        bool IsAutoRun { get; set; }
        double ActivationCost { get; set; }

        /// <summary>
        /// Fitting - Compartment number
        /// </summary>
        int Compartment { get; set; }
        /// <summary>
        /// Fitting - Slot position
        /// </summary>
        int Slot { get; set; }

        double ReloadTime { get; set; }
        double Reloading { get; set; }

        void Reload();
        
    }
}
