using System;
using System.Runtime.InteropServices;

namespace CrossTemplate.Mac
{
	// Sample Class for Getting Constants in Mac
	public class Constants
	{
		[Flags]
		private enum RuntimeLoadMode
		{
			Lazy = 1,
			Now = 2,
			Global = 4,
			Local = 8
		}
		[DllImport("libSystem")]
		private static extern IntPtr dlopen(string path, RuntimeLoadMode mode);
		[DllImport("libSystem")]
		private static extern IntPtr dlsym(IntPtr handle, string name);

		private static IntPtr GetSymbol(string framework, string name)
		{
			IntPtr handle;
			handle = dlopen(framework, RuntimeLoadMode.Lazy | RuntimeLoadMode.Global);
			return dlsym(handle, name);
		}
		// Example of getting kCFRunLoopCommonModes from CoreFoundation
		public IntPtr kCFRunLoopCommonModes()
		{
			return Marshal.ReadIntPtr(GetSymbol(MonoMac.Constants.CoreFoundationLibrary, "kCFRunLoopCommonModes"));
		}
	}
}

