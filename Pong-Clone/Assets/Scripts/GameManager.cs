using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text playerScoreText;
    public Text opponentScoreText;

    private int playerScore = 0;
    private int opponentScore = 0;
    public static GameManager instance;


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
        else if (tag == "OpponentWall")
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }
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
}