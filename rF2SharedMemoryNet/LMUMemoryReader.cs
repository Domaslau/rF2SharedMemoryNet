using rF2SharedMemoryNet.LMUData.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace rF2SharedMemoryNet
{
    /// <summary>
    /// Game should be running before creating this instance.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    internal class LMUMemoryReader : IDisposable
    {
        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;
        private readonly IntPtr _tcAddress;
        private readonly IntPtr _tcSlipAddress;
        private readonly IntPtr _tcCutAddress;
        private readonly IntPtr _antiLockBrakesAddress;
        private readonly IntPtr _engineMapAddress;
        private Process? _process;
        private IntPtr _lmuHandle;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size, out IntPtr bytesRead);


        /// <summary>
        /// Initializes a new instance of the <see cref="LMUMemoryReader"/> class.
        /// </summary>
        /// <remarks>This constructor attempts to locate and attach to the "Le Mans Ultimate" process. It
        /// retrieves the necessary memory addresses for reading specific game data. If the process is not found or the
        /// base address cannot be retrieved, an exception is thrown.</remarks>
        /// <exception cref="InvalidOperationException">Thrown if the "Le Mans Ultimate" process is not running or if the base address of the process cannot be
        /// retrieved.</exception>
        public LMUMemoryReader()
        {
            _process = Process.GetProcessesByName("Le Mans Ultimate")[0];
            if(_process == null)
            {
                Dispose();
                throw new InvalidOperationException("Le Mans Ultimate process not found. Ensure the game is running.");
            }
            _lmuHandle = GetLMUHandle(_process);
            IntPtr baseAddress = _process.MainModule?.BaseAddress ?? IntPtr.Zero;
            if(baseAddress == IntPtr.Zero)
            {
                Dispose();
                throw new InvalidOperationException("Could not retrieve base address of the LMU process.");
              
            }
            _tcAddress = IntPtr.Add(baseAddress, LMUData.Constants.MemoryAddressOffsets.TcOffset);
            _tcSlipAddress = IntPtr.Add(baseAddress, LMUData.Constants.MemoryAddressOffsets.TcSlipOffset);
            _tcCutAddress = IntPtr.Add(baseAddress, LMUData.Constants.MemoryAddressOffsets.TcCutOffset);
            _antiLockBrakesAddress = IntPtr.Add(baseAddress, LMUData.Constants.MemoryAddressOffsets.AntiLockBrakesOffset);
            _engineMapAddress = IntPtr.Add(baseAddress, LMUData.Constants.MemoryAddressOffsets.EngineMapOffset);
            
        }

        /// <summary>
        /// Retrieves a handle to the specified process with permissions for reading memory and querying information.
        /// </summary>
        /// <remarks>Use <see cref="Dispose"/> when done to clean up.</remarks>
        /// <param name="process">The process for which to obtain the handle. Must not be null.</param>
        /// <returns>An <see cref="IntPtr"/> representing the handle to the process.  The handle can be used to read the
        /// process's memory and query its information.</returns>
        private static IntPtr GetLMUHandle(Process process)
        {
            
            return OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, process.Id);
        }

        /// <summary>
        /// Reads a 32-bit integer from the specified memory address.
        /// </summary>
        /// <param name="address">The memory address from which to read the integer.</param>
        /// <returns>The 32-bit integer value read from the specified address.</returns>
        private int ReadInt(IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(_lmuHandle, address, buffer, buffer.Length, out _);
            return BitConverter.ToInt32(buffer, 0);
        }


        /// <summary>
        /// Retrieves the current electronics settings from the LMU process.
        /// </summary>
        /// <remarks>This method attempts to access the LMU process to read various electronics settings
        /// such as traction control and anti-lock brakes. If the LMU process is not accessible, an exception is
        /// thrown.</remarks>
        /// <returns>An <see cref="Electronics"/> object containing the current settings for traction control, traction control
        /// slip, traction control cut, anti-lock brakes, and engine map.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the LMU process cannot be accessed. Ensure the game is running before calling this method.</exception>
        public Electronics GetElectronics()
        {
            if (_lmuHandle == IntPtr.Zero)
            {
                try
                {
                    if(_process == null) { return new(); }
                    _lmuHandle = GetLMUHandle(_process);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting LMU handle: {ex.Message}");
                    Dispose();
                    throw new InvalidOperationException("Could not access LMU process. Ensure the game is running.", ex);
                }

            }
            return new Electronics
            {
                TractionControl = ReadInt(_tcAddress),
                TractionControlSlip = ReadInt(_tcSlipAddress),
                TractionControlCut = ReadInt(_tcCutAddress),
                AntiLockBrakes = ReadInt(_antiLockBrakesAddress),
                EngineMap = ReadInt(_engineMapAddress)
            };
        }

        /// <summary>
        /// Releases all resources used by the current instance of the class.
        /// </summary>
        /// <remarks>This method should be called when the instance is no longer needed to free unmanaged
        /// resources. After calling this method, the instance should not be used.</remarks>
        public void Dispose()
        {
            if (_lmuHandle != IntPtr.Zero)
            {
                Marshal.Release(_lmuHandle);
                _lmuHandle = IntPtr.Zero;
            }
            if (_tcAddress != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_tcAddress);
            }
            if (_tcSlipAddress != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_tcSlipAddress);
            }
            if (_tcCutAddress != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_tcCutAddress);
            }
            if (_antiLockBrakesAddress != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_antiLockBrakesAddress);
            }
            if (_engineMapAddress != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_engineMapAddress);
            }
        }


    }
}
