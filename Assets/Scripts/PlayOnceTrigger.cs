using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnceTrigger : MonoBehaviour
{
    public bool triggered;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            // play audio
            audioSource.Play();
            triggered = true;
        }
    }
}
