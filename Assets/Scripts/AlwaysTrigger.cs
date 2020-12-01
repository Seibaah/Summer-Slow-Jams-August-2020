using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysTrigger : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
}
