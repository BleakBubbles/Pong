using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;
using System;

public class CreateItemAndModifier : MonoBehaviour
{
	[HideInInspector]
	public event System.Action<Ball, Player> OnClearedItems;

	[Header("Transforms")]
	[SerializeField]
	private Transform pos1;
	[SerializeField]
	private Transform pos2;
	[SerializeField]
	private Transform pos3;
	[SerializeField]
	private Transform ModifierPosition;

	[Header("\n")]

	[SerializeField]
	private GameObject Panel;

	private GameObject Item1;
	private GameObject Item2;
	private GameObject Item3;
	private GameObject Modifier;

	[Header("Text")]
	public TextMeshProUGUI ItemName1;
	public TextMeshProUGUI ItemName2;
	public TextMeshProUGUI ItemName3;
	public TextMeshProUGUI ModifierName;

	void Start()
	{
		PongGameManager.Instance.ballScript.OnLevelReset += this.HandleInstantiate;
	}

	public void HandleInstantiate(Ball ball)
	{
		Panel.SetActive(true);

		//I dont know why,
		//I dont want to know why,
		//But if we dont do this some will not activate, despite us setting their parent to active.
		foreach (Transform child in Panel.transform)
		{
			child.gameObject.SetActive(true);
		}

		var item1 = UnityEngine.Random.Range(0, Game.items.Count);
		var item2 = UnityEngine.Random.Range(0, Game.items.Count);
		var item3 = UnityEngine.Random.Range(0, Game.items.Count);
		InstantiateItem(item1, item2, item3);
		var modifier = UnityEngine.Random.Range(0, Game.modifiers.Count);
		InstantiateModifier(modifier);
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
			ItemName1.text = Item1.name;
		}
		else
		{
			Debug.LogError("ITEM1 IS OUT OF RANGE, id: " + itemId1 + ", talk to bleak");
		}
		if (itemId2 >= 0 && itemId2 < Game.items.Count)
		{
			Item2 = new GameObject();
			Type t2 = Game.items[itemId2].GetType();
			var i2 = Item2.AddComponent(t2) as Item;
			Item2.name = i2.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			Item2.transform.parent = canvas.transform;
			Item2.transform.localScale = new Vector3(1, 1, 1);
			Item2.transform.position = pos2.position;
			ItemName2.text = Item2.name;
		}
		else
		{
			Debug.LogError("ITEM2 IS OUT OF RANGE, id: " + itemId2 + ", talk to bleak");
		}
		if (itemId3 >= 0 && itemId3 < Game.items.Count)
		{
			Item3 = new GameObject();
			Type t3 = Game.items[itemId3].GetType();
			var i3 = Item3.AddComponent(t3) as Item;
			Item3.name = i3.ItemName;
			var canvas = FindObjectOfType<Canvas>();
			Item3.transform.parent = canvas.transform;
			Item3.transform.localScale = new Vector3(1, 1, 1);
			Item3.transform.position = pos3.position;
			ItemName3.text = Item3.name;
		}
		else
		{
			Debug.LogError("ITEM3 IS OUT OF RANGE, id: " + itemId3 + ", talk to bleak");
		}
	}
	public void InstantiateModifier(int ModifierID)
	{
		if (ModifierID >= 0 && ModifierID < Game.modifiers.Count)
		{
			Modifier = new GameObject();
			Type t = Game.modifiers[ModifierID].GetType();
			var m = Modifier.AddComponent(t) as Modifier;
			Modifier.name = m.ModifierName;
			var canvas = FindObjectOfType<Canvas>();
			Modifier.transform.parent = canvas.transform;
			Modifier.transform.localScale = new Vector3(1, 1, 1);
			Modifier.transform.position = ModifierPosition.position;
			ModifierName.text = "Modifier: " + Modifier.name;
		}
		else
		{
			Debug.LogError("MODIFIER IS OUT OF RANGE, id: " + ModifierID + ", talk to bleak");
		}
	}
	public void Clear()
	{
		Destroy(Item1);
		Destroy(Item2);
		Destroy(Item3);
		Destroy(Modifier);
		Panel.SetActive(false);
		//same for this (read handle Instantiate)
		foreach (Transform child in Panel.transform)
		{
			child.gameObject.SetActive(false);
		}

		if (OnClearedItems != null)
			OnClearedItems.Invoke(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
	}
}

