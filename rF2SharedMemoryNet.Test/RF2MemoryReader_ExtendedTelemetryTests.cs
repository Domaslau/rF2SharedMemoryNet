using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the extended telemetry-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetExtended"/> and <see cref="RF2MemoryReader.GetExtendedAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_ExtendedTelemetryTests : GetTest<ExtendedTelemetry>
    {
        [TestMethod]
        public void Test_GetExtended_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var extendedTelemetry = _reader?.GetExtended();
            // Assert
            Assert.IsNull(extendedTelemetry, "ExtendedTelemetry should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetExtendedAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var extendedTelemetry = await _reader!.GetExtendedAsync();
            // Assert
            Assert.IsNull(extendedTelemetry, "ExtendedTelemetry should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetExtended_ReturnsExtendedTelemetry_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.EXTENDED_FILE_NAME, _testData);
            // Act
            var extendedTelemetry = _reader?.GetExtended();
            // Assert
            Assert.IsNotNull(extendedTelemetry, "ExtendedTelemetry should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, extendedTelemetry.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetExtendedAsync_ReturnsExtendedTelemetry_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.EXTENDED_FILE_NAME, _testData);
            // Act
            var extendedTelemetry = await _reader!.GetExtendedAsync();
            // Assert
            Assert.IsNotNull(extendedTelemetry, "ExtendedTelemetry should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, extendedTelemetry.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetExtendedFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetExtended();

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
        public void Test_Logger_WritesErrorMessage_WhenGetExtendedAsyncFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetExtendedAsync().Result;
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