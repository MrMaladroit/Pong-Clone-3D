using System;
using System.Collections;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 400;

    private float maxSpeed = 1000;
    private float increasedSpeedMultiplier = 50;
    private int hitCounter = 0;
    private Rigidbody rb;
    private bool isPlayerOneStarting;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isPlayerOneStarting = true;
    }

    private void Start()
    {
        StartCoroutine(StartBall(isPlayerOneStarting));
    }

    private IEnumerator StartBall(bool isPlayerOneStarting)
    {
        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isPlayerOneStarting)
            MoveBall(new Vector3(-1, 0, 0));
        else
            MoveBall(new Vector3(1, 0, 0));

    }

    private void MoveBall(Vector3 dir)
    {
        dir = dir.normalized;

        speed = speed + (increasedSpeedMultiplier * hitCounter);

        rb.velocity = dir * speed;
    }
}