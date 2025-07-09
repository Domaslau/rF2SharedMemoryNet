using Microsoft.Extensions.Logging;
using Moq;
using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.RF2Data.Structs;
using System.Runtime.Versioning;

namespace rF2SharedMemoryNet.Test
{
    /// <summary>
    /// Provides unit tests for the RF2MemoryReader class, specifically testing the plugin control-related methods.
    /// </summary>
    /// <remarks>
    /// Tests for: <see cref="RF2MemoryReader.GetPluginControl"/> and <see cref="RF2MemoryReader.GetPluginControlAsync"/>.
    /// </remarks> 
    [SupportedOSPlatform("windows")]
    [TestClass]
    public class RF2MemoryReader_PluginControlTests : GetTest<PluginControl>
    {
        [TestMethod]
        public void Test_GetPluginControl_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var pluginControl = _reader?.GetPluginControl();
            // Assert
            Assert.IsNull(pluginControl, "PluginControl should be null when the file is not opened.");
        }

        [TestMethod]
        public async Task Test_GetPluginControlAsync_ReturnsNull_WhenFileNotOpened()
        {
            // Act
            var pluginControl = await _reader!.GetPluginControlAsync();
            // Assert
            Assert.IsNull(pluginControl, "PluginControl should be null when the file is not opened.");
        }

        [TestMethod]
        public void Test_GetPluginControl_ReturnsPluginControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.PLUGIN_CONTROL_FILE_NAME, _testData);
            // Act
            var pluginControl = _reader?.GetPluginControl();
            // Assert
            Assert.IsNotNull(pluginControl, "PluginControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, pluginControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }

        [TestMethod]
        public async Task Test_GetPluginControlAsync_ReturnsPluginControl_WhenFileAvailable()
        {
            // Arrange
            CreateTestFile(RFactor2Constants.PLUGIN_CONTROL_FILE_NAME, _testData);
            // Act
            var pluginControl = await _reader!.GetPluginControlAsync();
            // Assert
            Assert.IsNotNull(pluginControl, "PluginControl should not be null when the file is available.");
            Assert.AreEqual(_testData.VersionUpdateEnd, pluginControl.Value.VersionUpdateEnd, "Version number read should match version number stored.");
        }
    

    
        [TestMethod]
        public void Test_Logger_WritesErrorMessage_WhenGetPluginControlFails()
        {
            // Act
            var extendedTelemetry = _reader?.GetPluginControl();

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
        public async Task Test_Logger_WritesErrorMessage_WhenGetPluginControlAsyncFails()
        {
            // Act
            var extendedTelemetry = await _reader!.GetPluginControlAsync();
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