using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_controls : MonoBehaviour
{
    public static bool isDead;
    public bool hasFoundKey;
    static Animator anim;
    public CharacterController controller;
    public float gravity = -9.81f;
    Vector3 velocity;
    public float speed = 5f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Collider monster;
    public Camera cam2;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        if (isDead)
        {
            anim.SetBool("isDead", true);
            //mouse_camera.deadCamera = true;
            cam2.gameObject.SetActive(true);

        }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // player movement - forward, backward, left, right
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (z != 0 || x != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else anim.SetBool("isWalking", false);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            velocity.y += 1.5f * gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }  
    }

    void OnTriggerEnter(Collider monster)
    {
        if(monster.gameObject.CompareTag("Monster"))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
