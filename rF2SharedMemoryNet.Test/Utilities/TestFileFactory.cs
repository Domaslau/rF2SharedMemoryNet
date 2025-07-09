using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;


namespace rF2SharedMemoryNet.Test.Utilities
{
    [SupportedOSPlatform("windows")]
    internal static class TestFileFactory
    {

        /// <summary>
        /// Creates or opens a memory-mapped file and writes the specified data structure to it.
        /// </summary>
        /// <remarks>The method creates or opens a memory-mapped file with read-write access and writes
        /// the provided data structure to it. The size of the memory-mapped file is determined by the size of the data
        /// structure.</remarks>
        /// <typeparam name="T">The type of the data structure to write to the memory-mapped file. Must be a value type.</typeparam>
        /// <param name="fileName">The name of the memory-mapped file to create or open.</param>
        /// <param name="data">The data structure to write to the memory-mapped file.</param>
        /// <returns>A <see cref="MemoryMappedFile"/> object representing the created or opened memory-mapped file.</returns>
        internal static MemoryMappedFile CreateTestFile<T>(string fileName, T data) where T : struct
        {
            var memoryMappedFile = MemoryMappedFile.CreateOrOpen(fileName, Marshal.SizeOf<T>(), MemoryMappedFileAccess.ReadWrite);
            var size = Marshal.SizeOf<T>();
            var bytes = new byte[size];

            var intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(data, intPtr, false);
            Marshal.Copy(intPtr, bytes, 0, size);

            using (var stream = memoryMappedFile.CreateViewStream())
            {
                stream.Write(bytes, 0, size);
            }
            return memoryMappedFile;
        }

        /// <summary>
        /// Deletes the specified test file and releases the associated memory-mapped file resources.
        /// </summary>
        /// <remarks>This method first disposes of the provided memory-mapped file to ensure that all
        /// resources are released. It then checks for the existence of the specified file and deletes it if it
        /// exists.</remarks>
        /// <param name="fileName">The name of the file to be deleted. Must not be null or empty.</param>
        /// <param name="memoryMappedFile">The memory-mapped file associated with the test file. This resource will be disposed.</param>
        internal static void DeleteTestFile(string fileName, MemoryMappedFile memoryMappedFile)
        {
            memoryMappedFile.Dispose();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
