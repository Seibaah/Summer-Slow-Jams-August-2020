using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_camera : MonoBehaviour
{
    public static bool deadCamera;
    public float sensitivity = 100f;

    public Transform playerBody;
    public Transform playerHead;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (deadCamera)
        {
            /*
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-70.0f, -1.085f, 180.0f), Time.deltaTime * 200);
            transform.position = new Vector3(-0.09f, 0.582f, -1.287f);
            transform.rotation = newRot;*/
            
        } else
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -50f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
