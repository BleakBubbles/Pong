using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modifier : ModifierButSomeAbstractStuff
{
    public int LevelsToLast;
    public Sprite DisplaySprite;
    public string ModifierName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart());       
    }
    private IEnumerator LateStart()
    {
        yield return new WaitForSecondsRealtime(0.001f);
        var img = this.gameObject.GetOrAddComponent<Image>();
        img.sprite = DisplaySprite;
        PongGameManager.Instance.createItemAndModifier.OnClearedItems += Activate;
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

    private void OnReset(Ball ball)
    {
            LevelsToLast--;
            if (LevelsToLast <= 0)
            {
                this.Deactivate(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
            }
        
    }
}
