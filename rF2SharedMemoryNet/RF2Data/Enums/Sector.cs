namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the sectors of a racing track as defined in the rFactor 2 simulation.
    /// </summary>
    /// <remarks>The sectors are numbered sequentially, with <see cref="Sector1"/> representing the first
    /// sector, <see cref="Sector2"/> the second sector, and <see cref="Sector3"/> the third sector. This enumeration is
    /// commonly used to identify specific track segments in telemetry or timing data.</remarks>
    public enum Sector
    {
        /// <summary>
        /// Sector 3, last sector of the track.
        /// </summary>
        Sector3,

        /// <summary>
        /// Sector 1
        /// </summary>
        Sector1,

        /// <summary>
        /// Sector 2
        /// </summary>
        Sector2
    }
}
