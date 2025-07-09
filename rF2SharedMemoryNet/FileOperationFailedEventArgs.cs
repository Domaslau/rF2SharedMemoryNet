namespace rF2SharedMemoryNet
{
    /// <summary>
    /// Provides data for the event that is raised when a file read operation fails.
    /// </summary>
    public class FileOperationFailedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the name of the data type associated with the file that failed to be read.
        /// </summary>
        public string DataTypeName { get; }

        /// <summary>
        /// Gets the error message associated with the current operation or state.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the type of failure that occurred during a file operation.
        /// </summary>
        public FileOperationFailType FailType { get; }

        /// <summary>
        /// Provides data for the event that is raised when a file read operation fails.
        /// </summary>
        /// <param name="dataTypeName">The name of the data type associated with the file read operation.</param>
        /// <param name="errorMessage">A message describing the error that occurred during the file read operation.</param>
        /// <param name="failType">The type of failure that occurred during the file operation.</param>
        public FileOperationFailedEventArgs(string dataTypeName, string errorMessage, FileOperationFailType failType)
        {
            DataTypeName = dataTypeName;
            ErrorMessage = errorMessage;
            FailType = failType;
        }
    }
}
