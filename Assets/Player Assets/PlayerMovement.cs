using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    //Variables for Movement
    private Rigidbody2D rigid;
    private Vector2 moveInput; //The player movement input initialized by the callback context
    private Vector2 refVelocity = Vector2.zero;
    [SerializeField] private float moveSpeed = 10f; //Player movement speed
    [SerializeField] private float moveSmoothing = 0.05f; //Player movement smoothing
    public bool isMoving;

    //Variables for Jumping
    private bool isGrounded = false;
    private bool isJumping = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpForce = 0.5f;
    const float checkRadius = 0.1f;

    //M&K inputs
    public float keyHorizontalInput = 0;

    //CoyoteTime variables
    //private bool canCoyoteJump;
    //private float coyoteTime = 0.2f;
    //private float coyoteTimeCounter;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        whatIsGround = LayerMask.GetMask("Obstacle");
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 targetVelocity = new Vector2(keyHorizontalInput * moveSpeed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelocity, ref refVelocity, moveSmoothing);

        if(isMoving && isGrounded)
            SoundManager.playSound?.Invoke(SoundManager.SoundType.PlayerMove, transform.position);
    }

    void Jumping()
    {
        if (isJumping && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            SoundManager.playOneShotSound?.Invoke(SoundManager.SoundType.PlayerJump);
        }
    }

    void GroundCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isGrounded = (collider != null) ? true : false;
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        keyHorizontalInput = moveInput.x;
        isMoving = context.performed;
    }

    public void onJump(InputAction.CallbackContext context)
    {
        isJumping = context.performed;
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Jumping();
    }

}
