namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Specifies the behavior for counting laps and recording lap times in a racing simulation.
    /// </summary>
    /// <remarks>This enumeration is used to define whether a lap should be counted and whether the lap time
    /// should be recorded. It is typically used in scenarios where lap counting and timing need to be controlled based
    /// on specific conditions.</remarks>
    public enum CountLapFlag
    {
        /// <summary>
        /// Do not count the lap and do not record the time.
        /// </summary>
        DoNotCountLap,
        /// <summary>
        /// Count the lap but do not record the time
        /// </summary>
        CountLapButNotTime,
        /// <summary>
        /// Count the lap and record the time
        /// </summary>
        CountLapAndTime,
    }
}
