using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents weather control information for the rFactor 2 simulation, including parameters for rain, cloudiness,
    /// temperature, wind, and other environmental factors.
    /// </summary>
    /// <remarks>This structure is used to define weather conditions and their effects on the simulation
    /// environment. It includes parameters for rain intensity at specific nodes, cloudiness, ambient temperature, wind
    /// speed, and other settings.  The weather changes are typically interpolated over time to ensure smooth
    /// transitions, such as clouds rolling in before rain starts. Sudden changes in weather parameters may result in
    /// unrealistic visual effects.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct WeatherControlInfo
    {
        /// <summary>
        /// When you want this weather to take effect.
        /// </summary>
        public double ET;

        /// <summary>
        /// Represents the rain intensity at different nodes in the simulation environment.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public double[] Raining;

        /// <summary>
        /// General cloudiness in the simulation environment.
        /// </summary>
        public double Cloudiness;

        /// <summary>
        /// Ambient temperature in Kelvin.
        /// </summary>
        public double AmbientTempK;

        /// <summary>
        /// Wind max speed
        /// </summary>
        public double WindMaxSpeed;

        /// <summary>
        /// Gets or sets a value indicating whether cloudiness changes are applied instantly.
        /// </summary>
        public bool ApplyCloudinessInstantly;

        /// <summary>
        /// unused
        /// </summary>
        public bool Unused1;

        /// <summary>
        /// unused
        /// </summary>
        public bool Unused2;

        /// <summary>
        /// unused
        /// </summary>
        public bool Unused3;

        /// <summary>
        /// For future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
        public byte[] Expansion;
    }
}
