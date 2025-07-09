namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the status of the ignition and starter in an RF2 system.
    /// </summary>
    /// <remarks>This enumeration is used to indicate the current state of the ignition and starter mechanism.
    /// The values correspond to distinct operational states, such as when the ignition is off,  when the ignition is
    /// active, or when both the ignition and starter are engaged.</remarks>
    public enum IgnitionStarterStatus
    {
        /// <summary>
        /// Both off
        /// </summary>
        Off = 0,
        /// <summary>
        /// Only ignition is on
        /// </summary>
        Ignition = 1,
        /// <summary>
        /// Ignition and starter are both on
        /// </summary>
        IgnitionAndStarter = 2
    }
}
