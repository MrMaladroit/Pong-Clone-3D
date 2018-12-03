using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private int initialSpeed = 150;
    [SerializeField]
    private int maximumSpeed = 750;
    [SerializeField]
    private int currentSpeed;
    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource audioSource;
    private Vector3 initialPosition;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = gameObject.transform.position;
        currentSpeed = initialSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(currentSpeed, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerWall")
        {
            GameManager.instance.UpdateScore(other.tag);
            ResetBall();
        }
        else if( other.tag == "OpponentWall")
        {
            GameManager.instance.UpdateScore(other.tag);
            ResetBall();
        }

        GameManager.instance.CheckIfGameOver();
    }

    private void ResetBall()
    {
        gameObject.transform.position = initialPosition;
        currentSpeed = initialSpeed;
    }
}

