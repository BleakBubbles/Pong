using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public TextMeshProUGUI start;

    private bool flash = true;

    private int localFrameCount;

    // Update is called once per frame
    void FixedUpdate()
    {
        localFrameCount++;
        if(localFrameCount % 25 == 0)
        {
            flash = !flash;
            if (flash)
            {
                start.color = Color.white;
            }
            else
            {
                start.color = Color.black;
            }
        }
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
