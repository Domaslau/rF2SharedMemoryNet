using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents graphical information related to the rFactor 2 simulation, including camera position, orientation,
    /// ambient lighting, and other visual settings.
    /// </summary>
    /// <remarks>This structure provides data about the current graphical state of the simulation, such as the
    /// camera's position and orientation, ambient lighting colors, and the slot ID being viewed. It also includes
    /// information about the camera type, which can be used to determine or set the current camera view. Some fields,
    /// such as <see cref="Expansion"/>, are reserved for future use.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct GraphicsInfo
    {
        /// <summary>
        /// Represents the position of the camera in 3D space.
        /// </summary>
        /// <remarks>This field stores the camera's position as a 3D vector. It can be used to determine
        /// or modify the camera's location in the scene.</remarks>
        public Vec3 CamPos;

        /// <summary>
        /// Represents the rows of an orientation matrix for the camera.
        /// </summary>
        /// <remarks>This array contains three elements, each representing a row of the orientation
        /// matrix. The matrix can be used to describe the camera's orientation in 3D space. For conversions, consider
        /// using TelemQuat utilities to transform the data into quaternion format.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Vec3[] CamOri;

        /// <summary>
        /// Represents the application handle as an array of bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] HWND;

        /// <summary>
        /// Represents the red component of the ambient color in a lighting system.
        /// </summary>
        /// <remarks>This field is typically used to define the intensity of the red channel for ambient
        /// lighting. Values should generally be in the range of 0.0 to 1.0, where 0.0 represents no red light and 1.0
        /// represents full intensity.</remarks>
        public double AmbientRed;

        /// <summary>
        /// Represents the green component of ambient light intensity.
        /// </summary>
        /// <remarks>This field is typically used in graphics or lighting calculations to define the green
        /// channel of ambient light. The value should be in a range appropriate for the specific application, such as
        /// 0.0 to 1.0 for normalized intensity or another range depending on the context.</remarks>
        public double AmbientGreen;

        /// <summary>
        /// Represents the intensity of the ambient blue color component in the lighting system.
        /// </summary>
        /// <remarks>This field is typically used to control the blue channel of ambient light in
        /// rendering or graphical applications. The value should be within a valid range for color intensity, typically
        /// between 0.0 and 1.0, where 0.0 represents no blue light and 1.0 represents full intensity.</remarks>
        public double AmbientBlue;

        /// <summary>
        /// Represents the slot ID currently being viewed.
        /// </summary>
        public int Id;

        /// <summary>
        /// Represents the type of camera view in a racing simulation environment.
        /// </summary>
        /// <remarks>The camera type determines the perspective from which the simulation is viewed.
        /// Values outside the defined range may not be supported. 
        /// <list type="bullet">
        ///     <item>
        ///         0  = TV cockpit
        ///     </item>
        ///     <item>
        ///         1  = cockpit
        ///     </item>
        ///     <item>
        ///         2  = nosecam
        ///     </item>
        ///     <item>
        ///         3  = swingman
        ///     </item>
        ///     <item>
        ///         4  = trackside (nearest)
        ///     </item>
        ///     <item>
        ///         5  = onboard000
        ///     </item>
        ///     <item>
        ///         :
        ///     </item>
        ///     <item>
        ///         :
        ///     </item>
        ///     <item>
        ///         1004  = onboard999
        ///     </item>
        ///     <item>
        ///         1005+ = (currently unsupported, in the future may be able to set/get specific trackside camera)
        ///     </item>
        /// </list>
        /// </remarks>
        public int CameraType;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] Expansion;
    };
}
