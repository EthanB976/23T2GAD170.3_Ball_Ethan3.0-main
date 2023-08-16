using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //get audio
    [SerializeField] private AudioClip playerAudioSource;
    [SerializeField] private AudioSource jumpSoundEffect;

    [Header("Movemant")]
    private float moveSpeed;
    public float walkspeed;
    public float sprintSpeed;

    public float wallRunSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;


    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    public float startYScale;


    //binds jump to the space key
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    public KeyCode crouchKey = KeyCode.LeftControl;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    //FOr keyboard inputs
    float horizontalInput;
    float verticalInput;


    Vector3 moveDirection;

    Rigidbody rb;


    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air,
        wallrunning,
    }

    public bool crouching;
    public bool wallrunning;


    // Start is called before the first frame update
    private void Start()
    {
        //stops player from falling over
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        //Check ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        if (grounded)
        {
            ResetJump();
        }


        MyInput();
        StateHandler();
        SpeedContrtol();

        //Handle the drag
        if(grounded )
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
        MovePlayer();
    }

    private void MyInput()
    {
        //for keyboard inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (grounded)
        {
            //When player hits key, jump
            if (Input.GetKeyDown(KeyCode.Space) && readyToJump)
            {
                readyToJump = false;

                Jump();

                //Player can hold space and continusouly jump, unfortunatly couldn't get this to work for some reason as the readtojump
                //function didn't work but when i fixed that then it called the jump function every frame so i had to change it to getkeydown to fix this
                Invoke(nameof(ResetJump), jumpCoolDown);

                Debug.Log("spacebar pressed");
            }
        }

        // if pressed crouch player
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            //Add force to put player on the ground
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //Stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

    }
    

    private void StateHandler()
    {

        //Mode - Walking
        if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkspeed;
        }
        //Mode - Air
        else
        {
            state = MovementState.air;
        }
        //Mode - Wallrunning
        if (wallrunning)
        {
            state = MovementState.wallrunning;
            moveSpeed = wallRunSpeed;
        }


        //Mode - Crouching
        if(Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }


        //Mode - Sprinting
        if(grounded && Input.GetKey(KeyCode.LeftShift))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;

        }
    }





    private void MovePlayer()
    {
        //calculate movedirection
        //makes sure player is always moveing in the direction the camera is facing
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        //if player on ground
        if (grounded)
        {
            //add force to the player
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        //if player is in the air
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10F * airMultiplier, ForceMode.Force);
        }
        
    }


    //manualy control players speed
    private void SpeedContrtol()
    {

        Vector3 FlatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(FlatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = FlatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }


    private void Jump()
    {
        //reset y velocity, makes sure you always jump the same height
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //jump once
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        //playerAudioSource.PlayOneShot(jumpSoundEffect);
    }


    private void ResetJump()
    {
        if (grounded)
        {
            readyToJump = true;
        }
        
    }


    public void SetPosition(double x, double y, double z)
    {
        Vector3 newPosition = new Vector3((float)x, (float)y, (float)z);
        transform.position = newPosition;
    }



}
