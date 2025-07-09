using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the graphics-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetGraphics"/> and <see cref="RF2MemoryReader.GetGraphicsAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_GraphicsTests : GetTest<Graphics>
    {
        [TestMethod]
        public void Test_GetGraphics_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var graphics = _reader?.GetGraphics();
            // Assert
            Assert.IsNull(graphics, "Graphics should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetGraphicsAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var graphics = await _reader!.GetGraphicsAsync();
            // Assert
            Assert.IsNull(graphics, "Graphics should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetGraphics_ReturnsGraphics_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.GRAPHICS_FILE_NAME, _testData);
            // Act
            var graphics = _reader?.GetGraphics();
            // Assert
            Assert.IsNotNull(graphics, "Graphics should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, graphics.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetGraphicsAsync_ReturnsGraphics_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.GRAPHICS_FILE_NAME, _testData);
            // Act
            var graphics = await _reader!.GetGraphicsAsync();
            // Assert
            Assert.IsNotNull(graphics, "Graphics should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, graphics.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetGraphicsFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetGraphics();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetGraphicsAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetGraphicsAsync();
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