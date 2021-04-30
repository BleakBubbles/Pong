using UnityEngine;

public class LongerPaddle : Item
{
    void Awake()
    {
        DisplaySprite = Resources.Load<Sprite>("Sprites/longer_paddle");
        ItemName = "longer paddle";
    }

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        base.Pickup(ball, playerPaddle);
        Vector3 scaleChange = new Vector3(0, 0.05f, 0);
        playerPaddle.transform.localScale += scaleChange;
    }

    public override void Drop(Ball ball, Player playerPaddle)
    {
        base.Drop(ball, playerPaddle);
        Vector3 scaleChange = new Vector3(0, 0.05f, 0);
        playerPaddle.transform.localScale -= scaleChange;
    }
}
