using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the weather control data structure used in RF2 simulations.
    /// </summary>
    /// <remarks>This structure contains information about the weather control system, including versioning 
    /// details and weather-specific data.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct WeatherControl
    {
        /// <summary>
        /// Represents the version number of the buffer at the point when an update begins.
        /// </summary>
        /// <remarks>This value is incremented immediately before the buffer is written to, indicating the
        /// start of an update process. It can be used to track changes or ensure consistency during buffer
        /// operations.</remarks>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Represents the version update counter, incremented after a buffer write operation is completed.
        /// </summary>
        /// <remarks>This field is intended to track the completion of buffer write operations. It is
        /// incremented  automatically after each write to indicate the end of an update cycle.</remarks>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Layout version of the weather control structure.
        /// </summary>
        public int LayoutVersion;

        /// <summary>
        /// Represents weather control information for RF2 simulations.
        /// </summary>
        public WeatherControlInfo WeatherInfo;
    }
}
