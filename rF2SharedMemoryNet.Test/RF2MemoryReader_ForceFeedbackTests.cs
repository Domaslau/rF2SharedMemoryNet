using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the force feedback-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetForceFeedback"/> and <see cref="RF2MemoryReader.GetForceFeedbackAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_ForceFeedbackTests : GetTest<ForceFeedback>
    {
        [TestMethod]
        public void Test_GetForceFeedback_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var forceFeedback = _reader?.GetForceFeedback();
            // Assert
            Assert.IsNull(forceFeedback, "ForceFeedback should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetForceFeedbackAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var forceFeedback = await _reader!.GetForceFeedbackAsync();
            // Assert
            Assert.IsNull(forceFeedback, "ForceFeedback should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetForceFeedback_ReturnsForceFeedback_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.FORCE_FEEDBACK_FILE_NAME, _testData);
            // Act
            var forceFeedback = _reader?.GetForceFeedback();
            // Assert
            Assert.IsNotNull(forceFeedback, "ForceFeedback should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, forceFeedback.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetForceFeedbackAsync_ReturnsForceFeedback_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.FORCE_FEEDBACK_FILE_NAME, _testData);
            // Act
            var forceFeedback = await _reader!.GetForceFeedbackAsync();
            // Assert
            Assert.IsNotNull(forceFeedback, "ForceFeedback should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, forceFeedback.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetForceFeedbackFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetForceFeedback();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetForceFeedbackAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetForceFeedbackAsync();
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