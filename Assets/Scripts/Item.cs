using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : ItemButSomeAbstractStuff
{
    public bool IsPermanent = true;
    public int LevelsToLast;
    public Sprite DisplaySprite;
    public string ItemName;
    public Type t;
    private void Start()
    {
        Debug.Log("ran item start");
        var btn = this.gameObject.GetOrAddComponent<Button>();
        var img = this.gameObject.GetOrAddComponent<Image>();
        img.sprite = DisplaySprite;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener( () => { this.OnClick(); });
        btn.targetGraphic = this.GetComponent<Image>();
        ColorBlock colors = btn.colors;
         colors.highlightedColor = Color.grey;
        btn.colors = colors;
        t = this.GetType(); 
    }

    private void OnClick()
    {
        this.Pickup(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
    }

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        playerPaddle.AcquireItem(this);
        ball.OnLevelReset += this.OnReset;
    }

	private void OnReset()
	{
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
