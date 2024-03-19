using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]   
    private float moveSpeed;
    public float wlakSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        walking,
        spritning,
        crouching,
        air,
    }

    //Fryser rotationen så spilleren ikke falder og deffinere Rigidbody  
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;
    }

    private void Update()
    {
        //Groudn check med raycast 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Kalder movement funktionen 
        MyInput();
        SpeedControl();
        statHandler();

        //Laver drag så man ikke glider på jorden
        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        //Kalder kraft funtionen 
        MovePlayer();
    }

    //Move input
    private void MyInput () 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        //Tjækker for om der trykket på hop kanppen
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            Jump();

            readyToJump = false;


            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //Start Crouch
        if(Input.GetKeyDown(crouchKey)) 
        { 
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        }

        //Stop Crouch 
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void statHandler()
    {
        //Crouch mode 
        if (Input.GetKeyUp(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;

        }


        //Sprint mode
        if (grounded && Input.GetKey(sprintKey)) 
        {
            state = MovementState.spritning;
            moveSpeed = sprintSpeed;
        }

        // Wlak mode
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = wlakSpeed;
            
        }

        //Air mode
        else 
        {
            state = MovementState.air;
        }

    }

    private void MovePlayer () 
    { 
        //Gøre så man kan bevæge spilleren 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    //Sørge for at hastigheden af spileren er det man sætter den til 
    private void SpeedControl () 
    { 
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    
    }

    private void Jump()
    {
        //Reset y hastigheden
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //hop funktionen 
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        
    }

    //Sørge for man kan hoppe igen 
    private void ResetJump()
    {
        readyToJump = true;
        
    }
}
