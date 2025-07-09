using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents detailed scoring and telemetry data for a vehicle in rFactor 2.
    /// </summary>
    /// <remarks>This structure provides comprehensive information about a vehicle's state, performance, and
    /// position during a race or session. It includes data such as lap times, sector times, position, control status,
    /// and telemetry details. Many fields are specific to rFactor 2's internal scoring and telemetry system.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct VehicleScoring
    {
        /// <summary>
        /// Represents the slot ID for a player in a multiplayer session.
        /// </summary>
        public int ID;

        /// <summary>
        /// Represents the name of the driver as a byte array.
        /// </summary>
        /// <remarks>The driver name is stored as a 32 byte array.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] DriverName;

        /// <summary>
        /// Represents the name of the vehicle as a byte array.
        /// </summary>
        /// <remarks>The array is fixed in size to 64 bytes.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] VehicleName;

        /// <summary>
        /// Represents the total number of laps completed.
        /// </summary>
        public short TotalLaps;

        /// <summary>
        /// Represents the sector identifier in a specific sequence.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.Sector"/> for possible values:
        /// </remarks>
        public sbyte Sector;

        /// <summary>
        /// Represents the status of the vehicle's finish.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.FinishStatus"/> for possible values:
        /// </remarks>
        public sbyte FinishStatus;

        /// <summary>
        /// Current distance around the track
        /// </summary>
        public double LapDist;

        /// <summary>
        /// Lateral position with respect to the <b>approximate</b> "center" path.
        /// </summary>
        public double PathLateral;

        /// <summary>
        /// Represents the track edge position relative to the center path on the same side of the track as the vehicle.
        /// </summary>
        public double TrackEdge;

        /// <summary>
        /// Represents the best recorded time for sector 1.
        /// </summary>
        public double BestSector1;

        /// <summary>
        /// Represents the best time recorded for sector 2, including the time from sector 1.
        /// </summary>
        public double BestSector2;

        /// <summary>
        /// Represents the best lap time achieved during a race.
        /// </summary>
        public double BestLapTime;

        /// <summary>
        /// Represents the recorded time for the last Sector 1.
        /// </summary>
        public double LastSector1;

        /// <summary>
        /// Represents the time of the last sector 2 plus sector 1.
        /// </summary>
        public double LastSector2;

        /// <summary>
        /// Represents the time of the last lap
        /// </summary>
        public double LastLapTime;

        /// <summary>
        /// Time of current sector 1 if valid.
        /// </summary>
        public double CurSector1;


        /// <summary>
        /// Time of current sector 2 plus sector 1 if valid.
        /// </summary>
        public double CurSector2;

        /// <summary>
        /// Number of pitstops made by the vehicle.
        /// </summary>
        public short NumPitstops;

        /// <summary>
        /// Number of penalties currently outstanding for the vehicle.
        /// </summary>
        public short NumPenalties;

        /// <summary>
        /// Is this the player's vehicle.
        /// </summary>
        public byte IsPlayer;

        /// <summary>
        /// Who is in control of the vehicle.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.ControlEntity"/> for possible values:
        /// </remarks>
        public sbyte Control;

        /// <summary>
        /// Is in the pits.
        /// </summary>
        public byte InPits;

        /// <summary>
        /// 1-based position of the vehicle.
        /// </summary>
        public byte Place;

        /// <summary>
        /// Name of vehicle class.
        /// </summary>
        /// <remarks>The array is marshaled as a fixed-size unmanaged array with a size of 32 bytes.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] VehicleClass;

        /// <summary>
        /// Time behind the vehicle in the next higher place.
        /// </summary>
        public double TimeBehindNext;

        /// <summary>
        /// Laps behind the vehicle in the next higher place.
        /// </summary>
        public int LapsBehindNext;

        /// <summary>
        /// Time behind leader vehicle.
        /// </summary>
        public double TimeBehindLeader;

        /// <summary>
        /// laps behind leader vehicle.
        /// </summary>
        public int LapsBehindLeader;

        /// <summary>
        /// Time this lap was started.
        /// </summary>
        public double LapStartTime;

        /// <summary>
        /// World position in meters.
        /// </summary>
        public Vec3 Position;

        /// <summary>
        /// Velocity (meters/sec) in local vehicle coordinates.
        /// </summary>
        public Vec3 LocalVelocity;

        /// <summary>
        /// Acceleration (meters/sec^2) in local vehicle coordinates
        /// </summary>
        public Vec3 LocalAcceleration;

        /// <summary>
        /// Represents the rows of an orientation matrix.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public Vec3[] Orientation;
        /// <summary>
        /// Represents the rotational velocity of the vehicle in local coordinates.
        /// </summary>
        public Vec3 LocalRotation;

        /// <summary>
        /// Represents the rotational acceleration in local vehicle coordinates.
        /// </summary>
        public Vec3 LocalRotationalAcceleration;

        /// <summary>
        /// Headlights status.
        /// </summary>
        public byte Headlights;

        /// <summary>
        /// Pit state of the vehicle.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.PitState"/> for possible values:
        /// </remarks>
        public byte PitState;

        /// <summary>
        /// whether this vehicle is being scored by server. 
        /// </summary>
        /// <remarks>
        /// Could be off in qualifying or racing heats.
        /// </remarks>
        public byte ServerScored;

        /// <summary>
        /// Game phases
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.GamePhase"/> for possible values.
        /// </remarks>
        public byte IndividualPhase;

        /// <summary>
        /// Qualification status 1-based.
        /// </summary>
        /// <remarks>
        /// -1 indicates an invalid qualification status.
        /// </remarks>
        public int Qualification;

        /// <summary>
        /// Estimated time into lap.
        /// </summary>
        public double TimeIntoLap;

        /// <summary>
        /// Estimated laptime.
        /// </summary>
        public double EstimatedLapTime;

        /// <summary>
        /// Pit group name.
        /// </summary>
        /// <remarks>
        /// Stored a fixed-size byte array of 24 bytes.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] PitGroup;

        /// <summary>
        /// Represents the current flag being shown to the vehicle.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.PrimaryFlags"/> for possible values.
        /// </remarks>
        public byte Flag;

        /// <summary>
        /// Indicates whether the car has taken a full-course caution flag at the start/finish line.
        /// </summary>
        public byte UnderYellow;

        /// <summary>
        /// Represents the flag indicating how laps and time are counted during an operation.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.CountLapFlag"/> for possible values:
        /// </remarks>
        public byte CountLapFlag;

        /// <summary>
        /// Is in correct garage stall.
        /// </summary>
        public byte InGarageStall;

        /// <summary>
        /// Coded upgrades
        /// </summary>
        /// <remarks>
        /// Stored as a fixed-size byte array of 16 bytes.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] UpgradePack;

        /// <summary>
        /// Represents the location of the pit in terms of lap distance.
        /// </summary>
        public float PitLapDist;

        /// <summary>
        /// Sector 1 time from best lap (not necessarily the best sector 1 time)
        /// </summary>
        public float BestLapSector1;         // sector 1 time from best lap (not necessarily the best sector 1 time)
        /// <summary>
        /// Sector 2 time from best lap (not necessarily the best sector 2 time)
        /// </summary>
        public float BestLapSector2;

        /// <summary>
        /// For future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] Expansion;
    }
}
