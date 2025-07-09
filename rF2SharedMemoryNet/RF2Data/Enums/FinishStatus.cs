namespace rF2SharedMemoryNet.RF2Data.Enums
{
    /// <summary>
    /// Represents the finish status of a participant in an RF2 event.
    /// </summary>
    /// <remarks>This enumeration is used to indicate the outcome of a participant's performance in an RF2
    /// event. Possible values include: <list type="bullet"> <item><term><see cref="None"/></term><description>No finish
    /// status is assigned.</description></item> <item><term><see cref="Finished"/></term><description>The participant
    /// successfully completed the event.</description></item> <item><term><see cref="Dnf"/></term><description>The
    /// participant did not finish the event.</description></item> <item><term><see cref="Dq"/></term><description>The
    /// participant was disqualified from the event.</description></item> </list></remarks>
    public enum FinishStatus
    {
        /// <summary>
        /// Not finished yet.
        /// </summary>
        None,
        /// <summary>
        /// Finished the event.
        /// </summary>
        Finished,
        /// <summary>
        /// Did not finish the event. (DNF)
        /// </summary>
        Dnf,
        /// <summary>
        /// Disqualified from the event. (DQ)
        /// </summary>
        Dq
    }
}