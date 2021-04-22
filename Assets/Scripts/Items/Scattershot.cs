using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattershot : Item
{
	private void Awake()
	{
		DisplaySprite = Resources.Load<Sprite>("Sprites/scattershot");
        ItemName = "scattershot";
    }

    List<GameObject> shadowBalls = new List<GameObject>();

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        base.Pickup(ball, playerPaddle);
        ball.OnHitPaddle += this.onHitPaddle;
        var b = Instantiate(ball.gameObject);
        shadowBalls.Add(b);
        b.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y + UnityEngine.Random.Range(-1.2f, 1.2f));
        Ball ballScript = b.GetComponent<Ball>();
        ballScript.scoresPoints = false;
        var ballRenderer = b.GetComponent<Renderer>();
        ballRenderer.material.SetColor("_Color", new Color32(229, 229, 229, 255));
        Physics2D.IgnoreCollision(b.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        LevelsToLast = 2;
    }

    public override void Drop(Ball ball, Player playerPaddle)
    {
        base.Drop(ball, playerPaddle);
        ball.OnHitPaddle -= this.onHitPaddle;
        foreach(GameObject b in this.shadowBalls)
        {
            UnityEngine.Object.Destroy(b);
        }
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
        if(UnityEngine.Random.value <= 0.1f)
        {
            var b = Instantiate(ball);
            shadowBalls.Add(b);
            b.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y + UnityEngine.Random.Range(-1.2f, 1.2f));
            Ball ballScript = b.GetComponent<Ball>();
            ballScript.scoresPoints = false;
            var ballRenderer = b.GetComponent<Renderer>();
            ballRenderer.material.SetColor("_Color", new Color32(229, 229, 229, 255));
            Physics2D.IgnoreCollision(b.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());
        }
    }
}
