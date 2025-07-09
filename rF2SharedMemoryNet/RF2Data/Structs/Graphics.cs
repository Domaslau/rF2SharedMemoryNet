using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the graphics data structure used in rFactor 2, containing versioning information and detailed
    /// graphics settings.
    /// </summary>
    /// <remarks>This structure is primarily used to store and transfer graphics-related information,
    /// including version update ranges and detailed graphics settings. It is designed for interoperability with
    /// unmanaged code, using sequential layout and ANSI character set.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Graphics
    {
        /// <summary>
        /// Represents the version number at which an update process begins.
        /// </summary>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Represents the version number at the end of an update process.
        /// </summary>
        public uint VersionUpdateEnd;

        /// <summary>
        /// Represents the graphics information for the RF2 simulation.
        /// </summary>
        /// <remarks>This field contains details about the graphical settings or state of the RF2
        /// simulation. It may include information such as resolution, rendering settings, or other graphical
        /// parameters.</remarks>
        public GraphicsInfo GraphicsInfo;
    }
}
