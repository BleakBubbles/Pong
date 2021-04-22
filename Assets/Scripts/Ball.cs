//Balls Wide
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    public event System.Action<GameObject, Collider2D> OnAnyBounce;
    public event System.Action<GameObject, Collider2D> OnHitHorizontalWall;
    public event System.Action<Ball> OnLevelReset;
    public event System.Action<GameObject, Collider2D> OnHitPaddle;

    public Rigidbody2D LeftPaddle;
    public Rigidbody2D RightPaddle;
    public Rigidbody2D rb;

    public float restartDelay = 1f;
    public float speed = 12.5f;
    public float speedModifier = 1f;
    public bool scoresPoints = true;

    public int counter;

    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;

    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(-1, 0);
        PongGameManager.Instance.PlayerScore = 0;
        PongGameManager.Instance.AiScore = 0;
        counter = 1;
        rb.freezeRotation = true;
    }

    

    public void Reset(bool isEnding)
    {
        gameObject.transform.position = new Vector2(0, 0);
        if (isEnding)
        {
            movement = Vector2.zero;
            if (OnLevelReset != null)
                OnLevelReset.Invoke(this);
            PongGameManager.Instance.PlayerScore = 0;
            PongGameManager.Instance.AiScore = 0;
            UpdateScores();
        }
        else
        {
            movement = new Vector2(Mathf.Pow(-1, counter), 0);
        }
        counter++;
        LeftPaddle.transform.position = new Vector2(-6, 0);
        RightPaddle.transform.position = new Vector2(6, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(OnAnyBounce != null)
            OnAnyBounce.Invoke(gameObject, collision.collider);

        if (collision.collider.tag == "Player")
        {
            float d = collision.contacts[0].point.y - collision.collider.transform.position.y;
            movement = new Vector2(movement.x * -1, d);
            Debug.Log(speedModifier);
            if(OnHitPaddle != null)
                OnHitPaddle.Invoke(gameObject, collision.collider);
        }
        else if (collision.collider.tag == "Horizontal Wall")
        {
            movement = new Vector2(movement.x, movement.y * -1);
            if(OnHitHorizontalWall != null)
                OnHitHorizontalWall.Invoke(gameObject, collision.collider);
        }
        else if (collision.collider.name == "Left Wall")
        {
            if (this.scoresPoints)
            {
                PongGameManager.Instance.PlayerScore++;
                UpdateScores();
                if (PongGameManager.Instance.PlayerScore >= 10)
                {
                    this.Reset(true);
                    PongGameManager.Instance.PlayerWins++;
                    return;
                }
                this.Reset(false);
            }
            else
            {
                movement = new Vector2(movement.x * -1, movement.y);
            }
        }
        else if (collision.collider.name == "Right Wall")
        {
            if (this.scoresPoints)
            {
                PongGameManager.Instance.AiScore++;
                UpdateScores();
                if (PongGameManager.Instance.AiScore >= 10)
                {
                    //Invoke("ResetScene", restartDelay);
                    PongGameManager.Instance.AiWins++;
                    this.Reset(true);
                    return;
                }
                this.Reset(false);
            }
            else
            {
                movement = new Vector2(movement.x * -1, movement.y);
            }
        }
    }

    public void UpdateScores()
	{
        this.LeftText.text = PongGameManager.Instance.AiScore.ToString();
        this.RightText.text = PongGameManager.Instance.PlayerScore.ToString();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * speedModifier * Time.fixedDeltaTime);
        if (this.scoresPoints)
        {
            LeftPaddle.MovePosition(LeftPaddle.position + new Vector2(0, Mathf.Clamp(base.transform.position.y - LeftPaddle.transform.position.y, -1, 1)) * 7.5f * Time.fixedDeltaTime);
        }
    }
}
