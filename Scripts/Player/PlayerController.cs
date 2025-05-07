using UnityEngine;

// 플레이어 캐릭터를 움직이기
public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 캐릭터가 얼마나 빠르게 움직일지를 정하기
    private Rigidbody2D rb; // 캐릭터에 물리적인 힘을 줄 수 있게 도와주는 컴포넌트
    private Vector2 moveInput; // 어느 방향으로 움직일지를 저장하는 변수

    // 게임이 시작될 때 한 번 실행되는 함수
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 이 오브젝트에 붙은 Rigidbody2D를 가져와요
    }

    // 매 프레임마다 실행되는 함수 (키보드 입력 체크)
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A, D 또는 왼쪽, 오른쪽 화살표 키
        float moveY = Input.GetAxisRaw("Vertical");   // W, S 또는 위쪽, 아래쪽 화살표 키

        // 입력한 방향을 저장 & 대각선으로 갈 때 속도가 빨라지지 않도록 normalized 처리
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    // 물리 엔진과 관련된 계산 처리
    void FixedUpdate()
    {
        // 키보드로 입력한 방향으로 캐릭터 움직이기
        rb.velocity = moveInput * speed;
    }
}
