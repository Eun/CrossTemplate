using System;
using Gtk;
using System.IO;
using System.Reflection;

namespace CrossTemplate
{
	class MainClass
	{
		public static Platforms platform;
		public static void Main (string[] args)
		{
			Application.Init ();
			platform = Platform.Get ();

			// Initiate NSApplication for the Native Messagebox on Mac
			// Normaly you wouldn't need this
			if (platform == Platforms.Mac)
			{
				MonoMac.AppKit.NSApplication.Init();
			}
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run();
		}	
	}
}
