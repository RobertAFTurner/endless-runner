using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask floorLayerMask;

    [SerializeField]
    private int jumpHeight = 5;

    [SerializeField]
    private int boostSpeed = 5;

    [SerializeField]
    private float totalJumpTime = 2f;

    [SerializeField]
    private Animator animator;

    private float jumpTime;
    private bool isJumping = false;
    private Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumpTime = totalJumpTime;
    }

    void Update()
    {
        HandleJump();
        MaintainAir();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                jumpTime = totalJumpTime;
                isJumping = true;
                playerRigidBody.velocity = Vector2.up * jumpHeight;
                animator.SetBool("isJumping", isJumping);
                GlobalGameStats.platformSpeed = GlobalGameStats.platformSpeed += 0.1f; 
            }
        }
    }

    private void MaintainAir()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTime >= 0)
            {
                playerRigidBody.velocity = Vector2.up * jumpHeight;
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;

        if (!isJumping && IsGrounded())
            animator.SetBool("isJumping", isJumping);
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.3f;
        var collider = GetComponent<BoxCollider2D>();

        RaycastHit2D cast = Physics2D.BoxCast(collider.bounds.center,
                                              collider.bounds.size,
                                              0f,
                                              Vector2.down,
                                              extraHeight,
                                              floorLayerMask);

        return cast.collider != null;
    }
}
