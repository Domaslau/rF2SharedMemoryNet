using rF2SharedMemoryNet.RF2Data.Constants;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the extended data structure for rFactor 2, providing detailed information about the simulation state,
    /// session transitions, plugin configurations, and various control inputs.
    /// </summary>
    /// <remarks>This structure is used to capture and expose extended simulation data for rFactor 2,
    /// including session timing, plugin states, damage tracking, and control input buffers. It is primarily intended
    /// for advanced integrations and plugins interacting with the rFactor 2 API. <para> The structure includes fields
    /// for session timing, plugin-specific data, and direct memory access flags, among others. Some fields, such as
    /// <see cref="SCRPluginEnabled"/> and <see cref="SCRPluginDoubleFileType"/>, are specific to the Stock Car Rules
    /// plugin. </para> <para> Note that certain fields, such as <see cref="UnsubscribedBuffersMask"/>, may be writable
    /// by clients in future API updates. </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct ExtendedTelemetry
    {
        /// <summary>
        /// Incremented right before buffer is written to.
        /// </summary>
        public uint VersionUpdateBegin;

        /// <summary>
        /// Incremented after buffer write is done.
        /// </summary>
        public uint VersionUpdateEnd;

        /// <summary>
        /// API version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] Version;

        /// <summary>
        /// Is 64bit plugin?
        /// </summary>
        public byte Is64bit;

        /// <summary>
        /// Represents the physics options for the session.
        /// </summary>
        /// <remarks>This property contains configuration settings related to the physics engine. The
        /// options are updated at the start of each session.</remarks>
        public PhysicsOptions Physics;

        /// <summary>
        /// Represents an array of tracked damage information for RF2 entities.
        /// </summary>
        /// <remarks>The array is fixed in size, determined by <see
        /// cref="RFactor2Constants.MAX_MAPPED_IDS"/>. Each element in the array corresponds to a specific tracked
        /// damage instance.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_MAPPED_IDS)]
        public TrackedDamage[] TrackedDamages;

        /// <summary>
        /// Represents the current state of the system in real-time mode.
        /// </summary>
        public byte InRealtimeFC;

        /// <summary>
        /// Indicates whether the multimedia thread has started.
        /// </summary>
        public byte MultimediaThreadStarted;

        /// <summary>
        /// Indicates whether the simulation thread has started.
        /// </summary>
        public byte SimulationThreadStarted;

        /// <summary>
        /// Indicates whether a session has started.
        /// </summary>
        public byte SessionStarted;

        /// <summary>
        /// Represents the timestamp, in ticks, when the session started.
        /// </summary>
        public long TicksSessionStarted;

        /// <summary>
        /// Represents the timestamp, in ticks, when the session ended.
        /// </summary>
        public long TicksSessionEnded;

        /// <summary>
        /// Represents the session transition capture for RF2, containing partial internal data captured during session
        /// transitions.
        /// </summary>
        public SessionTransitionCapture SessionTransitionCapture;

        /// <summary>
        /// Represents a byte array used to store the displayed message update capture.
        /// </summary>
        /// <remarks>The array has a fixed size of 128 bytes.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] DisplayedMessageUpdateCapture;

        /// <summary>
        /// Indicates whether direct memory access is enabled.
        /// </summary>
        public byte DirectMemoryAccessEnabled;

        /// <summary>
        /// Represents the timestamp, in ticks, when the status message was last updated.
        /// </summary>
        public long TicksStatusMessageUpdated;

        /// <summary>
        /// Represents a status message as a fixed-length array of bytes.
        /// </summary>
        /// <remarks>The array is marshaled as a fixed-size buffer with a length defined by <see
        /// cref="RFactor2Constants.MAX_STATUS_MSG_LEN"/>. This member is typically used for interop scenarios where a
        /// fixed-size buffer is required.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_STATUS_MSG_LEN)]
        public byte[] StatusMessage;

        /// <summary>
        /// Represents the timestamp, in ticks, when the last message history was updated.
        /// </summary>
        public long TicksLastHistoryMessageUpdated;

        /// <summary>
        /// Represents the last history message received, stored as a byte array.
        /// </summary>
        /// <remarks>
        /// The array is fixed in size, defined by <see cref="RFactor2Constants.MAX_STATUS_MSG_LEN"/>.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_STATUS_MSG_LEN)]
        public byte[] LastHistoryMessage;

        /// <summary>
        /// Represents the current pit speed limit in meters per second.
        /// </summary>
        public float CurrentPitSpeedLimit;

        /// <summary>
        /// Stock Car Rules plugin is enabled.
        /// </summary>
        public byte SCRPluginEnabled;
        /// <summary>
        /// Stock Car Rules plugin DoubleFileType value, only meaningful if mSCRPluginEnabled is true.
        /// </summary>
        public int SCRPluginDoubleFileType;

        /// <summary>
        /// Represents the timestamp, in ticks, of when the last LSI phase message was updated.
        /// </summary>
        public long TicksLSIPhaseMessageUpdated;

        /// <summary>
        /// Represents a message used in the LSI phase, stored as a fixed-length array of bytes.
        /// </summary>
        /// <remarks>The array is marshaled as a fixed-size buffer with a length defined by <see
        /// cref="RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN"/>. This member is typically used for interop
        /// scenarios where a fixed-size buffer is required.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN)]
        public byte[] LSIPhaseMessage;

        /// <summary>
        /// Represents the timestamp, in ticks, when the last LSI pit state message was updated.
        /// </summary>
        public long TicksLSIPitStateMessageUpdated;

        /// <summary>
        /// Represents a message containing pit state information for LSIs (Local Shared Instructions).
        /// </summary>
        /// <remarks>The message is stored as a fixed-length byte array with a maximum size defined by 
        /// <see cref="RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN"/>.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN)]
        public byte[] LSIPitStateMessage;

        /// <summary>
        /// Represents the timestamp, in ticks, of the last update to the LSI order instruction message.
        /// </summary>
        public long TicksLSIOrderInstructionMessageUpdated;

        /// <summary>
        /// Represents the order instruction message for a specific rule set.
        /// </summary>
        /// <remarks>
        /// Array is fixed in size, defined by <see cref="RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN"/>.
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN)]
        public byte[] LSIOrderInstructionMessage;

        /// <summary>
        /// Represents the timestamp, in ticks, of the last update to the FCY rules instruction message.
        /// </summary>
        public long TicksLSIRulesInstructionMessageUpdated;

        /// <summary>
        /// Represents a fixed-size array of bytes containing the rules instruction message.
        /// </summary>
        /// <remarks>The array is marshaled as a fixed-size buffer with a length defined by <see
        /// cref="RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN"/>. This member is typically used for interop
        /// scenarios where a specific buffer size is required.</remarks>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = RFactor2Constants.MAX_RULES_INSTRUCTION_MSG_LEN)]
        public byte[] LSIRulesInstructionMessage;

        /// <summary>
        /// Currently active UnsbscribedBuffersMask value.  This will be allowed for clients to write to in the future, but not yet.
        /// </summary>
        public int UnsubscribedBuffersMask;

        /// <summary>
        /// HWControl input buffer is enabled.
        /// </summary>
        public byte HWControlInputEnabled;

        /// <summary>
        /// WeatherControl input buffer is enabled.
        /// </summary>
        public byte WeatherControlInputEnabled;

        /// <summary>
        /// RulesControl input buffer is enabled.
        /// </summary>
        public byte RulesControlInputEnabled;

        /// <summary>
        /// Plugin control input buffer is enabled.
        /// </summary>
        public byte PluginControlInputEnabled;
    }
}
