namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the control type for an entity in the RF2 simulation environment.
    /// </summary>
    /// <remarks>This enumeration is used to specify the control mechanism for an entity, such as whether it
    /// is controlled by a player, AI, or other systems.</remarks>
    public enum ControlEntity
    {
        /// <summary>
        /// Nobody controls the vehicle.
        /// </summary>
        /// <remarks>
        /// This value should not be available in normal conditions.
        /// </remarks>
        Nobody = -1,

        /// <summary>
        /// Player is in control.
        /// </summary>
        Player = 0,

        /// <summary>
        /// AI is in control.
        /// </summary>
        AI = 1,

        /// <summary>
        /// Remote player is in control.
        /// </summary>
        Remote = 2,

        /// <summary>
        /// Replay is in control.
        /// </summary>
        /// <remarks>
        /// Should not be available in normal conditions.
        /// </remarks>
        Replay = 3
    }
}
