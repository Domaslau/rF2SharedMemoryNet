using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the rules and state information for the rFactor 2 simulation, including track rules, actions, and
    /// participants.
    /// </summary>
    /// <remarks>This structure is used to manage and synchronize simulation data related to track rules,
    /// vehicle actions, and participants. It includes versioning fields to track updates and hints about the number of
    /// bytes updated during the last synchronization.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Rules
    {
        /// <summary>
        /// Represents the version number of the buffer at the point when an update begins.
        /// </summary>
        /// <remarks>This value is incremented immediately before the buffer is written to, indicating the
        /// start of an update process. It can be used to track changes or ensure consistency during buffer
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
        /// <remarks>This value serves as a hint for the number of bytes updated in the structure. It may
        /// be useful for tracking or debugging purposes.</remarks>
        public int BytesUpdatedHint;

        /// <summary>
        /// Represents the track rules for an RF2 simulation.
        /// </summary>
        public TrackRules TrackRules;

        /// <summary>
        /// Represents an array of track rule actions mapped to vehicles.
        /// </summary>
        /// <remarks>The array is fixed in size, with a maximum length defined by <see
        /// cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/>. Each element corresponds to a specific track rule action for
        /// a mapped vehicle.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public TrackRulesAction[] Actions;

        /// <summary>
        /// Represents an array of participants in the track rules system.
        /// </summary>
        /// <remarks>The array is marshaled using the <see cref="UnmanagedType.ByValArray"/> attribute,
        /// ensuring compatibility  with unmanaged code. The size of the array is determined by the constant  <see
        /// cref="RFactor2Constants.MAX_MAPPED_VEHICLES"/>.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_VEHICLES)]
        public TrackRulesParticipant[] Participants;
    }
}
