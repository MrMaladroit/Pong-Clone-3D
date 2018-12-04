using UnityEngine;

public class AIMovementController : MonoBehaviour
{
    [SerializeField]
    private int speed = 150;

    private Transform ball;
    private Rigidbody2D rb;
    private Vector3 initialPosition;

    private void Awake()
    {
        ball = FindObjectOfType<BallMovementController>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if(gameObject.transform.position.y - ball.transform.position.y > 1.25f)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else if(gameObject.transform.position.y - ball.transform.position.y < -1.25f)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        gameObject.transform.position = initialPosition;
    }
}
