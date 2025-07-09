namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the type of surface in the rFactor 2 simulation environment.
    /// </summary>
    /// <remarks>This enumeration is used to classify different surface types encountered in the simulation.
    /// Surface types can affect vehicle behavior, such as grip and handling.</remarks>
    public enum SurfaceType
    {
        /// <summary>
        /// Dry surface
        /// </summary>
        Dry,

        /// <summary>
        /// Wet surface
        /// </summary>
        Wet,

        /// <summary>
        /// Grass surface
        /// </summary>
        Grass,

        /// <summary>
        /// Dirt surface
        /// </summary>
        Dirt,

        /// <summary>
        /// Gravel surface
        /// </summary>
        Gravel,

        /// <summary>
        /// Kerb
        /// </summary>
        Kerb,

        /// <summary>
        /// Special surface type
        /// </summary>
        Special
    }
}
