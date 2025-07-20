using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Text maxScoreText;

    private void Start()
    {
        maxScoreText.text = $"Max Score: {PlayerPrefsUtils.GetMaxPlayerScore()}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
