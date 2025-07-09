using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents a version block used to track the state of a mapped buffer during updates.
    /// </summary>
    /// <remarks>This structure contains two version numbers that indicate whether the buffer is being written
    /// to or is in a consistent state. If <see cref="VersionUpdateBegin"/> and <see cref="VersionUpdateEnd"/> are
    /// equal, the buffer is either not being written to or requires further verification. If the values differ, the
    /// buffer is actively being written to or may be incomplete due to an interruption (e.g., a crash or missed
    /// transition).</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MappedBufferVersionBlock
    {
        /// <summary>
        /// Represents the version number at which an update process begins.
        /// </summary>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Represents the version number at the end of an update process.
        /// </summary>
        public uint VersionUpdateEnd;
    }
}
