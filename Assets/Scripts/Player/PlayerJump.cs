using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; 
    public KeyCode jumpKey = KeyCode.Space; 

    private Rigidbody rb;

    GroundCheck groundCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();

    }

    public void Jump()
    {
        

        if (Input.GetKeyDown(jumpKey) && groundCheck.isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
