namespace UI
{
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

            // 점수 저장 및 UI 출력
            GameSystem.ScoreManager.Instance.score = finalScore;
            GameSystem.ScoreManager.Instance.SaveHighScore();
            PlayerPrefs.SetInt("LastScore", finalScore);
            PlayerPrefs.Save();

            gameOverPanel.SetActive(true);
            resultText.text = success ? "성공!" : "실패!";
            elapsed = 0f;
        }

        void Update()
        {
            if (gameOver)
            {
                elapsed += Time.deltaTime;

                // 일정 시간 지나면 메인맵으로 복귀
                if (elapsed >= returnDelay)
                    SceneManager.LoadScene("MainMap");
            }
        }
    }
}
