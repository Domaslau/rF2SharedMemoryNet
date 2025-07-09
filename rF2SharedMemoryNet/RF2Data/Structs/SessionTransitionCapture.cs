using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents a snapshot of session transition data in rFactor 2, including game phase, session information,  and
    /// scoring details for vehicles.
    /// </summary>
    /// <remarks>This structure is used to capture and transfer information about the current state of a
    /// session in rFactor 2.  It includes details about the game phase, session identifier, and scoring data for
    /// vehicles participating in the session.</remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SessionTransitionCapture
    {
        /// <summary>
        /// Represents the current phase of the game.
        /// </summary>
        public byte GamePhase;

        /// <summary>
        /// Represents the current session identifier.
        /// </summary>
        public int Session;

        /// <summary>
        /// Represents the number of scoring vehicles in the current context.
        /// </summary>
        public int NumScoringVehicles;

        /// <summary>
        /// Represents an array of vehicle scoring data for mapped vehicles.
        /// </summary>
        /// <remarks>The array contains scoring information for up to <see
        /// cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/> vehicles. Each element in the array corresponds to a specific
        /// vehicle's scoring data.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public VehicleScoringCapture[] ScoringVehicles;
    }
}
