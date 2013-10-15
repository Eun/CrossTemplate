using System;
using System.Runtime.InteropServices;

namespace CrossTemplate.Win32
{
	// Sample Class for Calling Native Functions in Windows
	public class user32
	{
		[DllImport("user32.dll")]
		public static extern int MessageBox(IntPtr h, string m, string c, int type);
	}
}
