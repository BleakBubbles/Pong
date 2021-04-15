using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    public delegate void OnAnyBounceHandler(GameObject ball, Collider2D other);
    public static event OnAnyBounceHandler OnAnyBounce;

    public delegate void OnHitHorizontalWallHandler(GameObject ball, Collider2D wall);
    public static event OnHitHorizontalWallHandler OnHitHorizontalWall;

    public delegate void OnLevelResetHandler();
    public static event OnLevelResetHandler OnLevelReset;

    public delegate void OnHitPaddleHandler(GameObject ball, Collider2D paddle);
    public static event OnHitPaddleHandler OnHitPaddle;


    public Rigidbody2D LeftPaddle;
    public Rigidbody2D RightPaddle;
    public Rigidbody2D rb;

    public static string modifier = "";
    public float restartDelay = 1f;
    public float speed = 12.5f;

    public int LeftScore;
    public int RightScore;
    public int counter;

    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;

    private GameManager gameManager;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(-1, 0);
        LeftScore = 0;
        RightScore = 0;
        counter = 0;
        rb.freezeRotation = true;
    }

    

    public void Reset(bool isEnding)
    {
        base.transform.position = new Vector2(0, 0);
        if (isEnding)
        {
            movement = Vector2.zero;
        }
        else
        {
            movement = new Vector2(Mathf.Pow(-1, counter), 0);
        }
        counter++;
        LeftPaddle.transform.position = new Vector2(-6, 0);
        RightPaddle.transform.position = new Vector2(6, 0);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(OnLevelReset != null)
            OnLevelReset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(OnAnyBounce != null)
            OnAnyBounce(gameObject, collision.collider);

        if (collision.collider.tag == "Player")
        {
            float d = collision.contacts[0].point.y - collision.collider.transform.position.y;
            movement = new Vector2(movement.x * -1, d);
            if(OnHitPaddle != null)
                OnHitPaddle(gameObject, collision.collider);
        }
        else if (collision.collider.tag == "Horizontal Wall")
        {
            movement = new Vector2(movement.x, movement.y * -1);
            if(OnHitHorizontalWall != null)
                OnHitHorizontalWall(gameObject, collision.collider);
        }
        else if (collision.collider.name == "Left Wall")
        {
            RightScore++;
            RightText.text = RightScore.ToString();
            if (RightScore == 10)
            {
                Invoke("ResetScene", restartDelay);
                this.Reset(true);
                return;
            }
            this.Reset(false);
        }
        else if (collision.collider.name == "Right Wall")
        {
            LeftScore++;
            LeftText.text = LeftScore.ToString();
            if(LeftScore == 10)
            {
                Invoke("ResetScene", restartDelay);
                this.Reset(true);
                return;
            }
            this.Reset(false);
        }

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        LeftPaddle.MovePosition(LeftPaddle.position + new Vector2(0, Mathf.Clamp(base.transform.position.y - LeftPaddle.transform.position.y, -1, 1)) * 7.5f * Time.fixedDeltaTime);
    }
}
