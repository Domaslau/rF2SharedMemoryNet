namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Specifies the mode of operation for a game instance.
    /// </summary>
    /// <remarks>This enumeration defines whether the game instance operates as a server, a client, or both.
    /// Use this to configure the behavior of the game based on its role in the network.</remarks>
    public enum GameMode
    {
        /// <summary>
        /// Represents a server role in RF2
        /// </summary>
        Server = 1,

        /// <summary>
        /// Represents the client role in RF2
        /// </summary>
        Client = 2,

        /// <summary>
        /// Specifies that the connection operates in both server and client modes.
        /// </summary>
        ServerAndClient = 3,
    }
}
