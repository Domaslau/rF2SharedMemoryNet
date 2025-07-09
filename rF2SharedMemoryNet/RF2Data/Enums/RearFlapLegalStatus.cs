namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the legal status of the RF2 rear flap in a racing context.
    /// </summary>
    /// <remarks>This enumeration is typically used to indicate whether the rear flap is allowed to be
    /// activated     during a race, based on the current conditions and regulations.</remarks>
    public enum RearFlapLegalStatus
    {
        /// <summary>
        /// Not allowed to use the rear flap.
        /// </summary>
        Disallowed,

        /// <summary>
        /// Detected but not allowed yet.
        /// </summary>
        DetectedButNotAllowedYet,

        /// <summary>
        /// Allowed to use the rear flap.
        /// </summary>
        Alllowed
    }
}
