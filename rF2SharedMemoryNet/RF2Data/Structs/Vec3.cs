using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents a three-dimensional vector with double-precision floating-point components.
    /// </summary>
    /// <remarks>This structure is commonly used to represent points or directions in 3D space. The components
    /// <see cref="X"/>, <see cref="Y"/>, and <see cref="Z"/> can be accessed directly.</remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vec3
    {
        /// <summary>
        /// Represents a coordinate of a point in 3D space.
        /// </summary>
        /// <remarks>These fields can be used to store or manipulate the position of a point in a
        /// three-dimensional coordinate system.</remarks>
        public double X, Y, Z;
    }
}
