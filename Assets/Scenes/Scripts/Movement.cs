using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{


    [Header("Movement")]
    private float moveSpeed;
    public float wlakSpeed;
    public float sprintSpeed;
    public float groundDrag;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

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

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Stamina")]
    public Image staminaBar;
    public float stamina;
    public float maxStamina;
    public float runCost;
    public float charegeRate;
    private Coroutine recharge_1;

    [Header("Smoke")]
    public GameObject smoke;
    public float smokeDamge;

    [Header("Strings")]
    string recharge = "recharge";
    string rundrain = "rundrain";
    string smokedrain = "smokedrain";

    [Header("MISC")]
    public Transform orientation;
    public MovementState state;



    Rigidbody rb;





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



        if (smoke != null && stamina == 0f)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("DeathScreenRøg");

        }



    }

    private void FixedUpdate()
    {
        //Kalder kraft funtionen 
        MovePlayer();
        if (state == MovementState.walking && smoke == null)
        {
            Stamina(recharge);
        }
        else
        {
            Stamina(rundrain);
        }

        if (smoke != null)
        {
            Stamina(smokedrain);
            
        }
    }

    //Move input
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        //Tjækker for om der trykket på hop kanppen
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            Jump();

            readyToJump = false;


            Invoke(nameof(ResetJump), jumpCooldown);




        }



        //Start Crouch
        if (Input.GetKeyDown(crouchKey))
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

            Stamina(rundrain);

            if (stamina == 0)
            {
                state = MovementState.walking;
                moveSpeed = wlakSpeed;

            }




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

            Stamina(rundrain);



        }


    }

    //Gøre så man kan bevæge spilleren 
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //På slope 
        if (OnSloop() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            //sørge man ikke bouncer når man går op ad slopes 
            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        //På jorden
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //I luften 
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        //Slukker for gravty så man ikke glider ned fra slopes
        rb.useGravity = !OnSloop();
    }

    //Sørge for at hastigheden af spileren er det man sætter den til 
    private void SpeedControl()
    {
        //Sørge at man går op ad slopes med samme hastighed som man går på jorden.  
        if (OnSloop() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }


        //Sørge for at det er den samme hastighed på jorden og i luften
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }

        }

    }

    private void Jump()
    {
        if (stamina > 0f)
        {
            exitingSlope = true;

            //Reset y hastigheden
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //hop funktionen 
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }



    }

    //Sørge for man kan hoppe igen 
    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;

    }

    void Stamina(string chargeState)
    {
        if (chargeState == rundrain)
        {
            stamina -= runCost + Time.deltaTime;
            if (stamina < 0) stamina = 0;
            staminaBar.fillAmount = stamina / maxStamina;
      
        }
        if (chargeState == smokedrain)
        {
            stamina -= smokeDamge + Time.deltaTime;
            if (stamina < 0) stamina = 0;
            staminaBar.fillAmount = stamina / maxStamina;
          
        }
        if (chargeState == recharge)
        {
            stamina += charegeRate / 10f;
            if (stamina > maxStamina)
            {
                stamina = maxStamina;
            }
            staminaBar.fillAmount = stamina / maxStamina;
         
        }


    }

    //Laver raycast når man er på slope da der en vinkel
    private bool OnSloop()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    //Regner hastighed ud når man er på slope  
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }



   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Røg"))
        {
            smoke = other.gameObject;
            Stamina(rundrain);


        }

    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Røg"))
        {
            smoke = null; // Reset smoke GameObject to null when player exits the smoke area

        }
    }



}
