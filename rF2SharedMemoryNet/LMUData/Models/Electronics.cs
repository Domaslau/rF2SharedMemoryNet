namespace rF2SharedMemoryNet.LMUData.Models
{
    /// <summary>
    /// Represents the electronic control settings of a vehicle, including traction control, anti-lock brakes, and
    /// engine mapping.
    /// </summary>
    /// <remarks> Used only for Le Mans Ultimate game data. This class provides data of multiple electronic assist systems.</remarks>
    public class Electronics
    {
        /// <summary>
        /// Gets or sets the level of traction control applied to the vehicle.
        /// </summary>
        public int TractionControl { get; set; } = 0;
        /// <summary>
        /// Gets or sets the slip value for the traction control system.
        /// </summary>
        public int TractionControlSlip { get; set; } = 0;
        /// <summary>
        /// Gets or sets the percentage of engine power reduction applied by the traction control system.
        /// </summary>
        public int TractionControlCut { get; set; } = 0;
        /// <summary>
        /// Gets or sets the status of the anti-lock braking system (ABS).
        /// </summary>
        public int AntiLockBrakes { get; set; } = 0;
        /// <summary>
        /// Gets or sets the engine map identifier.
        /// </summary>
        public int EngineMap { get; set; } = 0;

    }
}
