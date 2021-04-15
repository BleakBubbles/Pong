using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : ItemButSomeAbstractStuff
{
    public bool IsPermanent = true;
    public int LevelsToLast;
    private void Start()
    {
        var btn = this.gameObject.GetOrAddComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener( () => { this.OnClick(); });
        btn.targetGraphic = this.GetComponent<Image>();
        ColorBlock colors = btn.colors;
         colors.highlightedColor = Color.grey;
        btn.colors = colors;
        IsPermanent = true;

    }

    private void OnClick()
    {
        this.Pickup(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
        Debug.Log("clicked");
    }

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        playerPaddle.AcquireItem(this);
        Debug.Log("Ran Item Pickup");
        ball.OnLevelReset += this.OnReset;
    }

	private void OnReset()
	{
        Debug.Log("onreset ran");
        if (IsPermanent == false)
        {
            LevelsToLast--;
            if (LevelsToLast <= 0)
            {
                //something that removes item from inventory 
            }
            
        }
        
	}
}
