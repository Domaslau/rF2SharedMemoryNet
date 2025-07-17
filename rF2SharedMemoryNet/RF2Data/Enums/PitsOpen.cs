using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// PitsOpen status
    /// </summary>
    public enum PitsOpen
    {
        /// <summary>
        /// Set pits to close
        /// </summary>
        SetClose = 0,

        /// <summary>
        /// Set pits to open
        /// </summary>
        SetOpen = 1,


        /// <summary>
        /// Closed pits, cannot enter.
        /// </summary>
        Closed = 2,

        /// <summary>
        /// Open pits, can enter.
        /// </summary>
        Open = 3,
    }
}
