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
    internal class LMUMemoryReader : IDisposable
    {

        private readonly IntPtr _tcAddress;
        private readonly IntPtr _tcSlipAddress;
        private readonly IntPtr _tcCutAddress;
        private readonly IntPtr _antiLockBrakesAddress;
        private readonly IntPtr _engineMapAddress;
        private IntPtr _lmuHandle;

        public LMUMemoryReader()
        {
            _tcAddress = new IntPtr(LMUData.Constants.MemoryAddresses.TCAddress);
            _tcSlipAddress = new IntPtr(LMUData.Constants.MemoryAddresses.TcSlipAddress);
            _tcCutAddress = new IntPtr(LMUData.Constants.MemoryAddresses.TcCutAddress);
            _antiLockBrakesAddress = new IntPtr(LMUData.Constants.MemoryAddresses.AntiLockBrakesAddress);
            _engineMapAddress = new IntPtr(LMUData.Constants.MemoryAddresses.EngineMapAddress);
            _lmuHandle = GetLMUHandle();
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size, out IntPtr bytesRead);

        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;

        private static IntPtr GetLMUHandle()
        {
            var process = Process.GetProcessesByName("Le Mans Ultimate")[0];
            return OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, process.Id);
        }

        private static int ReadInt(IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(GetLMUHandle(), address, buffer, buffer.Length, out _);
            return BitConverter.ToInt32(buffer, 0);
        }


        public Electronics GetElectronics()
        {
            if (_lmuHandle == IntPtr.Zero)
            {
                try
                {
                    _lmuHandle = GetLMUHandle();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting LMU handle: {ex.Message}");
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
