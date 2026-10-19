using UnityEngine;

/// <summary>
/// Script đơn giản để máy bay "cất cánh" (bay về phía trước + lên).
/// Gắn lên Airplane (cần Rigidbody, Is Kinematic OFF hoặc dùng Transform).
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class AirplaneTakeOff : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 4f;
    [SerializeField] private float climbSpeed = 0.8f;
    [SerializeField] private bool autoStart = true;

    private Rigidbody rb;
    private bool isFlying;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Start()
    {
        if (autoStart)
            isFlying = true;
    }

    private void FixedUpdate()
    {
        if (!isFlying)
            return;

        Vector3 velocity = transform.forward * forwardSpeed + Vector3.up * climbSpeed;
        rb.linearVelocity = velocity;
    }

    public void StartTakeOff()
    {
        isFlying = true;
    }
}
