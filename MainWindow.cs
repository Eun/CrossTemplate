using System;
using Gtk;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using MonoMac;
using System.Collections.Generic;
using CrossTemplate;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		label1.Text = "You are on " + MainClass.platform.ToString() + ".";

		// Events
		// I suggest to put the events here, because gtk designer is buggy sometimes
		this.Destroyed += OnDestroyed;
		button1.Clicked += OnButtonClicked;
		button2.Clicked += OnButtonClicked;

	}
	protected void OnDestroyed (object sender, EventArgs e)
	{
		Environment.Exit (0);
	}

	protected void OnButtonClicked (object sender, EventArgs e)
	{
		if (sender == button1)
		{
			// native system calls messagebox demo
			// note: this is just a demo, you should always use GTK if you can!
			if (MainClass.platform == Platforms.Mac)
			{
				MonoMac.AppKit.NSAlert alert = new MonoMac.AppKit.NSAlert ();
				alert.MessageText = "Hello";
				alert.AlertStyle = MonoMac.AppKit.NSAlertStyle.Informational;
				alert.AddButton ("Ok");
				alert.RunModal ();
			}
			else if (MainClass.platform == Platforms.Windows)
			{
				CrossTemplate.Win32.user32.MessageBox (IntPtr.Zero, "Hello", "Caption", 0x40 /* MB_ICONINFORMATION */);
			}
			else
			{
				throw new NotImplementedException ();
			}
		}
		else if (sender == button2)
		{
			// Gtk
			Gtk.MessageDialog alert = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Hello");
			alert.Title = "Caption";
			ResponseType result = (ResponseType)alert.Run ();
			if (result == ResponseType.Ok)
			{
				alert.Destroy ();
			}
		}

	}
}
