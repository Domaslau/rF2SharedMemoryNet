using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the weather-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetWeather"/> and <see cref="RF2MemoryReader.GetWeatherAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_WeatherTests : GetTest<Weather>
    {
        [TestMethod]
        public void Test_GetWeather_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var weather = _reader?.GetWeather();
            // Assert
            Assert.IsNull(weather, "Weather should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetWeatherAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var weather = await _reader!.GetWeatherAsync();
            // Assert
            Assert.IsNull(weather, "Weather should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetWeather_ReturnsWeather_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.WEATHER_FILE_NAME, _testData);
            // Act
            var weather = _reader?.GetWeather();
            // Assert
            Assert.IsNotNull(weather, "Weather should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, weather.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetWeatherAsync_ReturnsWeather_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.WEATHER_FILE_NAME, _testData);
            // Act
            var weather = await _reader!.GetWeatherAsync();
            // Assert
            Assert.IsNotNull(weather, "Weather should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, weather.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetWeatherFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetWeather();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetWeatherAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetWeatherAsync();
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