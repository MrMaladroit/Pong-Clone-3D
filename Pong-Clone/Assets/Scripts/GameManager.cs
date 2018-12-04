using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text playerScoreText;
    public Text opponentScoreText;
    public static GameManager instance;

    private int playerScore = 0;
    private int opponentScore = 0;
    private PlayerMovementController playerPaddle;
    private AIMovementController opponentPaddle;

       
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        playerPaddle = FindObjectOfType<PlayerMovementController>();
        opponentPaddle = FindObjectOfType<AIMovementController>();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void UpdateScore(string tag)
    {
        if (tag == "PlayerWall")
        {
            opponentScore++;
            opponentScoreText.text = opponentScore.ToString();
        }
        else
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }
        CheckIfGameOver();
        playerPaddle.ResetPosition();
        opponentPaddle.ResetPosition();
    }

    public void CheckIfGameOver()
    {
        if (playerScore >= 7)
        {
            SceneManager.LoadScene(2);
        }
        else if (opponentScore >= 7)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}