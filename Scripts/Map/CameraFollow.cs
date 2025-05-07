namespace Map
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;         // 따라갈 대상
        public float smoothSpeed = 5f;   // 따라가는 속도
        public Vector2 minBounds;        // 카메라 제한 최소
        public Vector2 maxBounds;        // 카메라 제한 최대
        private Vector3 offset;

        void Start() => offset = transform.position - target.position;

        void LateUpdate()
        {
            // 플레이어 위치 + 간격 계산
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = transform.position.z;

            // 맵 밖으로 안 나가도록 제한
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            // 부드럽게 따라가기
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        }
    }
}
