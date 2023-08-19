//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
//using UnityEngine;

//public class WallRunning : MonoBehaviour
//{

//    [Header("wallrunning")]
//    public LayerMask whatIsWall;
//    public LayerMask whatIsGround;
//    public float wallRunForce;
//    public float maxWallRunTime;
//    private float wallRunTimer;

//    [Header("Input")]
//    private float horizontalInput;
//    private float verticalInput;

//    [Header("Dectection")]
//    public float wallCheackDistance;
//    public float minJumpHeight;
//    private RaycastHit leftwallhit;
//    private RaycastHit rightwallhit;
//    private bool wallLeft;
//    private bool wallRight;

//    [Header("References")]
//    public Transform orientation;
//    private PlayerMovement pm;
//    private Rigidbody rb;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        pm = GetComponent<PlayerMovement>();
//    }


//    private void Update()
//    {
//        CheckForWall();
//        StateMachine();
//    }

//    private void FixedUpdate()
//    {
//        if(pm.wallrunning)
//        {
//            WallRunningMovement();
//        }
//    }

//    private void CheckForWall()
//    {

//        wallRight = Physics.Raycast(transform.position, orientation.right, out rightwallhit, wallCheackDistance, whatIsWall);
//        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftwallhit, wallCheackDistance, whatIsWall);
//    }



//    private bool AboveGround()
//    {
//        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
//    }


//    private void StateMachine()
//    {
//        //Getting Inputs
//        horizontalInput = Input.GetAxisRaw("Horizontal");
//        verticalInput = Input.GetAxisRaw("Vertical");

//        //State 1 - Wallrunning
//        if((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
//        {
//            // start wallrun here
//            if (!pm.wallrunning)
//            {
//                StartWallRun();
//            }
//        }
//        //State 3 -None
//        else
//        {
//            if(pm.wallrunning)
//            {
//               StopWallRun();
//            }
//        }
//    }


//    private void StartWallRun()
//    {
//        pm.wallrunning = true;
//    }


//    private void WallRunningMovement()
//    {
//        rb.useGravity = false;
//        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
//        var grav = -9.8;
//        var x = Math.Min(0, (grav + rb.velocity.x));
//        Vector3 wallNormal = wallRight ? rightwallhit.normal : leftwallhit.normal;

//        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

//        //Forward force
//        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);
//    }


//    private void StopWallRun()
//    {
//        pm.wallrunning = false;
//    }


//}
