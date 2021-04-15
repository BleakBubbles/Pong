using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    List<Item> items = new List<Item>();

    List<Modifier> modifiers = new List<Modifier>();

    public void AcquireItem(Item item)
	{
		this.items.Add(item);
	}

    public void DropItem(Item item)
    {
        this.items.Remove(item);
    }

    public void ActivateModifier(Modifier modifier)
    {
        this.modifiers.Add(modifier);
    }

    public void DeactivateModifier(Modifier modifier)
    {
        this.modifiers.Remove(modifier);
    }
    public float speed = 7.5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
