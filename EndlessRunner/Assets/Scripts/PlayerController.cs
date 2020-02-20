using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask floorLayerMask;

    [SerializeField]
    private int jumpHeight;

    [SerializeField]
    private float boostSpeed;

    [SerializeField]
    private float totalJumpTime;

    [SerializeField]
    private Animator animator;

    private float jumpTime;
    private bool isJumping = false;
    private Rigidbody2D playerRigidBody;

    private float currentSpeed;

    [SerializeField]
    private float boostTime;
    private float boostTimer;
    private bool isBoosting = false;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumpTime = totalJumpTime;
        boostTimer = boostTime;
    }

    void Update()
    {
        HandleJump();
        HandleBoost();
        MaintainAir();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded() || isBoosting)
            {
                jumpTime = totalJumpTime;
                isJumping = true;
                isBoosting = false;
                playerRigidBody.velocity = Vector2.up * jumpHeight;
                animator.SetBool("isJumping", isJumping);
                animator.SetBool("isBoosting", isBoosting);
            }
        }        
    }

    private void HandleBoost()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !isBoosting)
        {
            currentSpeed = GlobalGameStats.platformSpeed;
            GlobalGameStats.platformSpeed = currentSpeed * boostSpeed;
            isBoosting = true;
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
            animator.SetBool("isBoosting", isBoosting);
        }

        if(isBoosting)
        {
            boostTimer -= Time.deltaTime;
            if(boostTimer < 0)
            {
                GlobalGameStats.platformSpeed = currentSpeed;
                isBoosting = false;
                boostTimer = boostTime;
                animator.SetBool("isBoosting", isBoosting);
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
