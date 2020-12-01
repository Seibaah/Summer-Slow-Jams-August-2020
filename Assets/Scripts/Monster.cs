using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Monster : MonoBehaviour
{
    public bool beingHandled = false;
    public static bool isAttack;
    public Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack)
        {
            Vector3 playerPos = GameObject.Find("Ch42_nonPBR").transform.position;
            Vector3 pos = new Vector3(playerPos.x, 0.0f, playerPos.z - 1);
            transform.position = pos;
            anim.SetBool("isAttack", true);
            isAttack = false;
            StartCoroutine( HandleIt() );
            
        }
    }

    private IEnumerator HandleIt()
    {
    beingHandled = true;
    // process pre-yield
    yield return new  WaitForSecondsRealtime(6);
    // process post-yield
    
    SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    Debug.Log ("QUIT!");
  Application.Quit();
    beingHandled = false;
    }
}
