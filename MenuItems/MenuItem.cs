using System;

public class MenuItem : Gtk.MenuItem
{
	public new object UserData {
		get;
		set;
	}
	public new string Identifier {
		get;
		set;
	}
	
	[Obsolete]
	protected MenuItem (GLib.GType gtype) : base (gtype)
	{
		UserData = null;
		Identifier = null;
	}

	public MenuItem (IntPtr raw) : base (raw)
	{
		UserData = null;
		Identifier = null;
	}

	public MenuItem (string label) : base (label)
	{
		UserData = null;
		Identifier = null;
	}

	public MenuItem () : base ()
	{
		UserData = null;
		Identifier = null;
	}

	public static MenuItem AddMenuItem(object Parent, string Title)
	{
		return AddMenuItem (Parent, Title, null, null);
	}



	public static MenuItem AddMenuItem(object Parent, string Title, string Identifier, EventHandler Activated)
	{
		MenuItem menuItem = new MenuItem (Title);
		menuItem.Identifier = Identifier;
		if (Activated != null) {
			menuItem.Activated += Activated;
		}
		AddToParent (Parent, menuItem);
		return menuItem;
	}

	public static void AddToParent (object Parent, Gtk.Widget menuItem)
	{
		if (Parent is MenuItem) {
			if (((Gtk.Menu)((MenuItem)Parent).Submenu) == null)
				((MenuItem)Parent).Submenu = new Gtk.Menu ();
			((Gtk.Menu)((MenuItem)Parent).Submenu).Append (menuItem);
		}
		else if (Parent is Gtk.MenuBar) {
			((Gtk.MenuBar)Parent).Append (menuItem);
		}
	}


}