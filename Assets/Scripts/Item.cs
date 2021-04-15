﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : ItemButSomeAbstractStuff
{

    private void Start()
    {
        var btn = this.gameObject.AddComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener( () => { this.OnClick(); });
        btn.targetGraphic = this.GetComponent<Image>();
        ColorBlock colors = btn.colors;
         colors.highlightedColor = Color.grey;
        btn.colors = colors;
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
    }
}