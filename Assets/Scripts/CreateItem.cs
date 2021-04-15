using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CreateItem : MonoBehaviour
{
	public void InstantiateItem(int itemId)
	{
		if (itemId >= 0 && itemId < Game.items.Count)
		{
			var obj = new GameObject();

			Type t = Game.items[itemId].GetType();
			var i = obj.AddComponent(t) as Item;
			obj.name = i.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			obj.transform.parent= canvas.transform;
			obj.transform.localScale = new Vector3(1, 1, 1);
		}
		else
		{
			Debug.LogError("ITEM IS OUT OF RANGE, talk to bleak");
		}
	}
}
