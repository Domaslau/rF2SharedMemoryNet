using rF2SharedMemoryNet.RF2Data.Enums;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents a participant in track rules management for a racing simulation, including information about
    /// position, status, and rules compliance.
    /// </summary>
    /// <remarks>This structure is used to manage and track the state of individual participants during
    /// formation laps, caution periods, and other race scenarios. It includes input-only fields for participant
    /// identification and status, input/output fields for rules compliance and position assignments,  and additional
    /// fields for messaging and future expansion.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct TrackRulesParticipant
    {
        /// <summary>
        /// Represents the unique identifier for a slot.
        /// </summary>
        public int ID;

        /// <summary>
        /// Represents the 0-based position of the frozen order when a caution flag is issued.
        /// </summary>
        /// <remarks>This value is not valid during formation laps.</remarks>
        public short FrozenOrder;

        /// <summary>
        /// Represents the 1-based position of an entity. 
        /// </summary>
        /// <remarks>Typically used for initializing the track order during a formation lap.</remarks>
        public short Place;

        /// <summary>
        /// Represents the severity rating of how much this vehicle is contributing to a yellow flag.
        /// </summary>
        public float YellowSeverity;

        /// <summary>
        /// Represents the current relative distance of the vehicle in the race.
        /// </summary>
        /// <remarks>The value is calculated as the sum of the lap distance multiplied by the relative
        /// laps and the lap distance of the vehicle. This property is useful for determining the vehicle's position
        /// relative to other competitors.</remarks>
        public double CurrentRelativeDistance;

        // input/output
        /// <summary>
        /// Represents the current number of formation or caution laps relative to the safety car.
        /// </summary>
        /// <remarks>This value is typically zero, except when the safety car crosses the start/finish
        /// line. It can be decremented to implement rules such as the 'wave around' or 'beneficiary rule'  (commonly
        /// referred to as 'lucky dog' or 'free pass').</remarks>
        public int RelativeLaps;

        /// <summary>
        /// Represents the column assignment for a participant, indicating the specific line or lane they are supposed
        /// to be in.
        /// </summary>
        /// <remarks>This field specifies the track rules column for a participant, which determines their
        /// designated position on the track.</remarks>
        public TrackRulesColumn ColumnAssignment;

        /// <summary>
        /// Represents the 0-based position within a column (line or lane) where the participant is assigned.
        /// </summary>
        public int PositionAssignment;

        /// <summary>
        /// Indicates whether the rules allow this particular vehicle to enter the pits at the current time.
        /// </summary>
        /// <remarks>2 for false or 3 for true; if you want to edit it, set to 0 for false or 1 for true.</remarks>
        public byte PitsOpen;

        /// <summary>
        /// Indicates whether the vehicle is up to speed and can be followed while in the frozen order.
        /// </summary>
        /// <remarks>This flag should be set to <see langword="false"/> for vehicles that have temporarily
        /// spun out and have not yet returned to normal speed.</remarks>
        public byte UpToSpeed;

        /// <summary>
        /// Unused
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Unused;


        /// <summary>
        /// Represents the relative distance to the goal, calculated based on the leader's position and adjusted by the
        /// desired column spacing and position assignments.
        /// </summary>
        public double mGoalRelativeDistance;

        /// <summary>
        /// Represents a message intended for a participant, providing context or explanation about the current
        /// situation.
        /// </summary>
        /// <remarks>The message is stored as an array of 96 bytes and is untranslated. It is expected to be
        /// processed by client machines for translation.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
        public byte[] Message;

        /// <summary>
        /// For future expansion.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 192)]
        public byte[] Expansion;
    }
}
