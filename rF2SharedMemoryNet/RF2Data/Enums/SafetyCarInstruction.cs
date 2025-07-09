namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the instructions that can be issued to the safety car in rFactor 2.
    /// </summary>
    /// <remarks>This enumeration defines the possible states or commands for the safety car during a race. It
    /// is typically used to control the behavior of the safety car in response to race events.</remarks>
    public enum SafetyCarInstruction
    {
        /// <summary>
        /// No change in safety car status;
        /// </summary>
        NoChange,

        /// <summary>
        /// Activate the safety car.
        /// </summary>
        GoActive,

        /// <summary>
        /// Heading for the pits, typically to end the safety car period.
        /// </summary>
        HeadForPits
    }
}
