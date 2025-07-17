using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Enums;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using rF2SharedMemoryNet.LMUData.Models;
namespace rF2SharedMemoryNet
{
    /// <summary>
    /// Provides functionality to read various types of data from memory-mapped files used by rFactor2.
    /// </summary>
    /// <remarks>The <see cref="RF2MemoryReader"/> class is designed to interface with rFactor2's shared
    /// memory plugin, allowing access to telemetry, scoring, rules, force feedback, graphics, pit information, weather,
    /// and other data. It attempts to open the necessary memory-mapped files upon instantiation and provides methods to
    /// read data synchronously and asynchronously. The class implements <see cref="IDisposable"/> to ensure proper
    /// release of resources.
    ///  <para><b>Important:</b> Always call <see cref="Dispose"/> when you are done using this class to release memory-mapped file resources.
    ///  If you need to read data from a new instance, create a new <see cref="RF2MemoryReader"/> object.</para>
    /// </remarks>
    [SupportedOSPlatform("windows")]
    public sealed class RF2MemoryReader : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether the object has been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; } = false;

        private MemoryMappedFile? _telemetryFile;
        private MemoryMappedFile? _scoringFile;
        private MemoryMappedFile? _rulesFile;
        private MemoryMappedFile? _forceFeedbackFile;
        private MemoryMappedFile? _GraphicsFile;
        private MemoryMappedFile? _pitInfoFile;
        private MemoryMappedFile? _weatherFile;
        private MemoryMappedFile? _extendedFile;
        private MemoryMappedFile? _hwControlFile;
        private MemoryMappedFile? _weatherControlFile;
        private MemoryMappedFile? _rulesControlFile;
        private MemoryMappedFile? _pluginControlFile;
        private LMUMemoryReader? _lmuMemoryReader;

        private readonly ILogger? _logger;
        private readonly object _disposeLock = new();
        private readonly ReaderWriterLockSlim _readWritelock = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="RF2MemoryReader"/> class, which reads memory-mapped files for
        /// rFactor2 or Le Mans Ultimate telemetry data.
        /// </summary>
        /// <remarks>This constructor attempts to open several memory-mapped files required for reading
        /// telemetry and other data from the rFactor2 or Le Mans Ultimate game. If the game is not running or the necessary plugins are
        /// not installed, errors will be logged if a logger is provided.</remarks>
        /// <param name="logger">An optional logger for capturing error messages and operational logs. Can be <see langword="null"/> if
        /// logging is not required.</param>
        /// <param name="enableDMA">A boolean value indicating whether to enable Direct Memory Access (DMA) for reading data. If <see
        /// langword="true"/>, attempts to initialize the LMU Memory Reader.</param>
        /// <exception cref="InvalidOperationException">Thrown if the LMU Memory Reader fails to initialize when <paramref name="enableDMA"/> is <see
        /// langword="true"/>.  Ensure the game is running and the LMU plugin is installed.</exception>
        public RF2MemoryReader(ILogger? logger = null, bool enableDMA = false)
        {
            _logger = logger;
            if (enableDMA)
            {
                try
                {
                    _lmuMemoryReader = new LMUMemoryReader();
                } catch(Exception e)
                {
                    throw new InvalidOperationException("Failed to initialize LMU Memory Reader. Ensure the game is running and the LMU plugin is installed.", e);
                }
                
            }
            try
            {
                _telemetryFile = MemoryMappedFile.OpenExisting(RFactor2Constants.TELEMETRY_FILE_NAME);
                _scoringFile = MemoryMappedFile.OpenExisting(RFactor2Constants.SCORING_FILE_NAME);
                _rulesFile = MemoryMappedFile.OpenExisting(RFactor2Constants.RULES_FILE_NAME);
                _forceFeedbackFile = MemoryMappedFile.OpenExisting(RFactor2Constants.FORCE_FEEDBACK_FILE_NAME);
                _GraphicsFile = MemoryMappedFile.OpenExisting(RFactor2Constants.GRAPHICS_FILE_NAME);
                _pitInfoFile = MemoryMappedFile.OpenExisting(RFactor2Constants.PITINFO_FILE_NAME);
                _weatherFile = MemoryMappedFile.OpenExisting(RFactor2Constants.WEATHER_FILE_NAME);
                _extendedFile = MemoryMappedFile.OpenExisting(RFactor2Constants.EXTENDED_FILE_NAME);
                _hwControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.HWCONTROL_FILE_NAME);
                _weatherControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.WEATHER_CONTROL_FILE_NAME);
                _rulesControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.RULES_CONTROL_FILE_NAME);
                _pluginControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.PLUGIN_CONTROL_FILE_NAME);
            }
            catch (Exception e)
            {

               

                if (_logger is not null)
                {
                    _logger.LogError($"Error opening memory mapped files: {e.Message}");
                    _logger.LogError("This is likely due to game not running");
                    _logger.LogError("You can ignore this error if game is not running yet");
                    _logger.LogError("If you are running the game, please ensure that the rFactor2 Shared Memory Plugin is installed and enabled.");
                }
#if DEBUG
                Console.WriteLine($"Error opening memory mapped files: {e.Message}");
                Console.WriteLine("This is likely due to game not running");
                Console.WriteLine("You can ignore this error if game is not running yet");
                Console.WriteLine("If you are running the game, please ensure that the rFactor2 Shared Memory Plugin is installed and enabled.");
#endif
            }
        }

        /// <summary>
        /// Retrieves the electronics configuration from the LMU memory reader.
        /// </summary>
        /// <returns>The <see cref="Electronics"/> object representing the current configuration of car electronics.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the LMU memory reader is not initialized. Ensure that the DMA is enabled when creating this
        /// object.</exception>
        public Electronics GetLMUElectronics()
        {
            CheckDisposed();
            if (_lmuMemoryReader is not null)
            {
                try
                {
                    return _lmuMemoryReader.GetElectronics();
                }
                catch (Exception e)
                {
                    PrintError(e.Message, new FileOperationFailedEventArgs(nameof(Electronics), "Failed reading: Electronics from memory. Make sure this is disposed of between game runs.", FileOperationFailType.Read));
                    return new Electronics();
                }
            }
            else
            {
                throw new InvalidOperationException("LMU Memory Reader is not initialized.\nSet enableDMA when creating this object.");
            }
        }

        /// <summary>
        /// Retrieves the telemetry data from the specified file.
        /// </summary>
        /// <remarks>This method attempts to read telemetry data from a predefined file. If the file does
        /// not exist or the data cannot be read, the method returns <see langword="null"/>.</remarks>
        /// <returns>An instance of <see cref="Telemetry"/> containing the telemetry data if available; otherwise, <see
        /// langword="null"/>.</returns>
        public Telemetry? GetTelemetry()
        {
            return GetData<Telemetry>(_telemetryFile);
        }

        /// <summary>
        /// Asynchronously retrieves telemetry data from a specified source.
        /// </summary>
        /// <remarks>This method fetches telemetry data, which may include performance metrics or usage
        /// statistics, from a predefined source. The operation can be canceled by passing a cancellation
        /// token.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the telemetry data, or <see
        /// langword="null"/> if no data is available.</returns>
        public Task<Telemetry?> GetTelemetryAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<Telemetry>(_telemetryFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the scoring data from the specified scoring file.
        /// </summary>
        /// <returns>An instance of <see cref="Scoring"/> containing the scoring data, or <see langword="null"/> if the data
        /// cannot be retrieved.</returns>
        public Scoring? GetScoring()
        {
            return GetData<Scoring>(_scoringFile);
        }

        /// <summary>
        /// Asynchronously retrieves the scoring data.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the scoring data, or <see
        /// langword="null"/> if the data is not available.</returns>
        public Task<Scoring?> GetScoringAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<Scoring>(_scoringFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the rules configuration from the specified data source.
        /// </summary>
        /// <returns>An instance of <see cref="Rules"/> containing the rules configuration, or <see langword="null"/> if the
        /// rules cannot be retrieved.</returns>
        public Rules? GetRules()
        {
            return GetData<Rules>(_rulesFile);
        }

        /// <summary>
        /// Asynchronously retrieves the rules from the specified data source.
        /// </summary>
        /// <remarks>This method fetches the rules data asynchronously, allowing for cancellation through
        /// the provided <paramref name="cancellationToken"/>.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the retrieved <see
        /// cref="Rules"/> object, or <see langword="null"/> if the rules cannot be found.</returns>
        public Task<Rules?> GetRulesAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<Rules>(_rulesFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the force feedback configuration data.
        /// </summary>
        /// <returns>An instance of <see cref="ForceFeedback"/> containing the configuration data, or <see langword="null"/> if
        /// the data is unavailable.</returns>
        public ForceFeedback? GetForceFeedback()
        {
            return GetData<ForceFeedback>(_forceFeedbackFile);
        }

        /// <summary>
        /// Asynchronously retrieves the force feedback data.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the force feedback data, or <see
        /// langword="null"/> if the data is not available.</returns>
        public Task<ForceFeedback?> GetForceFeedbackAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<ForceFeedback>(_forceFeedbackFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the graphics data from the specified graphics file.
        /// </summary>
        /// <returns>An instance of <see cref="Graphics"/> containing the graphics data, or <see langword="null"/> if the data
        /// cannot be retrieved.</returns>
        public Graphics? GetGraphics()
        {
            return GetData<Graphics>(_GraphicsFile);
        }

        /// <summary>
        /// Asynchronously retrieves graphics data from a specified source.
        /// </summary>
        /// <remarks>This method fetches graphics data asynchronously and can be canceled using the
        /// provided <paramref name="cancellationToken"/>.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the graphics data if available;
        /// otherwise, <see langword="null"/>.</returns>
        public Task<Graphics?> GetGraphicsAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<Graphics>(_GraphicsFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about the pit from a data source.
        /// </summary>
        /// <returns>An instance of <see cref="PitInfo"/> containing the pit details, or <see langword="null"/> if the data is
        /// unavailable.</returns>
        public PitInfo? GetPitInfo()
        {
            return GetData<PitInfo>(_pitInfoFile);
        }

        /// <summary>
        /// Asynchronously retrieves the pit information from the specified data source.
        /// </summary>
        /// <remarks>This method fetches the pit information using an asynchronous operation. It is
        /// designed to be non-blocking and can be cancelled by passing a cancellation token.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="PitInfo"/> object
        /// if the data is successfully retrieved; otherwise, <see langword="null"/>.</returns>
        public Task<PitInfo?> GetPitInfoAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<PitInfo>(_pitInfoFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the current weather data.
        /// </summary>
        /// <returns>An instance of <see cref="Weather"/> containing the current weather information, or <see langword="null"/>
        /// if the data is unavailable.</returns>
        public Weather? GetWeather()
        {
            return GetData<Weather>(_weatherFile);
        }

        /// <summary>
        /// Asynchronously retrieves the current weather data.
        /// </summary>
        /// <remarks>This method fetches weather data from a predefined source. It supports cancellation
        /// through the provided <paramref name="cancellationToken"/>.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the current weather data, or <see
        /// langword="null"/> if the data is unavailable.</returns>
        public Task<Weather?> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<Weather>(_weatherFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the extended telemetry data.
        /// </summary>
        /// <returns>An instance of <see cref="ExtendedTelemetry"/> containing the extended telemetry data, or <see
        /// langword="null"/> if the data is unavailable.</returns>
        public ExtendedTelemetry? GetExtended()
        {
            return GetData<ExtendedTelemetry>(_extendedFile);
        }

        /// <summary>
        /// Asynchronously retrieves extended telemetry data.
        /// </summary>
        /// <remarks>This method fetches data from a predefined source and returns it as an <see
        /// cref="ExtendedTelemetry"/> object. The operation can be canceled by passing a cancellation token.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the extended telemetry data, or
        /// <see langword="null"/> if the data is not available.</returns>
        public Task<ExtendedTelemetry?> GetExtendedAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<ExtendedTelemetry>(_extendedFile, cancellationToken);
        }


        /// <summary>
        /// Retrieves the hardware control configuration from the specified data source.
        /// </summary>
        /// <returns>An instance of <see cref="HardwareControl"/> representing the current hardware control settings, or <see
        /// langword="null"/> if the configuration cannot be retrieved.</returns>
        public HardwareControl? GetHWControl()
        {
            return GetData<HardwareControl>(_hwControlFile);
        }

        /// <summary>
        /// Asynchronously retrieves the hardware control configuration.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the hardware control
        /// configuration, or <see langword="null"/> if the configuration is not available.</returns>
        public Task<HardwareControl?> GetHWControlAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<HardwareControl>(_hwControlFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the current weather control settings.
        /// </summary>
        /// <returns>An instance of <see cref="WeatherControl"/> representing the current weather control settings, or <see
        /// langword="null"/> if the settings cannot be retrieved.</returns>
        public WeatherControl? GetWeatherControl()
        {
            return GetData<WeatherControl>(_weatherControlFile);
        }

        /// <summary>
        /// Asynchronously retrieves the current weather control settings.
        /// </summary>
        /// <remarks>This method fetches the weather control data from a predefined source. If the
        /// operation is canceled, the task will be completed with a <see cref="TaskCanceledException"/>.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the current <see
        /// cref="WeatherControl"/> settings, or <see langword="null"/> if the settings could not be retrieved.</returns>
        public Task<WeatherControl?> GetWeatherControlAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<WeatherControl>(_weatherControlFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the <see cref="RulesControl"/> object from the specified data source.
        /// </summary>
        /// <remarks>This method attempts to load the <see cref="RulesControl"/> from a predefined file.
        /// If the file does not exist or the data cannot be parsed, the method returns <see
        /// langword="null"/>.</remarks>
        /// <returns>An instance of <see cref="RulesControl"/> if the data is successfully retrieved; otherwise, <see
        /// langword="null"/>.</returns>
        public RulesControl? GetRulesControl()
        {
            return GetData<RulesControl>(_rulesControlFile);
        }

        /// <summary>
        /// Asynchronously retrieves the rules control data.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="RulesControl"/>
        /// object if available; otherwise, <see langword="null"/>.</returns>
        public Task<RulesControl?> GetRulesControlAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<RulesControl>(_rulesControlFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves the plugin control configuration.
        /// </summary>
        /// <returns>An instance of <see cref="PluginControl"/> representing the plugin control configuration, or <see
        /// langword="null"/> if the configuration is not available.</returns>
        public PluginControl? GetPluginControl()
        {
            return GetData<PluginControl>(_pluginControlFile);
        }

        /// <summary>
        /// Asynchronously retrieves the plugin control data.
        /// </summary>
        /// <remarks>This method fetches the plugin control data from a predefined source. If the data is
        /// not available, the method returns <see langword="null"/>.</remarks>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="PluginControl"/>
        /// object if available; otherwise, <see langword="null"/>.</returns>
        public Task<PluginControl?> GetPluginControlAsync(CancellationToken cancellationToken = default)
        {
            return GetDataAsync<PluginControl>(_pluginControlFile, cancellationToken);
        }

        /// <summary>
        /// Retrieves data of the specified type from a memory-mapped file.
        /// </summary>
        /// <remarks>If the <paramref name="file"/> parameter is <see langword="null"/>, the method
        /// attempts to open a file before reading. The method returns <see langword="null"/> if the file cannot be
        /// opened or if reading fails.</remarks>
        /// <typeparam name="T">The type of data to retrieve. Must be a value type.</typeparam>
        /// <param name="file">The memory-mapped file from which to read data. Can be <see langword="null"/>.</param>
        /// <returns>The data of type <typeparamref name="T"/> if successfully read; otherwise, <see langword="null"/>.</returns>
        private T? GetData<T>(MemoryMappedFile? file) where T : struct
        {
            CheckDisposed();

            if (file is not null)
            {
                return TryRead<T>();
            }
            else
            {
                if (OpenFile<T>())
                {
                    return TryRead<T>();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Asynchronously retrieves data of the specified type from a memory-mapped file.
        /// </summary>
        /// <remarks>If the <paramref name="file"/> parameter is <see langword="null"/>, the method
        /// attempts to open a file before reading.</remarks>
        /// <typeparam name="T">The type of data to retrieve. Must be a value type.</typeparam>
        /// <param name="file">The memory-mapped file from which to read data. Can be <see langword="null"/>.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the data of type <typeparamref
        /// name="T"/> if successful; otherwise, <see langword="null"/>.</returns>
        private async Task<T?> GetDataAsync<T>(MemoryMappedFile? file, CancellationToken cancellationToken = default) where T : struct
        {
            CheckDisposed();
            if (file is not null)
            {
                return await TryReadAsync<T>(cancellationToken);
            }
            else
            {
                if (OpenFile<T>())
                {
                    return await TryReadAsync<T>(cancellationToken);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Attempts to read a value of the specified type from a memory file.
        /// </summary>
        /// <remarks>This method catches exceptions that occur during the read operation and logs an error
        /// message.</remarks>
        /// <typeparam name="T">The type of the value to read, which must be a non-nullable value type.</typeparam>
        /// <returns>The value of type <typeparamref name="T"/> if the read operation is successful; otherwise, <see
        /// langword="null"/>.</returns>
        private T? TryRead<T>() where T : struct
        {
            try
            {
                return ReadMemoryFile<T>();
            }
            catch (Exception e)
            {
                PrintError(e.Message, new FileOperationFailedEventArgs(nameof(T), $"Failed reading: {nameof(T)} file", FileOperationFailType.Read));
                return null;
            }
        }

        /// <summary>
        /// Attempts to read a memory file asynchronously and returns the result.
        /// </summary>
        /// <remarks>This method catches exceptions that occur during the read operation and logs an error
        /// message.</remarks>
        /// <typeparam name="T">The type of the structure to read from the memory file.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The structure of type <typeparamref name="T"/> if the read operation is successful; otherwise, <see
        /// langword="null"/>.</returns>
        private async Task<T?> TryReadAsync<T>(CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                return await ReadMemoryFileAsync<T>(cancellationToken);
            }
            catch (Exception e)
            {
                PrintError(e.Message, new FileOperationFailedEventArgs(nameof(T), $"Failed reading: {nameof(T)} file", FileOperationFailType.Read));
                return null;
            }
        }

        /// <summary>
        /// Opens a memory-mapped file corresponding to the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <remarks>This method attempts to open a memory-mapped file based on the type parameter
        /// <typeparamref name="T"/>. If the file is already open, the method returns <see langword="true"/> without
        /// attempting to reopen it. If the type is not supported, the method returns <see langword="false"/>.</remarks>
        /// <typeparam name="T">The type of the file to open. Supported types include <c>Telemetry</c>, <c>Scoring</c>, <c>Rules</c>,
        /// <c>ForceFeedback</c>, <c>Graphics</c>, <c>PitInfo</c>, <c>Weather</c>, <c>ExtendedTelemetry</c>,
        /// <c>HardwareControl</c>, <c>WeatherControl</c>, <c>RulesControl</c>, and <c>PluginControl</c>.</typeparam>
        /// <returns><see langword="true"/> if the file is successfully opened or already open; otherwise, <see
        /// langword="false"/>.</returns>
        private bool OpenFile<T>()
        {
            try
            {
                switch (typeof(T).Name)
                {
                    case nameof(Telemetry):
                        if (_telemetryFile is not null) return true;
                        _telemetryFile = MemoryMappedFile.OpenExisting(RFactor2Constants.TELEMETRY_FILE_NAME);
                        return true;
                    case nameof(Scoring):
                        if (_scoringFile is not null) return true;
                        _scoringFile = MemoryMappedFile.OpenExisting(RFactor2Constants.SCORING_FILE_NAME);
                        return true;
                    case nameof(Rules):
                        if (_rulesFile is not null) return true;
                        _rulesFile = MemoryMappedFile.OpenExisting(RFactor2Constants.RULES_FILE_NAME);
                        return true;
                    case nameof(ForceFeedback):
                        if (_forceFeedbackFile is not null) return true;
                        _forceFeedbackFile = MemoryMappedFile.OpenExisting(RFactor2Constants.FORCE_FEEDBACK_FILE_NAME);
                        return true;
                    case nameof(Graphics):
                        if (_GraphicsFile is not null) return true;
                        _GraphicsFile = MemoryMappedFile.OpenExisting(RFactor2Constants.GRAPHICS_FILE_NAME);
                        return true;
                    case nameof(PitInfo):
                        if (_pitInfoFile is not null) return true;
                        _pitInfoFile = MemoryMappedFile.OpenExisting(RFactor2Constants.PITINFO_FILE_NAME);
                        return true;
                    case nameof(Weather):
                        if (_weatherFile is not null) return true;
                        _weatherFile = MemoryMappedFile.OpenExisting(RFactor2Constants.WEATHER_FILE_NAME);
                        return true;
                    case nameof(ExtendedTelemetry):
                        if (_extendedFile is not null) return true;
                        _extendedFile = MemoryMappedFile.OpenExisting(RFactor2Constants.EXTENDED_FILE_NAME);
                        return true;
                    case nameof(HardwareControl):
                        if (_hwControlFile is not null) return true;
                        _hwControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.HWCONTROL_FILE_NAME);
                        return true;
                    case nameof(WeatherControl):
                        if (_weatherControlFile is not null) return true;
                        _weatherControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.WEATHER_CONTROL_FILE_NAME);
                        return true;
                    case nameof(RulesControl):
                        if (_rulesControlFile is not null) return true;
                        _rulesControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.RULES_CONTROL_FILE_NAME);
                        return true;
                    case nameof(PluginControl):
                        if (_pluginControlFile is not null) return true;
                        _pluginControlFile = MemoryMappedFile.OpenExisting(RFactor2Constants.PLUGIN_CONTROL_FILE_NAME);
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                PrintError(e.Message, new FileOperationFailedEventArgs(typeof(T).Name, $"Failed opening: {typeof(T).Name} file", FileOperationFailType.Open));
                return false;
            }
        }

        /// <summary>
        /// Reads a memory-mapped file and converts its contents to a structure of type <typeparamref name="T"/>.
        /// </summary>
        /// <remarks>This method reads a memory-mapped file corresponding to the specified structure type
        /// and parses its contents into an instance of that type. The method returns <see langword="null"/> if the
        /// memory-mapped file stream cannot be accessed.</remarks>
        /// <typeparam name="T">The type of structure to read from the memory-mapped file. Must be a value type.</typeparam>
        /// <returns>An instance of type <typeparamref name="T"/> containing the data read from the memory-mapped file, or <see
        /// langword="null"/> if the stream could not be obtained.</returns>
        private T? ReadMemoryFile<T>() where T : struct
        {
            byte[] bytes = new byte[Marshal.SizeOf<T>()];
            using MemoryMappedViewStream? stream = GetStreamFromTypeName(typeof(T).Name);
            if (stream is null)
            {
                return null;
            }
            stream.Read(bytes, 0, bytes.Length);
            return ParseToStruct<T>(bytes);
        }

        /// <summary>
        /// Asynchronously reads a memory-mapped file and parses its contents into a structure of type <typeparamref
        /// name="T"/>.
        /// </summary>
        /// <remarks>This method reads a memory-mapped file based on the type name of <typeparamref
        /// name="T"/> and attempts to parse its contents into the specified structure.</remarks>
        /// <typeparam name="T">The type of structure to read from the memory-mapped file. Must be a value type.</typeparam>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous read operation. The task result contains the parsed structure of
        /// type <typeparamref name="T"/>. If the stream is null, returns a default instance of <typeparamref
        /// name="T"/>.</returns>
        private async Task<T?> ReadMemoryFileAsync<T>(CancellationToken cancellationToken = default) where T : struct
        {
            byte[] bytes = new byte[Marshal.SizeOf<T>()];
            using MemoryMappedViewStream? stream = GetStreamFromTypeName(typeof(T).Name);
            if (stream is null)
            {
                return new T();
            }
            await stream.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
            return ParseToStruct<T>(bytes);
        }

        /// <summary>
        /// Retrieves a <see cref="MemoryMappedViewStream"/> associated with the specified type name.
        /// </summary>
        /// <param name="name">The name of the type for which to retrieve the stream. Must be one of the predefined type names such as
        /// "Telemetry", "Scoring", "Rules", etc.</param>
        /// <returns>A <see cref="MemoryMappedViewStream"/> for the specified type name, or <see langword="null"/> if the type
        /// name is not recognized.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the file associated with the specified type name is not open.</exception>
        private MemoryMappedViewStream? GetStreamFromTypeName(string name)
        {
            return name switch
            {
                nameof(Telemetry) => _telemetryFile?.CreateViewStream() ?? throw new InvalidOperationException("Telemetry file is not open."),
                nameof(Scoring) => _scoringFile?.CreateViewStream() ?? throw new InvalidOperationException("Scoring file is not open."),
                nameof(Rules) => _rulesFile?.CreateViewStream() ?? throw new InvalidOperationException("Rules file is not open."),
                nameof(ForceFeedback) => _forceFeedbackFile?.CreateViewStream() ?? throw new InvalidOperationException("Force Feedback file is not open."),
                nameof(Graphics) => _GraphicsFile?.CreateViewStream() ?? throw new InvalidOperationException("Graphics file is not open."),
                nameof(PitInfo) => _pitInfoFile?.CreateViewStream() ?? throw new InvalidOperationException("Pit Info file is not open."),
                nameof(Weather) => _weatherFile?.CreateViewStream() ?? throw new InvalidOperationException("Weather file is not open."),
                nameof(ExtendedTelemetry) => _extendedFile?.CreateViewStream() ?? throw new InvalidOperationException("Extended file is not open."),
                nameof(HardwareControl) => _hwControlFile?.CreateViewStream() ?? throw new InvalidOperationException("Hardware Control file is not open."),
                nameof(WeatherControl) => _weatherControlFile?.CreateViewStream() ?? throw new InvalidOperationException("Weather Control file is not open."),
                nameof(RulesControl) => _rulesControlFile?.CreateViewStream() ?? throw new InvalidOperationException("Rules Control file is not open."),
                nameof(PluginControl) => _pluginControlFile?.CreateViewStream() ?? throw new InvalidOperationException("Plugin Control file is not open."),
                _ => null
            };
        }

        /// <summary>
        /// Converts a byte array to a structure of type <typeparamref name="T"/>.
        /// </summary>
        /// <remarks>This method uses unmanaged memory allocation to perform the conversion. Ensure that
        /// the byte array is of the correct size for the target structure type to avoid unexpected behavior.</remarks>
        /// <typeparam name="T">The type of the structure to convert to. Must be a value type.</typeparam>
        /// <param name="bytes">The byte array containing the data to be converted into the structure.</param>
        /// <returns>An instance of type <typeparamref name="T"/> populated with data from the byte array, or <see
        /// langword="null"/> if the conversion fails.</returns>
        private T? ParseToStruct<T>(byte[] bytes) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            nint ptr = nint.Zero;
            T page = new();

            try
            {
                ptr = Marshal.AllocHGlobal(size);
                Marshal.Copy(bytes, 0, ptr, size);
                object? data = Marshal.PtrToStructure(ptr, page.GetType());
                if (data != null)
                {
                    page = (T)data;
                    return page;
                }

            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine($"Error parsing structure {typeof(T).Name}: {e.Message}");
#endif
                PrintError(e.Message, new FileOperationFailedEventArgs(nameof(T), $"Failed parsing: {typeof(T).Name} structure", FileOperationFailType.Parse));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return null;
        }

        /// <summary>
        /// Logs the error message and exception details related to a file operation failure.
        /// </summary>
        /// <remarks>This method logs the provided error messages using the configured logger. In debug
        /// mode, it also writes the error messages to the console.</remarks>
        /// <param name="exceptionMessage">The message describing the exception that occurred.</param>
        /// <param name="args">The event arguments containing additional details about the file operation failure.</param>
        private void PrintError(string exceptionMessage, FileOperationFailedEventArgs args)
        {

            if (_logger is not null)
            {
                _logger.LogError(exceptionMessage);
                _logger.LogError(args.ErrorMessage);
            }
#if DEBUG
            Console.WriteLine(args.ErrorMessage);
            Console.WriteLine(exceptionMessage);
#endif
        }


        private void CheckDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(nameof(RF2MemoryReader), "The RF2MemoryReader instance has already been disposed.");
            }
        }





        /// <summary>
        /// Disposes of the resources used by the <see cref="RF2MemoryReader"/>.
        /// </summary>
        /// <remarks>
        /// <b>Important:</b> Call this method when you are done using the <see cref="RF2MemoryReader"/> to release memory-mapped file resources. Failure to do so may result in resource leaks.
        /// <para>If you need to read data from a new instance, create a new <see cref="RF2MemoryReader"/> object after disposing of the current one.</para>
        /// </remarks>
        public void Dispose()
        {
            lock (_disposeLock)
            {
                if(IsDisposed)
                {
                    return;
                }
                DisposeOfDisposable(_telemetryFile);
                DisposeOfDisposable(_scoringFile);
                DisposeOfDisposable(_rulesFile);
                DisposeOfDisposable(_forceFeedbackFile);
                DisposeOfDisposable(_GraphicsFile);
                DisposeOfDisposable(_pitInfoFile);
                DisposeOfDisposable(_weatherFile);
                DisposeOfDisposable(_extendedFile);
                DisposeOfDisposable(_hwControlFile);
                DisposeOfDisposable(_weatherControlFile);
                DisposeOfDisposable(_rulesControlFile);
                DisposeOfDisposable(_pluginControlFile);
                DisposeOfDisposable(_lmuMemoryReader);
            }
        }

        private void DisposeOfDisposable(IDisposable? disposable)
        {
            try
            {
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            catch (Exception e)
            {
                PrintError("Error while disposing of file", new FileOperationFailedEventArgs(disposable?.GetType().Name ?? "Unknown", $"Failed disposing: {disposable?.GetType().Name ?? "Unknown"} file", FileOperationFailType.Dispose));
            }
        }
    }

}