using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pick_up : MonoBehaviour
{
    public Transform theDest;
    public CharacterController myPlayer;
    public float pickUpDistance = 3f;
    // Start is called before the first frame update
    void OnMouseDown(){
        if (Mathf.Abs(Vector3.Distance(myPlayer.transform.position, this.transform.position)) <= pickUpDistance){
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = true; 
            this.transform.parent = GameObject.Find("Destination").transform;
            this.transform.position = theDest.position;
        }       
    }
    void OnMouseUp(){
       
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 600f);

        this.transform.parent = null;
    }
}
