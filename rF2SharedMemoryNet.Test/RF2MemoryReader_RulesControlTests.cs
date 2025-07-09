using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the rules control-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetRulesControl"/> and <see cref="RF2MemoryReader.GetRulesControlAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_RulesControlTests : GetTest<RulesControl>
    {
        [TestMethod]
        public void Test_GetRulesControl_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var rulesControl = _reader?.GetRulesControl();
            // Assert
            Assert.IsNull(rulesControl, "RulesControl should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetRulesControlAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var rulesControl = await _reader!.GetRulesControlAsync();
            // Assert
            Assert.IsNull(rulesControl, "RulesControl should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetRulesControl_ReturnsRulesControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.RULES_CONTROL_FILE_NAME, _testData);
            // Act
            var rulesControl = _reader?.GetRulesControl();
            // Assert
            Assert.IsNotNull(rulesControl, "RulesControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, rulesControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetRulesControlAsync_ReturnsRulesControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.RULES_CONTROL_FILE_NAME, _testData);
            // Act
            var rulesControl = await _reader!.GetRulesControlAsync();
            // Assert
            Assert.IsNotNull(rulesControl, "RulesControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, rulesControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetRulesControlFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetRulesControl();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetRulesControlAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetRulesControlAsync();
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