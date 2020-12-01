using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect_key : MonoBehaviour
{
    void OnMouseUp()
    {
        Door.doorKey = true;
        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
    }
}
