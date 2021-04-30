using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : ItemButSomeAbstractStuff
{
    public int LevelsToLast = 1;
    public Sprite DisplaySprite;
    public string ItemName;

    private void Start()
    {
        StartCoroutine(LateStart());     
    }
    private IEnumerator LateStart()
	{
        yield return new WaitForSecondsRealtime(0.001f);
        var btn = this.gameObject.GetOrAddComponent<Button>();
        var img = this.gameObject.GetOrAddComponent<Image>();
        img.sprite = DisplaySprite;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => { this.OnClick(); });
        btn.targetGraphic = this.GetComponent<Image>();
        ColorBlock colors = btn.colors;
        colors.highlightedColor = Color.grey;
        btn.colors = colors;
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

    private void OnReset(Ball ball)
	{
        LevelsToLast--;
        if (LevelsToLast <= 0)
            this.Drop(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
        
	}

    private void OnClick()
    {
        this.Pickup(PongGameManager.Instance.ballScript, PongGameManager.Instance.Player);
        PongGameManager.Instance.createItemAndModifier.Clear();
        PongGameManager.Instance.ballScript.Reset(false);
    }

}
