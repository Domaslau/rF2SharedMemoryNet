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

        private readonly IntPtr _tcAddress;
        private readonly IntPtr _tcSlipAddress;
        private readonly IntPtr _tcCutAddress;
        private readonly IntPtr _antiLockBrakesAddress;
        private readonly IntPtr _engineMapAddress;
        private Process? _process;
        private IntPtr _lmuHandle;


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

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size, out IntPtr bytesRead);

        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;

        private static IntPtr GetLMUHandle(Process process)
        {
            
            return OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, process.Id);
        }

        private int ReadInt(IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(_lmuHandle, address, buffer, buffer.Length, out _);
            return BitConverter.ToInt32(buffer, 0);
        }


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
