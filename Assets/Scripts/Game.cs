using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

public class Game : MonoBehaviour
{
	public IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
	{
		return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
	}

	private void Start()
	{
		foreach (Type t in FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(Item)))
		{
			var instance = (Item)Activator.CreateInstance(t);
			items.Add(instance);
		}
	}

	public static List<Item> items = new List<Item>();
    public static List<Modifier> modifiers = new List<Modifier>();
}
