using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 미니게임이 끝났을 때 점수 저장, 성공/실패 표시, 맵으로 돌아가는 기능을 담당하는 클래스
public class MiniGameController : MonoBehaviour
{
    public GameObject gameOverPanel;     // 게임이 끝났을 때 보여줄 UI 패널
    public Text resultText;              // 성공/실패 결과를 표시할 텍스트
    public float returnDelay = 2.5f;     // 몇 초 후에 메인 맵으로 돌아갈지 설정하는 시간

    private bool gameOver = false;       // 게임이 끝났는지 확인하는 변수
    private float elapsed = 0f;          // 흐른 시간을 재는 변수

    // 게임이 끝났을 때 실행되는 함수
    public void EndMiniGame(bool success, int finalScore)
    {
        if (gameOver) return; // 이미 끝난 상태면 다시 실행하지 않음
        gameOver = true; // 게임이 끝났다고 표시

        // 최종 점수를 ScoreManager에 저장
        ScoreManager.Instance.score = finalScore;
        ScoreManager.Instance.SaveHighScore();

        // 최근 점수를 저장 (다음 씬에서 보여줄 수 있음)
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();

        // 게임 종료 UI를 보여주고 성공/실패 메시지 출력
        gameOverPanel.SetActive(true);
        resultText.text = success ? "성공!" : "실패!";
    }

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // 게임이 끝났다면 시간 재기 시작
        if (gameOver)
        {
            elapsed += Time.deltaTime; // 흐른 시간을 누적
            if (elapsed >= returnDelay) // 기다린 시간이 설정값보다 많으면
                SceneManager.LoadScene("MainMap"); // 메인 맵 씬으로 돌아감
        }
    }
}
