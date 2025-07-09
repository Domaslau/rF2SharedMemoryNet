namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the various files or views available in the application.
    /// </summary>
    /// <remarks>Each value in the <see cref="MemoryFile"/> enumeration corresponds to a specific functional area or
    /// display within the application. Use this enumeration to specify or identify the active file.</remarks>
    public enum MemoryFile
    {
        /// <summary>
        /// Telemetry file
        /// </summary>
        Telemetry,
        /// <summary>
        /// Scoring file
        /// </summary>
        Scoring,
        /// <summary>
        /// Rules file
        /// </summary>
        Rules,
        /// <summary>
        /// Force Feedback (FFB) file
        /// </summary>
        FFB,
        /// <summary>
        /// Graphics file
        /// </summary>
        Graphics,
        /// <summary>
        /// Pit information file
        /// </summary>
        PitInfo,
        /// <summary>
        /// Weather file
        /// </summary>
        Weather,
        /// <summary>
        /// Extended information file
        /// </summary>
        Extended,
        /// <summary>
        /// Hardware control file
        /// </summary>
        HWControl,
        /// <summary>
        /// Weather control file
        /// </summary>
        WeatherControl,
        /// <summary>
        /// Rules control file
        /// </summary>
        RulesControl,
        /// <summary>
        /// Plugin control file
        /// </summary>
        PluginControl,
    }
}
