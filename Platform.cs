using System;
using System.IO;

namespace CrossTemplate
{
	public enum Platforms
	{
		Windows,
		Linux,
		Mac
	}
	public class Platform
	{
		public static Platforms Get()
		{
			switch (Environment.OSVersion.Platform)
			{
			case PlatformID.Unix:
				// Well, there are chances MacOSX is reported as Unix instead of MacOSX.
				// Instead of platform check, we'll do a feature checks (Mac specific root folders)
				if (Directory.Exists("/Applications")
				    & Directory.Exists("/System")
				    & Directory.Exists("/Users")
				    & Directory.Exists("/Volumes"))
					return Platforms.Mac;
				else
					return Platforms.Linux;
				
			case PlatformID.MacOSX:
				return Platforms.Mac;
				
			default:
				return Platforms.Windows;
			}
		}
	}
}

