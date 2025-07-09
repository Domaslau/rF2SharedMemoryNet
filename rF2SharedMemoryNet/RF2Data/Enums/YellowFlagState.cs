namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the various states of a yellow flag during a race.
    /// </summary>
    /// <remarks>The <see cref="YellowFlagState"/> enum defines the progression of states that occur during a
    /// yellow flag scenario. These states are used to manage race conditions, such as closing pits, opening pits, and
    /// resuming racing.</remarks>
    public enum YellowFlagState
    {
        /// <summary>
        /// Invalid state, used for error handling or uninitialized values.
        /// </summary>
        Invalid = -1,

        /// <summary>
        /// Normal racing conditions without any yellow flag.
        /// </summary>
        NoYellowFlag = 0,

        /// <summary>
        /// Pending yellow flag state, indicating that a yellow flag condition is about to be applied.
        /// </summary>
        PendingYellowFlag = 1,

        /// <summary>
        /// Pits are closed, typically during a yellow flag condition to prevent pit stops.
        /// </summary>
        PitsClosed = 2,

        /// <summary>
        /// Lead allowed to pit
        /// </summary>
        PitLeadLap = 3,

        /// <summary>
        /// Pits are open, allowing vehicles to enter the pits during a yellow flag condition.
        /// </summary>
        PitsOpen = 4,

        /// <summary>
        /// Last lap of Yellow Flag
        /// </summary>
        LastLap = 5,

        /// <summary>
        /// Resume racing after a yellow flag condition has been cleared or resolved.
        /// </summary>
        ResumeRacing = 6,

        /// <summary>
        /// Race is halted
        /// </summary>
        RaceHalt = 7
    }
}
