namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the various phases of a racing session in rFactor2.
    /// </summary>
    /// <remarks>This enumeration defines the distinct stages of a racing session, such as preparation, active
    /// racing, and post-session states. Use these values to determine the current phase of the session or to handle
    /// specific logic based on the session's state.</remarks>
    public enum GamePhase
    {
        /// <summary>
        /// In Garage
        /// </summary>
        Garage,

        /// <summary>
        /// Warm-up phase
        /// </summary>
        WarmUp,

        /// <summary>
        /// Grid walk
        /// </summary>
        GridWalk,

        /// <summary>
        /// Formation lap
        /// </summary>
        Formation,

        /// <summary>
        /// Countdown to start
        /// </summary>
        Countdown,

        /// <summary>
        /// Green flag
        /// </summary>
        GreenFlag,

        /// <summary>
        /// Full course yellow flag
        /// </summary>
        FullCourseYellow,

        /// <summary>
        /// Session has stopped, e.g. due to a crash or manual stop
        /// </summary>
        SessionStopped,

        /// <summary>
        /// Session is over
        /// </summary>
        SessionOver,

        /// <summary>
        /// Paused or heartbeat phase.
        /// </summary>
        PausedOrHeartbeat,

        /// <summary>
        /// Under yellow flag conditions
        /// </summary>
        UnderYellowFlag,

        /// <summary>
        /// Under blue flag conditions
        /// </summary>
        UnderBlueFlag
    }
}
