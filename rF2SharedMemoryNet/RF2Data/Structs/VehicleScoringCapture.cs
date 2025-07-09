using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the scoring information for a vehicle in rFactor 2, including its position, player status, and finish
    /// status.
    /// </summary>
    /// <remarks>This structure is used to capture scoring data for vehicles during gameplay in rFactor 2. The
    /// <see cref="mID"/> field represents the slot ID, which may be reused in multiplayer sessions after a player
    /// leaves.</remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct VehicleScoringCapture
    {
        /// <summary>
        /// ID of the vehicle in the scoring capture.
        /// </summary>
        /// <remarks>
        /// May be reused in multiplayer sessions after a player leaves.
        /// </remarks>
        public int mID;

        /// <summary>
        /// Place of the vehicle.
        /// </summary>
        public byte mPlace;

        /// <summary>
        /// Is the vehicle a player.
        /// </summary>
        public byte mIsPlayer;

        /// <summary>
        /// Finish status of the vehicle.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.FinishStatus"/> for possible values.
        /// </remarks>
        public sbyte mFinishStatus;
    }
}
