using System;

public class ImageMenuItem : Gtk.ImageMenuItem
{
	public new object UserData {
		get;
		set;
	}

	public string Identifier {
		get;
		set;
	}

	protected ImageMenuItem (GLib.GType gtype) : base (gtype)
	{
		UserData = null;
		Identifier = null;
	}

	public ImageMenuItem (IntPtr raw) : base (raw)
	{
		UserData = null;
		Identifier = null;
	}

	public ImageMenuItem () : base ()
	{
		UserData = null;
		Identifier = null;
	}

	public ImageMenuItem (string stock_id, Gtk.AccelGroup accel_group) : base (stock_id, accel_group)
	{
		UserData = null;
		Identifier = null;
	}

	public ImageMenuItem (string label) : base (label)
	{
		UserData = null;
		Identifier = null;
	}

	public static ImageMenuItem AddMenuItem (object Parent, string Title)
	{
		return AddMenuItem (Parent, Title, null, null, null);
	}

	public static ImageMenuItem AddMenuItem (object Parent, string Title, Gtk.Widget Image)
	{
		return AddMenuItem (Parent, Title, Image, null, null);
	}

	public static ImageMenuItem AddMenuItem (object Parent, string Title, Gtk.Widget Image, string Identifier, EventHandler Activated)
	{
		ImageMenuItem menuItem = new ImageMenuItem (Title);
		menuItem.Image = Image;
		menuItem.Identifier = Identifier;
		if (Activated != null) {
			menuItem.Activated += Activated;
		}
		MenuItem.AddToParent (Parent, menuItem);
		return menuItem;
	}
}

