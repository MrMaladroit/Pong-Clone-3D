using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private int speed = 75;

    private float dir;

    private Rigidbody2D rb;
    private Vector3 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = gameObject.transform.position;
    }

    private void Update()
    {
        dir = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(0, dir * speed);
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        gameObject.transform.position = initialPosition;
    }
}