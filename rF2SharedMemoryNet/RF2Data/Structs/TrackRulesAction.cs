using rF2SharedMemoryNet.RF2Data.Enums;
using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents an action related to track rules in rFactor 2, including a recommended command,  slot ID, and elapsed
    /// time of the event.
    /// </summary>
    /// <remarks>This structure is typically used to communicate track rule actions within the simulation. 
    /// The values are intended for input purposes only and provide details about the recommended  action, the
    /// associated slot ID (if applicable), and the elapsed time of the event.</remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct TrackRulesAction
    {
        /// <summary>
        /// Represents the recommended action for RF2 track rules.
        /// </summary>
        public TrackRulesCommand Command;

        /// <summary>
        /// Represents the slot ID, if applicable.
        /// </summary>
        public int Id;

        /// <summary>
        /// Represents the elapsed time at which an event occurred, if applicable.
        /// </summary>
        public double ElapsedTime;
    }
}
