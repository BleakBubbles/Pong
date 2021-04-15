using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattershot : Item
{
	private void Awake()
	{
		DisplaySprite = Resources.Load<Sprite>("Sprites/crown");
        ItemName = "scattershot";
    }

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        base.Pickup(ball, playerPaddle);
        ball.OnHitPaddle += this.onHitPaddle;
        IsPermanent = true;
        LevelsToLast = 2;     
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
        var b = Instantiate(ball);
        b.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y + UnityEngine.Random.Range(-1.2f,1.2f));
    }
}
