using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the rules-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetRules"/> and <see cref="RF2MemoryReader.GetRulesAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_RulesTests : GetTest<Rules>
    {
        [TestMethod]
        public void Test_GetRules_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var rules = _reader?.GetRules();
            // Assert
            Assert.IsNull(rules, "Rules should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetRulesAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var rules = await _reader!.GetRulesAsync();
            // Assert
            Assert.IsNull(rules, "Rules should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetRules_ReturnsRules_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.RULES_FILE_NAME, _testData);
            // Act
            var rules = _reader?.GetRules();
            // Assert
            Assert.IsNotNull(rules, "Rules should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, rules.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetRulesAsync_ReturnsRules_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.RULES_FILE_NAME, _testData);
            // Act
            var rules = await _reader!.GetRulesAsync();
            // Assert
            Assert.IsNotNull(rules, "Rules should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, rules.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetRulesFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetRules();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetRulesAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetRulesAsync();
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
