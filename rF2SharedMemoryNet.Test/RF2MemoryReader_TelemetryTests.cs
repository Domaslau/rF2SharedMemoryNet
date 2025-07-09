using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the telemetry-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetTelemetry"/> and <see cref="RF2MemoryReader.GetTelemetryAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_TelemetryTests : GetTest<Telemetry>
    {
        [TestMethod]
        public void Test_GetTelemetry_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var telemetry = _reader?.GetTelemetry();
            // Assert
            Assert.IsNull(telemetry, "Telemetry should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetTelemetryAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var telemetry = await _reader!.GetTelemetryAsync();
            // Assert
            Assert.IsNull(telemetry, "Telemetry should be null when the file is not opened.");
        }


        [TestMethod]
        public void Test_GetTelemetry_ReturnsTelemetry_WhenFileAvailable()
        {

            // Arrange
            CreateTestFile(RFactor2Constants.TELEMETRY_FILE_NAME, _testData);
            // Act
            var telemetry = _reader?.GetTelemetry();
            // Assert
            Assert.IsNotNull(telemetry, "Telemetry should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, telemetry.Value.VersionUpdateEnd, "Version number read should match version number stored");

        }

        [TestMethod]
        public async Task Test_GetTelemetryAsync_ReturnsTelemetry_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.TELEMETRY_FILE_NAME, _testData);
            // Act
            var telemetry = await _reader!.GetTelemetryAsync();
            // Assert
            Assert.IsNotNull(telemetry, "Telemetry should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, telemetry.Value.VersionUpdateEnd, "Version number read should match version number stored");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetTelemetryFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetTelemetry();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetTelemetryAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetTelemetryAsync();
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
