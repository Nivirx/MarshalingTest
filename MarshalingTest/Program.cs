using System;
using System.Runtime.InteropServices;

namespace MarshalingTest
{
    /// <summary>
    /// Just a quick PoC of sorts to test mixed _cdecl and _stdcalls from VC++, you may (will) have to change the EntryPoint for the _stdcall functions
    /// this is 100% true if you change the compiler as name mangling is different between MSVC and GCC(or MinGW). this is verified to work with .NET 4.5 and MSVC 12.0
    /// but should work with Mono + GCC as long as the calling convention is changed to _fastcall(?) and the signatures are updated.
    /// also MarshalMe.dll needs to be rewriten for GCC as it does call functions in Windows.h to produce a dll.
    ///
    /// to find the signatures on Windows use dumpbin.exe (check VC bin folder) ex: dumpbin /EXPORT MarshalMe.dll > exports.txt
    ///                        on Linux use objdump -T MarshalMe.so > exports (maybe, again this is not tested)
    /// </summary>
    class Program
    {
    [DllImport("MarshalMe.dll", EntryPoint = "?printS@@YGXPAD@Z", ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
      static extern void printS(IntPtr msgPtr);
    [DllImport("MarshalMe.dll", EntryPoint = "?addC@@YGHHH@Z", ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
      static extern void addC(int a, int b);
    [DllImport("MarshalMe.dll", ExactSpelling = false, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
    static extern void printC(IntPtr msgPtr);

        static void Main(string[] args)
        {
            printS(Marshal.StringToHGlobalAnsi("1. Hello from C#\n"));
            printC(Marshal.StringToHGlobalAnsi("2. Hello from C#\n"));
            addC(3,5);
        }
    }
}
