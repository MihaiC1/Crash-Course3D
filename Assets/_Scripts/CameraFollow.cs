using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // Player (ball)
    public float followSpeed = 10f;
    public float fixedX = 0f;
    public float fixedY = 5f;
    public float offsetZ = -10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Only follow Z position (forward)
        float desiredZ = target.position.z + offsetZ;
        Vector3 desiredPosition = new Vector3(fixedX, fixedY, desiredZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
