using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGameManager : MonoBehaviour
{
	public static PongGameManager Instance;

	public int AiScore;
	public int PlayerScore;

	public Player Player;
	public GameObject AiPaddle;
	public Ball ballScript;

	void Awake()
	{
		MakeSingleton();
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
