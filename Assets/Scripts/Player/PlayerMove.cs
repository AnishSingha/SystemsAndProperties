using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public void Move()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(HorizontalInput, 0f, VerticalInput).normalized;

        // Move the object
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
