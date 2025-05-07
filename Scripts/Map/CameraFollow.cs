using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desired = target.position + offset;
        desired.z = transform.position.z;

        desired.x = Mathf.Clamp(desired.x, minBounds.x, maxBounds.x);
        desired.y = Mathf.Clamp(desired.y, minBounds.y, maxBounds.y);

        transform.position = Vector3.Lerp(transform.position, desired, Time.deltaTime * smoothSpeed);
    }
}
