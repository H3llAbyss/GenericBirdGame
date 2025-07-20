using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public float textSpeed = 10;
    public bool IsAlive { get; set; } = true;
    public Text scoreText;
    public Text debugText;
    public GameObject gameOverScreen;

    private void Update()
    {
        if (!IsAlive)
        {
            scoreText.rectTransform.anchoredPosition = Vector3.MoveTowards(scoreText.rectTransform.anchoredPosition, new Vector3(0, scoreText.rectTransform.anchoredPosition.y),  textSpeed * Time.deltaTime);
        }
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameOver()
    {
        IsAlive = false;
        gameOverScreen.SetActive(true);
       
    }

    public void SetDebugText(DebugTextEntry entry)
    {
        var sb = new StringBuilder();

        sb.AppendLine(entry.currentPositionPixels.ToString() + "px");
        sb.AppendLine(entry.currentPositionGame.ToString());

        debugText.text = sb.ToString();
    }

    public class DebugTextEntry
    {
        public int currentPositionPixels;
        public float currentPositionGame;
    }
}
