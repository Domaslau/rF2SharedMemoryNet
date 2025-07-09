using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the pit information-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetPitInfo"/> and <see cref="RF2MemoryReader.GetPitInfoAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_PitInfoTests : GetTest<PitInfo>
    {
        [TestMethod]
        public void Test_GetPitInfo_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var pitInfo = _reader?.GetPitInfo();
            // Assert
            Assert.IsNull(pitInfo, "PitInfo should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetPitInfoAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var pitInfo = await _reader!.GetPitInfoAsync();
            // Assert
            Assert.IsNull(pitInfo, "PitInfo should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetPitInfo_ReturnsPitInfo_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.PITINFO_FILE_NAME, _testData);
            // Act
            var pitInfo = _reader?.GetPitInfo();
            // Assert
            Assert.IsNotNull(pitInfo, "PitInfo should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, pitInfo.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetPitInfoAsync_ReturnsPitInfo_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.PITINFO_FILE_NAME, _testData);
            // Act
            var pitInfo = await _reader!.GetPitInfoAsync();
            // Assert
            Assert.IsNotNull(pitInfo, "PitInfo should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, pitInfo.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetPitInfoFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetPitInfo();

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
        public void Test_Logger_WritesErrorMessage_WhenGetPitInfoAsyncFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetPitInfoAsync().Result;
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