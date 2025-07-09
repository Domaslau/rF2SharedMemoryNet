using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents scoring information for a session in rFactor 2, including track details, session timing, weather
    /// conditions, and multiplayer settings.
    /// </summary>
    /// <remarks>This structure provides detailed information about the current state of a session in rFactor
    /// 2, including track name, session type, timing data, weather conditions, and multiplayer server details. It is
    /// primarily used for telemetry and plugin development to monitor and interact with the game state.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct ScoringInfo
    {
        /// <summary>
        /// Represents the name of the current track.
        /// </summary>
        /// <remarks>The track name is stored as a fixed-size array of 64 bytes.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] TrackName;

        /// <summary>
        /// Represents the current session of the event.
        /// </summary>
        /// <remarks><list type="table"><item>
        /// <term>0</term>
        /// <description>Test day session.</description>
        /// </item>
        /// <item>
        /// <term>1-4</term>
        /// <description>Practice sessions, numbered 1 to 4.</description>
        /// </item>
        /// <item>
        /// <term>5-8</term>
        /// <description>Qualifying sessions, numbered 5 to 8.</description>
        /// </item>
        /// <item>
        /// <term>9</term>
        /// <description>Warmup session.</description>
        /// </item>
        /// <item>
        /// <term>10-13</term>
        /// <description> Race session</description>
        /// </item>
        /// </list>
        /// </remarks>
        public int Session;

        /// <summary>
        /// Represents the current session time.
        /// </summary>
        public double CurrentET;

        /// <summary>
        /// Ending time of the session.
        /// </summary>
        public double EndET;

        /// <summary>
        /// Max laps for the session.
        /// </summary>
        public int MaxLaps;

        /// <summary>
        /// Represents the distance traveled around the track in meters.
        /// </summary>
        /// <remarks>This field stores the current lap distance for a vehicle or entity on the track. The
        /// value is typically updated as the entity progresses along the track.</remarks>
        public double LapDist;

        /// <summary>
        /// Not used
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Pointer1;

        /// <summary>
        /// Represents the current number of vehicles.
        /// </summary>
        public int NumVehicles;

        /// <summary>
        /// Represents the current phase of the game session.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.GamePhase"/> for more details on the possible values."/>
        /// </remarks>
        public byte GamePhase;

        /// <summary>
        /// Represents the current state of the yellow flag during a full-course caution.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.YellowFlagState"/> for more details on the possible values.
        /// </remarks>
        public sbyte YellowFlagState;

        /// <summary>
        /// Represents the flags indicating the presence of local yellow warnings in each sector.
        /// </summary>
        /// <remarks>The array contains three elements, each representing a sector. The mapping of sectors
        /// to array indices (whether sector 0 corresponds to the first or last index) is not explicitly defined and
        /// should be verified.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public sbyte[] SectorFlag;

        /// <summary>
        /// Represents the starting light frame number for a track.
        /// </summary>
        /// <remarks>The value of this field depends on the specific track configuration.</remarks>
        public byte StartLight;

        /// <summary>
        /// Represents the number of red lights in the start sequence.
        /// </summary>
        /// <remarks>This value indicates the total count of red lights displayed during the start
        /// sequence. It can be used to determine the duration or configuration of the sequence.</remarks>
        public byte NumRedLights;

        /// <summary>
        /// Indicates whether the operation is performed in real-time as opposed to being monitored.
        /// </summary>
        public byte InRealtime;

        /// <summary>
        /// Represents the name of the player, including any possible multiplayer override.
        /// </summary>
        /// <remarks>
        /// Array of bytes with a fixed size of 32 bytes.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] PlayerName;

        /// <summary>
        /// Represents a byte array that may be encoded to form a legal filename.
        /// </summary>
        /// <remarks>The array is fixed in size to 64 bytes and may contain encoded data to ensure
        /// compatibility with file naming conventions.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] PlrFileName;

        // weather
        /// <summary>
        /// Represents the darkness level of clouds in the weather system.
        /// </summary>
        public double DarkCloud;

        /// <summary>
        /// Represents the severity of rainfall on a scale from 0.0 to 1.0.
        /// </summary>
        public double Raining;

        /// <summary>
        /// Represents the ambient temperature in degrees Celsius.
        /// </summary>
        public double AmbientTemp;

        /// <summary>
        /// Represents the temperature of the track in degrees Celsius.
        /// </summary>
        public double TrackTemp;

        /// <summary>
        /// Represents the wind speed as a three-dimensional vector.
        /// </summary>
        public Vec3 Wind;

        /// <summary>
        /// Represents the minimum wetness level on the main path.
        /// </summary>
        public double MinPathWetness;

        /// <summary>
        /// Represents the maximum wetness level on the main path, ranging from 0.0 to 1.0.
        /// </summary>
        public double MaxPathWetness;

        /// <summary>
        /// Represents the game mode for multiplayer functionality.
        /// </summary>
        /// <remarks>
        /// See <see cref="Enums.GameMode"/> for more details on the possible values.
        /// </remarks>
        public byte GameMode;

        /// <summary>
        /// Indicates whether the server is password protected.
        /// </summary>
        public byte IsPasswordProtected;

        /// <summary>
        /// Represents the port number of the server.
        /// </summary>
        public ushort ServerPort;

        /// <summary>
        /// Represents the public IP address of the server.
        /// </summary>
        public uint ServerPublicIP;

        /// <summary>
        /// Represents the maximum number of vehicles that can be in the session.
        /// </summary>
        public int MaxPlayers;

        /// <summary>
        /// Represents the name of the server as a fixed-size byte array.
        /// </summary>
        /// <remarks>The array is marshaled as a fixed-size unmanaged array with a maximum size of 32
        /// bytes.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] ServerName;

        /// <summary>
        /// Represents the start time of the event, measured in seconds since midnight.
        /// </summary>
        public float StartET;

        /// <summary>
        /// Represents the average wetness on the main path, expressed as a value between 0.0 and 1.0.
        /// </summary>
        public double AvgPathWetness;

        /// <summary>
        /// For future expansion.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public byte[] Expansion;

        /// <summary>
        /// Not used
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Pointer2;
    }
}
