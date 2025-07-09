using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the configuration options for physics and driving aids in rFactor 2.
    /// </summary>
    /// <remarks>This structure contains various settings that control driving aids, mechanical behavior, and 
    /// other physics-related options in the simulation. Each field represents a specific feature or adjustment, such
    /// as traction control, automatic shifting, or mechanical failure settings. Values for each field are typically
    /// represented as enumerations or ranges, as described in the field definitions.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct PhysicsOptions
    {
        /// <summary>
        /// Represents the level of traction control applied to the vehicle.
        /// </summary>
        public byte TractionControl;

        /// <summary>
        /// Represents the level of anti-lock braking system (ABS) functionality.
        /// </summary>
        public byte AntiLockBrakes;

        /// <summary>
        /// Represents the stability control level of the system.
        /// </summary>
        public byte StabilityControl;

        /// <summary>
        /// Represents the automatic shifting mode for a vehicle.
        /// </summary>
        public byte AutoShift;

        /// <summary>
        /// Indicates whether the automatic clutch feature is enabled.
        /// </summary>
        public byte AutoClutch;

        /// <summary>
        /// Indicates whether the entity is invulnerable.
        /// </summary>
        public byte Invulnerable;

        /// <summary>
        /// Represents the state of the opposite lock feature.
        /// </summary>
        public byte OppositeLock;

        /// <summary>
        /// Represents the level of steering assistance provided, ranging from off to high.
        /// </summary>
        public byte SteeringHelp;

        /// <summary>
        /// Represents the level of braking assistance provided by the system.
        /// </summary>
        public byte BrakingHelp;

        /// <summary>
        /// Represents the spin recovery mode for the system.
        /// </summary>
        public byte SpinRecovery;

        /// <summary>
        /// Indicates whether the automatic pit stop feature is enabled.
        /// </summary>
        public byte AutoPit;

        /// <summary>
        /// Indicates whether the auto-lift feature is enabled.
        /// </summary>
        public byte AutoLift;

        /// <summary>
        /// Indicates whether the automatic throttle blip feature is enabled.
        /// </summary>
        public byte AutoBlip;

        /// <summary>
        /// Represents the fuel multiplier used to adjust fuel consumption rates.
        /// </summary>
        public byte FuelMult;

        /// <summary>
        /// Represents the multiplier applied to tire wear.
        /// </summary>
        public byte TireMult;

        /// <summary>
        /// Represents the mechanical failure setting.
        /// </summary>
        public byte MechFail;

        /// <summary>
        /// Gets or sets a value indicating whether pitcrew push assistance is allowed.
        /// </summary>
        public byte AllowPitcrewPush;

        /// <summary>
        /// Represents the accidental repeat shift prevention value.
        /// </summary>
        public byte RepeatShifts;

        /// <summary>
        /// Represents the state of the hold clutch for automatic shifters at the start of a race.
        /// </summary>
        public byte HoldClutch;

        /// <summary>
        /// Indicates whether the auto-reverse feature is enabled.
        /// </summary>
        public byte AutoReverse;

        /// <summary>
        /// Represents whether shifting up and down simultaneously results in neutral.
        /// </summary>
        public byte AlternateNeutral;

        /// <summary>
        /// Indicates whether the player vehicle is currently under AI control.
        /// </summary>
        public byte AIControl;

        /// <summary>
        /// Reserved field for future use. This field is currently unused.
        /// </summary>
        public byte Unused1;

        /// <summary>
        /// Reserved field for future use. This field is currently unused.
        /// </summary>
        public byte Unused2;

        /// <summary>
        /// Represents the duration, in seconds, before automatic shifting can resume after a recent manual shift.
        /// </summary>
        public float ManualShiftOverrideTime;

        /// <summary>
        /// Specifies the duration, in seconds, before manual shifting can resume after a recent automatic shift.
        /// </summary>
        public float AutoShiftOverrideTime;

        /// <summary>
        /// Represents the sensitivity of steering based on speed.
        /// </summary>
        public float SpeedSensitiveSteering;

        /// <summary>
        /// Represents the speed, in meters per second, below which the steering lock is expanded to its full range.
        /// </summary>
        public float SteerRatioSpeed;
    }
}