namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the various states of a pit stop in rFactor 2.
    /// </summary>
    /// <remarks>This enumeration defines the progression of a pit stop, from no pit activity to requesting,
    /// entering, stopping, and exiting the pit. It is typically used to track or manage the pit stop state during a
    /// race simulation.</remarks>
    public enum PitState
    {
        /// <summary>
        /// No pit activity
        /// </summary>
        None,

        /// <summary>
        /// Requeted pit stop
        /// </summary>
        Request,

        /// <summary>
        /// Entering the pit area
        /// </summary>
        Entering,

        /// <summary>
        /// Stopped in the pit area
        /// </summary>
        Stopped,

        /// <summary>
        /// Exiting the pit area
        /// </summary>
        Exiting
    }
}
