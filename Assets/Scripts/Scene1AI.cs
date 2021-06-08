using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1AI : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(0, Mathf.Clamp(PongGameManager.Instance.ballScript.gameObject.transform.position.y - rb.transform.position.y, -1, 1)) * 7.5f * Time.fixedDeltaTime);
    }
}
