using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Game : MonoBehaviour
{
	public static List<Item> items = new List<Item>();
	public static List<Modifier> modifiers = new List<Modifier>();

	private void Start()
	{
		foreach (Type t in ToolBox.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(Item)))
		{
			var instance = (Item)Activator.CreateInstance(t);
			items.Add(instance);
		}

		foreach (Type t in ToolBox.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(Modifier)))
		{
			var instance = (Modifier)Activator.CreateInstance(t);
			modifiers.Add(instance);
		}
	}
}
