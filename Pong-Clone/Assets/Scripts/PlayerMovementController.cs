using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private int speed = 75;

    private Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, speed, 0);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}