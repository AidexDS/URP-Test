using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class move : MonoBehaviour
{


[Header("References")]
public ClimbingsSysz cs;
[Header("Movement")]
 public float moveSpeed;
 public float groundDrag;
// public float climbSpeed;

 public float jumpForce;
 public float jumpCooldown;
 public float airMulty;
 bool readyToJump;
 public bool climbing;

 [Header("Keybinds")]
public KeyCode jumpkey = KeyCode.Space;

[Header("Groundcheck")]
public float playerHeight;
public LayerMask whatIsGround;
public bool grounded ;

public Transform orientation;

float horizontalInput;
float verticalInput;

Vector3 moveDirection;
Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, whatIsGround);
        

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded){
            rb.drag = groundDrag;
        }
        else{
            rb.drag = 0;

            Debug.Log("Grounded: " + grounded);
            
            if(grounded){
                Debug.DrawRay(transform.position, Vector3.down * ( playerHeight * 0.5f), Color.green);
            }else{
                Debug.DrawRay(transform.position, Vector3.down * ( playerHeight * 0.5f), Color.red);
            }
        }

     
           
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput(){
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");

         // when to jump
        if(Input.GetKey(jumpkey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {

        if(cs.exitingWall) return;

        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMulty, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

     private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
