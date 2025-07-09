using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{

    /// <summary>
    /// Represents damage tracking data for a racing session, including maximum and accumulated impact magnitudes.
    /// </summary>
    /// <remarks>This structure is used to track the magnitude of impacts during a racing session. The values
    /// are updated  on every telemetry update and reset when the vehicle visits the pits or the session is
    /// restarted.</remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct TrackedDamage
    {
        /// <summary>
        /// Represents the maximum impact magnitude recorded during telemetry updates.
        /// </summary>
        /// <remarks>The value is updated on every telemetry update and reset when visiting the pits or
        /// restarting the session.</remarks>
        public double MaxImpactMagnitude;

        /// <summary>
        /// Represents the accumulated impact magnitude tracked during telemetry updates.
        /// </summary>
        /// <remarks>The value is updated continuously during telemetry updates and reset when visiting
        /// the pits or restarting the session.</remarks>
        public double AccumulatedImpactMagnitude;
    };
}
