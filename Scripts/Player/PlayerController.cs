namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody2D rb;
        private Vector2 moveInput;

        void Start() => rb = GetComponent<Rigidbody2D>();

        void Update()
        {
            // 키보드 입력을 받아 이동 방향 계산
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(moveX, moveY).normalized;
        }

        void FixedUpdate()
        {
            // Rigidbody2D를 사용해 부드럽게 이동
            rb.velocity = moveInput * speed;
        }
    }
}

