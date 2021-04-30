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
        ball.OnLevelReset += this.onLevelReset;
    }

    public override void Drop(Ball ball, Player playerPaddle)
    {
        base.Drop(ball, playerPaddle);
        ball.OnHitPaddle -= this.onHitPaddle;
        ball.OnLevelReset -= this.onLevelReset;
    }

    private void onLevelReset(Ball ball)
    {
        ball.speedModifier = 1f;
    }

    private void onHitPaddle(GameObject ball, Collider2D paddle)
    {
        Ball ballScript = ball.GetComponent<Ball>();
        if (paddle.name == "Right Paddle")
            ballScript.speedModifier = 1.25f;
        else if(paddle.name == "Left Paddle")
            ballScript.speedModifier = 1f;
    }
}
