using UnityEngine;

// 장애물을 피하면서 점수를 올리는 플래피버드 스타일 미니게임 컨트롤러
public class FlappyGameController : MonoBehaviour
{
    public float jumpForce = 5f; // 스페이스를 눌렀을 때 위로 튀는 힘
    public Rigidbody2D rb; // 플레이어의 물리 몸체
    public int score = 0; // 현재 점수
    public UI.MiniGameController gameController; // 게임 종료 후 UI 처리 담당

    private bool isGameOver = false; // 게임이 끝났는지 여부 확인용

    void Start()
    {
        // Rigidbody2D 컴포넌트를 연결
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 게임이 끝났으면 입력을 막기
        if (isGameOver) return;

        // 스페이스바를 누르면 위로 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce; // 위쪽으로 힘을 줘서 점프
        }

        // 점수가 100점 이상이면 자동으로 성공 처리
        if (score >= 100)
        {
            isGameOver = true; // 게임 종료 상태로 변경
            gameController.EndMiniGame(true, score); // 성공 처리 및 점수 전달
        }
    }

    // 장애물에 부딪히면 게임 실패
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)
        {
            isGameOver = true; // 게임 종료 상태로 변경
            gameController.EndMiniGame(false, score); // 실패 처리 및 점수 전달
        }
    }

    // 점수 존에 들어가면 점수 +10
    void OnTriggerEnter2D(Collider2D other)
    {
        // 부딪힌 오브젝트의 태그가 "ScoreZone"이면
        if (other.CompareTag("ScoreZone"))
        {
            score += 10; // 점수 증가
        }
    }
}
