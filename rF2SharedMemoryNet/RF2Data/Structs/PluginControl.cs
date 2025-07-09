using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the control structure used for communication between the rFactor 2 plugin and the simulation.
    /// </summary>
    /// <remarks>This structure is primarily used to manage versioning and control requests for various
    /// simulation inputs. It is designed to be updated sequentially, with the <see cref="VersionUpdateBegin"/> and
    /// <see cref="VersionUpdateEnd"/>  fields ensuring consistency during buffer writes.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct PluginControl
    {
        /// <summary>
        /// Represents the version number of the buffer at the point when an update begins.
        /// </summary>
        /// <remarks>This value is incremented immediately before the buffer is written to, indicating the
        /// start of an update. It can be used to track changes or ensure consistency during buffer
        /// operations.</remarks>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Represents the version update counter, which is incremented after a buffer write operation is completed.
        /// </summary>
        /// <remarks>This field is used to track the completion of buffer write operations. It is
        /// incremented automatically after each write to indicate the end of the update process.</remarks>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Represents the version number of the layout configuration.
        /// </summary>
        public int LayoutVersion;


        /// <summary>
        /// Represents a bitmask used to enable specific request buffers.
        /// </summary>
        public int RequestEnableBuffersMask;

        /// <summary>
        /// Represents the hardware control input request as a byte value.
        /// </summary>
        /// <remarks>This field is used to store a hardware control input request in byte format. The
        /// specific meaning of the value depends on the context in which it is used.</remarks>
        public byte RequestHWControlInput;

        /// <summary>
        /// Represents the input value for requesting weather control.
        /// </summary>
        /// <remarks>This field is used to specify the desired weather control input in a weather control
        /// system. The exact meaning of the value depends on the implementation of the system.</remarks>
        public byte RequestWeatherControlInput;

        /// <summary>
        /// Represents the control input for request rules.
        /// </summary>
        /// <remarks>This field is intended to store a byte value that influences the behavior of request
        /// rules. Ensure the value is within the expected range for the specific rules being applied.</remarks>
        public byte RequestRulesControlInput;
    }
}
