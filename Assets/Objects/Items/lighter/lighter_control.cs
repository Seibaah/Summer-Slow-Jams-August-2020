using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighter_control : MonoBehaviour
{
    GameObject lightGameObject;
    Light lightComp;
    bool lighterOn = true;
    static Animator anim;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // Make a game object and a child of the lighter
        lightGameObject = new GameObject("Lighter");
        lightGameObject.transform.parent = GameObject.Find("lighter").transform;

        // Add the light component
        lightComp = lightGameObject.AddComponent<Light>();

        //Set the light intensity to 0
        lightComp.intensity = 1.5f;

        // Set color and position
        Color light_color = new Color (222.0f/255.0f, 218.0f/255.0f, 156.0f/255.0f);
        lightComp.color = light_color;
        lightGameObject.transform.position = GameObject.Find("lighter").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //On a right click turn the light on or off
        if (Input.GetKeyUp(KeyCode.Mouse1) && lighterOn == false){
            lightGameObject.SetActive(true);
            lighterOn=true;
        } else if (Input.GetKeyUp(KeyCode.Mouse1) && lighterOn == true){
            lightGameObject.SetActive(false);
            lighterOn=false;
        }
    }
}
