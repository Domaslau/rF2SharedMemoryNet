namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the various stages of track rules in a racing simulation.
    /// </summary>
    /// <remarks>This enumeration defines the distinct phases of track rules, including formation laps, normal
    /// racing,  and caution periods. It is primarily used to manage and update the state of the race based on the 
    /// current track conditions.</remarks>
    public enum TrackRulesStage
    {
        /// <summary>
        /// Initialization of the formation lap.
        /// </summary>
        FormationInit = 0,

        /// <summary>
        /// Update of the formation lap.
        /// </summary>
        FormationUpdate,

        /// <summary>
        /// Normal update
        /// </summary>
        Normal,

        /// <summary>
        /// Initialization of a full-course yellow.
        /// </summary>
        CautionInit,

        /// <summary>
        /// Update of a full-course yellow.
        /// </summary>
        CautionUpdate,

        /// <summary>
        /// Maximum number of stages.
        /// </summary>
        Maximum
    }
}
