using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_collision : MonoBehaviour
{
    Vector3 velocity;
    public Transform groundCheck;
    public float sphereRadius = 2f;
    public LayerMask groundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = 0.1f;
            velocity.x = 0.1f;
            velocity.z = 0.1f;
        }
    }
}
