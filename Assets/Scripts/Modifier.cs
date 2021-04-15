using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : ModifierButSomeAbstractStuff
{
    public bool IsPermanent = false;
    public int LevelsToLast;
    public Sprite DisplaySprite;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ran modifier start");
        Game.modifiers.Add(this);
    }

    public override void Activate(Ball ball, Player playerPaddle)
    {
        playerPaddle.ActivateModifier(this);
        ball.OnLevelReset += this.OnReset;
    }

    public override void Deactivate(Ball ball, Player playerPaddle)
    {
        playerPaddle.DeactivateModifier(this);
        ball.OnLevelReset -= this.OnReset;
    }

    private void OnReset()
    {
        if (IsPermanent == false)
        {
            LevelsToLast--;
            if (LevelsToLast <= 0)
            {
                this.Deactivate(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
            }
        }
    }
}
