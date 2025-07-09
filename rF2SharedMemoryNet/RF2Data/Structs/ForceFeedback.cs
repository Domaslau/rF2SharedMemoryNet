using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the force feedback data structure used in rFactor 2.
    /// </summary>
    /// <remarks>This structure provides information about the current force feedback value and versioning
    /// updates for synchronization purposes. The version update fields are incremented before and after the buffer is
    /// written to, ensuring consistency when accessing the data.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct ForceFeedback
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
        /// <remarks>This field can be used to track the completion of buffer write operations. Each time
        /// a buffer write is finalized,  the value of this counter is incremented.</remarks>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Represents the current force feedback (FFB) value reported by the InternalsPlugin.
        /// </summary>
        /// <remarks>This value indicates the magnitude of the force feedback effect at a given moment. It
        /// is typically used in applications that interact with force feedback devices, such as steering
        /// wheels.</remarks>
        public double ForceValue;
    }
}
