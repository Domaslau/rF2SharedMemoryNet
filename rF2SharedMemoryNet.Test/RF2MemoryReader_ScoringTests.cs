using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_ScoringTests : GetTest<Scoring>
    {

        [TestMethod]
        public void Test_GetScoring_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var scoring = _reader?.GetScoring();
            // Assert
            Assert.IsNull(scoring, "Scoring should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetScoringAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var scoring = await _reader!.GetScoringAsync();
            // Assert
            Assert.IsNull(scoring, "Scoring should be null when the file is not opened.");
        }


        [TestMethod]
        public void Test_GetScoring_ReturnsScoring_WhenFileAvailable()
        {

            // Arrange
            CreateTestFile(RFactor2Constants.SCORING_FILE_NAME, _testData);
            // Act
            var scoring = _reader?.GetScoring();
            // Assert
            Assert.IsNotNull(scoring, "Scoring should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, scoring.Value.VersionUpdateEnd, "Version number read should match version number stored");

        }

        [TestMethod]
        public async Task Test_GetScoringAsync_ReturnsScoring_WhenFileAvailable()
        {

            // Arrange
            CreateTestFile(RFactor2Constants.SCORING_FILE_NAME, _testData);
            // Act
            var scoring = await _reader!.GetScoringAsync();
            // Assert
            Assert.IsNotNull(scoring, "Scoring should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, scoring.Value.VersionUpdateEnd, "Version number read should match version number stored");

        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetScoringFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetScoring();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetScoringAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetScoringAsync();
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
