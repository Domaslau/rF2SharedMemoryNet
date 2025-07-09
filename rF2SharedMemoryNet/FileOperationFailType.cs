namespace rF2SharedMemoryNet
{

    /// <summary>
    /// Specifies the types of failures that can occur during file operations.
    /// </summary>
    /// <remarks>This enumeration is used to categorize the different stages at which a file operation might
    /// fail, such as opening, reading, or parsing a file. It helps in identifying the specific operation that
    /// encountered an error, allowing for more precise error handling and logging.</remarks>
    public enum FileOperationFailType
    {
        /// <summary>
        /// Failure occurred while opening the file.
        /// </summary>
        Open,

        /// <summary>
        /// Failure occurred while reading the file.
        /// </summary>
        Read,

        /// <summary>
        /// Failure occurred while parsing the file.
        /// </summary>
        Parse
    }
}
