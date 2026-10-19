using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script luyện tập Bài 1.3: di chuyển nhân vật 2D bằng Input System.
/// Gắn lên Player cùng với: SpriteRenderer, Rigidbody2D, CapsuleCollider2D.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class SimplePlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 8f;

    Rigidbody2D rb;
    Vector2 moveInput;
    bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
            jumpPressed = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }

        if (Mathf.Abs(moveInput.x) > 0.01f)
            transform.localScale = new Vector3(Mathf.Sign(moveInput.x), 1f, 1f);
    }
}
