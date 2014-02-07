using System;

public class CheckMenuItem : Gtk.CheckMenuItem
{
	public new object UserData {
		get;
		set;
	}

	public string Identifier {
		get;
		set;
	}

	public CheckMenuItem (string label) : base (label)
	{
		UserData = null;
		Identifier = null;
	}

	public CheckMenuItem () : base ()
	{
		UserData = null;
		Identifier = null;
	}

	public CheckMenuItem (IntPtr raw) : base (raw)
	{
		UserData = null;
		Identifier = null;
	}

	[Obsolete]
	protected CheckMenuItem (GLib.GType gtype) : base (gtype)
	{
		UserData = null;
		Identifier = null;
	}

	public static CheckMenuItem AddMenuItem (object Parent, string Title)
	{
		return AddMenuItem (Parent, Title, null, null);
	}

	public static CheckMenuItem AddMenuItem (object Parent, string Title, string Identifier, EventHandler Activated)
	{
		CheckMenuItem menuItem = new CheckMenuItem (Title);
		menuItem.Identifier = Identifier;
		if (Activated != null) {
			menuItem.Activated += Activated;
		}
		MenuItem.AddToParent (Parent, menuItem);
		return menuItem;
	}
}

