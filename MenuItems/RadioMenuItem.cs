using System;

public class RadioMenuItem : Gtk.RadioMenuItem
{
	public new object UserData {
		get;
		set;
	}

	public string Identifier {
		get;
		set;
	}

	public RadioMenuItem (string label) : base (label)
	{
		UserData = null;
		Identifier = null;
	}

	public RadioMenuItem (IntPtr raw) : base (raw)
	{
		UserData = null;
		Identifier = null;
	}

	[Obsolete]
	protected RadioMenuItem (GLib.GType gtype) : base (gtype)
	{
		UserData = null;
		Identifier = null;
	}

	public static RadioMenuItem AddMenuItem (object Parent, string Title)
	{
		return AddMenuItem (Parent, Title, null, null, null);
	}

	public static RadioMenuItem AddMenuItem (object Parent, string Title, RadioMenuItem RadioGroup)
	{
		return AddMenuItem (Parent, Title, RadioGroup, null, null);
	}

	public static RadioMenuItem AddMenuItem (object Parent, string Title, RadioMenuItem RadioGroup, string Identifier, EventHandler Activated)
	{
		RadioMenuItem menuItem = new RadioMenuItem (Title);
		menuItem.Identifier = Identifier;
		if (Activated != null) {
			menuItem.Activated += Activated;
		}
		if (RadioGroup != null) {
			menuItem.Group = RadioGroup.Group;
		} else {
			menuItem.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		}
		MenuItem.AddToParent (Parent, menuItem);
		return menuItem;
	}
}

