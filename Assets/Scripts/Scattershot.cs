using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattershot : Item
{
    public override void Pickup(Ball ball, Player playerPaddle)
    {
        base.Pickup(ball, playerPaddle);
        ball.OnHitPaddle += this.onHitPaddle;
        IsPermanent = false;
        LevelsToLast = 2;
        Debug.Log("pickup ran");
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
        Debug.Log("OnHitRan");
    }
}
