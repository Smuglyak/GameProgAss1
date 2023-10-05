using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Vector3 playerVelocity;
    Vector3 move;

    public float walkSpeed = 5;
    public float runSpeed = 8; 
    public float jumpHeight = 2;
    public float gravity = -9.18f;
    static public bool bluePickedUp = false;
    public int jumpCount = 0;
    static public int maxJumpCount = 1;
    public bool isGrounded ; 
    private CharacterController controller;
    private Animator animator;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        ProcessMovement();
        ProcessGravity();
        // Debug.Log(playerVelocity);
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }

    void UpdateAnimator()
    {
        isGrounded = controller.isGrounded; 
        
        animator.SetBool("isGrounded", isGrounded);
        
        // TODO 
        if (isGrounded) {
            if (move != Vector3.zero)
            {
                if(GetMovementSpeed() == runSpeed) {
                    animator.SetFloat("Speed", 1f);
                }
                else if(GetMovementSpeed() == walkSpeed)
                {
                    animator.SetFloat("Speed", 0.5f);
                }
        
            }
            else
            {
                animator.SetFloat("Speed", 0.0f);
            }
        }
        else {

        }
        
        
    }

    void ProcessMovement()
    { 
        float speed = GetMovementSpeed();

        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * Input.GetAxis("Vertical") + cameraRight * Input.GetAxis("Horizontal");
        move = moveDirection.normalized * speed;
        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }
    }

    public void ProcessGravity()
    {
        isGrounded = controller.isGrounded;
        
        //animator.SetBool("bluePickedUp", bluePickedUp);
        // Since there is no physics applied on character controller we have this applies to reapply gravity
        
        if (isGrounded)
        {            
            if (playerVelocity.y < 0.0f) // we want to make sure the players stays grounded when on the ground
            {
                playerVelocity.y = -1.0f;
            }
            animator.SetBool("doubleJump", false);
            jumpCount = 0;
        }
        else // if not grounded
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }       
        bool canJump = isGrounded || !isGrounded && bluePickedUp && jumpCount < maxJumpCount;
        if (Input.GetButtonDown("Jump") && canJump) // Code to jump
        {
            playerVelocity.y = -1.0f;
            playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            ++jumpCount;
            if (!isGrounded && bluePickedUp && jumpCount == 2)
            {
                animator.SetBool("doubleJump", true);
            }
        }
        
        controller.Move((playerVelocity + move) * Time.deltaTime);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
