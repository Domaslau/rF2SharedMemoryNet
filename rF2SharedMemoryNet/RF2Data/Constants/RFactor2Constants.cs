namespace rF2SharedMemoryNet.RF2Data.Constants
{
    /// <summary>
    /// Provides constants used for interacting with rFactor 2 shared memory and control mechanisms.
    /// </summary>
    /// <remarks>This class contains file names, layout versions, and other constants that are used for
    /// accessing rFactor 2 shared memory data and control interfaces. These constants are intended for use in
    /// applications that integrate with rFactor 2 telemetry, scoring, rules, force feedback, graphics, weather, and
    /// other systems.</remarks>
    public static class RFactor2Constants
    {
        /// <summary>
        /// Represents the default file name used for telemetry data in rFactor2.
        /// </summary>
        /// <remarks>This constant is typically used to identify the telemetry file when interacting with
        /// the rFactor2 simulation.</remarks>
        public const string TELEMETRY_FILE_NAME = "$rFactor2SMMP_Telemetry$";

        /// <summary>
        /// Represents the default file name used for scoring in the rFactor2 Shared Memory Plugin.
        /// </summary>
        /// <remarks>This constant is used as the identifier for the scoring file in the rFactor2 Shared
        /// Memory Plugin. It is intended for use in scenarios where scoring data needs to be accessed or
        /// manipulated.</remarks>
        public const string SCORING_FILE_NAME = "$rFactor2SMMP_Scoring$";

        /// <summary>
        /// The default file name used for storing rFactor2 shared memory plugin rules.
        /// </summary>
        /// <remarks>This constant represents the file name used by the rFactor2 shared memory plugin to
        /// manage rules. It is intended for use in scenarios where the plugin requires a predefined file name for rule
        /// storage.</remarks>
        public const string RULES_FILE_NAME = "$rFactor2SMMP_Rules$";

        /// <summary>
        /// Represents the file name used for storing force feedback data in rFactor2.
        /// </summary>
        /// <remarks>This constant is used as the identifier for the shared memory file that contains
        /// force feedback information. It is specific to the rFactor2 simulation software.</remarks>
        public const string FORCE_FEEDBACK_FILE_NAME = "$rFactor2SMMP_ForceFeedback$";

        /// <summary>
        /// Represents the file name used for the rFactor2 shared memory graphics data.
        /// </summary>
        /// <remarks>This constant is used to identify the shared memory file containing graphics-related
        /// data for the rFactor2 simulation.</remarks>
        public const string GRAPHICS_FILE_NAME = "$rFactor2SMMP_Graphics$";

        /// <summary>
        /// Represents the file name used for storing pit information in rFactor2 Shared Memory Map.
        /// </summary>
        /// <remarks>This constant is used as the identifier for the pit information file in the rFactor2
        /// simulation. It is intended for use in applications interfacing with rFactor2's shared memory
        /// system.</remarks>
        public const string PITINFO_FILE_NAME = "$rFactor2SMMP_PitInfo$";

        /// <summary>
        /// Represents the default file name used for storing weather data in the rFactor2 Shared Memory Plugin.
        /// </summary>
        /// <remarks>This constant is used as the identifier for the weather-related shared memory file.
        /// It is intended for use in applications interfacing with the rFactor2 simulation environment.</remarks>
        public const string WEATHER_FILE_NAME = "$rFactor2SMMP_Weather$";

        /// <summary>
        /// Represents the name of the extended shared memory file used by rFactor2.
        /// </summary>
        /// <remarks>This constant is used to identify the extended shared memory file for rFactor2. It is
        /// typically required when interacting with the rFactor2 simulation's shared memory system.</remarks>
        public const string EXTENDED_FILE_NAME = "$rFactor2SMMP_Extended$";

        /// <summary>
        /// Represents the file name used for hardware control in rFactor2 Shared Memory Plugin.
        /// </summary>
        /// <remarks>This constant is used as a key or identifier for hardware control operations within
        /// the rFactor2 Shared Memory Plugin.</remarks>
        public const string HWCONTROL_FILE_NAME = "$rFactor2SMMP_HWControl$";

        /// <summary>
        /// Represents the version number of the hardware control layout.
        /// </summary>
        /// <remarks>This constant is used to identify the version of the hardware control layout
        /// configuration. It can be used for compatibility checks or version-specific operations.</remarks>
        public const int HWCONTROL_LAYOUT_VERSION = 1;

        /// <summary>
        /// Represents the file name used for weather control in rFactor2 shared memory.
        /// </summary>
        /// <remarks>This constant is used to identify the weather control file in the rFactor2 simulation
        /// environment. It is intended for use in shared memory operations related to weather settings.</remarks>
        public const string WEATHER_CONTROL_FILE_NAME = "$rFactor2SMMP_WeatherControl$";

        /// <summary>
        /// Represents the version number of the weather control layout.
        /// </summary>
        /// <remarks>This constant is used to identify the current version of the weather control layout.
        /// It can be used for compatibility checks or version-specific logic.</remarks>
        public const int WEATHER_CONTROL_LAYOUT_VERSION = 1;

        /// <summary>
        /// Represents the name of the control file used for managing rules in the rFactor2 Shared Memory Plugin.
        /// </summary>
        /// <remarks>This constant is used as a key or identifier for the rules control file in the
        /// rFactor2 Shared Memory Plugin. It is intended for internal use or integration scenarios where the plugin
        /// requires a specific file name.</remarks>
        public const string RULES_CONTROL_FILE_NAME = "$rFactor2SMMP_RulesControl$";

        /// <summary>
        /// Represents the version number for the control layout rules.
        /// </summary>
        /// <remarks>This constant is used to identify the version of the control layout rules. It can be
        /// used for compatibility checks or version-specific logic.</remarks>
        public const int RULES_CONTROL_LAYOUT_VERSION = 1;

        /// <summary>
        /// Represents the name of the plugin control file used by the rFactor2 Shared Memory Plugin.
        /// </summary>
        /// <remarks>This constant defines the file name that the rFactor2 Shared Memory Plugin uses for
        /// control operations. It is intended for use in scenarios where interaction with the plugin's control
        /// mechanisms is required.</remarks>
        public const string PLUGIN_CONTROL_FILE_NAME = "$rFactor2SMMP_PluginControl$";

        /// <summary>
        /// Represents the version number of the plugin control layout.
        /// </summary>
        /// <remarks>This constant is used to identify the version of the plugin control layout. It can be
        /// used for compatibility checks or version-specific behavior.</remarks>
        public const int PLUGIN_CONTROL_LAYOUT_VERSION = 1;

        /// <summary>
        /// Represents the maximum number of vehicles that can be mapped.
        /// </summary>
        /// <remarks>This constant defines the upper limit for the number of vehicles that can be tracked
        /// or processed in a mapping operation. It is intended to ensure consistent behavior and prevent exceeding
        /// system capacity.</remarks>
        public const int MAX_MAPPED_VEHICLES = 128;

        /// <summary>
        /// Represents the maximum number of IDs that can be mapped.
        /// </summary>
        /// <remarks>This constant defines the upper limit for the number of IDs that can be mapped in
        /// operations or configurations that rely on ID mapping. It is intended to ensure consistency and prevent
        /// exceeding predefined limits.</remarks>
        public const int MAX_MAPPED_IDS = 512;

        /// <summary>
        /// Represents the maximum length, in characters, allowed for a status message.
        /// </summary>
        /// <remarks>This constant can be used to enforce a limit on the length of status messages in
        /// applications where message size constraints are required.</remarks>
        public const int MAX_STATUS_MSG_LEN = 128;

        /// <summary>
        /// Represents the maximum length, in characters, of a rules instruction message.
        /// </summary>
        /// <remarks>This constant defines the upper limit for the length of instruction messages related
        /// to rules. Messages exceeding this length may need to be truncated or handled appropriately.</remarks>
        public const int MAX_RULES_INSTRUCTION_MSG_LEN = 96;

        /// <summary>
        /// Represents the maximum length, in characters, for hardware control names.
        /// </summary>
        /// <remarks>This constant defines the upper limit for the length of hardware control name
        /// strings. It can be used to validate input or ensure compatibility with systems that enforce this
        /// limit.</remarks>
        public const int MAX_HWCONTROL_NAME_LEN = 96;
    }
}
