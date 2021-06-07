using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{

    public void OnClickedStartSolo()
	{
        SceneManager.LoadScene("SoloStart");
	}

    public void OnClickedStartMP()
    {
        SceneManager.LoadScene("MPScene");
    }  
}
