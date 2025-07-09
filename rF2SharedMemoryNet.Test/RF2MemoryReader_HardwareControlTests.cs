using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the hardware control-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetHWControl"/> and <see cref="RF2MemoryReader.GetHWControlAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_HardwareControlTests : GetTest<HardwareControl>
    {
        [TestMethod]
        public void Test_GetHWControl_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var hardwareControl = _reader?.GetHWControl();
            // Assert
            Assert.IsNull(hardwareControl, "HardwareControl should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetHWControlAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var hardwareControl = await _reader!.GetHWControlAsync();
            // Assert
            Assert.IsNull(hardwareControl, "HardwareControl should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetHWControl_ReturnsHardwareControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.HWCONTROL_FILE_NAME, _testData);
            // Act
            var hardwareControl = _reader?.GetHWControl();
            // Assert
            Assert.IsNotNull(hardwareControl, "HardwareControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, hardwareControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetHWControlAsync_ReturnsHardwareControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.HWCONTROL_FILE_NAME, _testData);
            // Act
            var hardwareControl = await _reader!.GetHWControlAsync();
            // Assert
            Assert.IsNotNull(hardwareControl, "HardwareControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, hardwareControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetHWControlFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetHWControl();

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
        public void Test_Logger_WritesErrorMessage_WhenGetHWControlAsyncFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetHWControlAsync().Result;
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