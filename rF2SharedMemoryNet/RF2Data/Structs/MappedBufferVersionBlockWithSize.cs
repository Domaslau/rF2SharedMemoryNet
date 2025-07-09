using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents a version block with size information for a mapped buffer, used to track updates to the buffer.
    /// </summary>
    /// <remarks>This structure is typically used in scenarios where a mapped buffer requires versioning to
    /// ensure consistency during updates. The versioning mechanism involves incrementing the update counters before and
    /// after the buffer is written to, allowing consumers to detect changes.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MappedBufferVersionBlockWithSize
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
        /// Represents the number of bytes written to the structure during the last update.
        /// </summary>
        /// <remarks>This value provides a hint about the amount of data updated in the structure. It may
        /// be useful for tracking or debugging purposes. 0 Should be considered complete</remarks> 
        public int BytesUpdatedHint;

    }
}
