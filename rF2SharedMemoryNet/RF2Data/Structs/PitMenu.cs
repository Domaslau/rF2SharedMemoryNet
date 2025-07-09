using System.Runtime.InteropServices;

namespace rF2SharedMemoryNet.RF2Data.Structs
{
    /// <summary>
    /// Represents the current state of the pit menu in rFactor 2, including category and choice information.
    /// </summary>
    /// <remarks>This structure provides details about the currently selected category and choice in the pit
    /// menu,  as well as the total number of available choices. It also includes fields for future expansion.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct PitMenu
    {
        /// <summary>
        /// Represents the index of the current category.
        /// </summary>
        public int CategoryIndex;

        /// <summary>
        /// Represents the name of the current category in untranslated form.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] CategoryName;

        /// <summary>
        /// Represents the index of the current choice within the current category.
        /// </summary>
        public int ChoiceIndex;

        /// <summary>
        /// Represents the name of the current choice, which may include translated words.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] ChoiceString;

        /// <summary>
        /// Represents the total number of choices available.
        /// </summary>
        public int NumChoices;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] Expansion;
    }
}
