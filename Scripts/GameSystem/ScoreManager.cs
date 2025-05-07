namespace GameSystem
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        public int score = 0;
        public Text scoreText; // 점수를 보여줄 UI

        void Awake()
        {
            // 전역에서 1개만 유지
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        public void AddScore(int value)
        {
            score += value;
            UpdateScoreUI();
        }

        public void ResetScore()
        {
            score = 0;
            UpdateScoreUI();
        }

        public void SaveHighScore()
        {
            int best = PlayerPrefs.GetInt("HighScore", 0);
            if (score > best)
            {
                PlayerPrefs.SetInt("HighScore", score);
                PlayerPrefs.Save();
            }
        }

        private void UpdateScoreUI()
        {
            if (scoreText != null)
                scoreText.text = $"점수: {score}";
        }
    }
}
