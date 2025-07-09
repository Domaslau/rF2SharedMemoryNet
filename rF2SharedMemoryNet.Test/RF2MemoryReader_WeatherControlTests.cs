using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the weather control-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetWeatherControl"/> and <see cref="RF2MemoryReader.GetWeatherControlAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_WeatherControlTests : GetTest<WeatherControl>
    {
        [TestMethod]
        public void Test_GetWeatherControl_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var weatherControl = _reader?.GetWeatherControl();
            // Assert
            Assert.IsNull(weatherControl, "WeatherControl should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetWeatherControlAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var weatherControl = await _reader!.GetWeatherControlAsync();
            // Assert
            Assert.IsNull(weatherControl, "WeatherControl should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetWeatherControl_ReturnsWeatherControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.WEATHER_CONTROL_FILE_NAME, _testData);
            // Act
            var weatherControl = _reader?.GetWeatherControl();
            // Assert
            Assert.IsNotNull(weatherControl, "WeatherControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, weatherControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetWeatherControlAsync_ReturnsWeatherControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.WEATHER_CONTROL_FILE_NAME, _testData);
            // Act
            var weatherControl = await _reader!.GetWeatherControlAsync();
            // Assert
            Assert.IsNotNull(weatherControl, "WeatherControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, weatherControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetWeatherControlFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetWeatherControl();

            // Assert
            Assert.IsNull(extendedTelemetry, "ExtendedTelemetry should be null when the file is not opened.");

            // Verify that the logger was called with the expected message
            _loggerMock?.Verify(
                logger => logger.Log(
                   It.Is<LogLevel>(level => level == LogLevel.Error),
                   It.IsAny<EventId>(),
                   It.Is<It.IsAnyType>((v, t) => _expectedFailMessages.Any(expected => (v.ToString() ?? string.Empty).Contains(expected))),
                   It.IsAny<Exception>(),
                   It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)
                ),
                Times.Once()
             );
        }

        [TestMethod]
        public async Task Test_Logger_WritesErrorMessage_WhenGetWeatherControlAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetWeatherControlAsync();
            // Assert
            Assert.IsNull(extendedTelemetry, "ExtendedTelemetry should be null when the file is not opened.");
            // Verify that the logger was called with the expected message
            _loggerMock?.Verify(
                logger => logger.Log(
                   It.Is<LogLevel>(level => level == LogLevel.Error),
                   It.IsAny<EventId>(),
                   It.Is<It.IsAnyType>((v, t) => _expectedFailMessages.Any(expected => (v.ToString() ?? string.Empty).Contains(expected))),
                   It.IsAny<Exception>(),
                   It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)
                ),
                Times.Once()
             );
        }
    }
}