using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the scoring data structure used in rFactor 2 to provide information about the current race session,
    /// including scoring details and vehicle-specific scoring data.
    /// </summary>
    /// <remarks>This structure is designed for interop scenarios and is used to exchange scoring information
    /// between rFactor 2 and external applications. It contains session-wide scoring details, as well as an array of
    /// vehicle-specific scoring data. <para> The structure is updated periodically, with the <see
    /// cref="VersionUpdateBegin"/> and <see cref="VersionUpdateEnd"/> fields indicating the start and end of an
    /// update cycle. The <see cref="BytesUpdatedHint"/> field provides a hint about the number of bytes updated during
    /// the last cycle. </para></remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Scoring
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
        /// Represents the scoring information for the RF2 system.
        /// </summary>
        /// <remarks>This field contains detailed scoring data related to the RF2 system.  It is intended
        /// to be used for accessing or manipulating scoring-related information.</remarks>
        public ScoringInfo ScoringInfo;


        /// <summary>
        /// Represents an array of vehicle scoring data for mapped vehicles.
        /// </summary>
        /// <remarks>The array contains scoring information for up to <see
        /// cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/> vehicles. Each element corresponds to a specific vehicle's
        /// scoring data.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public VehicleScoring[] Vehicles;
    }
}
