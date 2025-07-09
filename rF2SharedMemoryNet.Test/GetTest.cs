using rF2SharedMemoryNet.RF2Data.Constants;
using rF2SharedMemoryNet.Test.Utilities;
using System.IO.MemoryMappedFiles;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Moq;

namespace rF2SharedMemoryNet.Test
{
    [SupportedOSPlatform("windows")]
    public abstract class GetTest<T> where T : struct
    {
        /// <summary>
        /// Simple semaphore to control access to the telemetry file during tests.
        /// </summary>
        protected static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// R2MemoryReader instance used for testing telemetry methods.
        /// </summary>
        protected RF2MemoryReader? _reader;

        /// <summary>
        /// Reference to the MemoryMappedFile used for testing telemetry data.
        /// </summary>
        protected MemoryMappedFile? _memoryMappedFile;

        /// <summary>
        /// Simple test data
        /// </summary>
        protected T _testData = new();

        protected Mock<ILogger>? _loggerMock;

        protected string[] _expectedFailMessages = [$"Failed opening: {typeof(T).Name} file",$"Failed reading: {typeof(T).Name} file"];

        /// <summary>
        /// Sets up the test environment.
        /// </summary>
        [TestInitialize]
        public virtual void Setup()
        {
            semaphore.Wait();

            _loggerMock = new();

            _reader = new RF2MemoryReader(_loggerMock.Object);
           
        }

        /// <summary>
        /// Cleans up the test environment.
        /// </summary>
        [TestCleanup]
        public virtual void Cleanup()
        {
            if (_memoryMappedFile != null)
            {
                TestFileFactory.DeleteTestFile(RFactor2Constants.TELEMETRY_FILE_NAME, _memoryMappedFile);
                _memoryMappedFile = null;
            }
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }
            semaphore.Release();
        }

        /// <summary>
        /// Creates a test file with the specified name and data.
        /// </summary>
        /// <remarks>This method initializes a memory-mapped file using the provided file name and data.
        /// It is intended to be overridden in derived classes to customize the file creation process.</remarks>
        /// <param name="fileName">The name of the file to be created. Cannot be null or empty.</param>
        /// <param name="data">The data to be written to the test file.</param>
        protected virtual void CreateTestFile(string fileName, T data)
        {
            _memoryMappedFile = TestFileFactory.CreateTestFile(fileName, data);
        }
    }
}
