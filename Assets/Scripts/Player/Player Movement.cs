using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // horiz movement variables
    private float horizVelocity;
    [SerializeField] float speed;

    // jump variables
    [SerializeField] float jumpingPower;
    [SerializeField] float coyoteTime;
    private float coyoteTimer;
    [SerializeField] float jumpBufferTime;
    private float jumpBufferTimer;

    // player object variables
    private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private bool isFacingRight = true;

    void Start()
    {
        Application.targetFrameRate = 60; // move to Game Manager script

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // move direction
        horizVelocity = Input.GetAxisRaw("Horizontal");

        // coyote time
        if (IsGrounded())
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }

        // jump buffering
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        // player jump
        if (jumpBufferTimer > 0f && coyoteTimer > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        // control jump height
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            coyoteTimer = 0f;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // horizontal movement
        rb.linearVelocity = new Vector2(horizVelocity * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizVelocity < 0f || !isFacingRight && horizVelocity > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
