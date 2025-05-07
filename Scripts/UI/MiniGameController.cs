using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text resultText;
    public float returnDelay = 2.5f;

    private bool gameOver = false;
    private float elapsed = 0f;

    public void EndMiniGame(bool success, int finalScore)
    {
        if (gameOver) return;
        gameOver = true;

        ScoreManager.Instance.score = finalScore;
        ScoreManager.Instance.SaveHighScore();
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();

        gameOverPanel.SetActive(true);
        resultText.text = success ? "성공!" : "실패!";
    }

    void Update()
    {
        if (gameOver)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= returnDelay)
                SceneManager.LoadScene("MainMap");
        }
    }
}
