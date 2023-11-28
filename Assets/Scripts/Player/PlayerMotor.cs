using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class playerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    private bool sprinting;
    public float sprintSpeed = 8f;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    
    //receives inputs from inputmanager script and applies them to charactercontroller.
    public void Processmove(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        // z because the joystick or keyboard translates up and down into forward and backwards instead.
        moveDirection.z = input.y; 
        controller.Move(transform.TransformDirection(moveDirection)* speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity* speed * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity = new Vector3(playerVelocity.x, jumpHeight, playerVelocity.z);
        }
    }
    public void Sprinting() 
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = sprintSpeed;
        }
        else if (!sprinting)
        {
            speed = 5f;
        }
        
    }
}
