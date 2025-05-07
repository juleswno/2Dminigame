using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        // UI 버튼에 연결할 함수
        public void OnClickResetGame()
        {
            GameSystem.GameManager.Instance.ResetGame();
        }

        public void OnClickDeleteAllPrefs()
        {
            GameSystem.GameManager.Instance.ResetPrefs();
        }
    }
}
