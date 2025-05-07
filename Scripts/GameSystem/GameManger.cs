using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // 씬 이동에도 유지
            }
            else
            {
                Destroy(gameObject); // 중복 제거
            }
        }

        // 초기화용 (예: 메인맵 들어올 때 사용)
        public void ResetGame()
        {
            ScoreManager.Instance.ResetScore();
            Debug.Log("게임 초기화 완료");
        }

        // 씬 이동 기능 래핑
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // 게임 강제 종료나 리셋
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        // PlayerPrefs 초기화용 (디버그용)
        public void ResetPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs 초기화 완료");
        }
    }
}
