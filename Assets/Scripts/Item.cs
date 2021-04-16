using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : ItemButSomeAbstractStuff
{
    public int LevelsToLast = 1;
    public Sprite DisplaySprite;
    public string ItemName;

    CreateItem CreateItem = new CreateItem();
    Ball ball = new Ball();
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
        var hand = GameObject.Find("Main Canvas/Item Menu");
        CreateItem = hand.GetComponent<CreateItem>();
    }

    private void OnClick()
    {
        this.Pickup(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
        CreateItem.ClearItems();     
        PongGameManager.Instance.ballScript.Reset(false);
    }

    public override void Pickup(Ball ball, Player playerPaddle)
    {
        playerPaddle.AcquireItem(this);
        ball.OnLevelReset += this.OnReset;
    }

    public override void Drop(Ball ball, Player playerPaddle)
    {
        playerPaddle.DropItem(this);
        ball.OnLevelReset -= this.OnReset;
        Debug.Log("Ran Drop");

    }

    private void OnReset()
	{
            LevelsToLast--;
            if (LevelsToLast <= 0)
            {
                this.Drop(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
            }    
        
	}
}
