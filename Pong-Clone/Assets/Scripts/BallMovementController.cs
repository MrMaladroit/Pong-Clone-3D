using System;
using System.Collections;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 400;

    private float maxSpeed = 1000;
    private float increasedSpeedMultiplier = 50;
    private float initialSpeed;
    private int hitCounter = 0;
    private bool isPlayerOneStarting = true;

    private Vector3 initialPosition;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        initialPosition = gameObject.transform.position;
    }

    private void Start()
    {
        StartCoroutine(StartBall(isPlayerOneStarting));
    }

    private IEnumerator StartBall(bool isPlayerOneServing)
    {
        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isPlayerOneServing)
            MoveBall(new Vector2(-1, 0));
        else
            MoveBall(new Vector2(1, 0));

    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        if(speed < maxSpeed)
            speed = speed + (increasedSpeedMultiplier * hitCounter);

        rb.velocity = dir * speed;
    }

    public void ResetBall(bool newStartingPlayer)
    {
        speed = initialSpeed;
        gameObject.transform.position = initialPosition;
        StartCoroutine(StartBall(newStartingPlayer));
        rb.velocity = Vector2.zero;

    }

    public void IncreaseHitCounter()
    {
        hitCounter++;
    }
    
}