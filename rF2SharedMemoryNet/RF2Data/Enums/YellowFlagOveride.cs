namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Specifies the override behavior for the yellow flag state.
    /// </summary>
    /// <remarks>This enumeration is used to control whether the yellow flag state is overridden, cleared, or
    /// left unchanged.</remarks>
    public enum YellowFlagOveride
    {
        /// <summary>
        /// Overide the yellow flag state.
        /// </summary>
        Yes = 1,

        /// <summary>
        /// Do not overide the yellow flag state.
        /// </summary>
        No = 0,

        /// <summary>
        /// Clear the yellow flag state.
        /// </summary>
        ClearYellowFlag = 2,
    }
}
