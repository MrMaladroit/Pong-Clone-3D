using UnityEngine;

public class CollisionConroller : MonoBehaviour
{
    private BallMovementController bmc;
    private AudioManager audioManager;

    private void Awake()
    {
        bmc = GetComponent<BallMovementController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void BounceFromRacket(Collision2D collision)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 racketPosition = collision.gameObject.transform.position;

        float racketHeight = collision.collider.bounds.size.y;

        float x;
        if (collision.gameObject.tag == "Player Paddle")
        {
            x = 1;
        }
        else
            x = -1;

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        this.bmc.IncreaseHitCounter();
        this.bmc.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Paddle" || collision.gameObject.tag == "Opponent Paddle")
        {
            this.BounceFromRacket(collision);
            audioManager.PlayRacketSound();
        }
        else if (collision.gameObject.tag == "PlayerWall")
        {
            GameManager.instance.UpdateScore(collision.gameObject.tag);
            audioManager.PlayGoalSound();
            bmc.ResetBall(true);
        }
        else if (collision.gameObject.tag == "OpponentWall") 
        {
            GameManager.instance.UpdateScore(collision.gameObject.tag);
            audioManager.PlayGoalSound();
            bmc.ResetBall(false);
        }
        else
        {
            audioManager.PlayWallSound();
        }


    }
}