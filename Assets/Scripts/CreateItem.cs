using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CreateItem : MonoBehaviour
{

	public Transform pos1;
	public Transform pos2;
	public Transform pos3;

	public Ball ballScipt;

	void Start()
    {
		ballScipt.OnLevelReset += this.HandleInstantiateItem;
    }

	public void HandleInstantiateItem()
    {
		for(int i = 0; i < gameObject.transform.childCount; i++)
        {
			gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
		this.InstantiateItem(0, 0, 0);
    }

    public void InstantiateItem(int itemId1, int itemId2, int itemId3)
	{
		if (itemId1 >= 0 && itemId1 < Game.items.Count)
		{
			var obj1 = new GameObject();
			Type t1 = Game.items[itemId1].GetType();
			var i1 = obj1.AddComponent(t1) as Item;
			obj1.name = i1.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			obj1.transform.parent = canvas.transform;
			obj1.transform.localScale = new Vector3(1, 1, 1);
			obj1.transform.position = pos1.position;
		}
		else
		{
			Debug.LogError("ITEM IS OUT OF RANGE, talk to bleak");
		}
		if (itemId2 >= 0 && itemId2 < Game.items.Count)
		{
			var obj2 = new GameObject();
			Type t2 = Game.items[itemId2].GetType();
			var i2 = obj2.AddComponent(t2) as Item;
			obj2.name = i2.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			obj2.transform.parent= canvas.transform;
			obj2.transform.localScale = new Vector3(1, 1, 1);
			obj2.transform.position = pos2.position;
		}
		else
		{
			Debug.LogError("ITEM IS OUT OF RANGE, talk to bleak");
		}
		if (itemId3 >= 0 && itemId3 < Game.items.Count)
		{
			var obj3 = new GameObject();
			Type t3 = Game.items[itemId3].GetType();
			var i3 = obj3.AddComponent(t3) as Item;
			obj3.name = i3.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			obj3.transform.parent= canvas.transform;
			obj3.transform.localScale = new Vector3(1, 1, 1);
			obj3.transform.position = pos3.position;
		}
		else
		{
			Debug.LogError("ITEM IS OUT OF RANGE, talk to bleak");
		}
	}
}
