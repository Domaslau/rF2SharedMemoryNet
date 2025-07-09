using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents telemetry data for rFactor 2, including information about vehicles and update status.
    /// </summary>
    /// <remarks>This structure is used to store telemetry data for rFactor 2, including details about the
    /// current number of vehicles and their telemetry information. It also provides versioning and update hints to help
    /// consumers determine the state of the data buffer.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Telemetry
    {
        /// <summary>
        /// Represents the version number of the buffer update process.
        /// </summary>
        /// <remarks>This value is incremented immediately before the buffer is written to, indicating the
        /// start of an update. It can be used to track or verify the state of the buffer during write
        /// operations.</remarks>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Represents the version update counter, which is incremented after a buffer write operation is completed.
        /// </summary>
        /// <remarks>This field is used to track the completion of buffer write operations. It is
        /// incremented automatically after each write to indicate the end of the update process.</remarks>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Represents the number of bytes written to the structure during the last update.
        /// </summary>
        /// <remarks>This value provides a hint about the amount of data updated in the structure. It may
        /// be useful for tracking or debugging purposes.</remarks>
        public int BytesUpdatedHint;

        /// <summary>
        /// Represents the current number of vehicles.
        /// </summary>
        /// <remarks>This field holds the count of vehicles currently tracked or managed.</remarks>
        public int NumVehicles;

        /// <summary>
        /// Represents an array of telemetry data for vehicles mapped in the simulation.
        /// </summary>
        /// <remarks>The array contains telemetry information for up to <see
        /// cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/> vehicles. Each element corresponds to a specific vehicle's
        /// telemetry data.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public VehicleTelemetry[] Vehicles;
    }
}
