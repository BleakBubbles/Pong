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

    public int counter;

    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;

    public Vector2 movement;

    [SerializeField]
    private bool ForceEnd;
    [SerializeField]
    private int BouncesSinceHitTop;
    [SerializeField]
    private int BouncesSinceHitBot;
    [SerializeField]
    private int BouncesSinceHitRight;
    [SerializeField]
    private int BouncesSinceHitLeft;
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
        BouncesSinceHitLeft = 0;
        BouncesSinceHitRight = 0;
        BouncesSinceHitTop = 0;
        BouncesSinceHitBot = 0;
        counter++;
        LeftPaddle.transform.position = new Vector2(-6, 0);
        RightPaddle.transform.position = new Vector2(6, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BouncesSinceHitLeft++;
        BouncesSinceHitRight++;
        BouncesSinceHitTop++;
        BouncesSinceHitBot++;
        if (OnAnyBounce != null)
            OnAnyBounce.Invoke(gameObject, collision.collider);

        if (collision.collider.tag == "Player")
        {
            if (collision.collider.gameObject.name == "Left Paddle")
                BouncesSinceHitLeft = 0;
            else
                BouncesSinceHitRight = 0;

            float d = collision.contacts[0].point.y - collision.collider.transform.position.y;
            movement = new Vector2(movement.x * -1, d);
    
            if(OnHitPaddle != null)
                OnHitPaddle.Invoke(gameObject, collision.collider);
        }
        if (collision.collider.tag == "Horizontal Wall")
        {
            if (collision.collider.gameObject.name == "Top Wall")
                BouncesSinceHitTop = 0;
            else
                BouncesSinceHitBot = 0;

            movement = new Vector2(movement.x, movement.y * -1);
            if(OnHitHorizontalWall != null)
                OnHitHorizontalWall.Invoke(gameObject, collision.collider);
        }
        if (collision.collider.name == "Left Wall")
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
        if (collision.collider.name == "Right Wall")
        {
                PongGameManager.Instance.AiScore++;
                UpdateScores();
                if (PongGameManager.Instance.AiScore >= 10)
                {
                    PongGameManager.Instance.AiWins++;
                    this.Reset(true);
                    return;
                }
                this.Reset(false);
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
        LeftPaddle.MovePosition(LeftPaddle.position + new Vector2(0, Mathf.Clamp(base.transform.position.y - LeftPaddle.transform.position.y, -1, 1)) * 7.5f * Time.fixedDeltaTime);
        
        if(ForceEnd == true)
		{
            Reset(true);

            ForceEnd = false;
		}
        
        if (BouncesSinceHitLeft >= 15 || BouncesSinceHitRight >= 15 || BouncesSinceHitTop >= 15 || BouncesSinceHitBot >= 15)
            Reset(false);
    }
}
