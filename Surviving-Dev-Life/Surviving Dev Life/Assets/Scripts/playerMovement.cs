using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 10;
    private float gravity = -10f;
    private float jumpHeight = 3f;

    public CharacterController controller;
    
    Vector3 currVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {


       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && currVelocity.y < 0)
        {
            currVelocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown("space") && isGrounded) 
        {
            currVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        currVelocity.y += gravity * Time.deltaTime;

        controller.Move(currVelocity * Time.deltaTime);


    }

}
