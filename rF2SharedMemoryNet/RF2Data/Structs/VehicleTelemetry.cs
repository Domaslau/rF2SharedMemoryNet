using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents telemetry data for a vehicle in rFactor 2, including positional, orientation,  vehicle status, driver
    /// input, aerodynamics, and other detailed metrics.
    /// </summary>
    /// <remarks>This structure provides comprehensive telemetry information for a vehicle in rFactor 2, 
    /// including real-time data such as position, velocity, acceleration, engine status, driver inputs,  and
    /// aerodynamic properties. It is designed for use in applications that require detailed  simulation data, such as
    /// telemetry analysis tools or custom plugins.  Many fields in this structure represent instantaneous values, such
    /// as engine RPM, throttle input,  and aerodynamic forces. Some fields, such as lap time and impact data, provide
    /// historical context  for the current state of the vehicle.  Note that certain fields, such as arrays for vehicle
    /// and track names, are encoded as byte arrays  and may require conversion to strings for human-readable use.
    /// Additionally, some fields, such as  orientation matrices, require specialized handling for
    /// interpretation.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct VehicleTelemetry
    {
        /// <summary>
        /// Identifier for the telemetry slot.
        /// </summary>
        public int ID;

        /// <summary>
        /// Time since the last update in seconds.
        /// </summary>
        public double DeltaTime;

        /// <summary>
        /// Game session time in seconds.
        /// </summary>
        public double ElapsedTime;

        /// <summary>
        /// Current lap number.
        /// </summary>
        public int LapNumber;

        /// <summary>
        /// Time this las was started
        /// </summary>
        public double LapStartTime;

        /// <summary>
        /// Vehicle name
        /// </summary>
        /// <remarks>
        /// Stored as a byte array of size 64.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] VehicleName;

        /// <summary>
        /// Name of track
        /// </summary>
        /// <remarks>
        /// Stored as a byte array of size 64.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] TrackName;

        /// <summary>
        /// World position in meters
        /// </summary>
        public Vec3 Position;

        /// <summary>
        /// Velocity in world coordinates (meters/sec)
        /// </summary>
        public Vec3 LocalVelocity;

        /// <summary>
        /// Acceleration (meters/sec^2) in local vehicle coordinates
        /// </summary>
        public Vec3 LocalAcceleration;

        /// <summary>
        /// rows of orientation matrix
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Vec3[] Orientation;

        /// <summary>
        /// Rotation (radians/sec) in local vehicle coordinates
        /// </summary>
        public Vec3 LocalRotationalSpeed;

        /// <summary>
        /// Rotational acceleration (radians/sec^2) in local vehicle coordinates
        /// </summary>
        public Vec3 LocalRotationalAcceleration;

        /// <summary>
        /// Gear information
        /// </summary>
        /// <remarks>
        /// -1 indicates reverse gear, 0 indicates neutral, and positive values indicate forward gears.
        /// </remarks>
        public int Gear;

        /// <summary>
        /// Represents the current revolutions per minute (RPM) of the engine.
        /// </summary>
        public double EngineRPM;

        /// <summary>
        /// Engine water temp in celsius.
        /// </summary>
        public double EngineWaterTemp;

        /// <summary>
        /// Engine oil temperature in celsius.
        /// </summary>
        public double EngineOilTemp;

        /// <summary>
        /// Clutch RPM
        /// </summary>
        public double ClutchRPM;

        /// <summary>
        /// Unfiltered throttle
        /// </summary>
        public double UnfilteredThrottle;

        /// <summary>
        /// Unfiltered brake
        /// </summary>
        public double UnfilteredBrake;

        /// <summary>
        /// Unfiltered steering
        /// </summary>
        public double UnfilteredSteering;

        /// <summary>
        /// Unfiltered clutch
        /// </summary>
        public double UnfilteredClutch;

        /// <summary>
        /// TC filtered throttle
        /// </summary>
        public double FilteredThrottle;

        /// <summary>
        /// ABS filtered brake
        /// </summary>
        public double FilteredBrake;

        /// <summary>
        /// Filtered steering
        /// </summary>
        public double FilteredSteering;

        /// <summary>
        /// Filtered clutch
        /// </summary>
        public double FilteredClutch;


        /// <summary>
        /// Torque around the steering shaft.
        /// </summary>
        public double SteeringShaftTorque;

        /// <summary>
        /// Represents the deflection at the front third spring.
        /// </summary>
        public double Front3rdDeflection;

        /// <summary>
        /// Represents the deflection at the rear third spring.
        /// </summary>
        public double Rear3rdDeflection;

        /// <summary>
        /// Front wing height
        /// </summary>
        public double FrontWingHeight;

        /// <summary>
        /// Front ride height
        /// </summary>
        public double FrontRideHeight;

        /// <summary>
        /// Rear ride height
        /// </summary>
        public double RearRideHeight;

        /// <summary>
        /// Drag coefficient.
        /// </summary>
        public double Drag;

        /// <summary>
        /// Front downforce
        /// </summary>
        public double FrontDownforce;

        /// <summary>
        /// Rear downforce
        /// </summary>
        public double RearDownforce;

        /// <summary>
        /// Fuel level in liters.
        /// </summary>
        public double Fuel;

        /// <summary>
        /// Max engine RPM.
        /// </summary>
        public double EngineMaxRPM;

        /// <summary>
        /// Number of scheduled pit stops.
        /// </summary>
        public byte ScheduledStops;

        /// <summary>
        /// Overheating icon is shown.
        /// </summary>
        public byte Overheating;

        /// <summary>
        /// Any parts besides wheels have been detached.
        /// </summary>
        public byte Detached;

        /// <summary>
        /// Headlights are on.
        /// </summary>
        public byte Headlights;

        /// <summary>
        /// Represents the severity of dents at eight locations around the car.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.DentSeverity"/> for the possible values.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] DentSeverity;

        /// <summary>
        /// Time of last impact.
        /// </summary>
        public double LastImpactTime;

        /// <summary>
        /// Magnitude of the last impact.
        /// </summary>
        public double LastImpactMagnitude;

        /// <summary>
        /// Location of last impact
        /// </summary>
        public Vec3 LastImpactPosition;

        /// <summary>
        /// Current engine torque, including any additive torque.
        /// </summary>
        public double EngineTorque;

        /// <summary>
        /// Represents the current sector of the track, with the pitlane status stored in the sign bit.
        /// </summary>
        /// <remarks>The value is zero-based, where the least significant bits indicate the sector number.
        /// If the sign bit is set, the value represents the pitlane status. For example, entering the pitlane from the
        /// third sector would result in a value of <c>0x80000002</c>.</remarks>
        public int CurrentSector;

        /// <summary>
        /// Indicates whether the speed limiter is enabled.
        /// </summary>
        public byte SpeedLimiter;

        /// <summary>
        /// Represents the maximum number of forward gears available.
        /// </summary>
        public byte MaxGears;

        /// <summary>
        /// Front tyre compound index
        /// </summary>
        public byte FrontTyreCompoundIndex;

        /// <summary>
        /// Rear tyre compound inde
        /// </summary>
        public byte RearTyreCompoundIndex;

        /// <summary>
        /// Fuel capacity in liters.
        /// </summary>
        public double FuelCapacity;

        /// <summary>
        /// Indicates whether the front flap is activated.
        /// </summary>
        public byte FrontFlapActivated;

        /// <summary>
        /// Indicates whether the rear flap is activated.
        /// </summary>
        public byte RearFlapActivated;

        /// <summary>
        /// Rear flap legal status.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.RearFlapLegalStatus"/> for the possible values.
        /// </remarks>
        public byte RearFlapLegalStatus;

        /// <summary>
        /// Igninition and starter status.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.IgnitionStarterStatus"/> for the possible values.
        /// </remarks>
        public byte IgnitionStarter;

        /// <summary>
        /// Front tyre compound name.
        /// </summary>
        /// <remarks>
        /// Stored as a byte array of size 18.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] FrontTyreCompoundName;

        /// <summary>
        /// Rear tyre compound name.
        /// </summary>
        /// <remarks>
        /// Stored as a byte array of size 18.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] RearTyreCompoundName;

        /// <summary>
        /// Is speed limiter available.
        /// </summary>
        public byte SpeedLimiterAvailable;

        /// <summary>
        /// Anti-stall activated status.
        /// </summary>
        public byte AntiStallActivated;

        /// <summary>
        /// Unused
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Unused;

        /// <summary>
        /// Visual steering wheel range.
        /// </summary>
        public float VisualSteeringWheelRange;

        /// <summary>
        /// Rear brake bias fraction.
        /// </summary>
        public double RearBrakeBias;

        /// <summary>
        /// Curren turbo boost pressure if available.
        /// </summary>
        public double TurboBoostPressure;

        /// <summary>
        /// Represents the offset from the static center of gravity (CG) to the graphical center.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] PhysicsToGraphicsOffset;

        /// <summary>
        /// Represents the physical range of the steering wheel in degrees.
        /// </summary>
        public float PhysicalSteeringWheelRange;

        /// <summary>
        /// Battery charge fraction.
        /// </summary>
        public double BatteryChargeFraction;

        /// <summary>
        /// Torque of the boost motor.
        /// </summary>
        /// <remarks>
        /// Negative values indicate regenerative braking.
        /// </remarks>
        public double ElectricBoostMotorTorque;

        /// <summary>
        /// RPM of the electric boost motor.
        /// </summary>
        public double ElectricBoostMotorRPM;

        /// <summary>
        /// Temperature of the electric boost motor.
        /// </summary>
        public double ElectricBoostMotorTemperature;

        /// <summary>
        /// Current water temperature of the electric boost motor cooler if present.
        /// </summary>
        public double ElectricBoostWaterTemperature;

        /// <summary>
        /// Electric boost motor state.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.BoostMotorState"/> for the possible values.
        /// </remarks>
        public byte ElectricBoostMotorState;

        /// <summary>
        /// For future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 111)]
        public byte[] Expansion;

        /// <summary>
        /// Wheel information.
        /// </summary>
        /// <remarks>
        /// Layout is as follows: front left, front right, rear left, rear right.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Wheel[] Wheels;
    }
}
