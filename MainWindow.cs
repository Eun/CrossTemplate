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


		BuildMenu ();
	}



	//RadioMenuItem
	//CheckMenuItem
	//SeperatorMenuItem
	//ImageMenuItem




	private void BuildMenu()
	{
		MenuItem appmenu = MenuItem.AddMenuItem (menubar1, "CrossTemplate", null, null);

		MenuItem.AddMenuItem (appmenu, "Hello World", "Hello World", HandleMenuItemActivated);

		MenuItem submenu = MenuItem.AddMenuItem (appmenu, "Submenu", null, null);
		MenuItem.AddMenuItem (submenu, "Item 1", "appmenu.Item.1", HandleMenuItemActivated);
		MenuItem.AddMenuItem (submenu, "Item 2", "appmenu.Item.2", HandleMenuItemActivated);

		CheckMenuItem.AddMenuItem(appmenu, "Checkbox", "appmenu.Checkbox", HandleMenuItemActivated);


		MenuItem submenus = MenuItem.AddMenuItem (menubar1, "SubMenus", null, null);
		MenuItem simple_submenu = MenuItem.AddMenuItem (submenus, "Simple Submenu", null, null);
		MenuItem.AddMenuItem (simple_submenu, "Item 1", "Submenus.Simple.1", HandleMenuItemActivated);
		MenuItem.AddMenuItem (simple_submenu, "Item 2", "Submenus.Simple.1", HandleMenuItemActivated);

		MenuItem.AddMenuItem (submenus, "Normal Item", "Submenus.Normal Item", HandleMenuItemActivated);
		MenuItem more_submenus = MenuItem.AddMenuItem (submenus, "More Submenus", null, null);
		MenuItem more_submenus_1 = MenuItem.AddMenuItem (more_submenus, "Submenu 1", null, null);
		MenuItem more_submenus_2 = MenuItem.AddMenuItem (more_submenus, "Submenu 2", null, null);
		MenuItem.AddMenuItem (more_submenus_1, "Item 1", "SubMenus.More.1.1", HandleMenuItemActivated);
		MenuItem.AddMenuItem (more_submenus_1, "Item 2", "SubMenus.More.1.2", HandleMenuItemActivated);
		MenuItem.AddMenuItem (more_submenus_2, "Item 1", "SubMenus.More.2.1", HandleMenuItemActivated);
		MenuItem.AddMenuItem (more_submenus_2, "Item 2", "SubMenus.More.2.2", HandleMenuItemActivated);


		MenuItem checkboxes = MenuItem.AddMenuItem (menubar1, "CheckBoxes", null, null);
		CheckMenuItem.AddMenuItem(checkboxes, "Checkbox 1", "Checkbox 1", HandleMenuItemActivated);
		CheckMenuItem.AddMenuItem(checkboxes, "Checkbox 2", "Checkbox 2", HandleMenuItemActivated);

		MenuItem radiobutton = MenuItem.AddMenuItem (menubar1, "RadioButtons", null, null);
		RadioMenuItem radio1 = RadioMenuItem.AddMenuItem (radiobutton, "Radio 1", null, "Radio 1", HandleMenuItemActivated);
		RadioMenuItem.AddMenuItem (radiobutton, "Radio 2", radio1, "Radio 2", HandleMenuItemActivated);



		menubar1.ShowAll();

		if (MainClass.platform == Platforms.Mac) {
			IgeMacIntegration.IgeMacMenuGroup appGroup = IgeMacIntegration.IgeMacMenu.AddAppMenuGroup ();
			Menu Submenu = (Menu)((MenuItem)menubar1.Children [0]).Submenu;

			if (Submenu != null) {
				foreach (Gtk.MenuItem menuItemApp in Submenu.Children) {
					string label = "";
					if (menuItemApp is MenuItem)
						label = ((Label)((MenuItem)menuItemApp).Child).Text;
					else if (menuItemApp is CheckMenuItem)
						label = ((Label)((CheckMenuItem)menuItemApp).Child).Text;
					else if (menuItemApp is RadioMenuItem)
						label = ((Label)((RadioMenuItem)menuItemApp).Child).Text;
					else if (menuItemApp is ImageMenuItem)
						label = ((Label)((ImageMenuItem)menuItemApp).Child).Text;
					appGroup.AddMenuItem (menuItemApp, label);
				}
			}
			menubar1.Remove (menubar1.Children [0]);

			IgeMacIntegration.IgeMacMenu.MenuBar = this.menubar1;
			menubar1.Hide ();
		}


	}

	void HandleMenuItemActivated (object sender, EventArgs e)
	{
		if (sender is MenuItem) {
			MenuItem item = (MenuItem)sender;
			Console.WriteLine ("Menu: " + ((item.Identifier == null) ? "NULL" : item.Identifier));
		}

		if (sender is RadioMenuItem) {
			RadioMenuItem item = (RadioMenuItem)sender;
			Console.WriteLine ("Menu: " + ((item.Identifier == null) ? "NULL" : item.Identifier) + ": " + item.Active);
		}

		if (sender is CheckMenuItem) {
			CheckMenuItem item = (CheckMenuItem)sender;
			Console.WriteLine ("Menu: " + ((item.Identifier == null) ? "NULL" : item.Identifier) + ": " + item.Active);
		}
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
