using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents information related to pit operations in rFactor 2, including versioning and pit menu details.
    /// </summary>
    /// <remarks>This structure is used to encapsulate data related to pit operations in rFactor 2.  The
    /// version update fields are used to ensure data consistency during buffer writes.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct PitInfo
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
        /// Represents the pit menu in the RF2 simulation.
        /// </summary>
        /// <remarks>This field provides access to the pit menu functionality</remarks>
        public PitMenu PitMenu;
    }
}
