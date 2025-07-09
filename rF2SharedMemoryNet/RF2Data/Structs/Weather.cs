using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents weather-related data and control information for the RF2 simulation.
    /// </summary>
    /// <remarks>This structure contains weather control information and metadata related to the simulation's
    /// weather system. The <see cref="VersionUpdateBegin"/> and <see cref="VersionUpdateEnd"/> fields are used to
    /// track updates to the buffer.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Weather
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
        /// <remarks>This field can be used to track the completion of buffer write operations. Each
        /// successful write increments the value.</remarks>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Represents the size of a track node.
        /// </summary>
        public double TrackNodeSize;

        /// <summary>
        /// Represents weather control information.
        /// </summary>
        public WeatherControlInfo WeatherInfo;
    }
}
