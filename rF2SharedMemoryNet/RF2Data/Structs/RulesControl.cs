using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the control structure for managing track rules and participants in rFactor2.
    /// </summary>
    /// <remarks>This structure is used to manage the state and actions related to track rules in rFactor2. It
    /// includes versioning information for updates, layout versioning, track rules, and arrays of actions and
    /// participants. The version update fields are incremented before and after buffer writes to ensure consistency
    /// during updates.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct RulesControl
    {
        /// <summary>
        /// Represents the version number of the buffer at the point when an update begins.
        /// </summary>
        /// <remarks>This value is incremented immediately before the buffer is written to, indicating the
        /// start of an update. It can be used to track changes or ensure consistency during buffer
        /// operations.</remarks>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Represents the version update counter that is incremented after a buffer write operation is completed.
        /// </summary>
        /// <remarks>This field is used to track the completion of buffer write operations. It is
        /// incremented automatically after each write operation to indicate the end of the update process.</remarks>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Represents the version number of the layout.
        /// </summary>
        /// <remarks>This field indicates the current version of the layout configuration. It can be used
        /// to track changes or updates to the layout structure.</remarks>
        public int LayoutVersion;

        /// <summary>
        /// Represents the track rules for an RF2 simulation.
        /// </summary>
        public TrackRules TrackRules;

        /// <summary>
        /// Represents an array of track rule actions for mapped vehicles in rFactor2.
        /// </summary>
        /// <remarks>The array is marshaled using the <see cref="UnmanagedType.ByValArray"/> attribute,
        /// with a fixed size specified by <see cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/>. This ensures
        /// compatibility with unmanaged code.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public TrackRulesAction[] Actions;

        /// <summary>
        /// Represents an array of participants in the track rules system.
        /// </summary>
        /// <remarks>The array is marshaled using the <see cref="UnmanagedType.ByValArray"/> attribute,
        /// with a fixed size specified by <see cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/>. This ensures
        /// compatibility with unmanaged code.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public TrackRulesParticipant[] Participants;
    }
}
