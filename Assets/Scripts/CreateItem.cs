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

	[SerializeField]
	private GameObject Panel;

	private GameObject Item1;
	private GameObject Item2;
	private GameObject Item3;
	void Start()
    {
		ballScipt.OnLevelReset += this.HandleInstantiateItem;
    }

	public void HandleInstantiateItem()
    {
		Panel.SetActive(true);
		var item1 = UnityEngine.Random.Range(0, Game.items.Count - 1);
		var item2 = UnityEngine.Random.Range(0, Game.items.Count - 1);
		var item3 = UnityEngine.Random.Range(0, Game.items.Count - 1);
		this.InstantiateItem(item1, item2, item3);
    }

    public void InstantiateItem(int itemId1, int itemId2, int itemId3)
	{
		if (itemId1 >= 0 && itemId1 < Game.items.Count)
		{
		    Item1 = new GameObject();
			Type t1 = Game.items[itemId1].GetType();
			var i1 = Item1.AddComponent(t1) as Item;
			Item1.name = i1.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			Item1.transform.parent = canvas.transform;
			Item1.transform.localScale = new Vector3(1, 1, 1);
			Item1.transform.position = pos1.position;
		}
		else
		{
			Debug.LogError("ITEM1 IS OUT OF RANGE id"+itemId1+", talk to bleak");
		}
		if (itemId2 >= 0 && itemId2 < Game.items.Count)
		{
			Item2 = new GameObject();
			Type t2 = Game.items[itemId2].GetType();
			var i2 = Item2.AddComponent(t2) as Item;
			Item2.name = i2.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			Item2.transform.parent= canvas.transform;
			Item2.transform.localScale = new Vector3(1, 1, 1);
			Item2.transform.position = pos2.position;
		}
		else
		{
			Debug.LogError("ITEM2 IS OUT OF RANGE id: "+itemId2+", talk to bleak");
		}
		if (itemId3 >= 0 && itemId3 < Game.items.Count)
		{
			Item3 = new GameObject();
			Type t3 = Game.items[itemId3].GetType();
			var i3 = Item3.AddComponent(t3) as Item;
			Item3.name = i3.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			Item3.transform.parent= canvas.transform;
			Item3.transform.localScale = new Vector3(1, 1, 1);
			Item3.transform.position = pos3.position;
		}
		else
		{
			Debug.LogError("ITEM3 IS OUT OF RANGE id: "+itemId3+", talk to bleak");
		}
	}

	public void ClearItems()
	{
		Destroy(Item1);
		Destroy(Item2);
		Destroy(Item3);
		Panel.SetActive(false);
	}	
}
