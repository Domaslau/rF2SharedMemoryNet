using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{

    /// <summary>
    /// Represents detailed telemetry data for a single wheel in the rFactor 2 simulation.
    /// </summary>
    /// <remarks>This structure provides various physical and dynamic properties of a wheel, including
    /// suspension deflection, ride height, forces, velocities, temperatures, and more. It is primarily used for
    /// analyzing wheel behavior and performance in the simulation environment.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct Wheel
    {
        /// <summary>
        /// Suspension deflection in meters
        /// </summary>
        public double SuspensionDeflection;

        /// <summary>
        /// Ride height in meters
        /// </summary>
        public double RideHeight;

        /// <summary>
        /// Pushrod load in newtons
        /// </summary>
        public double SuspForce;

        /// <summary>
        /// Brake temperature in celsius
        /// </summary>
        public double BrakeTemp;

        /// <summary>
        /// Normalized brake pressure, currently 0.0-1.0, depending on driver input and brake balance.
        /// </summary>
        public double BrakePressure;

        /// <summary>
        /// Rotation speed in radians per second
        /// </summary>
        public double Rotation;

        /// <summary>
        /// Lateral velocity at contact patch
        /// </summary>
        public double LateralPatchVel;

        /// <summary>
        /// longitudinal velocity at contact patch
        /// </summary>
        public double LongitudinalPatchVel;

        /// <summary>
        /// Lateral ground velocity at contact patch
        /// </summary>
        public double LateralGroundVel;

        /// <summary>
        /// Longitudinal ground velocity at contact patch
        /// </summary>
        public double LongitudinalGroundVel;

        /// <summary>
        /// Camber angle in radians
        /// </summary>
        /// <remarks>
        /// Positive is left for left-side wheels, right for right-side wheels
        /// </remarks>
        public double Camber;

        /// <summary>
        /// Lateral force in newtons
        /// </summary>
        public double LateralForce;

        /// <summary>
        /// Longitudinal force in newtons
        /// </summary>
        public double LongitudinalForce;

        /// <summary>
        /// Tyre load in newtons
        /// </summary>
        public double TyreLoad;

        /// <summary>
        /// Fraction of the contact patch that is sliding
        /// </summary>
        public double GripFract;

        /// <summary>
        /// Tyre pressure in kPa
        /// </summary>
        public double Pressure;

        /// <summary>
        /// Tyre temperature in Kelvin
        /// </summary>
        /// <remarks>
        /// Layout is left/center/right
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public double[] Temperature;

        /// <summary>
        /// Tyre wear in fraction
        /// </summary>
        public double Wear;

        /// <summary>
        /// Terrain name
        /// </summary>
        /// <remarks>
        /// A 16-byte array containing the terrain name, which is a prefix from the TDF file.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] TerrainName;

        /// <summary>
        /// Surface type under the wheel
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.SurfaceType"/> for possible values.
        /// </remarks>
        public byte SurfaceType;

        /// <summary>
        /// Is tyre flat.
        /// </summary>
        public byte Flat;

        /// <summary>
        /// Is wheel detached.
        /// </summary>
        public byte Detached;

        /// <summary>
        /// Tyre radius in centimeters.
        /// </summary>
        public byte StaticUndeflectedRadius;

        /// <summary>
        /// Represents the vertical deflection of a tyre from its speed-sensitive radius.
        /// </summary>
        public double VerticalTyreDeflection;

        /// <summary>
        /// Wheel's y location relative to the vehicle's y location.
        /// </summary>
        public double mWheelYLocation;

        /// <summary>
        /// Toe angle with relation to vehicle
        /// </summary>
        public double Toe;

        /// <summary>
        /// Represents the rough average temperature of tyre carcass samples, measured in Kelvin.
        /// </summary>
        public double TyreCarcassTemperature;

        /// <summary>
        /// Rough average of temperature samples from the innermost layer of rubber (before carcass), measured in Kelvin.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public double[] TyreInnerLayerTemperature;

        /// <summary>
        /// For future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        byte[] Expansion;
    }
}