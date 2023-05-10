using System;
using UnityEngine;

[Serializable]
public class Target
{
	public string Name;
	public GameObject PositionObject;

	public void init(GameObject obj, string name)
	{
		PositionObject = obj;
		Name = name;
	}
}
