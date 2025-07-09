namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the operational state of a motor in a boost system.
    /// </summary>
    /// <remarks>This enumeration defines the possible states of a motor, including whether it is unavailable,
    /// inactive,  providing propulsion, or performing regeneration. Use this to determine the current state of the
    /// motor  in the system.</remarks>
    public enum BoostMotorState
    {
        /// <summary>
        /// Unavailable state indicates that the motor is not operational or not present.
        /// </summary>
        Unavailable,
        /// <summary>
        /// Inactive state indicates that the motor is not currently engaged in any operation.
        /// </summary>   
        Inactive,

        /// <summary>
        /// Propulsion state indicates that the motor is actively providing propulsion power.
        /// </summary>
        Propulsion,

        /// <summary>
        /// Boost motor is regenerating energy.
        /// </summary>
        Regeneration,
    }
}
