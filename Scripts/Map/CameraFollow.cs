using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // 따라갈 대상 
    public float smoothSpeed = 5f;    // 카메라 이동 부드러움 정도
    public Vector2 minBounds;         // 카메라가 이동 가능한 최소 위치 (왼쪽 아래)
    public Vector2 maxBounds;         // 카메라가 이동 가능한 최대 위치 (오른쪽 위)

    private Vector3 offset;           // 카메라와 타겟 사이 거리 

    void Start()
    {
        // 시작 시, 현재 카메라 위치와 타겟 사이의 거리 계산
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // 타겟을 따라가되, 초기 거리(offset)를 유지
        Vector3 desired = target.position + offset;

        // z값은 카메라의 고정 위치 유지
        desired.z = transform.position.z;

        // 카메라가 지정된 경계를 벗어나지 않도록 제한
        desired.x = Mathf.Clamp(desired.x, minBounds.x, maxBounds.x);
        desired.y = Mathf.Clamp(desired.y, minBounds.y, maxBounds.y);

        // 현재 위치에서 목표 위치로 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desired, Time.deltaTime * smoothSpeed);
    }
}
