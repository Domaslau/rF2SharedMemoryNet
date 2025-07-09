using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents a hardware control structure used for communication between rFactor 2 and external systems.
    /// </summary>
    /// <remarks>This structure is designed to facilitate data exchange with hardware control systems in
    /// rFactor 2. It includes versioning fields to track updates, a layout version identifier, a control name, and a
    /// return value. The <see cref="VersionUpdateBegin"/> and <see cref="VersionUpdateEnd"/> fields are used to
    /// ensure data consistency during updates.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct HardwareControl
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
        /// Represents the version number of the layout configuration.
        /// </summary>
        /// <remarks>This field is used to track the version of the layout configuration.  It can be
        /// useful for ensuring compatibility or identifying changes  in layout structure.</remarks>
        public int LayoutVersion;

        /// <summary>
        /// Represents the name of a hardware control as a byte array.
        /// </summary>
        /// <remarks>The array is marshaled using the <see cref="UnmanagedType.ByValArray"/> attribute and
        /// has a fixed size defined by <see cref="RFactor2Constants.MAX_HWCONTROL_NAME_LEN"/>. This ensures
        /// compatibility with unmanaged code.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_HWCONTROL_NAME_LEN)]
        public byte[] ControlName;

        /// <summary>
        /// Represents a double-precision floating-point value.
        /// </summary>
        /// <remarks>This field can be used to store or retrieve a numeric value.</remarks>
        public double FRetVal;
    }
}
