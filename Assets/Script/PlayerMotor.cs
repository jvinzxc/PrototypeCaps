using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool IsGrounded;
    private bool lerpCrouch;
    private bool crouching;
    private bool sprinting;
    public FixedJoystick joystick;
    public float crouchTimer;
    public float speed = 4f; //player movement speed
    public float gravity = -9.8f; //usual gravity is -9.8
    public float jumpHeight = 1f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move*speed*Time.deltaTime);
        // if already crouching
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            // if crouching turn value to 2 to 1
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            // if not crouching return the value to 2
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }
        }
        
    }
    //receive the inputs for our InputManager.cs and apply them to our character controller.
    public void processMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(IsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
            // to make the value of gravity dont over extend to -2 making it possible to jump
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if(IsGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight - 1.5f * gravity);
            //For Jumping Mechanic
        }
    }
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
        if (crouching)
        {
            speed = 2;
            // crouching speed is reduce
        }
        else
        {
            speed = 4;
            // revert the speed back after crouching
        }
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 4;
        }
    }
}
