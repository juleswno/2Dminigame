namespace Map
{
    public class MiniGameTrigger : MonoBehaviour
    {
        public GameObject popupUI;       // 스페이스바를 눌러 미니게임 시작 안내 UI
        private bool canEnter = false;   // 진입 가능한 상태인지 저장
        public string sceneToLoad = "FlappyGame"; // 이동할 씬 이름

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                popupUI.SetActive(true); // UI 보여주기
                canEnter = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                popupUI.SetActive(false); // UI 숨기기
                canEnter = false;
            }
        }

        void Update()
        {
            // 스페이스 누르면 씬 전환
            if (canEnter && Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(sceneToLoad);
        }
    }
}
