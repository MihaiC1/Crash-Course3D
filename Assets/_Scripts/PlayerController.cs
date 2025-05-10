using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player; // The ball
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 8f;

    private int targetLane = 1; // 0 = left, 1 = center, 2 = right
    private Rigidbody rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleSwipeInput();

        // Constant forward motion
        player.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Smooth lateral movement
        Vector3 targetPosition = player.position;
        targetPosition.x = (targetLane - 1) * laneDistance;
        Vector3 moveDir = targetPosition - player.position;
        moveDir.y = 0;

        rb.linearVelocity = new Vector3(moveDir.x * laneChangeSpeed, rb.linearVelocity.y, forwardSpeed);
    }

    void HandleSwipeInput()
    {
        if (SwipeDetector.SwipeLeft && targetLane > 0)
            targetLane--;

        if (SwipeDetector.SwipeRight && targetLane < 2)
            targetLane++;

        if (SwipeDetector.SwipeUp && IsGrounded())
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(player.position, Vector3.down, 0.6f);
    }
}
