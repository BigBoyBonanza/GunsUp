using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Camera vision;

    bool isGrounded;
    bool sprintToggle = false;

    public float speed = 12f;
    public float crouchSpeed = 10f;
    public float walkspeed = 12f;
    public float sprint = 28f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float airControl = 0.25f;
    public Vector3 lastMove;

    Vector3 velocity;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetButtonDown("Crouch"))
        {
            speed = crouchSpeed;
            //vision.fieldOfView -= 5;
            controller.height -= 1.0f;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            speed = walkspeed;
            //vision.fieldOfView += 5;
            controller.height += 1.0f;
        }
        if (Input.GetButtonDown("Sprint"))
        {
            speed = sprint;
            //vision.fieldOfView += 5;
        }
        if(Input.GetButtonUp("Sprint"))
        {
            speed = walkspeed;
            //vision.fieldOfView -= 5;
        }

        if(!isGrounded)
        {
            controller.Move(lastMove * speed * Time.deltaTime);
        }

        if (isGrounded)
        {
            controller.Move(move * speed * Time.deltaTime);
            lastMove = move;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
