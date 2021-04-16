using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefulPaddle : Item
{
    // Start is called before the first frame update
    void Awake()
    {
        DisplaySprite = Resources.Load<Sprite>("Sprites/forceful_paddle");
        ItemName = "forceful paddle";
    }

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        base.Pickup(ball, playerPaddle);
        ball.OnHitPaddle += this.onHitPaddle;
    }

    public override void Drop(Ball ball, Player playerPaddle)
    {
        base.Drop(ball, playerPaddle);
        ball.OnHitPaddle -= this.onHitPaddle;
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
        Ball ballScript = ball.GetComponent<Ball>();
        if (paddle.name == "Right Paddle")
        {
            ballScript.speed *= 1.25f;
        }
        else if(paddle.tag == "Left Paddle")
        {
            ballScript.speed *= 0.8f;
        }
    }
}
