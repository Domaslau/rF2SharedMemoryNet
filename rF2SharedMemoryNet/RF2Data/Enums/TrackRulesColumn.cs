namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the various lane options and states used in RF2 track rules.
    /// </summary>
    /// <remarks>This enumeration defines both static lane choices (e.g., <see cref="LeftLane"/>, <see
    /// cref="MiddleLane"/>)   and dynamic states (e.g., <see cref="FreeChoice"/>, <see cref="Pending"/>).   It is
    /// primarily used to specify lane assignments and track rule states for participants.</remarks>
    public enum TrackRulesColumn
    {
        /// <summary>
        /// Left lane
        /// </summary>
        LeftLane,

        /// <summary>
        /// Mid-left lane
        /// </summary>
        MidLefLane,

        /// <summary>
        /// Middle lane
        /// </summary>
        MiddleLane,

        /// <summary>
        /// Mid-right lane
        /// </summary>
        MidrRghtLane,

        /// <summary>
        /// Right lane
        /// </summary>
        RightLane,

        /// <summary>
        /// Maximum number of static lane choices.
        /// </summary>
        MaxLanes,

        /// <summary>
        /// Invalid lane state
        /// </summary>
        Invalid = MaxLanes,

        /// <summary>
        /// Free choice lane state
        /// </summary>
        FreeChoice,

        /// <summary>
        /// Pending lane state
        /// </summary>
        Pending,

        /// <summary>
        /// Represents the maximum number of track rules columns defined.
        /// </summary>
        Maximum
    }
}
