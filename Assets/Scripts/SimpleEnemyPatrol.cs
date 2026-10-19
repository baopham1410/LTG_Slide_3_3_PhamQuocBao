using UnityEngine;

/// <summary>
/// Script luyện tập Bài 1.3: enemy tự chạy và đảo chiều khi rời trigger.
/// Cần Rigidbody2D + Collider2D (isTrigger) trên chân / đầu đường.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class SimpleEnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector3(-(Mathf.Sign(moveSpeed)), 1f, 1f);
    }
}
