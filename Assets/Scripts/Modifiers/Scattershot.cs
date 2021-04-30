using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattershot : Modifier
{
	private void Awake()
	{
		DisplaySprite = Resources.Load<Sprite>("Sprites/scattershot");
        ModifierName = "scattershot";
    }

    List<GameObject> shadowBalls = new List<GameObject>();

    public override void Activate(Ball ball, Player playerPaddle)
    {
        base.Activate(ball, playerPaddle);
        ball.OnHitPaddle += this.onHitPaddle;
        var b = ShadowBall.CreateShadowBall(new Vector2(ball.transform.position.x, ball.transform.position.y + UnityEngine.Random.Range(-1.2f, 1.2f)));       
        shadowBalls.Add(b);
        LevelsToLast = 1;
    }

    public override void Deactivate(Ball ball, Player playerPaddle)
    {
        base.Deactivate(ball, playerPaddle);
        ball.OnHitPaddle -= this.onHitPaddle;
        foreach(GameObject b in this.shadowBalls)
        {
            Destroy(b);
        }
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
        if(UnityEngine.Random.value <= 0.1f)
        {
            var b = ShadowBall.CreateShadowBall(new Vector2(ball.transform.position.x, ball.transform.position.y + UnityEngine.Random.Range(-1.2f, 1.2f)));
            shadowBalls.Add(b);
        }
    }
}
