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
        IsPermanent = true;
        LevelsToLast = 2;     
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
    }
}
