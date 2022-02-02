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

    //Variables for Jumping
    private bool isGrounded = false;
    private bool isJumping = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpForce = 0.5f;
    const float checkRadius = 0.2f;

    //M&K inputs
    private float keyHorizontalInput = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Jumping();
        //JoystickPosition(); //Method for gamepad controls (Not Implemented yet)
    }

    public void Movement()
    {
        Vector2 targetVelocity = new Vector2(keyHorizontalInput * moveSpeed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelocity, ref refVelocity, moveSmoothing);

    }

    void Jumping()
    {
        if (isJumping && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
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
    }

    public void onJump(InputAction.CallbackContext context)
    {
        isJumping = context.performed;
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

}
