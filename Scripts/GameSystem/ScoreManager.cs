using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // 싱글턴 인스턴스 
    public int score = 0;                     // 현재 점수
    public Text scoreText;                   // UI에 표시할 텍스트 컴포넌트

    // 싱글턴 초기화 및 중복 방지
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 이동 시 파괴되지 않도록
        }
        else
        {
            Destroy(gameObject);           // 이미 인스턴스가 있으면 중복 제거
        }
    }

    // 점수 추가 및 UI 업데이트
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    // 최고 점수를 저장 (PlayerPrefs 사용)
    public void SaveHighScore()
    {
        int best = PlayerPrefs.GetInt("HighScore", 0);  // 저장된 최고 점수 불러오기

        if (score > best)
        {
            PlayerPrefs.SetInt("HighScore", score);     // 더 높으면 갱신
            PlayerPrefs.Save();                         // 저장
        }
    }

    // 점수 UI 텍스트 업데이트
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"점수: {score}";
        }
    }
}
