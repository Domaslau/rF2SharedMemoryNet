namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the set of commands used to manage vehicle behavior and penalties during a full-course yellow in RF2.
    /// </summary>
    /// <remarks>This enumeration defines commands for adding, removing, or penalizing vehicles based on their
    /// actions during a full-course yellow. Commands are typically used to enforce race rules and manage vehicle
    /// states.</remarks>
    public enum TrackRulesCommand
    {
        /// <summary>
        /// Crossed s/f line for first time after full-course yellow was called
        /// </summary>
        AddFromTrack,

        /// <summary>
        /// Exited pit during full-course yellow
        /// </summary>
        AddFromPit,

        /// <summary>
        /// During a full-course yellow, the admin reversed a disqualification
        /// </summary>
        AddFromUndq,

        /// <summary>
        /// Entered pit during full-course yellow
        /// </summary>
        RemoveToPit,

        /// <summary>
        /// Vehicle DNF'd during full-course yellow
        /// </summary>
        RemoveToDnf,

        /// <summary>
        /// Vehicle DQ'd during full-course yellow
        /// </summary>
        RemoveToDq,

        /// <summary>
        /// Vehicle unloaded (possibly kicked out or banned) during full-course yellow
        /// </summary>
        RemoveToUnloaded,

        /// <summary>
        /// Misbehavior during full-course yellow, resulting in the penalty of being moved to the back of their current line
        /// </summary>
        MoveToBack,

        /// <summary>
        /// Misbehavior during full-course yellow, resulting in the penalty of being moved to the back of the longest line
        /// </summary>
        LongestTime,

        /// <summary>
        /// Maximum number of commands defined.
        /// </summary>
        Maximum
    }
}
