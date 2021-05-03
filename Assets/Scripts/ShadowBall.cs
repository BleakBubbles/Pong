using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;

    void Start()
    {
        movement = new Vector2(-1, 0);
        rb = gameObject.GetOrAddComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ShadowBall")
             Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider);
        if (collision.collider.tag == "Player")
        {
            float d = collision.contacts[0].point.y - collision.collider.transform.position.y;
            movement = new Vector2(movement.x * -1, d);
        }
        else if (collision.collider.tag == "Horizontal Wall")
        {
            movement = new Vector2(movement.x, movement.y * -1);
        }
        else if (collision.collider.name == "Left Wall")
        {
                movement = new Vector2(movement.x * -1, movement.y);
            
        }
        else if (collision.collider.name == "Right Wall")
        {
                movement = new Vector2(movement.x * -1, movement.y);
        }
    }

    public static GameObject CreateShadowBall(Vector2 InitPos)
	{
        var b = new GameObject("Shadow Ball");
        b.AddComponent<ShadowBall>();
        b.AddComponent<BoxCollider2D>();
        var r = b.AddComponent<SpriteRenderer>();
        r.sprite = Resources.Load<Sprite>("Sprites/Ball");
        var Rb = b.GetOrAddComponent<Rigidbody2D>();
        Rb.freezeRotation = true;
        Rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        b.transform.position = InitPos;
        var ballRenderer = b.GetComponent<Renderer>();
        b.tag = "ShadowBall";
        ballRenderer.material.SetColor("_Color", new Color32(186, 186, 186, 255));

        Physics2D.IgnoreCollision(b.GetComponent<Collider2D>(), PongGameManager.Instance.ballScript.GetComponent<Collider2D>());
        
        return b;
    }
    void FixedUpdate()
    {
            rb.MovePosition(rb.position + movement * 11.5f * Time.fixedDeltaTime);
    }
    void Update()
	{
        gameObject.transform.localScale = PongGameManager.Instance.ballScript.transform.localScale;
    }
}
