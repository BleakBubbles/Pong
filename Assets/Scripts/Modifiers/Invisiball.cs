using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisiball : Modifier
{
	//doesnt work yet.
	//i think.
	Renderer ballRenderer;
    void Awake()
    {
		ModifierName = "Invisiball";
	}
	public override void Activate(Ball ball, Player playerPaddle)
	{
		base.Activate(ball, playerPaddle);
		ballRenderer = PongGameManager.Instance.ballScript.gameObject.GetComponent<Renderer>();
		StartCoroutine(Blink(2));
	}
	public override void Deactivate(Ball ball, Player playerPaddle)
	{
		base.Deactivate(ball, playerPaddle);
	}

	
 
	IEnumerator Blink(float WaitTime)
	{
		var endTime = Time.time + WaitTime;
		while (Time.time < WaitTime)
		{
			ballRenderer.enabled = false;
			yield return new WaitForSeconds(0.2f);
			ballRenderer.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
	}

}
