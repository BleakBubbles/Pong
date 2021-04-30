using System.Collections;
using UnityEngine;
using TMPro;

public class PongGameManager : MonoBehaviour
{
	public static PongGameManager Instance;

	public int AiScore;
	public int PlayerScore;

	public int AiWins;
	public int PlayerWins;

	public Player Player;
	public GameObject AiPaddle;
	public Ball ballScript;

	public TextMeshProUGUI countdown;
	public GameObject panel;

	public CreateItemAndModifier createItemAndModifier;

	void Awake()
	{
		MakeSingleton();
	}

    void Start()
    {
		Time.timeScale = 0;
		base.StartCoroutine("Countdown");
	}

	private IEnumerator Countdown()
	{
		for(int i = 2; i >= 1; i--)
        {
			yield return new WaitForSecondsRealtime(1);
			countdown.text = i.ToString();
        }
		yield return new WaitForSecondsRealtime(1);
		Time.timeScale = 1;
		countdown.text = "Pong!";
		yield return new WaitForSeconds(1);
		countdown.gameObject.SetActive(false);
		panel.SetActive(false);
	}

	private void MakeSingleton()
	{
		if (Instance != null)
			Destroy(Instance);
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
