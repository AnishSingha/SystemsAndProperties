using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] float raycastDistance = 10f;

    [SerializeField]LayerMask groundLayer;
    
   
    void Update()
    {
        Ray ray = new(transform.position, Vector3.down);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, raycastDistance, groundLayer))
        { 
            isGrounded = true;
            Debug.Log("HitGround");
        }
        else
        {
            isGrounded = false;
        }
    }
}
