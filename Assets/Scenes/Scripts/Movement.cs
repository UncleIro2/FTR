using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //Fryser rotationen så spilleren ikke falder og deffinere Rigidbody  
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update()
    {
        //Groudn check med raycast 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Kalder movement funktionen 
        MyInput();
        SpeedControl();

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


            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
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
