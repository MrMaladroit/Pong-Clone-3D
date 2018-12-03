using UnityEngine;

public class AIMovementController : MonoBehaviour
{
    [SerializeField]
    private int speed = 150;

    private Transform ball;
    private Rigidbody rb;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y - ball.transform.position.y > 1.25f)
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
        else if(gameObject.transform.position.y - ball.transform.position.y < -1.25f)
        {
            rb.velocity = new Vector3(0, speed, 0);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
