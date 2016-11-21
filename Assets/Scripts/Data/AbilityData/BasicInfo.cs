using UnityEngine;

public class BasicInfo {
	private string name;
	private string desc;
	private Sprite icon;

	public BasicInfo (string name, string desc)
	{
		this.name = name;
		this.desc = desc;
	}
	
	public BasicInfo (string name, string desc, Sprite icon)
	{
		this.name = name;
		this.desc = desc;
		this.icon = icon;
	}

	public string Name {
		get {
			return this.name;
		}
	}

	public string Desc {
		get {
			return this.desc;
		}
	}

	public Sprite Icon {
		get {
			return this.icon;
		}
	}
}
