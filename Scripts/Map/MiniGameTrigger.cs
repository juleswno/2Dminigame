using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject popupUI;             // 플레이어가 접근했을 때 보여줄 UI
    public string sceneToLoad = "FlappyGame"; // 진입할 미니게임 씬 이름
    private bool canEnter = false;         // 현재 상호작용 가능한 상태인지 여부


    // 플레이어가 트리거 영역에 들어왔을 때 실행
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 태그가 Player인 경우에만 반응
        {
            popupUI.SetActive(true);    // 안내 UI 표시
            canEnter = true;            // 상호작용 가능 상태로 변경
        }
    }

    // 플레이어가 트리거 영역에서 나갔을 때 실행
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupUI.SetActive(false);   // UI 숨김
            canEnter = false;           // 상호작용 불가 상태로 변경
        }
    }

    // 스페이스바 입력으로 씬 전환 처리
    void Update()
    {
        if (canEnter && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad); // 설정된 미니게임 씬으로 이동
        }
    }
}

