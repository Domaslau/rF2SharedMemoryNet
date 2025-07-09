using rF2SharedMemoryNet.RF2Data.Enums;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the rules and state information for a racing track in rFactor 2.
    /// </summary>
    /// <remarks>This structure encapsulates various parameters and states related to track rules, safety car
    /// behavior, yellow flag conditions, participant information, and other race-related data. It is primarily used to
    /// manage and communicate the current state of the track and race conditions during a session.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct TrackRules
    {
        // input only
        /// <summary>
        /// Represents the current elapsed time in seconds.
        /// </summary>
        public double CurrentET;

        /// <summary>
        /// Represents the current stage of the RF2 track rules.
        /// </summary>
        public TrackRulesStage Stage;

        /// <summary>
        /// Represents the column assignment where the pole position data is located.
        /// </summary>
        public TrackRulesColumn PoleColumn;

        /// <summary>
        /// Represents the number of recent actions performed.
        /// </summary>
        public int NumActions;

        /// <summary>
        /// Not used
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Pointer1;

        /// <summary>
        /// Number of participants
        /// </summary>
        public int NumParticipants;


        /// <summary>
        /// Indicates whether a yellow flag has been requested or the sum of participant yellow severity values exceeds
        /// the safety car threshold.
        /// </summary>
        public byte YellowFlagDetected;

        /// <summary>
        /// Indicates whether the yellow flag laps were overridden by an admin request.
        /// </summary>
        /// <remarks>
        /// See <see cref="YellowFlagOveride"/> for more details.
        /// </remarks>
        public byte YellowFlagLapsWasOverridden;

        /// <summary>
        /// Indicates whether a safety car exists in the current context.
        /// </summary>
        public byte SafetyCarExists;

        /// <summary>
        /// Indicates whether the safety car is active.
        /// </summary>
        public byte SafetyCarActive;

        /// <summary>
        /// Gets or sets the number of laps completed by the safety car.
        /// </summary>
        public int SafetyCarLaps;

        /// <summary>
        /// Represents the threshold value at which a safety car is deployed.
        /// </summary>
        public float SafetyCarThreshold;

        /// <summary>
        /// Safety car lap distance
        /// </summary>
        public double SafetyCarLapDist;

        /// <summary>
        /// Where the safety car starts from
        /// </summary>
        public float SafetyCarLapDistAtStart;

        /// <summary>
        /// Represents the distance along the track where the waypoint branch to the pit lane begins.
        /// </summary>
        public float PitLaneStartDist;

        /// <summary>
        /// Represents the distance to the front of the teleport locations,  which serves as an initial estimate for
        /// determining where to signal the start of an event.
        /// </summary>
        public float TeleportLapDist;

        /// <summary>
        /// For future expansion.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] InputExpansion;

        /// <summary>
        /// Represents the state of the yellow flag in a racing event.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.YellowFlagState"/> for more details on the possible values.
        /// </remarks>
        public sbyte YellowFlagState;

        /// <summary>
        /// Represents the suggested number of laps to run under a yellow flag condition.
        /// </summary>
        public short YellowFlagLaps;

        /// <summary>
        /// Represents the instruction for the safety car's behavior during a race.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.SafetyCarInstruction"/> for more details on the possible values.
        /// </remarks>
        public int SafetyCarInstruction;

        /// <summary>
        /// Represents the maximum speed, at which the safety car can drive.
        /// </summary>
        public float SafetyCarSpeed;

        /// <summary>
        /// Represents the minimum spacing behind the safety car.
        /// </summary>
        /// <remarks> -1 indicates no limit.</remarks>
        public float SafetyCarMinimumSpacing;

        /// <summary>
        /// Represents the maximum allowable spacing behind the safety car.
        /// </summary>
        /// <remarks> -1 indicates no limit.</remarks>
        public float SafetyCarMaximumSpacing;

        /// <summary>
        /// Represents the minimum desired spacing between vehicles in a column.
        /// </summary>
        /// <remarks>A value of -1 indicates that the spacing is indeterminate or unenforced.</remarks>
        public float MinimumColumnSpacing;

        /// <summary>
        /// Represents the maximum desired spacing between vehicles in a column.
        /// </summary>
        /// <remarks>A value of -1 indicates that the spacing is indeterminate or unenforced.</remarks>
        public float MaximumColumnSpacing;

        /// <summary>
        /// Represents the minimum speed that a vehicle should be driving.
        /// </summary>
        /// <remarks>A value of -1 indicates that there is no minimum speed limit.</remarks>
        public float MinimumSpeed;

        /// <summary>
        /// Represents the maximum speed limit for driving.
        /// </summary>
        /// <remarks>A value of -1 indicates that there is no speed limit.</remarks>
        public float MaximumSpeed;

        /// <summary>
        /// Represents a message intended for all users, providing context or information about the current state.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        public byte[] Message;

        /// <summary>
        /// Not used
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Pointer2;

        /// <summary>
        /// For future expansion.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] InputOutputExpansion;
    }
}
